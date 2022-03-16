using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VolatilleVsLockVsInterlocked
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public int _outCounter = 0;
        public static int _outCounterStatic = 0;
        public volatile int _outCounterVolatile = 0;

        public MainWindow()
        {
            InitializeComponent();

            //TestClass tc = new TestClass();

            DataContext = this;

            //Thread threadA = new Thread(() =>
            Task.Run(() =>
            {
                TestClass tc = new TestClass();

                int stopCountA = 0;

                while (stopCountA++ < 50)
                {
                    //TB_Text += $"[Task-A]   Field: {++tc._counter}, Static: {++TestClass._counterStatic}, Volatile: {++tc._counterVolatile}, outCounter: {++_outCounter}, outCounterStatic: {++_outCounterStatic}, outCounterVolatile: {++_outCounterVolatile}\r\n";
                    TB_Text += $"[Task-A]   Field: {tc._counter}, Static: {TestClass._counterStatic}, Volatile: {tc._counterVolatile}, outCounter: {_outCounter}, outCounterStatic: {_outCounterStatic}, outCounterVolatile: {_outCounterVolatile}\r\n";

                    Thread.Sleep(10);


                }

            });
            //threadA.Start();

            //Thread threadB = new Thread(() =>
            Task.Run(() =>
            {
                TestClass tc = new TestClass();

                int stopCountB = 0;

                while (stopCountB++ < 50)
                {
                    //TB_Text += $"[Task-B]   Field: {++tc._counter}, Static: {++TestClass._counterStatic}, Volatile: {++tc._counterVolatile}, outCounter: {++_outCounter}, outCounterStatic: {++_outCounterStatic}, outCounterVolatile: {++_outCounterVolatile}\r\n";
                    TB_Text += $"[Task-B]  修改  Field: {++tc._counter}, Static: {++TestClass._counterStatic}, Volatile: {++tc._counterVolatile}, outCounter: {++_outCounter}, outCounterStatic: {++_outCounterStatic}, outCounterVolatile: {++_outCounterVolatile}\r\n";

                    Thread.Sleep(10);
                }

            });
            //threadB.Start();

        }

        #region Field


        #endregion

        #region Properties
        private string _tb_Text;

        public string TB_Text
        {
            get { return _tb_Text; }
            set { _tb_Text = value; NotifyPropertyChanged(); }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class TestClass
    {
        public int _counter = 0;
        public static int _counterStatic = 0;
        public volatile int _counterVolatile = 0;
    }

}
