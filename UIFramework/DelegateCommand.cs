using System;
using System.Windows.Input;

namespace UIFramework {
    public class DelegateCommand : ICommand {
        private readonly Predicate<object> _CanExecute;
        private readonly Action _Execute;

        public DelegateCommand(Predicate<object> canExecute, Action execute) {
            this._CanExecute = canExecute;
            this._Execute = execute;
        }

        public bool CanExecute(object parameter) {
            return this._CanExecute(parameter);
        }

        public void Execute(object parameter) {
            this._Execute();
        }

        public void FireCanExecuteChanged() {
            var handler = this.CanExecuteChanged;
            if (handler != null) {
                handler(this, new EventArgs());
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
