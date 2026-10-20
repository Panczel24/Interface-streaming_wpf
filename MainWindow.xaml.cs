using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Interface_streaming
{
    public partial class MainWindow : Window
    {
        private StreamingPlatform streaming = new StreamingPlatform();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FilmekBeolvasasa_Click(object sender, RoutedEventArgs e)
        {
            FilmekBeolvasasa();
        }

        private void SorozatokBeolvasasa_Click(object sender, RoutedEventArgs e)
        {
            SorozatokBeolvasasa();
        }

        private void FilmekBeolvasasa()
        {
            string[] filmek = File.ReadAllLines("catalog.txt");

            for (int i = streaming.contents.Count - 1; i >= 0; i--)
            {
                if (streaming.contents[i] is Movie)
                {
                    streaming.contents.RemoveAt(i);
                }
            }

            foreach (string sor in filmek)
            {
                string[] adatok = sor.Split(';');

                Video video = new Video(adatok[0], int.Parse(adatok[1]));
                Movie film = new Movie(video);

                streaming.addContent(film);
            }

            ListaFrissitese();
            eredmenyTextBlock.Text = "Filmek beolvasva!";
        }

        private void SorozatokBeolvasasa()
        {
            string[] sorozatok = File.ReadAllLines("series.txt");

            for (int i = streaming.contents.Count - 1; i >= 0; i--)
            {
                if (streaming.contents[i] is Series)
                {
                    streaming.contents.RemoveAt(i);
                }
            }

            foreach (string sor in sorozatok)
            {
                string[] adatok = sor.Split(';');

                Video video1 = new Video("1. rész", int.Parse(adatok[1]));
                Video video2 = new Video("2. rész", int.Parse(adatok[2]));

                List<Video> reszek = new List<Video>();
                reszek.Add(video1);
                reszek.Add(video2);

                Series sorozat = new Series(adatok[0], reszek);
                streaming.addContent(sorozat);
            }

            ListaFrissitese();
            eredmenyTextBlock.Text = "Sorozatok beolvasva!";
        }

        private void ListaFrissitese()
        {
            tartalomLista.Items.Clear();

            foreach (IContent content in streaming.contents)
            {
                TartalomSor sor = new TartalomSor();

                sor.Cim = content.getTitle();
                sor.Hossz = content.getLength() + " perc";

                tartalomLista.Items.Add(sor);
            }
        }

        private void Leghosszabb_Click(object sender, RoutedEventArgs e)
        {
            IContent leghosszabb = streaming.Leghosszabb();

            if (leghosszabb != null)
            {
                eredmenyTextBlock.Text = "Leghosszabb tartalom: "
                    + leghosszabb.getTitle() + " ("
                    + leghosszabb.getLength() + " perc)";
            }
            else
            {
                eredmenyTextBlock.Text = "Nincs beolvasott tartalom!";
            }
        }
    }

    internal class TartalomSor
    {
        public string Cim { get; set; }
        public string Hossz { get; set; }
    }
}