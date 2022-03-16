using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindingSample
{
    public class BasicsDataContent : INotifyPropertyChanged
    {
        // prop
        public int Value { get; set; } = 10;

        // propfull
        private double _number = 20;
        public double Number
        {
            get { return _number; }
            set { _number = value; OnNoifyPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNoifyPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
