using System.Numerics;
using CommonLibrary;
class Player
{
    public Vector2 position { get; set; }

    private List<Vector2> path { get; set; } = new List<Vector2>();

    private PlayerDirection direction { get; set; } = PlayerDirection.RIGHT;
    public Player(Vector2 position)
    {
        this.position = position;
    }

    public Vector2 GetDirection(PlayerDirection direction)
    {
        switch (direction)
        {
            case PlayerDirection.UP:
                return new Vector2(0, -1);
            case PlayerDirection.DOWN:
                return new Vector2(0, 1);
            case PlayerDirection.LEFT:
                return new Vector2(-1, 0);
            case PlayerDirection.RIGHT:
                return new Vector2(1, 0);
            default:
                return new Vector2(0, 0);
        }
    }
    public void AddPath(Vector2 pos)
    {
        for (int i = 1; i < GameData.MAP_WIDTH - pos.X + 1; i++)
        {
            path.Add(new Vector2(pos.X + i, pos.Y));
        }
    }

    public (int, int) GetPosition()
    {
        return ((int)position.X, (int)position.Y);
    }

    public void SetPosition(Vector2 position)
    {
        this.position = position;
    }

    public bool CheckIfIsInPath(Vector2 pos)
    {
        foreach (var pathPos in path)
        {
            if (pathPos.X == pos.X && pathPos.Y == pos.Y)
            {
                return true;
            }
        }
        return false;
    }

}