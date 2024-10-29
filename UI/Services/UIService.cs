using UI.Controls;
using UI.Interfaces;
using System.Numerics;
using CommonLibrary;


namespace UI.Services
{
    class UIService
    {
        private List<ButtonService> ButtonServices = new List<ButtonService>();
        private UIService() {
            IButton button = new ButtonSelectType("BOUCE_UP", CeilType.BOUCE_UP, new Vector2(0, 0));
            ButtonServices.Add(new ButtonService(button));

            button = new ButtonSelectType("BOUCE_DOWN", CeilType.BOUCE_DOWN , new Vector2(0, 60));

            ButtonServices.Add(new ButtonService(button));
            button = new ButtonSelectType("BOUCE_LEFT", CeilType.BOUCE_LEFT, new Vector2(0, 120));

            ButtonServices.Add(new ButtonService(button));
            button = new ButtonSelectType("BOUCE_RIGHT", CeilType.BOUCE_RIGHT, new Vector2(0, 180));

            ButtonServices.Add(new ButtonService(button));
            button = new ButtonSelectType("TELEPORT", CeilType.TELEPORT, new Vector2(0, 240));

            ButtonServices.Add(new ButtonService(button));
            button = new ButtonSelectType("TELEPORT_DEST", CeilType.TELEPORT_DEST, new Vector2(0, 300));

            ButtonServices.Add(new ButtonService(button));
         }

        public static UIService Instance { get; } = new UIService();

        public void Draw()
        {
            foreach (var buttonService in ButtonServices)
            {
                buttonService.Draw();
            }
        }

        public void Update()
        {
            foreach (var buttonService in ButtonServices)
            {
                buttonService.Update();
            }
        }

        public void UpdateUI()
        {
            Update();
            Draw();
        }
    }
}