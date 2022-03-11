using System;

namespace ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces
{
    public interface ITermController
    {
        event Action OnExpired;
    }
}