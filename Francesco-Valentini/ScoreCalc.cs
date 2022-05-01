using System;

namespace Francesco_Valentini
{
    public class ScoreCalc
    {
        private Int32 _score;
        private Boolean _calcStatus;
        private Int32 _multiplier;
        private Double _multiplierTime;
        private Double _frameCounter;
        private static readonly Double s_MULTIPLIER_TIME = 5;
        private static readonly Int32 s_POINTS_PER_SECOND = 15;
        private static readonly Double s_SECONDS_PER_POINT = 1 / (Double) s_POINTS_PER_SECOND;
        private static readonly Int32 s_MULTIPLIER_2X = 2;

        private Boolean _hasMultiplier;

        public ScoreCalc()
        {
            this._multiplier = 1;
            this.SetCalcStatus(false);
        }

        public Int32 GetScore()
        {
            return this._score;
        }

        public Boolean IsCalculable()
        {
            return this._calcStatus;
        }

        public void SetCalcStatus(Boolean status)
        {
            this._calcStatus = status;
        }

        public void IncScore(Int32 deltaScore)
        {
            this._score += deltaScore * this.GetMultiplier();
        }

        private void ManageMultiplierTime(Double deltaTime)
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

        public void CalculateScore(Double deltaTime)
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

        public Int32 GetMultiplier()
        {
            return this._multiplier;
        }

        public void SetMultiplier(Int32 multiplier)
        {
            this._multiplier = multiplier;
            this._multiplierTime = s_MULTIPLIER_TIME;
            this._hasMultiplier = true;
        }

        public void SetMultiplier()
        {
            this.SetMultiplier(s_MULTIPLIER_2X);
        }

        public void ResetMultiplier()
        {
            this._multiplier = 1;
            this._hasMultiplier = false;
        }

        public Double GetMultiplierTime()
        {
            return this._multiplierTime;
        }

        public void DecMultiplierTime(Double decrement)
        {
            this._multiplierTime -= decrement;
        }

        private Double GetFrameCounter()
        {
            return this._frameCounter;
        }

        private void ResetFrameCounter()
        {
            this._frameCounter -= s_SECONDS_PER_POINT;
        }
    }
}