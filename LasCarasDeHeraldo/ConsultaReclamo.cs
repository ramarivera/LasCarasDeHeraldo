using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            this.AcceptButton = this.buttonBuscar;
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
            comboConformidad.DataSource = Enumerable.Range(1, 10).ToList().ToBindingList();
        }


        private void ConfigurarDataGrid()
        {
            dataGridView1.RowHeadersVisible = false;
            DataGridViewColumnCollection columnas = dataGridView1.Columns;
            columnas["Fecha"].Width = 121;
            columnas["Estado"].Width = 53;
            columnas["Area"].Width = 73;
            columnas["Comentario"].Width = 203;

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
                                         from usr in rec.UsuariosAdherentes
                                         where rec.Id == lCod && (usr.Id == this.User.Id || this.User.TipoUsuario.Nombre=="Admin")
                                         select rec;


                        Reclamo lReclamo = lResultado.FirstOrDefault<Reclamo>();

                        if (lReclamo != null)
                        {
                            this.textTitulo.Text = lReclamo.Titulo;
                            this.textCodigo.Text = lReclamo.Id.ToString("D4");
                            this.textUsuario.Text = lReclamo.Usuario.Nombre;
                            List<Historico> lHistoricos = lReclamo.Historicos.ToList<Historico>();
                            lHistoricos.Sort((x, y) => DateTime.Compare(y.FechaHora,x.FechaHora));
                            Historico lUltimoHistorico = lHistoricos.FirstOrDefault<Historico>();

                            if (lUltimoHistorico != null && lUltimoHistorico.Estado.Nombre == "Terminado")
                            {
                                string lCadena = "Su reclamo se encuentra en estado Terminado. Nos ayudaria mucho a mejorar" +
                                    "si nos comentara como considero la gestion del reclamo. Desea hacerlo?";
                                DialogResult lDiag = MessageBox.Show(lCadena, "Reclamo Terminado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (lDiag==DialogResult.Yes)
                                {
                                    this.ActivarComentario();
                                }
                            }
                            var listaAnonima = lHistoricos.Select(his => new
                                {Fecha = his.FechaHora, Estado = his.Estado.Nombre, Area = his.Area.Nombre, Comentario = his.Comentario }).ToList().ToBindingList();

                            //var bindingList = new BindingList<Object>(listaAnonima);
                            //  var source = new BindingSource(bindingList, null);
                            dataGridView1.DataSource = listaAnonima;
                            ConfigurarDataGrid();


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

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
           // Debugger.Break();
        }
    }
}
