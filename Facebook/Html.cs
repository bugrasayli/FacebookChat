using FaceBook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook
{
    class Html
    {
        private string html;
        private StreamWriter writer;
        private List<person> people;
        public Html(string html)
        {
            this.html = html;
            people = new List<person>();
        }
        public List<person> Parse()
        {
            string[] a = splitted(html);
            string b = " ";
            int count = a.Length;
            a[0] = "";
            a[count - 1] = "";

            for (int i = 0; i < count; i++)
            {
                b += a[i];
            }
            string[] x = splitDataId(b);
            string c = "";

            for (int i = 0; i < count - 2; i++)
            {
                c += x[i] + "\n";
            }
            string _b = "";
            foreach (var line in x)
            {
                _b = NoHtml(line);
                string[] xyz = new string[3];
                xyz = _b.Split('-');
                if (!_b.Equals(""))
                {
                    if (xyz[1].Equals("Active"))
                    {
                        people.Add(new person
                        {
                            ID = xyz[0],
                            Name = xyz[3] + " " + xyz[4],
                            Situation = xyz[1] + " " + xyz[2]
                        });
                    }
                    else
                    {
                        if (char.IsNumber(xyz[1][0]))
                        {
                            people.Add(new person
                            {
                                ID = xyz[0],
                                Name = xyz[2] + " " + xyz[3]
                            });
                        }
                        else
                        {
                            people.Add(new person
                            {
                                ID = xyz[0],
                                Name = xyz[1] + " " + xyz[2]
                            });

                        }
                        
                    }
                }
            }
            return people;
        }
        public string[] splitted(string html)
        {

            return html.Split(new String[] { "<li class=\"_42fz\"" }, StringSplitOptions.None);
        }
        public string[] splitDataId(string html)
        {

            return html.Split(new String[] { "data-id=\"" }, StringSplitOptions.None);
        }
        public string NoHtml(string html)
        {
            string noHTMLNormalised = Regex.Replace(html, @"<a.*?>", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"<i.*?>", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"<div.*?>", " ").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"</div>", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"</ul.*?>>", "").Trim();

            noHTMLNormalised = Regex.Replace(noHTMLNormalised, ">.*?=\"", " ").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"</i.*?ul>", "").Trim();

            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"</a>", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"</li>", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"st.*?>", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"MO.*?ul", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"</span>", "").Trim();

            noHTMLNormalised = Regex.Replace(noHTMLNormalised, "\"", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @">", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised, @"\s+", "-").Trim();
            return noHTMLNormalised;
        }

    }
}
