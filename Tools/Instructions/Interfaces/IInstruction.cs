namespace Birdhouse.Tools.Instructions.Interfaces
{
    public interface IInstruction
    {
        bool TryExecute();
        void Destroy();
    }
}
