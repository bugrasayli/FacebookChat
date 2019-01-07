using FaceBook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facebook
{
    public partial class Authanticated : Form
    {
        List<person> people;
        public Authanticated()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        public void getList(List<person> people)
        {
            this.people = people;
            person.DataSource = people;
        }

        private void Authanticated_Load(object sender, EventArgs e)
        {
        }
    }
}
