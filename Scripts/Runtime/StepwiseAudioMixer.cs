using UnityEngine;
using UnityEngine.Audio;

namespace StepwiseGameSettings
{
    public class StepwiseAudioMixer : IStepwise
    {
        private readonly AudioMixer _audioMixer;
        private readonly string _parameterName;
        private readonly float _minValue;
        private readonly float _maxValue;
        private readonly int _stepCount;

        public StepwiseAudioMixer(AudioMixer audioMixer, string parameterName, float minValue, float maxValue, int stepCount = 11)
        {
            _audioMixer = audioMixer;
            _parameterName = parameterName;
            _minValue = minValue;
            _maxValue = maxValue;
            _stepCount = stepCount;
        }

        public int GetStepCount()
        {
            return _stepCount;
        }

        public void SetStep(int step)
        {
            step = Mathf.Clamp(step, 0, _stepCount - 1);
            var t = step / (float)(_stepCount - 1);
            var value = Mathf.Lerp(_minValue, _maxValue, t);
            _audioMixer.SetFloat(_parameterName, value);
        }

        public int GetStep()
        {
            var hasParam = _audioMixer.GetFloat(_parameterName, out var value);
            if (!hasParam)
            {
                return 0;
            }
            return Mathf.RoundToInt(Mathf.InverseLerp(_minValue, _maxValue, value) * (_stepCount - 1));
        }
    }
}
