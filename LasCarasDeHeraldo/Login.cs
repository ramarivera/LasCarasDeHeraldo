using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LasCarasDeHeraldo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            var lPrin = new Principal();
            lPrin.User = ((this.textBox1.Text == String.Empty) ? 2 : int.Parse(this.textBox1.Text));
            lPrin.Closed += (s, args) => this.Close();
            lPrin.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
