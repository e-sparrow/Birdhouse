using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ESparrow.Utils.Experimental
{
    public class EventList<T>
    {
        public event Func<T> Event
        {
            add => _list.Add(value);
            remove => _list.Remove(value);
        }

        private readonly List<Func<T>> _list;

        private List<T> Values => _list.Select(value => value.Invoke()).ToList();

        private void Start()
        {
            Event += Example;
        }
        
        private T Example()
        {
            return default;
        }
    }
}