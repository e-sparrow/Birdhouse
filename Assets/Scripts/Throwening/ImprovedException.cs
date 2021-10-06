using System;
using UnityEngine;
using ESparrow.Utils.Throwening.Enums;
using ESparrow.Utils.Throwening.Interfaces;
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Throwening
{
    public class ImprovedException : Exception, IThrowable
    {
        private readonly string _message;
        private readonly Object _context;

        public override string Message => _message;

        public ImprovedException(string message, Object context)
        {
            _message = message;
            _context = context;
        }

        public void Throw(EThrowingType type)
        {
            switch (type)
            {
                case EThrowingType.Message:
                    Debug.Log(_message, _context);
                    break;
                case EThrowingType.Warning:
                    Debug.LogWarning(_message, _context);
                    break;
                case EThrowingType.Error:
                    Debug.LogError(_message, _context);
                    break;
                case EThrowingType.Exception:
                    throw this;
            }
        }
    }
}
