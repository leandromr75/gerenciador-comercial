using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class AjudaEAN : Form
    {
        public AjudaEAN()
        {
            InitializeComponent();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AjudaEAN_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
