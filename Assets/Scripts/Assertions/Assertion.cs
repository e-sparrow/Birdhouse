using System;
using UnityEngine;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Extensions;
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Assertions
{
    public class Assertion
    {
        private string _message;
        private Object _context;

        private EAssertionType _type = EAssertionType.Exception;

        private readonly Func<bool> _assertion;
        private readonly Action _onAssert;

        public Assertion(string message, Object context, Func<bool> assertion, Action onAssert = default)
        {
            _message = message;
            _context = context;

            _assertion = assertion;
            _onAssert = CheckHelper.CheckForDefault(onAssert);
        }

        public Assertion AsMessage()
        {
            _type = EAssertionType.Message;
            return this;
        }

        public Assertion AsWarning()
        {
            _type = EAssertionType.Warning;
            return this;
        }

        public Assertion AsError()
        {
            _type = EAssertionType.Error;
            return this;
        }

        public Assertion AsException()
        {
            _type = EAssertionType.Exception;
            return this;
        }

        public Assertion WithContext(Object context)
        {
            _context = context;
            return this;
        }

        public Assertion WithColor(Color color)
        {
            _message = _message.WithColor(color);
            return this;
        }

        public Assertion WithBoldMessage()
        {
            _message = _message.Bold();
            return this;
        }

        public void Assert()
        {
            if (!_assertion.Invoke())
            {
                switch (_type)
                {
                    case EAssertionType.Message:
                        Debug.Log(_message, _context);
                        break;
                    case EAssertionType.Warning:
                        Debug.LogWarning(_message, _context);
                        break;
                    case EAssertionType.Error:
                        Debug.LogError(_message, _context);
                        break;
                    case EAssertionType.Exception:
                        throw new AssertionException(_message, _context);
                }

                _onAssert?.Invoke();
            }
        }

        private class AssertionException : Exception
        {
            private readonly string _message;
            private readonly Object _context;

            public override string Message => GetMessage();

            public AssertionException(string message, Object context)
            {
                _message = message;
                _context = context;
            }

            private string GetMessage()
            {
                string message = $"Assertion provider asserts: \n\"{_message}\".";
                
                if (_context != default)
                {
                    message += $"\n\nContext: {_context.name}";
                }

                return message;
            }
        }

        private enum EAssertionType
        {
            Message,
            Warning,
            Error,
            Exception
        }
    }
}
