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
    public partial class ProcurarPDV : Form
    {
        public ProcurarPDV()
        {
            InitializeComponent();
        }

        private void ProcurarPDV_Load(object sender, EventArgs e)
        {
            this.Text = "Localizar Produtos / Clientes. Operador ==> " + Global.Margem.Operador;
        }

        private void ProcurarPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    textBox4.Text = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                    textBox4.Focus();
                }
                else
                {
                    MessageBox.Show("Selecione um Cliente");
                }
            }
            if (e.KeyCode == Keys.F2)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                    textBox3.Focus();
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.F10)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    textBox1.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox1.Text);
                    textBox1.Text = textBox1.Text.Replace(",", "");
                    textBox1.Text = textBox1.Text.Replace(".", "");
                    Int64 qtde;
                    if (Int64.TryParse(textBox1.Text.Trim(), out qtde) == false)
                    {
                        MessageBox.Show("Insira somente valores numéricos");
                        textBox1.Text = "";
                        textBox1.Focus();
                        return;

                    }
                    if (textBox1.Text.Length == 13)
                    {
                        dataGridView1.DataSource = DALCadastro.ProcurarProdutoCodeBar(textBox1.Text);
                        textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                        textBox3.Focus();
                        //dataGridView1.Focus();
                        return;
                    }
                    dataGridView1.DataSource = DALCadastro.ProcurarProdutoSemCodeBarId(textBox1.Text);
                    if (dataGridView1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Columns[1].Width = 330;
                            textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                            textBox3.Focus();
                        }
                        dataGridView1.Focus();
                        return;
                    }
                   

                }
            }
            if (e.KeyCode == Keys.F12)
            {
                if (String.IsNullOrEmpty(textBox2.Text) == false)
                {

                    dataGridView1.DataSource = DALCadastro.ProcurarProdutoSemCodeBarDescInt(textBox2.Text + "%");
                    if (dataGridView1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Columns[1].Width = 330;
                            textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                            textBox3.Focus();
                        }
                    }
                    if (dataGridView1.Rows.Count <= 0)
                    {
                        MessageBox.Show("Produto inexistente");
                        textBox2.Text = "";
                        textBox2.Focus();
                    }
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                Form cadRapido = new CadastroProdRapido();
                cadRapido.ShowDialog();
            }
            if (e.KeyCode == Keys.F7)
            {
                 dataGridView2.DataSource = DALCadastro.ListaClienteFiado();
                 if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Columns[0].Width = 330;
                    }
                }
            }
            if (e.KeyCode == Keys.F9)
            {
                Form cadFiado = new ClienteFiado();
                cadFiado.ShowDialog();
                dataGridView2.DataSource = DALCadastro.ListaClienteFiado();
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        dataGridView2.Columns[0].Width = 330;
                    }
                }
            }
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                textBox1.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox1.Text);
                textBox1.Text = textBox1.Text.Replace(",", "");
                textBox1.Text = textBox1.Text.Replace(".", "");
                Int64 qtde;
                if (Int64.TryParse(textBox1.Text.Trim(), out qtde) == false)
                {
                    MessageBox.Show("Insira somente valores numéricos");
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;

                }
                if (textBox1.Text.Length == 13)
                {
                    dataGridView1.DataSource = DALCadastro.ProcurarProdutoCodeBar(textBox1.Text);
                    textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    textBox3.Focus();
                    button1.Focus();
                    //dataGridView1.Focus();
                    return;
                }
                else
                {
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = DALCadastro.ProcurarProdutoSemCodeBarId(textBox1.Text);
                    if (dataGridView1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Columns[1].Width = 330;
                            textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                            textBox3.Focus();
                        }
                        
                    }
                }
                button1.Focus();
                
                
                
                    
                
                
                

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) == false)
            {
                
                dataGridView1.DataSource = DALCadastro.ProcurarProdutoSemCodeBarDescInt("%" + textBox2.Text + "%");
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Columns[1].Width = 330;
                        //textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                        
                        textBox3.Focus();
                    }
                }
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("Produto inexistente");
                    textBox2.Text = "";
                    textBox2.Focus();
                }
            }
            button1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                textBox3.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox3.Text) == false)
            {

                Global.Margem.RetornarID = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                Global.Margem.RetornarIDaviso = "achei";
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (textBox3.Text == dataGridView1.Rows[i].Cells[1].Value.ToString())
                        {
                            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Preço" || dataGridView1.Rows[i].Cells[5].Value.ToString() == "Peso")
                            {
                                Global.Margem.PreçoManual = "sim";
                                this.Close();
                            }
                            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "não" || dataGridView1.Rows[i].Cells[5].Value.ToString() == "")
                            {
                                Global.Margem.PreçoManual = "";
                                this.Close();
                            }
                            
                        }
                    }
                    this.Close();
                }               
                
            }
            else
            {
                MessageBox.Show("Selecione o Produto");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DALCadastro.ListaClienteFiado();
            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    dataGridView2.Columns[0].Width = 330;
                }
            }
            dataGridView2.Focus();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                textBox4.Text = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                textBox4.Focus();
                button4.Focus();
            }
            else
            {
                MessageBox.Show("Selecione um Cliente");
            }
                        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox4.Text) == false)
            {
                Global.Margem.ClienteFiado = textBox4.Text;
                Form fiado = new VisualizaFiado();
                fiado.ShowDialog();
                Global.Margem.ClienteFiado = "";
            }
            else
            {
                MessageBox.Show("Selecione um Cliente");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form cadFiado = new ClienteFiado();
            cadFiado.ShowDialog();
            dataGridView2.DataSource = DALCadastro.ListaClienteFiado();
            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    dataGridView2.Columns[0].Width = 330;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form cadRapido = new CadastroProdRapido();
            cadRapido.ShowDialog();
            if (Global.Margem.CadRapido == "EAN")
            {
                dataGridView1.DataSource = DALCadastro.ProcurarProdutoCodeBar(Global.Margem.EANCadRapido);
                textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Focus();
                
            }
            if (Global.Margem.CadRapido == "SemEAN")
            {
                dataGridView1.DataSource = DALCadastro.ProcurarProdutoSemCodeBarId(Global.Margem.IDCadRapido);
                textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox3.Focus();
            }
            Global.Margem.CadRapido = "";
            Global.Margem.EANCadRapido = "";
            Global.Margem.IDCadRapido = "";
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Columns[1].Width = 330;
                    textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    textBox3.Focus();
                }
                //dataGridView1.Focus();
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    textBox1.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox1.Text);
                    textBox1.Text = textBox1.Text.Replace(",", "");
                    textBox1.Text = textBox1.Text.Replace(".", "");
                    Int64 qtde;
                    if (Int64.TryParse(textBox1.Text.Trim(), out qtde) == false)
                    {
                        MessageBox.Show("Insira somente valores numéricos");
                        textBox1.Text = "";
                        textBox1.Focus();
                        return;

                    }
                    if (textBox1.Text.Length == 13)
                    {
                        dataGridView1.DataSource = DALCadastro.ProcurarProdutoCodeBar(textBox1.Text);
                        textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                        textBox3.Focus();
                        //dataGridView1.Focus();
                        button1.Focus();
                        return;
                    }
                    else
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = DALCadastro.ProcurarProdutoSemCodeBarId(textBox1.Text);
                        if (dataGridView1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                dataGridView1.Columns[1].Width = 330;
                                textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                                textBox3.Focus();
                            }

                        }
                    }
                    button1.Focus();
                }
                
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
            {
                if (String.IsNullOrEmpty(textBox2.Text) == false)
                {

                    dataGridView1.DataSource = DALCadastro.ProcurarProdutoSemCodeBarDescInt("%" + textBox2.Text + "%");
                    if (dataGridView1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Columns[1].Width = 330;
                            //textBox3.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();

                            textBox3.Focus();
                        }
                    }
                    if (dataGridView1.Rows.Count <= 0)
                    {
                        MessageBox.Show("Produto inexistente");
                        textBox2.Text = "";
                        textBox2.Focus();
                    }
                }
                button1.Focus();
            }
            
        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            string s = e.KeyData.ToString();
            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (dataGridView2.Rows[i].Cells[0].Value.ToString().Substring(0,1) == s)
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[0];

                    }
                }
                
            }
            
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            string s = e.KeyData.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 1) == s)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                    }
                }

            }
        }
    }
}
