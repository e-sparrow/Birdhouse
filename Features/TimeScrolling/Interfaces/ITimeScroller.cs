namespace Birdhouse.Mechanics.TimeScrolling.Interfaces
{
    public interface ITimeScroller
    {
        /// <summary>
        /// Records some action.
        /// </summary>
        void Record();
        /// <summary>
        /// Records push of some action.
        /// </summary>
        void RecordPush();
        /// <summary>
        /// Records release of some action.
        /// </summary>
        void RecordRelease();

        /// <summary>
        /// Is time passes in a positive direction.
        /// </summary>
        bool InOrder
        {
            get;
        }
    }
}
