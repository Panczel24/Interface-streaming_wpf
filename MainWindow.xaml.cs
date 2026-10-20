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

namespace Interface_streaming
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StreamingPlatform streaming = new StreamingPlatform();
        public MainWindow()
        {
            InitializeComponent();
            Beolvasas();
        }


        private void Beolvasas()
        {
            streaming = new StreamingPlatform();

            string[] filmek = File.ReadAllLines("catalog.txt");
            foreach (string sor in filmek)
            {
                string[] adatok = sor.Split(";");
                Video video = new Video(adatok[0], int.Parse(adatok[1]));
                Movie film = new Movie(video);
                streaming.addContent(film);
            }

            string[] sorozatok = File.ReadAllLines("series.txt");
            foreach (string sor in sorozatok)
            {
                string[] adatok = sor.Split(";");
                string cim = adatok[0];
                List<Video> reszek = new List<Video>();

                Video video1 = new Video("1. rész", int.Parse(adatok[1]));
                Video video2 = new Video("2. rész", int.Parse(adatok[2]));

                reszek.Add(video1);
                reszek.Add(video2);

                Series sorozat = new Series(adatok[0], reszek);
                streaming.addContent(sorozat);

            }

        }


        private void Beolvasas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Leghosszabb_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}