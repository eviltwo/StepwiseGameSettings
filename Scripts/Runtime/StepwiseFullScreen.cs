using UnityEngine;

namespace StepwiseGameSettings
{
    public class StepwiseFullScreen : IStepwise
    {
        public int GetStepCount()
        {
            return 2;
        }

        public void SetStep(int step)
        {
            step = Mathf.Clamp(step, 0, 1);
            Screen.fullScreen = step == 1;
        }

        public int GetStep()
        {
            return Screen.fullScreen ? 1 : 0;
        }
    }
}
