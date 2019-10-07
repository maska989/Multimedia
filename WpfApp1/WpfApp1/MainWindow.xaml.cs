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
        List<Lista1> Utwór = new List<Lista1>();
        public MainWindow()
        {
            
            InitializeComponent();
            
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

                      foreach(string filename in openFileDialog.FileNames)
                    {
                        Utwór.Add(new Lista1() {Nazwa = "cos" });
                        ListBoxWav.Items.Add("{0}",Utwór.ToString);
                        
                    }
//                    Utwór.Add(new Lista1() {Nazwa = openFileDialog.SafeFileName});
                    
                }
                
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "Błąd załadowania utworu.");
            }
           
        }
        public class Lista1
        {
            public string Nazwa { get; set; }
           // public string Ścieszka { get; set; }
           // public int Procent { get; set; }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ListBoxWav.SelectedItem.;
            //Utwór.Remove();
        }
    }
}
