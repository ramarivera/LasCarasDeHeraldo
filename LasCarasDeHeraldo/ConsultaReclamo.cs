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
    public partial class ConsultaReclamo : Form
    {

        public Usuario User { get; internal set; }


        public ConsultaReclamo()
        {
            InitializeComponent();
            Shown += ConsultaReclamo_Shown;
        }

        private void ConsultaReclamo_Load(object sender, EventArgs e)
        {

        }

        private void CambiarTamaño(int width, int height)
        {
            this.Size = new Size(width, height);
            this.MaximumSize = new Size(width, height);
            this.MinimumSize = new Size(width, height);
            this.CenterToScreen();
        }

        private void ConsultaReclamo_Shown(object sender, EventArgs e)
        {
            this.CambiarTamaño(514, 404);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ActivarComentario()
        {
            this.CambiarTamaño(514, 608);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int lCod = 0;
            if (!int.TryParse(this.textBusqueda.Text, out lCod))
            {
                MessageBox.Show("Introduzca un codigo numerico", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                using (var context = new ReclamoEntities())
                {
                    try
                    {
                        var lResultado = from rec in context.Reclamos
                                         where (rec.UsuariosAdherentes.Contains(this.User)
                                                || rec.Usuario == this.User) && rec.Id == lCod
                                         select rec;

                        Reclamo lReclamo = lResultado.FirstOrDefault<Reclamo>();

                        if (lReclamo != null)
                        {
                            List<Historico> lHistoricos = lReclamo.Historicos.ToList<Historico>();
                            lHistoricos.Sort((x, y) => y.CompareTo(x));
                            Historico lUltimoHistorico = lHistoricos.FirstOrDefault<Historico>();

                            if (lUltimoHistorico != null && lUltimoHistorico.Estado.Nombre == "Terminado")
                            {
                                this.ActivarComentario();
                            }

                            var bindingList = new BindingList<Historico>(lHistoricos);
                            var source = new BindingSource(bindingList, null);
                            dataGridView1.DataSource = source;

                            // lHistoricos.
                        }
                        else
                        {
                            MessageBox.Show("Usd no posee reclamos con ese codigo ni se halla adherido a reclamos con ese codigo", "Sin Registros", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Excepcion no manejada...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw ex;
                    }

                }
            }
        }
    }
}
