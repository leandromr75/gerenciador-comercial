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
    public partial class Alert3 : Form
    {
        public Alert3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.Margem.EditarCad = "sim";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global.Margem.EditarCad = "";
            this.Close();
        }
    }
}
