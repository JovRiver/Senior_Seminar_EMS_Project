namespace Project_2_EMS.Controls.ViewControls {
    public class ActiveViewControls : BaseViewControls {
        private BaseViewControls _currentView;

        public BaseViewControls CurrentView {
            get => _currentView;
            set {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
    }
}
