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
    public partial class AUXCadEmpresa : Form
    {
        public AUXCadEmpresa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.ReadOnly == false && String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text))
            {
                bool jaexiste = false;
                bool controle = false;
                if (dataGridView1.Rows.Count > 0)
                {
                   
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {


                            if (controle == false)
                            {
                                if (textBox1.Text == dataGridView1.Rows[i].Cells[1].Value.ToString() ||
                                    textBox2.Text == dataGridView1.Rows[i].Cells[2].Value.ToString() ) 
                                {
                                    MessageBox.Show("Já existe este cadastro!");
                                    jaexiste = true;
                                    controle = true;
                                }
                            }
                        

                        }
                    
                }
                if (jaexiste == false)
                {
                    string message = "Você deseja cadastrar esta Empresa: \n" + textBox1.Text + " ?";
                    string caption = "Empresa";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        string Stored = "CriarCadEmpresa";

                        DALCadastro.AUXCadCriarEmpresa(Stored, textBox1.Text, textBox2.Text);
                        dataGridView1.DataSource = DALCadastro.AUXCadListar("ListarCadEmpresa");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.ReadOnly = true;
                        textBox2.ReadOnly = true;
                        label3.Text = "";
                    }
                }
            }
            
                    
        }

        private void AUXCadEmpresa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.AUXCadListar("ListarCadEmpresa");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox2.TextLength == 2)
            {
                textBox2.Text = textBox2.Text + ".";
                textBox2.Select(textBox2.Text.Length, 0);
            }
            if (textBox2.TextLength == 6)
            {
                textBox2.Text = textBox2.Text + ".";
                textBox2.Select(textBox2.Text.Length, 0);
            }
            if (textBox2.TextLength == 10)
            {
                textBox2.Text = textBox2.Text + "/";
                textBox2.Select(textBox2.Text.Length, 0);
            }
            if (textBox2.TextLength == 15)
            {
                textBox2.Text = textBox2.Text + "-";
                textBox2.Select(textBox2.Text.Length, 0);
            }
            if (textBox2.TextLength == 18)
            {

                string temp = Ferramentas.Retira_Meta(textBox2.Text);
                bool teste = Ferramentas.IsCnpj(temp);
                if (teste == false)
                {
                    MessageBox.Show("CNPJ em formato incorreto");
                    textBox2.Text = "";
                    textBox2.Focus();

                }
                if (teste == true)
                {
                    textBox2.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox2.Text = "";
            textBox1.Text = "";
            label3.Text = "";
            textBox1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                label3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
            }
        }
            
        

    }
}
