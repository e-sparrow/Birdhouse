using System;
using UnityEngine;

namespace Birdhouse.Tools.Exceptions.Abstractions
{
    // TODO:
    public abstract class SeparateFileExceptionBase
        : Exception
    {
        protected SeparateFileExceptionBase()
        {
            Append(GetPath(), GetData());
        }

        protected abstract string GetPath();
        protected abstract string GetData();
        
        private static void Append(string path, string data)
        {
            
        }
    }
}