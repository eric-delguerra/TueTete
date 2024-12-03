using System.Numerics;
using CommonLibrary;
using Raylib_cs;
public class Defender : Ceil
{
    public int ResistanceMalus { get; set; } = 0;
    public int Resistance { get; set; }
    private int _power { get; set; } = 5;
    private float _time;
    public string Name { get; set; }

    public Defender(CeilType type, int x, int y, int size)
        : base(type, x, y, size)
    {
        // percent
        Resistance = 130;
        Name = Randomizer.GetRandomName();
    }

    public override void Draw(string name = "")
    {
        Console.WriteLine("Defender: " + Name);
        base.Draw(Name);
    }

    public override void Update()
    {
        base.Update();
        _time += Raylib.GetFrameTime();
        // N'active pas la défense si le temps est trop court
        if (_time < 60) return;
        if (_time > GameData.GAME_LOOP_TIME - 0.2)
        {
            DefendAdjacentCell();
            _time = 0;
        }
    }

    public override bool Resist(int _, int power)
    {
        return base.Resist(Resistance - ResistanceMalus, power);
    }

    public void DefendAdjacentCell()
    {

        List<Vector2> adjacentCells = base.GetAdjacentCells(ServiceLocator.Resolve<Ceil[,]>());
        foreach (Vector2 cell in adjacentCells)
        {
            Console.WriteLine("Defender: " + cell.X);
            Console.WriteLine("Defender: " + cell.Y);

            int x = Math.Abs((int)cell.X);
            int y = Math.Abs((int)cell.Y);

            Ceil ceil = ServiceLocator.Resolve<Ceil[,]>()[x - 1, y - 1];

            if (ceil.GetCeilType() == CeilType.NEUTRAL || ceil.GetCeilType() == CeilType.INFECTED)
            {
                if (!ceil.Resist(0, (int)_power))
                {
                    ServiceLocator.Resolve<Ceil[,]>()[x - 1, y - 1] = new Defender(
                    CeilType.DEFENDER,
                     y * GameData.CELLSIZE,
                      x * GameData.CELLSIZE,
                       GameData.CELLSIZE
                       );
                }
            }
        }
    }


}
