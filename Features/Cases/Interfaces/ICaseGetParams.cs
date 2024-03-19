namespace Birdhouse.Features.Cases.Interfaces
{
    public interface ICaseGetParams
    {
        public bool NeedToMemoize
        {
            get;
        }

        public bool LoadAllTheDictionary
        {
            get;
        }
    }
}