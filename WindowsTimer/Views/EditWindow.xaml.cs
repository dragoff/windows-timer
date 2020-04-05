using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WinForms = System.Windows.Forms;

namespace WindowsTimer
{
    /// <summary>
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private WinForms.NotifyIcon notifier = new WinForms.NotifyIcon();
        private Window timerWindow;
        private Window settingsWindow;
        public EditWindow()
        {
            InitializeComponent();
            SaveLoad.Load();
            this.notifier.MouseDown += new WinForms.MouseEventHandler(notifier_MouseDown);
            this.notifier.Icon = Properties.Resources.icon;
            this.notifier.Visible = true;
        }

        void notifier_MouseDown(object sender, WinForms.MouseEventArgs e)
        {
            if (e.Button == WinForms.MouseButtons.Right)
            {
                ContextMenu menu = (ContextMenu)this.FindResource("NotifierContextMenu");
                menu.IsOpen = true;
                System.Timers.Timer closeContextMenuTimer = new System.Timers.Timer(3000);

                closeContextMenuTimer.Elapsed += new ElapsedEventHandler(closeContextMenuTimer_Elapsed);
                closeContextMenuTimer.AutoReset = false;
                closeContextMenuTimer.Enabled = true;
                closeContextMenuTimer.Start();
            }
        }
        void closeContextMenuTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                new Action(
                    delegate ()
                    {
                        ContextMenu menu = (ContextMenu)this.FindResource("NotifierContextMenu");
                        menu.IsOpen = false;
                        }
                    ));
        }
        private void Menu_ShowHide(object sender, RoutedEventArgs e)
        {
            if(timerWindow==null) return;
            if (timerWindow.Visibility == Visibility.Visible)
            {
                timerWindow.Visibility = Visibility.Hidden;
                
            }
            else
            {
                timerWindow.Visibility = Visibility.Visible;
            }
        }
        private void Menu_About(object sender, RoutedEventArgs e)
        {
            new LinkMessageBox();

        }
        private void Menu_Settings(object sender, RoutedEventArgs e)
        {
            
            settingsWindow = new SettingsWindow();
            this.Hide();
            settingsWindow.ShowDialog();
            if(timerWindow== null)
                this.Show();
        }
        private void Menu_EditTime(object sender, RoutedEventArgs e)
        {
            if(timerWindow!= null)
                timerWindow.Close();
            this.Show();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeBox.Text = SliderMain.Value.ToString();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            timerWindow = new CollapsedWindow(Convert.ToInt32(TimeBox.Text));
            timerWindow.Show();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Menu_Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
