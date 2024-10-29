using UI.Interfaces;

namespace UI.Services
{
    public class ButtonService
    {

        private IButton button { get; set; }

        public ButtonService(IButton b)
        {
            button = b;
        }

        public void HandleClick()
        {
            button.OnClick();
        }

        public void Draw()
        {
            button.Draw();
        }

        public void Update()
        {
            button.Update();
        }
    }
}