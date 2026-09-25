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
                    MessageBox.Show("I tempi devono essere maggiori di zero.", "Valori non validi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (max < min)
                {
                    MessageBox.Show("Il tempo massimo non può essere minore del tempo minimo.", "Errore di logica", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                bool playAudio = AudioCheckBox.IsChecked ?? false;

                ((App)System.Windows.Application.Current).StartJumpscareLoop(min, max, playAudio);
                this.Close();
            }
            else
            {
                MessageBox.Show("Inserisci solo valori numerici interi.", "Errore di digitazione", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}