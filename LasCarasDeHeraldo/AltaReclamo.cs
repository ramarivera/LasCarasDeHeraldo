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
    public partial class AltaReclamo : Form
    {
        public Usuario User { get; internal set; }

        public AltaReclamo()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           using (var context = new ReclamoEntities())
            {
                try
                {
                    List<Usuario> lLista = new List<Usuario>() { this.User };
                    Reclamo lReclamo = new Reclamo() { Titulo = textBox1.Text, Comentario = richTextBox1.Text, Usuario = this.User, UsuariosAdherentes=lLista };
                    context.Reclamos.Add(lReclamo);
                    context.SaveChanges();
                    MessageBox.Show("Reclamo guardado correctamente","Exito",MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion no manejada...","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    throw ex;
                }
                
            }
        }

        private void AltaReclamo_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
