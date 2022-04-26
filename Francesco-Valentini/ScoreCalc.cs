using System;

namespace DontPop
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
        private static readonly Double s_SECONDS_PER_POINT = 1 / (Double) _POINTS_PER_SECOND;
        private static readonly Int32 s_MULTIPLIER_2X = 2;

        private Boolean _hasMultiplier;

        private readonly List<Runnable> _onMultiplierEndList = new ArrayList<>();
        private readonly List<Runnable> _onMultiplierStartList = new ArrayList<>();

        public ScoreCalc()
        {
            _multiplier = 1;
            SetCalcStatus(false);
        }

        public Int32 GetScore()
        {
            return _score;
        }

        public Boolean IsCalculable()
        {
            return _calcStatus;
        }

        public void SetCalcStatus(Boolean status)
        {
            _calcStatus = status;
        }

        public void IncScore(Int32 deltaScore)
        {
            _score += deltaScore * GetMultiplier();
        }

        private void ManageMultiplierTime(Double deltaTime)
        {
            if (!_hasMultiplier)
            {
                return;
            }
            if (GetMultiplierTime() > 0)
            {
                DecMultiplierTime(deltaTime);
            }
            else
            {
                ResetMultiplier();
            }
        }

        public void CalculateScore(Double deltaTime)
        {
            if (IsCalculable())
            {
                _frameCounter += deltaTime;
                if (GetFrameCounter() >= s_SECONDS_PER_POINT)
                {
                    IncScore(1);
                    ResetFrameCounter();
                }
                ManageMultiplierTime(deltaTime);
            }
        }

        public Int32 GetMultiplier()
        {
            return _multiplier;
        }

        public void SetMultiplier(Int32 multiplier)
        {
            _multiplier = multiplier;
            _multiplierTime = s_MULTIPLIER_TIME;
            _hasMultiplier = true;
            foreach (var item in _onMultiplierStartList)
            {
                item.Run();
            }
        }

        public void SetMultiplier()
        {
            SetMultiplier(s_MULTIPLIER_2X);
        }

        public void ResetMultiplier()
        {
            _multiplier = 1;
            _hasMultiplier = false;
            foreach (var item in _onMultiplierEndList)
            {
                item.Run();
            }
        }

        public Double GetMultiplierTime()
        {
            return _multiplierTime;
        }

        public void DecMultiplierTime(Double decrement)
        {
            _multiplierTime -= decrement;
        }

        private Double GetFrameCounter()
        {
            return _frameCounter;
        }

        private void ResetFrameCounter()
        {
            _frameCounter -= s_SECONDS_PER_POINT;
        }

        public void OnMultiplierStart(Runnable action)
        {
            _onMultiplierStartList.Add(action);
        }

        public void OnMultiplierEnd(Runnable action)
        {
            _onMultiplierEndList.add(action);
        }
    }
}