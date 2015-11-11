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
        public bool AdminMode { get; internal set; }

        public RegistrarUsuario()
        {
            InitializeComponent();
            if (!AdminMode)
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
                            this.comboBox1.Items.Add(tipo);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Excepcion no manejada...");
                        throw ex;
                        //ex.InnerException
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

        }
    }
}
