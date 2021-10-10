using System;
using ESparrow.Utils.Logging;
using ESparrow.Utils.Logging.Interfaces;
using ESparrow.Utils.Throwening.Enums;
using ESparrow.Utils.Throwening.Interfaces;
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Throwening
{
    public class ImprovedException : Exception, IThrowable
    {
        private readonly string _message;
        private readonly Object _context;

        private readonly IUnityLogger _logger = new UnityLogger();

        public override string Message => _message;

        public ImprovedException(string message, Object context)
        {
            _message = message;
            _context = context;
        }

        public ImprovedException(string message, Object context, IUnityLogger logger) : this(message, context)
        {
            _logger = logger;
        }

        public void Throw(EThrowingType type)
        {
            switch (type)
            {
                case EThrowingType.Message:
                    _logger.LogMessage(_message, _context);
                    break;
                case EThrowingType.Warning:
                    _logger.LogWarning(_message, _context);
                    break;
                case EThrowingType.Error:
                    _logger.LogError(_message, _context);
                    break;
                case EThrowingType.Exception:
                    throw this;
            }
        }
    }
}
