using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HostelControlService.Utils
{
    internal class ViewModelCommand : ICommand
    {
        #region Field
        private readonly Action<object> _executeAction;
        private readonly Predicate<object> _canExecuteAction;

        public event EventHandler CanExecuteChanged 
        {
             add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion

        #region Constructor

        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }
        #endregion

        public bool CanExecute(object parameter) => _canExecuteAction == null ? true : _canExecuteAction(parameter);

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
