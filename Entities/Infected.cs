using System.Numerics;
using CommonLibrary;
using Game.Timer;
using Raylib_cs;
public class Infected : Ceil
{
    public int SpeedBonuses { get; set; }
    public int Speed { get; set; }
    public string Name { get; set; }
    private float _time;
    private float _power { get; set; } = 5;
    private int _infectionRadius { get; set; } = 1;


    public Infected(CeilType type, int x, int y, int size)
        : base(type, x, y, size)
    {
        // percent
        Speed = 100;
        Name = Randomizer.GetRandomName();
    }

    public override void Draw(string name = "")
    {
        base.Draw(Name);
    }

    public override void Update()
    {
        base.Update();
        _time += Raylib.GetFrameTime();
        bool hasToUp = ServiceLocator.Resolve<GameTimer>().GetState();
        if (hasToUp && _time > GameData.GAME_LOOP_TIME)
        {
            InfectAdjacentCell();


            ServiceLocator.Resolve<GameTimer>().SetState(false);
            _time = 0;

        }
    }

    public void InfectAdjacentCell()
    {

        List<Vector2> adjacentCells = base.GetAdjacentCells(ServiceLocator.Resolve<Ceil[,]>());
        foreach (Vector2 cell in adjacentCells)
        {
            Console.WriteLine(cell.X);
            Console.WriteLine(cell.Y);

            int x = Math.Abs((int)cell.X);
            int y = Math.Abs((int)cell.Y);
            Ceil ceil = ServiceLocator.Resolve<Ceil[,]>()[x - 1, y - 1];

            if (ceil.GetCeilType() == CeilType.NEUTRAL
             || ceil.GetCeilType() == CeilType.DEFENDER
            )
            {
                if (!ceil.Resist(0, (int)_power))
                {
                    ServiceLocator.Resolve<Ceil[,]>()[x - 1, y - 1] = new Infected(
                    CeilType.INFECTED,
                     y * GameData.CELLSIZE,
                      x * GameData.CELLSIZE,
                       GameData.CELLSIZE
                       );
                }
            }
        }
    }

}
