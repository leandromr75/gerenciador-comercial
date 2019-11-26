using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    class EnviaSAT
    {
        public static void EnviarDadosVenda(int numerosessao,string codAtivação,string numVenda,string formasPagamentoQTDE)
        {
            //Global.SAT_Param.Forneceu_CNPJ_ou_CPF = "não"; //pode ser -> não, CNPJ, CPF

            Global.SAT_Param.VersaoDadosEntrada = "0.03";
            Global.SAT_Param.CNPJ_SoftwareHouse = "11111111111111";
            Global.SAT_Param.signAC_344 = "1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfeiuyt";
            Global.SAT_Param.numeroCaixa = "001";
            Global.SAT_Param.CNPJ_Emitente = "11111111111111";
            Global.SAT_Param.IE_Emitente = "111111111111";


            Global.SAT_Param.Informa_IM = "sim"; //sim,não (se estabelecimento não possuir não informar)
            Global.SAT_Param.IM_Emitente = "123123";

            

            Global.SAT_Param.Formas_Pagamento_Qtde = formasPagamentoQTDE; // pode ser não,sim
            
            
            
            Global.SAT_Param.vItem14741_Campo = "1.00";
            geraSAT gera = new geraSAT();
            IntPtr recebe = IntPtr.Zero;
            if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
            {
                recebe = SAT_Emulador_Funcoes.EnviarDadosVenda(numerosessao, codAtivação, gera.EnviaXML(10, "produção", numVenda));
            }
            if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
            {
                
            }
                        
            if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
            {
                string stringB = Marshal.PtrToStringAnsi(recebe);
                    using (StreamWriter writer = new StreamWriter("Cfe.txt"))
                    {
                        writer.Write(stringB.ToString());
                    }

                    string time = "";
                    string chave = "";
                    string total = "";
                    string assinatura = "";
                    string sucesso = "";
                    int barra = 0;
                    string extrato = "";
                    for (int i = 0; i < stringB.Length; i++)
                    {
                        
                        
                        if (stringB.Substring(i , 1 ) == "|")
                        {
                                barra++;
                        }
                        if (barra < 1)
                        {
                            extrato += stringB.Substring(i, 1);
                        }
                        if (barra <= 4)
                        {
                            sucesso += stringB.Substring(i, 1);
                        }
                        if (barra == 7)
                        {
                            time += stringB.Substring(i, 1);
                        }
                        if (barra == 8)
                        {
                            chave += stringB.Substring(i, 1);
                        }
                        if (barra == 9)
                        {
                            total += stringB.Substring(i , 1);
                        }
                        if (barra == 11)
                        {
                            assinatura += stringB.Substring(i, 1);
                        }
                        
                    }


                    chave = chave.Replace("|", "");
                    
                    string caminho = chave;
                    
                    
                    
                    
                    //System.Diagnostics.Process.Start("C:\\SAT\\CFes\\" + caminho + ".XML");
                    //webBrowser1.Navigate(new Uri("C:\\SAT\\CFes\\" + caminho + ".XML"));
                    string caminho2 = caminho.Replace("C","A");
                    caminho2 = caminho2.Replace("F","D");
                    caminho2 = caminho2.Replace("e","");
                    // caminho e nome atual do arquivo
                    string antigo = "C:\\SAT\\CFes\\" + caminho + ".XML";

                    string path = Directory.GetCurrentDirectory();
                    // caminho e novo nome do arquivo
                    string novo = "";
                    if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                    {
                        novo = path + "\\SAT_EMU\\copias_de_segurança\\Emitidos\\" + caminho2 + ".XML";    
                    }
                    if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                    {
                        novo = path + "\\SAT\\copias_de_segurança\\Emitidos\\" + caminho2 + ".XML";
                    }
                    if (String.IsNullOrEmpty(novo) == false)
                    {
                        File.Move(antigo, novo);
                        MessageBox.Show(sucesso + "\n" + chave + "\n\nExtrato de teste CFe -> " + extrato);
                    }
                    if (String.IsNullOrEmpty(novo) == true)
                    {
                        
                        MessageBox.Show("Erro na geração do CFe.");

                    }
                    // vamos renomear o arquivo
                    
                   //System.Diagnostics.Process.Start(novo);
                    
                    
                    
            }
            
            Global.SAT_Param.CPF_Destinatario = "";
            Global.SAT_Param.CNPJ_Destinatario = "";
            Global.SAT_Param.Nome_Destinatario = "";

            Global.SAT_Param.Formas_Pagamento_cheque = "";
            Global.SAT_Param.Formas_Pagamento_CC = "";
            Global.SAT_Param.Formas_Pagamento_CD = "";
            Global.SAT_Param.Formas_Pagamento_credito_loja = "";
            Global.SAT_Param.Formas_Pagamento_dinheiro = "";

            Global.SAT_Param.Formas_Pagamento_cheque_valor = "";
            Global.SAT_Param.Formas_Pagamento_CC_valor = "";
            Global.SAT_Param.Formas_Pagamento_CD_valor = "";
            Global.SAT_Param.Formas_Pagamento_credito_loja_valor = "";
            Global.SAT_Param.Formas_Pagamento_dinheiro_valor = "";
            //IntPtr recebe =  SAT_Emulador_Funcoes.EnviarDadosVenda(numsess, codativação, gera.EnviaXML(Convert.ToInt32(Global.Margem.IdProdSAT),"emulador",1));
           
                    
        }
        public static void EnviarDadosVendaCPF(int numerosessao, string codAtivação, string emulador_OU_produção, string numVenda, string formasPagamentoQTDE, string cpf)
        {
            Global.SAT_Param.VersaoDadosEntrada = "0.03";
            Global.SAT_Param.CNPJ_SoftwareHouse = "11111111111111";
            Global.SAT_Param.signAC_344 = "1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfeiuyt";
            Global.SAT_Param.numeroCaixa = "001";
            Global.SAT_Param.CNPJ_Emitente = "11111111111111";
            Global.SAT_Param.IE_Emitente = "111111111111";


            Global.SAT_Param.Informa_IM = "sim"; //sim,não (se estabelecimento não possuir não informar)
            Global.SAT_Param.IM_Emitente = "123123";

            Global.SAT_Param.Forneceu_CNPJ_ou_CPF = "CPF"; //pode ser -> não, CNPJ, CPF
            Global.SAT_Param.CPF_Destinatario = cpf;
            Global.SAT_Param.CNPJ_Destinatario = "";
            Global.SAT_Param.Nome_Destinatario = "";

            Global.SAT_Param.Formas_Pagamento_Qtde = formasPagamentoQTDE; // pode ser não,sim
            /*Global.SAT_Param.Formas_Pagamento_cheque = "não";
            Global.SAT_Param.Formas_Pagamento_CC = "não";
            Global.SAT_Param.Formas_Pagamento_CD = "não";
            Global.SAT_Param.Formas_Pagamento_credito_loja = "não";
            Global.SAT_Param.Formas_Pagamento_dinheiro = "não";

            Global.SAT_Param.Formas_Pagamento_cheque_valor = "";
            Global.SAT_Param.Formas_Pagamento_CC_valor = "";
            Global.SAT_Param.Formas_Pagamento_CD_valor = "";
            Global.SAT_Param.Formas_Pagamento_credito_loja_valor = "";
            Global.SAT_Param.Formas_Pagamento_dinheiro_valor = "";*/

            Global.SAT_Param.vItem14741_Campo = "1.00";


            geraSAT gera = new geraSAT();
            //IntPtr recebe =  SAT_Emulador_Funcoes.EnviarDadosVenda(numsess, codativação, gera.EnviaXML(Convert.ToInt32(Global.Margem.IdProdSAT),"emulador",1));
            IntPtr recebe = SAT_Emulador_Funcoes.EnviarDadosVenda(numerosessao, codAtivação, gera.EnviaXML(20, "produção", numVenda));

        }
        public static void EnviarDadosVendaCNPJ(int numerosessao, string codAtivação, string emulador_OU_produção, string numVenda, string formasPagamentoQTDE, string cnpj)
        {
            Global.SAT_Param.VersaoDadosEntrada = "0.03";
            Global.SAT_Param.CNPJ_SoftwareHouse = "11111111111111";
            Global.SAT_Param.signAC_344 = "1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfeiuyt";
            Global.SAT_Param.numeroCaixa = "001";
            Global.SAT_Param.CNPJ_Emitente = "11111111111111";
            Global.SAT_Param.IE_Emitente = "111111111111";


            Global.SAT_Param.Informa_IM = "sim"; //sim,não (se estabelecimento não possuir não informar)
            Global.SAT_Param.IM_Emitente = "123123";

            Global.SAT_Param.Forneceu_CNPJ_ou_CPF = "CNPJ"; //pode ser -> não, CNPJ, CPF
            Global.SAT_Param.CPF_Destinatario = "";
            Global.SAT_Param.CNPJ_Destinatario = cnpj;
            Global.SAT_Param.Nome_Destinatario = "";

            Global.SAT_Param.Formas_Pagamento_Qtde = formasPagamentoQTDE; // pode ser não,sim
            /*Global.SAT_Param.Formas_Pagamento_cheque = "não";
            Global.SAT_Param.Formas_Pagamento_CC = "não";
            Global.SAT_Param.Formas_Pagamento_CD = "não";
            Global.SAT_Param.Formas_Pagamento_credito_loja = "não";
            Global.SAT_Param.Formas_Pagamento_dinheiro = "não";

            Global.SAT_Param.Formas_Pagamento_cheque_valor = "";
            Global.SAT_Param.Formas_Pagamento_CC_valor = "";
            Global.SAT_Param.Formas_Pagamento_CD_valor = "";
            Global.SAT_Param.Formas_Pagamento_credito_loja_valor = "";
            Global.SAT_Param.Formas_Pagamento_dinheiro_valor = "";*/

            Global.SAT_Param.vItem14741_Campo = "1.00";


            geraSAT gera = new geraSAT();
            //IntPtr recebe =  SAT_Emulador_Funcoes.EnviarDadosVenda(numsess, codativação, gera.EnviaXML(Convert.ToInt32(Global.Margem.IdProdSAT),"emulador",1));
            IntPtr recebe = SAT_Emulador_Funcoes.EnviarDadosVenda(numerosessao, codAtivação, gera.EnviaXML(20, "produção", numVenda));

        }
    }
}
