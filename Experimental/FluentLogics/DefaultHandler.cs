namespace Birdhouse.Experimental.FluentLogics
{
    public readonly struct DefaultHandler<T>
    {
        public DefaultHandler(SwitchRoot<T> root) => _root = root;

        private readonly SwitchRoot<T> _root;
    }
}