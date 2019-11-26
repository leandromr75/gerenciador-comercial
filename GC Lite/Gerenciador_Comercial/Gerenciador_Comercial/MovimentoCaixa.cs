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
    public partial class MovimentoCaixa : Form
    {
        public MovimentoCaixa()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            label6.Text = "Data selecionada : " + monthCalendar1.SelectionStart.Date.ToShortDateString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form formPrincipal = new TelaPrincipal();
            GerenciadorDeFormulario.Abre(formPrincipal);
            GerenciadorDeFormulario.Fecha(this);
        }

        private void MovimentoCaixa_Load(object sender, EventArgs e)
        {
            DataTable cor = DALCadastro.CoresRetorna(Global.Margem.Operador);
            this.Text += " ==> Operador: " + Global.Margem.Operador;
            if (cor.Rows.Count > 0)
            {
                DataTable cor10 = DALCadastro.CoresRetorna(Global.Margem.Operador);
                if (cor10.Rows.Count > 0)
                {
                    panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["CorMenu"].ToString()));
                    panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor2"].ToString()));
                }
                else
                {
                    DataTable cor2 = DALCadastro.CoresRetorna("Default");
                    if (cor2.Rows.Count > 0)
                    {
                        panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["CorMenu"].ToString()));
                        panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor2"].ToString()));
                    }
                }         
            }
                 
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            groupBox2.BackColor = System.Drawing.Color.GreenYellow;
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            groupBox2.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            groupBox5.BackColor = System.Drawing.Color.GreenYellow;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            groupBox5.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            groupBox4.BackColor = System.Drawing.Color.GreenYellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            groupBox4.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            groupBox3.BackColor = System.Drawing.Color.GreenYellow;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            dataGridView1.DataSource = null; 
            
            if (String.IsNullOrEmpty(label6.Text) == false)
            {
                decimal soma = 0;
                int cont = 0;
                dataGridView1.DataSource = DALCadastro.FluxoVendaTudo(monthCalendar1.SelectionStart.Date.ToShortDateString());
                if (dataGridView1.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string prazo1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        if (prazo1 == "a prazo")
                        {
                            cont++;
                        }
                        if (prazo1 == "a prazo_parcial")
                        {
                            cont++;
                        }
                        if (prazo1 == "Pagamento Misto")
                        {
                            cont++;
                        }
                        if (cont == 0)
                        {
                            soma += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            dataGridView1.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.Cyan;
                        }
                        cont = 0;
                    }
                    textBox3.Text = Convert.ToString(soma);
                }
                textBox3.Text = Convert.ToString(soma);
                dataGridView2.DataSource = DALCadastro.ListaAUXVendas(monthCalendar1.SelectionStart.Date.ToShortDateString());
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Fiado Parcial" || dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Misto")
                        {
                            soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                            dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                        }
                        else
                        {
                            if (checkBox1.Checked == true)
                            {
                                
                                if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Saldo Inicial")
                                {
                                    soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                                else
                                {
                                    soma = soma - Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Coral;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                            }
                        }
                        
                    }
                }
                textBox3.Text = Convert.ToString(soma);
            }
            else
            {
                MessageBox.Show("Selecione uma Data");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBox3.Text = "";
            if (String.IsNullOrEmpty(label6.Text) == false)
            {
                decimal soma = 0;
                int cont = 0;
                dataGridView1.DataSource = DALCadastro.FluxoVendaTudoPag5(monthCalendar1.SelectionStart.Date.ToShortDateString());
                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string prazo1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        if (prazo1 == "a prazo")
                        {
                            cont++;
                        }
                        if (prazo1 == "a prazo_parcial")
                        {
                            cont++;
                        }
                        if (prazo1 == "Pagamento Misto")
                        {
                            cont++;
                        }
                        if (cont == 0)
                        {
                            soma += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            dataGridView1.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.Cyan;
                        }
                        cont = 0;
                    }
                    textBox3.Text = Convert.ToString(soma);
                }
                dataGridView2.DataSource = DALCadastro.ListaAUXVendas(monthCalendar1.SelectionStart.Date.ToShortDateString());
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        string fp = dataGridView2.Rows[i].Cells[5].Value.ToString();
                        if (String.IsNullOrEmpty(fp) == false)
                        {
                            if (fp == "Pagamento Fiado Parcial")
                            {
                                soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                            }
                        }                 
                        else
                        {
                            if (checkBox1.Checked == true)
                            {
                                if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Saldo Inicial" )
                                {
                                    soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                                else
                                {
                                    soma = soma - Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Coral;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                            }
                        }
                    } 
                }
                textBox3.Text = Convert.ToString(soma);
           
            }
            else
            {
                MessageBox.Show("Selecione uma Data");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBox3.Text = "";
            if (String.IsNullOrEmpty(label6.Text) == false)
            {
                decimal soma = 0;
                int cont = 0;
                dataGridView1.DataSource = DALCadastro.FluxoVendaTudoPag(monthCalendar1.SelectionStart.Date.ToShortDateString(), "cartão de crédito");
                if (dataGridView1.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string prazo1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        if (prazo1 == "a prazo")
                        {
                            cont++;
                        }
                        if (prazo1 == "a prazo_parcial")
                        {
                            cont++;
                        }
                        if (prazo1 == "Pagamento Misto")
                        {
                            cont++;
                        }
                        if (cont == 0)
                        {
                            soma += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            dataGridView1.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.Cyan;
                        }
                        cont = 0;
                    }
                    textBox3.Text = Convert.ToString(soma);
                }
                dataGridView2.DataSource = DALCadastro.ListaAUXVendas(monthCalendar1.SelectionStart.Date.ToShortDateString());
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {

                        if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Fiado Parcial" || dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Misto")
                        {
                            if (dataGridView2.Rows[i].Cells[4].Value.ToString() == "cartão de crédito")
                            {
                                soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                            }
                        }
                        else
                        {
                            if (checkBox1.Checked == true)
                            {
                                if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Saldo Inicial")
                                {
                                    soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                                else
                                {
                                    soma = soma - Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Coral;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                            }
                        }
                    }
                }
                textBox3.Text = Convert.ToString(soma);
           
            }
            else
            {
                MessageBox.Show("Selecione uma Data");
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBox3.Text = "";
            if (String.IsNullOrEmpty(label6.Text) == false)
            {
                decimal soma = 0;
                int cont = 0;
                dataGridView1.DataSource = DALCadastro.FluxoVendaTudoPag(monthCalendar1.SelectionStart.Date.ToShortDateString(), "cartão de débito");
                if (dataGridView1.Rows.Count > 0)
                {
               
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string prazo1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        if (prazo1 == "a prazo")
                        {
                            cont++;
                        }
                        if (prazo1 == "a prazo_parcial")
                        {
                            cont++;
                        }
                        if (prazo1 == "Pagamento Misto")
                        {
                            cont++;
                        }
                        if (cont == 0)
                        {
                            soma += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            dataGridView1.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.Cyan;
                        }
                        cont = 0;
                    }
                    textBox3.Text = Convert.ToString(soma);
                }
                dataGridView2.DataSource = DALCadastro.ListaAUXVendas(monthCalendar1.SelectionStart.Date.ToShortDateString());
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {

                        if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Fiado Parcial" || dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Misto")
                        {
                            if (dataGridView2.Rows[i].Cells[4].Value.ToString() == "cartão de débito")
                            {
                                soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                            }
                        }
                        else
                        {
                            if (checkBox1.Checked == true)
                            {
                                if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Saldo Inicial")
                                {
                                    soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                                else
                                {
                                    soma = soma - Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Coral;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                            }
                        }
                    }
                }
                textBox3.Text = Convert.ToString(soma);
           
            }
            else
            {
                MessageBox.Show("Selecione uma Data");
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBox3.Text = "";
            if (String.IsNullOrEmpty(label6.Text) == false)
            {
                decimal soma = 0;
                int cont = 0;
                dataGridView1.DataSource = DALCadastro.FluxoVendaTudoPag(monthCalendar1.SelectionStart.Date.ToShortDateString(), "dinheiro");

                if (dataGridView1.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string prazo1 = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        if (prazo1 == "a prazo")
                        {
                            cont++;
                        }
                        if (prazo1 == "a prazo_parcial")
                        {
                            cont++;
                        }
                        if (prazo1 == "Pagamento Misto")
                        {
                            cont++;
                        }
                        if (cont == 0)
                        {
                            soma += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            dataGridView1.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.Cyan;
                        }
                        cont = 0;
                    }
                    textBox3.Text = Convert.ToString(soma);    
                }
                dataGridView2.DataSource = DALCadastro.ListaAUXVendas(monthCalendar1.SelectionStart.Date.ToShortDateString());
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {

                        if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Fiado Parcial" || dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Misto")
                        {
                            if (dataGridView2.Rows[i].Cells[4].Value.ToString() == "dinheiro")
                            {
                                soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                            }
                        }
                        else
                        {
                            if (checkBox1.Checked == true)
                            {
                                if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Saldo Inicial")
                                {
                                    soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                                else
                                {
                                    soma = soma - Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Coral;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                            }
                            
                        }
                    }
                }
                textBox3.Text = Convert.ToString(soma);
           
            }
            else
            {
                MessageBox.Show("Selecione uma Data");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBox3.Text = "";
            if (String.IsNullOrEmpty(label6.Text) == false)
            {
                decimal soma = 0;
                int cont = 0;
                dataGridView1.DataSource = DALCadastro.FluxoVendaTudoPag(monthCalendar1.SelectionStart.Date.ToShortDateString(), "cheque");
                if (dataGridView1.Rows.Count > 0)
                {
                    
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string prazo1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        if (prazo1 == "a prazo")
                        {
                            cont++;
                        }
                        if (prazo1 == "a prazo_parcial")
                        {
                            cont++;
                        }
                        if (prazo1 == "Pagamento Misto")
                        {
                            cont++;
                        }
                        if (cont == 0)
                        {
                            soma += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);
                            dataGridView1.Rows[i].Cells[5].Style.BackColor = System.Drawing.Color.Cyan;
                        }
                        cont = 0;
                    }
                    textBox3.Text = Convert.ToString(soma);
                }
                dataGridView2.DataSource = DALCadastro.ListaAUXVendas(monthCalendar1.SelectionStart.Date.ToShortDateString());
                if (dataGridView2.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {

                        if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Fiado Parcial" || dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Misto")
                        {
                            if (dataGridView2.Rows[i].Cells[4].Value.ToString() == "cheque")
                            {
                                soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                            }
                           
                        }
                        else
                        {
                            if (checkBox1.Checked == true)
                            {
                                if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Saldo Inicial")
                                {
                                    soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                                else
                                {
                                    soma = soma - Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Coral;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                            }
                        }
                    }
                }
                textBox3.Text = Convert.ToString(soma);
           
            }
            else
            {
                MessageBox.Show("Selecione uma Data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DALCadastro.FluxoVendaTudo1();
            decimal soma = 0;
            int cont = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string prazo1 = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    if (prazo1 == "a prazo")
                    {
                        cont++;
                    }
                    if (prazo1 == "não definido")
                    {
                        cont++;
                    }
                    if (prazo1 == "a prazo_parcial")
                    {
                        cont++;
                    }
                    if (prazo1 == "Pagamento Misto")
                    {
                        cont++;
                    }
                    if (cont == 0)
                    {
                        soma += Convert.ToDecimal(dataGridView1.Rows[i].Cells[6].Value);
                        dataGridView1.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                    }
                    cont = 0;
                }
                textBox3.Text = Convert.ToString(soma);
            }
            dataGridView2.DataSource = DALCadastro.ListaAUXVendas(monthCalendar1.SelectionStart.Date.ToShortDateString());
            if (dataGridView2.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {

                    if (dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Fiado Parcial" || dataGridView2.Rows[i].Cells[5].Value.ToString() == "Pagamento Misto")
                    {
                            soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                            dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                    }
                    else
                    {
                            if (checkBox1.Checked == true)
                            {
                                if (dataGridView2.Rows[i].Cells[1].Value.ToString() == "Saldo Inicial")
                                {
                                    soma = soma + Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Cyan;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                                else
                                {
                                    soma = soma - Convert.ToDecimal(dataGridView2.Rows[i].Cells[6].Value);
                                    dataGridView2.Rows[i].Cells[6].Style.BackColor = System.Drawing.Color.Coral;
                                    textBox3.Text = Convert.ToString(soma);
                                }
                            }

                    }
                }
            }
            textBox3.Text = Convert.ToString(soma);
        }
    }
}
