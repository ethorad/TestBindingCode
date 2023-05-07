
using System.ComponentModel;

namespace TestBindingCode
{
    class Temp : INotifyPropertyChanged
    {
        private int num;

        public int Num
        {
            get { return num; }
            set { num = value; NotifyPropertyChanged("Num"); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            // Use null forgiveness operator to keep from invoking null event
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
