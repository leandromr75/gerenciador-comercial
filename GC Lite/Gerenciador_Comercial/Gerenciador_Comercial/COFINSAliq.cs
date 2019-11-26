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
    public partial class COFINSAliq : Form
    {
        public COFINSAliq()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("01 – Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))\n" +
                           "02 - Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada))\n" +
                           "05 - Operação Tributável por Substituição Tributária)");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false &&
               String.IsNullOrEmpty(textBox3.Text) == false)
            {
                XML_SAT.CST_COFINSAliq = textBox1.Text;
                XML_SAT.vBC_COFINSAliq = textBox2.Text;
                XML_SAT.pCOFINS_COFINSAliq = textBox3.Text;
                GlobalSAT.ImpostoOK = "ok";
                this.Close();
            }
            else
            {
                MessageBox.Show("Campos obrigatórios não preenchidos");

            }
        }

        private void COFINSAliq_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
