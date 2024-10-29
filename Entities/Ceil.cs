using Raylib_cs;
using CommonLibrary;
using System.Numerics;
using Game.Cursor;
class Ceil
{

    private CeilType type { get; set; }

    private Vector2 position { get; set; }
    private int size { get; set; }

    private Color color { get; set; }

    private bool isPlayer { get; set; }

    public Ceil(CeilType type, int x, int y, int size, bool isPlayer = false)
    {
        this.type = type;
        this.position = new Vector2(x, y);
        this.size = size;
        this.isPlayer = isPlayer;
        this.color = Color.DarkGray;
    }

    public void Draw()
    {
        switch (type)
        {
            case CeilType.EMPTY:
                color = Color.DarkGray;
                break;
            case CeilType.WALL:
                color = Color.Black;
                break;
            case CeilType.PLAYER:
                color = Color.Blue;
                break;
            case CeilType.GOAL:
                color = Color.Green;
                break;
            case CeilType.BOUCE_UP:
                color = Color.Orange;
                break;
            case CeilType.BOUCE_DOWN:
                color = Color.Orange;
                break;
            case CeilType.BOUCE_LEFT:
                color = Color.Orange;
                break;
            case CeilType.BOUCE_RIGHT:
                color = Color.Orange;
                break;
            case CeilType.TELEPORT:
                color = Color.Purple;
                break;
            case CeilType.TELEPORT_DEST:
                color = Color.Purple;
                break;
            case CeilType.HOVERED:
                color = Color.Brown;
                break;
            case CeilType.PATH:
                color = Color.DarkBlue;
                break;
        }
        if (type != CeilType.EMPTY) Raylib.DrawRectangle((int)position.X, (int)position.Y, size, size, color);
        Raylib.DrawRectangleLines((int)position.X, (int)position.Y, size, size, Color.Black);

        Raylib.DrawText(type.ToString(), (int)position.X + 10, (int)position.Y + size / 2 - 10, 8, Color.White);
    }

    public void Update()
    {
        if (type == CeilType.EMPTY || type == CeilType.HOVERED)
        {
            if (Raylib.GetMouseX() >= position.X && Raylib.GetMouseX() <= position.X + size && Raylib.GetMouseY() >= position.Y && Raylib.GetMouseY() <= position.Y + size)
            {
                type = CeilType.HOVERED;
                Console.WriteLine(GetCeilPosition());
            } else
            {
                type = CeilType.EMPTY;
            }
        }
        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            if (type == CeilType.HOVERED)
            {
                type = Cursor.Instance.getType();
                Cursor.Instance.setType(CeilType.HOVERED);
            }
        }
    }
    public Vector2 GetCeilPosition()
    {
        return new Vector2((int)position.X / size, (int)position.Y / size);
    }

    public void TransformIntoType(CeilType type)
    {
        if(this.type == CeilType.EMPTY)
            this.type = type;
    }

    public CeilType GetCeilType()
    {
        return type;
    }

}