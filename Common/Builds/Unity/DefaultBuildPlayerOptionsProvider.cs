using System.Reflection;
using Birdhouse.Abstractions.Providers.Interfaces;
using UnityEditor;

namespace Birdhouse.Common.Builds.Unity
{
    public class DefaultBuildPlayerOptionsProvider
        : IProvider<bool, BuildPlayerOptions, BuildPlayerOptions>
    {
        public BuildPlayerOptions GetValue(bool askForLocation, BuildPlayerOptions defaultOptions)
        {
            const string MethodName = "GetBuildPlayerOptionsInternal";
            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;
            
            var method = typeof(BuildPlayerWindow).GetMethod(MethodName, Flags);
            if (method == null)
            {
                method = typeof(BuildPlayerWindow.DefaultBuildMethods).GetMethod(MethodName, Flags);
            }
            
            var parameters = new object[] { askForLocation, defaultOptions };
            
            var result = (BuildPlayerOptions) method.Invoke(null, parameters);
            return result;
        }
    }
}