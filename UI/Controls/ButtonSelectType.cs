using UI.Interfaces;
using Raylib_cs;
using System.Numerics;
using CommonLibrary;
using Game.Cursor;

namespace UI.Controls
{
    public class ButtonSelectType : IButton
    {

        public ButtonSelectType(string text, CeilType ceilType, Vector2 _position)
        {
            Text = text;
            position = _position;
            this.ceilType = ceilType;
            onClickAction = () =>
            {
                Cursor.Instance.setType(ceilType);
            };

        }

        private readonly Action onClickAction;
        public string Text { get; set; }
        private Vector2 position { get; set; }

        private CeilType ceilType { get; set; }


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
            if (Cursor.Instance.getType() == ceilType)
            {
                Raylib.DrawRectangle(
                    Raylib.GetScreenWidth() - Text.Length * 15 - 30,
                    (int)position.Y,
                    Text.Length * 16,
                    50,
                    Color.DarkBrown
                );
            }
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