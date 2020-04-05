using System.Windows.Media;
using WindowsTimer.Properties;

namespace WindowsTimer
{
    public static class SaveLoad
    {
        public static void Save()
        {
            Settings.Default["Background"] = StyleSettings.Instance.Background;
            Settings.Default["Foreground"] = StyleSettings.Instance.Foreground;
            Settings.Default["Size"] = StyleSettings.Instance.Size;
            Settings.Default["Style"] = (int)StyleSettings.Instance.Style;
            Settings.Default["Behaviour"] = (int)StyleSettings.Instance.Behaviour;
            Settings.Default.Save();
        }
        public static void Load()
        {
            try
            {
                Settings.Default.Reload();
                StyleSettings.Instance.Background = (Color)Settings.Default["Background"];
                StyleSettings.Instance.Foreground = (Color)Settings.Default["Foreground"];
                StyleSettings.Instance.Size = (int)Settings.Default["Size"];
                StyleSettings.Instance.Style =(WindowStyleView) Settings.Default["Style"];
                StyleSettings.Instance.Behaviour = (Mode)Settings.Default["Behaviour"];
            }
            catch { }
        }
    }
}
