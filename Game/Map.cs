using System.Text.Json;
using CommonLibrary;
public class Map
{
    private static Map instance = null;
    private static readonly object lockObj = new object();

    public int[,] MapGrid { get; private set; }

    // Constructeur privé pour empêcher l'instanciation directe
    private Map() { }

    public static Map Instance
    {
        get
        {
            lock (lockObj)
            {
                if (instance == null)
                {
                    instance = new Map();
                }
                return instance;
            }
        }
    }

    // Méthode pour charger la map depuis un fichier JSON
    public void LoadMapFromJson(string filePath)
    {
        if (MapGrid != null)
        {
            Console.WriteLine("La map a déjà été chargée.");
            return;
        }

        string jsonString = File.ReadAllText(filePath);
        var mapData = JsonSerializer.Deserialize<MapData>(jsonString);

        int rows = mapData.map.Length;
        int cols = mapData.map[0].Length;
        MapGrid = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                MapGrid[i, j] = mapData.map[i][j];
            }
        }

        Console.WriteLine("Map chargée avec succès depuis le fichier JSON.");
    }
    public int[,] GetMap()
    {
        if (MapGrid == null)
        {
            throw new InvalidOperationException("La map n'a pas été chargée. Utilisez LoadMapFromJson d'abord.");
        }

        return MapGrid;
    }
}
