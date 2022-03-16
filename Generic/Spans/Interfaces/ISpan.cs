namespace ESparrow.Utils.Generic.Spans.Interfaces
{
    public interface ISpan<out T>
    {
        T Min
        { 
            get;
        }

        T Max
        {
            get;
        }
    }
}