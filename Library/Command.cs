//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Input;

//namespace DietApplication
//{
//    public class Command : ICommand
//    {
//        private readonly Lazy<DelegateCommand> command;

//        public Command(Action<object> executeAction, Func<bool> canExecuteAction = null)
//        {
//            command = canExecuteAction == null ?
//                new Lazy<DelegateCommand>(() => new DelegateCommand(executeAction)) :
//                new Lazy<DelegateCommand>(() => new DelegateCommand(executeAction, canExecuteAction));
//        }

//        public bool CanExecute(object parameter)
//        {
//            return command.Value.CanExecute();
//        }

//        public void Execute(object parameter)
//        {
//            command.Value.Execute();
//        }

//        public event EventHandler CanExecuteChanged
//        {
//            add { command.Value.CanExecuteChanged += value; }
//            remove { command.Value.CanExecuteChanged -= value; }
//        }

//        public void RaiseCanExecuteChanged()
//        {
//            command.Value.RaiseCanExecuteChanged();
//        }
//    }

//    public class DelegateCommand : ICommand
//    {
//        private readonly Predicate<object> _canExecute;
//        private readonly Action<object> _execute;
//        private Func<bool> canExecuteAction;

//        public event EventHandler CanExecuteChanged;
               

//        public DelegateCommand(Action<object> execute,
//                       Predicate<object> canExecute)
//        {
//            _execute = execute;
//            _canExecute = canExecute;
//        }

//        public DelegateCommand(Action<object> execute, Func<bool> canExecuteAction) : this(execute)
//        {
//            this.canExecuteAction = canExecuteAction;
//        }

//        public override bool CanExecute(object parameter)
//        {
//            if (_canExecute == null)
//            {
//                return true;
//            }

//            return _canExecute(parameter);
//        }

//        public override void Execute(object parameter)
//        {
//            _execute(parameter);
//        }

//        public void RaiseCanExecuteChanged()
//        {
//            if (CanExecuteChanged != null)
//            {
//                CanExecuteChanged(this, EventArgs.Empty);
//            }
//        }
//    }
//}
