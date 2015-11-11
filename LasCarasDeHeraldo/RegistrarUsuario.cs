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
    public partial class RegistrarUsuario : Form
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
            
        }

        public void ModoAdmin (bool modo = false)
        {
            if (!modo)
            {
                this.label5.Hide();
                this.comboBox1.Hide();
            }
            else
            {
                using (var context = new ReclamoEntities())
                {
                    try
                    {
                        List<TipoUsuario> lLista = context.TipoUsuarios.ToList<TipoUsuario>();
                        foreach (var tipo in lLista)
                        {
                            this.comboBox1.Items.Add(tipo.Nombre);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Excepcion no manejada...");
                        throw ex;
                    }

                }
            }
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Usuario usuario = context.Usuarios.ToList<Usuario>().Where(u => u.Id == this.User).FirstOrDefault<Usuario>();
            List<Usuario> lLista = new List<Usuario>() { usuario };
            Reclamo lReclamo = new Reclamo() { Titulo = textBox1.Text, Comentario = richTextBox1.Text, Usuario = usuario, Usuarios = lLista };
            context.Reclamos.Add(lReclamo);
            context.SaveChanges();
            MessageBox.Show("Reclamo guardado correctamente", "Exito", MessageBoxButtons.OK);



    */

            using (var context = new ReclamoEntities())
            {
                try
                {
                    Usuario lUsuario = new Usuario() { Nombre = textBox1.Text, Email = textBox2.Text, };
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion no manejada...");
                    throw ex;
                }

            }
        }
    }
}
