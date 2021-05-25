using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermercadoEcommerce.br.unitins.supercommerce.views
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar.Width += 3;

            if(progressBar.Width >= 699)
            {
                timer1.Stop();
                Main mainScreen = new Main();
                mainScreen.Show();
                this.Hide();
            }
        }
    }
}
