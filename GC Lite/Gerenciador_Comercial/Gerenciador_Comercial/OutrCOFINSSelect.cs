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
    public partial class OutrCOFINSSelect : Form
    {
        public OutrCOFINSSelect()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Aliquota em Percentual")
            {
                //this.Visible = false;
                GlobalSAT.COFINS = "COFINSOutrPercentual";
                Form cofinsPerc = new COFINSOutrPercentual();
                cofinsPerc.ShowDialog();
                this.Close();
            }
            if (comboBox1.Text == "Aliquota em Valor")
            {
                //this.Visible = false;
                GlobalSAT.COFINS = "COFINSOutrValor";
                Form cofinsvalor = new COFINSOutrValor();
                cofinsvalor.ShowDialog();
                this.Close();
            }
        }

    }
}
