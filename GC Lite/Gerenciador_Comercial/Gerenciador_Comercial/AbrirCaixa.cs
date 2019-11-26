using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class AbrirCaixa : Form
    {
        public AbrirCaixa()
        {
            InitializeComponent();
        }

        private void AbrirCaixa_Load(object sender, EventArgs e)
        {
            
            this.Text = "[Abertura de Caixa. Operador ==> " + Global.Margem.Operador + "]";
            dataGridView1.DataSource = DALCadastro.ListarContaAbrirCaixa();
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("Não exitem Contas Cadastradas");
                Global.Margem.SemContaCadastrada = "sim";
                this.Close();
            }
            comboBox1.DataSource = DALCadastro.AUXCadListar("ListarCadEmpresa");
            comboBox1.ValueMember = "Descrição";
            comboBox1.DisplayMember = "Descricao";
            //comboBox1.SelectedItem = "";
            comboBox1.Refresh();
            dataGridView1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                label7.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                textBox3.ReadOnly = false;
                textBox3.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false)
            {
                if (textBox3.Text.Length >= 4)
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    textBox3.Text = textBox3.Text.Replace(",","");
                    string fração = textBox3.Text.Substring(textBox3.Text.Length - 2, 2);
                    string inteiro = textBox3.Text.Substring(0,textBox3.Text.Length - 2);
                    textBox3.Text = inteiro + "," + fração;
                }
                else
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    textBox3.Text = textBox3.Text.Replace(",", "");
                    textBox3.Text = textBox3.Text + ",00";
                }
                string message = "Correto o Valor : " + textBox3.Text + " para abertura do Caixa,\ncom a Conta : " + textBox2.Text + "\nEmpresa : " + comboBox1.Text;
                string caption = "Valor";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Mostra a MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    //global valores
                    using (StreamWriter writer = new StreamWriter("Conta.txt"))
                    {
                        writer.Write(textBox2.Text);
                        Global.Margem.ContaAberta = label7.Text;
                        
                    }
                    using (StreamWriter writer = new StreamWriter("Valor.txt"))
                    {
                        writer.Write(textBox3.Text);
                        Global.Margem.ValorAberto = textBox3.Text;

                    }
                    using (StreamWriter writer = new StreamWriter("CaixaAberto.txt"))
                    {
                        writer.Write("sim");
                        

                    }
                    using (StreamWriter writer = new StreamWriter("Empresa.txt"))
                    {
                        writer.Write(comboBox1.Text);
                        Global.Margem.EmpresaCaixa = comboBox1.Text;

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
                    DALCadastro.InsereAUXVendas("Saldo Inicial","","","","Valor Inicial do Caixa",textBox3.Text,data,Convert.ToInt32(datacalc));
                    this.Close();
                }
                if (result == DialogResult.No)
                {
                    textBox3.Text = "";
                    textBox3.Focus();
                }
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.BackColor = System.Drawing.Color.White;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Global.Margem.SemContaCadastrada = "sim";
            this.Close();
        }

        private void AbrirCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                dataGridView1.Focus();
            }
            if (e.KeyCode == Keys.Space)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    label7.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                    textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                    textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                    textBox3.ReadOnly = false;
                    textBox3.Focus();
                }
            }
        }
    }
}
