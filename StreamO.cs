using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class StreamO
    {
        private Stream streamObj;

        public StreamO(Stream stream)
        {
            streamObj = stream;
        }

        public StreamO()
        {
            streamObj = new MemoryStream();
        }

        public string[] GetLinesFromStream()
        {
            streamObj.Position = 0;
            StreamReader reader = new StreamReader(streamObj);
            string[] result = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        public StreamO(Events list)
        {
            string stringContent = list.ToOneString();
            streamObj= StringToStream(stringContent);
        }

         static Stream StringToStream(string src)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(src);
            return new MemoryStream(byteArray);
        }
    }

}
