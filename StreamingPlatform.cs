using System;
using System.Collections.Generic;
using System.Text;

namespace Interface_streaming
{
    internal class StreamingPlatform
    {
        public List<IContent> contents = new List<IContent>();

        public void addContent(IContent content)
        {
            contents.Add(content);
        }

        public IContent Leghosszabb()
        {
            IContent leghosszabb = contents[0];
            foreach (IContent content in contents)
            {
                if (content.getLength() > leghosszabb.getLength())
                {
                    leghosszabb = content;
                }
            }
            return leghosszabb;
        }
    }
}
