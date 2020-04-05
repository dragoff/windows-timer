using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsTimer
{
    public static class Controller
    {
        public static void Sleep()
        {
            Application.SetSuspendState(PowerState.Suspend, true, true);
        }
        public static void Shutdown()
        {
            var psi = new ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
        public static void Hibernate()
        {
            Application.SetSuspendState(PowerState.Hibernate, true, true);
        }
        public static void Reboot()
        {
            var psi = new ProcessStartInfo("shutdown", "/r /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }
    }
}
