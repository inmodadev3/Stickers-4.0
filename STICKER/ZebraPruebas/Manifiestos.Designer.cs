namespace ZebraPruebas
{
    partial class Manifiestos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CbBaseD = new System.Windows.Forms.ComboBox();
            this.TxtTransaccion = new System.Windows.Forms.TextBox();
            this.TxtDocumento = new System.Windows.Forms.TextBox();
            this.Productos = new System.Windows.Forms.DataGridView();
            this.ManifiestosImp = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.Impresoras = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ManifiestoPrd = new System.Windows.Forms.DataGridView();
            this.TxtProducto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Productos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifiestosImp)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManifiestoPrd)).BeginInit();
            this.SuspendLayout();
            // 
            // CbBaseD
            // 
            this.CbBaseD.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.CbBaseD.FormattingEnabled = true;
            this.CbBaseD.Items.AddRange(new object[] {
            "Verde",
            "Blanca"});
            this.CbBaseD.Location = new System.Drawing.Point(11, 27);
            this.CbBaseD.Name = "CbBaseD";
            this.CbBaseD.Size = new System.Drawing.Size(121, 32);
            this.CbBaseD.TabIndex = 0;
            this.CbBaseD.SelectedIndexChanged += new System.EventHandler(this.CbBaseD_SelectedIndexChanged);
            // 
            // TxtTransaccion
            // 
            this.TxtTransaccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TxtTransaccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtTransaccion.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtTransaccion.Location = new System.Drawing.Point(159, 25);
            this.TxtTransaccion.Name = "TxtTransaccion";
            this.TxtTransaccion.Size = new System.Drawing.Size(147, 22);
            this.TxtTransaccion.TabIndex = 1;
            this.TxtTransaccion.Text = "Transaccion";
            this.TxtTransaccion.Enter += new System.EventHandler(this.TxtTransaccion_Enter);
            this.TxtTransaccion.Leave += new System.EventHandler(this.TxtTransaccion_Leave);
            // 
            // TxtDocumento
            // 
            this.TxtDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TxtDocumento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtDocumento.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtDocumento.Location = new System.Drawing.Point(295, 26);
            this.TxtDocumento.Name = "TxtDocumento";
            this.TxtDocumento.Size = new System.Drawing.Size(147, 22);
            this.TxtDocumento.TabIndex = 2;
            this.TxtDocumento.Text = "Documento";
            this.TxtDocumento.AcceptsTabChanged += new System.EventHandler(this.TxtDocumento_AcceptsTabChanged);
            this.TxtDocumento.TextChanged += new System.EventHandler(this.TxtDocumento_TextChanged);
            this.TxtDocumento.Enter += new System.EventHandler(this.TxtDocumento_Enter);
            this.TxtDocumento.Leave += new System.EventHandler(this.TxtDocumento_Leave);
            // 
            // Productos
            // 
            this.Productos.AllowUserToAddRows = false;
            this.Productos.AllowUserToDeleteRows = false;
            this.Productos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Productos.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.Productos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Productos.Location = new System.Drawing.Point(11, 68);
            this.Productos.Name = "Productos";
            this.Productos.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.Productos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Productos.Size = new System.Drawing.Size(488, 214);
            this.Productos.TabIndex = 3;
            // 
            // ManifiestosImp
            // 
            this.ManifiestosImp.AllowUserToAddRows = false;
            this.ManifiestosImp.AllowUserToDeleteRows = false;
            this.ManifiestosImp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ManifiestosImp.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.ManifiestosImp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManifiestosImp.Location = new System.Drawing.Point(11, 288);
            this.ManifiestosImp.Name = "ManifiestosImp";
            this.ManifiestosImp.ReadOnly = true;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ManifiestosImp.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ManifiestosImp.Size = new System.Drawing.Size(488, 169);
            this.ManifiestosImp.TabIndex = 4;
            this.ManifiestosImp.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ManifiestosImp_CellClick);
            this.ManifiestosImp.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ManifiestosImp_RowsAdded);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label1.Location = new System.Drawing.Point(156, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "__________________";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label2.Location = new System.Drawing.Point(292, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "__________________";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.Impresoras);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.TxtDocumento);
            this.groupBox1.Controls.Add(this.CbBaseD);
            this.groupBox1.Controls.Add(this.TxtTransaccion);
            this.groupBox1.Controls.Add(this.Productos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ManifiestosImp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 537);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Factura";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(223, 501);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 29);
            this.btnPrint.TabIndex = 20;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // Impresoras
            // 
            this.Impresoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Impresoras.FormattingEnabled = true;
            this.Impresoras.Location = new System.Drawing.Point(11, 463);
            this.Impresoras.Name = "Impresoras";
            this.Impresoras.Size = new System.Drawing.Size(488, 32);
            this.Impresoras.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.BackgroundImage = global::ZebraPruebas.Properties.Resources.search;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button1.Location = new System.Drawing.Point(448, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.ManifiestoPrd);
            this.groupBox2.Controls.Add(this.TxtProducto);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox2.Location = new System.Drawing.Point(523, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 537);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Producto";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Gainsboro;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.button2.Location = new System.Drawing.Point(18, 273);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 38);
            this.button2.TabIndex = 15;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ManifiestoPrd
            // 
            this.ManifiestoPrd.AllowUserToAddRows = false;
            this.ManifiestoPrd.AllowUserToDeleteRows = false;
            this.ManifiestoPrd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ManifiestoPrd.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.ManifiestoPrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ManifiestoPrd.Location = new System.Drawing.Point(18, 78);
            this.ManifiestoPrd.Name = "ManifiestoPrd";
            this.ManifiestoPrd.ReadOnly = true;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.ManifiestoPrd.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.ManifiestoPrd.Size = new System.Drawing.Size(233, 189);
            this.ManifiestoPrd.TabIndex = 14;
            this.ManifiestoPrd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ManidiestoPrd_CellClick);
            // 
            // TxtProducto
            // 
            this.TxtProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.TxtProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TxtProducto.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TxtProducto.Location = new System.Drawing.Point(37, 26);
            this.TxtProducto.Name = "TxtProducto";
            this.TxtProducto.Size = new System.Drawing.Size(147, 22);
            this.TxtProducto.TabIndex = 7;
            this.TxtProducto.Text = "Referencia";
            this.TxtProducto.Enter += new System.EventHandler(this.TxtProducto_Enter);
            this.TxtProducto.Leave += new System.EventHandler(this.TxtProducto_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(122)))), ((int)(((byte)(183)))));
            this.label3.Location = new System.Drawing.Point(34, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "__________________";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Manifiestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(802, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Manifiestos";
            this.Text = "Items";
            ((System.ComponentModel.ISupportInitialize)(this.Productos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManifiestosImp)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ManifiestoPrd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CbBaseD;
        private System.Windows.Forms.TextBox TxtTransaccion;
        private System.Windows.Forms.TextBox TxtDocumento;
        private System.Windows.Forms.DataGridView Productos;
        private System.Windows.Forms.DataGridView ManifiestosImp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtProducto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView ManifiestoPrd;
        private System.Windows.Forms.ComboBox Impresoras;
        private System.Windows.Forms.Button btnPrint;
    }
}