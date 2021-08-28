using Project_2_EMS.Controls.ViewControls;
using System;
using System.Windows.Input;

namespace Project_2_EMS.Commands {
    public class ViewChangedCommand : ICommand {
        private readonly ActiveViewControl ActiveView;

        public ViewChangedCommand(ActiveViewControl activeView) {
            ActiveView = activeView;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            return true;
        }

        public void Execute(object parameter) {
            switch (parameter.ToString()) {
                case "PatientLogin":
                    ActiveView.CurrentView = new PatientLoginViewControl();
                    break;
                case "StaffLogin":
                    ActiveView.CurrentView = new StaffLoginViewControl();
                    break;
                case "ReceptionistCalendar":
                    ActiveView.CurrentView = new ReceptionistCalendarViewControl();
                    break;
                default:
                    break;
            }
        }
    }
}
