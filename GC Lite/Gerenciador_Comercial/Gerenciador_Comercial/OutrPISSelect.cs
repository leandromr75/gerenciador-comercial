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
    public partial class OutrPISSelect : Form
    {
        public OutrPISSelect()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Aliquota em Percentual")
            {
                //this.Visible = false;
                GlobalSAT.PIS = "PISOutrPercentual";
                Form pisPerc = new PISOutrPercentual();
                pisPerc.ShowDialog();
                this.Close();
            }
            if (comboBox1.Text == "Aliquota em Valor")
            {
                //this.Visible = false;
                GlobalSAT.PIS = "PISOutrValor";
                Form pisvalor = new PISOutrValor();
                pisvalor.ShowDialog();
                this.Close();
            }
        }

       
    }
}
