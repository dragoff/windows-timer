using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WindowsTimer
{
    public class LinkMessageBox
    {
        public LinkMessageBox()
        {
            Window w = new Window()
            {
                Width = 200,
                Height = 100,
                WindowStyle = WindowStyle.ToolWindow,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                Title = "It is dragoff\'s timer",
                Topmost = true,
                MaxHeight = 100,
                MaxWidth = 200,
            };
            DockPanel panel = new DockPanel()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            TextBlock tx = new TextBlock();
            tx.Inlines.Add("Contact me on ");
            Run linkDescribtion = new Run("github");
            Hyperlink hyperl = new Hyperlink(linkDescribtion);
            tx.Inlines.Add(hyperl);
            panel.Children.Add(tx);
            w.Content = panel;
            w.Show();
            hyperl.Click += (sender, args) => System.Diagnostics.Process.Start("https://github.com/dragoff/windows-timer");
        }
    }
}
