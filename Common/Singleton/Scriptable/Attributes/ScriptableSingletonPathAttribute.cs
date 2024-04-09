using System;

namespace Birdhouse.Common.Singleton.Scriptable.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ScriptableSingletonPathAttribute 
        : Attribute
    {
        public ScriptableSingletonPathAttribute(string path)
        {
            Path = path;
        }
        
        public string Path
        {
            get;
        }
    }
}