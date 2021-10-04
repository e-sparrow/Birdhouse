using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Patterns.FluentBuilder.Interfaces
{
    public interface IBuilder<T>
    {
        public T Build();
    }
}
