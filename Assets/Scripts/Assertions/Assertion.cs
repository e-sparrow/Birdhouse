using System;
using UnityEngine;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Throwening;
using ESparrow.Utils.Throwening.Enums;
using ESparrow.Utils.Extensions;
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Assertions
{
    public class Assertion
    {
        private string _message;
        private Object _context;

        private EThrowingType _type = EThrowingType.Exception;

        private readonly Func<bool> _assertion;
        private Action _onAssert;

        public Assertion(string message, Object context, Func<bool> assertion, Action onAssert = default)
        {
            _message = message;
            _context = context;

            _assertion = assertion;
            _onAssert = CheckHelper.CheckForDefault(onAssert);
        }

        public Assertion AsMessage()
        {
            _type = EThrowingType.Message;
            return this;
        }

        public Assertion AsWarning()
        {
            _type = EThrowingType.Warning;
            return this;
        }

        public Assertion AsError()
        {
            _type = EThrowingType.Error;
            return this;
        }

        public Assertion AsException()
        {
            _type = EThrowingType.Exception;
            return this;
        }

        public Assertion WithCallback(Action callback)
        {
            _onAssert += callback;
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
                var exception = new ImprovedException(_message, _context);
                exception.Throw(_type);

                _onAssert.Invoke();
            }
        }
    }
}
