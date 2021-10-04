using System;

namespace ESparrow.Utils.Patterns.FluentBuilder.Examples
{
    public class ConcreteBuilder : BuilderBase<ConcreteInstance>
    {
        protected override event Action<ConcreteInstance> OnInstanceBuilded = instance => instance.Log();

        public ConcreteBuilder SetName(string name)
        {
            _instance.Name = name;
            return this;
        }

        public ConcreteBuilder SetAge(int age)
        {
            _instance.Age = age;
            return this;
        }

        public ConcreteBuilder SetMessage(string message)
        {
            _instance.SetMessage(message);
            return this;
        }
    }
}
