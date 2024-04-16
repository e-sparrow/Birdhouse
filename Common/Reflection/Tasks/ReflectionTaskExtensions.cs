using System;
using System.Linq;
using System.Threading.Tasks;

namespace Birdhouse.Common.Reflection.Tasks
{
    public static class ReflectionTaskExtensions
    {
        // TODO: TEST
        public static async Task<T> StartTask<T>(this Type self, object target, string taskName, params object[] parameters)
        {
            var method = self.GetMethod(taskName);
            var parameterTypes = method
                .GetParameters()
                .Select(value => value.ParameterType)
                .ToArray();
            
            var generic = method.MakeGenericMethod(parameterTypes);
            var task = (Task<T>) generic.Invoke(target, parameters);

            await task.ConfigureAwait(false);

            return task.Result;
        }
    }
}