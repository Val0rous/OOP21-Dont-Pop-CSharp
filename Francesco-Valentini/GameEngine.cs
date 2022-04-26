using System;

using namespace DontPop
{
    public class GameEngine
    {
        //<must write>
        //[optional]
        //(alternative1 | alternative2)

        private Double _gameTime;
        private readonly PlayerObj _player;
        private readonly SpawnManager _spawnManager;
        private readonly AudioManager _audioManager;
        private readonly ScoreCalc _scoreCalc;
        private readonly GameScene _gameScene;
        private readonly GameApplication _application;
        private readonly ScoreDisplayObj _scoreDisplay;			//score overlay
        private readonly List<AbstractGameObject> _enemies;
        private readonly List<AbstractGameObject> _powerups;	//to change in PowerUpObject
        private readonly List<AbstractGameObject> _destroyQueue;

        private static readonly Int32 s_TIME_CONST_60_HZ_MS = 1000 / 60;
        private static readonly Double s_START_X = 0.5;
        private static readonly Double s_START_Y = 0.5;
        private static readonly Double s_SCORE_POS_X = 0.5;
        private static readonly Double s_SCORE_POS_Y = 0.5;

        private Boolean _hasShield;
        private Boolean _hasMultiplier;
        private Boolean _executeLoop;

        private Double _deltaTime;
    }
}