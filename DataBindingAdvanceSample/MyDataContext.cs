using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingAdvanceSample
{
    public class MyDataContext
    {
        public MyClass MyClass { get; set; } = new MyClass();
    }

    public class MyClass : INotifyPropertyChanged
    {

        private double _myValue;

        public double MyValue
        {
            get { return _myValue; }
            set { _myValue = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
