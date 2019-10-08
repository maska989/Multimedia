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
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public string NazwaUtworó;
        public string filePath;
        List<Muzyka> muza = new List<Muzyka>();
        public SoundPlayer player = new SoundPlayer();

        public MainWindow()
        {

            InitializeComponent();

            
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
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.DefaultExt.Contains("*.wav");
                openFileDialog.Filter = "Wav files (*wav)|*.wav";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == true)
                {

                      foreach(string filepath in openFileDialog.FileNames)
                    {
                        muza.Add(new Muzyka() {nazwa = openFileDialog.SafeFileName , ścieszka = filepath });
                        ListWPF.Items.Add(this.muza.Last<Muzyka>());
                        
                    }
                    
                }
                
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "Błąd załadowania utworu.");
            }
           
        }


        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ListBoxWav.SelectedItem.;
            //Utwór.Remove();
        }

        private void ListWPF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            
           // ListWPF.SelectedIndex = muza.;
         //   player.SoundLocation = 
        }
    }
}
