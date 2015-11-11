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

        private BindingList<Area> listaAreas = new BindingList<Area>();

        public AltaReclamo()
        {
            InitializeComponent();
            this.InicializarListaAreas();
        }

        private void InicializarListaAreas()
        {
            using (var context = new ReclamoEntities())
            {
                try
                {
                    this.listaAreas = new BindingList<Area>(context.Areas.ToList<Area>());
                    comboAreas.ValueMember = "Id";
                    comboAreas.DisplayMember = "Nombre";
                    comboAreas.DataSource = listaAreas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excepcion no manejada...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
            }
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
                    context.Usuarios.Attach(this.User);

                    int lCodArea = ((Area)this.comboAreas.SelectedItem).Id;
                    bool lPublico = this.checkBox1.Checked;
                    
                    List<Usuario> lLista = new List<Usuario>() { this.User };
                    Reclamo lReclamo = new Reclamo() { Titulo = textBox1.Text, Comentario = richTextBox1.Text, Usuario = this.User, UsuariosAdherentes=lLista, Publico = lPublico };
                    context.Reclamos.Add(lReclamo);
                    context.SaveChanges();

                    Estado lEstado = context.Estados.Where(es => es.Nombre == "Abierto").FirstOrDefault<Estado>();
                    Historico lHistorico = new Historico() { Comentario = "Apertura de Reclamo", FechaHora = DateTime.Now, Reclamo_Id = lReclamo.Id, Estado_Id = lEstado.Id, Area_Id= lCodArea };

                    context.Historicos.Add(lHistorico);
                    context.SaveChanges();

                    MessageBox.Show("Reclamo guardado correctamente","Exito",MessageBoxButtons.OK);
                    this.Close();

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

        private void comboAreas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
