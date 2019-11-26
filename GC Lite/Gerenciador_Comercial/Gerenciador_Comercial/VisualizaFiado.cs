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
    public partial class VisualizaFiado : Form
    {
        public VisualizaFiado()
        {
            InitializeComponent();
        }

        private void VisualizaFiado_Load(object sender, EventArgs e)
        {
            this.Text += " Cliente : " + Global.Margem.ClienteFiado;
            comboBox1.Text = "dinheiro";
            dataGridView1.DataSource = DALCadastro.FluxoVendaFiado(Global.Margem.ClienteFiado);
            textBox3.Text = "0,00";
            textBox1.Text = "0,00";
            textBox2.Text = "0,00";
            DataTable parcial = DALCadastro.ListaParcial(Global.Margem.ClienteFiado);
            if (parcial.Rows.Count > 0)
            {
                decimal so = 0;
                for (int i = 0; i < parcial.Rows.Count; i++)
                {
                    so = so + Convert.ToDecimal(Convert.ToDecimal(parcial.Rows[i]["Total_Devedor"].ToString()) - Convert.ToDecimal(parcial.Rows[i]["Valor_Parcial"].ToString()));
                }
                textBox1.Text = Convert.ToString(so);
                if (dataGridView1.Rows.Count <= 0)
                {
                    textBox3.Text = textBox1.Text;
                    textBox2.Text = "0,00";
                }
            }
            if (dataGridView1.Rows.Count > 0)
            {
                decimal soma = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    soma = soma + Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                }
                textBox2.Text = Convert.ToString(soma);
                textBox3.Text = Convert.ToString(soma + Convert.ToDecimal(textBox1.Text));
            }    
           
        }
       
        private void VisualizaFiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            
                if (dataGridView1.Rows.Count > 0 || Convert.ToDecimal(textBox1.Text) > 0)
                {
                    string ven = "";
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        ven += dataGridView1.Rows[i].Cells[6].Value.ToString() + "|";
                    }
                    Global.Margem.BaixaVendasFiado = ven;
                    Global.Margem.SaldoDevedorFiado = textBox3.Text;
                    Global.Margem.CompraAtual = textBox2.Text;
                    Global.Margem.QuitafiadoPag = comboBox1.Text;
                    this.Close();
                    Form fin = new QuitaFiado();
                    fin.ShowDialog();    
                }
                else
                {
                    MessageBox.Show("Não existem pendências para este cliente");
                    return;
                }
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form hist = new HistoricoComprasFiado();
            hist.ShowDialog();
            
        }

       

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Form fi = new MostraParcial();
            fi.ShowDialog();
            comboBox1.Text = "dinheiro";
            dataGridView1.DataSource = DALCadastro.FluxoVendaFiado(Global.Margem.ClienteFiado);
            textBox3.Text = "0,00";
            textBox1.Text = "0,00";
            textBox2.Text = "0,00";
            DataTable parcial = DALCadastro.ListaParcial(Global.Margem.ClienteFiado);
            if (parcial.Rows.Count > 0)
            {
                decimal so = 0;
                for (int i = 0; i < parcial.Rows.Count; i++)
                {
                    so = so + Convert.ToDecimal(Convert.ToDecimal(parcial.Rows[i]["Total_Devedor"].ToString()) - Convert.ToDecimal(parcial.Rows[i]["Valor_Parcial"].ToString()));
                }
                textBox1.Text = Convert.ToString(so);
                if (dataGridView1.Rows.Count <= 0)
                {
                    textBox3.Text = textBox1.Text;
                    textBox2.Text = "0,00";
                }
            }
            if (dataGridView1.Rows.Count > 0)
            {
                decimal soma = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    soma = soma + Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                }
                textBox2.Text = Convert.ToString(soma);
                textBox3.Text = Convert.ToString(soma + Convert.ToDecimal(textBox1.Text));
            }    
           
        }
        
        
    }
}
