using Project_2_EMS.Commands;
using System.Windows.Input;

namespace Project_2_EMS.Controls.ViewControls {
    public class ActiveViewControl : BaseViewControl {
        private IView _currentView;

        public IView CurrentView {
            get => _currentView;
            set {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand ViewChangedCommand { get; set; }

        public ActiveViewControl() {
            ViewChangedCommand = new ViewChangedCommand(this);
        }
    }
}
