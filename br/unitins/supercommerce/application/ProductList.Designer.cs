
namespace supermercadoEcommerce.br.unitins.supercommerce.application
{
    partial class ProductList
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbPrefix = new System.Windows.Forms.Label();
            this.lbValue = new System.Windows.Forms.Label();
            this.btnCarrinho = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbQuantity = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbPrefix
            // 
            this.lbPrefix.AutoSize = true;
            this.lbPrefix.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrefix.Location = new System.Drawing.Point(27, 34);
            this.lbPrefix.Name = "lbPrefix";
            this.lbPrefix.Size = new System.Drawing.Size(31, 13);
            this.lbPrefix.TabIndex = 1;
            this.lbPrefix.Text = "R$: ";
            // 
            // lbValue
            // 
            this.lbValue.AutoSize = true;
            this.lbValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValue.Location = new System.Drawing.Point(52, 34);
            this.lbValue.Name = "lbValue";
            this.lbValue.Size = new System.Drawing.Size(57, 13);
            this.lbValue.TabIndex = 2;
            this.lbValue.Text = "0.000,00";
            // 
            // btnCarrinho
            // 
            this.btnCarrinho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(79)))), ((int)(((byte)(35)))));
            this.btnCarrinho.FlatAppearance.BorderSize = 0;
            this.btnCarrinho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarrinho.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarrinho.ForeColor = System.Drawing.Color.White;
            this.btnCarrinho.Location = new System.Drawing.Point(660, 14);
            this.btnCarrinho.Name = "btnCarrinho";
            this.btnCarrinho.Size = new System.Drawing.Size(166, 39);
            this.btnCarrinho.TabIndex = 10;
            this.btnCarrinho.Text = "Adicionar ao Carrinho";
            this.btnCarrinho.UseVisualStyleBackColor = false;
            this.btnCarrinho.Click += new System.EventHandler(this.btnCarrinho_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Quantidade em Estoque: ";
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantity.Location = new System.Drawing.Point(170, 47);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(14, 13);
            this.lbQuantity.TabIndex = 12;
            this.lbQuantity.Text = "0";
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductName.Location = new System.Drawing.Point(26, 14);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(151, 20);
            this.lbProductName.TabIndex = 13;
            this.lbProductName.TabStop = true;
            this.lbProductName.Text = "Nome Do Produto";
            this.lbProductName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbProductName_LinkClicked);
            // 
            // ProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lbProductName);
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCarrinho);
            this.Controls.Add(this.lbValue);
            this.Controls.Add(this.lbPrefix);
            this.Name = "ProductList";
            this.Size = new System.Drawing.Size(840, 68);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbPrefix;
        private System.Windows.Forms.Label lbValue;
        private System.Windows.Forms.Button btnCarrinho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbQuantity;
        private System.Windows.Forms.LinkLabel lbProductName;
    }
}
