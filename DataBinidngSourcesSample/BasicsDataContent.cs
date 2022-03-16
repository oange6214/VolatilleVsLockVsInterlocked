using System.ComponentModel;

namespace DataBinidngSourcesSample
{
    public class BasicsDataContent : INotifyPropertyChanged
    {
        // prop
        public double Value { get; set; } = 0.5;

        // propfull
        private double _number = 1;

        public double Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
