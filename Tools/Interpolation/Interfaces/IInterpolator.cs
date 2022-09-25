namespace Birdhouse.Tools.Interpolation.Interfaces
{
    public interface IInterpolator<T>
    { 
        /// <summary>
        /// Interpolates between two values by progress variable.
        /// </summary>
        /// <param name="from">Start value</param>
        /// <param name="to">End value</param>
        /// <param name="progress">Progress of interpolation</param>
        T Interpolate(T from, T to, float progress);
    }
}
