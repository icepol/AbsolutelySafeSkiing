namespace pixelook
{
    public static class Events
    {
        // level progression events
        public const string PRE_GAME_STARTED = "PreGameStarted";
        public const string GAME_STARTED = "GameStarted";
        public const string POST_GAME_STARTED = "PostGameStarted";
        
        public const string GAME_OVER = "GameOver";

        public const string DIRECTION_CHANGED = "DirectionChanged";
        public const string FLAG_COLLISION = "FlagCollision";
        public const string FLAG_PASSED = "FlagPassed";
        
        public const string SCORE_CHANGED = "ScoreChanged";

        // settings events
        public const string MUSIC_SETTINGS_CHANGED = "MusicSettingsChanged";
    }
}