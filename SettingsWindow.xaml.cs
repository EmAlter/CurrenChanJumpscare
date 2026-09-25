using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CurrenChanJumpscare
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            string iconPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets", "curren_chan.ico");
            if (File.Exists(iconPath))
            {
                this.Icon = new BitmapImage(new Uri(iconPath));
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(MinTimeTextBox.Text, out int min) && int.TryParse(MaxTimeTextBox.Text, out int max))
            {
                if (min <= 0 || max <= 0)
                {
                    MessageBox.Show("The time values must be greater than zero.", "Invalid values", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (max < min)
                {
                    MessageBox.Show("The maximum time cannot be less than the minimum time.", "Logic error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                bool playAudio = AudioCheckBox.IsChecked ?? false;

                ((App)System.Windows.Application.Current).StartJumpscareLoop(min, max, playAudio);
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter only integer numeric values.", "Typing error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}