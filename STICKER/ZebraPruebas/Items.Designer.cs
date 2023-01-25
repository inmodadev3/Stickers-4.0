namespace ZebraPruebas
{
    partial class Items
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
            this.TxtDocumento = new System.Windows.Forms.TextBox();
            this.TxtTransaccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CbBaseD = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.TxtNumeroItems = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Impresoras = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtDocumento
            // 
            this.TxtDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TxtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtDocumento.Location = new System.Drawing.Point(307, 71);
            this.TxtDocumento.Name = "TxtDocumento";
            this.TxtDocumento.Size = new System.Drawing.Size(147, 22);
            this.TxtDocumento.TabIndex = 9;
            this.TxtDocumento.Text = "Documento";
            this.TxtDocumento.TextChanged += new System.EventHandler(this.TxtDocumento_TextChanged);
            this.TxtDocumento.Enter += new System.EventHandler(this.TxtDocumento_Enter);
            // 
            // TxtTransaccion
            // 
            this.TxtTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TxtTransaccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtTransaccion.Location = new System.Drawing.Point(157, 71);
            this.TxtTransaccion.Name = "TxtTransaccion";
            this.TxtTransaccion.Size = new System.Drawing.Size(147, 22);
            this.TxtTransaccion.TabIndex = 8;
            this.TxtTransaccion.Text = "Transaccion";
            this.TxtTransaccion.TextChanged += new System.EventHandler(this.TxtTransaccion_TextChanged);
            this.TxtTransaccion.Enter += new System.EventHandler(this.TxtTransaccion_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label2.Location = new System.Drawing.Point(304, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "__________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label1.Location = new System.Drawing.Point(154, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "__________________";
            // 
            // CbBaseD
            // 
            this.CbBaseD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CbBaseD.FormattingEnabled = true;
            this.CbBaseD.Items.AddRange(new object[] {
            "Verde",
            "Blanca"});
            this.CbBaseD.Location = new System.Drawing.Point(15, 73);
            this.CbBaseD.Name = "CbBaseD";
            this.CbBaseD.Size = new System.Drawing.Size(121, 32);
            this.CbBaseD.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.TxtNumeroItems);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(491, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 328);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label3.Location = new System.Drawing.Point(59, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "__________________";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button2.Location = new System.Drawing.Point(35, 174);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(198, 38);
            this.button2.TabIndex = 13;
            this.button2.Text = "Imprimir";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TxtNumeroItems
            // 
            this.TxtNumeroItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TxtNumeroItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNumeroItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtNumeroItems.Location = new System.Drawing.Point(62, 71);
            this.TxtNumeroItems.Name = "TxtNumeroItems";
            this.TxtNumeroItems.Size = new System.Drawing.Size(147, 22);
            this.TxtNumeroItems.TabIndex = 13;
            this.TxtNumeroItems.Text = "Items";
            this.TxtNumeroItems.TextChanged += new System.EventHandler(this.TxtNumeroItems_TextChanged);
            this.TxtNumeroItems.Enter += new System.EventHandler(this.TxtNumeroItems_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CbBaseD);
            this.groupBox2.Controls.Add(this.TxtDocumento);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TxtTransaccion);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(463, 328);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automatico";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button1.Location = new System.Drawing.Point(151, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 38);
            this.button1.TabIndex = 12;
            this.button1.Text = "Imprimir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Impresoras
            // 
            this.Impresoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Impresoras.FormattingEnabled = true;
            this.Impresoras.Location = new System.Drawing.Point(27, 12);
            this.Impresoras.Name = "Impresoras";
            this.Impresoras.Size = new System.Drawing.Size(531, 32);
            this.Impresoras.TabIndex = 15;
            // 
            // Items
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(786, 415);
            this.Controls.Add(this.Impresoras);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Items";
            this.Text = "Items";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxtDocumento;
        private System.Windows.Forms.TextBox TxtTransaccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CbBaseD;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TxtNumeroItems;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox Impresoras;
    }
}