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
    public partial class CFOP_Entrada : Form
    {
        public CFOP_Entrada()
        {
            InitializeComponent();
        }

        private void CFOP_Entrada_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.ListaCFOP();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox2.Text = "";
            textBox1.Text = "";

            textBox2.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false)
            {
                Global.Margem.CFOP_Entr = textBox2.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecionar antes o código CFOP");

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly == true && textBox2.ReadOnly == true)
            {
                MessageBox.Show("Necessário abrir novo cadastro.");
                return;
            }
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (textBox2.Text == dataGridView1.Rows[i].Cells[0].Value.ToString())
                    {
                        MessageBox.Show("Código já cadastrado.");
                        return;
                    }
                }
                DALCadastro.CriaCFOP(textBox2.Text,textBox1.Text);
                MessageBox.Show("CFOP inserido com sucesso.");
                dataGridView1.DataSource = DALCadastro.ListaCFOP();
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Campos Obrigatórios não preenchidos.");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.ReadOnly == true && textBox1.ReadOnly == true)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false)
                {
                    DataTable pode = DALCadastro.PodeApagarCFOP(textBox2.Text);
                    if (pode.Rows.Count <= 0)
                    {
                        DALCadastro.ProcCFOP(textBox2.Text);
                        MessageBox.Show("CFOP apagado com sucesso.");
                        dataGridView1.DataSource = DALCadastro.ListaCFOP();
                    }
                    if (pode.Rows.Count > 0)
                    {
                        MessageBox.Show("CFOP não pode ser deletado, pois já foi utilizado para cadastrar produtos.");

                    }
                    //deleta

                }    
            }
            if (textBox2.ReadOnly == false && textBox1.ReadOnly == false)
            {
                MessageBox.Show("Selecionar antes o código CFOP");
            }

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form gen = new Pesquisagenero();
            gen.ShowDialog();
        }
    }
}
