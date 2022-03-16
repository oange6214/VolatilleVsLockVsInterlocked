using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace FodyDataBindingSample.Assets.UserControls
{
    public partial class UCdemo : UserControl
    {
        public UCdemo()
        {
            InitializeComponent();
        }


        public double UserValue
        {
            get { return (double)GetValue(UserValueProperty); }
            set { SetValue(UserValueProperty, value); }
        }
        /// <summary>
        /// 1. 相依屬性無法設定預設值，需透過 PropertyMetadata 的第一個參數來設定
        /// 2. 不能對相依屬性使用 getter, setter 因此得透過屬性改變的 Callback 方法來操作
        /// </summary>
        public static readonly DependencyProperty UserValueProperty =
            DependencyProperty.Register(
                nameof(UserValue),
                typeof(double),
                typeof(UCdemo),
                new PropertyMetadata(
                    default(double),        // 屬性預設值
                    OnUserValueChanged,     // 屬性值改變時的 Callback
                    CoerceUserValue)        // 轉換屬性值的 Callback
                );

        /// <summary>
        /// 屬性值改變時的 Callback
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnUserValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debugger.Break();
            System.Console.WriteLine("OnUserValueChanged");
        }

        /// <summary>
        /// 轉換屬性值的 Callback
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        private static object CoerceUserValue(DependencyObject d, object baseValue)
        {
            Debugger.Break();
            System.Console.WriteLine("CoerceUserValue");
            return baseValue;
        }
    }
}
