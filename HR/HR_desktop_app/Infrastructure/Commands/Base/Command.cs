using System;
using System.Windows.Input;

namespace HR_desktop_app.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value; 
            remove => CommandManager.RequerySuggested -= value;
        }

        public virtual bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);
    }
}
