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
    public partial class ActualizarEstado : Form
    {
        private BindingList<Reclamo> listaReclamos = new BindingList<Reclamo>();
        private BindingList<Estado> listaEstados = new BindingList<Estado>();

        public ActualizarEstado()
        {
            InitializeComponent();
            this.InicializarListaReclamos();
            this.InicializarListaEstados();

        }

        private void InicializarListaEstados()
        {
            using (var context = new ReclamoEntities())
            {
                try
                {
                    this.listaEstados = new BindingList<Estado>(context.Estados.ToList<Estado>());
                    comboEstado.ValueMember = "Id";
                    comboEstado.DisplayMember = "Nombre";
                    comboEstado.DataSource = listaEstados;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion no manejada...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
            }
        }

        private void InicializarListaReclamos()
        {
            using (var context = new ReclamoEntities())
            {
                try
                {
                    this.listaReclamos = new BindingList<Reclamo>(context.Reclamos.ToList<Reclamo>());
                    comboEstado.ValueMember = "Id";
                    comboEstado.DisplayMember = "Id";
                    comboEstado.DataSource = listaReclamos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion no manejada...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
