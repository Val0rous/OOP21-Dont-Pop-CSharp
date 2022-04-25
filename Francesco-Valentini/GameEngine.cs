using System;

using namespace DontPop
{
    class GameEngine
    {
        //<must write>
        //[optional]
        //(alternative1 | alternative2)

        private Double gameTime;
        private readonly PlayerObj player;
        private readonly SpawnManager spawnManager;
        private readonly AudioManager audioManager;
        private readonly ScoreCalc scoreCalc;
        private readonly GameScene gameScene;
        private readonly GameApplication application;
        private readonly ScoreDisplayObj scoreDisplay;			//score overlay
        private readonly List<AbstractGameObject> enemies;
        private readonly List<AbstractGameObject> powerups;	//to change in PowerUpObject
        private readonly List<AbstractGameObject> destroyQueue;

        private static readonly Int32 TIME_CONST_60_HZ_MS = 1000 / 60;
        private static readonly Double START_X = 0.5;
        private static readonly Double START_Y = 0.5;
        private static readonly Double SCORE_POS_X = 0.5;
        private static readonly Double SCORE_POS_Y = 0.5;

        private Boolean hasShield;
        private Boolean hasMultiplier;
        private Boolean executeLoop;

        private Double deltaTime;
    }
}