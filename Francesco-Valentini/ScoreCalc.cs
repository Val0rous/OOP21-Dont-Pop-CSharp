using System;

namespace Francesco_Valentini
{
    /// <summary>
    /// Manages final score, that will be displayed both during gameplay and after gameover.
    /// Differs from ScoreManager, which manages GUI-related aspects of score displaying.
    /// </summary>
    public class ScoreCalc
    {
        public int Score { get; private set; }
        public bool CalcStatus { get; set; }
        public int Multiplier { get; private set; }
        private double _multiplierTime;
        private double _frameCounter;
        private static readonly double s_MULTIPLIER_TIME = 5;   //five seconds of multiplier
        private static readonly int s_POINTS_PER_SECOND = 15;
        private static readonly double s_SECONDS_PER_POINT = 1 / (double) s_POINTS_PER_SECOND;
        private static readonly int s_MULTIPLIER_2X = 2;

        private bool _hasMultiplier;

        /// <summary>
        /// Creates class and sets multiplier to 1 by default.
        /// </summary>
        public ScoreCalc()
        {
            this.Multiplier = 1;
            this.CalcStatus = false;
        }

        /// <summary>
        /// Increments score by an arbitrary amount, while still abiding by multiplier rules.
        /// </summary>
        /// <param name="deltaScore"></param>
        public void IncScore(int deltaScore) => this.Score += deltaScore * this.Multiplier;

        /// <summary>
        /// Manages multiplier time, decreasing it until it reaches 0.
        /// </summary>
        /// <param name="deltaTime"></param>
        private void ManageMultiplierTime(double deltaTime)
        {
            if (!this._hasMultiplier)
            {
                return;
            }
            if (this._multiplierTime > 0)
            {
                this.DecMultiplierTime(deltaTime);
            }
            else
            {
                this.ResetMultiplier();
            }
        }

        /// <summary>
        /// Increments score by 1 every 4 frames, giving >= 15 points per second.
        /// </summary>
        /// <param name="deltaTime"></param>
        public void CalculateScore(double deltaTime)
        {
            if (this.CalcStatus)
            {
                this._frameCounter += deltaTime;
                if (this._frameCounter >= s_SECONDS_PER_POINT)
                {
                    this.IncScore(1);
                    this.ResetFrameCounter();
                }
                this.ManageMultiplierTime(deltaTime);
            }
        }

        /// <summary>
        /// Sets multiplier to any value.
        /// </summary>
        /// <param name="multiplier"></param>
        public void SetMultiplier(int multiplier)
        {
            this.Multiplier = multiplier;
            this._multiplierTime = s_MULTIPLIER_TIME;
            this._hasMultiplier = true;
        }

        /// <summary>
        /// Sets multiplier to default value (2x).
        /// Useful when you don't want to specify the value of the multiplier.
        /// </summary>
        public void SetMultiplier() => this.SetMultiplier(s_MULTIPLIER_2X);

        /// <summary>
        /// Resets multiplier back to 1.
        /// </summary>
        public void ResetMultiplier()
        {
            this.Multiplier = 1;
            this._multiplierTime = 0;
            this._hasMultiplier = false;
        }

        /// <summary>
        /// Decreases multiplier time by an arbitrary amount.
        /// </summary>
        /// <param name="decrement"></param>
        private void DecMultiplierTime(double decrement) => this._multiplierTime -= decrement;

        /// <summary>
        /// Resets frame counter.
        /// </summary>
        private void ResetFrameCounter() => this._frameCounter -= s_SECONDS_PER_POINT;
    }
}