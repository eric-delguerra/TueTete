namespace UI.Interfaces
{
   public interface IButton
    {
        string Text { get; set; }
        void OnClick();
        void Draw();
        void Update();
    }
}