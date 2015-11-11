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
            this.AcceptButton = this.button1;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var context = new ReclamoEntities())
            {
                try
                {
                    String lUsuarioIngresado = this.textBox2.Text;
                    String lContraseña = this.textBox1.Text;

                    Usuario lUsuario = context.Usuarios.Where(us => us.NombreUsuario == lUsuarioIngresado).FirstOrDefault<Usuario>();

                    if (lUsuario != null && lUsuario.Contraseña == lContraseña)
                    {
                        this.Hide();
                        var lPrin = new Principal();
                        lPrin.User = lUsuario;
                        lPrin.Closed += (s, args) => this.Close();
                        lPrin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Autenticacion Invalida, vuelvalo a intentar", "Error de Autenticacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex )
                {

                    MessageBox.Show("5 manejada...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
                
                
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarUsuario lReg = new RegistrarUsuario();
            lReg.AdminMode = true;
            this.Hide();
            lReg.ShowDialog();
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
