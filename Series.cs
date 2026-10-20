using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_streaming
{
    internal class Series : IContent
    {
        private string title;
        private List<Video> videoList;

        public Series(string title, List<Video> videoList)
        {
            this.title = title;
            this.videoList = videoList;
        }

        public int getLength()
        {
            int hossz = 0;
            foreach (Video video in videoList)
            {
                hossz += video.getLength();
            }
            return hossz;
        }

        public string getTitle()
        {
            return title;
        }
    }
}
