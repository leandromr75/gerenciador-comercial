using Microsoft.Reporting.WinForms;
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
    public partial class FecharCaixa : Form
    {
        public FecharCaixa()
        {
            InitializeComponent();
        }
        
        private void FecharCaixa_Load(object sender, EventArgs e)
        {
            
            this.Text = "[Fechamento de Caixa. Operador ==> " + Global.Margem.Operador + "]";
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FechamentoCaixa";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Caixa", Global.Margem.CaixaAberto);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //cria um objeto datatable
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //clientes.TableName = "DataTable1";
            textBox8.Text = Global.Margem.ValorAberto;
            dataGridView1.DataSource = clientes;
            DataTable fiadi2 = DALCadastro.ParcialLista(Global.Margem.CaixaSelecionado);
            DataTable reti2 = DALCadastro.ListaRetirada(Global.Margem.RetiradaCaixa);
            if (dataGridView1.Rows.Count > 0 || fiadi2.Rows.Count > 0 || reti2.Rows.Count > 0)
            {
                decimal soma = 0;
                decimal dinheiro = 0;
                decimal cheque = 0;
                decimal cartaodebito = 0;
                decimal cartaocredito = 0;
                
                decimal fiado = 0;
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    soma = Convert.ToDecimal( dataGridView1.Rows[i].Cells[4].Value.ToString());
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "dinheiro")
                    {
                        dinheiro += soma;
                    }
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "cartão de débito")
                    {
                        cartaodebito += soma;
                    }
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "cartão de crédito")
                    {
                        cartaocredito += soma;
                    }
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "cheque")
                    {
                        cheque += soma;
                    }
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString() == "Pagamento Misto")
                    {
                        DataTable misto = DALCadastro.ListaMisto(dataGridView1.Rows[i].Cells[6].Value.ToString());
                        if (misto.Rows.Count > 0)
                        {
                            decimal soma8 = 0;
                            for (int j = 0; j < misto.Rows.Count; j++)
                            {
                                if (misto.Rows[j]["Pagamento"].ToString() == "dinheiro")
                                {
                                    soma8 = Convert.ToDecimal(misto.Rows[j]["Valor_Total"].ToString());
                                    dinheiro += soma8;
                                }
                                if (misto.Rows[j]["Pagamento"].ToString() == "cartão de débito")
                                {
                                    soma8 = Convert.ToDecimal(misto.Rows[j]["Valor_Total"].ToString());
                                    cartaodebito += soma8;
                                }
                                if (misto.Rows[j]["Pagamento"].ToString() == "cartão de crédito")
                                {
                                    soma8 = Convert.ToDecimal(misto.Rows[j]["Valor_Total"].ToString());
                                    cartaocredito += soma8;
                                }
                                if (misto.Rows[j]["Pagamento"].ToString() == "cheque")
                                {
                                    soma8 = Convert.ToDecimal(misto.Rows[j]["Valor_Total"].ToString());
                                    cheque += soma8;
                                }
                            }
                        }
                    }   
                    
                }
                DataTable fia = DALCadastro.ParcialLista(Global.Margem.CaixaSelecionado);
                if (fia.Rows.Count > 0)
                {
                    for (int i = 0; i < fia.Rows.Count; i++)
                    {
                        fiado += Convert.ToDecimal( fia.Rows[i]["Valor"].ToString());
                        if (fia.Rows[i]["Pagamento"].ToString() == "dinheiro")
                        {
                            dinheiro += Convert.ToDecimal(fia.Rows[i]["Valor"].ToString());
                        }
                        if (fia.Rows[i]["Pagamento"].ToString() == "cartão de débito")
                        {
                            cartaodebito += Convert.ToDecimal(fia.Rows[i]["Valor"].ToString());
                        }
                        if (fia.Rows[i]["Pagamento"].ToString() == "cartão de crédito")
                        {
                            cartaocredito += Convert.ToDecimal(fia.Rows[i]["Valor"].ToString());
                        }
                        if (fia.Rows[i]["Pagamento"].ToString() == "cheque")
                        {
                            cheque += Convert.ToDecimal(fia.Rows[i]["Valor"].ToString());
                        }

                       
                    }
                    textBox5.Text = Convert.ToString(fiado);
                }
                

                if (dinheiro > 0 )
                {
                    textBox1.Text = Convert.ToString(dinheiro) ;    
                }
                if (cartaodebito > 0)
                {
                    textBox2.Text = Convert.ToString(cartaodebito);     
                }
                if (cartaocredito > 0)
                {
                    textBox3.Text = Convert.ToString(cartaocredito);    
                }
                if (cheque > 0)
                {
                    textBox4.Text = Convert.ToString(cheque);    
                }
               
                decimal soma2 = 0;
                textBox8.Text = Global.Margem.ValorAberto;
                DataTable retirada = DALCadastro.ListaRetirada(Global.Margem.RetiradaCaixa);
                if (retirada.Rows.Count > 0)
                {
                    for (int i = 0; i < retirada.Rows.Count; i++)
                    {
                        soma2 += Convert.ToDecimal( retirada.Rows[i][1].ToString());
                        
                    }
                    textBox9.Text = Convert.ToString(soma2);
                }
                
                textBox7.Text = textBox8.Text;

                textBox6.Text = Convert.ToString(dinheiro + cartaocredito + cartaodebito + cheque - soma2);
                
                /*if (checkBox1.Checked == true )
	            {
                    if (String.IsNullOrEmpty(textBox5.Text) == false)
                    {
                        
                        decimal temp = Convert.ToDecimal(textBox5.Text);
                        temp = Convert.ToDecimal(textBox6.Text) + temp;
                        textBox6.Text = Convert.ToString(temp);
                    }
                    if (String.IsNullOrEmpty(textBox5.Text) == true)
                    {
                        textBox6.Text = Convert.ToString(dinheiro + cartaocredito + cartaodebito + cheque - soma2 );
                    }

                        
	            }
                if (checkBox1.Checked == false)
                {
                    if (String.IsNullOrEmpty(textBox5.Text) == false)
                    {
                        textBox6.Text = Convert.ToString(dinheiro + cartaocredito + cartaodebito + cheque - soma2 );
                        /*decimal temp = Convert.ToDecimal(textBox5.Text);
                        temp = Convert.ToDecimal(textBox6.Text) + temp;
                        textBox6.Text = Convert.ToString(temp);
                    }
                    if (String.IsNullOrEmpty(textBox5.Text) == true)
                    {
                        textBox6.Text = Convert.ToString(dinheiro + cartaocredito + cartaodebito + cheque - soma2);
                    }
                }*/
                if (checkBox2.Checked == true)
                {
                    textBox6.Text = Convert.ToString( Convert.ToDecimal(textBox6.Text) + Convert.ToDecimal(textBox7.Text));
                     
                }
                
                
            }
            DataTable fiadi = DALCadastro.ParcialLista(Global.Margem.CaixaSelecionado);
            DataTable reti = DALCadastro.ListaRetirada(Global.Margem.RetiradaCaixa);
            if (dataGridView1.Rows.Count <= 0 && fiadi.Rows.Count == 0 && reti.Rows.Count == 0)
            {
                DataTable retirada = DALCadastro.ListaRetirada(Global.Margem.RetiradaCaixa);
                decimal soma3 = 0;
                string retira = "";
                string tot = "";
                if (retirada.Rows.Count > 0)
                {
                    for (int i = 0; i < retirada.Rows.Count; i++)
                    {
                        soma3 += Convert.ToDecimal(retirada.Rows[i][1].ToString());

                    }
                    retira = Convert.ToString(soma3);
                    
                }
                if (retirada.Rows.Count <= 0)
                {
                    retira = "0,00";
                }
                tot = Convert.ToString(Convert.ToDecimal(Global.Margem.ValorAberto) - Convert.ToDecimal(retira));

                string message = "Não foi realizada nenhuma venda neste período.\nSaldo Inicial : " + Global.Margem.ValorAberto +
                    " ==> Retiradas : " + retira + "\nTotal no Caixa : " + tot + "\nCaixa será fechado." ;
                
                MessageBox.Show(message);
                this.Close();
                    
                    
                
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "0,00")
            {
                if (checkBox1.Checked == true)
                {
                   //textBox6.Text = Convert.ToString(Convert.ToDecimal(textBox6.Text) + Convert.ToDecimal(textBox5.Text));
                }
                if (checkBox1.Checked == false)
                {
                    //textBox6.Text = Convert.ToString(Convert.ToDecimal(textBox6.Text) - Convert.ToDecimal(textBox5.Text));
                    checkBox1.Checked = true;
                }
            }
                
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

                DataTable fiadi = DALCadastro.ParcialLista(Global.Margem.CaixaSelecionado);
                DataTable reti = DALCadastro.ListaRetirada(Global.Margem.RetiradaCaixa);
                string message = "Você deseja Finalizar/Fechar o Caixa?";
                string caption = "Fechamento";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Mostra a MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    
                    if (dataGridView1.Rows.Count <= 0 && fiadi.Rows.Count == 0 && reti.Rows.Count == 0)
                    {
                        string message1 = "Não foi realizada nenhuma venda neste período\nO Caixa será fechado";
                        string caption1 = "Fechamento";
                        MessageBoxButtons buttons1 = MessageBoxButtons.YesNo;
                        DialogResult result1;

                        // Mostra a MessageBox.

                        result1 = MessageBox.Show(this, message1, caption1, buttons1,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result1 == DialogResult.Yes)
                        {
                            using (StreamWriter writer = new StreamWriter("CaixaAberto.txt"))
                            {
                                writer.Write("não");
                                Global.Margem.CaixaAberto = "não";
                                DALCadastro.DeletaRetirada(Global.Margem.RetiradaCaixa);
                                this.Close();


                            }



                        }
                        
                    }
                    if (dataGridView1.Rows.Count > 0 || fiadi.Rows.Count > 0 || reti.Rows.Count > 0)
                    {
                        string strConnection = "";
                        if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
                        {
                            strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                        }
                        if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
                        {
                            string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                            string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                            strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
                        }
                        String strSQL = "FechamentoCaixaOK";
                        //cria a conexão com o banco de dados
                        OleDbConnection dbConnection = new OleDbConnection(strConnection);
                        //cria a conexão com o banco de dados
                        OleDbConnection con = new OleDbConnection(strConnection);
                        //cria o objeto command para executar a instruçao sql
                        OleDbCommand cmd = new OleDbCommand(strSQL, con);
                        //abre a conexao
                        con.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Caixa", Global.Margem.CaixaAberto);
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                        //cria um objeto datatable
                        DataTable clientes = new DataTable();
                        //preenche o datatable via dataadapter
                        da.Fill(clientes);
                        con.Dispose();
                        con.Close();
                        cmd.Dispose();
                        dbConnection.Dispose();
                        dbConnection.Close();

                        
                        using (StreamWriter writer = new StreamWriter("CaixaAberto.txt"))
                        {
                            writer.Write("não");
                            Global.Margem.CaixaAberto = "não";
                            DALCadastro.DeletaRetirada(Global.Margem.RetiradaCaixa);
                            this.Close();
                        }
                        if (fiadi.Rows.Count > 0)
                        {
                            DALCadastro.ParcialDeleta(Global.Margem.CaixaSelecionado);
                        }
                        MessageBox.Show("Fechamento de caixa concluído.\nTotal das vendas : " + textBox6.Text);
                        checkBox1.Checked = true;
                        checkBox2.Checked = true;
                        
                        Global.Margem.FechamentoCaixad = "Total dinheiro : " + textBox1.Text + "\n";
                        Global.Margem.FechamentoCaixacd = "Total cartão débito : " + textBox2.Text + "\n";
                        Global.Margem.FechamentoCaixacc = "Total cartão crédito : " + textBox3.Text + "\n";
                        Global.Margem.FechamentoCaixac = "Total cheque : " + textBox4.Text + "\n";
                        //Global.Margem.FechamentoCaixaf = "Total fiado : " + textBox5.Text + "\n";
                        
                        Global.Margem.FechamentoCaixaf = "Inicial : [" + textBox7.Text + "] - Retiradas : [" + textBox9.Text + "]\n\n";
                        
                        Global.Margem.FechamentoCaixa = "Valor Total : " + textBox6.Text + "\n";
                        DALCadastro.InsereImpressao("Fechamento");

                    }
                }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox6.Text = Convert.ToString( Convert.ToDecimal(textBox6.Text) + Convert.ToDecimal(textBox7.Text) );
            }
            if (checkBox2.Checked == false)
            {
                textBox6.Text = Convert.ToString(Convert.ToDecimal(textBox6.Text) - Convert.ToDecimal(textBox7.Text));
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Global.Margem.Cancelar = "OK";
            this.Close();
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = System.Drawing.Color.Black;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox6.Text = Convert.ToString(Convert.ToDecimal(textBox6.Text) - Convert.ToDecimal(textBox9.Text));
            }
            if (checkBox3.Checked == false)
            {
                textBox6.Text = Convert.ToString(Convert.ToDecimal(textBox6.Text) + Convert.ToDecimal(textBox9.Text));
            }
        }

        private void FecharCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                string ret = "";
                //abrir retiradas
                DataTable retirada = DALCadastro.ListaRetirada(Global.Margem.RetiradaCaixa);
                if (retirada.Rows.Count > 0)
                {
                    for (int i = 0; i < retirada.Rows.Count; i++)
                    {
                        ret += retirada.Rows[i]["Valor"].ToString() + " ==> " + retirada.Rows[i]["Motivo"].ToString() + " ==> " +
                            retirada.Rows[i]["Caixa"].ToString() + "\n";
                    }
                    MessageBox.Show(ret);
                }
                if (retirada.Rows.Count <= 0)
                {
                    MessageBox.Show("Não houve retiradas do caixa.");
                }
                
            }
            if (e.KeyCode == Keys.Escape)
            {
                Global.Margem.Cancelar = "OK";
                this.Close();
            }
            if (e.KeyCode == Keys.F2)
            {
                Form detalhes = new ParcialList();
                detalhes.ShowDialog();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string ret = "Retiradas : \n";
            //abrir retiradas
            DataTable retirada = DALCadastro.ListaRetirada(Global.Margem.RetiradaCaixa);
            if (retirada.Rows.Count > 0)
            {
                for (int i = 0; i < retirada.Rows.Count; i++)
                {
                    ret += retirada.Rows[i]["Valor"].ToString() + " ==> " + retirada.Rows[i]["Motivo"].ToString() + " ==> " +
                        retirada.Rows[i]["Caixa"].ToString() + "\n";
                }
                MessageBox.Show(ret);
            }
            if (retirada.Rows.Count <= 0)
            {
                MessageBox.Show("Não houve retiradas do caixa.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form detalhes = new ParcialList();
            detalhes.ShowDialog();
        }
    }
}
