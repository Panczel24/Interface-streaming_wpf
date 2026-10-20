using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_streaming
{
    internal class Movie : IContent
    {
        private Video video;

        public Movie(Video video)
        {
            this.video = video;
        }

        public int getLength()
        {
            return video.getLength();
        }

        public string getTitle()
        {
            return video.getTitle();
        }
    }
}
