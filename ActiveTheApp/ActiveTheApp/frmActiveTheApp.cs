using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ActiveTheApp
{
    public partial class frmActiveTheApp : Form
    {
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        System.Timers.Timer aTimer;
        static bool flgMinMax = false;
        static string AppName = string.Empty;

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }

        static void PreventSleep()
        {
            // Prevent Idle-to-Sleep (monitor not affected) (see note above)
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
        }

        public frmActiveTheApp()
        {
            InitializeComponent();
            AppName = txtbxappexename.Text.ToString();
        }

        private void btnactivateapp_Click(object sender, EventArgs e)
        {
           // MornaLicensing.License l = new MornaLicensing.License();
             var rr = MornaLicensing.License.hdCollection;

            AppName = txtbxappexename.Text.ToString();
            aTimer.Enabled = true;
            hideForm();
        }

        private void frmActiveTheApp_Load(object sender, EventArgs e)
        {
            this.Paint += this.OnPaint;
            Resize += new EventHandler(frmActiveTheApp_Resize);
            aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = Convert.ToDouble(txtinterval.Text) * 1000;
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var p = System.Diagnostics.Process.GetProcessesByName(AppName).FirstOrDefault();

            if (p != null)
            {
                if (flgMinMax == false)
                {
                    Process[] processlist = Process.GetProcesses();

                    foreach (Process prc in processlist)
                    {
                        if (AppName == prc.ProcessName)
                        {
                            flgMinMax = true;
                            ShowWindowAsync(prc.MainWindowHandle, SW_SHOWMINIMIZED);
                            ShowWindow(prc.MainWindowHandle, SW_SHOWMINIMIZED);
                            ShowWindowAsync(prc.MainWindowHandle, SW_SHOWMAXIMIZED);
                            ShowWindow(prc.MainWindowHandle, SW_SHOWMAXIMIZED);
                            ShowWindowAsync(prc.MainWindowHandle, SW_SHOWMINIMIZED);
                            ShowWindow(prc.MainWindowHandle, SW_SHOWMINIMIZED);
                            ShowWindowAsync(prc.MainWindowHandle, SW_SHOWMAXIMIZED);
                            ShowWindow(prc.MainWindowHandle, SW_SHOWMAXIMIZED);
                            PreventSleep();
                        }
                    }
                }
                else
                {
                    Process[] processlist = Process.GetProcesses();

                    foreach (Process prc in processlist)
                    {
                        if (AppName == prc.ProcessName)
                        {
                            flgMinMax = false;
                            ShowWindowAsync(prc.MainWindowHandle, SW_SHOWMINIMIZED);
                            ShowWindow(prc.MainWindowHandle, SW_SHOWMINIMIZED);
                            ShowWindowAsync(prc.MainWindowHandle, SW_SHOWMAXIMIZED);
                            ShowWindow(prc.MainWindowHandle, SW_SHOWMAXIMIZED);
                            ShowWindowAsync(prc.MainWindowHandle, SW_SHOWMINIMIZED);
                            ShowWindow(prc.MainWindowHandle, SW_SHOWMINIMIZED);
                            ShowWindowAsync(prc.MainWindowHandle, SW_SHOWMAXIMIZED);
                            ShowWindow(prc.MainWindowHandle, SW_SHOWMAXIMIZED);
                            PreventSleep();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(new Form { TopMost = true }, "The \"" + AppName + "\" is not correct, try to enter correct process name (App exe name).");

                Application.Exit();
                GC.Collect();
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            AppName = txtbxappexename.Text.ToString();
            aTimer.Interval = Convert.ToDouble(txtinterval.Text) * 1000;
            toolStripStatusLabelappname.Text = "Auto Activate App: " + AppName;
        }

        private void MinimzedTray()
        {
            if (notifyIcon == null)
                return;
            notifyIcon.Visible = true;
            //notifyIcon.Icon = new System.Drawing.Icon(Path.GetFullPath(@"assets\activate1.ico")); ;
            notifyIcon.Icon = ActiveTheApp.Properties.Resources.activate;
            notifyIcon.BalloonTipText = "Auto Activate \"" + txtbxappexename.Text.ToString() + "\" App";
            notifyIcon.BalloonTipTitle = "\"" + txtbxappexename.Text.ToString() + "\" Application is Running in BackGround";
            notifyIcon.ShowBalloonTip(0);

        }

        private void MaxmizedFromTray()
        {
            if (notifyIcon == null)
                return;
            notifyIcon.Visible = true;
            notifyIcon.Icon = ActiveTheApp.Properties.Resources.activate;
            notifyIcon.BalloonTipText = "Auto Activate \"" + txtbxappexename.Text.ToString() + "\" App";
            notifyIcon.BalloonTipTitle = "\"" + txtbxappexename.Text.ToString() + "\" Application is Running in Foreground";
            notifyIcon.ShowBalloonTip(0);
        }

        private void frmActiveTheApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                hideForm();
            }
        }

        private void hideForm()
        {
            this.WindowState = FormWindowState.Minimized;
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void frmActiveTheApp_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                MinimzedTray();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                MaxmizedFromTray();
            }
        }       

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIcon.BalloonTipText = "Closing \"Auto ActivateApp\"";
            notifyIcon.BalloonTipTitle = "\"" + "Auto ActivateApp " + "\" is Closing";
            notifyIcon.ShowBalloonTip(0);
            notifyIcon.Visible = false;
            notifyIcon = null;
            this.Close();
            this.Dispose();
            Application.Exit();
            GC.Collect();
        }        

        private void notifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
            MaxmizedFromTray();
        }
    }
}
