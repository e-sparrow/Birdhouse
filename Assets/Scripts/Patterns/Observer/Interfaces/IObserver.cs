using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Patterns.Observer.Interfaces
{
    public interface IObserver
    {
        public IMemberObserver CreateMemberObserver(string name);
        public void RemovePropertyObserver(IMemberObserver observer);
    }
}
