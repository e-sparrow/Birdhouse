using System;
using Birdhouse.Tools.Ticks;
using Birdhouse.Tools.Updatables.Abstractions;

namespace Birdhouse.Tools.Updatables
{
    public static class UpdatableValueExtensions
    {
        public static UpdatableValueWriterIncrementor<T> WrapIncremental<T>(this IUpdatableValueWriter<T> self)
        {
            var result = new UpdatableValueWriterIncrementor<T>(self);
            return result;
        }

        public static UpdatableValueWriterIncrementorBuilder<T> IncrementWithPeriod<T>
        (
            this UpdatableValueWriterIncrementor<T> self, 
            float period
        )
        {
            var targetTime = period;
            
            var result = self.IncrementWhen(HandleCondition);
            return result;

            bool HandleCondition(float time)
            {
                var isSuccess = time >= targetTime;
                if (isSuccess)
                {
                    targetTime += period;
                }

                return isSuccess;
            }
        }

        public static IDisposable StartFor<T>(this UpdatableValueWriterIncrementorBuilder<T> self, Func<int, T> factory, int times)
        {
            var counter = 0;

            Func<int, T> realFactory = HandleCreate;
            
            var token = self.Start(realFactory);
            return token;

            T HandleCreate(int index)
            {
                var result = factory.Invoke(index);
                return result;
            }
        }
    }

    public sealed class UpdatableValueWriterIncrementor<T>
    {
        public UpdatableValueWriterIncrementor(IUpdatableValueWriter<T> writer)
        {
            _writer = writer;
        }

        private readonly IUpdatableValueWriter<T> _writer;

        public UpdatableValueWriterIncrementorBuilder<T> IncrementWhen(Func<float, bool> func)
        {
            var result = new UpdatableValueWriterIncrementorBuilder<T>(_writer, func);
            return result;
        }
    }

    public sealed class UpdatableValueWriterIncrementorBuilder<T>
    {
        public UpdatableValueWriterIncrementorBuilder(IUpdatableValueWriter<T> writer, Func<float, bool> func)
        {
            _writer = writer;
            _func = func;
        }

        private readonly IUpdatableValueWriter<T> _writer;
        private readonly Func<float, bool> _func;

        private float _time;
        private int _counter;
        
        public IDisposable Start(Func<int, T> factory)
        {
            var result = TickHelper
                .GetDefaultTickProvider()
                .RegisterTick(deltaTime => Tick(deltaTime, factory));
            
            return result;
        }

        private void Tick(float deltaTime, Func<int, T> factory)
        {
            _time += deltaTime;

            var isSuccess = _func.Invoke(_time);
            if (!isSuccess)
            {
                return;
            }
            
            var result = factory.Invoke(_counter);
            _writer.Update(result);

            _counter++;
        }
    }
}