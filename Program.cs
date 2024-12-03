using CommonLibrary;
using Raylib_cs;
using UI.Services;
using Game.Timer;
class Program
{
    static void Main()
    {

        Raylib.InitWindow(GameData.SCREEN_WIDTH, GameData.SCREEN_HEIGHT, "Casse tête");
        Raylib.SetTargetFPS(120);
        Map.Instance.LoadMapFromJson("map.json");

        int[,] mapTemplate = Map.Instance.GetMap();

        Ceil[,] mapCell = new Ceil[GameData.MAP_WIDTH, GameData.MAP_WIDTH];

        for (int i = 0; i < GameData.MAP_WIDTH; i++)
        {
            for (int j = 0; j < GameData.MAP_WIDTH; j++)
            {
                if ((CeilType)mapTemplate[j, i] == CeilType.NEUTRAL)
                    mapCell[j, i] = new Neutral(
                    CeilType.NEUTRAL,
                     (i + 1) * GameData.CELLSIZE,
                      (j + 1) * GameData.CELLSIZE,
                       GameData.CELLSIZE
                       );
                else if ((CeilType)mapTemplate[j, i] == CeilType.INFECTED)
                    mapCell[j, i] = new Infected(
                        CeilType.INFECTED,
                         (i + 1) * GameData.CELLSIZE,
                          (j + 1) * GameData.CELLSIZE,
                           GameData.CELLSIZE
                           );

                else if ((CeilType)mapTemplate[j, i] == CeilType.WALL)
                    mapCell[j, i] = new Ceil(
                    CeilType.WALL,
                     (i + 1) * GameData.CELLSIZE,
                      (j + 1) * GameData.CELLSIZE,
                       GameData.CELLSIZE
                       );
                else if ((CeilType)mapTemplate[j, i] == CeilType.DEFENDER)
                    mapCell[j, i] = new Defender(
                    CeilType.DEFENDER,
                     (i + 1) * GameData.CELLSIZE,
                      (j + 1) * GameData.CELLSIZE,
                       GameData.CELLSIZE
                       );

            }
        }

        GameTimer timer = new GameTimer();

        ServiceLocator.Register(timer);
        ServiceLocator.Register(mapCell);


        // Boucle principale du jeu
        while (!Raylib.WindowShouldClose())  // S'arrête quand la fenêtre est fermée
        {
            // Obtenir le Delta Time (temps écoulé depuis la dernière frame)
            float deltaTime = Raylib.GetFrameTime();
       

            // Début du dessin
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Beige);

            UIService.Instance.UpdateUI();

            ServiceLocator.Resolve<GameTimer>().UpdateState(deltaTime);
            ServiceLocator.Resolve<GameTimer>().Draw();

            for (int i = 0; i < GameData.MAP_WIDTH; i++)
            {
                for (int j = 0; j < GameData.MAP_WIDTH; j++)
                {
                    ServiceLocator.Resolve<Ceil[,]>()[i, j].Draw();
                    ServiceLocator.Resolve<Ceil[,]>()[i, j].Update();
                }
            }

            // Fin du dessin
            Raylib.EndDrawing();
        }

        // Fermer la fenêtre une fois que le jeu est terminé
        Raylib.CloseWindow();
    }
}