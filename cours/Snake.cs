
public class Snake
{
    public int x;
    public int y;
    private int PV;

    public Snake(int px, int py)
    {
        x = px;
        y = py;
        PV = 100;
    }

    public void Avance(int distanceX, int distanceY)
    {
        x += distanceX;
        y += distanceY;

        Console.WriteLine("le Snake avance de {0},{1}", distanceX, distanceY);
    }

    public int getPV()
    {
        return PV;
    }
}

public class MegaSnake : Snake
{
    public MegaSnake(int px, int py) : base(px, py)
    {
        Console.WriteLine("SuperSnake");
    }

    public void Avance(int distanceX, int distanceY)
    {
        x += distanceX;
        y += distanceY;

        Console.WriteLine("le SuperSnake avance de {0},{1}", distanceX, distanceY);
    }

    public void Phase()
    {
        Console.WriteLine("Phase");
    }
}