using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace FaceBook
{
    public class Selenium
    {
        private ChromeDriver driver;
        private ChromeOptions options;
        private string Url;
        public string HTML
        {
            get
            {
                return HTML = driver.PageSource;
            }
            private set { }
        }
        public Selenium(string Url,string email,string password)
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

            var password = driver.FindElementById("pass");
            var email = driver.FindElementById("email");
            var login = driver.FindElementById("loginbutton");


            email.SendKeys(Password);
            password.SendKeys(EMail);
            login.Click();
        }
    }
}
