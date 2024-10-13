namespace StepwiseGameSettings
{
    public interface IStepwise
    {
        /// <summary>
        /// Get the total number of steps.
        /// </summary>
        int GetStepCount();

        /// <summary>
        /// Set the current step. The step will be clamped to the range [0, StepCount - 1].
        /// </summary>
        void SetStep(int step);

        /// <summary>
        /// Get the current step. The step will be clamped to the range [0, StepCount - 1].
        /// </summary>
        int GetStep();
    }
}
