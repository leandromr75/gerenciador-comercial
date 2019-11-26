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
    public partial class AUXCadGenero : Form
    {
        public AUXCadGenero()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly == false && String.IsNullOrEmpty(textBox1.Text) == false && 
                String.IsNullOrEmpty(textBox2.Text) == false && textBox2.ReadOnly == false)
            {
                Int64 qtde;
                if (Int64.TryParse(textBox2.Text.Trim(), out qtde) == false)
                {
                    MessageBox.Show("Favor informar somente valores numéricos no campo \ncódigo NCM.");
                    textBox2.Text = "";
                    textBox2.Focus();
                    return;
                }
                DataTable ncm = DALCadastro.AUXCadListar("ListarCadGenero");
                if (ncm.Rows.Count > 0)
                {
                    for (int i = 0; i < ncm.Rows.Count; i++)
                    {
                        if (textBox2.Text == ncm.Rows[i]["Codigo"].ToString())
                        {
                            MessageBox.Show("Código já cadastrado anteriormente.");
                            return;
                        }                  
                        
                    }
                    string message = "Você deseja cadastrar este Código de Gênero : \n" + textBox2.Text + " ?";
                    string caption = "Gênero";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        DALCadastro.CriarCadGenero(textBox2.Text, textBox1.Text);
                        dataGridView1.DataSource = DALCadastro.AUXCadListar("ListarCadGenero");
                        MessageBox.Show("Código : " + textBox2.Text + "\n" + textBox1.Text + "\nincluído com sucesso.");
                        string cod = textBox2.Text;
                        textBox1.ReadOnly = true;
                        textBox1.Text = "";
                        textBox2.ReadOnly = true;
                        textBox2.Text = "";
                        if (dataGridView1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[0].Value.ToString() == cod)
                                {
                                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                                    textBox2.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                                    textBox1.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                                    button4.Focus();
                                    return;
                                }
                            }
                        }

                    }
                }
                if (ncm.Rows.Count <= 0)
                {
                    string message = "Você deseja cadastrar este Código de Gênero : \n" + textBox2.Text + " ?";
                    string caption = "Gênero";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.
                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        DALCadastro.CriarCadGenero(textBox2.Text, textBox1.Text);
                        dataGridView1.DataSource = DALCadastro.AUXCadListar("ListarCadGenero");
                        MessageBox.Show("Código : " + textBox2.Text + "\n" + textBox1.Text + "\nincluído com sucesso.");
                        textBox1.ReadOnly = true;
                        textBox1.Text = "";
                        textBox2.ReadOnly = true;
                        textBox2.Text = "";
                                               
                    }
                }
            }
        }

        private void AUXCadGenero_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.AUXCadListar("ListarCadGenero");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form gen = new Pesquisagenero();
            gen.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();

                Global.Margem.generoTemp = textBox2.Text;
                Global.Margem.generoTemp2 = textBox1.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox2.Text = "";
            textBox1.Text = "";
           
            textBox2.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) == false && textBox2.ReadOnly == true && textBox2.Text != "SELECIONAR")
            {
                string resul = Convert.ToString(DALCadastro.ProcuraAUXCad("ExcluiCadAUXGenero", textBox2.Text));
                if (String.IsNullOrEmpty(resul) == false)
                {
                    MessageBox.Show("Gênero não pode ser excluído, porque existem produtos cadastrados que o utilizam");
                    textBox2.Text = "";
                    textBox2.ReadOnly = true;
                    
                }
                if (String.IsNullOrEmpty(resul) == true)
                {
                    string message = "Você deseja excluír o Gênero ==> " + textBox2.Text;
                    string caption = "Exclusão";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Mostra a MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        DALCadastro.ExcluiCadAUX("ExcluiGenero", textBox2.Text);
                        MessageBox.Show("Código : " + textBox2.Text + "\n" + textBox1.Text + "\nexcluído com sucesso.");
                        dataGridView1.DataSource = DALCadastro.AUXCadListar("ListarCadGenero");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro para exclusão");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.Color.White;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.White;
        }

    }
}
