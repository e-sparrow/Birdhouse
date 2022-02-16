namespace ESparrow.Utils.Exceptions.Interfaces
{
    public interface IWtfException
    {
        public string Reason
        {
            get;
        }

        public object Target
        {
            get;
        }
    }
}
