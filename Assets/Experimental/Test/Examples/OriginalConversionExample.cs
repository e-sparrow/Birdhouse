namespace ESparrow.Utils.Experimental.Examples
{
    public class OriginalConversionExample
    {
        public FinalConversionExample CreateFinal()
        {
            return new FinalConversionExample(this);
        }

        public static implicit operator FinalConversionExample(OriginalConversionExample example)
        {
            return new FinalConversionExample(example);
        }
    }
}