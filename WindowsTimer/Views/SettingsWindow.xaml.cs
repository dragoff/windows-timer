using System.Windows;
using System.Windows.Input;

namespace WindowsTimer
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            DataContext = StyleSettings.Instance;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            SaveLoad.Save();
            this.Close();
        }
    }
}
