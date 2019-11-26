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
    public partial class Retirada : Form
    {
        public Retirada()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                textBox1.Text = textBox1.Text.Replace(".",",");
                decimal teste = 0;
                if (Decimal.TryParse(textBox1.Text.Trim() ,out teste) == false)
	            {
                    MessageBox.Show("Formato incorreto");
                    textBox1.Text = "";
                    textBox1.Focus();
	            }
                
            }
            string data = System.DateTime.Now.ToShortDateString();
            string datacalc = "";
            string ano = DateTime.Now.Year.ToString();
            string mes = DateTime.Now.Month.ToString();
            if (mes.Length < 2)
            {
                mes = "0" + mes;
            }
            string dia = DateTime.Now.Day.ToString();
            if (dia.Length < 2)
            {
                dia = "0" + dia;
            }
            datacalc = ano + mes + dia;
            if (String.IsNullOrEmpty(textBox1.Text) == false &&
                    String.IsNullOrEmpty(comboBox1.Text) == false && comboBox1.Text != "Pagamento Fornecedor")
            {
                
                DALCadastro.CriarRetirada(textBox1.Text,comboBox1.Text,Global.Margem.RetiradaCaixa,textBox2.Text);
                DALCadastro.InsereAUXVendas(comboBox1.Text + " -> " + Global.Margem.RetiradaCaixa,"","","",comboBox1.Text,textBox1.Text,data,Convert.ToInt32( datacalc));
                this.Close();
            }

            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && 
                    String.IsNullOrEmpty(comboBox1.Text) == false && comboBox1.Text == "Pagamento Fornecedor")
            {
                textBox2.Visible = true;
                DALCadastro.CriarRetirada(textBox1.Text,comboBox1.Text,Global.Margem.RetiradaCaixa,"");
                DALCadastro.InsereAUXVendas("Pagamento Fornecedor [" + textBox2.Text + "]" + Global.Margem.RetiradaCaixa, "", "", "", comboBox1.Text, textBox1.Text, data, Convert.ToInt32(datacalc));
                textBox2.Visible = false;
                this.Close();
            }
        }

        private void Retirada_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void Retirada_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.White;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Pagamento Fornecedor")
            {
                label3.Visible = true;
                textBox2.Visible = true;
                return;
            }
            if (comboBox1.Text != "Pagamento Fornecedor")
            {
                label3.Visible = false;
                textBox2.Visible = false;
            }
        }

       
    }
}
