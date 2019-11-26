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
    public partial class Valor : Form
    {
        public Valor(string prod)
        {
            InitializeComponent();
            this.Text = prod;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Int64 qtde3;
            textBox1.Text = textBox1.Text.Replace(".", ",");
            if (Int64.TryParse(textBox1.Text.Replace(",", "").Trim(), out qtde3) == false)
            {
                MessageBox.Show("Formato incorreto");
                textBox1.Text = "";
                textBox1.Focus();
                return;

            }
            else
            {
                Global.Margem.DescontoValor = textBox1.Text;
                this.Close();
            }
        }
    }
}
