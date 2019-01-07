using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Facebook;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace FaceBook
{
    public class Selenium
    {
        private person Person;
        private ChromeDriver driver;
        private ChromeOptions options;
        private FileOpp file;
        private string Url;
        public string HTML
        {
            get
            {
                return HTML = driver.PageSource;
            }
            private set { }
        }
        public Selenium(string Url, string email, string password)
        {
            options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            this.Url = Url;
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();

            Login(email, password);
        }
        public void Login(string Password, string EMail)
        {
            file = new FileOpp();
            List<person> people = new List<person>();

            var password = driver.FindElementById("pass");
            var email = driver.FindElementById("email");
            var login = driver.FindElementById("loginbutton");


            password.SendKeys("say_say0909");
            email.SendKeys("bugrasayli@gmail.com");
            login.Click();
            string asdf = driver.PageSource;
            System.Threading.Thread.Sleep(3000);

            //file.Write(@"C:\Users\cobhc\Onedrive\Masaüstü\FaceAnalysis\Facebook2.txt", asdf);
            string[] a = splitted(asdf);
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

            for (int i = 0; i < count - 1; i++)
            {
                c += x[i] + "\n";
            }
            string path = @"C:\Users\cobhc\Onedrive\Masaüstü\FaceAnalysis\Facebook2.txt";
            StreamWriter sw = new StreamWriter(path);
            string _b="";
            foreach (var line in x)
            {
                _b = NoHtml(line);
                sw.WriteLine(_b);
            }
            //file.Write(@"C:\Users\cobhc\Onedrive\Masaüstü\FaceAnalysis\Facebook2.txt", c);
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
            string noHTMLNormalised  = Regex.Replace(html, @"<a.*?>", "").Trim();
            noHTMLNormalised = Regex.Replace(noHTMLNormalised,@"<i.?>","").Trim();
            return noHTMLNormalised;
        }
    }
    public class person
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Situation { get; set; }

    }
}
