using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace Parsers
{
    public class ParsingEvents
    {
        string url = "https://it-events.com/";
        public string ParseMain()
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string html;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                html = sr.ReadToEnd();
            }
            string path = @"C:\Users\Asus\Documents\GitHub\News_holder\Project\site1.txt";
            File.Create(path).Dispose();
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {
                sw.WriteLine(html);
            }
            return html;



        }
        public string ParseEvent(string item)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string html;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                html = sr.ReadToEnd();
            }
            string path = @"C:\Users\Asus\Documents\GitHub\News_holder\Project\site1.txt";
            File.Create(path).Dispose();
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {
                sw.WriteLine(html);
            }
            return html;
        }
        public void FindNews()
        {
            string text = ParseMain();
            string pattern = @"<a class='event-list-item__title' href='\S*'>";
            MatchCollection matches = Regex.Matches(text, pattern);
            List<string> list = new List<string>();
            foreach (Match m in matches)
            {
                string str = m.Value.Remove(0, 40);
                str = str.Remove(str.IndexOf("'"), 2);
                text = ParseEvent(str);

            }

        }
    }
}
