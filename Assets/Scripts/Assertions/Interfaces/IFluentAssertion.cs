using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Assertions.Interfaces
{
    public interface IFluentAssertion : IAssertion
    {
        IAssertion AsMessage();
        IAssertion AsWarning();
        IAssertion AsError();
        IAssertion AsException();

        IAssertion WithCallback(Action callback);
        IAssertion WithContext(Object context);
        IAssertion WithColor(Color color);
        IAssertion WithBoldMessage();
    }
}
