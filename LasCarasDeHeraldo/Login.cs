using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LasCarasDeHeraldo
{
    public partial class Login : Form
    {
        public Usuario UsuarioEncontrado { get; set; }
        public List<Usuario> ListaUsuarios { get; set; }


        public Login()
        {
            InitializeComponent();
            this.button1.Enabled = false;
            this.AcceptButton = this.button1;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            this.progressBar1.SetState(3);
            this.Cursor = Cursors.WaitCursor;
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.RunWorkerAsync();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistrarUsuario lReg = new RegistrarUsuario();
            lReg.AnonMode = true;
            this.Hide();
            lReg.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.progressBar1.Value = 100;
            using (var context = new ReclamoEntities())
            {
                try
                {
                    String lUsuarioIngresado = this.textBox2.Text;
                    String lContraseña = this.textBox1.Text;



                    Usuario lUsuario = this.ListaUsuarios.Where(us => us.NombreUsuario == lUsuarioIngresado).FirstOrDefault<Usuario>();

                    if (lUsuario != null && lUsuario.Contraseña == lContraseña)
                    {
                        this.Hide();
                        var lPrin = new Principal();
                        lPrin.User = lUsuario;
                        lPrin.Closed += (s, args) => this.Close();
                        lPrin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Autenticacion Invalida, vuelvalo a intentar", "Error de Autenticacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Excepcion no manejada...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarUsuario lReg = new RegistrarUsuario();
            lReg.AdminMode = true;
            this.Hide();
            lReg.ShowDialog();
            this.Show();
        }


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var context = new ReclamoEntities())
            {
                var backgroundWorker = sender as BackgroundWorker;
                
                for (int i = 1; i <= 100; i++)
                {
                    Thread.Sleep(1);
                    if (i == 21)
                    {
                        this.ListaUsuarios = context.Usuarios.Include("TipoUsuario").ToList<Usuario>();
                    }
                    Thread.Sleep(1);
                    backgroundWorker.ReportProgress(i);
                }
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.button1.Enabled = true;
            this.Cursor = Cursors.Default;
            this.estadoLabel.Text = "conectado";
            this.estadoLabel.ForeColor = Color.Green;
            this.progressBar1.ForeColor = Color.Green;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
        }
    }
}
