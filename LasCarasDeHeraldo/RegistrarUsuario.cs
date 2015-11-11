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
        private readonly BindingList<TipoUsuario> listaTipos = new BindingList<TipoUsuario>();

        public RegistrarUsuario()
        {
            InitializeComponent();
            using (var context = new ReclamoEntities())
            {
                try
                {
                    this.listaTipos = new BindingList<TipoUsuario>(context.TipoUsuarios.ToList<TipoUsuario>());
                    comboBox1.ValueMember = "Id";
                    comboBox1.DisplayMember = "Nombre";
                    comboBox1.DataSource = listaTipos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion no manejada...");
                    throw ex;
                }
            }
            
        }

        public void ModoAdmin (bool modo = false)
        {
            if (!modo)
            {
                this.label5.Hide();
                this.comboBox1.Hide();
                this.comboBox1.SelectedIndex = 1;
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
          //  MessageBox.Show(this.textBox1.Text == String.Empty ? "Empty" : "Otra Cosa :(");
            using (var context = new ReclamoEntities())
            {
                try
                {
                    string lNombre = textBox1.Text;
                    string lNombreUsuario = textBox4.Text;
                    string lContraseña = textBox3.Text;
                    string lCorreo = textBox2.Text;

                    Usuario lUsuario = new Usuario() { Nombre = lNombre, Email = lCorreo, NombreUsuario = lNombreUsuario, Contraseña = lContraseña };

                    int lIdTipo = ((TipoUsuario)comboBox1.SelectedItem).Id;

                    lUsuario.TipoUser_Id = lIdTipo;

                    context.Usuarios.Add(lUsuario);
                    context.SaveChanges();
                    MessageBox.Show("Usuario generado con exito", "Exito", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Excepcion no manejada...");
                    throw ex;
                }
                finally
                {
                    this.Close();
                }

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RegistrarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
