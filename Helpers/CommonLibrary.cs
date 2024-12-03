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

        public static int MAP_WIDTH { get; set; } = 20;
        public static int CELLSIZE { get; set; } = SCREEN_HEIGHT / (MAP_WIDTH + 2);

        public static int GAME_LOOP_TIME { get; set; } = 5;

        public static string ConvertCeilTypeToString(CeilType type)
        {
            switch (type)
            {
                case CeilType.EMPTY:
                    return "EMPTY";
                case CeilType.WALL:
                    return "WALL";
                case CeilType.INFECTED:
                    return "INFECTED";
                case CeilType.NEUTRAL:
                    return "NEUTRAL";
                case CeilType.DEFENDER:
                    return "DEFENDER";
                default:
                    return "UNKNOWN";
            }
        }
    }

    public enum CeilType
    {
        EMPTY = 0,
        WALL = 1,
        INFECTED = 2,
        NEUTRAL = 3,
        DEFENDER = 4,
    }


    public enum PlayerDirection
    {
        UP = 0,
        DOWN = 1,
        LEFT = 2,
        RIGHT = 3
    }

    public class Distance
    {
        public int GetCeilNumber(Ceil[] ceils, Vector2 position)
        {
            for (int i = 0; i < ceils.Length; i++)
            {
                if (ceils[i].GetCeilType() == CeilType.WALL)
                {
                    return i;
                }
            }
            return ceils.Length;
        }
    }

    public class Randomizer()
    {
        private static Random random = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static string GetRandomName()
        {
            string[] names = new string[]
            {
                "Pierre", "Marie", "Luc", "Sophie", "Antoine", "Claire",
                "John", "Emily", "William", "Emma", "James", "Olivia",
                "Carlos", "Isabella", "Santiago", "Maria", "Javier", "Lucia",
                "Lorenzo", "Giulia", "Matteo", "Sofia", "Marco", "Chiara",
                "Hans", "Anna", "Friedrich", "Greta", "Lukas", "Klara",
                "Hiroshi", "Yuki", "Takumi", "Sakura", "Kenta", "Aiko",
                "Wei", "Mei", "Li", "Xia", "Chen", "Ling",
                "Ahmed", "Fatima", "Omar", "Leila", "Karim", "Amina",
                "Arjun", "Priya", "Ravi", "Anjali", "Vikram", "Nina",
                "Ivan", "Anastasia", "Dmitri", "Svetlana", "Sergei", "Olga",
                "Bjorn", "Astrid", "Sven", "Freya", "Erik", "Ingrid",
                "Kofi", "Amina", "Kwame", "Zahra", "Ndidi", "Fatou",
                "Diego", "Mia", "Liam", "Zoe", "Noah", "Chloe"
            };
            return names[GetRandomNumber(0, names.Length)];
        }
        public static (int x, int y) GetRandomNeutralCell(CeilType[,] map)
        {
            List<(int x, int y)> neutralCells = new List<(int x, int y)>();

            // Parcours de la carte pour identifier les cases NEUTRAL
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == CeilType.NEUTRAL)
                    {
                        neutralCells.Add((i, j));
                    }
                }
            }

            // Si aucune case NEUTRAL n'existe, renvoyer (-1, -1)
            if (neutralCells.Count == 0)
            {
                return (-1, -1);
            }

            // Choisir une case aléatoire parmi les cases NEUTRAL
            int randomIndex = random.Next(0, neutralCells.Count);
            return neutralCells[randomIndex];
        }
    }
    

}