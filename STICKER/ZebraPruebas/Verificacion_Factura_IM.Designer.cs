namespace ZebraPruebas
{
    partial class Verificacion_Factura_IM
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
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.cbxPanel = new System.Windows.Forms.ComboBox();
            this.lblRpta = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impresoras = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtIdTercero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTransaccion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNumDocumento = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxTransaccionManual = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(18, 17);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(204, 20);
            this.txtFiltrar.TabIndex = 1;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged);
            // 
            // cbxPanel
            // 
            this.cbxPanel.FormattingEnabled = true;
            this.cbxPanel.Items.AddRange(new object[] {
            "Pedidos IM",
            "Pedidos IM Verificados"});
            this.cbxPanel.Location = new System.Drawing.Point(228, 16);
            this.cbxPanel.Name = "cbxPanel";
            this.cbxPanel.Size = new System.Drawing.Size(121, 21);
            this.cbxPanel.TabIndex = 2;
            this.cbxPanel.Text = "Pedidos IM";
            // 
            // lblRpta
            // 
            this.lblRpta.AutoSize = true;
            this.lblRpta.Location = new System.Drawing.Point(12, 250);
            this.lblRpta.Name = "lblRpta";
            this.lblRpta.Size = new System.Drawing.Size(0, 13);
            this.lblRpta.TabIndex = 7;
            this.lblRpta.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.Impresoras);
            this.groupBox2.Location = new System.Drawing.Point(12, 336);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(829, 280);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pedidos IM Verificados";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "actualizar docref 04";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Valor_Total});
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(817, 217);
            this.dataGridView2.TabIndex = 20;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Cliente";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Valor_Total
            // 
            this.Valor_Total.HeaderText = "Valor Total ($)";
            this.Valor_Total.Name = "Valor_Total";
            // 
            // Impresoras
            // 
            this.Impresoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.Impresoras.FormattingEnabled = true;
            this.Impresoras.Location = new System.Drawing.Point(174, 242);
            this.Impresoras.Name = "Impresoras";
            this.Impresoras.Size = new System.Drawing.Size(419, 32);
            this.Impresoras.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(829, 280);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pedidos IM";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.txtIdTercero,
            this.Col,
            this.txtTransaccion,
            this.txtNumero});
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(817, 255);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // txtIdTercero
            // 
            this.txtIdTercero.HeaderText = "Identificacion";
            this.txtIdTercero.Name = "txtIdTercero";
            this.txtIdTercero.ReadOnly = true;
            // 
            // Col
            // 
            this.Col.HeaderText = "Cliente";
            this.Col.Name = "Col";
            // 
            // txtTransaccion
            // 
            this.txtTransaccion.HeaderText = "Transaccion";
            this.txtTransaccion.Items.AddRange(new object[] {
            "09",
            "1009"});
            this.txtTransaccion.Name = "txtTransaccion";
            // 
            // txtNumero
            // 
            this.txtNumero.HeaderText = "Nº";
            this.txtNumero.Name = "txtNumero";
            // 
            // txtNumDocumento
            // 
            this.txtNumDocumento.Location = new System.Drawing.Point(664, 16);
            this.txtNumDocumento.Name = "txtNumDocumento";
            this.txtNumDocumento.Size = new System.Drawing.Size(124, 20);
            this.txtNumDocumento.TabIndex = 4;
            this.txtNumDocumento.TextChanged += new System.EventHandler(this.txtNumDocumento_TextChanged);
            this.txtNumDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumDocumento_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(587, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Documento";
            // 
            // cbxTransaccionManual
            // 
            this.cbxTransaccionManual.FormattingEnabled = true;
            this.cbxTransaccionManual.Items.AddRange(new object[] {
            "09",
            "1009",
            "0410"});
            this.cbxTransaccionManual.Location = new System.Drawing.Point(514, 16);
            this.cbxTransaccionManual.Name = "cbxTransaccionManual";
            this.cbxTransaccionManual.Size = new System.Drawing.Size(53, 21);
            this.cbxTransaccionManual.TabIndex = 3;
            this.cbxTransaccionManual.Text = "09";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(431, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Transaccion";
            // 
            // Verificacion_Factura_IM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(853, 644);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxTransaccionManual);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumDocumento);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.cbxPanel);
            this.Controls.Add(this.lblRpta);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Verificacion_Factura_IM";
            this.Text = "Verificacion_Factura_IM";
            this.Load += new System.EventHandler(this.Verificacion_Factura_IM_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.ComboBox cbxPanel;
        private System.Windows.Forms.Label lblRpta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor_Total;
        private System.Windows.Forms.ComboBox Impresoras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtNumDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxTransaccionManual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtIdTercero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col;
        private System.Windows.Forms.DataGridViewComboBoxColumn txtTransaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNumero;
        private System.Windows.Forms.Button button1;
    }
}