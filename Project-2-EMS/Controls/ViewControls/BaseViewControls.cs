using System.ComponentModel;

namespace Project_2_EMS.Controls.ViewControls {
    public class BaseViewControls : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
