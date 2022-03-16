using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace DataBindingSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as BasicsDataContent).Number += 1;
            (this.DataContext as BasicsDataContent).Value += 1;
        }
    }
}
