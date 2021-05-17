using System;
using UnityEngine;
using UnityEngine.Events;

namespace ESparrow.Utils.Structs
{
    [Serializable]
    public class Link : MonoBehaviour
    {
        public string id;
        public UnityAction action;
    }
}
