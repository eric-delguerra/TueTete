using CommonLibrary;

namespace Game.Cursor
{
    class Cursor
    {
        private CeilType type { get; set; } = CeilType.HOVERED;
        public static Cursor Instance { get; } = new Cursor();

        public void setType(CeilType type)
        {
            this.type = type;
        }

        public CeilType getType()
        {
            return type;
        }

    }
}
