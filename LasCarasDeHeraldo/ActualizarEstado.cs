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
       /* private BindingList<Reclamo> listaReclamos = new BindingList<Reclamo>();
        private BindingList<Estado> listaEstados = new BindingList<Estado>();*/

        public ActualizarEstado()
        {
            InitializeComponent();
            this.InicializarListaReclamos();
            this.InicializarListaEstados();
            this.InicializarListaAreas();

        }

        private void InicializarListaAreas()
        {
            using (var context = new ReclamoEntities())
            {
                comboAreas.ValueMember = "Id";
                comboAreas.DisplayMember = "Nombre";
                comboAreas.DataSource = new BindingList<Area>(context.Areas.ToList<Area>());
            }
            
        }

        private void InicializarListaEstados()
        {
            using (var context = new ReclamoEntities())
            {
                try
                {
                    comboEstados.ValueMember = "Id";
                    comboEstados.DisplayMember = "Nombre";
                    comboEstados.DataSource = new BindingList<Estado>(context.Estados.ToList<Estado>()); ;
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
                    comboReclamos.ValueMember = "Id";
                    comboReclamos.DisplayMember = "Id";
                    comboReclamos.DataSource = new BindingList<Reclamo>(context.Reclamos.ToList<Reclamo>()); ;
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
            using (var context = new ReclamoEntities())
            {
                try
                {
                    comboReclamos.ValueMember = "Id";
                    comboReclamos.DisplayMember = "Id";
                    comboReclamos.DataSource = new BindingList<Reclamo>(context.Reclamos.ToList<Reclamo>()); ;

                    int lIdReclamo = ((Reclamo) this.comboReclamos.SelectedItem).Id;
                    int lIdEstado = ((Estado)this.comboEstados.SelectedItem).Id;
                    int lIdArea = 5;


                    Historico lHistorico = new Historico() { Comentario = this.richTextBox1.Text, FechaHora = DateTime.Now, Reclamo_Id = lIdReclamo, Estado_Id = lIdEstado, Area_Id = lIdArea };

                    context.Historicos.Add(lHistorico);
                    context.SaveChanges();

                    MessageBox.Show("Reclamo guardado correctamente", "Exito", MessageBoxButtons.OK);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion no manejada...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
            }
        }

        private void comboReclamo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboReclamoFormat(object sender, ListControlConvertEventArgs e)
        {
            int cod = ((Reclamo)e.ListItem).Id;
            string titulo = ((Reclamo)e.ListItem).Titulo;
            e.Value = cod.ToString("D4") + "-" + titulo;
        }

        private void comboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarReclamo_Leave(object sender, EventArgs e)
        {
            Historico lHistorico = ((Reclamo)this.comboReclamos.SelectedItem).Historicos.OrderByDescending(his => his.FechaHora).First();
            this.textEstadoActual.Text = lHistorico.Estado.Nombre;
            this.comboAreas.SelectedIndex = this.comboAreas.Items.IndexOf(lHistorico.Area);
        }
    }
}
