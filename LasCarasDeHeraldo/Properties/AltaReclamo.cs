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
        public AltaReclamo()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           using (var context = new ReclamosEntities())
            {

                UsuarioSet usuario = context.UsuarioSets.ToList<UsuarioSet>().Where(u => u.Id == this.User).FirstOrDefault<UsuarioSet>();

                //var lista = context.ReclamoSets.ToList<ReclamoSet>();
                context.ReclamoSets.Add(new ReclamoSet() { Titulo = textBox1.Text, Comentario = richTextBox1.Text, UsuarioSet = usuario, UsuarioSets = new List<UsuarioSet>() { usuario } });

                /* //Perform create operation
                // context.Students.Add(new Student() { StudentName = "New Student" });

                 //Perform Update operation
                 Student studentToUpdate = studentList.Where(s => s.StudentName == "student1").FirstOrDefault<Student>();
                 studentToUpdate.StudentName = "Edited student1";

                 //Perform delete operation
                 context.Students.Remove(studentList.ElementAt<Student>(0));

                 //Execute Inser, Update & Delete queries in the database*/
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ENTITY FRAMEWORK Y LA CONCHA DE TU MADREEEEEEEE (NIIIIIILL)");
                    throw ex;
                   //ex.InnerException
                }
                
            }
        }
    }
}
