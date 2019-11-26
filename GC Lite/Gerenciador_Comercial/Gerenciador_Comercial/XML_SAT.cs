using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gerenciador_Comercial
{
    class XML_SAT
    {
        //|||||||||||||||||||||||||||||||||
        //|||||CFe tag raiz do CFe|||||||||
        //|||||||||||||||||||||||||||||||||
        //infCFe ==> informações do cfe .informa campo versaoDadosEnt.
        //exemplo :<CFe><infCFe versaoDadosEnt=\"0.03\">
        private static string versaodados = "";
        public static string versaoDadosEnt
        {
            get { return versaodados; }
            set { versaodados = value; }
        }
                    
        //|||||ide|||||||
        //CNPJ  ==> CNPJ SoftwareHouse (nos testes fim a fim usar 14 digitos 0)
        private static string cnpjsoft = "";
        public static string CNPJ_SoftwareHouse
        {
            get { return cnpjsoft; }
            set { cnpjsoft = value; }
        }
        //signAC ==> assinatura aplicativo comercial, 344 caracteres (nos testes fim a fim 344 digitos 0) 
        private static string signac = "";
        public static string signAC
        {
            get { return signac; }
            set { signac = value; }
        }
        //numeroCaixa ==> 0 a 999
        private static string numcaixa = "";
        public static string numeroCaixa
        {
            get { return numcaixa; }
            set { numcaixa = value; }
        }
        //|||||||emit|||||||||
        //CNPJ - CNPJ emitente
        private static string cnpjemit = "";
        public static string CNPJ_Emitente
        {
            get { return cnpjemit; }
            set { cnpjemit = value; }
        }
        //IE - insc estad.
        private static string ie = "";
        public static string IE
        {
            get { return ie; }
            set { ie = value; }
        }
        //IM - insc. municipal Este campo deve ser informado, quando ocorrer a emissão de CF-e conjugada, com prestação 
                //de serviços sujeitos ao ISSQN e fornecimento de peças sujeitos ao ICMS.
        private static string im = "";
        public static string IM
        {
            get { return im; }
            set { im = value; }
        }
        //cRegTribISSQN - somente se enquadrar em ISSQN . 1 - Microempresa Municipal; 2 -Estimativa; 3 - Sociedade de Profissionais; 4 - Cooperativa; 5 -Microempresário Individual (MEI); 
        private static string cregtribissqn = "";
        public static string cRegTribISSQN
        {
            get { return cregtribissqn; }
            set { cregtribissqn = value; }
        }
        //indRatISSQN - N  ou S  
        private static string indratissqn = "";
        public static string indRatISSQN
        {
            get { return indratissqn; }
            set { indratissqn = value; }
        }


        //|||||||||||||||||||||||||||||||||||||
        //||||||destinatário - opcional||||||||
        //dest 
        //CNPJ - destinatário
        private static string CNPJdest = "";
        public static string CNPJ_Destinatario
        {
            get { return CNPJdest; }
            set { CNPJdest = value; }
        }
        //CPF Destinatário
        private static string CPFdest = "";
        public static string CPF_Destinatario
        {
            get { return CPFdest; }
            set { CPFdest = value; }
        }
        //||||||||destinatario - local de entrega opcional









        //|||||||||||||||||||||||||||||||||||||||
        //|||||det - detalhamento dos produtos e serviços
        //nItem - numero do item 1-500
        private static string nitem = "";
        public static string nItem
        {
            get { return nitem; }
            set { nitem = value; }
        }
        //|||||||prod
        //cProd - Código do produto ou serviço,interno do contribuinte
        private static string cprod = "";
        public static string cProd
        {
            get { return cprod; }
            set { cprod = value; }
        }
        //cEAN - Preencher com o código GTIN-8, GTIN-12,  GTIN-13  ou  GTIN-14(antigos  códigos  EAN,  UPC  e DUN-14),  não  informar  o 
                //conteúdo da TAG em caso de o produto não possuir este código.
        private static string cean = "";
        public static string cEAN
        {
            get { return cean; }
            set { cean = value; }
        }
        //xProd - descr~ição do produto ou serviço
        private static string xprod = "";
        public static string xProd
        {
            get { return xprod; }
            set { xprod = value; }
        }
        //NCM - Código NCM com 8 dígitos ou 2 dígitos (gênero). Em caso de srviço informar codigo 99.
        private static string ncm = "";
        public static string NCM
        {
            get { return ncm; }
            set { ncm = value; }
        }
        //CFOP
        private static string cfop = "";
        public static string CFOP
        {
            get { return cfop; }
            set { cfop = value; }
        }
        //uCom - unidade comercial
        private static string ucom = "";
        public static string uCom
        {
            get { return ucom; }
            set { ucom = value; }
        }
        //qCom - quantidade comercial
        private static string qcom = "";
        public static string qCom
        {
            get { return qcom; }
            set { qcom = value; }
        }
        //vUnCom - informar com 2 casas decimais, exceto combustiveis (3 casas)
        private static string vuncom = "";
        public static string vUnCom
        {
            get { return vuncom; }
            set { vuncom = value; }
        }
        //indRegra - A (arredondamento) ou T (truncamento)
        private static string indregra = "";
        public static string indRegra
        {
            get { return indregra; }
            set { indregra = value; }
        }
        //vDesc - valor desconto (2 casas decimais) , informar somente se houver desconto
        private static string vdesc = "";
        public static string vDesc
        {
            get { return vdesc; }
            set { vdesc = value; }
        }
        //vOutro - opcional - outras despesas acessorias para este item
        private static string voutro = "";
        public static string vOutro
        {
            get { return voutro; }
            set { voutro = value; }
        }


        //Obsfisco    ***********implementar








        //||||||||||||||||||||||||||||||||||||||||||||||
        //|||||||imposto||||||||||||||||||||||||||||||||
        //||||||||||||||||||||||||||||||||||||||||||||||
        //vItem12741 - Valor aproximado dos tributos do produto ou serviço, declarado pelo emitente, conforme Lei 12741/2012.
                   //Valor deve ser maior ou igual a zero.Campo de preenchimento: - opcional, caso o contribuinte opte por informar o valor em 
                   //painel afixado no estabelecimento, conforme artigo 2º, §2º da referida lei. - obrigatório, caso o contribuinte
                   //não opte por informar o valor em painel afixado no estabelecimento, conforme artigo 2º, §2º da referida lei.
        private static string vitem12741 = "";
        public static string vItem12741
        {
            get { return vitem12741; }
            set { vitem12741 = value; }
        }
        
        
        
        
        
        
        //|||||||||||||||||||||||||||||||||||||||||||||||
        //||||||||||||ICMS|||||||||||||||||||||||||||||||
        //|||||||||||||||||||||||||||||||||||||||||||||||
        //Informar apenas um dos grupos N02, N03, N04, N05 com base no conteúdo informado na TAG Tributação do ICMS.
        
        
        //*********************************************************************************************************
        //ICMS00 - Tributação do ICMS: 00 – Tributada integralmente 20 - Com redução de base de cálculo 90 - Outros
        //*********************************************************************************************************
        //Orig - Origem da mercadoria: 0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;
                //1 - Estrangeira - Importação direta, exceto a indicada no código 6;
                //2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;
                //3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% (quarenta por cento) e inferior ou igual a 70% (setenta por cento);
                //4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as le gislações citadas nos Ajustes;
                //5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;
                //6 - Estrangeira - Importação direta, sem similar nacional,constante em lista da CAMEX;
                //7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante em lista da CAMEX;
                //8 – Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70% (setenta por cento).
        private static string origicms00 = "";
        public static string Orig_ICMS00
        {
            get { return origicms00; }
            set { origicms00 = value; }
        }
        //CST - Tributação do ICMS: 00 – Tributada integralmente 20 - Com redução de base de cálculo 90 - Outros
        private static string csticms00 = "";
        public static string CST_ICMS00
        {
            get { return csticms00; }
            set { csticms00 = value; }
        }
        //pICMS 
        private static string picms00 = "";
        public static string pICMS00
        {
            get { return picms00; }
            set { picms00 = value; }
        }

        
        //*********************************************************************************************************
        //ICMS40 - Tributação do ICMS: 00 – Tributada integralmente 20 - Com redução de base de cálculo 90 - Outros
        //*********************************************************************************************************
        //Redação atual, efeitos até 31.12.15.Tributação do ICMS – 40 - Isenta 41 - Não tributada 50 - Suspensão
            //60 - ICMS cobrado anteriormente por substituição tributária 
        //Nova redação, efeitos a partir de 01.01.16. Tributação do ICMS – 40 - Isenta 41 - Não tributada 
            //60 - ICMS cobrado anteriormente por substituição tributária
        
        
        //Orig - Origem da mercadoria: 0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;
            //1 - Estrangeira - Importação direta, exceto a indicada no código 6; 2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;
            //3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% (quarenta por cento) e inferior ou igual a 70% (setenta por cento);
            //4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as legislações citadas nos Ajustes;
            //5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;
            //6 - Estrangeira - Importação direta, sem similar nacional,constante em lista da CAMEX;
            //7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante em lista da CAMEX;
            //8 – Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70% (setenta por cento).
        private static string origicms40 = "";
        public static string Orig_ICMS40
        {
            get { return origicms40; }
            set { origicms40 = value; }
        }
        //CST - 
                //Redação atual, efeitos até 31.12.15. Tributação do ICMS – 40 - Isenta 41 - Não tributada 50 - 
                        //Suspensão 60 - ICMS cobrado anteriormente por substituição tributária 
                //Nova redação, efeitos a partir de 01.01.16. Tributação do ICMS – 40 - Isenta 41 - Não tributada 
                        //60 - ICMS cobrado anteriormente por substituição tributária
        private static string csticms40 = "";
        public static string CST_ICMS40
        {
            get { return csticms40; }
            set { csticms40 = value; }
        }
        //******************************************************************
        //Observação: Não informar o campo pICMS dentro deste grupo.(ICMS40)
        //******************************************************************


        //*********************************************************************************************************
        //ICMSSN102 
        //*********************************************************************************************************
            //Redação atual,efeitos até 31.12.15.Grupo cRegTrib=1 – Simples Nacional e CSOSN=102, 300, 500
            //Nova redação,efeitos a partir de 01.01.16.Grupo cRegTrib=1 – Simples Nacional e CSOSN=102, 300,400, 500

        //Orig - Origem da mercadoria: 0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;
                //1 - Estrangeira - Importação direta, exceto a indicada no código 6;
                //2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;
                //3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% (quarenta por cento) e inferior ou igual a 70% (setenta por cento);
                //4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as legislações citadas nos Ajustes;
                //5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;
                //6 - Estrangeira - Importação direta, sem similar nacional,constante em lista da CAMEX;
                //7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante em lista da CAMEX;
                //8 – Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70% (setenta por cento).
        private static string origicmssn102 = "";
        public static string Orig_ICMSSN102
        {
            get { return origicmssn102; }
            set { origicmssn102 = value; }
        }
        //CSOSN - Código de Situação da Operação – Simples Nacional.
                //Redação atual, efeitos até 31.12.15. -   102- Tributada pelo Simples Nacional sem permissão de crédito. 
                        //300 – Imune 500 – ICMS cobrado anteriormente por substituição tributária (substituído) ou por antecipação
                //Nova redação, efeitos a partir de 01.01.16. - 102- Tributada pelo Simples Nacional sem permissão de crédito. 
                        //300 – Imune 400 – Não tributada 500 – ICMS cobrado anteriormente por substituição tributária (substituído) ou por substituição.
        private static string csosnicmssn102 = "";
        public static string CSOSN_ICMSSN102
        {
            get { return csosnicmssn102; }
            set { csosnicmssn102 = value; }
        }

        //*********************************************************************
        //Observação: Não informar o campo pICMS dentro deste grupo.(ICMSSN102)
        //*********************************************************************



        //*********************************************************************************************************
        //ICMSSN900 - TAG de Grupo cRegTrib=1 – Simples Nacional e CSOSN=900
        //*********************************************************************************************************
        //Orig - Origem da mercadoria: 0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;
                //1 - Estrangeira - Importação direta, exceto a indicada no código 6;
                //2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;
                //3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% (quarenta por cento) e inferior ou igual a 70% (setenta por cento);
                //4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as legislações citadas nos Ajustes;
                //5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%; 
                //6 - Estrangeira - Importação direta, sem similar nacional,constante em lista da CAMEX;
                //7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante em lista da CAMEX;
                //8 – Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70% (setenta por cento).
        private static string origicmssn900 = "";
        public static string Orig_ICMSSN900
        {
            get { return origicmssn900; }
            set { origicmssn900 = value; }
        }
        //CSOSN - Código de Situação da Operação – Simples Nacional.Tributação pelo ICMS - 900 - Outros
        private static string csosnicmssn900 = "";
        public static string CSOSN_ICMSSN900
        {
            get { return csosnicmssn900; }
            set { csosnicmssn900 = value; }
        }
        //pICMS - alíquota efetiva
        private static string pICMSicmssn900 = "";
        public static string pICMS_ICMSSN900
        {
            get { return pICMSicmssn900; }
            set { pICMSicmssn900 = value; }
        }

        //*********************************************
        //|||||||||PIS|||||||||||||||||||||||||||||||||
        //*********************************************
        //Informar apenas um dos grupos PISAliq,PISQtde ,PISNT ,PISSN  ou  PISOutr ==> com base valor atribuído ao campo Q07 – CST do PIS .ex: <PIS><...><CST>
        //PISAliq ==> CST = 01, 02 e 05
        //CST - 01 – Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo));
                //02 - Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada));
                //05 - Operação Tributável por Substituição Tributária;
        private static string cstPIS_PISAliq = "";
        public static string CST_PIS_PISAliq
        {
            get { return cstPIS_PISAliq; }
            set { cstPIS_PISAliq = value; }
        }
        //vBC ==>valor da base de cálculo do PIS
        private static string vbcPIS_PISAliq = "";
        public static string vBC_PIS_PISAliq
        {
            get { return vbcPIS_PISAliq; }
            set { vbcPIS_PISAliq = value; }
        }
        //pPIS ==> alíquota do PIS (em porcentual)  Ex.  Se  a  alíquota  for  0,65% informar 0,0065
        private static string ppisPIS_PISAliq = "";
        public static string pPIS_PIS_PISAliq
        {
            get { return ppisPIS_PISAliq; }
            set { ppisPIS_PISAliq = value; }
        }
        //PISQtde ==> CST = 03
        //CST ==> 03 - Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto);
        private static string cstPIS_PISQtde = "";
        public static string CST_PIS_PISQtde
        {
            get { return cstPIS_PISQtde; }
            set { cstPIS_PISQtde = value; }
        }
        //QBCProd ==> quantidade vendida
        private static string qbcprodPIS_PISQtde = "";
        public static string QBCProd_PIS_PISQtde
        {
            get { return qbcprodPIS_PISQtde; }
            set { qbcprodPIS_PISQtde = value; }
        }
        //vAliqProd ==> alíquota do PIS (em R$)
        private static string valiqprodPIS_PISQtde = "";
        public static string vAliqProd_PIS_PISQtde
        {
            get { return valiqprodPIS_PISQtde; }
            set { valiqprodPIS_PISQtde = value; }
        }
        
        //PISNT ==> grupo PIS não tributável ==> CST = 04, 06, 07, 08 ou 09 
        //CST ==> 04 - Operação Tributável (tributação monofásica (alíquota zero)); 06 - Operação Tributável (alíquota zero);
                //07 - Operação Isenta da Contribuição; 08 - Operação Sem Incidência da Contribuição; 09 - Operação com Suspensão da Contribuição;
        private static string cstPIS_PISNT = "";
        public static string CST_PIS_PISNT
        {
            get { return cstPIS_PISNT; }
            set { cstPIS_PISNT = value; }
        }
        
        //PISSN ==> grupo PIS Simples Nacional ==> CST = 49 
        //CST ==> 49 - Outras Operações de saída;  
        private static string cstPIS_PISSN = "";
        public static string CST_PIS_PISSN
        {
            get { return cstPIS_PISSN; }
            set { cstPIS_PISSN = value; }
        }

        //PISOutr ==> grupo PIS outras operações ==> CST = 99
                                 //******************************************************************************
                                //Informar campos para cálculo do PIS com aliquota em percentual (vBC e vPIS) ou 
                                //campos para PIS com aliquota em valor (QBCProd e vAliqProd). 
                                 //******************************************************************************
        //CST ==> 99 - Outras Operações
        private static string cstPIS_PISOutr = "";
        public static string CST_PIS_PISOutr
        {
            get { return cstPIS_PISOutr; }
            set { cstPIS_PISOutr = value; }
        }
        //vBC - em porcentual
        private static string vbcPIS_PISOutr = "";
        public static string vBC_PIS_PISOutr
        {
            get { return vbcPIS_PISOutr; }
            set { vbcPIS_PISOutr = value; }
        }
        //pPIS - em porcentual
        private static string ppisPIS_PISOutr = "";
        public static string pPIS_PIS_PISOutr
        {
            get { return ppisPIS_PISOutr; }
            set { ppisPIS_PISOutr = value; }
        }
        //QBCProd - aliquota em valor
        private static string qbcprodPIS_PISOutr = "";
        public static string QBCProd_PIS_PISOutr
        {
            get { return qbcprodPIS_PISOutr; }
            set { qbcprodPIS_PISOutr = value; }
        }
        //vAliqProd ==> alíquota do PIS (em R$)
        private static string valiqprodPIS_PISOutr = "";
        public static string vAliqProd_PIS_PISOutr
        {
            get { return valiqprodPIS_PISOutr; }
            set { valiqprodPIS_PISOutr = value; }
        }

        //PISST ==> grupo PIS substituição tributária 
        //******************************************************************************
        //Informar campos para cálculo do PISST com aliquota em percentual (vBC e vPIS) ou 
        //campos para PIS com aliquota em valor (QBCProd e vAliqProd). 
        //******************************************************************************
        //vBC - em porcentual
        private static string vbc_PISST = "";
        public static string vBC_PISST
        {
            get { return vbc_PISST; }
            set { vbc_PISST = value; }
        }
        //pPIS - em porcentual
        private static string ppis_PISST = "";
        public static string pPIS_PISST
        {
            get { return ppis_PISST; }
            set { ppis_PISST = value; }
        }
        //QBCProd - aliquota em valor
        private static string qbcprod_PISST = "";
        public static string QBCProd_PISST
        {
            get { return qbcprod_PISST; }
            set { qbcprod_PISST = value; }
        }
        //vAliqProd ==> alíquota do PIS (em R$)
        private static string valiqprod_PISST = "";
        public static string vAliqProd_PISST
        {
            get { return valiqprod_PISST; }
            set { valiqprod_PISST = value; }
        }


        //*********************************************
        //|||||||||COFINS|||||||||||||||||||||||||||||||||
        //*********************************************
        //Informar apenas um dos grupos COFINSAliq,COFINSQtde ,COFINSNT ,COFINSSN  ou  COFINSOutr ==> com base valor atribuído ao campo CST
        //COFINSAliq ==> CST = 01, 02 e 05 
        //CST - 01 – Operação Tributável (base de cálculo = valor da operação alíquota normal (cumulativo/não cumulativo));
                //02 - Operação Tributável (base de cálculo = valor da operação (alíquota diferenciada));05 - Operação Tributável por Substituição Tributária;
        private static string cstcofinsAliq = "";
        public static string CST_COFINSAliq
        {
            get { return cstcofinsAliq; }
            set { cstcofinsAliq = value; }
        }
        //vBC ==>valor da base de cálculo do cofins
        private static string vbccofinsAliq = "";
        public static string vBC_COFINSAliq
        {
            get { return vbccofinsAliq; }
            set { vbccofinsAliq = value; }
        }
        //pCOFINS ==> alíquota do cofins (em porcentual)  Ex.  Se  a  alíquota  for  0,65% informar 0,0065
        private static string pCofinsCOFINSAliq = "";
        public static string pCOFINS_COFINSAliq
        {
            get { return pCofinsCOFINSAliq; }
            set { pCofinsCOFINSAliq = value; }
        }
        //COFINSQtde ==> CST = 03
        //CST ==> 03 - Operação Tributável (base de cálculo = quantidade vendida x alíquota por unidade de produto);
        private static string cstcofins_COFINSQtde = "";
        public static string CST_COFINSQtde
        {
            get { return cstcofins_COFINSQtde; }
            set { cstcofins_COFINSQtde = value; }
        }
        //QBCProd ==> quantidade vendida
        private static string qbcprod_COFINSQtde = "";
        public static string QBCProd_COFINSQtde
        {
            get { return qbcprod_COFINSQtde; }
            set { qbcprod_COFINSQtde = value; }
        }
        //vAliqProd ==> alíquota do COFINS (em R$)
        private static string valiqprod_cofinsQtde = "";
        public static string vAliqProd_COFINSQtde
        {
            get { return valiqprod_cofinsQtde; }
            set { valiqprod_cofinsQtde = value; }
        }

        //COFINSNT ==> grupo COFINS não tributável ==> CST = 04, 06, 07, 08 ou 09 
        //CST ==> 04 - Operação Tributável (tributação monofásica (alíquota zero)); 06 - Operação Tributável (alíquota zero);
            //07 - Operação Isenta da Contribuição; 08 - Operação Sem Incidência da Contribuição; 09 - Operação com Suspensão da Contribuição;
        private static string cst_cofinsNT = "";
        public static string CST_COFINSNT
        {
            get { return cst_cofinsNT; }
            set { cst_cofinsNT = value; }
        }

        //COFINSSN ==> grupo COFINS Simples Nacional ==> CST = 49 
        //CST ==> 49 - Outras Operações de saída;  
        private static string cst_cofinsSN = "";
        public static string CST_COFINSSN
        {
            get { return cst_cofinsSN; }
            set { cst_cofinsSN = value; }
        }

        //COFINSOutr ==> grupo COFINS outras operações ==> CST = 99
        //******************************************************************************
        //Informar campos para cálculo do PIS com aliquota em percentual (vBC e vPIS) ou 
        //campos para PIS com aliquota em valor (QBCProd e vAliqProd). 
        //******************************************************************************
        //CST ==> 99 - Outras Operações
        private static string cst_cofinsOutr = "";
        public static string CST_COFINSOutr
        {
            get { return cst_cofinsOutr; }
            set { cst_cofinsOutr = value; }
        }
        //vBC - em porcentual
        private static string vbc_cofinsOutr = "";
        public static string vBC_COFINSOutr
        {
            get { return vbc_cofinsOutr; }
            set { vbc_cofinsOutr = value; }
        }
        //pCOFINS - em porcentual
        private static string pcofins_cofinsOutr = "";
        public static string pCOFINS_COFINSOutr
        {
            get { return pcofins_cofinsOutr; }
            set { pcofins_cofinsOutr = value; }
        }
        //QBCProd - aliquota em valor
        private static string qbcprod_COFINSOutr = "";
        public static string QBCProd_COFINSOutr
        {
            get { return qbcprod_COFINSOutr; }
            set { qbcprod_COFINSOutr = value; }
        }
        //vAliqProd ==> alíquota do PIS (em R$)
        private static string valiqprod_cofinsOutr = "";
        public static string vAliqProd_COFINSOutr
        {
            get { return valiqprod_cofinsOutr; }
            set { valiqprod_cofinsOutr = value; }
        }


        //COFINSST ==> grupo COFINS substituição tributária 
        //******************************************************************************
        //Informar campos para cálculo do COFINSST com aliquota em percentual (vBC e vPIS) ou 
        //campos para COFINS com aliquota em valor (QBCProd e vAliqProd). 
        //******************************************************************************
        //vBC - em porcentual
        private static string vbc_COFINSST = "";
        public static string vBC_COFINSST
        {
            get { return vbc_COFINSST; }
            set { vbc_COFINSST = value; }
        }
        //pCOFINS - em porcentual
        private static string pcofins_COFINSST = "";
        public static string pCOFINS_COFINSST
        {
            get { return pcofins_COFINSST; }
            set { pcofins_COFINSST = value; }
        }
        //QBCProd - aliquota em valor
        private static string qbcprod_COFINSST = "";
        public static string QBCProd_COFINSST
        {
            get { return qbcprod_COFINSST; }
            set { qbcprod_COFINSST = value; }
        }
        //vAliqProd ==> alíquota do COFINS (em R$)
        private static string valiqprod_COFINSST = "";
        public static string vAliqProd_COFINSST
        {
            get { return valiqprod_COFINSST; }
            set { valiqprod_COFINSST = value; }
        }



        //||||||||||||||||||||||||||||||||||||||||
        //||||||||||||||||||ISSQN|||||||||||||||||
        //||||||||||||||||||||||||||||||||||||||||
        //||||||||||||||||||||||||||||||||||||||||

        //inserir código para ISSQN



        //****************************************
        //****************************************
        //****************************************
        //****************************************






        //total   ==> <total />

        //entrar com código para desconto 





        //*****************************************
        //#########################################
        //pgto ==> Grupo de infoemações sobre pagamento da cfe
        //####################################################
        //MP
        //cMP  ==> Código do Meio de Pagamento empregado para quitação do CFe 01 - Dinheiro  02 - Cheque 03 - Cartão de Crédito 04 - Cartão de Débito
                //05 - Crédito Loja 10 - Vale Alimentação 11 - Vale Refeição  12 - Vale Presente 13 - Vale Combustível 99 - Outros
        private static string cmp = "";
        public static string cMP_pgto
        {
            get { return cmp; }
            set { cmp = value; }
        }
        //vMP ==> valor do meio de pagamento
        private static string vmp = "";
        public static string vMP_pgto
        {
            get { return vmp; }
            set { vmp = value; }
        }
        //cAdmC ==> Credenciadora de cartão de débito ou crédito
                //Código da Credenciadora de cartão de débito ou crédito conforme tabela disponível no Anexo 3 - Tabela de credenciadoras de cartão de 
                //débito ou crédito  Exemplos: 001, 002, 003. .
        private static string cadmc = "";
        public static string cAdmC_pgto
        {
            get { return cadmc; }
            set { cadmc = value; }
        }


        //**********escrever informações adicionais


        //fim nfe
    }


    //Globais de controle teste com emulador
    class GlobalSAT
    {
        private static string mostra = "";
        public static string ImpostoOK
        {
            get { return mostra; }
            set { mostra = value; }
        }
        //tributação ICMS Selecionada
        private static string icmstrib = "";
        public static string TributaçãoICMS
        {
            get { return icmstrib; }
            set { icmstrib = value; }
        }
       
        private static string pis = "";
        public static string PIS
        {
            get { return pis; }
            set { pis = value; }
        }
        private static string pisst = "";
        public static string PISST
        {
            get { return pisst; }
            set { pisst = value; }
        }
        private static string confins = ""; 
        public static string COFINS
        {
            get { return confins; }
            set { confins = value; }
        }
        private static string confinsst = "";
        public static string COFINSST
        {
            get { return confinsst; }
            set { confinsst = value; }
        }
        
    }
    class carregaSATCadastro
    {
        private static string pis = "";
        public static string PIS
        {
            get { return pis; }
            set { pis = value; }
        }
    }
}
