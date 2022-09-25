namespace Birdhouse.Tools.Equality.Interfaces
{
    public interface IEqualityComparer<in TSelf>
    {
        /// <summary>
        /// Checks self and another values for equality.
        /// </summary>
        /// <param name="self">Self value</param>
        /// <param name="other">Another value</param>
        /// <returns>True if self value equals another one and false otherwise</returns>
        bool Equals(TSelf self, object other);
    }
}
