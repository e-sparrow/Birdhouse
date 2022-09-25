namespace Birdhouse.Common.Exceptions.Interfaces
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
