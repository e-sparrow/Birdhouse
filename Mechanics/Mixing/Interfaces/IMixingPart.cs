namespace ESparrow.Utils.Tools.Interpolation.Mixing.Interfaces
{
    public interface IMixingPart<out T>
    {
        T Value
        {
            get;
        }

        float Proportion
        {
            get;
        }
    }
}
