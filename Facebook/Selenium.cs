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
        private ChromeDriver driver;
        private ChromeOptions options;
        private FileOpp file;
        private Html html;
        private string Url;
        List<person> people;
        public string HTML
        {
            get
            {
                return HTML = driver.PageSource;
            }
            private set { }
        }
        public Selenium(string Url)
        {
            options = new ChromeOptions();
            options.AddArguments("--disable-notifications");
            this.Url = Url;
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
        }
        public List<person> Login(string Password, string EMail)
        {
            var password = driver.FindElementById("pass");
            var email = driver.FindElementById("email");
            var login = driver.FindElementById("loginbutton");


            password.SendKeys("say_say0909");
            email.SendKeys("bugrasayli@gmail.com");
            login.Click();
            System.Threading.Thread.Sleep(3000);

            string asdf = driver.PageSource;
            html = new Html(asdf);
            people =html.Parse();
            driver.Close();
            driver.Dispose();
            return people;
        }
        public List<person> Login()
        {
            return this.people;
        }
    }
    
}
