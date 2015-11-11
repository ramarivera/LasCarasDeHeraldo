namespace LasCarasDeHeraldo
{
    partial class ActualizarEstado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActualizarEstado));
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboEstados = new System.Windows.Forms.ComboBox();
            this.comboReclamos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textEstadoActual = new System.Windows.Forms.TextBox();
            this.comboAreas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(137, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 206);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(342, 121);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nuevo Estado:";
            // 
            // comboEstados
            // 
            this.comboEstados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEstados.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboEstados.FormattingEnabled = true;
            this.comboEstados.Location = new System.Drawing.Point(137, 107);
            this.comboEstados.Name = "comboEstados";
            this.comboEstados.Size = new System.Drawing.Size(156, 24);
            this.comboEstados.TabIndex = 3;
            this.comboEstados.SelectedIndexChanged += new System.EventHandler(this.comboEstado_SelectedIndexChanged);
            // 
            // comboReclamos
            // 
            this.comboReclamos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboReclamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboReclamos.FormattingEnabled = true;
            this.comboReclamos.Location = new System.Drawing.Point(137, 26);
            this.comboReclamos.Name = "comboReclamos";
            this.comboReclamos.Size = new System.Drawing.Size(227, 24);
            this.comboReclamos.TabIndex = 4;
            this.comboReclamos.SelectedIndexChanged += new System.EventHandler(this.comboReclamo_SelectedIndexChanged);
            this.comboReclamos.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboReclamoFormat);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(64, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reclamo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Comentario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Estado Actual:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // textEstadoActual
            // 
            this.textEstadoActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textEstadoActual.Location = new System.Drawing.Point(137, 67);
            this.textEstadoActual.Name = "textEstadoActual";
            this.textEstadoActual.Size = new System.Drawing.Size(156, 23);
            this.textEstadoActual.TabIndex = 8;
            // 
            // comboAreas
            // 
            this.comboAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAreas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboAreas.FormattingEnabled = true;
            this.comboAreas.Location = new System.Drawing.Point(137, 154);
            this.comboAreas.Name = "comboAreas";
            this.comboAreas.Size = new System.Drawing.Size(156, 24);
            this.comboAreas.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(89, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Area:";
            // 
            // ActualizarEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 371);
            this.Controls.Add(this.comboAreas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textEstadoActual);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboReclamos);
            this.Controls.Add(this.comboEstados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(392, 410);
            this.MinimumSize = new System.Drawing.Size(392, 410);
            this.Name = "ActualizarEstado";
            this.Text = "Actualizar Estado de Reclamo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboEstados;
        private System.Windows.Forms.ComboBox comboReclamos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textEstadoActual;
        private System.Windows.Forms.ComboBox comboAreas;
        private System.Windows.Forms.Label label5;
    }
}