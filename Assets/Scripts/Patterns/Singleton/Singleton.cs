namespace ESparrow.Utils.Patterns.Singleton
{
    public class Singleton<T> where T : Singleton<T>
    {
        private static Singleton<T> _instance;

        public static Singleton<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton<T>();
                }

                return _instance;
            }
        }

        protected Singleton()
        {
            _instance = this;
        }
    }
}
