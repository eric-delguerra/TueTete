using CommonLibrary;
using Raylib_cs;
using UI.Services;
using System.Numerics;
class Program
{
    static void Main()
    {
        Raylib.InitWindow(GameData.SCREEN_WIDTH, GameData.SCREEN_HEIGHT, "Casse tête");
        Raylib.SetTargetFPS(120);
        Map.Instance.LoadMapFromJson("map.json");
        Player player = new Player(new Vector2(0, 0));

        int[,] mapTemplate = Map.Instance.GetMap();

        Ceil[,] mapCell = new Ceil[GameData.MAP_WIDTH, GameData.MAP_WIDTH];

        for (int i = 0; i < GameData.MAP_WIDTH; i++)
        {
            for (int j = 0; j < GameData.MAP_WIDTH; j++)
            {
                if (mapTemplate[j, i] == (int)CeilType.PLAYER)
                {
                    player.SetPosition(new Vector2(i + 1, j + 1));
                    player.AddPath(player.position);
                }
                mapCell[j, i] = new Ceil(
                    (CeilType)mapTemplate[j, i],
                     (i + 1) * GameData.CELLSIZE,
                      (j + 1) * GameData.CELLSIZE,
                       GameData.CELLSIZE
                       );
            }
        }


        // Boucle principale du jeu
        while (!Raylib.WindowShouldClose())  // S'arrête quand la fenêtre est fermée
        {
            // Obtenir le Delta Time (temps écoulé depuis la dernière frame)
            float deltaTime = Raylib.GetFrameTime();

            // Début du dessin
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Beige);

            UIService.Instance.UpdateUI();

            for (int i = 0; i < GameData.MAP_WIDTH; i++)
            {
                for (int j = 0; j < GameData.MAP_WIDTH; j++)
                {
                    if (player.CheckIfIsInPath(mapCell[i, j].GetCeilPosition()))
                    {
                        mapCell[i, j].TransformIntoType(CeilType.PATH);
                    }
                    mapCell[i, j].Draw();
                    mapCell[i, j].Update();
                }
            }

            // Fin du dessin
            Raylib.EndDrawing();
        }

        // Fermer la fenêtre une fois que le jeu est terminé
        Raylib.CloseWindow();
    }
}