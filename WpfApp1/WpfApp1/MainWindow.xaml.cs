using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Media;
using Microsoft.Win32;
namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public string NazwaUtworó;
        public string filePath;
        List<Muzyka> muza = new List<Muzyka>();
        public SoundPlayer player = new SoundPlayer();

        public MainWindow()
        {

            InitializeComponent();
            MenuDodaj.Click += Dodaj_Click;
            MenuUsusn.Click += Button_Click;
            MenuPlay.Click += Play_Click;
        }
        public class Muzyka
        {
            public string nazwa { get; set; }
            public string ścieszka { get; set; }

            public override string ToString()
            {

                return ścieszka;

            }

        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "C:\\Windows\\Media";
                openFileDialog.DefaultExt.Contains("*.wav");
                openFileDialog.Filter = "Wav files (*wav)|*.wav";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == true)
                {
                    foreach (string filepath in openFileDialog.FileNames)
                    {
                        muza.Add(new Muzyka() { nazwa = openFileDialog.SafeFileName, ścieszka = filepath });
                        ListWPF.Items.Add(muza.Last<Muzyka>().nazwa);
                    }

                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "Błąd załadowania utworu.");
            }
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                muza.RemoveAt(ListWPF.SelectedIndex);
                ListWPF.Items.RemoveAt(ListWPF.SelectedIndex);
                STbar.Items.Clear();
                player.Stop();
            }
            catch
            {
                MessageBox.Show("Błąd usunięcia utworu! \nWybierz utwór!","Error");
            }
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Pętla.IsChecked.Equals("False")) { 
                    STbar.Items.Clear();
                player.SoundLocation = muza.ElementAt(ListWPF.SelectedIndex).ToString();
                STbar.Items.Add(ListWPF.SelectedItem);
                player.Play();
                }
                else
                {
                    STbar.Items.Clear();
                    player.SoundLocation = muza.ElementAt(ListWPF.SelectedIndex).ToString();
                    STbar.Items.Add(ListWPF.SelectedItem);
                    player.PlayLooping();
                }
            }
            catch
            {
                MessageBox.Show("Wybierz utwór", "Error");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if(ListWPF.SelectedIndex >= 1){
                    ListWPF.SelectedIndex--;
                    STbar.Items.Clear();
                    player.SoundLocation = muza.ElementAt(ListWPF.SelectedIndex).ToString();
                    STbar.Items.Add(ListWPF.SelectedItem);
                    player.Play();
                }
                else
                {
                    STbar.Items.Clear();
                    player.SoundLocation = muza.ElementAt(ListWPF.SelectedIndex).ToString();
                    STbar.Items.Add(ListWPF.SelectedItem);
                    player.Play();
                }
            }
            catch
            {
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                ListWPF.SelectedIndex ++;
                STbar.Items.Clear();
                player.SoundLocation = muza.ElementAt(ListWPF.SelectedIndex).ToString();
                STbar.Items.Add(ListWPF.SelectedItem);
                player.Play();
            }
            catch
            {
            }
        }

        private void Sync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                STbar.Items.Clear();
                player.SoundLocation = muza.ElementAt(ListWPF.SelectedIndex).ToString();
                STbar.Items.Add(ListWPF.SelectedItem);
                player.PlaySync();

            }
            catch
            {
                MessageBox.Show("Wybierz utwór", "Error");
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                STbar.Items.Clear();
                player.Stop();
            }
            catch
            {
                MessageBox.Show("Bład obsługi!","Error");
            }
        }
    }
}
