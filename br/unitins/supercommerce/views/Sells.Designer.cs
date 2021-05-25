
namespace supermercadoEcommerce.br.unitins.supercommerce.views
{
    partial class Sells
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
            this.dtVendas = new System.Windows.Forms.DataGridView();
            this.VendaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendaQuantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendaUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtVendas
            // 
            this.dtVendas.AllowUserToAddRows = false;
            this.dtVendas.AllowUserToDeleteRows = false;
            this.dtVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVendas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VendaTotal,
            this.VendaQuantidade,
            this.VendaUsuario});
            this.dtVendas.Location = new System.Drawing.Point(13, 125);
            this.dtVendas.Name = "dtVendas";
            this.dtVendas.ReadOnly = true;
            this.dtVendas.Size = new System.Drawing.Size(859, 474);
            this.dtVendas.TabIndex = 5;
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
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Sells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.dtVendas);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Sells";
            this.Text = "Sells";
            this.Load += new System.EventHandler(this.Sells_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dtVendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendaTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendaQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendaUsuario;
    }
}