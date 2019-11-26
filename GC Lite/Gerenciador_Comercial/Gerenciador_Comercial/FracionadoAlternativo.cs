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
    public partial class FracionadoAlternativo : Form
    {
        string codigo = "";
        public FracionadoAlternativo(string cod)
        {
            InitializeComponent();
            codigo = cod;
            dataGridView1.DataSource = DALCadastro.FracionadoAlternativo(codigo);
        }
        
        private void FracionadoAlternativo_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false)
            {

                textBox3.Text = textBox3.Text.Replace(".", ",");
                decimal preço;
                if (Decimal.TryParse(textBox3.Text.Trim(), out preço) == false)
                {
                    MessageBox.Show("O campo peso Preço/KG está em formato incorreto");
                    textBox3.Text = "";
                    textBox3.Focus();
                    return;
                }
                Int64 ean;
                if (Int64.TryParse(textBox2.Text.Trim(), out ean) == false)
                {
                    MessageBox.Show("O campo código da balança está em formato incorreto");
                    textBox2.Text = "";
                    textBox2.Focus();
                    return;
                }
                if (label5.Text == "Editando")
                {
                    DALCadastro.EditaFracionadoAlternativo(textBox2.Text,textBox1.Text,textBox3.Text);
                    label5.Text = "";
                    textBox1.ReadOnly = true;
                    textBox3.ReadOnly = true;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    dataGridView1.DataSource = DALCadastro.FracionadoAlternativo(codigo);
                }
                else
                {
                    if (String.IsNullOrEmpty(textBox2.Text) == false)
                    {
                        if (textBox2.Text.Length == 13)
                        {
                            //string ean = "2000030001808";
                            string codigo2 = textBox2.Text.Substring(1, 5);
                            textBox2.Text = codigo2;
                            



                        }
                        if (textBox2.Text.Length != 5 && textBox2.Text.Length != 13)
                        {
                            MessageBox.Show("O formato padrão para integrar com a balança é EAN 13 \nou o código de 5 digitos.");
                            textBox2.Text = "";
                            textBox2.Focus();
                            
                            return;
                        }

                    }
                    String recebe = Convert.ToString(DALCadastro.TemEAN(textBox2.Text));
                    if (String.IsNullOrEmpty(recebe) == false)
                    {
                        DataTable testa = DALCadastro.produtoVenda(textBox2.Text);
                        if (testa.Rows.Count == 1)
                        {
                            MessageBox.Show("Existe cadastro com este código de barras.\n" + testa.Rows[0]["DescInterna"].ToString() + "\n==> Id produto: " +
                                testa.Rows[0]["IdProd"].ToString());
                            textBox2.Text = "";
                            textBox2.Focus();
                            return;
                        }
                    }
                    String recebe2 = Convert.ToString(DALCadastro.TemCodBalança(textBox2.Text));
                    if (String.IsNullOrEmpty(recebe2) == false)
                    {
                        DataTable testa2 = DALCadastro.ListaFracionadoAlternativo();

                        DataTable testa3 = DALCadastro.produtoVenda(testa2.Rows[0]["Cod_Principal"].ToString());
                        MessageBox.Show("Existe cadastro de peso por KG alternativo com este código da balança.\n" + testa2.Rows[0]["Descrição"].ToString() + "\nPreço por KG : " +
                            testa2.Rows[0]["Preço"].ToString() + "\n\nLigado ao código principal : " + testa2.Rows[0]["Cod_Principal"].ToString() +
                            "\n" + testa3.Rows[0]["DescInterna"].ToString());
                        textBox2.Text = "";
                        textBox2.Focus();
                        return;   
                        
                    }
                    DALCadastro.CriaFracionadoAlternativo(codigo, textBox2.Text, textBox1.Text, textBox3.Text);
                    dataGridView1.DataSource = DALCadastro.FracionadoAlternativo(codigo);
                    label5.Text = "";
                    textBox1.ReadOnly = true;
                    textBox3.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    
                }
            }
            else
            {
                MessageBox.Show("Campos obrigatórios não foram preenchidos");
                if (String.IsNullOrEmpty(textBox1.Text) == true)
                {
                    textBox1.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox2.Text) == true)
                {
                    textBox2.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Focus();
                    
                }
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            textBox1.ReadOnly = false;
            textBox3.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                label4.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false)
            {
                label5.Text = "Editando";
                textBox1.ReadOnly = false;
                textBox3.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Selecione um registro para edição");
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

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.Color.White;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.BackColor = System.Drawing.Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = "Você deseja excluír o código vinculado da balança -> " + textBox2.Text + " ?";
            string caption = "Exclusão Preço/KG alternativo";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (textBox2.ReadOnly == true && String.IsNullOrEmpty(textBox1.Text) == false &&
                String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false)
                {
                    DALCadastro.ExcluiFracionadoAlternativo(textBox2.Text);
                    dataGridView1.DataSource = DALCadastro.FracionadoAlternativo(codigo);
                    MessageBox.Show("Código : " + textBox2.Text + " excluído com sucesso.");
                    label5.Text = "";
                    textBox1.ReadOnly = true;
                    textBox3.ReadOnly = true;
                    textBox2.ReadOnly = true;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }

            
        }
    }
}
