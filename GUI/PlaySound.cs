using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class PlaySound
    {
        public static void playNeedText(string txt)
        {
            
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    WorkingDirectory = Application.StartupPath + "\\sound",
                    FileName = @"D:\app\python\python.exe",
                    Arguments = $" text_sang_nhac.py \"{txt}\"",
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Process p = Process.Start(startInfo);
                // p.WaitForExit();

            }
            catch (Exception ex) //  bắt lỗi c# 
            {
                ex.ToString();
            }
        }
    }
}
