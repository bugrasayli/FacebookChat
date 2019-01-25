using FaceBook;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Facebook
{
    public partial class Form1 : Form
    {
        private string email;
        private string password;
        private List<person> people;
        private Database db;
        Selenium selenium;
        public Form1()
        {
            InitializeComponent();
            password_txt.PasswordChar = '$';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Connect();
        }
        private void Connect()
        {
            email = email_txt.Text;
            password = password_txt.Text;
            if (NullControl(email, password))
            {

                selenium = new Selenium("http://facebook.com");

                people = selenium.Login(email_txt.Text, password_txt.Text);
                db = new Database();
                threading();
            }
        }
        public void threading()
        {
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(5000);
                selenium.driver.Navigate().Refresh();
                Html obje = new Html(selenium.driver.PageSource);
                List<person> people = new List<person>();
                people = obje.Parse();
                foreach (var person in people)
                {
                    db.insertTime(person);
                }
            }
        }






        private void email_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Connect();
            }
        }
        private void password_txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Connect();
            }
        }
        private bool NullControl(string email, string pass)
        {
            if (email.Equals("") || pass.Equals(""))
            {
                MessageBox.Show("please fill");
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
