namespace ESparrow.Utils.Interactions.Interfaces
{
    public interface IInteractor
    {   
        void EnterTo(ITrigger trigger);
        void StayIn(ITrigger trigger);
        void ExitFrom(ITrigger trigger);
    }
}
