
using System.ComponentModel;

namespace TestBindingCode
{
    class Temp : INotifyPropertyChanged
    {
        private int num;
        public  int Num
        {
            get { return num; }
            set { num = value; OnPropertyChanged("Num"); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
