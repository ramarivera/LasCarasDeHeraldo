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
    public partial class ListarReclamos : Form
    {
        private List<Reclamo> iListaReclamos;

        public Usuario User { get;  set; }

        public ListarReclamos()
        {
            InitializeComponent();
            InicializarListaReclamos();
            InicializarLinkLabels();
        }

        private void InicializarListaReclamos()
        {
            this.iListaReclamos = new List<Reclamo>();
            using (var context = new ReclamoEntities())
            {
                this.iListaReclamos = context.Reclamos.ToList<Reclamo>();
            }
        }

        private void InicializarLinkLabels()
        {
            int i = 0;
            this.tableLayoutPanel1.RowCount = iListaReclamos.Count;
            foreach (var rec in iListaReclamos)
            {
                this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

                Button lButton = new Button();
                lButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((   System.Windows.Forms.AnchorStyles.Top |
                                                                                System.Windows.Forms.AnchorStyles.Left) | 
                                                                                System.Windows.Forms.AnchorStyles.Right)));
                lButton.Name = "button" + i.ToString() ;
                lButton.Size = new System.Drawing.Size(188, 23);
                lButton.TabIndex = i;
                lButton.Tag = rec;
                lButton.Text = "Reclamo "+i.ToString()+": "+rec.Titulo;
                lButton.UseVisualStyleBackColor = true;
                lButton.Click += LButton_Click;
                lButton.Dock = DockStyle.Fill;

                this.tableLayoutPanel1.Controls.Add(lButton,1,i);
                i++;
            }
            this.Text = string.Format("Se encontraron {0} Reclamos" ,i.ToString());
        }

        private void LButton_Click(object sender, EventArgs e)
        {
            Button send = sender as Button;
            ConsultaReclamo cons = new ConsultaReclamo();
            cons.User = this.User;
            cons.Controls["textBusqueda"].Text = ((Reclamo) send.Tag).Id.ToString();
            ((Button)cons.Controls["buttonBuscar"]).PerformClick();
            cons.Shown += (s, args) => ((Button)cons.Controls["buttonBuscar"]).PerformClick(); 
            cons.ShowDialog();

        }

        private void pnlFlow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
