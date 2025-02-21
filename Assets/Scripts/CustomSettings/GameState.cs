namespace pixelook
{
    public static class GameState
    {
        private static float _distance;
        private static int _flagsPassed;

        public static bool IsGameRunning { get; set; }
        
        public static bool IsLevelReady { get; set; }
        
        public static bool IsGameOver { get; set; }
        
        public static float Distance
        {
            get => _distance;
            set
            {
                _distance = value;
                
                EventManager.TriggerEvent(Events.SCORE_CHANGED);
            }
        }

        public static int FlagsPassed
        {
            get => _flagsPassed;
            set
            {
                _flagsPassed = value;
                
                EventManager.TriggerEvent(Events.SCORE_CHANGED);
            }
        }

        public static int Score => (int) Distance + FlagsPassed * 100;
        
        public static void OnApplicationStarted()
        {
            Distance = 0;
            FlagsPassed = 0;
            IsGameRunning = false;
            IsLevelReady = false;
            IsGameOver = false;
        }

        public static void OnGameStarted()
        {
            Distance = 0;
            FlagsPassed = 0;
            IsGameRunning = true;
            IsLevelReady = false;
            IsGameOver = false;
        }
    }
}