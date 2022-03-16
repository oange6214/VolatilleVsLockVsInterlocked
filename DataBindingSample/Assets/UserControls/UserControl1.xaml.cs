using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace DataBindingSample.Assets.UserControls
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();


        }

        /// <summary>
        /// 屬性透過 GetValue, SetValue 操作相依屬性的值
        /// 相依屬性的包裝（Wrapper）方式
        /// 不應該在 UserValue 的 getter, setter 中加入其他的指令
        /// </summary>
        public double UserValue
        {
            get { return (double)GetValue(UserValueProperty); }
            set { SetValue(UserValueProperty, value); }
        }

        /// <summary>
        /// 註冊相依屬性，命名歸則：屬性名稱 + Property
        /// </summary>
        public static readonly DependencyProperty UserValueProperty =
            DependencyProperty.Register(
                nameof(UserValue),      // 屬性名稱
                typeof(double),         // 屬性型別
                typeof(UserControl1),   // 擁有屬性的類別
                new PropertyMetadata()  // 相依屬性的其他設定
                );



        public double UserValue2
        {
            get { return (double)GetValue(UserValue2Property); }
            set { SetValue(UserValue2Property, value); }
        }
        /// <summary>
        /// 1. 相依屬性無法設定預設值，需透過 PropertyMetadata 的第一個參數來設定
        /// 2. 不能對相依屬性使用 getter, setter 因此得透過屬性改變的 Callback 方法來操作
        /// </summary>
        public static readonly DependencyProperty UserValue2Property =
            DependencyProperty.Register(
                nameof(UserValue2), 
                typeof(double), 
                typeof(UserControl1), 
                new PropertyMetadata(
                    default(double),        // 屬性預設值
                    OnUserValue2Changed,     // 屬性值改變時的 Callback
                    CoerceUserValue2)        // 轉換屬性值的 Callback
                );
         
        /// <summary>
        /// 屬性值改變時的 Callback
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnUserValue2Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Debugger.Break();
            System.Console.WriteLine("OnUserValue2Changed");
        }

        /// <summary>
        /// 轉換屬性值的 Callback
        /// </summary>
        /// <param name="d"></param>
        /// <param name="baseValue"></param>
        /// <returns></returns>
        private static object CoerceUserValue2(DependencyObject d, object baseValue)
        {
            Debugger.Break();
            System.Console.WriteLine("CoerceUserValue2");
            return baseValue;
        }
    }
}
