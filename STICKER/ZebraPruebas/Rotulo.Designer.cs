namespace ZebraPruebas
{
    partial class Rotulo
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxContacto = new System.Windows.Forms.ComboBox();
            this.txtCantidadImpr = new System.Windows.Forms.NumericUpDown();
            this.Impresoras = new System.Windows.Forms.ComboBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtDocumento = new System.Windows.Forms.TextBox();
            this.CbBaseD = new System.Windows.Forms.ComboBox();
            this.TxtTransaccion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadImpr)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.cbxContacto);
            this.groupBox2.Controls.Add(this.txtCantidadImpr);
            this.groupBox2.Controls.Add(this.Impresoras);
            this.groupBox2.Controls.Add(this.btnImprimir);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.TxtDocumento);
            this.groupBox2.Controls.Add(this.CbBaseD);
            this.groupBox2.Controls.Add(this.TxtTransaccion);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCiudad);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDireccion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDestino);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox2.Location = new System.Drawing.Point(16, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1016, 481);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rótulo";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // cbxContacto
            // 
            this.cbxContacto.FormattingEnabled = true;
            this.cbxContacto.Location = new System.Drawing.Point(219, 309);
            this.cbxContacto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxContacto.Name = "cbxContacto";
            this.cbxContacto.Size = new System.Drawing.Size(284, 37);
            this.cbxContacto.TabIndex = 37;
            // 
            // txtCantidadImpr
            // 
            this.txtCantidadImpr.Location = new System.Drawing.Point(793, 42);
            this.txtCantidadImpr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidadImpr.Name = "txtCantidadImpr";
            this.txtCantidadImpr.Size = new System.Drawing.Size(76, 34);
            this.txtCantidadImpr.TabIndex = 36;
            this.txtCantidadImpr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Impresoras
            // 
            this.Impresoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Impresoras.FormattingEnabled = true;
            this.Impresoras.Location = new System.Drawing.Point(224, 377);
            this.Impresoras.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Impresoras.Name = "Impresoras";
            this.Impresoras.Size = new System.Drawing.Size(596, 37);
            this.Impresoras.TabIndex = 35;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Gainsboro;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Location = new System.Drawing.Point(419, 423);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(199, 38);
            this.btnImprimir.TabIndex = 34;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label3.Location = new System.Drawing.Point(469, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 17);
            this.label3.TabIndex = 33;
            this.label3.Text = "__________________";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label10.Location = new System.Drawing.Point(288, 65);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "__________________";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.BackgroundImage = global::ZebraPruebas.Properties.Resources.search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button1.Location = new System.Drawing.Point(677, 37);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 43);
            this.button1.TabIndex = 31;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // TxtDocumento
            // 
            this.TxtDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TxtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtDocumento.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtDocumento.Location = new System.Drawing.Point(473, 39);
            this.TxtDocumento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtDocumento.Name = "TxtDocumento";
            this.TxtDocumento.Size = new System.Drawing.Size(196, 27);
            this.TxtDocumento.TabIndex = 30;
            this.TxtDocumento.Text = "Documento";
            this.TxtDocumento.TextChanged += new System.EventHandler(this.TxtDocumento_TextChanged);
            this.TxtDocumento.Enter += new System.EventHandler(this.TxtDocumento_Enter);
            this.TxtDocumento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDocumento_KeyDown);
            this.TxtDocumento.Leave += new System.EventHandler(this.TxtDocumento_Leave);
            // 
            // CbBaseD
            // 
            this.CbBaseD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CbBaseD.FormattingEnabled = true;
            this.CbBaseD.Items.AddRange(new object[] {
            "Verde",
            "Blanca"});
            this.CbBaseD.Location = new System.Drawing.Point(95, 41);
            this.CbBaseD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CbBaseD.Name = "CbBaseD";
            this.CbBaseD.Size = new System.Drawing.Size(160, 37);
            this.CbBaseD.TabIndex = 28;
            // 
            // TxtTransaccion
            // 
            this.TxtTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TxtTransaccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtTransaccion.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtTransaccion.Location = new System.Drawing.Point(292, 38);
            this.TxtTransaccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtTransaccion.Name = "TxtTransaccion";
            this.TxtTransaccion.Size = new System.Drawing.Size(196, 27);
            this.TxtTransaccion.TabIndex = 29;
            this.TxtTransaccion.Text = "Transaccion";
            this.TxtTransaccion.Enter += new System.EventHandler(this.TxtTransaccion_Enter);
            this.TxtTransaccion.Leave += new System.EventHandler(this.TxtTransaccion_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 313);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 29);
            this.label9.TabIndex = 27;
            this.label9.Text = "Telefono: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(91, 177);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 29);
            this.label8.TabIndex = 26;
            this.label8.Text = "Direccion:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(91, 240);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "Ciudad: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 29);
            this.label6.TabIndex = 24;
            this.label6.Text = "Destino: ";
            // 
            // txtCiudad
            // 
            this.txtCiudad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtCiudad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtCiudad.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtCiudad.Location = new System.Drawing.Point(200, 240);
            this.txtCiudad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.ReadOnly = true;
            this.txtCiudad.Size = new System.Drawing.Size(668, 27);
            this.txtCiudad.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label4.Location = new System.Drawing.Point(187, 262);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(656, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "________________________________________________________________________";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtDireccion.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDireccion.Location = new System.Drawing.Point(224, 177);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ReadOnly = true;
            this.txtDireccion.Size = new System.Drawing.Size(644, 27);
            this.txtDireccion.TabIndex = 18;
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label2.Location = new System.Drawing.Point(215, 202);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(629, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "_____________________________________________________________________";
            // 
            // txtDestino
            // 
            this.txtDestino.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txtDestino.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtDestino.Location = new System.Drawing.Point(204, 106);
            this.txtDestino.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.ReadOnly = true;
            this.txtDestino.Size = new System.Drawing.Size(664, 27);
            this.txtDestino.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label1.Location = new System.Drawing.Point(187, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(656, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "________________________________________________________________________";
            // 
            // Rotulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1048, 511);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Rotulo";
            this.Text = "Rotulo";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadImpr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtDocumento;
        private System.Windows.Forms.ComboBox CbBaseD;
        private System.Windows.Forms.TextBox TxtTransaccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox Impresoras;
        private System.Windows.Forms.NumericUpDown txtCantidadImpr;
        private System.Windows.Forms.ComboBox cbxContacto;
    }
}