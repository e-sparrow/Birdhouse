using UnityEngine;
using ESparrow.Utils.Patterns.CommandPattern;
using TMPro;

namespace Demos.Patterns.CommandPattern
{
    [AddComponentMenu("Demos/Patterns/CommandPattern/MathCommandsManager")]
    public class MathCommandsManager : MonoBehaviour
    {
        [SerializeField] private int value;

        [SerializeField] private GameObject commandBoxPrefab;

        [SerializeField] private TMP_Text valueText;

        [SerializeField] private MathBoxesStack doStack;
        [SerializeField] private MathBoxesStack undoStack;

        private CommandExecutor _commandExecutor;

        private MathCommand _incrementCommand;
        private MathCommand _decrementCommand;

        private int Value
        {
            get => value;
            set
            {
                this.value = value;
                valueText.text = value.ToString();
            }
        }

        public void Increment()
        {
            _commandExecutor.Execute(_incrementCommand);
            doStack.Add(CreateBox(_incrementCommand));
            undoStack.Clear();
        }

        public void Decrement()
        {
            _commandExecutor.Execute(_decrementCommand);
            doStack.Add(CreateBox(_decrementCommand));
            undoStack.Clear();
        }

        public void Undo()
        {
            _commandExecutor.Undo();

            var pop = doStack.Pop();
            if (pop != null)
            {
                undoStack.Add(pop);
            }
        }

        public void Redo()
        {
            _commandExecutor.Redo();

            var pop = undoStack.Pop();
            if (pop != null)
            {
                doStack.Add(pop);
            }
        }

        private MathCommandBox CreateBox(MathCommand command)
        {
            var box = Instantiate(commandBoxPrefab);

            var component = box.GetComponent<MathCommandBox>();
            component.Init(command);

            return component;
        }

        private void IncrementValue()
        {
            Value++;
        }

        private void DecrementValue()
        {
            Value--;
        }

        private void Start()
        {
            _commandExecutor = new CommandExecutor();

            _incrementCommand = new MathCommand(IncrementValue, DecrementValue, "+");
            _decrementCommand = new MathCommand(DecrementValue, IncrementValue, "-");

            Value = value;
        }

        private void OnValidate()
        {
            Value = value;
        }
    }
}
