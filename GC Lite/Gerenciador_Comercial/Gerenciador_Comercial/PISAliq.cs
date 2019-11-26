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
    public partial class PISAliq : Form
    {
        public PISAliq()
        {
            InitializeComponent();
        }

        private void PISAliq_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false &&
                String.IsNullOrEmpty(textBox3.Text) == false)
            {
                XML_SAT.CST_PIS_PISAliq = textBox1.Text;
                XML_SAT.vBC_PIS_PISAliq = textBox2.Text;
                XML_SAT.pPIS_PIS_PISAliq = textBox3.Text;
                GlobalSAT.ImpostoOK = "ok";
                this.Close();
            }
            else
            {
                MessageBox.Show("Campos obrigatórios não preenchidos");
                
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("01 – Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo))\n" +
                            "02 - Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada))\n" +
                            "05 - Operação Tributável por Substituição Tributária)");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
