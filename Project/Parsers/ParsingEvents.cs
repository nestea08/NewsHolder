using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using BD;

namespace Parsers
{
    public class ParsingEvents
    {
        private static DataBase db=new DataBase();
        private const string url = "https://it-events.com/";
        public static string ParseMain()
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
        public static string ParseEvent(string item)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url+item);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string html;
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                html = sr.ReadToEnd();
            }
            string path = @"C:\Users\Asus\Documents\GitHub\News_holder\Project\site2.txt";
            File.Create(path).Dispose();
            using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
            {
                sw.WriteLine(html);
            }
            return html;
        }
        public static void FindNews()
        {
            string name="", description="",link="";
            string text = ParseMain();
            string pattern = @"<a class='event-list-item__title' href='\S*'>";
            MatchCollection matches = Regex.Matches(text, pattern);
            List<string> list = new List<string>();
            MatchCollection event_matches;
            foreach (Match m in matches)
            {
                description = "";
                string str = m.Value.Remove(0, 40);
                str = str.Remove(str.IndexOf("'"), 2);
                text = ParseEvent(str);
                link = str;
                pattern = "<title>.*/";
                event_matches = Regex.Matches(text, pattern);
                foreach (Match match in event_matches)
                {
                    str = match.Value.Remove(0, 7);
                    string[] mas = str.Split('/');
                    name = mas[0];
                }
                pattern = "style=\"text-align:justify\">.*<";
                
                event_matches = Regex.Matches(text, pattern);
                foreach (Match match in event_matches)
                {
                    str = match.Value.Replace("nbsp;", " ").Replace("strong","").Replace("quot;","\'").Replace("laquo;","\'").Replace("raquo;","\'").
                        Replace("<a href", "(").Replace(" target=\"_blank\"", ") ").Replace("thinsp;","").Replace("mdash;","-").Replace("ldquo;","\'").
                        Replace("rdquo;","\'");
                   
                    str = str.Remove(str.Length - 1);
                    str=str.Remove(0, 27);
                    pattern = "[A-Za-zА-Яа-я 0-9().,;:?!|-]{1}";
                    foreach (char symbol in str)
                    {
                        if (Regex.IsMatch(new string(new char[] { symbol }), pattern))
                        {
                            description += symbol;
                        }
                    }
                    description += "\n";
                    

                }
                Console.WriteLine(description);
                try
                {
                    db.AddNews(new News(name, description, link));
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
        }
    }
}
