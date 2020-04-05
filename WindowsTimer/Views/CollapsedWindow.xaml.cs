using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WindowsTimer
{
    /// <summary>
    /// Логика взаимодействия для CollapsedWindow.xaml
    /// </summary>
    public partial class CollapsedWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private int minutes;
        private int seconds;

        private delegate void Act();
        private Act myAction;
        public CollapsedWindow(int minutes)
        {
            InitializeComponent();
            this.minutes = minutes;
            seconds = 60;

            StyleSettings.Instance.ActionChanging += SetBehaviour;
            StyleSettings.Instance.StyleChanging += SetAppearance;
            SetAppearance();
            SetBehaviour();

            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 1, 0);
            if (minutes == 1)
                timer.Interval = new TimeSpan(0, 0, 1);
            TimeText.Text = minutes.ToString();
            timer.Start();
        }

        public void SetAppearance()
        {
            switch (StyleSettings.Instance.Style)
            {
                case WindowStyleView.Circle:
                    TimeText.Template = this.FindResource("TbCircle") as ControlTemplate;
                    break;
                case WindowStyleView.Quad:
                    TimeText.Template = this.FindResource("TbQuad") as ControlTemplate;
                    break;
            }

            TimeText.Background = new SolidColorBrush(StyleSettings.Instance.Background);
            TimeText.Foreground = new SolidColorBrush(StyleSettings.Instance.Foreground);
            TimeText.Width = StyleSettings.Instance.Size;
            TimeText.Height = StyleSettings.Instance.Size;
            TimeText.FontSize = StyleSettings.Instance.Size * 0.6;
            this.Width = StyleSettings.Instance.Size;
            this.Height = StyleSettings.Instance.Size;
            this.UpdateLayout();
        }
        public void SetBehaviour()
        {
            switch (StyleSettings.Instance.Behaviour)
            {
                case Mode.Hibernate:
                    myAction = Controller.Hibernate;
                    break;
                case Mode.Reboot:
                    myAction = Controller.Reboot;
                    break;
                case Mode.Shutdown:
                    myAction = Controller.Shutdown;
                    break;
                case Mode.Sleep:
                    myAction = Controller.Sleep;
                    break;
                default:
                    myAction = Controller.Shutdown;
                    break;
            }
        }
        private void timerTick(object sender, EventArgs e)
        {
            minutes--;
            if (minutes > 1)
            {
                TimeText.Text = minutes.ToString();
                return;
            }
            if (minutes == 1)
            {
                timer.Interval = new TimeSpan(0, 0, 1);
                minutes = 0;
            }

            if (minutes <= 0)
            {
                seconds--;
                TimeText.Text = seconds.ToString();
                if (seconds == 0)
                {
                    timer.Stop();
                    myAction();
                    Application.Current.Shutdown();
                }
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
