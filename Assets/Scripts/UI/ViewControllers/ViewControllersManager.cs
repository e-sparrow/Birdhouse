using System;
using System.Linq;
using System.Collections.Generic;
using ESparrow.Utils.Patterns.Commands;
using ESparrow.Utils.Patterns.Commands.Interfaces;

namespace ESparrow.Utils.UI.ViewControllers
{
    public class ViewControllersManager
    {
        private static readonly ViewControllersManager Main;

        private readonly ICommandExecutor<Action> _commandExecutor = new DefaultCommandExecutor();

        private ViewControllerBase _currentViewController;

        private List<ViewControllerBase> _viewControllers;

        private List<ViewControllerBase> ActiveViewControllers => _viewControllers.Where(value => value.Active).ToList();
        private List<ViewControllerBase> PassiveViewControllers => _viewControllers.Except(ActiveViewControllers).ToList();

        static ViewControllersManager()
        {
            Main = new ViewControllersManager();
        }

        public ViewControllersManager()
        {
            _viewControllers = new List<ViewControllerBase>();

            _commandExecutor.OnEmptyUndoStackInvoked += () => _currentViewController.SetActive(false);
        }
        
        /// <summary>
        /// Is this view controller is current.
        /// </summary>
        /// <param name="viewController">This view controller</param>
        /// <returns>True if it's current view controller and false otherwise</returns>
        public bool IsCurrent(ViewControllerBase viewController)
        {
            return _currentViewController != null && _currentViewController.Equals(viewController);
        }

        /// <summary>
        /// Registers the view controller in this controller.
        /// </summary>
        /// <param name="viewController">View controller to register</param>
        public void Register(ViewControllerBase viewController)
        {
            _viewControllers.Add(viewController);
        }

        /// <summary>
        /// Unregisters the view controller from this controller.
        /// </summary>
        /// <param name="viewController">View controller to unregister</param>
        public void Unregister(ViewControllerBase viewController)
        {
            _viewControllers.Remove(viewController);
        }

        /// <summary>
        /// Opens the specified view controller and closes previous if needed.
        /// </summary>
        /// <param name="viewController">Specified view controller</param>
        /// <param name="closePrevious">Need to close previous view controller or not</param>
        public void Open(ViewControllerBase viewController, bool closePrevious = false)
        {
            var tempCurrent = _currentViewController;

            var command = new CommandGeneric<Action>(Open, Close);
            _commandExecutor.Execute(command);

            _currentViewController = viewController;

            void Open()
            {
                if (closePrevious)
                {
                    tempCurrent?.SetActive(false);
                }

                viewController.SetActive(true);
            }

            void Close()
            {
                if (closePrevious)
                {
                    tempCurrent?.SetActive(true);
                    _currentViewController = tempCurrent;
                }

                viewController.SetActive(false);
            }
        }

        /// <summary>
        /// Closes current window and opens previous if needed.
        /// </summary>
        public void Back()
        {
            _commandExecutor.Undo();
        }

        /// <summary>
        /// Closes all the active windows.
        /// </summary>
        public void Close()
        {
            _commandExecutor.Clear();
            ActiveViewControllers.ForEach(value => value.SetActive(false));
        }
    }
}
