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
    public partial class tipoPagamento : Form
    {
        public tipoPagamento()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Você deseja finalizar com pagamento à prazo?";
            string caption = "Fiado";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    
                    if (Global.SAT_Ativo.SATativado == "não")
                    {
                        DALCadastro.tipoVendaFiado(textBox1.Text, Global.Margem.Numvenda);
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);

                        Global.Margem.Pagamento = "Pagamento a prazo";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : a prazo. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        this.Close();
                    }
                    
                        
                    
                    
                }
                else
                {
                    MessageBox.Show("Favor selecionar cliente");
                }
            }

            
          
            
            
        }
        
        

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            groupBox2.BackColor = System.Drawing.Color.GreenYellow;
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            groupBox2.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            groupBox3.BackColor = System.Drawing.Color.GreenYellow;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            groupBox3.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            groupBox4.BackColor = System.Drawing.Color.GreenYellow;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            groupBox4.BackColor = System.Drawing.Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            groupBox5.BackColor = System.Drawing.Color.GreenYellow;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            groupBox5.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            string message = "Você deseja finalizar com pagamento em dinheiro?";
            string caption = "Dinheiro";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                
                if (Global.SAT_Ativo.SATativado == "sim" && Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                {
                    MessageBox.Show("Sistema em modo de teste(emulador SEFAZ) de envio ao SAT.\n\nO emulador precisa estar ativo para teste");
                }
                if (Global.SAT_Ativo.SATativado == "não")
                {
                    DALCadastro.tipoVenda("dinheiroVenda", Global.Margem.Numvenda);
                    DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                    Global.Margem.Pagamento = "Pagamento realizado em dinheiro";
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : dinheiro. Número venda : " + Global.Margem.Numvenda +
                            " Total : " + Global.Margem.Totalvenda);
                    }
                    if (Global.Margem.TemTroco == "sim")
                    {

                    }

                    this.Close();    
                }

                if (Global.SAT_Ativo.SATativado == "sim")
                {
                    if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                    {
                        DALCadastro.tipoVenda("dinheiroVenda", Global.Margem.Numvenda);

                        //definir impressão cupom sat
                        Global.SAT_Ativo.CupomSATativado = "sim";

                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado em dinheiro";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : dinheiro. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        if (Global.Margem.TemTroco == "sim")
                        {

                        }

                        this.Close();    
                    }
                    if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                    {
                        DALCadastro.tipoVenda("dinheiroVenda", Global.Margem.Numvenda);

                        //definir impressão cupom sat
                        //Global.SAT_Ativo.CupomSATativado = "sim";

                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado em dinheiro";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : dinheiro. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        if (Global.Margem.TemTroco == "sim")
                        {

                        }
                        

                        
                        EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda),"#lecoteco1975#",Global.Margem.Numvenda,"não");

                        this.Close();    
                    }
                   
                }
                
            }            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string message = "Você deseja finalizar com pagamento em cartão de débito?";
            string caption = "Cartão de Débito";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (Global.SAT_Ativo.SATativado == "sim" && Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                {
                    MessageBox.Show("Sistema em modo de teste(emulador SEFAZ) de envio ao SAT.\n\nO emulador precisa estar ativo para teste");
                }
                if (Global.SAT_Ativo.SATativado == "não")
                {
                    DALCadastro.tipoVenda("cartaoDebitoVenda", Global.Margem.Numvenda);
                    DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                    Global.Margem.Pagamento = "Pagamento realizado com cartão de débito";
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de débito. Número venda : " + Global.Margem.Numvenda +
                            " Total : " + Global.Margem.Totalvenda);
                    }
                    this.Close();
                }
                if (Global.SAT_Ativo.SATativado == "sim")
                {
                    if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                    {
                        DALCadastro.tipoVenda("cartaoDebitoVenda", Global.Margem.Numvenda);

                        Global.SAT_Ativo.CupomSATativado = "sim";
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado com cartão de débito";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de débito. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        this.Close();
                    }
                    if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                    {
                        DALCadastro.tipoVenda("cartaoDebitoVenda", Global.Margem.Numvenda);

                        Global.SAT_Ativo.CupomSATativado = "sim";
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado com cartão de débito";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de débito. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }

                       

                        Global.SAT_Param.Formas_Pagamento_CD_valor = Global.Margem.Totalvenda.Replace(",", ".");
                        Global.SAT_Param.Formas_Pagamento_CD_codigo = "001";
                        EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "não");
                        this.Close();
                    }
                    
                }
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            string message = "Você deseja finalizar com pagamento em cartão de crédito?";
            string caption = "Cartão de Crédito";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (Global.SAT_Ativo.SATativado == "sim" && Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                {
                    MessageBox.Show("Sistema em modo de teste(emulador SEFAZ) de envio ao SAT.\n\nO emulador precisa estar ativo para teste");
                }
                if (Global.SAT_Ativo.SATativado == "não")
                {
                    DALCadastro.tipoVenda("cartaoCreditoVenda", Global.Margem.Numvenda);
                    DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                    Global.Margem.Pagamento = "Pagamento realizado com cartão de crédito";
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de crédito. Número venda : " + Global.Margem.Numvenda +
                            " Total : " + Global.Margem.Totalvenda);
                    }
                    this.Close();
                }
                if (Global.SAT_Ativo.SATativado == "sim")
                {
                    if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                    {
                        DALCadastro.tipoVenda("cartaoCreditoVenda", Global.Margem.Numvenda);

                        Global.SAT_Ativo.CupomSATativado = "sim";
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado com cartão de crédito";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de crédito. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        this.Close();
                    }
                    if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                    {
                        DALCadastro.tipoVenda("cartaoCreditoVenda", Global.Margem.Numvenda);

                        Global.SAT_Ativo.CupomSATativado = "sim";
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado com cartão de crédito";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de crédito. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }

                        

                        Global.SAT_Param.Formas_Pagamento_CC_valor = Global.Margem.Totalvenda.Replace(",", ".");
                        Global.SAT_Param.Formas_Pagamento_CC_Codigo = "001";
                        EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "não");
                        this.Close();
                    }
                   
                }
                
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string message = "Você deseja finalizar com pagamento em cheque?";
            string caption = "Cheque";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                if (Global.SAT_Ativo.SATativado == "sim" && Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                {
                    MessageBox.Show("Sistema em modo de teste(emulador SEFAZ) de envio ao SAT.\n\nO emulador precisa estar ativo para teste");
                }
                if (Global.SAT_Ativo.SATativado == "não")
                {
                    DALCadastro.tipoVenda("chequeVenda", Global.Margem.Numvenda);
                    DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                    Global.Margem.Pagamento = "Pagamento realizado com cheque";
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cheque. Número venda : " + Global.Margem.Numvenda +
                            " Total : " + Global.Margem.Totalvenda);
                    }
                    this.Close();
                }
                if (Global.SAT_Ativo.SATativado == "sim")
                {
                    if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                    {
                        DALCadastro.tipoVenda("chequeVenda", Global.Margem.Numvenda);

                        Global.SAT_Ativo.CupomSATativado = "sim";
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado com cheque";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cheque. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        this.Close();
                    }
                    if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                    {
                        DALCadastro.tipoVenda("chequeVenda", Global.Margem.Numvenda);

                        Global.SAT_Ativo.CupomSATativado = "sim";
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado com cheque";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cheque. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }

                        

                        Global.SAT_Param.Formas_Pagamento_cheque_valor = Global.Margem.Totalvenda.Replace(",", ".");
                        EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "não");
                        
                        

                        this.Close();
                    }
                    
                }
                
            }
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Global.Margem.Cancelar = "OK";
            textBox1.Focus();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.ListaClienteFiado();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Columns[0].Width = 300;
                }
            }
            dataGridView1.Focus();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form cadFiado = new ClienteFiado();
            cadFiado.ShowDialog();
            dataGridView1.DataSource = DALCadastro.ListaClienteFiado();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();

            }
        }

        private void tipoPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                dataGridView1.DataSource = DALCadastro.ListaClienteFiado();
                dataGridView1.Columns[0].Width = 300;
                return;
            }
            if (e.KeyCode == Keys.F3)
            {
                string message = "Você deseja finalizar com pagamento em dinheiro?";
                string caption = "Dinheiro";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    if (Global.SAT_Ativo.SATativado == "sim" && Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                    {
                        MessageBox.Show("Sistema em modo de teste(emulador SEFAZ) de envio ao SAT.\n\nO emulador precisa estar ativo para teste");
                    }
                    if (Global.SAT_Ativo.SATativado == "não")
                    {
                        DALCadastro.tipoVenda("dinheiroVenda", Global.Margem.Numvenda);
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado em dinheiro";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : dinheiro. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        if (Global.Margem.TemTroco == "sim")
                        {

                        }

                        this.Close();
                    }

                    if (Global.SAT_Ativo.SATativado == "sim")
                    {
                        if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                        {
                            DALCadastro.tipoVenda("dinheiroVenda", Global.Margem.Numvenda);

                            //definir impressão cupom sat
                            Global.SAT_Ativo.CupomSATativado = "sim";

                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                            Global.Margem.Pagamento = "Pagamento realizado em dinheiro";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : dinheiro. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }
                            if (Global.Margem.TemTroco == "sim")
                            {

                            }

                            this.Close();
                        }
                        if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                        {
                            DALCadastro.tipoVenda("dinheiroVenda", Global.Margem.Numvenda);

                            //definir impressão cupom sat
                            //Global.SAT_Ativo.CupomSATativado = "sim";

                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                            Global.Margem.Pagamento = "Pagamento realizado em dinheiro";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : dinheiro. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }
                            if (Global.Margem.TemTroco == "sim")
                            {

                            }



                            EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "não");

                            this.Close();
                        }

                    }
                }
                return;
            }
            if (e.KeyCode == Keys.F4)
            {
                string message = "Você deseja finalizar com pagamento em cartão de débito?";
                string caption = "Cartão de Débito";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    if (Global.SAT_Ativo.SATativado == "sim" && Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                    {
                        MessageBox.Show("Sistema em modo de teste(emulador SEFAZ) de envio ao SAT.\n\nO emulador precisa estar ativo para teste");
                    }
                    if (Global.SAT_Ativo.SATativado == "não")
                    {
                        DALCadastro.tipoVenda("cartaoDebitoVenda", Global.Margem.Numvenda);
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado com cartão de débito";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de débito. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        this.Close();
                    }
                    if (Global.SAT_Ativo.SATativado == "sim")
                    {
                        if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                        {
                            DALCadastro.tipoVenda("cartaoDebitoVenda", Global.Margem.Numvenda);

                            Global.SAT_Ativo.CupomSATativado = "sim";
                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                            Global.Margem.Pagamento = "Pagamento realizado com cartão de débito";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de débito. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }
                            this.Close();
                        }
                        if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                        {
                            DALCadastro.tipoVenda("cartaoDebitoVenda", Global.Margem.Numvenda);

                            Global.SAT_Ativo.CupomSATativado = "sim";
                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                            Global.Margem.Pagamento = "Pagamento realizado com cartão de débito";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de débito. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }



                            Global.SAT_Param.Formas_Pagamento_CD_valor = Global.Margem.Totalvenda.Replace(",", ".");
                            Global.SAT_Param.Formas_Pagamento_CD_codigo = "001";
                            EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "não");
                            this.Close();
                        }

                    }
                }
                return;
            }
            if (e.KeyCode == Keys.F5)
            {
                dataGridView1.Focus();
                return;
            }
            if (e.KeyCode == Keys.F7)
            {
                string message = "Você deseja finalizar com pagamento em cartão de crédito?";
                string caption = "Cartão de Crédito";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    if (Global.SAT_Ativo.SATativado == "sim" && Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                    {
                        MessageBox.Show("Sistema em modo de teste(emulador SEFAZ) de envio ao SAT.\n\nO emulador precisa estar ativo para teste");
                    }
                    if (Global.SAT_Ativo.SATativado == "não")
                    {
                        DALCadastro.tipoVenda("cartaoCreditoVenda", Global.Margem.Numvenda);
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado com cartão de crédito";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de crédito. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        this.Close();
                    }
                    if (Global.SAT_Ativo.SATativado == "sim")
                    {
                        if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                        {
                            DALCadastro.tipoVenda("cartaoCreditoVenda", Global.Margem.Numvenda);

                            Global.SAT_Ativo.CupomSATativado = "sim";
                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                            Global.Margem.Pagamento = "Pagamento realizado com cartão de crédito";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de crédito. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }
                            this.Close();
                        }
                        if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                        {
                            DALCadastro.tipoVenda("cartaoCreditoVenda", Global.Margem.Numvenda);

                            Global.SAT_Ativo.CupomSATativado = "sim";
                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                            Global.Margem.Pagamento = "Pagamento realizado com cartão de crédito";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cartão de crédito. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }



                            Global.SAT_Param.Formas_Pagamento_CC_valor = Global.Margem.Totalvenda.Replace(",", ".");
                            Global.SAT_Param.Formas_Pagamento_CC_Codigo = "001";
                            EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "não");
                            this.Close();
                        }

                    }
                }
                return;
            }
            if (e.KeyCode == Keys.F10)
            {
                string message = "Você deseja finalizar com pagamento em cheque?";
                string caption = "Cheque";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    if (Global.SAT_Ativo.SATativado == "sim" && Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                    {
                        MessageBox.Show("Sistema em modo de teste(emulador SEFAZ) de envio ao SAT.\n\nO emulador precisa estar ativo para teste");
                    }
                    if (Global.SAT_Ativo.SATativado == "não")
                    {
                        DALCadastro.tipoVenda("chequeVenda", Global.Margem.Numvenda);
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        Global.Margem.Pagamento = "Pagamento realizado com cheque";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cheque. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        this.Close();
                    }
                    if (Global.SAT_Ativo.SATativado == "sim")
                    {
                        if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                        {
                            DALCadastro.tipoVenda("chequeVenda", Global.Margem.Numvenda);

                            Global.SAT_Ativo.CupomSATativado = "sim";
                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                            Global.Margem.Pagamento = "Pagamento realizado com cheque";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cheque. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }
                            this.Close();
                        }
                        if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                        {
                            DALCadastro.tipoVenda("chequeVenda", Global.Margem.Numvenda);

                            Global.SAT_Ativo.CupomSATativado = "sim";
                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                            Global.Margem.Pagamento = "Pagamento realizado com cheque";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : cheque. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }



                            Global.SAT_Param.Formas_Pagamento_cheque_valor = Global.Margem.Totalvenda.Replace(",", ".");
                            EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "não");



                            this.Close();
                        }

                    }
                }
                return;
            }
             if (e.KeyCode == Keys.F12)
            {
                string message = "Você deseja finalizar com pagamento à prazo?";
                string caption = "Fiado";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    if (String.IsNullOrEmpty(textBox1.Text) == false)
                    {
                        DALCadastro.tipoVendaFiado(textBox1.Text, Global.Margem.Numvenda);
                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                        
                        Global.Margem.Pagamento = "Pagamento a prazo";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : a prazo. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Favor selecionar cliente");
                    }
                }
            
            
                return;
            }
            if (e.KeyCode == Keys.Escape)
            {
                Global.Margem.Cancelar = "OK";
                textBox1.Focus();
                this.Close();
                 return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    Global.Margem.ClienteFiado = textBox1.Text;
                    Form fiado = new VisualizaFiado();
                    fiado.ShowDialog();
                    Global.Margem.ClienteFiado = "";
                }
                 return;
            }
            if (e.KeyCode == Keys.Space)
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();

                }
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                Form cadFiado = new ClienteFiado();
                cadFiado.ShowDialog();
                dataGridView1.DataSource = DALCadastro.ListaClienteFiado();
                return;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty (textBox1.Text) == false)
            {
                Global.Margem.ClienteFiado = textBox1.Text;
                Form fiado = new VisualizaFiado();
                fiado.ShowDialog();
                Global.Margem.ClienteFiado = "";
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
