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
    public partial class AuxCadEstoque : Form
    {
        public AuxCadEstoque()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Checked = false;
            }
            textBox12.Focus();
        
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
            }
            textBox12.Focus();
        }

        private void AuxCadEstoque_Load(object sender, EventArgs e)
        {
            textBox1.Text = Global.Margem.Operador;
            dataGridView3.DataSource = DALCadastro.AUXCadListar("ListarCadEmpresa");
            textBox6.Text = Global.Margem.IdProdSAT;
            textBox10.Text = Global.Margem.xProd;

            textBox13.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" +
                DateTime.Now.Year.ToString();

            textBox7.Text = Global.Margem.EstoqueCusto;
            textBox8.Text = Global.Margem.EstoqueValor;
            textBox9.Text = Global.Margem.EstoqueQtde;
            textBox11.Text = Global.Margem.EstoqueUnd;

        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            textBox12.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            textBox12.BackColor = System.Drawing.Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkBox1.Checked == false && checkBox2.Checked == false && String.IsNullOrEmpty(textBox12.Text) == false)
            {
                MessageBox.Show("É necessário informar se a operação é de entrada ou saída ");
                return;
            }
            else
            {
                Int64 qtde;
                if (Int64.TryParse(textBox12.Text.Trim(), out qtde) == false)
                {
                    MessageBox.Show("Favor informar somente valores numéricos");
                    textBox12.Focus();
                    return;
                }
                else
                {
                    Global.Margem.EstoqueQtde = textBox12.Text;
                    if (Global.Margem.TemCad == "não")
                    {
                        if (checkBox1.Checked == true)
                        {
                            
                            
                            Global.Margem.EstoqueQtde = Convert.ToString(textBox12.Text);
                            this.Close();
                        }
                        if (checkBox2.Checked == true)
                        {
                            MessageBox.Show("Como o cadastro do Produto está em formação, só é permitido movimento de entrada");
                            return;
                        }    
                    }
                    else
                    {
                        if (checkBox1.Checked == true)
                        {
                            int total = Convert.ToInt32(textBox9.Text) + Convert.ToInt32(textBox12.Text);
                            DALCadastro.Qtde_Produto(Convert.ToInt32(textBox6.Text), total);
                            MessageBox.Show("Quantidade alterada com sucesso.\nEstoque atual :" + total + " ," + textBox11.Text);
                            Global.Margem.EstoqueQtde = Convert.ToString(total);
                            this.Close();
                        }
                        if (checkBox2.Checked == true)
                        {
                            if (Convert.ToInt32(textBox9.Text) >= Convert.ToInt32(textBox12.Text))
                            {
                                int total = Convert.ToInt32(textBox9.Text) - Convert.ToInt32(textBox12.Text);
                                DALCadastro.Qtde_Produto(Convert.ToInt32(textBox6.Text), total);
                                MessageBox.Show("Quantidade alterada com sucesso.\nEstoque atual :" + total + " ," + textBox11.Text);
                                Global.Margem.EstoqueQtde = Convert.ToString(total);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Qtde de saída informada não pode ser maior do que estoque disponível.");

                                return;
                            }
                        }
                    }

                           
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                textBox2.Text = dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            }
        }
    }
}
