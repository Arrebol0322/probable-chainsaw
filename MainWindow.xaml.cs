using ProductMonitor.MyUserControl;
using ProductMonitor.OperationCommand;
using ProductMonitor.ViewModels;
using ProductMonitor.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductMonitor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowVm mainWindowVM = new MainWindowVm();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mainWindowVM;
        }

        /// <summary>
        /// 显示车间详情页
        /// </summary>
        private void ShowDetailUC()
        {
            WorkShopUC workShopDetailUC = new WorkShopUC();

            mainWindowVM.MonitorUserControl = workShopDetailUC;

            //切换页面时设置为由下至上的动画效果
            //位移
            ThicknessAnimation thicknessAnimation = new ThicknessAnimation(new Thickness(0,50,0,-50),new Thickness(0,0,0,0),new TimeSpan(0,0,0,0,200));
            //透明度
            DoubleAnimation doubleAnimation = new DoubleAnimation(0,1,new TimeSpan(200));

            //设置目标对象
            Storyboard.SetTarget(thicknessAnimation,workShopDetailUC);
            Storyboard.SetTarget(doubleAnimation,workShopDetailUC);

            //设置目标属性
            Storyboard.SetTargetProperty(thicknessAnimation, new PropertyPath("Margin"));
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("Opacity"));

            //添加对象
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(thicknessAnimation);
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }

        /// <summary>
        /// 展示详情命令
        /// </summary>
        public Command ShowDetailCmm
        {
            get
            {
                return new Command(ShowDetailUC);
            }
        }


        /// <summary>
        /// 返回车间监控页面的方法
        /// </summary>
        private void ReturnMonitorUC()
        {
            MonitorUC monitorUC = new MonitorUC();
            mainWindowVM.MonitorUserControl= monitorUC;
        }

        /// <summary>
        /// 返回命令的属性
        /// </summary>
        public Command ReturnMonitorCmm
        {
            get {return new Command(ReturnMonitorUC); }
        }

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMinimization(object sender, EventArgs e)
        {
            this.WindowState=WindowState.Minimized;
        }

        /// <summary>
        /// 最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMaximization(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormClose(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 弹出配置窗口方法
        /// </summary>
        private void ShowSettingWindow()
        {
            SettingWindow settingWindow = new SettingWindow() { Owner = this };
            settingWindow.ShowDialog();
        }

        /// <summary>
        /// 弹出配置窗口的命令的属性
        /// </summary>
        public Command ShowSettingWindowCmm
        {
            get
            {
                return new Command(ShowSettingWindow);
            }
        }
    }
}