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
        private static readonly Double _MULTIPLIER_TIME = 5;
        private static readonly Int32 _POINTS_PER_SECOND = 15;
        private static readonly Double _SECONDS_PER_POINT = 1 / (Double) _POINTS_PER_SECOND;
        private static readonly Int32 _MULTIPLIER_2X = 2;

        private Boolean _hasMultiplier;

        private readonly List<Runnable> _onMultiplierEndList = new ArrayList<>();
        private readonly List<Runnable> _onMultiplierStartList = new ArrayList<>();
    }
}