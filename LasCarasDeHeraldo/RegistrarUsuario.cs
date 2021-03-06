﻿using System;
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

        public bool AdminMode { get; internal set; }
        public bool AnonMode { get; internal set; }

        public RegistrarUsuario()
        {
            InitializeComponent();
            Shown += RegistrarUsuario_Shown;

            using (var context = new ReclamoEntities())
            {
                try
                {
                    this.listaTipos = new BindingList<TipoUsuario>(context.TipoUsuarios.OrderBy(tip => tip.Nombre).ToList<TipoUsuario>());
                    comboBox1.ValueMember = "Id";
                    comboBox1.DisplayMember = "Nombre";
                    comboBox1.DataSource = listaTipos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Autenticacion Invalida, vuelvalo a intentar", "Error de Autenticacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw ex;
                }
            }

        }

        private void RegistrarUsuario_Shown(object sender, EventArgs e)
        {
            if (!AdminMode)
            {
                this.label5.Hide();
                this.comboBox1.Hide();
                this.comboBox1.SelectedIndex = 2;
            }
            if (AnonMode)
            {
                this.label5.Hide();
                this.comboBox1.Hide();
                this.comboBox1.SelectedIndex = 1;
                this.label1.Hide();
                this.label2.Hide();
                this.textBox1.Hide();
                this.textBox2.Hide();
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
            using (var context = new ReclamoEntities())
            {
                try
                {
                    string lNombre = textBox1.Text;
                    string lNombreUsuario = textBox4.Text;
                    string lContraseña = textBox3.Text;
                    string lCorreo = textBox2.Text;

                    var lRes = context.Usuarios.Where(us => us.NombreUsuario == lNombreUsuario).FirstOrDefault<Usuario>();

                    if (lRes == null)
                    {
                        Usuario lUsuario = new Usuario() { Nombre = lNombre, Email = lCorreo, NombreUsuario = lNombreUsuario, Contraseña = lContraseña };

                        int lIdTipo = ((TipoUsuario)comboBox1.SelectedItem).Id;

                        lUsuario.TipoUser_Id = lIdTipo;

                        context.Usuarios.Add(lUsuario);
                        context.SaveChanges();
                        MessageBox.Show("Usuario generado con exito", "Exito", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el usuario porque ya existe con ese nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Excepcion no manejada...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
