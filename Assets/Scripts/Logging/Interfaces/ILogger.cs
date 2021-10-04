using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Throwening.Interfaces;

namespace ESparrow.Utils.Logging.Interfaces
{
    public interface ILogger
    {
        public void Log(string message);
        public void ThrowWarning(string message);
        public void ThrowError(string message);

        public void Throw(IThrowable throwable);
    }
}
