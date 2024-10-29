using UI.Interfaces;
using Raylib_cs;
using System.Numerics;

namespace UI.Controls
{
    public class Button : IButton
    {

        public Button(string text, Action onClickAction, Vector2 _position)
        {
            Text = text;
            position = _position;
            this.onClickAction = onClickAction;
        }

        private readonly Action onClickAction;
        public string Text { get; set; }
        public Vector2 position { get; set; }

        public void OnClick()
        {
            onClickAction?.Invoke();
        }

        public void Draw()
        {
            Raylib.DrawRectangleLines(
                Raylib.GetScreenWidth() - Text.Length * 15 - 30,
                (int)position.Y,
                Text.Length * 16,
                50,
                Color.Black
            );
            Raylib.DrawText(
                Text,
                Raylib.GetScreenWidth() - Text.Length * 15 - 20,
                (int)position.Y + 15, 
                20, 
                Color.Black
            );
        }

        public void Update()
        {
            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                if (
                    Raylib.GetMouseX() >= Raylib.GetScreenWidth() - Text.Length * 16 - 30 &&
                    Raylib.GetMouseX() <= Raylib.GetScreenWidth() - Text.Length * 16 - 30 + Text.Length * 16 &&
                    Raylib.GetMouseY() >= (int)position.Y &&
                    Raylib.GetMouseY() <= (int)position.Y + 50
                   )
                {
                    OnClick();
                }
            }
        }
    }
}