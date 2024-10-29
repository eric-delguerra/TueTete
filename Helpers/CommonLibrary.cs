using System.Numerics;

namespace CommonLibrary
{
    public class MapData
    {
        public int[][] map { get; set; }
    }

    public class GameData
    {
        public static int SCREEN_WIDTH { get; set; } = 1200; 
        public static int SCREEN_HEIGHT { get; set; } = 960;
        public static int CELLSIZE { get; set; } = SCREEN_WIDTH / 15;

        public static int MAP_WIDTH { get; set; } = 10;
    }

      public enum CeilType
    {
        EMPTY = 0,
        WALL = 1,
        PLAYER = 2,
        GOAL = 3,
        BOUCE_UP = 4,
        BOUCE_DOWN = 5,
        BOUCE_LEFT = 6,
        BOUCE_RIGHT = 7,
        TELEPORT = 8,
        TELEPORT_DEST = 9,
        HOVERED = 10,
        PATH = 11
    }

    public enum PlayerDirection
    {
        UP = 0,
        DOWN = 1,
        LEFT = 2,
        RIGHT = 3
    }



}