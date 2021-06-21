using System.Linq;
using System.Collections.Generic;
using ESparrow.Utils.Patterns.CommandPattern;

namespace ESparrow.Utils.UI.ViewControllers
{
    public static class ViewControllersManager
    {
        // Выполняющий команды скрипт, который в данном случае нужен для последовательного закрытия окон.
        private static readonly CommandExecutor _commandExecutor = new CommandExecutor();

        // Текущий ViewController. Остаётся null до первого вызова метода Open.
        private static ViewControllerBase _currentViewController;

        private static List<ViewControllerBase> _viewControllers;

        private static List<ViewControllerBase> ActiveViewControllers => _viewControllers.Where(value => value.IsActive).ToList();
        private static List<ViewControllerBase> PassiveViewControllers => _viewControllers.Except(ActiveViewControllers).ToList();

        static ViewControllersManager()
        {
            _viewControllers = new List<ViewControllerBase>();

            _commandExecutor.OnEmptyUndoExecuted += () => _currentViewController.SetActive(false);
        }
        
        public static bool IsCurrent(ViewControllerBase viewController)
        {
            return _currentViewController != null && _currentViewController.Equals(viewController);
        }

        public static void Add(ViewControllerBase viewController)
        {
            _viewControllers.Add(viewController);
        }

        /// <summary>
        /// Открывает окно. Если leaveOn - false, то при открытии следующего окна оно закроется.
        /// </summary>
        public static void Open(ViewControllerBase viewController, bool closePrevious)
        {
            var tempCurrent = _currentViewController;

            var command = new Command(Open, Close);
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
        /// Закрывает текущее окно и открывает предыдущее.
        /// </summary>
        public static void Back()
        {
            _commandExecutor.Undo();
        }

        public static void Close()
        {
            _commandExecutor.Clear();
            ActiveViewControllers.ForEach(value => value.SetActive(false));
        }
    }
}
