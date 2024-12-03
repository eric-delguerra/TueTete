using CommonLibrary;
using Game.Timer;
using Raylib_cs;
public class Neutral : Ceil
{
    public int ResistanceMalus { get; set; } = 0;
    public int Resistance { get; set; }
    public string Name { get; set; }

    public Neutral(CeilType type, int x, int y, int size)
        : base(type, x, y, size)
    {
        // percent
        Resistance = 100;
        Name = Randomizer.GetRandomName();
    }

    public override void Draw(string name = "")
    {
        base.Draw(Name);
        Raylib.DrawText("Resistance: " + Resistance, 50, 50, 3, Color.LightGray);
    }

    public override void Update()
    {
        base.Update();
    }

    public override bool Resist(int _, int power)
    {
        return base.Resist(Resistance - ResistanceMalus, power);
    }

}
