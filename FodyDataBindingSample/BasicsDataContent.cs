using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FodyDataBindingSample
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
            set { _number = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
