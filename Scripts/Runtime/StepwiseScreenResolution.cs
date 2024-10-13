using System.Collections.Generic;
using UnityEngine;

namespace StepwiseGameSettings
{
    public class StepwiseScreenResolution : IStepwise
    {
        private List<Vector2Int> _resolutionBuffer = new List<Vector2Int>();

        public int GetStepCount()
        {
            CollectResolutions(_resolutionBuffer);
            return _resolutionBuffer.Count;
        }

        public void SetStep(int step)
        {
            CollectResolutions(_resolutionBuffer);
            step = Mathf.Clamp(step, 0, _resolutionBuffer.Count - 1);
            var resolution = _resolutionBuffer[step];
            Screen.SetResolution(resolution.x, resolution.y, Screen.fullScreen);
        }

        public int GetStep()
        {
            return GetClosestResolutionIndex(Screen.width, Screen.height);
        }

        private static void CollectResolutions(List<Vector2Int> results)
        {
            results.Clear();
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                var resolution = Screen.resolutions[i];
                var res = new Vector2Int(resolution.width, resolution.height);
                if (!results.Contains(res))
                {
                    results.Add(res);
                }
            }
        }

        public int GetClosestResolutionIndex(int width, int height)
        {
            CollectResolutions(_resolutionBuffer);
            var target = new Vector2Int(width, height);
            var minDistanceW = int.MaxValue;
            var minDistanceH = int.MaxValue;
            var minIndex = -1;
            for (int i = 0; i < _resolutionBuffer.Count; i++)
            {
                var res = _resolutionBuffer[i];
                var distanceW = Mathf.Abs(res.x - target.x);
                var distanceH = Mathf.Abs(res.y - target.y);
                if (distanceW < minDistanceW)
                {
                    minDistanceW = distanceW;
                    minDistanceH = distanceH;
                    minIndex = i;
                }
                else if (distanceW == minDistanceW && distanceH < minDistanceH)
                {
                    minDistanceH = distanceH;
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public Vector2Int GetResolution(int step)
        {
            CollectResolutions(_resolutionBuffer);
            step = Mathf.Clamp(step, 0, _resolutionBuffer.Count - 1);
            return _resolutionBuffer[step];
        }
    }
}
