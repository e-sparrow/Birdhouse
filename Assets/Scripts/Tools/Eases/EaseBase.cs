using System;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Tools.Eases.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Eases
{
    public abstract class EaseBase : IFluentEase
    {
        protected EaseBase()
        {
            
        }
        
        protected EaseBase(Func<float, float> func)
        {
            Func = func;
        }
        
        protected Func<float, float> Func = Default;
        
        protected static float Default(float progress)
        {
            return Mathf.Lerp(0f, 1f, progress);
        }
        
        public abstract float Evaluate(float progress);

        public IFluentEase InverseX()
        {
            var oldFunc = new Func<float, float>(Func);
            
            Func = value => oldFunc.Invoke(1f - value);
            return this;
        }

        public IFluentEase InverseY()
        {
            var oldFunc = new Func<float, float>(Func);
            
            Func = value => 1f - oldFunc.Invoke(value);
            return this;
        }

        public IFluentEase IncreaseBy(float value)
        {
            return Modify(_ => value, Increase);

            float Increase(float left, float right)
            {
                return left + right;
            }
        }

        public IFluentEase DecreaseBy(float value)
        {
            return Modify(_ => value, Decrease);

            float Decrease(float left, float right)
            {
                return left - right;
            }
        }

        public IFluentEase MultipleBy(float value)
        {
            return Modify(_ => value, Multiple);

            float Multiple(float left, float right)
            {
                return left * right;
            }
        }

        public IFluentEase DivideBy(float value)
        { 
            return Modify(_ => value, Divide);

            float Divide(float left, float right)
            {
                return left / right;
            }
        }

        public IFluentEase Pow(float value)
        {
            return Modify(_ => value, Pow);
            
            float Pow(float left, float right)
            {
                return left.Power(right);
            }
        }

        public IFluentEase Modify(Func<float, float> func, Func<float, float, float> operation)
        {
            var oldFunc = new Func<float, float>(Func);
            
            Func = Combine;
            return this;
            
            float Combine(float value)
            {
                var oldValue = oldFunc.Invoke(value);
                var newValue = func.Invoke(value);

                var combinedValue = operation.Invoke(oldValue, newValue);

                return combinedValue;
            }
        }
    }
}
