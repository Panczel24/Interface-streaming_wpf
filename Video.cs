using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_streaming
{
    internal class Video
    {
        string title;
        int length;

        public Video(string title, int length)
        {
            this.title = title;
            this.length = length;
        }
        public string getTitle()
        {
            return title;
        }

        public int getLength()
        {
            return length;
        }
    }
}
