﻿using System;
using System.IO;
using System.Text;

namespace Calendar
{
    public class IOStream:IDisposable
    {
        Stream  streamObj;
   
        public IOStream(Stream stream)
        {
            streamObj = stream;
        }

        public IOStream()
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

        public IOStream(Events list)
        {
            string stringContent = list.ToOneString();
            streamObj = StringToStream(stringContent);
        }

        public void ExportEventsInHTMLStream(Events eventsList)
        {
            string beginTags = "<!DOCTYPE html>\n<html>\n<head>\n<title>Events List</title>\n</head>\n<body>";
            string endTags = "\n</body>\n</html>";
            using (StreamWriter w = new StreamWriter(streamObj, Encoding.UTF8))
            {
                w.Write(beginTags);
                foreach (Event ev in eventsList)
                {
                    string htmlData = "";
                    htmlData += "<p><b>Date:</b> " + ev.Date.ToString("yyyy/MM/dd") + "</p>\n";
                    htmlData += "<p><b>Title:</b> " + Utils.DecodingNewLineCharForHTML(Utils.DecodingNewLineChar(ev.Title)) + "</p>";
                    htmlData += "<p><b>Description:</b> " + Utils.DecodingNewLineCharForHTML(Utils.DecodingNewLineChar(ev.Description)) + "</p>";
                    htmlData += "<hr>";
                    w.Write(htmlData);
                }
                w.Write(endTags);
              }
        }

        static Stream StringToStream(string src)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(src);
            return new MemoryStream(byteArray);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (streamObj != null) streamObj.Dispose();
            }
        }
    }
    }
