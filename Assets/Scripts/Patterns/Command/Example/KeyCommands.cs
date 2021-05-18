using UnityEngine;
using ESparrow.Utils.Enums;
using ESparrow.Utils.Instructions;
using ESparrow.Utils.Instructions.Kinds;

namespace ESparrow.Utils.Patterns.Command.Example
{
    [AddComponentMenu("ESparrow/Utils/Patterns/Command/Example")]
    public class KeyCommands : MonoBehaviour
    {
        [SerializeField] private KeyCode incrementKey;
        [SerializeField] private KeyCode decrementKey;

        [SerializeField] private KeyCode undoKey;
        [SerializeField] private KeyCode redoKey;

        [SerializeField] private Executor executor;
        [SerializeField] private CommandExecutor commandExecutor;

        private KeyInstruction incrementInstruction;
        private KeyInstruction decrementInstruction;

        private KeyInstruction undoInstruction;
        private KeyInstruction redoInstruction;

        private Command incrementCommand;
        private Command decrementCommand;

        private int _targetInt;

        private void Increment()
        {
            var command = commandExecutor.GetCommandByName("Increment");
            commandExecutor.DoCommand(command);
        }

        private void Decrement()
        {
            var command = commandExecutor.GetCommandByName("Decrement");
            commandExecutor.DoCommand(command);
        }

        private void IncrementValue()
        {
            _targetInt++;
            Debug.Log(_targetInt);
        }

        private void DecrementValue()
        {
            _targetInt--;
            Debug.Log(_targetInt);
        }

        private void Undo()
        {
            Debug.Log($"Undo");
            commandExecutor.Undo();
        }

        private void Redo()
        {
            Debug.Log($"Redo");
            commandExecutor.Redo();
        }

        private void OnEnable()
        {
            incrementCommand = new Command("Increment", IncrementValue, DecrementValue);
            decrementCommand = new Command("Decrement", DecrementValue, IncrementValue);

            commandExecutor.AddCommand(incrementCommand);
            commandExecutor.AddCommand(decrementCommand);

            incrementInstruction = new KeyInstruction(incrementKey, EKeyState.Pressed, Increment);
            decrementInstruction = new KeyInstruction(decrementKey, EKeyState.Pressed, Decrement);

            undoInstruction = new KeyInstruction(undoKey, EKeyState.Pressed, Undo);
            redoInstruction = new KeyInstruction(redoKey, EKeyState.Pressed, Redo);

            executor.AddInstruction(incrementInstruction);
            executor.AddInstruction(decrementInstruction);

            executor.AddInstruction(undoInstruction);
            executor.AddInstruction(redoInstruction);
        }

        private void OnDisable()
        {
            executor.RemoveInstruction(incrementInstruction);
            executor.RemoveInstruction(decrementInstruction);

            executor.RemoveInstruction(undoInstruction);
            executor.RemoveInstruction(redoInstruction);

            commandExecutor.RemoveCommand(incrementCommand);
            commandExecutor.RemoveCommand(decrementCommand);

            incrementInstruction = null;
            decrementInstruction = null;

            undoInstruction = null;
            redoInstruction = null;

            incrementCommand = null;
            decrementCommand = null;
        }
    }
}
