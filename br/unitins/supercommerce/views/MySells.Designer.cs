
namespace supermercadoEcommerce.br.unitins.supercommerce.views
{
    partial class MySells
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
            this.dtMyVendas = new System.Windows.Forms.DataGridView();
            this.VendaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendaQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendaUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtMyVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtMyVendas
            // 
            this.dtMyVendas.AllowUserToAddRows = false;
            this.dtMyVendas.AllowUserToDeleteRows = false;
            this.dtMyVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtMyVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VendaTotal,
            this.VendaQuantidade,
            this.VendaUsuario});
            this.dtMyVendas.Location = new System.Drawing.Point(13, 125);
            this.dtMyVendas.Name = "dtMyVendas";
            this.dtMyVendas.ReadOnly = true;
            this.dtMyVendas.Size = new System.Drawing.Size(859, 474);
            this.dtMyVendas.TabIndex = 7;
            // 
            // VendaTotal
            // 
            this.VendaTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendaTotal.HeaderText = "Total da Venda";
            this.VendaTotal.Name = "VendaTotal";
            this.VendaTotal.ReadOnly = true;
            // 
            // VendaQuantidade
            // 
            this.VendaQuantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendaQuantidade.HeaderText = "Quantidade de Itens";
            this.VendaQuantidade.Name = "VendaQuantidade";
            this.VendaQuantidade.ReadOnly = true;
            // 
            // VendaUsuario
            // 
            this.VendaUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VendaUsuario.HeaderText = "Usuario";
            this.VendaUsuario.Name = "VendaUsuario";
            this.VendaUsuario.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::supermercadoEcommerce.Properties.Resources.LogoBOmPreco_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // MySells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.dtMyVendas);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MySells";
            this.Text = "MySells";
            this.Load += new System.EventHandler(this.MySells_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtMyVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtMyVendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendaTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendaQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendaUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}