using ESparrow.Utils.Tools.Eases.Interfaces;

namespace ESparrow.Utils.Tools.Eases
{
    public readonly struct StartFinishEaseApplierParams<T> : IStartFinishEaseApplierParams<T>
    {
        public StartFinishEaseApplierParams(T start, T finish, IEase ease)
        {
            Start = start;
            Finish = finish;
            Ease = ease;
        }

        public T Start
        {
            get;
        }

        public T Finish
        {
            get;
        }

        public IEase Ease
        {
            get;
        }
    }
}