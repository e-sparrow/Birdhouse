using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ESparrow.Utils.Assertions.Interfaces
{
    public interface IFluentAssertion : IAssertion
    {
        /// <summary>
        /// Assertion will be asserted as message.
        /// </summary>
        /// <returns>Message assertion</returns>
        IFluentAssertion AsMessage();
        /// <summary>
        /// Assertion will be asserted as warning.
        /// </summary>
        /// <returns>Warning assertion</returns>
        IFluentAssertion AsWarning();
        /// <summary>
        /// Assertion will be asserted as error.
        /// </summary>
        /// <returns>Error assertion</returns>
        IFluentAssertion AsError();
        /// <summary>
        /// Assertion will be asserted as exception.
        /// </summary>
        /// <returns>Exception assertion</returns>
        IFluentAssertion AsException();

        /// <summary>
        /// Adds a callback to assertion.
        /// </summary>
        /// <param name="callback">What to do after assertion</param>
        /// <returns>Same assertion with callback</returns>
        IFluentAssertion WithCallback(Action callback);
        /// <summary>
        /// Sets the context to assertion.
        /// </summary>
        /// <param name="context">Context of assertion</param>
        /// <returns>Assertion with concrete context</returns>
        IFluentAssertion WithContext(Object context);
        /// <summary>
        /// Sets the context to assertion.
        /// </summary>
        /// <param name="context">Context of assertion</param>
        /// <typeparam name="T">Type of context</typeparam>
        /// <returns>Assertion with concrete context</returns>
        IFluentAssertion WithContext<T>(T context) where T : Object;
        /// <summary>
        /// Sets the specified color to assertion text.
        /// </summary>
        /// <param name="color">Color to set</param>
        /// <returns>Assertion with colored text</returns>
        IFluentAssertion WithColor(Color color);
        /// <summary>
        /// Sets the assertion text to bold.
        /// </summary>
        /// <returns>Assertion with bold message</returns>
        IFluentAssertion WithBoldMessage();
    }
}
