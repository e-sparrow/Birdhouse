using System;
using UnityEngine;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Throwening;
using ESparrow.Utils.Throwening.Enums;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Assertions.Interfaces; 
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Assertions
{
    public class Assertion : IFluentAssertion
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

        public IAssertion AsMessage()
        {
            _type = EThrowingType.Message;
            return this;
        }

        public IAssertion AsWarning()
        {
            _type = EThrowingType.Warning;
            return this;
        }

        public IAssertion AsError()
        {
            _type = EThrowingType.Error;
            return this;
        }

        public IAssertion AsException()
        {
            _type = EThrowingType.Exception;
            return this;
        }

        public IAssertion WithCallback(Action callback)
        {
            _onAssert += callback;
            return this;
        }

        public IAssertion WithContext(Object context)
        {
            _context = context;
            return this;
        }

        public IAssertion WithColor(Color color)
        {
            _message = _message.WithColor(color);
            return this;
        }

        public IAssertion WithBoldMessage()
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
