using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProductMonitor.Views
{
    /// <summary>
    /// SettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            //pack(包)：程序集；component(组件)页面相当于一个组件，接地址；#片段,后面接页面中一片段
            NavigatePage.Navigate(new Uri("pack://application:,,,/ProductMonitor;component/Views/SettingPage.xaml#" + (sender as RadioButton)?.Tag.ToString(), UriKind.RelativeOrAbsolute));
        }
    }
}
