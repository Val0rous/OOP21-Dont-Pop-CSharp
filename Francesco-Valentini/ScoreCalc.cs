using System;

namespace Francesco_Valentini
{
    /// <summary>
    /// Manages final score, that will be displayed both during gameplay and after gameover.
    /// Differs from ScoreManager, which manages GUI-related aspects of score displaying.
    /// </summary>
    public class ScoreCalc
    {
        private int _score;
        private bool _calcStatus;
        private int _multiplier;
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
            this._multiplier = 1;
            this.SetCalcStatus(false);
        }

        /// <summary>
        /// Gets current score.
        /// </summary>
        /// <returns>score</returns>
        public int GetScore() => this._score;

        /// <summary>
        /// Gets current calc status: if true, the score shall be calculated.
        /// </summary>
        /// <returns>calc status</returns>
        public bool IsCalculable() => this._calcStatus;

        /// <summary>
        /// Sets whether ScoreCalc shall calculate the score (true) or not (false).
        /// </summary>
        /// <param name="status"></param>
        public void SetCalcStatus(bool status) => this._calcStatus = status;

        /// <summary>
        /// Increments score by an arbitrary amount, while still abiding by multiplier rules.
        /// </summary>
        /// <param name="deltaScore"></param>
        public void IncScore(int deltaScore) => this._score += deltaScore * this.GetMultiplier();

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
            if (this.GetMultiplierTime() > 0)
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
            if (this.IsCalculable())
            {
                this._frameCounter += deltaTime;
                if (this.GetFrameCounter() >= s_SECONDS_PER_POINT)
                {
                    this.IncScore(1);
                    this.ResetFrameCounter();
                }
                this.ManageMultiplierTime(deltaTime);
            }
        }

        /// <summary>
        /// Gets current value of multiplier.
        /// </summary>
        /// <returns>multiplier</returns>
        public int GetMultiplier() => this._multiplier;

        /// <summary>
        /// Sets multiplier to any value.
        /// </summary>
        /// <param name="multiplier"></param>
        public void SetMultiplier(int multiplier)
        {
            this._multiplier = multiplier;
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
            this._multiplier = 1;
            this._multiplierTime = 0;
            this._hasMultiplier = false;
        }

        /// <summary>
        /// Gets remaining multiplier time.
        /// </summary>
        /// <returns>multiplier time</returns>
        private double GetMultiplierTime() => this._multiplierTime;

        /// <summary>
        /// Decreases multiplier time by an arbitrary amount.
        /// </summary>
        /// <param name="decrement"></param>
        private void DecMultiplierTime(double decrement) => this._multiplierTime -= decrement;

        /// <summary>
        /// Gets current frame counter.
        /// </summary>
        /// <returns>frame counter</returns>
        private double GetFrameCounter() => this._frameCounter;

        /// <summary>
        /// Resets frame counter.
        /// </summary>
        private void ResetFrameCounter() => this._frameCounter -= s_SECONDS_PER_POINT;
    }
}