
namespace supermercadoEcommerce.br.unitins.supercommerce.views
{
    partial class RecoveryPassword
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
            this.tbEmailRecovery = new System.Windows.Forms.TextBox();
            this.lbRecovery = new System.Windows.Forms.Label();
            this.btnRecovery = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbEmailRecovery
            // 
            this.tbEmailRecovery.Location = new System.Drawing.Point(74, 326);
            this.tbEmailRecovery.Name = "tbEmailRecovery";
            this.tbEmailRecovery.Size = new System.Drawing.Size(415, 20);
            this.tbEmailRecovery.TabIndex = 1;
            // 
            // lbRecovery
            // 
            this.lbRecovery.AutoSize = true;
            this.lbRecovery.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRecovery.Location = new System.Drawing.Point(69, 274);
            this.lbRecovery.Name = "lbRecovery";
            this.lbRecovery.Size = new System.Drawing.Size(608, 25);
            this.lbRecovery.TabIndex = 2;
            this.lbRecovery.Text = "Preencha um email para enviar uma nova senha em seu email";
            // 
            // btnRecovery
            // 
            this.btnRecovery.BackColor = System.Drawing.Color.Maroon;
            this.btnRecovery.FlatAppearance.BorderSize = 0;
            this.btnRecovery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecovery.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecovery.ForeColor = System.Drawing.Color.White;
            this.btnRecovery.Location = new System.Drawing.Point(507, 315);
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Size = new System.Drawing.Size(220, 39);
            this.btnRecovery.TabIndex = 10;
            this.btnRecovery.Text = "Enviar Email de Recuperacao";
            this.btnRecovery.UseVisualStyleBackColor = false;
            this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::supermercadoEcommerce.Properties.Resources.LogoBOmPreco_removebg_preview;
            this.pictureBox1.Location = new System.Drawing.Point(282, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // RecoveryPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRecovery);
            this.Controls.Add(this.lbRecovery);
            this.Controls.Add(this.tbEmailRecovery);
            this.Name = "RecoveryPassword";
            this.Text = "RecoveryPassword";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbEmailRecovery;
        private System.Windows.Forms.Label lbRecovery;
        private System.Windows.Forms.Button btnRecovery;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}