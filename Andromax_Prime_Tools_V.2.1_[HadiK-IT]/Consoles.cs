using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Andromax
{
    internal static class Consoles
    {
        public static void Delay(double dblSecs)
        {
            DateTime.Now.AddSeconds(0.0000115740740740741d);
            var dateTime = DateTime.Now.AddSeconds(0.0000115740740740741d);
            var dateTime1 = dateTime.AddSeconds(dblSecs);
            while (DateTime.Compare(DateTime.Now, dateTime1) <= 0)
                Application.DoEvents();
        }
        public static string adb(string cmd, BackgroundWorker worker, DoWorkEventArgs e)
        {
            if (worker.CancellationPending)
            {
                worker.CancelAsync();
                e.Cancel = true;
                return " STOPPED!";
            }
            else
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine("ADB Command : " + cmd);
                Console.WriteLine(" ");
                Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    FileName = "Data\\adb.exe",
                    Arguments = cmd,
                    RedirectStandardOutput = true
                }
            };
                process.Start();
                Console.WriteLine("---------------------------------------------------------------------------------------------------");
                Console.WriteLine(" ");
                return process.StandardOutput.ReadToEnd();
            }
        }

        public static string adbcmd(string cmd)
        {
            Process process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    FileName = "Data\\cmd.bat",
                    Arguments = cmd,
                    RedirectStandardOutput = true
                }
            };
            process.Start();
            return process.StandardOutput.ReadToEnd();
        }

        public static bool adbdevice(BackgroundWorker worker, DoWorkEventArgs e)
        {
            bool flag = false;
            if (Consoles.adb("devices", worker, e).Contains("\tdevice"))
            {
                Consoles.adb("shell mount -o rw,remount rootfs /", worker, e);
                Consoles.adb("shell cp /etc/recovery.fstab /etc/fstab", worker, e);
                Consoles.adb("shell mount /cache", worker, e);
                Consoles.adb("shell mount /data", worker, e);
                Consoles.adb("shell mount /system", worker, e);
                Consoles.adb("shell mount /sdcard", worker, e);
                Consoles.adb("shell mount -o rw,remount /cache", worker, e);
                Consoles.adb("shell mount -o rw,remount /data", worker, e);
                Consoles.adb("shell mount -o rw,remount /system", worker, e);
                flag = true;
            }
            else if (Consoles.adb("devices", worker, e).Contains("\trecovery"))
            {
                Consoles.adb("shell mount -o rw,remount rootfs /", worker, e);

                if (!Consoles.adb("shell if test -f '/etc/fstab'; then echo true; fi", worker, e).Contains("true"))
                {
                    Consoles.adb("shell cp /etc/recovery.fstab /etc/fstab", worker, e);
                }
                Consoles.adb("shell mount /cache", worker, e);
                Consoles.adb("shell mount /data", worker, e);
                Consoles.adb("shell mount /system", worker, e);
                Consoles.adb("shell mount /sdcard", worker, e);
                Consoles.adb("shell mount -o rw,remount /cache", worker, e);
                Consoles.adb("shell mount -o rw,remount /data", worker, e);
                Consoles.adb("shell mount -o rw,remount /system", worker, e);


                flag = true;
            }
            return flag;
        }
    }
}
