using UnityEngine;

namespace StepwiseGameSettings
{
    public class StepwiseRenderingQuality : IStepwise
    {
        public int GetStepCount()
        {
            return QualitySettings.count;
        }

        public void SetStep(int step)
        {
            step = Mathf.Clamp(step, 0, QualitySettings.count - 1);
            QualitySettings.SetQualityLevel(step);
        }

        public int GetStep()
        {
            return QualitySettings.GetQualityLevel();
        }

        public string GetName(int step)
        {
            step = Mathf.Clamp(step, 0, QualitySettings.count - 1);
            return QualitySettings.names[step];
        }
    }
}
