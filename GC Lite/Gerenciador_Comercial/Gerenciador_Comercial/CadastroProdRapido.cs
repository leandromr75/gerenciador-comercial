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
    public partial class CadastroProdRapido : Form
    {
        public CadastroProdRapido()
        {
            InitializeComponent();
        }
        string semaforo = "verde";
        private void textBox3_Leave(object sender, EventArgs e)
        {
            string MarGem = "";
            if (checkBox1.Checked == true)
            {
                textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                textBox3.Text = textBox3.Text.Replace(",", "");
                textBox3.Text = textBox3.Text.Replace(".", "");
                if (textBox3.Text.Length >= 3)
                {
                    string inteiro = textBox3.Text.Substring(0, textBox3.Text.Length - 2);
                    string fração = textBox3.Text.Substring(textBox3.Text.Length - 2, 2);

                    string virgula = ",";
                    textBox3.Text = inteiro + virgula + fração;
                }
                if (textBox3.Text.Length == 2)
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    textBox3.Text = textBox3.Text.Replace(",", "");
                    textBox3.Text = textBox3.Text.Replace(".", "");
                    textBox3.Text = textBox3.Text + ",00";
                }
                if (textBox3.Text.Length == 1)
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    if (textBox3.Text == ",")
                    {
                        textBox3.Text = "";
                        textBox3.Focus();
                    }
                    textBox3.Text = textBox3.Text + ",00";
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Focus();
                    return;
                }
                MarGem = Global.Margem.ConfiguraçãoSistemaFinanceiroMargem;
                decimal valorCusto = Convert.ToDecimal(textBox3.Text);
                string marg = "0," + MarGem.Replace(",", "");
                decimal margen = Convert.ToDecimal(marg);
                decimal num = 1;
                decimal divisor = num - margen;

                decimal venda = valorCusto / divisor;
                textBox4.Text = Convert.ToString(Math.Round(venda, 2));
            }
            if (checkBox1.Checked == false)
            {
                textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                textBox3.Text = textBox3.Text.Replace(",", "");
                textBox3.Text = textBox3.Text.Replace(".", "");
                if (textBox3.Text.Length >= 3)
                {
                    string inteiro = textBox3.Text.Substring(0, textBox3.Text.Length - 2);
                    string fração = textBox3.Text.Substring(textBox3.Text.Length - 2, 2);
                    string virgula = ",";
                    textBox3.Text = inteiro + virgula + fração;
                }
                if (textBox3.Text.Length == 2)
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    textBox3.Text = textBox3.Text.Replace(",", "");
                    textBox3.Text = textBox3.Text.Replace(".", "");
                    textBox3.Text = textBox3.Text + ",00";
                }
                if (textBox3.Text.Length == 1)
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    if (textBox3.Text == ",")
                    {
                        textBox3.Text = "";
                        textBox3.Focus();
                    }
                    textBox3.Text = textBox3.Text + ",00";
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Focus();
                    return;
                }
                MarGem = Global.Margem.ConfiguraçãoSistemaFinanceiroMargem;
                decimal valorCusto = Convert.ToDecimal(textBox3.Text);
                string marg = "1," + MarGem.Replace(",", "");
                decimal margen = Convert.ToDecimal(marg);
                decimal venda = valorCusto * margen;
                textBox4.Text = Convert.ToString(Math.Round(venda, 2));
            }
            textBox3.BackColor = System.Drawing.Color.White;
            button1.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string MarGem = "";
            if (checkBox1.Checked == true)
            {
                textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                textBox3.Text = textBox3.Text.Replace(",", "");
                textBox3.Text = textBox3.Text.Replace(".", "");
                if (textBox3.Text.Length >= 3)
                {
                    string inteiro = textBox3.Text.Substring(0, textBox3.Text.Length - 2);
                    string fração = textBox3.Text.Substring(textBox3.Text.Length - 2, 2);
                    string virgula = ",";
                    textBox3.Text = inteiro + virgula + fração;
                }
                if (textBox3.Text.Length == 2)
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    textBox3.Text = textBox3.Text.Replace(",", "");
                    textBox3.Text = textBox3.Text.Replace(".", "");
                    textBox3.Text = textBox3.Text + ",00";
                }
                if (textBox3.Text.Length == 1)
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    if (textBox3.Text == ",")
                    {
                        textBox3.Text = "";
                        textBox3.Focus();
                    }
                    textBox3.Text = textBox3.Text + ",00";
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Focus();
                    return;
                }
                MarGem = Global.Margem.ConfiguraçãoSistemaFinanceiroMargem;
                decimal valorCusto = Convert.ToDecimal(textBox3.Text);
                string marg = "0," + MarGem.Replace(",", "");
                decimal margen = Convert.ToDecimal(marg);
                decimal num = 1;
                decimal divisor = num - margen;

                decimal venda = valorCusto / divisor;
                textBox4.Text = Convert.ToString(Math.Round(venda, 2));
            }
            if (checkBox1.Checked == false)
            {
                textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                textBox3.Text = textBox3.Text.Replace(",", "");
                textBox3.Text = textBox3.Text.Replace(".", "");
                if (textBox3.Text.Length >= 3)
                {
                    string inteiro = textBox3.Text.Substring(0, textBox3.Text.Length - 2);
                    string fração = textBox3.Text.Substring(textBox3.Text.Length - 2, 2);
                    string virgula = ",";
                    textBox3.Text = inteiro + virgula + fração;
                }
                if (textBox3.Text.Length == 2)
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    textBox3.Text = textBox3.Text.Replace(",", "");
                    textBox3.Text = textBox3.Text.Replace(".", "");
                    textBox3.Text = textBox3.Text + ",00";
                }
                if (textBox3.Text.Length == 1)
                {
                    textBox3.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox3.Text);
                    if (textBox3.Text == ",")
                    {
                        textBox3.Text = "";
                        textBox3.Focus();
                    }
                    textBox3.Text = textBox3.Text + ",00";
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Focus();
                    return;
                }
                MarGem = Global.Margem.ConfiguraçãoSistemaFinanceiroMargem;
                decimal valorCusto = Convert.ToDecimal(textBox3.Text);
                string marg = "1," + MarGem.Replace(",", "");
                decimal margen = Convert.ToDecimal(marg);
                decimal venda = valorCusto * margen;
                textBox4.Text = Convert.ToString(Math.Round(venda, 2));
            }
        }

        private void CadastroProdRapido_Load(object sender, EventArgs e)
        {
            comboBox5.DataSource = DALCadastro.AUXCadListar("ListarCadUnidade");
            comboBox5.ValueMember = "Descrição";
            comboBox5.DisplayMember = "Descricao";
            comboBox5.SelectedItem = "";
            comboBox5.Refresh();
            Global.Margem.IDCadRapido = Convert.ToString(DALCadastro.Revisao());
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {

                Int64 qtde2;
                if (Int64.TryParse(textBox1.Text.Trim(), out qtde2) == false)
                {
                    MessageBox.Show("O campo Código EAN só aceita valores numéricos");
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;

                }
                if (textBox1.Text.Length < 5)
                {
                    MessageBox.Show("Formato EAN incorreto");
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false &&
                        String.IsNullOrEmpty(textBox4.Text) == false && String.IsNullOrEmpty(textBox5.Text) == false)
                {


                    DataTable testa = DALCadastro.produtoVenda(textBox1.Text);
                    if (testa.Rows.Count == 1)
                    {
                        MessageBox.Show("Existe produto cadastrado com este código de barras.\n" + testa.Rows[0]["DescInterna"].ToString());
                    }
                    if (testa.Rows.Count <= 0)
                    {
                        textBox3.Text = textBox3.Text.Replace(",", ".");
                        
                        textBox4.Text = textBox4.Text.Replace(",", ".");
                        
                        string emp = Global.Margem.EmpresaCaixa;
                        DALCadastro.CadProdRapido(textBox1.Text, comboBox5.Text, textBox2.Text, emp, textBox3.Text, textBox4.Text, textBox5.Text);
                        MessageBox.Show("Cadastrado com sucesso.");
                        Global.Margem.EANCadRapido = textBox1.Text;
                        Global.Margem.CadRapido = "EAN";
                        this.Close();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("Campos obrigatórios não foram preenchidos");
                    if (String.IsNullOrEmpty(textBox2.Text) == true)
                    {
                        textBox2.Focus();
                        return;
                    }
                    if (String.IsNullOrEmpty(textBox3.Text) == true)
                    {
                        textBox3.Focus();
                        return;
                    }
                    if (String.IsNullOrEmpty(textBox5.Text) == true)
                    {
                        textBox5.Focus();
                        return;
                    }
                    
                }
            }
            if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                string message = "Você deseja cadastrar produto sem código de barras?";
                string caption = "EAN";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.
                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    if (String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false &&
                        String.IsNullOrEmpty(textBox4.Text) == false && String.IsNullOrEmpty(textBox5.Text) == false )
                    {
                        DataTable tem =  DALCadastro.TemDesc(textBox2.Text);
                        if (tem.Rows.Count > 0)
                        {
                            MessageBox.Show("Existe cadastro com esta descrição interna.");
                            return;
                        }
                        else
                        {
                            textBox3.Text = textBox3.Text.Replace(",", ".");

                            textBox4.Text = textBox4.Text.Replace(",", ".");

                            string emp = Global.Margem.EmpresaCaixa;
                            DALCadastro.CadProdRapido(textBox1.Text, comboBox5.Text, textBox2.Text, emp, textBox3.Text, textBox4.Text, textBox5.Text);
                            MessageBox.Show("Cadastrado com sucesso.");
                            Global.Margem.CadRapido = "SemEAN";
                            this.Close();
                            return;      
                        }                    

                     }
                     else
                     {
                            MessageBox.Show("Campos obrigatórios não foram preenchidos");
                            if (String.IsNullOrEmpty(textBox2.Text) == true)
                            {
                                textBox2.Focus();
                                return;
                            }
                            if (String.IsNullOrEmpty(textBox3.Text) == true)
                            {
                                textBox3.Focus();
                                return;
                            }
                            if (String.IsNullOrEmpty(textBox5.Text) == true)
                            {
                                textBox5.Focus();
                                return;
                            }
                                
                        
                       

                    }
                }
                if (result == DialogResult.No)
                {
                    textBox1.Focus();
                    return;
                }
            }
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.Cyan;
            MessageBox.Show("Entre com código de barras");

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

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.BackColor = System.Drawing.Color.White;
        }

        private void CadastroProdRapido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text) == false)
            {
                Form mp = new MargemRapida();
                mp.ShowDialog();
                if (String.IsNullOrEmpty(Global.Margem.MargemPersonalizada) == false)
                {

                    string MarGem = Global.Margem.MargemPersonalizada;
                    if (checkBox1.Checked == true)
                    {                    
                       
                        decimal valorCusto = Convert.ToDecimal(textBox3.Text);
                        
                        if (MarGem.Length <= 2)
                        {
                            MarGem = "0," + MarGem.Replace(",", "");    
                        }
                        if (MarGem.Length == 3)
                        {
                            MessageBox.Show("Margem inversa não permitida acima de 99%");
                            Global.Margem.MargemPersonalizada = "";
                            return;
                        }
                        
                        decimal margen = Convert.ToDecimal(MarGem);
                        decimal num = 1;
                        decimal divisor = num - margen;

                        decimal venda = valorCusto / divisor;
                        textBox4.Text = Convert.ToString(Math.Round(venda, 2));
                    }
                    if (checkBox1.Checked == false)
                    {
                       
                        decimal valorCusto = Convert.ToDecimal(textBox3.Text);
                        if (MarGem.Length == 2)
                        {
                            MarGem = "1," + MarGem;
                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0,1) == "1")
                            {
                                MarGem = "2," + MarGem.Substring(1, 2);    
                            }
                            
                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "2")
                            {
                                MarGem = "3," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "3")
                            {
                                MarGem = "4," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "4")
                            {
                                MarGem = "5," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "5")
                            {
                                MarGem = "6," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "6")
                            {
                                MarGem = "7," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "7")
                            {
                                MarGem = "8," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "8")
                            {
                                MarGem = "9," + MarGem.Substring(1, 2);
                            }

                        } if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "9")
                            {
                                textBox4.ReadOnly = false;
                                textBox4.Text = "";
                                
                                MessageBox.Show("Favor digitar o valor de venda");
                                semaforo = "vermelho";
                                textBox4.Focus();
                                return;


                            }

                        }
                        MessageBox.Show(MarGem);
                        decimal margen = Convert.ToDecimal(MarGem);
                        decimal venda = valorCusto * margen;
                        textBox4.Text = Convert.ToString(Math.Round(venda, 2));
                    }
                    
                    
                }
                Global.Margem.MargemPersonalizada = "";
                textBox4.ReadOnly = true;
                
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (semaforo == "vermelho")
            {
                textBox4.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox4.Text);
                textBox4.Text = textBox4.Text.Replace(",", "");
                textBox4.Text = textBox4.Text.Replace(".", "");
                int qtde;
                if (Int32.TryParse(textBox4.Text.Trim(), out qtde) == false)
                {
                    MessageBox.Show("Formato incorreto para o valor da margem");
                    textBox4.Text = "";
                    textBox4.Focus();
                    return;

                }

                if (textBox4.Text.Length >= 3)
                {
                    string inteiro = textBox4.Text.Substring(0, textBox4.Text.Length - 2);
                    string fração = textBox4.Text.Substring(textBox4.Text.Length - 2, 2);

                    string virgula = ",";
                    textBox4.Text = inteiro + virgula + fração;
                }
                if (textBox4.Text.Length == 2)
                {
                    textBox4.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox4.Text);
                    textBox4.Text = textBox4.Text.Replace(",", "");
                    textBox4.Text = textBox4.Text.Replace(".", "");
                    textBox4.Text = textBox4.Text + ",00";
                }
                if (textBox4.Text.Length == 1)
                {
                    textBox4.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox4.Text);
                    if (textBox4.Text == ",")
                    {
                        textBox4.Text = "";
                        textBox4.Focus();
                    }
                    textBox4.Text = textBox4.Text + ",00";
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Focus();
                    return;
                }
                if (Convert.ToDecimal(textBox3.Text) > Convert.ToDecimal(textBox4.Text))
                {
                    MessageBox.Show("Valor de venda menor que o custo");
                    textBox4.Text = "";
                    textBox4.ReadOnly = true;
                    textBox4.Focus();
                    semaforo = "verde";
                }
                else
                {
                    semaforo = "verde";
                    textBox4.ReadOnly = true;
                }
            }
        }
    }
}
