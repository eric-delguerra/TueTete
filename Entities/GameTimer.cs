using Raylib_cs;
using CommonLibrary;

namespace Game.Timer
{
    public class GameTimer
    {
        private float _global_time;
        private float _time;
        private bool _update_time = false;
        private bool _is_paused = false;

        public GameTimer()
        {
            _time = 0f;
        }

        public void Update(float dt)
        {

            if (_is_paused)
            {
                return;
            }
            _time += dt;
            _global_time += dt;
        }

        public void Draw()
        {
            string timeText = $"Time: {_time:F0}";
            string globalTimeText = $"Global Time: {_global_time:F0}";
            int margin = 10; // Margin from the edge of the screen

            // Using Raylib to draw text on the screen
            Raylib.DrawText(timeText, GameData.SCREEN_WIDTH - margin - Raylib.MeasureText(timeText, 20), margin, 20, Color.Black);
            Raylib.DrawText(globalTimeText, GameData.SCREEN_WIDTH - margin - Raylib.MeasureText(globalTimeText, 20), margin + 20, 20, Color.Black);
        }

        public float GetTime()
        {
            return _time;
        }

        public float GetGlobalTime()
        {
            return _global_time;
        }

        public void Reset()
        {
            _time = 0f;
        }

        public void Pause()
        {
            _is_paused = true;
        }

        public void Resume()
        {
            _is_paused = false;
        }


        public bool GetState()
        {
            return _update_time;
        }

        public void UpdateState(float dt)
        {
            Update(dt);
            if (_time >= GameData.GAME_LOOP_TIME)
            {
                _update_time = !_update_time;
                Reset();
            }
        }

        public void SetState(bool state)
        {
            _update_time = state;
        }
    }
}