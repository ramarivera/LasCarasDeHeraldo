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
    public partial class Principal : Form
    {
        public Usuario User { get; internal set; }
        public Principal()
        {
            InitializeComponent();
            Shown += Principal_Shown;
        }

        private void Principal_Shown(object sender, EventArgs e)
        {
            this.ConfigurarControles();
        }

        private void ConfigurarControles()
        {
            if (this.User.TipoUsuario.Nombre == "User" || this.User.TipoUsuario.Nombre == "Anon")
            {
                gestionToolStripMenuItem.Visible = false;
                buscarToolStripMenuItem.Visible = false; 
            }
        }

        private void darDeAltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lAlta = new AltaReclamo();
            lAlta.User = this.User; 
            lAlta.ShowDialog();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Salir();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lCons = new ConsultaReclamo();
            lCons.User = this.User;
            lCons.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Salir()
        {
            DialogResult lResult = MessageBox.Show("Desea salir del sistema?", "Salir", MessageBoxButtons.YesNo);
            if (lResult == DialogResult.Yes)
            {
                this.Close();
            }

        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Salir();   
        }

        private void actualizarEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lAct = new ActualizarEstado();
            lAct.ShowDialog();
        }
    }
}
