using Raylib_cs;
using CommonLibrary;
using System.Numerics;
using Game.Cursor;
public class Ceil
{
    private CeilType type { get; set; }
    private Vector2 position { get; set; }
    private int size { get; set; }
    private Color color { get; set; }
    private bool isHovered { get; set; }

    private bool hasResisted { get; set; } = false;

    private float _timer = 0;

    public Ceil(CeilType type, int x, int y, int size)
    {
        this.type = type;
        this.position = new Vector2(x, y);
        this.size = size;
        
        this.color = Color.DarkGray;
    }

    public virtual void Draw(string name = "")
    {
        switch (type)
        {
            case CeilType.EMPTY:
                color = Color.DarkGray;
                break;
            case CeilType.WALL:
                color = Color.Black;
                break;
            case CeilType.INFECTED:
                color = Color.DarkGreen;
                break;
            case CeilType.NEUTRAL:
                color = Color.LightGray;
                break;
            case CeilType.DEFENDER:
                color = Color.Blue;
                break;

        }
        if (type != CeilType.EMPTY) Raylib.DrawRectangle((int)position.X, (int)position.Y, size, size, color);

        if (isHovered && type != CeilType.WALL)
        {
            Raylib.DrawRectangle((int)position.X, (int)position.Y, size, size, Color.DarkBrown);
            Raylib.DrawText(GameData.ConvertCeilTypeToString(type), (int)position.X + 2, (int)position.Y + size / 2 - 10, 3, Color.White);

        }
        else
        {

            Raylib.DrawRectangleLines((int)position.X, (int)position.Y, size, size, Color.Black);
            Raylib.DrawText(name, (int)position.X + 2, (int)position.Y + size / 2 - 10, 3, Color.White);
        }

        if (hasResisted)
        {
            Raylib.DrawText("RESISTED", (int)position.X + 2, (int)position.Y + size / 2 - 10 + (int)Math.Round(_timer + 1), 3, Color.Red);
        }


    }

    public virtual void Update()
    {



        if (Raylib.GetMouseX() >= position.X && Raylib.GetMouseX() <= position.X + size && Raylib.GetMouseY() >= position.Y && Raylib.GetMouseY() <= position.Y + size)
        {
            // Console.WriteLine(GetCeilPosition());
            isHovered = true;
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                // TransformIntoType(Cursor.Instance.getType());
                // Cursor.Instance.setType(CeilType.HOVERED);
            }
        }
        else isHovered = false;

        if (hasResisted)
        {
            _timer += Raylib.GetFrameTime();
            if (_timer > 4)
            {
                hasResisted = false;
                _timer = 0;
            }
        }


    }

    // private void TransformIntoType(CeilType value)
    // {
     
    //     if (type == CeilType.WALL)
    //     {
    //         return;
    //     }
    //     type = value;
    // }

    public Vector2 GetCeilPosition()
    {
        return new Vector2((int)position.Y / size, (int)position.X / size);
    }

    public CeilType GetCeilType()
    {
        return type;
    }

    public virtual List<Vector2> GetAdjacentCells(Ceil[,] map)
    {
        List<Vector2> adjacentCells = new List<Vector2>();
        Vector2 currentPos = GetCeilPosition(); // Position de la case courante

        Console.WriteLine("currentPos: " + currentPos);

        int x = (int)currentPos.X;
        int y = (int)currentPos.Y;

        // Vector2[] directions = new Vector2[]
        // {
        //     new Vector2(x -1, y), // Left
        //     new Vector2(x + 1, y),  // Right
        //     new Vector2(x, y -1), // Up
        //     new Vector2(x, y + 1)   // Down
        // };

        // List<Vector2> randomDirections = new List<Vector2>();
        // int randomDirectionNbr = Randomizer.GetRandomNumber(1, radius);

        // for (int i = 0; i < randomDirectionNbr; i++)
        // {
        //     randomDirections.Add(directions[Randomizer.GetRandomNumber(0, directions.Length)]);
        //     directions = directions.Where(val => val != randomDirections[i]).ToArray();
        // }

        adjacentCells.Add(new Vector2(x - 1, y));
        adjacentCells.Add(new Vector2(x + 1, y));
        adjacentCells.Add(new Vector2(x, y - 1));
        adjacentCells.Add(new Vector2(x, y + 1));

        return adjacentCells;
    }

    public virtual bool Resist(int res, int power)
    {
        if (hasResisted)
        {
            return true;
        }
        if (Randomizer.GetRandomNumber(0, res) < power)
        {
            return false;
        }
        hasResisted = true;
        return true;
    }

}