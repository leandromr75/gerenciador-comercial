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
    public partial class PesoPreço : Form
    {
        public PesoPreço()
        {
            InitializeComponent();
            
        }

        private void PesoPreço_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.White;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty( textBox1.Text ) == true)
            {
                MessageBox.Show("Forneça o valor de Venda por KG");
                textBox1.Focus();
                return;
            }
            decimal preço;
            if (Decimal.TryParse(textBox1.Text.Trim(), out preço) == false)
            {
                MessageBox.Show("O campo peso Preço está em formato incorreto");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            
            Global.Margem.PreçoPesoManual = textBox1.Text;
            
            this.Close();
        }
    }
}
