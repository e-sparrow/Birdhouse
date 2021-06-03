using UnityEngine;

namespace ESparrow.Utils.Patterns.FluentBuilder.Examples
{
    public class ConcreteInstance
    {
        public string Name
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        private string _message;

        public ConcreteInstance()
        {

        }

        public static ConcreteBuilder CreateBuilder()
        {
            return new ConcreteBuilder();
        }

        public ConcreteInstance(string name, int age, string message)
        {
            Name = name;
            Age = age;
            _message = message;
        }

        public void SetMessage(string message)
        {
            _message = message;
        }

        public void Log()
        {
            Debug.Log($"Name: {Name}, Age: {Age}, _message: {_message}");
        }
    }
}
