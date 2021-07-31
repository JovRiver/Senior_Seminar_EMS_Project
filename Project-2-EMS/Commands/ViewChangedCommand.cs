using Project_2_EMS.Controls.ViewControls;
using System;
using System.Windows.Input;

namespace Project_2_EMS.Commands {
    public class ViewChangedCommand : ICommand {
        private readonly ActiveViewControls ActiveView;

        public ViewChangedCommand(ActiveViewControls activeView) {
            ActiveView = activeView;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            ActiveView.CurrentView = new ReceptionViewControl();
        }
    }
}
