using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace menu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> gyumolcsok = [];
        public MainWindow()
        {
            InitializeComponent();
            lb_1.ItemsSource = gyumolcsok;
        }
        private void MenuItemOpen_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("gyumolcs.txt");
            while (!sr.EndOfStream)
            {
                gyumolcsok.Add(sr.ReadLine().Trim());
            }
            sr.Close();
            lb_1.Items.Refresh();
        }
        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            StreamReader sr = new StreamReader("gyumolcs.txt");
            List<string> ellenorizni = [];
            while (!sr.EndOfStream)
            {
                ellenorizni.Add(sr.ReadLine().Trim());
            }
            sr.Close();
            Mentes(ellenorizni);
        }
        private void Mentes(List<string> ellenorizni)
        {
            StreamWriter sw = new StreamWriter("gyumolcs.txt", true);
            sw.WriteLine();
            if (ellenorizni.Count < gyumolcsok.Count)
            {
                for (int i = ellenorizni.Count; i < gyumolcsok.Count; i++)
                {
                    sw.Write(gyumolcsok[i]);
                }
            }
            sw.Close();
        }
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuItemAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Gyümölcsök &copy; Körmöndi", "Névjegy");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string bevitt = tb_be.Text;
            gyumolcsok.Add(bevitt);
            lb_1.Items.Refresh();
        }
    }
}