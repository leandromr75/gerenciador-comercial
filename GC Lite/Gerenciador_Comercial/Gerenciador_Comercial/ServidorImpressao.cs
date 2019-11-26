using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace Gerenciador_Comercial
{
    public partial class ServidorImpressao : Form
    {
        public ServidorImpressao()
        {
            InitializeComponent();
            
        }
        int iRetorno = 0;
        
        int tipoLetra = 1;
        int italico = 0;
        int sublinhado = 0;
        int expandido = 0;
        int enfatizado = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            string pag = "";
            dataGridView1.DataSource = DALCadastro.ListaImpressao();
            if (dataGridView1.Rows.Count > 0)
            {
                timer1.Enabled = false;
                if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "ImprimeCodeBar")
                {
                    if (Global.Margem.Impressora == "mp4200th")
                    {
                        MP2032.ImprimeBitmap(Global.Margem.CodeBarURL , 0);
                        MP2032.FormataTX( "\n\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                        MP2032.FormataTX(Global.Margem.CodeBarTexto , tipoLetra, italico, sublinhado, expandido, enfatizado);

                        DALCadastro.DeletaImpressao(dataGridView1.Rows[0].Cells[0].Value.ToString());

                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        label1.Text = "Aguardando Impressão de Cupom";
                        timer1.Enabled = true;
                        return;
                    }
                }
                if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "Fechamento")
                {
                    if (Global.Margem.Impressora == "generic")
                    {
                        using (StreamWriter writer = new StreamWriter("Venda.txt"))
                        {
                            if (Global.Margem.Impressora == "generic")
                            {
                                writer.WriteLine("*********************************************");
                                writer.WriteLine("---------------------------------------------");
                                writer.WriteLine(DateTime.Now.ToLongDateString().Replace("ç","c"));
                                writer.WriteLine(Global.Margem.FechamentoCaixad);
                                writer.WriteLine(Global.Margem.FechamentoCaixacd);
                                writer.WriteLine(Global.Margem.FechamentoCaixacc);
                                writer.WriteLine(Global.Margem.FechamentoCaixac);
                                writer.WriteLine(Global.Margem.FechamentoCaixaf);
                                writer.WriteLine("---------------------------------------------");
                                writer.WriteLine(Global.Margem.FechamentoCaixa);
                                writer.WriteLine("---------------------------------------------");
                                writer.WriteLine("*********************************************");
                                
                            }
                        }
                        ReadFile();
                        printDocument1.Print();
                        using (StreamWriter writer = new StreamWriter("Venda.txt"))
                        {
                            writer.WriteLine("---------------------------------------------");
                        }
                        DALCadastro.DeletaImpressao(dataGridView1.Rows[0].Cells[0].Value.ToString());

                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        label1.Text = "Aguardando Impressão de Cupom";
                        Global.Margem.FechamentoCaixacd = "";
                        Global.Margem.FechamentoCaixacc = "";
                        Global.Margem.FechamentoCaixac = "";
                        Global.Margem.FechamentoCaixad = "";
                        Global.Margem.FechamentoCaixa = "";
                        Global.Margem.FechamentoCaixaf = "";
                        timer1.Enabled = true;   
                        return;
                    }
                    if (Global.Margem.Impressora == "mp4200th")
                    {
                        MP2032.FormataTX("*****************************************************************" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                        MP2032.FormataTX("Fechamento do Caixa. " + DateTime.Now.ToLongDateString() + "\n\n", tipoLetra, italico, sublinhado, expandido, 1);
                        MP2032.FormataTX(Global.Margem.FechamentoCaixad + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                        MP2032.FormataTX(Global.Margem.FechamentoCaixacd + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                        MP2032.FormataTX(Global.Margem.FechamentoCaixacc + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                        MP2032.FormataTX(Global.Margem.FechamentoCaixac + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                        MP2032.FormataTX(Global.Margem.FechamentoCaixaf + "\n\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                        MP2032.FormataTX("-----------------------------------------------------------------" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                        MP2032.FormataTX(Global.Margem.FechamentoCaixa + "\n", tipoLetra, italico, sublinhado, expandido, 1);
                        MP2032.FormataTX("-----------------------------------------------------------------" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                        MP2032.FormataTX("*****************************************************************" + "\n\n\n", tipoLetra, italico, sublinhado, expandido, enfatizado);

                        DALCadastro.DeletaImpressao(dataGridView1.Rows[0].Cells[0].Value.ToString());

                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        label1.Text = "Aguardando Impressão de Cupom";
                        Global.Margem.FechamentoCaixacd = "";
                        Global.Margem.FechamentoCaixacc = "";
                        Global.Margem.FechamentoCaixac = "";
                        Global.Margem.FechamentoCaixad = "";
                        Global.Margem.FechamentoCaixa = "";
                        Global.Margem.FechamentoCaixaf = "";
                        timer1.Enabled = true;   
                        return;
                    }
                    return;

                }
                if (dataGridView1.Rows[0].Cells[0].Value.ToString() == "CupomResumido")
                {
                    if (Global.Margem.Impressora == "generic")
                    {
                        Global.Margem.CupomResumido = "sim";
                        ReadFile();
                        printDocument1.Print();

                        DALCadastro.DeletaImpressao(dataGridView1.Rows[0].Cells[0].Value.ToString());

                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        label1.Text = "Aguardando Impressão de Cupom";
                        
                        timer1.Enabled = true;
                        return;
                    }
                    if (Global.Margem.Impressora == "mp4200th")
                    {
                        string temp = "";
                        using (FileStream stream = new FileStream("CupomResumido.txt", FileMode.Open))
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            temp += reader.ReadToEnd();
                        }
                        MP2032.FormataTX(temp, tipoLetra, italico, sublinhado, expandido, enfatizado);
                        DALCadastro.DeletaImpressao(dataGridView1.Rows[0].Cells[0].Value.ToString());

                        dataGridView1.DataSource = null;
                        dataGridView2.DataSource = null;
                        label1.Text = "Aguardando Impressão de Cupom";

                        timer1.Enabled = true;
                        return;
                    }

                    
                }
                label1.Text = "Imprimindo Venda Número : " + dataGridView1.Rows[0].Cells[0].Value.ToString();

                dataGridView2.DataSource = DALCadastro.ProcuraVendaImpressao(dataGridView1.Rows[0].Cells[0].Value.ToString());
                
                
                //*********************************************************************
                //###########Cupom SAT#################################################
                //*********************************************************************
                
                
                //**********************************************************************
                //##########Cupom não Fiscal############################################
                //**********************************************************************
                if (dataGridView2.Rows.Count > 0)
                {
                    
                    
                    decimal soma = 0;
                    using (StreamWriter writer = new StreamWriter("Venda.txt"))
                    {
                        if (Global.Margem.Impressora == "generic")
                        {
                            writer.WriteLine("*********************************************");
                            writer.WriteLine(Global.Margem.CupomEmpresa);
                            writer.WriteLine("CNPJ-" + Global.Margem.CupomCNPJ + " | " + "IE-" + Global.Margem.CupomIE);
                            writer.WriteLine(Global.Margem.CupomTexto1);
                            writer.WriteLine(Global.Margem.CupomTexto2);
                            writer.WriteLine(DateTime.Now.ToLongDateString() + "|" + DateTime.Now.ToLongTimeString());
                            writer.WriteLine("*********************************************");
                            writer.WriteLine("---------------------------------------------");
                            writer.WriteLine("[Produto] x [Qtd] x [ValorUni] x [ValorTotal]");
                            writer.WriteLine("---------------------------------------------");    
                        }
                        if (Global.Margem.Impressora == "mp4200th")
                        {
                            MP2032.FormataTX("*****************************************************************" + "\n",tipoLetra, italico, sublinhado, expandido, enfatizado);
                            MP2032.FormataTX(Global.Margem.CupomEmpresa + "\n",tipoLetra, italico, sublinhado, expandido, 1);
                            MP2032.FormataTX("CNPJ-" + Global.Margem.CupomCNPJ + " - " + "IE-" + Global.Margem.CupomIE + "\n",tipoLetra, italico, sublinhado, expandido, enfatizado);
                            MP2032.FormataTX(Global.Margem.CupomTexto1 + "\n",tipoLetra, italico, sublinhado, expandido, enfatizado);
                            MP2032.FormataTX(Global.Margem.CupomTexto2.Replace("|","-") + "\n",tipoLetra, italico, sublinhado, expandido, enfatizado);
                            MP2032.FormataTX(DateTime.Now.ToLongDateString() + " [" + DateTime.Now.ToLongTimeString() + "]\n",tipoLetra, italico, sublinhado, expandido, enfatizado);
                            MP2032.FormataTX("*****************************************************************" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                            MP2032.FormataTX("-----------------------------------------------------------------" + "\n",tipoLetra, italico, sublinhado, expandido, enfatizado);
                            MP2032.FormataTX("[Produto] x [Quantidade] x [ValorUnitário] x [ValorTotal]" + "\n",tipoLetra, italico, sublinhado, expandido, 1);
                            MP2032.FormataTX("-----------------------------------------------------------------" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);    
                        }
                        for (int j = 0; j < dataGridView2.Rows.Count; j++)
                        {
                            string efrac = "não";
                            string prod = dataGridView2.Rows[j].Cells[0].Value.ToString();
                            string qtde = dataGridView2.Rows[j].Cells[1].Value.ToString();
                            string valorUnitario = dataGridView2.Rows[j].Cells[3].Value.ToString();
                            string valortotal = dataGridView2.Rows[j].Cells[4].Value.ToString();
                            for (int i = 0; i < valorUnitario.Length; i++)
                            {
                                if (valorUnitario.Substring(i, 1) == "g")
                                {
                                    efrac = "sim";
                                }
                            }
                            if (efrac == "não")
                            {
                                
                                if (prod.Length > 0 )
                                {
                                    if (Global.Margem.Impressora == "generic")
                                    {
                                        if (prod.Length >= 14)
                                        {
                                            prod = prod.Substring(0, 14);
                                        }
                                        if (prod.Length < 14)
                                        {
                                            prod = prod.Substring(0, prod.Length);
                                        }
                                    }
                                    if (Global.Margem.Impressora == "mp4200th")
                                    {
                                        if (prod.Length >= 25)
                                        {
                                            prod = prod.Substring(0, 25);
                                        }
                                        if (prod.Length < 25)
                                        {
                                            prod = prod.Substring(0, prod.Length);
                                        }
                                    }
                                    
                                    prod = prod.Replace("ã", "a");
                                    prod = prod.Replace("é", "e");
                                    prod = prod.Replace("á", "a");
                                    prod = prod.Replace("è", "e");
                                    prod = prod.Replace("à", "a");
                                    prod = prod.Replace("ç", "c");
                                    prod = prod.Replace("ê", "e");
                                    prod = prod.Replace("â", "a");
                                }
                                if (qtde.Length > 0)
                                {
                                    if (qtde.Length >= 4)
                                    {
                                        qtde = qtde.Substring(0, 4);
                                    }
                                    if (qtde.Length < 4)
                                    {
                                        qtde = qtde.Substring(0, qtde.Length);
                                    }
                                }
                                if (valorUnitario.Length > 0)
                                {
                                    if (valorUnitario.Length >= 8)
                                    {
                                        valorUnitario = valorUnitario.Substring(0, 8);
                                    }
                                    if (valorUnitario.Length < 8)
                                    {
                                        valorUnitario = valorUnitario.Substring(0, valorUnitario.Length);
                                    }
                                }
                                if (valortotal.Length > 0)
                                {
                                    if (valortotal.Length >= 10)
                                    {
                                        valortotal = valortotal.Substring(0, 10);
                                    }
                                    if (valortotal.Length < 10)
                                    {
                                        valortotal = valortotal.Substring(0, valortotal.Length);
                                    }

                                }
                            }
                            if (efrac == "sim")
                            {
                                if (prod.Length > 0)
                                {
                                    if (prod.Length >= 14)
                                    {
                                        prod = prod.Substring(0, 14);
                                    }
                                    if (prod.Length < 14)
                                    {
                                        prod = prod.Substring(0, prod.Length);
                                    }
                                    prod = prod.Replace("ã", "a");
                                    prod = prod.Replace("é", "e");
                                    prod = prod.Replace("á", "a");
                                    prod = prod.Replace("è", "e");
                                    prod = prod.Replace("à", "a");
                                    prod = prod.Replace("ç", "c");
                                    prod = prod.Replace("ê", "e");
                                    prod = prod.Replace("â", "a");
                                }
                                
                                if (valortotal.Length > 0)
                                {
                                    if (valortotal.Length >= 10)
                                    {
                                        valortotal = valortotal.Substring(0, 10);
                                    }
                                    if (valortotal.Length < 10)
                                    {
                                        valortotal = valortotal.Substring(0, valortotal.Length);
                                    }

                                }
                            }
                            soma += Convert.ToDecimal(dataGridView2.Rows[j].Cells[4].Value.ToString());
                            efrac = "não";
                            if (Global.Margem.Impressora == "generic")
	                        {
                                writer.WriteLine(prod + " | " + qtde + " | " + valorUnitario + " | " + valortotal);    		 
	                        }
                            if (Global.Margem.Impressora == "mp4200th")
	                        {
		                        MP2032.FormataTX("[" + prod + "] x [" + qtde + "] x [" + valorUnitario + "] x [" + valortotal + "]\n",tipoLetra, italico, sublinhado, expandido, enfatizado);
	                        }
                            
                        }
                        if (Global.Margem.Impressora == "generic")
	                    {
                            writer.WriteLine("---------------------------------------------");
                            writer.WriteLine("            Valor Total da Venda => " + Convert.ToString(soma));
                            writer.WriteLine("---------------------------------------------");
                        }
                        if (Global.Margem.Impressora == "mp4200th")
	                    {
                            MP2032.FormataTX("-----------------------------------------------------------------" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                            MP2032.FormataTX("            Valor Total da Venda => " + Convert.ToString(soma) + "\n",tipoLetra, italico, sublinhado, expandido, enfatizado);
                            MP2032.FormataTX("-----------------------------------------------------------------" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
	                    }
                       
                        pag = dataGridView2.Rows[0].Cells[5].Value.ToString();
                        
                       
                        pag = pag.Replace("ã","a");
                        pag = pag.Replace("é", "e");
                        pag = pag.Replace("á", "a");
                        pag = pag.Replace("è", "e");
                        pag = pag.Replace("à", "a");
                        pag = pag.Replace("ç", "c");
                        pag = pag.Replace("ê", "e");
                        pag = pag.Replace("â", "a");
                        if (Global.Margem.Impressora == "generic")
                        {
                            if (Global.Margem.PagParcialFiado == "sim")
                            {
                                writer.WriteLine("Pagamentos Parciais desta Venda :");
                                if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoD) == false)
                                {
                                    writer.WriteLine(Global.Margem.PagParcialFiadoD);    
                                }
                                if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoCC) == false)
                                {
                                    writer.WriteLine(Global.Margem.PagParcialFiadoCC);
                                }
                                if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoCD) == false)
                                {
                                    writer.WriteLine(Global.Margem.PagParcialFiadoCD);
                                }
                                if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoC) == false)
                                {
                                    writer.WriteLine(Global.Margem.PagParcialFiadoC);
                                }
                                writer.WriteLine(Global.Margem.PagParcialFiadoSaldoDevedor);
                                writer.WriteLine("Operador : " + dataGridView2.Rows[0].Cells[6].Value.ToString() + ", " + dataGridView2.Rows[0].Cells[7].Value.ToString());
                            }
                            else
                            {
                                writer.WriteLine("Pagamento : " + pag);
                                writer.WriteLine("Operador : " + dataGridView2.Rows[0].Cells[6].Value.ToString() + ", " + dataGridView2.Rows[0].Cells[7].Value.ToString());
                            }
                            
                        }
                        if (Global.Margem.Impressora == "mp4200th")
                        {
                            if (Global.Margem.PagParcialFiado == "sim")
                            {
                                MP2032.FormataTX("Pagamentos Parciais desta Venda : \n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoD) == false)
                                {
                                    MP2032.FormataTX(Global.Margem.PagParcialFiadoD + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                }
                                if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoCC) == false)
                                {
                                    MP2032.FormataTX(Global.Margem.PagParcialFiadoCC + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                }
                                if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoCD) == false)
                                {
                                    MP2032.FormataTX(Global.Margem.PagParcialFiadoCD + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                }
                                if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoC) == false)
                                {
                                    MP2032.FormataTX(Global.Margem.PagParcialFiadoC + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                }                          
                                
                                MP2032.FormataTX(Global.Margem.PagParcialFiadoSaldoDevedor + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX("[Operador : " + dataGridView2.Rows[0].Cells[6].Value.ToString() + "] [" + dataGridView2.Rows[0].Cells[7].Value.ToString() + "]\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                            }
                            else
                            {
                                MP2032.FormataTX("[Pagamento: " + pag + "] ", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX("[Operador : " + dataGridView2.Rows[0].Cells[6].Value.ToString() + "] [" + dataGridView2.Rows[0].Cells[7].Value.ToString() + "]\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX("\n\n\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                iRetorno = MP2032.AcionaGuilhotina(0);
                            }
                            
                        }
                        
                        
                        
                    }


                }
                if (Global.Margem.Impressora == "generic")
                {
                    ReadFile();
                    printDocument1.Print();
                }
                
                if (pag == "a prazo" || Global.Margem.PagParcialFiado == "sim")
                {
                    if (dataGridView2.Rows.Count > 0)
                    {

                        decimal soma = 0;
                        using (StreamWriter writer = new StreamWriter("Venda.txt"))
                        {
                            if (Global.Margem.Impressora == "generic")
                            {
                                writer.WriteLine("*********************************************");
                                writer.WriteLine(Global.Margem.CupomEmpresa);
                                writer.WriteLine("CNPJ-" + Global.Margem.CupomCNPJ + " | " + "IE-" + Global.Margem.CupomIE);
                                writer.WriteLine(Global.Margem.CupomTexto1);
                                writer.WriteLine(Global.Margem.CupomTexto2);
                                writer.WriteLine(DateTime.Now.ToLongDateString() + "|" + DateTime.Now.ToLongTimeString());
                                writer.WriteLine("*********************************************");
                                writer.WriteLine("---------------------------------------------");
                                writer.WriteLine("[Produto] x [Qtd] x [ValorUni] x [ValorTotal]");
                                writer.WriteLine("---------------------------------------------");
                            }
                            if (Global.Margem.Impressora == "mp4200th")
                            {
                                MP2032.FormataTX("*****************************************************************" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX(Global.Margem.CupomEmpresa + "\n", tipoLetra, italico, sublinhado, expandido, 1);
                                MP2032.FormataTX("CNPJ-" + Global.Margem.CupomCNPJ + " - " + "IE-" + Global.Margem.CupomIE + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX(Global.Margem.CupomTexto1 + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX(Global.Margem.CupomTexto2.Replace("|", "-") + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX(DateTime.Now.ToLongDateString() + " [" + DateTime.Now.ToLongTimeString() + "]\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX("*****************************************************************" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX("-----------------------------------------------------------------" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX("[Produto] x [Quantidade] x [ValorUnitário] x [ValorTotal]" + "\n", tipoLetra, italico, sublinhado, expandido, 1);
                                MP2032.FormataTX("-----------------------------------------------------------------" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                            }
                            for (int j = 0; j < dataGridView2.Rows.Count; j++)
                            {
                                string efrac = "não";
                                string prod = dataGridView2.Rows[j].Cells[0].Value.ToString();
                                string qtde = dataGridView2.Rows[j].Cells[1].Value.ToString();
                                string valorUnitario = dataGridView2.Rows[j].Cells[3].Value.ToString();
                                string valortotal = dataGridView2.Rows[j].Cells[4].Value.ToString();
                                for (int i = 0; i < valorUnitario.Length; i++)
                                {
                                    if (valorUnitario.Substring(i, 1) == "g")
                                    {
                                        efrac = "sim";
                                    }
                                }
                                if (efrac == "não")
                                {

                                    if (prod.Length > 0)
                                    {
                                        if (Global.Margem.Impressora == "generic")
                                        {
                                            if (prod.Length >= 14)
                                            {
                                                prod = prod.Substring(0, 14);
                                            }
                                            if (prod.Length < 14)
                                            {
                                                prod = prod.Substring(0, prod.Length);
                                            }
                                        }
                                        if (Global.Margem.Impressora == "mp4200th")
                                        {
                                            if (prod.Length >= 25)
                                            {
                                                prod = prod.Substring(0, 25);
                                            }
                                            if (prod.Length < 25)
                                            {
                                                prod = prod.Substring(0, prod.Length);
                                            }
                                        }

                                        prod = prod.Replace("ã", "a");
                                        prod = prod.Replace("é", "e");
                                        prod = prod.Replace("á", "a");
                                        prod = prod.Replace("è", "e");
                                        prod = prod.Replace("à", "a");
                                        prod = prod.Replace("ç", "c");
                                        prod = prod.Replace("ê", "e");
                                        prod = prod.Replace("â", "a");
                                    }
                                    if (qtde.Length > 0)
                                    {
                                        if (qtde.Length >= 4)
                                        {
                                            qtde = qtde.Substring(0, 4);
                                        }
                                        if (qtde.Length < 4)
                                        {
                                            qtde = qtde.Substring(0, qtde.Length);
                                        }
                                    }
                                    if (valorUnitario.Length > 0)
                                    {
                                        if (valorUnitario.Length >= 8)
                                        {
                                            valorUnitario = valorUnitario.Substring(0, 8);
                                        }
                                        if (valorUnitario.Length < 8)
                                        {
                                            valorUnitario = valorUnitario.Substring(0, valorUnitario.Length);
                                        }
                                    }
                                    if (valortotal.Length > 0)
                                    {
                                        if (valortotal.Length >= 10)
                                        {
                                            valortotal = valortotal.Substring(0, 10);
                                        }
                                        if (valortotal.Length < 10)
                                        {
                                            valortotal = valortotal.Substring(0, valortotal.Length);
                                        }

                                    }
                                }
                                if (efrac == "sim")
                                {
                                    if (prod.Length > 0)
                                    {
                                        if (prod.Length >= 14)
                                        {
                                            prod = prod.Substring(0, 14);
                                        }
                                        if (prod.Length < 14)
                                        {
                                            prod = prod.Substring(0, prod.Length);
                                        }
                                        prod = prod.Replace("ã", "a");
                                        prod = prod.Replace("é", "e");
                                        prod = prod.Replace("á", "a");
                                        prod = prod.Replace("è", "e");
                                        prod = prod.Replace("à", "a");
                                        prod = prod.Replace("ç", "c");
                                        prod = prod.Replace("ê", "e");
                                        prod = prod.Replace("â", "a");
                                    }

                                    if (valortotal.Length > 0)
                                    {
                                        if (valortotal.Length >= 10)
                                        {
                                            valortotal = valortotal.Substring(0, 10);
                                        }
                                        if (valortotal.Length < 10)
                                        {
                                            valortotal = valortotal.Substring(0, valortotal.Length);
                                        }

                                    }
                                }
                                soma += Convert.ToDecimal(dataGridView2.Rows[j].Cells[4].Value.ToString());
                                efrac = "não";
                                if (Global.Margem.Impressora == "generic")
                                {
                                    writer.WriteLine(prod + " | " + qtde + " | " + valorUnitario + " | " + valortotal);
                                }
                                if (Global.Margem.Impressora == "mp4200th")
                                {
                                    MP2032.FormataTX("[" + prod + "] x [" + qtde + "] x [" + valorUnitario + "] x [" + valortotal + "]\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                }

                            }
                            if (Global.Margem.Impressora == "generic")
                            {
                                writer.WriteLine("---------------------------------------------");
                                writer.WriteLine("            Valor Total da Venda => " + Convert.ToString(soma));
                                writer.WriteLine("---------------------------------------------");
                            }
                            if (Global.Margem.Impressora == "mp4200th")
                            {
                                MP2032.FormataTX("-----------------------------------------------------------------" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX("            Valor Total da Venda => " + Convert.ToString(soma) + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                MP2032.FormataTX("-----------------------------------------------------------------" + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                            }

                            pag = dataGridView2.Rows[0].Cells[5].Value.ToString();


                            pag = pag.Replace("ã", "a");
                            pag = pag.Replace("é", "e");
                            pag = pag.Replace("á", "a");
                            pag = pag.Replace("è", "e");
                            pag = pag.Replace("à", "a");
                            pag = pag.Replace("ç", "c");
                            pag = pag.Replace("ê", "e");
                            pag = pag.Replace("â", "a");
                            if (Global.Margem.Impressora == "generic")
                            {
                                if (Global.Margem.PagParcialFiado == "sim")
                                {
                                    writer.WriteLine("Pagamentos Parciais desta Venda :");
                                    if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoD) == false)
                                    {
                                        writer.WriteLine(Global.Margem.PagParcialFiadoD);
                                    }
                                    if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoCC) == false)
                                    {
                                        writer.WriteLine(Global.Margem.PagParcialFiadoCC);
                                    }
                                    if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoCD) == false)
                                    {
                                        writer.WriteLine(Global.Margem.PagParcialFiadoCD);
                                    }
                                    if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoC) == false)
                                    {
                                        writer.WriteLine(Global.Margem.PagParcialFiadoC);
                                    }
                                    writer.WriteLine(Global.Margem.PagParcialFiadoSaldoDevedor);
                                    writer.WriteLine("Operador : " + dataGridView2.Rows[0].Cells[6].Value.ToString() + ", " + dataGridView2.Rows[0].Cells[7].Value.ToString());
                                    writer.WriteLine(".                                          ");
                                    writer.WriteLine(".                                          ");
                                    writer.WriteLine("___________________________________________");
                                    writer.WriteLine("Cliente: " + dataGridView2.Rows[0].Cells[9].Value.ToString());
                                    writer.WriteLine("Ciente");
                                }
                                else
                                {
                                    writer.WriteLine("Pagamento : " + pag);
                                    writer.WriteLine("Operador : " + dataGridView2.Rows[0].Cells[6].Value.ToString() + ", " + dataGridView2.Rows[0].Cells[7].Value.ToString());
                                    writer.WriteLine(".                                          ");
                                    writer.WriteLine(".                                          ");
                                    writer.WriteLine("___________________________________________");
                                    writer.WriteLine("Cliente: " + dataGridView2.Rows[0].Cells[9].Value.ToString());
                                    writer.WriteLine("Ciente");
                                }

                            }
                            if (Global.Margem.Impressora == "mp4200th")
                            {
                                if (Global.Margem.PagParcialFiado == "sim")
                                {
                                    MP2032.FormataTX("Pagamentos Parciais desta Venda : \n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoD) == false)
                                    {
                                        MP2032.FormataTX(Global.Margem.PagParcialFiadoD + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    }
                                    if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoCC) == false)
                                    {
                                        MP2032.FormataTX(Global.Margem.PagParcialFiadoCC + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    }
                                    if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoCD) == false)
                                    {
                                        MP2032.FormataTX(Global.Margem.PagParcialFiadoCD + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    }
                                    if (String.IsNullOrEmpty(Global.Margem.PagParcialFiadoC) == false)
                                    {
                                        MP2032.FormataTX(Global.Margem.PagParcialFiadoC + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    }                          
                                    MP2032.FormataTX(Global.Margem.PagParcialFiadoSaldoDevedor + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("[Operador : " + dataGridView2.Rows[0].Cells[6].Value.ToString() + "] [" + dataGridView2.Rows[0].Cells[7].Value.ToString() + "]\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("\n\n\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("     ______________________________________________________     \n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("     Cliente: " + dataGridView2.Rows[0].Cells[9].Value.ToString() + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("     Ciente\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("\n\n\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    iRetorno = MP2032.AcionaGuilhotina(0);
                                }
                                else
                                {
                                    MP2032.FormataTX("[Pagamento: " + pag + "] ", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("[Operador : " + dataGridView2.Rows[0].Cells[6].Value.ToString() + "] [" + dataGridView2.Rows[0].Cells[7].Value.ToString() + "]", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("\n\n\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("     ______________________________________________________     \n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("     Cliente: " + dataGridView2.Rows[0].Cells[9].Value.ToString() + "\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("     Ciente\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    MP2032.FormataTX("\n\n\n", tipoLetra, italico, sublinhado, expandido, enfatizado);
                                    iRetorno = MP2032.AcionaGuilhotina(0);
                                }

                            }
                            
                        
                        }


                    }
                    if (Global.Margem.Impressora == "generic")
                    {
                        ReadFile();
                        printDocument1.Print();
                    }
                    
                }          
                
                DALCadastro.DeletaImpressao(dataGridView1.Rows[0].Cells[0].Value.ToString());
                             
                dataGridView2.DataSource = null;
                label1.Text = "Aguardando Impressão de Cupom";

                if ( Global.Margem.ImprimeFiado == "sim")
                {
                    DALCadastro.deletaVendaFiadoImpressao();
                    Global.Margem.ImprimeFiado = "";
                }
                Global.Margem.PagParcialFiado = "";
                Global.Margem.PagParcialFiadoD = "";
                Global.Margem.PagParcialFiadoCC = "";
                Global.Margem.PagParcialFiadoCD = "";
                Global.Margem.PagParcialFiadoC = "";
                Global.Margem.PagParcialFiadoSaldoDevedor = "";
                timer1.Enabled = true;   
            }
            
            
        }

        private void ServidorImpressao_Load(object sender, EventArgs e)
        {
            
            if (Global.Margem.Impressora == "generic")
            {
                printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);

                printDocument1.DefaultPageSettings.Margins.Left = 4;
                printDocument1.DefaultPageSettings.Margins.Right = 4;

                printDocument1.DefaultPageSettings.Margins.Top = 2;
            }
            if (String.IsNullOrEmpty(Global.Margem.Impressora) == true)
            {
                MessageBox.Show("Impressora não selecionada");
                Application.Exit();
                return;
            }
            if (Global.Margem.Impressora == "mp4200th")
            {
                iRetorno = 0; //Variável para retorno das chamadas para MP2032
                iRetorno = MP2032.ConfiguraModeloImpressora(7);
                iRetorno = MP2032.IniciaPorta("USB");
                iRetorno = MP2032.AjustaLarguraPapel(80);

            }
            DataTable cupom = DALCadastro.ExisteTextoCupom();
            if (cupom.Rows.Count > 0)
            {
                string emp = cupom.Rows[0]["Empresa"].ToString();
                emp = emp.Replace("ã", "a");
                emp = emp.Replace("é", "e");
                emp = emp.Replace("á", "a");
                emp = emp.Replace("è", "e");
                emp = emp.Replace("à", "a");
                emp = emp.Replace("ç", "c");
                emp = emp.Replace("ê", "e");
                emp = emp.Replace("â", "a");

                emp = emp.Replace("Ã", "A");
                emp = emp.Replace("É", "E");
                emp = emp.Replace("Á", "A");
                emp = emp.Replace("È", "E");
                emp = emp.Replace("À", "A");
                emp = emp.Replace("Ç", "C");
                emp = emp.Replace("Ê", "E");
                emp = emp.Replace("Â", "A");
                Global.Margem.CupomEmpresa = emp;

                Global.Margem.CupomCNPJ = cupom.Rows[0]["CNPJ"].ToString();
                Global.Margem.CupomIE = cupom.Rows[0]["IE"].ToString();
                string texto1 = cupom.Rows[0]["TextoAdicional1"].ToString();
                texto1 = texto1.Replace("ã", "a");
                texto1 = texto1.Replace("é", "e");
                texto1 = texto1.Replace("á", "a");
                texto1 = texto1.Replace("è", "e");
                texto1 = texto1.Replace("à", "a");
                texto1 = texto1.Replace("ç", "c");
                texto1 = texto1.Replace("ê", "e");
                texto1 = texto1.Replace("â", "a");

                texto1 = texto1.Replace("Ã", "A");
                texto1 = texto1.Replace("É", "E");
                texto1 = texto1.Replace("Á", "A");
                texto1 = texto1.Replace("È", "E");
                texto1 = texto1.Replace("À", "A");
                texto1 = texto1.Replace("Ç", "C");
                texto1 = texto1.Replace("Ê", "E");
                texto1 = texto1.Replace("Â", "A");
                if (texto1 != "vazio")
                {
                    Global.Margem.CupomTexto1 = texto1;
                }
                if (texto1 == "vazio")
                {
                    Global.Margem.CupomTexto1 = "";
                }
                string texto2 = cupom.Rows[0]["TextoAdicional2"].ToString();
                texto2 = texto2.Replace("ã", "a");
                texto2 = texto2.Replace("é", "e");
                texto2 = texto2.Replace("á", "a");
                texto2 = texto2.Replace("è", "e");
                texto2 = texto2.Replace("à", "a");
                texto2 = texto2.Replace("ç", "c");
                texto2 = texto2.Replace("ê", "e");
                texto2 = texto2.Replace("â", "a");

                texto2 = texto2.Replace("Ã", "A");
                texto2 = texto2.Replace("É", "E");
                texto2 = texto2.Replace("Á", "A");
                texto2 = texto2.Replace("È", "E");
                texto2 = texto2.Replace("À", "A");
                texto2 = texto2.Replace("Ç", "C");
                texto2 = texto2.Replace("Ê", "E");
                texto2 = texto2.Replace("Â", "A");
                if (texto2 != "vazio")
                {
                    Global.Margem.CupomTexto2 = texto2;
                }
                if (texto2 == "vazio")
                {
                    Global.Margem.CupomTexto2 = "";
                }

            }
            else
            {
                MessageBox.Show("Não foi possível localizar informações sobre cupom");
            }
            

        }
        string stringToPrint = "";
        private void ReadFile()
        {
            if (Global.Margem.CupomResumido == "sim")
            {
                stringToPrint = "";
                string docName2 = @"CupomResumido.txt";
                printDocument1.DocumentName = docName2;
                using (FileStream stream = new FileStream(docName2, FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    stringToPrint += reader.ReadToEnd();
                }
                Global.Margem.CupomResumido = "";
                return;
            }

            stringToPrint = "";           
            string docName = @"Venda.txt";
            printDocument1.DocumentName = docName;
            using (FileStream stream = new FileStream(docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                stringToPrint += reader.ReadToEnd();
            }
            
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            System.Drawing.Font pdvFont = new System.Drawing.Font("Segoe UI", 7f, FontStyle.Regular);

            e.Graphics.MeasureString(stringToPrint, pdvFont,
            e.MarginBounds.Size, StringFormat.GenericTypographic,
            out charactersOnPage, out linesPerPage);



            e.Graphics.DrawString(stringToPrint, pdvFont, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);                   
        }
       

       
    
    }
}
