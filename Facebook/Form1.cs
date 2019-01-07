using FaceBook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook
{
    public partial class Form1 : Form
    {
        private string email;
        private string password;
        private List<person> people;
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
                people = selenium.Login(email_txt.Text,password_txt.Text);
                
                Authanticated obje = new Authanticated();
                
                Thread thread = new Thread(()=>obje.getList(people));
                Thread thread2 = new Thread(() => obje.ShowDialog());
                thread.Start();
                thread2.Start();

                this.Close();
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
