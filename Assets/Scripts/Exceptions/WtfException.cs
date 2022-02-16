namespace ESparrow.Utils.Exceptions
{
    public class WtfException : WtfExceptionBase
    {
        public WtfException(string reason = "No information", object target = null) : base(reason, target)
        {
            
        }
    }
}
