using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class QuitaFiado : Form
    {
        public QuitaFiado()
        {
            InitializeComponent();
        }

        private void QuitaFiado_Load(object sender, EventArgs e)
        {
            textBox2.Text = Global.Margem.SaldoDevedorFiado;
            textBox3.Text = Global.Margem.CompraAtual;
            label4.Text = Global.Margem.QuitafiadoPag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = System.DateTime.Now.ToShortDateString();
            string datacalc = "";
            string ano = DateTime.Now.Year.ToString();
            string mes = DateTime.Now.Month.ToString();
            if (mes.Length < 2)
            {
               mes = "0" + mes;
            }
            string dia = DateTime.Now.Day.ToString();
            if (dia.Length < 2)
            {
               dia = "0" + dia;
            }
            datacalc = ano + mes + dia;             
            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                textBox1.Text = textBox1.Text.Replace(".",",");
                int ponto = 0;
                for (int i = 0; i < textBox1.Text.Length; i++)
                {
                    if (textBox1.Text.Substring(i,1) == ",")
                    {
                        ponto = ponto + 1;
                    }
                    if (ponto > 1)
                    {
                        MessageBox.Show("Valor em formato incorreto");
                        textBox1.Text = "";
                        textBox1.Focus();
                        return;
                    }
                }
                Int64 qtde;
                if (Int64.TryParse(textBox1.Text.Replace(",","").Trim(), out qtde) == false)
                {
                    MessageBox.Show("Favor informar somente valores numéricos");
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                DataTable sal = DALCadastro.ListaParcial(Global.Margem.ClienteFiado);
                if (sal.Rows.Count <= 0)
                {
                    decimal saldo = Convert.ToDecimal(textBox2.Text);
                    if (Convert.ToDecimal(textBox1.Text) == saldo)
                    {
                        MessageBox.Show("A dívida será totalmente quitada.\nSaldo Devedor : 0,00");
                        DALCadastro.FluxoVendaFiadoQuitaConta(Global.Margem.ClienteFiado, label4.Text);
                        DALCadastro.ParcialInsere(Global.Margem.ClienteFiado,textBox1.Text,label4.Text,Global.Margem.CaixaSelecionado);
                        DALCadastro.InsereAUXVendas("Pagamento total de saldo devedor fiado", Global.Margem.BaixaVendasFiado, Global.Margem.ClienteFiado, label4.Text,
                                       "Pagamento Fiado Parcial", textBox1.Text, data, Convert.ToInt32(datacalc));

                        MessageBox.Show("1");

                        //------------------------------SAT-------------------------------------------------------


                        using (StreamWriter writer = new StreamWriter("CupomResumido.txt"))
                        {
                            writer.WriteLine("Baixa de Vendas a prazo");
                            writer.WriteLine(".");
                            writer.WriteLine("Pagamento total de saldo devedor");
                            writer.WriteLine("Vendas : " + Global.Margem.BaixaVendasFiado);
                            writer.WriteLine("Total Pago :" + textBox1.Text);
                            writer.WriteLine("Pagamento " + label4.Text);
                            writer.WriteLine("Cliente : " + Global.Margem.ClienteFiado);
                            writer.WriteLine("Data : " + data);

                        }
                        DALCadastro.InsereImpressao("CupomResumido");
                        this.Close();
                        return;
                    }
                    if (Convert.ToDecimal(textBox1.Text) < saldo)
                    {
                        
                        DataTable fi = DALCadastro.FluxoVendaFiado(Global.Margem.ClienteFiado);
                        
                        string vendas1 = "";
                        string repete = "";
                        
                        if (fi.Rows.Count > 0)
	                    {
                            
                            for (int i = 0; i < fi.Rows.Count; i++)
			                {
			                    DALCadastro.FiadoPAGParcial(fi.Rows[i]["Venda_Numero"].ToString());

                                string temp = fi.Rows[i]["Venda_Numero"].ToString();
                                if (repete != temp)
                                {
                                    vendas1 += fi.Rows[i]["Venda_Numero"].ToString() + "|";
                                    repete = fi.Rows[i]["Venda_Numero"].ToString();

                                    
                                }
                                
			                }
                                
	                    }
                        DALCadastro.ParcialInsere(Global.Margem.ClienteFiado, textBox1.Text, label4.Text, Global.Margem.CaixaSelecionado);
                        decimal tempDEC = Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox1.Text);
                        DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado,textBox2.Text,textBox1.Text,DateTime.Now.ToLongDateString(),vendas1);
                        MessageBox.Show("Quitado parcialmente Venda(s) número(s) : " + vendas1 + "\nSaldo Devedor : " + Convert.ToString(tempDEC));
                        //insere auxvendas
                        DALCadastro.InsereAUXVendas("Pagamento Parcial de Fiado", vendas1, Global.Margem.ClienteFiado, label4.Text,
                            "Pagamento Fiado Parcial", textBox1.Text, data, Convert.ToInt32(datacalc));

                        MessageBox.Show("2");

                        using (StreamWriter writer = new StreamWriter("CupomResumido.txt"))
                        {
                            writer.WriteLine("Baixa de Vendas a prazo");
                            writer.WriteLine(".");
                            writer.WriteLine("Pagamento parcial de saldo devedor");
                            writer.WriteLine("Vendas : " + vendas1);
                            writer.WriteLine("Total Pago :" + textBox1.Text);
                            writer.WriteLine("Saldo Devedor: " + Convert.ToString(tempDEC));
                            writer.WriteLine("Pagamento " + label4.Text);
                            writer.WriteLine("Cliente : " + Global.Margem.ClienteFiado);
                            writer.WriteLine("Data : " + data);

                        }
                        DALCadastro.InsereImpressao("CupomResumido");
                        
                        this.Close();
                        return;
                    }
                    if (Convert.ToDecimal(textBox1.Text) > saldo)
                    {
                        MessageBox.Show("Valor informado maior que o saldo devedor");
                        textBox1.Text = "";
                        textBox1.Focus();
                        return;                        
                    }
                }
                
                if (sal.Rows.Count > 0)
                {
                    decimal saldo = Convert.ToDecimal(textBox2.Text);
                    if (Convert.ToDecimal(textBox1.Text) > saldo)
                    {
                        MessageBox.Show("Valor informado maior que o saldo devedor");
                        textBox1.Text = "";
                        textBox1.Focus();
                        return;  
                    }
                    if (Convert.ToDecimal(textBox1.Text) == saldo)
                    {

                        
                        string vendNum = "";
                        string numVEnda = "";
                        for (int i = 0; i < sal.Rows.Count; i++)
                        {
                            string vend = sal.Rows[i]["Vendas"].ToString();
                            for (int j = 0; j < vend.Length; j++)
                            {
                                if (vend.Substring(j,1) != "|")
                                {
                                    numVEnda += vend.Substring(j,1);
                                }
                                if (vend.Substring(j, 1) == "|")
                                {
                                    DALCadastro.QuitaVendaParcial(numVEnda,label4.Text);
                                    vendNum += " [" + numVEnda + "]" ;
                                                                
                                    numVEnda = "";
                                }
                            }
                            DALCadastro.DeletaFiadoParcial(Convert.ToInt32( sal.Rows[i]["Id"].ToString()),Global.Margem.ClienteFiado);
                            
                            DataTable aberta = DALCadastro.FluxoVendaFiado(Global.Margem.ClienteFiado);

                            

                            if (aberta.Rows.Count > 0)
                            {
                                for (int k = 0; k < aberta.Rows.Count; k++)
                                {
                                    DALCadastro.QuitaVendaParcial(aberta.Rows[i]["Venda_Numero"].ToString(),label4.Text);
                                    vendNum += " [" + aberta.Rows[i]["Venda_Numero"].ToString() + "] " ;
                                }
                            }
                            
                        }
                        DALCadastro.ParcialInsere(Global.Margem.ClienteFiado, textBox1.Text, label4.Text, Global.Margem.CaixaSelecionado);
                        MessageBox.Show("A dívida será totalmente quitada.\nAs seguintes vendas serão quitadas automaticamente : \n" + vendNum);
                        //insere auxvendas
                        DALCadastro.InsereAUXVendas("Pagamento Total de Fiado", vendNum, Global.Margem.ClienteFiado, label4.Text,
                            "Pagamento Fiado Parcial", textBox1.Text, data, Convert.ToInt32(datacalc));

                        MessageBox.Show("3");

                        using (StreamWriter writer = new StreamWriter("CupomResumido.txt"))
                        {
                            writer.WriteLine("Baixa de Vendas a prazo");
                            writer.WriteLine(".");
                            writer.WriteLine("Pagamento total de saldo devedor");
                            writer.WriteLine("Vendas : " + vendNum);
                            writer.WriteLine("Total Pago :" + textBox1.Text);
                            writer.WriteLine("Pagamento " + label4.Text);
                            writer.WriteLine("Cliente : " + Global.Margem.ClienteFiado);
                            writer.WriteLine("Data : " + data);

                        }
                        DALCadastro.InsereImpressao("CupomResumido");
                     
                        this.Close();
                        return;
                        
                    }
                    if (Convert.ToDecimal(textBox1.Text) < saldo)
                    {
                        bool sinal = false;
                        string deve = "";
                        decimal inicio = Convert.ToDecimal(textBox1.Text);
                        
                        string semaforo = "";
                        if (sinal == false && inicio > 0)
                        {
                            for (int i = 0; i < sal.Rows.Count; i++)
                            {
                                if (inicio < Convert.ToDecimal(sal.Rows[i]["Total_Devedor"].ToString() ) - Convert.ToDecimal(sal.Rows[i]["Valor_Parcial"].ToString()) )
                                {
                                    deve += "Quitado parcialmente saldo devedor da Data : " + sal.Rows[i]["Data"].ToString() + "\nVendas : " + sal.Rows[i]["Vendas"].ToString() + "\n";
                                    decimal resul = inicio + Convert.ToDecimal(sal.Rows[i]["Valor_Parcial"].ToString());
                                    DALCadastro.AtualizaParcialFiado(Convert.ToInt32( sal.Rows[i]["Id"].ToString() ),Global.Margem.ClienteFiado,Convert.ToString(resul));
                                    deve += "Novo saldo devedor : " + Convert.ToString( Convert.ToDecimal(sal.Rows[i]["Total_Devedor"].ToString()) - resul) + "\n\n";
                                    DALCadastro.ParcialInsere(Global.Margem.ClienteFiado, textBox1.Text, label4.Text, Global.Margem.CaixaSelecionado);
                                     //insere auxvendas
                                    DALCadastro.InsereAUXVendas("Pagamento Parcial de saldo devedor fiado", sal.Rows[i]["Vendas"].ToString(), Global.Margem.ClienteFiado, label4.Text,
                                         "Pagamento Fiado Parcial",Convert.ToString( inicio), data, Convert.ToInt32(datacalc));

                                    MessageBox.Show("4");

                                    using (StreamWriter writer = new StreamWriter("CupomResumido.txt"))
                                    {
                                        writer.WriteLine("Baixa de Vendas a prazo");
                                        writer.WriteLine(".");
                                        writer.WriteLine("Pagamento parcial de saldo devedor");
                                        writer.WriteLine("Vendas : " + sal.Rows[i]["Vendas"].ToString());
                                        writer.WriteLine("Total Pago :" + Convert.ToString(inicio));
                                        writer.WriteLine("Saldo Devedor atualizado: " + Convert.ToString(Convert.ToDecimal(sal.Rows[i]["Total_Devedor"].ToString()) - resul));
                                        writer.WriteLine("Pagamento " + label4.Text);
                                        writer.WriteLine("Cliente : " + Global.Margem.ClienteFiado);
                                        writer.WriteLine("Data : " + data);

                                    }
                                    DALCadastro.InsereImpressao("CupomResumido");
                                    inicio = 0;
                                    sinal = true;
                                    
                                
                                }
                                
                                if (inicio == Convert.ToDecimal(sal.Rows[i]["Total_Devedor"].ToString()) - Convert.ToDecimal(sal.Rows[i]["Valor_Parcial"].ToString()))
                                {
                                    deve += "Quitado saldo devedor da Data : " + sal.Rows[i]["Data"].ToString() + "\nVendas : " + sal.Rows[i]["Vendas"].ToString();
                                    string numVEnda = "";
                                    string temp5 = "";
                                    for (int l = 0; l < sal.Rows.Count; l++)
                                    {
                                        string vend = sal.Rows[l]["Vendas"].ToString();
                                        for (int m = 0; m < vend.Length; m++)
                                        {
                                            if (vend.Substring(m, 1) != "|")
                                            {
                                                numVEnda += vend.Substring(m, 1);
                                            }
                                            if (vend.Substring(m, 1) == "|")
                                            {
                                                DALCadastro.QuitaVendaParcial(numVEnda, label4.Text);
                                                temp5 = numVEnda;
                                                numVEnda = "";
                                            }
                                        }
                                        DALCadastro.DeletaFiadoParcial(Convert.ToInt32(sal.Rows[i]["Id"].ToString()), Global.Margem.ClienteFiado);
                                        DALCadastro.ParcialInsere(Global.Margem.ClienteFiado, textBox1.Text, label4.Text, Global.Margem.CaixaSelecionado);
                                        DALCadastro.InsereAUXVendas("Pagamento total de saldo devedor fiado", temp5, Global.Margem.ClienteFiado, label4.Text,
                                         "Pagamento Fiado Parcial",Convert.ToString(inicio), data, Convert.ToInt32(datacalc));
                                        MessageBox.Show("5");

                                        using (StreamWriter writer = new StreamWriter("CupomResumido.txt"))
                                        {
                                            writer.WriteLine("Baixa de Vendas a prazo");
                                            writer.WriteLine(".");
                                            writer.WriteLine("Pagamento total de saldo devedor");
                                            writer.WriteLine("Vendas : " + temp5);
                                            writer.WriteLine("Total Pago :" + Convert.ToString(inicio));
                                            writer.WriteLine("Pagamento " + label4.Text);
                                            writer.WriteLine("Cliente : " + Global.Margem.ClienteFiado);
                                            writer.WriteLine("Data : " + data);

                                        }
                                        DALCadastro.InsereImpressao("CupomResumido");
                                        
                                        inicio = 0;
                                        sinal = true;
                                    } 
                                }
                                if (inicio > Convert.ToDecimal(sal.Rows[i]["Total_Devedor"].ToString()) - Convert.ToDecimal(sal.Rows[i]["Valor_Parcial"].ToString()))
                                {
                                    deve += "Quitado saldo devedor da Data : " + sal.Rows[i]["Data"].ToString() + "\nVendas : " + sal.Rows[i]["Vendas"].ToString() + "\n\n";
                                    string numVEnda = "";
                                    string temp6 = "";
                                    for (int l = 0; l < sal.Rows.Count; l++)
                                    {
                                        string vend = sal.Rows[l]["Vendas"].ToString();
                                        for (int m = 0; m < vend.Length; m++)
                                        {
                                            if (vend.Substring(m, 1) != "|")
                                            {
                                                numVEnda += vend.Substring(m, 1);
                                            }
                                            if (vend.Substring(m, 1) == "|")
                                            {
                                                DALCadastro.QuitaVendaParcial(numVEnda, label4.Text);
                                                temp6 = numVEnda;
                                                numVEnda = "";
                                            }
                                        }
                                        DALCadastro.DeletaFiadoParcial(Convert.ToInt32( sal.Rows[l]["Id"].ToString()),Global.Margem.ClienteFiado);
                                        decimal result = Convert.ToDecimal(sal.Rows[i]["Total_Devedor"].ToString()) - Convert.ToDecimal(sal.Rows[i]["Valor_Parcial"].ToString());
                                        DALCadastro.ParcialInsere(Global.Margem.ClienteFiado, Convert.ToString(inicio), label4.Text, Global.Margem.CaixaSelecionado);
                                        DALCadastro.InsereAUXVendas("Pagamento total de saldo devedor fiado", temp6, Global.Margem.ClienteFiado, label4.Text,
                                        "Pagamento Fiado Parcial", Convert.ToString(inicio), data, Convert.ToInt32(datacalc));

                                        MessageBox.Show("10");
                                        
                                        using (StreamWriter writer = new StreamWriter("CupomResumido.txt"))
                                        {
                                            writer.WriteLine("Baixa de Vendas a prazo");
                                            writer.WriteLine(".");
                                            writer.WriteLine("Pagamento total de saldo devedor");
                                            writer.WriteLine("Vendas : " + temp6);
                                            writer.WriteLine("Total Pago :" + Convert.ToString(inicio));
                                            writer.WriteLine("Pagamento " + label4.Text);
                                            writer.WriteLine("Cliente : " + Global.Margem.ClienteFiado);
                                            writer.WriteLine("Data : " + data);

                                        }
                                        DALCadastro.InsereImpressao("CupomResumido");

                                        inicio = inicio - result;
                                        semaforo = "verde";
                                    }
                                    
                                }
                            
                            }
                            if (semaforo == "verde")
	                        {
                                decimal saldo2 = Convert.ToDecimal(textBox3.Text);
                                if (inicio == saldo2)
                                {
                                    deve += "A dívida será totalmente quitada (débitos anteriores + compra atual).\n\n";
                                    DALCadastro.FluxoVendaFiadoQuitaConta(Global.Margem.ClienteFiado, label4.Text);
                                    DALCadastro.ParcialInsere(Global.Margem.ClienteFiado, Convert.ToString(inicio), label4.Text, Global.Margem.CaixaSelecionado);
                                    DALCadastro.InsereAUXVendas("Pagamento total de saldo devedor fiado", Global.Margem.BaixaVendasFiado, Global.Margem.ClienteFiado, label4.Text,
                                        "Pagamento Fiado Parcial", Convert.ToString(inicio), data, Convert.ToInt32(datacalc));
                                    MessageBox.Show("6");

                                    using (StreamWriter writer = new StreamWriter("CupomResumido.txt"))
                                    {
                                        writer.WriteLine("Baixa de Vendas a prazo");
                                        writer.WriteLine(".");
                                        writer.WriteLine("Pagamento total de saldo devedor");
                                        writer.WriteLine("Vendas : " + Global.Margem.BaixaVendasFiado);
                                        writer.WriteLine("Total Pago :" + textBox1.Text);
                                        writer.WriteLine("Pagamento " + label4.Text);
                                        writer.WriteLine("Cliente : " + Global.Margem.ClienteFiado);
                                        writer.WriteLine("Data : " + data);

                                    }
                                    DALCadastro.InsereImpressao("CupomResumido");
                                    
                                    this.Close();
                                    return;
                                }
                                if (inicio < saldo2)
                                {
                                    DataTable fi = DALCadastro.FluxoVendaFiado(Global.Margem.ClienteFiado);
                                    string vendas1 = "";
                                    string repete = "";
                                    if (fi.Rows.Count > 0)
                                    {
                                        
                                        for (int i = 0; i < fi.Rows.Count; i++)
                                        {
                                            
                                            DALCadastro.FiadoPAGParcial(fi.Rows[i]["Venda_Numero"].ToString());
                                            string temp = fi.Rows[i]["Venda_Numero"].ToString();
                                            if (repete != temp)
                                            {
                                                vendas1 += fi.Rows[i]["Venda_Numero"].ToString() + "|";
                                                repete = fi.Rows[i]["Venda_Numero"].ToString();
                                            }
                                            
                                            
                                        }

                                    }
                                    DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado, Convert.ToString(saldo2),
                                        Convert.ToString(inicio), DateTime.Now.ToLongDateString(), vendas1);
                                    DALCadastro.ParcialInsere(Global.Margem.ClienteFiado, Convert.ToString(inicio), label4.Text,Global.Margem.CaixaSelecionado);
                                    DALCadastro.InsereAUXVendas("Pagamento Parcial de saldo devedor fiado", vendas1, Global.Margem.ClienteFiado, label4.Text,
                                         "Pagamento Fiado Parcial", Convert.ToString(inicio), data, Convert.ToInt32(datacalc));

                                    MessageBox.Show("7");

                                    using (StreamWriter writer = new StreamWriter("CupomResumido.txt"))
                                    {
                                        writer.WriteLine("Baixa de Vendas a prazo");
                                        writer.WriteLine(".");
                                        writer.WriteLine("Quitado parcialmente saldo devedor atual");
                                        writer.WriteLine("Todos os débitos anteriores foram quitados");
                                        writer.WriteLine("Total Pago :" + textBox1.Text);
                                        writer.WriteLine("Saldo devedor atual: " + Convert.ToString(saldo2 - inicio));
                                        writer.WriteLine("Vendas : " + Global.Margem.BaixaVendasFiado);                                     
                                        writer.WriteLine("Pagamento " + label4.Text);
                                        writer.WriteLine("Cliente : " + Global.Margem.ClienteFiado);
                                        writer.WriteLine("Data :");
                                        writer.WriteLine(data);

                                    }
                                    DALCadastro.InsereImpressao("CupomResumido");
                                    
                                    deve += "Quitado parcialmente saldo devedor atual.\n\nTodos os débitos anteriores foram quitados\n";
                                    deve += "Saldo devedor atual : " + Convert.ToString(saldo2 - inicio);
                                    
                                    
                                }
                               
	                        }
                        }
                       
                        MessageBox.Show(deve);
                        this.Close();
                        
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Informe o valor pago");
            }
        }
    }
}
