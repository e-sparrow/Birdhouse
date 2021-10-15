namespace ESparrow.Utils.Tools.Eases.Interfaces
{
    public interface IEase
    {
        /// <summary>
        /// Gets point on the ease.
        /// </summary>
        /// <param name="progress">Pass progress from 0 to 1</param>
        /// <returns>Value on this progress</returns>
        float Evaluate(float progress);
    }
}
