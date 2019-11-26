using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                textBox12.ReadOnly = true;
                textBox13.ReadOnly = true;
                textBox12.Text = "";
                textBox13.Text = "";
                button6.Visible = false;
                button5.Visible = false;
                button9.Visible = true;
                
            }
            if (checkBox8.Checked == false)
            {
                textBox12.ReadOnly = false;
                textBox13.ReadOnly = false;
                button6.Visible = true;
                button5.Visible = false;
                button9.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Global.Margem.ConfiguraçãoSistema != "adm")
            {
                MessageBox.Show("Acesso não autorizado");

                return;
            }
            DataTable temp = DALCadastro.TestaConfiVazia("1");
            if (temp.Rows.Count < 1)
            {
                DALCadastro.CriaConfig("1","um","dois","tres","quatro","cinco","seis","sete","oito","nove","dez");
                DALCadastro.InsereConfig("1", textBox9.Text, textBox10.Text, textBox11.Text, "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                MessageBox.Show("Configuração salva");

                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("config", "Salvou margem, impostos, comissão : " + textBox9.Text + " / " + textBox10.Text + " / " + textBox11.Text);
                }
            }
            else
            {
                DALCadastro.InsereConfig("1",textBox9.Text,textBox10.Text,textBox11.Text,"quatro","cinco","seis","sete","oito","nove","dez");
                MessageBox.Show("Configuração salva");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("config", "Salvou margem, impostos, comissão : " + textBox9.Text + " / " + textBox10.Text + " / " + textBox11.Text);
                }
            }
            Global.Margem.ConfiguraçãoSistemaFinanceiroMargem = textBox9.Text;
            Global.Margem.ConfiguraçãoSistemaFinanceiroImpostos = textBox10.Text;
            Global.Margem.ConfiguraçãoSistemaFinanceiroComissão = textBox11.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string teste = "";
            if (checkBox3.Checked == true)
	        {
		        teste = "sim";
	        }
            if (checkBox3.Checked == false)
	        {
		        teste = "não";
	        }
            DataTable temp = DALCadastro.TestaConfiVazia("2");
            if (temp.Rows.Count < 1)
            {
                DALCadastro.CriaConfig("2", "um", "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                DALCadastro.InsereConfig("2", teste, "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                MessageBox.Show("Configuração salva");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("config", "Alterou Configuração de controle de Estoque : " + "Faz controle? (" + teste + ")");
                }
            }
            else
            {

                DALCadastro.InsereConfig("2", teste, "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                MessageBox.Show("Configuração salva");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("config", "Alterou Configuração de controle de Estoque : " + "Faz controle? (" + teste + ")");
                }
            }
            Global.Margem.ConfiguraçãoSistemaEstoque = teste;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string teste = "";
            if (checkBox6.Checked == true)
            {
                teste = "sim";
                using (StreamWriter writer = new StreamWriter("LOG.txt"))
                {
                    writer.Write("sim");
                    Global.Margem.Logs = "sim";

                }
            }
            if (checkBox6.Checked == false)
            {
                teste = "não";
                using (StreamWriter writer = new StreamWriter("LOG.txt"))
                {
                    writer.Write("não");
                    Global.Margem.Logs = "não";

                }
            }
            DataTable temp = DALCadastro.TestaConfiVazia("3");
            if (temp.Rows.Count < 1)
            {
                DALCadastro.CriaConfig("3", "um", "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                DALCadastro.InsereConfig("3", teste, "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                MessageBox.Show("Configuração salva");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("config", "Alterou Configuração de controle de LOGs : " + "Faz controle? (" + teste + ")");
                }
            }
            else
            {

                DALCadastro.InsereConfig("3", teste, "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                MessageBox.Show("Configuração salva");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("config", "Alterou Configuração de controle de LOGs : " + "Faz controle? (" + teste + ")");
                }
            }
            Global.Margem.ConfiguraçãoSistemaLOGs = teste;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string teste = "";
            if (checkBox4.Checked == true)
            {
                teste = "sim";
            }
            if (checkBox4.Checked == false)
            {
                if (checkBox7.Checked == true)
                {
                    teste = "tv";
                }
                if (checkBox9.Checked == true)
                {
                    teste = "caixa";
                }
            }
            DataTable temp = DALCadastro.TestaConfiVazia("4");
            if (temp.Rows.Count < 1)
            {
                DALCadastro.CriaConfig("4", "um", "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                DALCadastro.InsereConfig("4", teste, "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                MessageBox.Show("Configuração salva");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    string caixa = "";
                    if (teste == "sim")
	                {
		                caixa = "Configurado para Caixa e Terminal de vendas.";
	                }
                    if (teste == "tv")
                    {
                        caixa = "Configurado para Terminal de vendas.";
                    }
                    if (teste == "caixa")
                    {
                        caixa = "Configurado para Caixa.";
                    }

                    Ferramentas.CriaLog("config", "Alterou Configuração de Caixa/terminal de Vendas : " + caixa);
                }
            }
            else
            {

                DALCadastro.InsereConfig("4", teste, "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                MessageBox.Show("Configuração salva");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    string caixa = "";
                    if (teste == "sim")
                    {
                        caixa = "Configurado para Caixa e Terminal de vendas.";
                    }
                    if (teste == "tv")
                    {
                        caixa = "Configurado para Terminal de vendas.";
                    }
                    if (teste == "caixa")
                    {
                        caixa = "Configurado para Caixa.";
                    }

                    Ferramentas.CriaLog("config", "Alterou Configuração de Caixa/terminal de Vendas : " + caixa);
                }
            }
            Global.Margem.ConfiguraçãoSistemaCaixaTerminalVendas = teste;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string teste = "";
            if (checkBox8.Checked == true)
            {
                teste = "sim";
                //BD local
                DataTable temp = DALCadastro.TestaConfiVazia("5");
                if (temp.Rows.Count < 1)
                {
                    DALCadastro.CriaConfig("5", "um", "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                    DALCadastro.InsereConfig("5", teste, "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                    MessageBox.Show("Configuração salva");
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("config", "Alterou Configuração de acesso á Banco de Dados : Local." );
                    }
                }
                else
                {

                    DALCadastro.InsereConfig("5", teste, "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                    MessageBox.Show("Configuração salva");
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("config", "Alterou Configuração de acesso á Banco de Dados : Local.");
                    }
                }
                
                using (StreamWriter writer = new StreamWriter("BD.txt"))
                {
                    writer.Write("local");
                    Global.Margem.ConfiguraçãoSistemaBancoDados = "local";
                    button5.Visible = false;
                    
                }
                Global.Margem.AtualizaPrincipal = "sim";
            }
            if (checkBox8.Checked == false)
            {
                teste = "não";
                //BD na rede
                DataTable temp = DALCadastro.TestaConfiVazia("5");
                if (temp.Rows.Count < 1)
                {
                    DALCadastro.CriaConfig("5", "um", "dois", "tres", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                    DALCadastro.InsereConfig("5", teste, textBox12.Text, textBox13.Text, "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                    MessageBox.Show("Configuração salva");
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("config", "Alterou Configuração de acesso á Banco de Dados : Rede." + "IP : " + 
                            textBox12.Text + "Porta : " + textBox13.Text );
                    }
                }
                else
                {

                    DALCadastro.InsereConfig("5", teste, textBox12.Text, textBox13.Text, "quatro", "cinco", "seis", "sete", "oito", "nove", "dez");
                    MessageBox.Show("Configuração salva");
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("config", "Alterou Configuração de acesso á Banco de Dados : Rede." + "IP : " +
                            textBox12.Text + "Porta : " + textBox13.Text);
                    }
                }
                using (StreamWriter writer = new StreamWriter("BD.txt"))
                {
                    writer.Write("rede");
                    Global.Margem.ConfiguraçãoSistemaBancoDados = "rede";

                }
                using (StreamWriter writer = new StreamWriter("BDIp.txt"))
                {
                    writer.Write(textBox12.Text);
                    Global.Margem.ConfiguraçãoSistemaBancoDadosIp = textBox12.Text;

                }
                using (StreamWriter writer = new StreamWriter("BDPorta.txt"))
                {
                    writer.Write(textBox13.Text);
                    Global.Margem.ConfiguraçãoSistemaBancoDadosPorta = textBox13.Text;

                }
                button5.Visible = false;
                Global.Margem.AtualizaPrincipal = "sim";
            }
            Global.Margem.AtualizaPrincipal = "sim";
            MessageBox.Show("Esta alteração requer reinicialização do sistema");
            Application.Exit();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox12.Text) == false && String.IsNullOrEmpty(textBox13.Text) == false)
            {
                Form senhabd = new SenhaBD();
                senhabd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Número IP  ou Porta não fornecido");
                return;
            }
            if (Global.Margem.senhaSA == "#lecoteco1975")
            {
                cont = 0;
                string strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + textBox12.Text + "," + textBox13.Text + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
                //define a instrução SQL para somar Quantidade e agrupar resultados

                String strSQL = "baixaEstoqueRetorna";

                //cria a conexão com o banco de dados
                OleDbConnection dbConnection = new OleDbConnection(strConnection);

                //cria a conexão com o banco de dados
                OleDbConnection con = new OleDbConnection(strConnection);
                //cria o objeto command para executar a instruçao sql
                OleDbCommand cmd = new OleDbCommand(strSQL, con);

                try
                {
                    //abre a conexao

                    con.Open();
                    progressBar1.Visible = true;
                    timer1.Enabled = true;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com o Banco de Dados\nTalvez seja necessário configurar o Firewall do servidor" + "\n\nDescrição do problema: : \n\n" + ex.Message.ToString());
                    Global.Margem.Erro = "no";

                }
            }
            
        }
        int cont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
            cont++;
            if (cont == 4)
            {
                timer1.Enabled = false;
                progressBar1.Refresh();
                progressBar1.Visible = false;
                MessageBox.Show("|||||| Conexão realizada com exito |||||||\n\n Não se esqueça de salvar esta configuração IP/Porta.");
                Global.Margem.senhaSA = "";
                textBox12.ReadOnly = true;
                textBox13.ReadOnly = true;

                checkBox8.Visible = false;
                button5.Visible = true;
               
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form formPrincipal = new TelaPrincipal();
            DataTable cor = DALCadastro.CoresRetorna(Global.Margem.Operador);

            
            GerenciadorDeFormulario.Abre(formPrincipal);
            GerenciadorDeFormulario.Fecha(this);
            
        }
        
        private void Config_Load(object sender, EventArgs e)
        {
            this.Text += "   Operador ==>  " + Global.Margem.Operador;
            if (Global.Margem.ServidorImpressao == "sim")
            {
                checkBox10.Checked = true;
                
            }
            dataGridView3.DataSource = DALCadastro.AUXCadListar("ListarCadEmpresa");

            DataTable cor10 = DALCadastro.CoresRetorna(Global.Margem.Operador.ToString());
            if (cor10.Rows.Count > 0)
            {
                panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["CorMenu"].ToString()));
                panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor2"].ToString()));
                tabPage3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));
                tabPage1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));
                tabPage2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));
               

            }
            DataTable inicio = DALCadastro.TestaConfiVazia("1");
            if (inicio.Rows.Count > 0)
            {
                textBox9.Text = inicio.Rows[0]["Campo1"].ToString();
                textBox10.Text = inicio.Rows[0]["Campo2"].ToString();
                textBox11.Text = inicio.Rows[0]["Campo3"].ToString();
            }
            inicio.Clear();
            inicio = DALCadastro.TestaConfiVazia("2");
            if (inicio.Rows.Count > 0)
            {
                string teste = inicio.Rows[0]["Campo1"].ToString();
                if (teste == "sim")
                {
                    checkBox3.Checked = true;
                }
                if (teste == "não")
                {
                    checkBox3.Checked = false;
                }
            }
            inicio.Clear();
            inicio = DALCadastro.TestaConfiVazia("3");
            if (inicio.Rows.Count > 0)
            {
                string teste = inicio.Rows[0]["Campo1"].ToString();
                if (teste == "sim")
                {
                    checkBox6.Checked = true;
                }
                if (teste == "não")
                {
                    checkBox6.Checked = false;
                }
            }
            inicio.Clear();
            inicio = DALCadastro.TestaConfiVazia("4");
            if (inicio.Rows.Count > 0)
            {
                string teste = inicio.Rows[0]["Campo1"].ToString();
                if (teste == "sim")
                {
                    checkBox4.Checked = true;
                }
                if (teste == "tv")
                {
                    checkBox4.Checked = false;
                    checkBox7.Checked = true;
                    checkBox7.Visible = true;
                    
                }
                if (teste == "caixa")
                {
                    checkBox4.Checked = false;
                    checkBox9.Checked = true;
                    checkBox9.Visible = true;
                }
             }
            
                
             if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
             {
                    checkBox8.Checked = true;
                    
             }
             if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
             {
                    checkBox8.Checked = false;
                    textBox12.Text = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                    textBox13.Text = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
             }
             if (Global.Margem.Impressora == "generic")
             {
                 checkBox11.Checked = true;
             }
             if (Global.Margem.Impressora == "mp4200th")
             {
                 checkBox12.Checked = true;
             }
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (Global.Margem.ConfiguraçãoSistema != "adm")
            {
                MessageBox.Show("Acesso não autorizado");

                return;
            }
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false)
            {
                string temp = "";
                if (checkBox1.Checked == true)
                {
                    temp = "sim";
                }
                if (checkBox1.Checked == false)
                {
                    temp = "não";
                }
                DALCadastro.Insere_Banco(textBox1.Text, textBox2.Text, temp);
                MessageBox.Show("Banco incluído com sucesso");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("config", "Incluiu novo Banco : " + "Código : " + textBox1.Text + 
                        " Nome : " + textBox2.Text);
                }
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox1.Text = "";
                textBox2.Text = "";
                checkBox1.Visible = false;
            }
        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {
            Form febra = new Febraban();
            febra.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == false)
            {
                dataGridView1.DataSource = DALCadastro.Lista_Banco();
            }
            if (checkBox5.Checked == true)
            {
                dataGridView1.DataSource = DALCadastro.Lista_Banco_Inativo();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Global.Margem.ConfiguraçãoSistema != "adm")
            {
                MessageBox.Show("Acesso não autorizado");

                return;
            }
            textBox1.ReadOnly = false;
            textBox1.Text = "";
            textBox2.ReadOnly = false;
            textBox2.Text = "";
            checkBox1.Visible = false;
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Global.Margem.ConfiguraçãoSistema != "adm")
            {
                MessageBox.Show("Acesso não autorizado");

                return;
            }
            textBox4.ReadOnly = false;
            textBox4.Text = "";
            textBox5.ReadOnly = false;
            textBox5.Text = "";
            textBox6.ReadOnly = false;
            textBox6.Text = "";
            textBox7.ReadOnly = false;
            textBox7.Text = "";
            
            textBox8.ReadOnly = false;
            textBox8.Text = "";
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (Global.Margem.ConfiguraçãoSistema != "adm")
            {
                MessageBox.Show("Acesso não autorizado");

                return;
            }
            string temp = "";
            if (checkBox2.Checked == false)
	        {
	            	 temp = "não";
	        }
            if (checkBox2.Checked == true)
	        {
	            	 temp = "sim";
	        }
            if (String.IsNullOrEmpty(textBox3.Text) == false)
            {
                DALCadastro.Insere_Contas_Corrente(label24.Text,textBox4.Text,textBox5.Text,textBox7.Text,textBox6.Text,
                    textBox3.Text,textBox8.Text,temp,label21.Text);
            }
            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
            {
                Ferramentas.CriaLog("config", "Incluiu nova Conta : " + textBox8.Text);
            }
            textBox4.ReadOnly = true;
            textBox4.Text = "";
            textBox5.ReadOnly = true;
            textBox5.Text = "";
            textBox6.ReadOnly = true;
            textBox6.Text = "";
            textBox7.ReadOnly = true;
            textBox7.Text = "";
            textBox3.Text = "";
            textBox8.ReadOnly = true;
            textBox8.Text = "";
            checkBox2.Visible = false;

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                label21.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                label24.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                checkBox1.Visible = true;
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                

                dataGridView2.DataSource = DALCadastro.Lista_Contas_Corrente(label21.Text);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Global.Margem.ConfiguraçãoSistema != "adm")
            {
                MessageBox.Show("Acesso não autorizado");

                return;
            }
            if (checkBox1.Checked == false)
            {
                string temp = "não";
                DALCadastro.Atualiza_Banco(label21.Text,temp);
                MessageBox.Show("Banco Inativado");
                dataGridView1.DataSource = DALCadastro.Lista_Banco();
            }
            if (checkBox1.Checked == true)
            {
                string temp = "sim";
                DALCadastro.Atualiza_Banco(label21.Text,temp);
                MessageBox.Show("Banco Ativo");
                dataGridView1.DataSource = DALCadastro.Lista_Banco();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                checkBox2.Visible = true;
                textBox4.Text = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                textBox5.Text = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
                textBox7.Text = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString();
                textBox6.Text = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[5].FormattedValue.ToString();
                textBox8.Text = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[7].FormattedValue.ToString();
                string temp = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[8].FormattedValue.ToString();
                if (temp == "sim")
                {
                    checkBox2.Checked = true;
                }
                if (temp == "não")
                {
                    checkBox2.Checked = false;
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true )
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    string temp = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                    string ativ = "sim";
                    DALCadastro.Inativa_Contas_Corrente(temp,ativ);
                    MessageBox.Show("Conta Ativa");
                    dataGridView2.DataSource = DALCadastro.Lista_Contas_Corrente("0");
                }
            }
            if (checkBox2.Checked == false )
            {
                if (dataGridView2.Rows.Count > 0)
                {
                    string temp = dataGridView2.Rows[dataGridView2.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                    string ativ = "não";
                    DALCadastro.Inativa_Contas_Corrente(temp, ativ);
                    MessageBox.Show("Conta Inativa");
                    dataGridView2.DataSource = DALCadastro.Lista_Contas_Corrente("0");
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            dataGridView2.DataSource = DALCadastro.Inativa_Contas_Corrente_Lista();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar2.PerformStep();
            cont++;
            if (cont == 4)
            {
                timer2.Enabled = false;
                progressBar2.Refresh();
                progressBar2.Visible = false;
                MessageBox.Show("|||||| Conexão realizada com exito |||||||\n\n Não se esqueça de salvar esta configuração local.");
                Global.Margem.senhaSA = "";
                textBox12.ReadOnly = true;
                textBox13.ReadOnly = true;

                checkBox8.Visible = false;
                button5.Visible = true;
                button9.Visible = false;

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form senhabd = new SenhaBD();
            senhabd.ShowDialog();
            if (Global.Margem.senhaSA == "#lecoteco1975")
	        {
		        cont = 0;
                
                //define a instrução SQL para somar Quantidade e agrupar resultados
                string strConnection = "";
                if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
                {
                    strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                }
                if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
                {
                    string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                    string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                    strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
                }
                String strSQL = "baixaEstoqueRetorna";

                //cria a conexão com o banco de dados
                OleDbConnection dbConnection = new OleDbConnection(strConnection);

                //cria a conexão com o banco de dados
                OleDbConnection con = new OleDbConnection(strConnection);
                //cria o objeto command para executar a instruçao sql
                OleDbCommand cmd = new OleDbCommand(strSQL, con);

                try
                {
                    //abre a conexao

                    con.Open();
                    progressBar2.Visible = true;
                    timer2.Enabled = true;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível estabelecer uma conexão com o Banco de Dados\nTalvez seja necessário configurar o Firewall do servidor" + "\n\nDescrição do problema: : \n\n" + ex.Message.ToString());
                    Global.Margem.Erro = "no";

                }

	        }
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                checkBox7.Visible = true;
                checkBox9.Visible = true;
            }
            if (checkBox4.Checked == true)
            {
                checkBox7.Visible = false;
                checkBox9.Visible = false;
                checkBox7.Checked = false;
                checkBox9.Checked = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox9.Checked = false;
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                checkBox7.Checked = false;
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                string nome = dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                if (nome.Length <= 43)
                {
                    textBox14.Text = nome;    
                }
                if (nome.Length > 43)
                {
                    textBox14.Text = nome.Substring(0,43);
                }
                
                textBox15.Text = dataGridView3.Rows[dataGridView3.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
               
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty( textBox14.Text) == false && String.IsNullOrEmpty(textBox15.Text) == false)
            {
                //string teste = "";
                if (checkBox10.Checked == true)
                {
                    //teste = "sim";
                    using (StreamWriter writer = new StreamWriter("SI.txt"))
                    {
                        writer.Write("sim");
                        Global.Margem.ServidorImpressao = "sim";
                        MessageBox.Show("Servidor de Impressão Ativado.\nEsta mudança requer reinicialização.");
                        Application.Exit();


                    }
                    
                }
                if (checkBox10.Checked == false)
                {
                    //teste = "não";
                    using (StreamWriter writer = new StreamWriter("SI.txt"))
                    {
                        writer.Write("não");
                        Global.Margem.ServidorImpressao = "não";
                        MessageBox.Show("Servidor de Impressão Desativado.\nEsta mudança requer reinicialização.");
                        Application.Exit();

                    }
                }
                //Configura tipo de impressora
                if (checkBox11.Checked == true)
                {
                    using (StreamWriter writer = new StreamWriter("Impressora.txt"))
                    {
                        writer.Write("generic");
                        Global.Margem.Impressora = "generic";
                        MessageBox.Show("Driver Generic Text Only Ativado.\nEsta mudança requer reinicialização.");
                        Application.Exit();


                    }
                }
                if (checkBox12.Checked == true)
                {
                    using (StreamWriter writer = new StreamWriter("Impressora.txt"))
                    {
                        writer.Write("mp4200th");
                        Global.Margem.Impressora = "mp4200th";
                        MessageBox.Show("Driver para Impressora MP4200 TH Ativado.\nEsta mudança requer reinicialização.");
                        Application.Exit();


                    }
                }

                //Insere Texto do Cupom
                string Empresa = textBox14.Text;
                string Cnpj = textBox15.Text;
                string Ie = "";
                if (String.IsNullOrEmpty(textBox18.Text) == true)
                {
                    Ie = "vazio";
                }
                if (String.IsNullOrEmpty(textBox18.Text) == false)
                {
                    Ie = textBox18.Text;
                }
                string texto1 = "";
                if (String.IsNullOrEmpty(textBox17.Text) == true)
                {
                    texto1 = "vazio";
                }
                if (String.IsNullOrEmpty(textBox17.Text) == false)
                {
                    texto1 = textBox17.Text;
                }
                string texto2 = "";
                if (String.IsNullOrEmpty(textBox16.Text) == true)
                {
                    texto2 = "vazio";
                }
                if (String.IsNullOrEmpty(textBox16.Text) == false)
                {
                    texto2 = textBox16.Text;
                }
                DataTable testa = DALCadastro.ExisteTextoCupom();
                if (testa.Rows.Count <= 0)
                {
                    DALCadastro.CriaTextoCupom(Empresa,Cnpj,Ie,texto1,texto2);
                }
                if (testa.Rows.Count > 0)
                {
                    DALCadastro.InsereTextoCupom(Empresa,Cnpj,Ie,texto1,texto2);
                }
                MessageBox.Show("Dados inseridos com sucesso\n" + "Empresa : " + Empresa + "\n" +
                    "CNPJ : " + Cnpj + "\n" + "IE : " + Ie + "\n" + "Texto Adicional1 : " + texto1 + "\n" + 
                    "Texto Adicional2 : " + texto2);
            }
            else
            {
                MessageBox.Show("Campo obrigatório não preenchido");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataTable cup = DALCadastro.ExisteTextoCupom();
            if (cup.Rows.Count > 0)
            {
                textBox14.Text = cup.Rows[0]["Empresa"].ToString();
                textBox15.Text = cup.Rows[0]["CNPJ"].ToString();
                textBox18.Text = cup.Rows[0]["IE"].ToString();
                textBox17.Text = cup.Rows[0]["TextoAdicional1"].ToString();
                textBox16.Text = cup.Rows[0]["TextoAdicional2"].ToString();

            }
            else
            {
                MessageBox.Show("Informações do Cupom ainda não foram fornecidas");
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                checkBox12.Checked = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                checkBox11.Checked = false;
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            checkBox14.Checked = false;
            Global.SAT_Ativo.SATativado = "sim";
            Global.SAT_Ativo.SATativadoModoOperação = "produção";
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            checkBox13.Checked = false;
            Global.SAT_Ativo.SATativado = "sim";
            Global.SAT_Ativo.SATativadoModoOperação = "emulador";
            MessageBox.Show("Testando sistema com emulador off-line SEFAZ");
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            Global.SAT_Ativo.SATativado = "não";
        }
    }
}
