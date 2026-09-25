using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CurrenChanJumpscare
{
    public partial class App : Application
    {
        private DispatcherTimer? _timer;
        private Random _rnd = new Random();
        private int _minSeconds;
        private int _maxSeconds;
        private bool _playAudio;

        private global::System.Windows.Forms.NotifyIcon? _notifyIcon;

        private static Mutex? _mutex = null;

        protected override void OnStartup(StartupEventArgs e)
        {
            // Create a unique ID for the program instance
            const string appName = "CurrenChanJumpscare_UniqueInstanceID";

            // Try to create a new Mutex
            _mutex = new Mutex(true, appName, out bool createdNew);

            // If createdNew is false, another instance is already open
            if (!createdNew)
            {
                MessageBox.Show("The program is already running in the background. Check the icon in the lower-right corner of the application bar.",
                                "Jumpscare already active", MessageBoxButton.OK, MessageBoxImage.Information);

                // Stop this new instance immediately
                Application.Current.Shutdown();
                return;
            }

            base.OnStartup(e);
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            var settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        public void StartJumpscareLoop(int minSeconds, int maxSeconds, bool playAudio)
        {
            _minSeconds = minSeconds;
            _maxSeconds = maxSeconds;
            _playAudio = playAudio;

            if (_notifyIcon == null)
                SetupSystemTray();

            ScheduleNextVideo();
        }

        private void SetupSystemTray()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string iconPath = Path.Combine(baseDir, "assets", "curren_chan.ico");

            _notifyIcon = new global::System.Windows.Forms.NotifyIcon
            {
                Icon = new System.Drawing.Icon(iconPath),
                Visible = true,
                Text = "Jumpscare Active in Background"
            };

            var contextMenu = new global::System.Windows.Forms.ContextMenuStrip();
            contextMenu.Items.Add("Settings", null, (s, e) => ShowSettings());
            contextMenu.Items.Add("Exit", null, (s, e) => ExitApplication());

            _notifyIcon.ContextMenuStrip = contextMenu;
        }

        private void ShowSettings()
        {
            _timer?.Stop();
            var settingsWindow = new SettingsWindow();
            settingsWindow.Show();
        }

        private void ExitApplication()
        {
            if (_notifyIcon != null)
            {
                _notifyIcon.Visible = false;
                _notifyIcon.Dispose();
            }
            Application.Current.Shutdown();
        }

        private void ScheduleNextVideo()
        {
            int nextSeconds = _rnd.Next(_minSeconds, _maxSeconds + 1);

            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(nextSeconds) };
            _timer.Tick += (s, ev) =>
            {
                _timer?.Stop();
                ShowVideo();
            };
            _timer.Start();
        }

        private async void ShowVideo()
        {
            var window = new VideoWindow();

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string gifPath = Path.Combine(baseDir, "assets", "curren_chan.gif");
            window.Player.Source = new Uri(gifPath, UriKind.Absolute);

            if (_playAudio)
            {
                string audioPath = Path.Combine(baseDir, "assets", "curren_chan.mp3");
                window.AudioPlayer.Source = new Uri(audioPath, UriKind.Absolute);
            }
            window.Show();

            await Task.Delay(1600);

            window.Close();
            ScheduleNextVideo();
        }
    }
}