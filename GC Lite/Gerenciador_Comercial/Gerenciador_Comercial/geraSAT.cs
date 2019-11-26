using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Gerenciador_Comercial
{
    class geraSAT
    {
        public String EnviaXML(int idSAT,string emulador_ou_SAT,string venda)
        {
            String retorno = "";           
            //***************************************************
            //Envia XML para Emulador
            //***************************************************
            
           //*********************************||||||||||||||||||||***********************************************
            if (emulador_ou_SAT == "emulador" || emulador_ou_SAT == "produção")
            {
                int numeroItemsVenda = 0;
                int id = 0;
                if (emulador_ou_SAT == "emulador")
                {
                    id = idSAT;
                    numeroItemsVenda = Convert.ToInt32("1");
                }
                DataTable vendaNum = DALCadastro.PegaIdVendaSAT(venda);

                if (emulador_ou_SAT == "produção")
                {
                    Global.SAT_Param.Numero_Items = Convert.ToString(vendaNum.Rows.Count);
                    id = Convert.ToInt32( vendaNum.Rows[0]["IdProduto"].ToString());
                    numeroItemsVenda = Convert.ToInt32(Global.SAT_Param.Numero_Items);
                }
                string valorEmu = "";

                DataTable sat = DALCadastro.CarregaSAT(id);
                if (sat.Rows.Count > 0)
                {
                        if (emulador_ou_SAT == "emulador")
                        {
                            retorno += "<CFe><infCFe versaoDadosEnt=\"0.03\"><ide><CNPJ>11111111111111</CNPJ><signAC>1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfeiuyt</signAC>" +
                            "<numeroCaixa>001</numeroCaixa></ide><emit><CNPJ>11111111111111</CNPJ><IE>111111111111</IE><IM>123123</IM><indRatISSQN>N</indRatISSQN></emit><dest />";
                        }
                        if (emulador_ou_SAT == "produção")
                        {
                            if (Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "não")
                            {
                                retorno += "<CFe><infCFe versaoDadosEnt=\"" + Global.SAT_Param.VersaoDadosEntrada + "\"><ide><CNPJ>" + Global.SAT_Param.CNPJ_SoftwareHouse +
                                "</CNPJ><signAC>" + Global.SAT_Param.signAC_344 + "</signAC><numeroCaixa>" + Global.SAT_Param.numeroCaixa +
                                "</numeroCaixa></ide><emit><CNPJ>" + Global.SAT_Param.CNPJ_Emitente + "</CNPJ><IE>" + Global.SAT_Param.IE_Emitente + "</IE>";
                                if (Global.SAT_Param.Informa_IM == "sim")
                                {
                                    retorno += "<IM>" + Global.SAT_Param.IM_Emitente + "</IM><indRatISSQN>N</indRatISSQN></emit><dest />";
                                }
                                if (Global.SAT_Param.Informa_IM == "não")
                                {
                                    retorno += "<indRatISSQN>N</indRatISSQN></emit><dest />";
                                }
                                
                            }
                            if (Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CPF")
                            {
                                retorno += "<CFe><infCFe versaoDadosEnt=\"" + Global.SAT_Param.VersaoDadosEntrada + "\"><ide><CNPJ>" + Global.SAT_Param.CNPJ_SoftwareHouse +
                                "</CNPJ><signAC>" + Global.SAT_Param.signAC_344 + "</signAC><numeroCaixa>" + Global.SAT_Param.numeroCaixa +
                                "</numeroCaixa></ide><emit><CNPJ>" + Global.SAT_Param.CNPJ_Emitente + "</CNPJ><IE>" + Global.SAT_Param.IE_Emitente + "</IE>";
                                if (String.IsNullOrEmpty(Global.SAT_Param.Nome_Destinatario) == false)
                                {
                                    if (Global.SAT_Param.Informa_IM == "sim" && Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CPF")
                                    {
                                        retorno += "<IM>" + Global.SAT_Param.IM_Emitente + "</IM><indRatISSQN>N</indRatISSQN></emit><dest><CPF>" + Global.SAT_Param.CPF_Destinatario + "</CPF><xNome>" + Global.SAT_Param.Nome_Destinatario + "</xNome></dest>";
                                    }
                                    if (Global.SAT_Param.Informa_IM == "não" && Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CPF")
                                    {
                                        retorno += "<indRatISSQN>N</indRatISSQN></emit><dest><CPF>" + Global.SAT_Param.CPF_Destinatario + "</CPF><xNome>" + Global.SAT_Param.Nome_Destinatario + "</xNome></dest>";
                                    }
                                }
                                if (String.IsNullOrEmpty(Global.SAT_Param.Nome_Destinatario) == true)
                                {
                                    if (Global.SAT_Param.Informa_IM == "sim" && Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CPF")
                                    {
                                        retorno += "<IM>" + Global.SAT_Param.IM_Emitente + "</IM><indRatISSQN>N</indRatISSQN></emit><dest><CPF>" + Global.SAT_Param.CPF_Destinatario + "</CPF></dest>";
                                    }
                                    if (Global.SAT_Param.Informa_IM == "não" && Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CPF")
                                    {
                                        retorno += "<indRatISSQN>N</indRatISSQN></emit><dest><CPF>" + Global.SAT_Param.CPF_Destinatario + "</CPF></dest>";
                                    }
                                }
                            }
                            if (Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CNPJ")
                            {
                                retorno += "<CFe><infCFe versaoDadosEnt=\"" + Global.SAT_Param.VersaoDadosEntrada + "\"><ide><CNPJ>" + Global.SAT_Param.CNPJ_SoftwareHouse +
                                "</CNPJ><signAC>" + Global.SAT_Param.signAC_344 + "</signAC><numeroCaixa>" + Global.SAT_Param.numeroCaixa +
                                "</numeroCaixa></ide><emit><CNPJ>" + Global.SAT_Param.CNPJ_Emitente + "</CNPJ><IE>" + Global.SAT_Param.IE_Emitente + "</IE>";
                                if (String.IsNullOrEmpty(Global.SAT_Param.Nome_Destinatario) == false)
                                {
                                    if (Global.SAT_Param.Informa_IM == "sim" && Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CNPJ")
                                    {
                                        retorno += "<IM>" + Global.SAT_Param.IM_Emitente + "</IM><indRatISSQN>N</indRatISSQN></emit><dest><CNPJ>" + Global.SAT_Param.CNPJ_Destinatario + "</CNPJ><xNome>" + Global.SAT_Param.Nome_Destinatario + "</xNome></dest>";
                                    }
                                    if (Global.SAT_Param.Informa_IM == "não" && Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CNPJ")
                                    {
                                        retorno += "<indRatISSQN>N</indRatISSQN></emit><dest><CNPJ>" + Global.SAT_Param.CNPJ_Destinatario + "</CNPJ><xNome>" + Global.SAT_Param.Nome_Destinatario + "</xNome></dest>";
                                    }
                                }

                                if (String.IsNullOrEmpty(Global.SAT_Param.Nome_Destinatario) == true)
                                {
                                    if (Global.SAT_Param.Informa_IM == "sim" && Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CNPJ")
                                    {
                                        retorno += "<IM>" + Global.SAT_Param.IM_Emitente + "</IM><indRatISSQN>N</indRatISSQN></emit><dest><CNPJ>" + Global.SAT_Param.CNPJ_Destinatario + "</CNPJ></dest>";
                                    }
                                    if (Global.SAT_Param.Informa_IM == "não" && Global.SAT_Param.Forneceu_CNPJ_ou_CPF == "CNPJ")
                                    {
                                        retorno += "<indRatISSQN>N</indRatISSQN></emit><dest><CNPJ>" + Global.SAT_Param.CNPJ_Destinatario + "</CNPJ></dest>";
                                    }
                                }
                                
                            }
                        }
                        
                        if (numeroItemsVenda > 0 )
                        {
                            for (int i = 0; i < numeroItemsVenda; i++)
                            {
                                string icms = "";
                                //<det nItem=\"1\">";
                                
                                
                                string procura = "";
                                if (emulador_ou_SAT == "emulador")
                                {
                                    procura = Convert.ToString( idSAT );
                                    //valorEmu = prod.Rows[0]["ValorVenda"].ToString();
                                }
                                if (emulador_ou_SAT == "produção")
                                {
                                    procura = vendaNum.Rows[i]["IdProduto"].ToString();
                                }
                                sat = null;
                                sat = DALCadastro.CarregaSAT(Convert.ToInt32( procura));
                                DataTable prod = DALCadastro.listaProdutos(Convert.ToInt32(procura));
                                valorEmu = prod.Rows[0]["ValorVenda"].ToString();

                                //******************
                                
                                
                                //retirar gr da quantidade ppor peso - qtde comercial
                                //vitem 741


                                //*****************
                                if (prod.Rows.Count > 0)
                                {
                                    string qtde = "";
                                    if (prod.Rows[0]["VenderPro"].ToString() == "não")
                                    {
                                        qtde = vendaNum.Rows[i]["Quantidade"].ToString() + ".0000";
                                    }
                                    if (prod.Rows[0]["VenderPro"].ToString() == "Preço" || prod.Rows[0]["VenderPro"].ToString() == "Peso")
                                    {
                                        string temp = vendaNum.Rows[i]["Quantidade"].ToString();

                                        temp = temp.Replace(" gr","");
                                        
                                        if (temp.Length == 4)
                                        {
                                            temp = temp.Substring(0, 1) + "." + temp.Substring(1, temp.Length - 1) + "0";
                                        }
                                        if (temp.Length == 3)
                                        {
                                            temp = "0" + "." + temp.Substring(0, temp.Length) + "0";
                                        }
                                        if (temp.Length == 5)
                                        {
                                            temp = temp.Substring(0, 2) + "." + temp.Substring(2, temp.Length - 2) + "0";
                                        }
                                        qtde = temp;
                                        
                                        
                                    }
                                    //string grana = prod.Rows[0]["ValorVenda"].ToString();
                                    string grana = vendaNum.Rows[i]["Valor_Total"].ToString();
                                    grana = grana.Replace(",", ".");
                                    if (emulador_ou_SAT == "emulador")
                                    {
                                        retorno += "<det nItem=\"1\"><prod><cProd>" + Convert.ToString(id) + "</cProd><cEAN>" + prod.Rows[0]["CodEAN"].ToString() +
                                        "</cEAN><xProd>" + prod.Rows[0]["DescInterna"].ToString() + "</xProd><NCM>" + prod.Rows[0]["CF_NCM"].ToString() +
                                        "</NCM><CFOP>" + sat.Rows[0]["CFOP"].ToString() + "</CFOP><uCom>" + prod.Rows[0]["Unidade"].ToString() +
                                        "</uCom><qCom>1.0000" + "</qCom><vUnCom>" + grana + "</vUnCom><indRegra>" + sat.Rows[0]["RegraCalculo"].ToString() +
                                        "</indRegra></prod><imposto><vItem12741>1.00</vItem12741>";        
                                    }
                                    

                                    if (emulador_ou_SAT == "produção")
                                    {


                                        retorno += "<det nItem=\"" + Convert.ToString(i + 1) + "\"><prod><cProd>" + prod.Rows[0]["IdProd"].ToString() + "</cProd>";
                                        if (String.IsNullOrEmpty(prod.Rows[0]["CodEAN"].ToString()) == false && prod.Rows[0]["VenderPro"].ToString() == "não")
                                        {
                                            retorno += "<cEAN>" + prod.Rows[0]["CodEAN"].ToString() +
                                            "</cEAN><xProd>" + prod.Rows[0]["DescInterna"].ToString() +
                                            "</xProd><NCM>" + prod.Rows[0]["CF_NCM"].ToString() +
                                            "</NCM><CFOP>" + sat.Rows[0]["CFOP"].ToString() +
                                            "</CFOP><uCom>" + prod.Rows[0]["Unidade"].ToString() +
                                            "</uCom><qCom>" + qtde +
                                            "</qCom><vUnCom>" + grana + "</vUnCom><indRegra>" + sat.Rows[0]["RegraCalculo"].ToString() +
                                            "</indRegra></prod><imposto><vItem12741>" + Global.SAT_Param.vItem14741_Campo + "</vItem12741>";
                                        }
                                        if (String.IsNullOrEmpty(prod.Rows[0]["CodEAN"].ToString()) == true && prod.Rows[0]["VenderPro"].ToString() == "não")
                                        {
                                            retorno += "<cEAN></cEAN><xProd>" + prod.Rows[0]["DescInterna"].ToString() +
                                            "</xProd><NCM>" + prod.Rows[0]["CF_NCM"].ToString() +
                                            "</NCM><CFOP>" + sat.Rows[0]["CFOP"].ToString() +
                                            "</CFOP><uCom>" + prod.Rows[0]["Unidade"].ToString() +
                                            "</uCom><qCom>" + qtde +
                                            "</qCom><vUnCom>" + grana + "</vUnCom><indRegra>" + sat.Rows[0]["RegraCalculo"].ToString() +
                                            "</indRegra></prod><imposto><vItem12741>" + Global.SAT_Param.vItem14741_Campo + "</vItem12741>";
                                        }
                                        if (prod.Rows[0]["VenderPro"].ToString() == "Preço" || prod.Rows[0]["VenderPro"].ToString() == "Peso"  )
                                        {
                                            if (Global.SAT_Ativo.SATativadoModoOperação == "emulador")
                                            {
                                                retorno += "<cEAN>7893460192261</cEAN><xProd>" + prod.Rows[0]["DescInterna"].ToString() +
                                                "</xProd><NCM>" + prod.Rows[0]["CF_NCM"].ToString() +
                                                "</NCM><CFOP>" + sat.Rows[0]["CFOP"].ToString() +
                                                "</CFOP><uCom>" + prod.Rows[0]["Unidade"].ToString() +
                                                "</uCom><qCom>" + qtde +
                                                "</qCom><vUnCom>" + grana + "</vUnCom><indRegra>" + sat.Rows[0]["RegraCalculo"].ToString() +
                                                "</indRegra></prod><imposto><vItem12741>" + Global.SAT_Param.vItem14741_Campo + "</vItem12741>";    
                                            }
                                            
                                        }
                                        if (prod.Rows[0]["VenderPro"].ToString() == "Preço" || prod.Rows[0]["VenderPro"].ToString() == "Peso" )
                                        {
                                            if (Global.SAT_Ativo.SATativadoModoOperação == "produção")
                                            {
                                                retorno += "<cEAN></cEAN><xProd>" + prod.Rows[0]["DescInterna"].ToString() +
                                                "</xProd><NCM>" + prod.Rows[0]["CF_NCM"].ToString() +
                                                "</NCM><CFOP>" + sat.Rows[0]["CFOP"].ToString() +
                                                "</CFOP><uCom>" + prod.Rows[0]["Unidade"].ToString() +
                                                "</uCom><qCom>" + qtde +
                                                "</qCom><vUnCom>" + grana + "</vUnCom><indRegra>" + sat.Rows[0]["RegraCalculo"].ToString() +
                                                "</indRegra></prod><imposto><vItem12741>" + Global.SAT_Param.vItem14741_Campo + "</vItem12741>";    
                                            }
                                            
                                        }
                                        
                                    }
                                    if (sat.Rows[0]["ICMS"].ToString() == "00" || sat.Rows[0]["ICMS"].ToString() == "20" ||
                                        sat.Rows[0]["ICMS"].ToString() == "90")
                                    {
                                        icms = "ICMS00";
                                        retorno += "<ICMS><" + icms + "><Orig>" + sat.Rows[0]["ICMS_Origem"].ToString() + "</Orig>" +
                                       "<CST>" + sat.Rows[0]["ICMS"].ToString() + "</CST><pICMS>" + sat.Rows[0]["ICMS_Aliq"].ToString() +
                                       "</pICMS></" + icms + "></ICMS>";
                                    }
                                    if (sat.Rows[0]["ICMS"].ToString() == "40" || sat.Rows[0]["ICMS"].ToString() == "41" ||
                                        sat.Rows[0]["ICMS"].ToString() == "50" || sat.Rows[0]["ICMS"].ToString() == "60")
                                    {
                                        icms = "ICMS40";
                                        retorno += "<ICMS><" + icms + "><Orig>" + sat.Rows[0]["ICMS_Origem"].ToString() + "</Orig>" +
                                        "<CST>" + sat.Rows[0]["ICMS"].ToString() + "</CST></" + icms + "></ICMS>";
                                    }
                                    if (sat.Rows[0]["ICMS"].ToString() == "102" || sat.Rows[0]["ICMS"].ToString() == "300" ||
                                        sat.Rows[0]["ICMS"].ToString() == "500")
                                    {
                                        icms = "ICM102";
                                        retorno += "<ICMS><" + icms + "><Orig>" + sat.Rows[0]["ICMS_Origem"].ToString() + "</Orig>" +
                                        "<CSOSN>" + sat.Rows[0]["ICMS"].ToString() + "</CSOSN></" +
                                        icms + "></ICMS>";
                                    }
                                    if (sat.Rows[0]["ICMS"].ToString() == "900")
                                    {
                                        icms = "ICMS900";
                                        retorno += "<ICMS><" + icms + "><Orig>" + sat.Rows[0]["ICMS_Origem"].ToString() + "</Orig>" +
                                      "<CSOSN>" + sat.Rows[0]["ICMS"].ToString() + "</CSOSN><pICMS>" + sat.Rows[0]["ICMS_Aliq"].ToString() +
                                      "</pICMS></" + icms + "></ICMS>";
                                    }

                                    //pis
                                    if (sat.Rows[0]["PIS"].ToString() == "PISNT")
                                    {
                                        retorno += "<PIS><PISNT><CST>" + sat.Rows[0]["PIS_CodSitTrib"].ToString() +
                                            "</CST></PISNT></PIS>";
                                    }
                                    if (sat.Rows[0]["PIS"].ToString() == "PISAliq")
                                    {
                                        retorno += "<PIS><PISAliq><CST>" + sat.Rows[0]["PIS_CodSitTrib"].ToString() +
                                        "</CST><vBC>" + sat.Rows[0]["PIS_vBC"].ToString() +
                                        "</vBC><pPIS>" + sat.Rows[0]["PIS_pPIS"].ToString() +
                                        "</pPIS></PISAliq></PIS>";
                                    }
                                    if (sat.Rows[0]["PIS"].ToString() == "PISQtde")
                                    {
                                        retorno += "<PIS><PISQtde><CST>" + sat.Rows[0]["PIS_CodSitTrib"].ToString() +
                                        "</CST><qBCProd>" + qtde + "</qBCProd><vAliqProd>" + sat.Rows[0]["PIS_vAliqProd"].ToString() + "</vAliqProd></PISQtde></PIS>";
                                    }
                                    if (sat.Rows[0]["PIS"].ToString() == "PISSN")
                                    {
                                        retorno += "<PIS><PISSN><CST>" + sat.Rows[0]["PIS_CodSitTrib"].ToString() +
                                            "</CST></PISSN></PIS>";
                                    }
                                    if (sat.Rows[0]["PIS"].ToString() == "PISOutrPercentual")
                                    {
                                        retorno += "<PIS><PISOutr><CST>" + sat.Rows[0]["PIS_CodSitTrib"].ToString() +
                                        "</CST><vBC>" + sat.Rows[0]["PIS_vBC"].ToString() +
                                        "</vBC><pPIS>" + sat.Rows[0]["PIS_pPIS"].ToString() +
                                        "</pPIS></PISOutr></PIS>";
                                    }
                                    if (sat.Rows[0]["PIS"].ToString() == "PISOutrValor")
                                    {
                                        retorno += "<PIS><PISOutr><CST>" + sat.Rows[0]["PIS_CodSitTrib"].ToString() +
                                        "</CST><qBCProd>" + qtde + "</qBCProd><vAliqProd>" + sat.Rows[0]["PIS_vAliqProd"].ToString() + "</vAliqProd></PISOutr></PIS>";
                                    }

                                    //pisst
                                    if (sat.Rows[0]["PISST"].ToString() == "PISSTPercentual")
                                    {
                                        retorno += "<PISST><vBC>" + sat.Rows[0]["PISST_vBC"].ToString() +
                                        "</vBC><pPIS>" + sat.Rows[0]["PISST_pPIS"].ToString() +
                                        "</pPIS></PISST>";
                                    }
                                    if (sat.Rows[0]["PISST"].ToString() == "PISSTValor")
                                    {
                                        retorno += "<PISST><qBCProd>" + qtde + "</qBCProd><vAliqProd>" + sat.Rows[0]["PISST_vAliqProd"].ToString() +
                                            "</vAliqProd></PISST>";
                                    }
                                    //cofins
                                    if (sat.Rows[0]["COFINS"].ToString() == "COFINSNT")
                                    {
                                        retorno += "<COFINS><COFINSNT><CST>" + sat.Rows[0]["COFINS_CodSitTrib"].ToString() +
                                            "</CST></COFINSNT></COFINS>";
                                    }
                                    if (sat.Rows[0]["COFINS"].ToString() == "COFINSAliq")
                                    {
                                        retorno += "<COFINS><COFINSAliq><CST>" + sat.Rows[0]["COFINS_CodSitTrib"].ToString() +
                                           "</CST><vBC>" + sat.Rows[0]["COFINS_vBC"].ToString() +
                                           "</vBC><pCOFINS>" + sat.Rows[0]["COFINS_pCOFINS"].ToString() +
                                           "</pCOFINS></COFINSAliq></COFINS>";
                                    }
                                    if (sat.Rows[0]["COFINS"].ToString() == "COFINSQtde")
                                    {
                                        retorno += "<COFINS><COFINSQtde><CST>" + sat.Rows[0]["COFINS_CodSitTrib"].ToString() +
                                           "</CST><qBCProd>" + qtde + "</qBCProd><vAliqProd>" + sat.Rows[0]["COFINS_vAliqProd"].ToString() +
                                           "</vAliqProd></COFINSQtde></COFINS>";
                                    }
                                    if (sat.Rows[0]["COFINS"].ToString() == "COFINSSN")
                                    {
                                        retorno += "<COFINS><COFINSSN><CST>" + sat.Rows[0]["COFINS_CodSitTrib"].ToString() +
                                            "</CST></COFINSSN></COFINS>";
                                    }
                                    if (sat.Rows[0]["COFINS"].ToString() == "COFINSOutrPercentual")
                                    {
                                        retorno += "<COFINS><COFINSOutr><CST>" + sat.Rows[0]["COFINS_CodSitTrib"].ToString() +
                                           "</CST><vBC>" + sat.Rows[0]["COFINS_vBC"].ToString() +
                                           "</vBC><pCOFINS>" + sat.Rows[0]["COFINS_pCOFINS"].ToString() +
                                           "</pCOFINS></COFINSOutr></COFINS>";
                                    }
                                    if (sat.Rows[0]["COFINS"].ToString() == "COFINSOutrValor")
                                    {
                                        retorno += "<COFINS><COFINSOutr><CST>" + sat.Rows[0]["COFINS_CodSitTrib"].ToString() +
                                           "</CST><qBCProd>" + qtde +
                                           "</qBCProd><vAliqProd>" + sat.Rows[0]["COFINS_vAliqProd"].ToString() +
                                           "</vAliqProd></COFINSOutr></COFINS>";
                                    }

                                    //cofinsst
                                    if (sat.Rows[0]["COFINSST"].ToString() == "COFINSSTPercentual")
                                    {
                                        retorno += "<COFINSST><vBC>" + sat.Rows[0]["COFINSST_vBC"].ToString() +
                                            "</vBC><pCOFINS>" + sat.Rows[0]["COFINSST_pCOFINS"].ToString() +
                                            "</pCOFINS></COFINSST></imposto></det>";
                                    }
                                    if (sat.Rows[0]["COFINSST"].ToString() == "COFINSSTValor")
                                    {
                                        retorno += "<COFINSST><qBCProd>" + qtde +
                                           "</qBCProd><vAliqProd>" + sat.Rows[0]["COFINSST_vAliqProd"].ToString() +
                                           "</vAliqProd></COFINSST></imposto></det>";
                                    }
                            }
                        }

                        if (emulador_ou_SAT == "emulador")
                        {
                            retorno += "<total /><pgto><MP><cMP>01</cMP><vMP>" + valorEmu.Replace(",",".") + "</vMP></MP></pgto></infCFe></CFe>";        
                        }
                        


                        if (emulador_ou_SAT == "produção")
                        {
                            
                            //-------------------------------------------------------------------------------------------------------------------------
                            if (Global.SAT_Param.Formas_Pagamento_Qtde == "não")
                            {
                                string pag = vendaNum.Rows[0]["Pagamento"].ToString();
                                if (pag == "dinheiro")
                                {
                                    Global.SAT_Param.Formas_Pagamento_dinheiro = "sim";
                                }
                                if (pag == "cheque")
                                {
                                    Global.SAT_Param.Formas_Pagamento_cheque = "sim";
                                }
                                if (pag == "cartão de débito")
                                {
                                    Global.SAT_Param.Formas_Pagamento_CD = "sim";
                                }
                                if (pag == "cartão de crédito")
                                {
                                    Global.SAT_Param.Formas_Pagamento_CC = "sim";
                                }

                                decimal soma = 0;
                                string total = "";
                                for (int k = 0; k < vendaNum.Rows.Count; k++)
                                {
                                    soma += Convert.ToDecimal(vendaNum.Rows[k]["Valor_Total"].ToString());
                                }
                                total = Convert.ToString(soma);
                                total = total.Replace(",", ".");
                                if (Global.SAT_Param.Formas_Pagamento_dinheiro == "sim")
                                {
                                    retorno += "<total /><pgto><MP><cMP>01</cMP><vMP>" + total + "</vMP></MP>";
                                }
                                if (Global.SAT_Param.Formas_Pagamento_cheque == "sim")
                                {
                                    retorno += "<total /><pgto><MP><cMP>02</cMP><vMP>" + total + "</vMP></MP>";
                                }
                                if (Global.SAT_Param.Formas_Pagamento_CC == "sim")
                                {
                                    retorno += "<total /><pgto><MP><cMP>03</cMP><vMP>" + total +
                                        "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CC_Codigo + "</cAdmC></MP>";
                                }
                                if (Global.SAT_Param.Formas_Pagamento_CD == "sim")
                                {
                                    retorno += "<total /><pgto><MP><cMP>04</cMP><vMP>" + total +
                                        "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                }
                                if (Global.SAT_Param.Formas_Pagamento_credito_loja == "sim")
                                {
                                    retorno += "<total /><pgto><MP><cMP>05</cMP><vMP>" + total + "</vMP></MP>";
                                }    
                                retorno += "</pgto></infCFe></CFe>";

                                
                            }
                            if (Global.SAT_Param.Formas_Pagamento_Qtde == "sim" )
                            {
                                bool continua = true;
                                if (Global.SAT_Param.Formas_Pagamento_dinheiro == "sim")
                                {
                                    retorno += "<total /><pgto><MP><cMP>01</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_dinheiro_valor + "</vMP></MP>";
                                    if (Global.SAT_Param.Formas_Pagamento_cheque == "sim")
                                    {
                                        retorno += "<MP><cMP>02</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_cheque_valor + "</vMP></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_CC == "sim")
                                    {
                                        retorno += "<MP><cMP>03</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CC_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CC_Codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_CD == "sim")
                                    {
                                        retorno += "<MP><cMP>04</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CD_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_credito_loja == "sim")
                                    {
                                         retorno += "<MP><cMP>05</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_credito_loja_valor + "</vMP></MP>";
                                    }
                                    retorno += "</pgto></infCFe></CFe>";
                                    continua = false;
                                }
                                if (Global.SAT_Param.Formas_Pagamento_cheque == "sim" && continua == true)
                                {
                                    retorno += "<total /><pgto><MP><cMP>02</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_cheque_valor + "</vMP></MP>";
                                    
                                    if (Global.SAT_Param.Formas_Pagamento_dinheiro == "sim")
                                    {
                                        retorno += "<MP><cMP>01</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_dinheiro_valor + "</vMP></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_CC == "sim")
                                    {
                                        retorno += "<MP><cMP>03</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CC_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CC_Codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_CD == "sim")
                                    {
                                        retorno += "<MP><cMP>04</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CD_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_credito_loja == "sim")
                                    {
                                        retorno += "<MP><cMP>05</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_credito_loja_valor + "</vMP></MP>";
                                    }
                                    retorno += "</pgto></infCFe></CFe>";
                                    continua = false;
                                }
                                if (Global.SAT_Param.Formas_Pagamento_CC == "sim" && continua == true)
                                {
                                    retorno += "<total /><pgto><MP><cMP>03</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CC_valor +
                                        "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CC_Codigo + "</cAdmC></MP>";
                                    if (Global.SAT_Param.Formas_Pagamento_dinheiro == "sim")
                                    {
                                        retorno += "<MP><cMP>01</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_dinheiro_valor + "</vMP></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_CD == "sim")
                                    {
                                        retorno += "<MP><cMP>04</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CD_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_cheque == "sim")
                                    {
                                        retorno += "<MP><cMP>02</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_cheque_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_credito_loja == "sim")
                                    {
                                        retorno += "<MP><cMP>05</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_credito_loja_valor + "</vMP></MP>";
                                    }
                                    retorno += "</pgto></infCFe></CFe>";
                                    continua = false;

                                }
                                if (Global.SAT_Param.Formas_Pagamento_CD == "sim" && continua == true)
                                {
                                    retorno += "<total /><pgto><MP><cMP>04</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CD_valor +
                                       "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    
                                    if (Global.SAT_Param.Formas_Pagamento_dinheiro == "sim")
                                    {
                                        retorno += "<MP><cMP>01</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_dinheiro_valor + "</vMP></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_CC == "sim")
                                    {
                                        retorno += "<MP><cMP>03</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CC_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CC_Codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_cheque == "sim")
                                    {
                                        retorno += "<MP><cMP>02</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_cheque_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_credito_loja == "sim")
                                    {
                                        retorno += "<MP><cMP>05</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_credito_loja_valor + "</vMP></MP>";
                                    }
                                    retorno += "</pgto></infCFe></CFe>";
                                    continua = false;
                                }
                                if (Global.SAT_Param.Formas_Pagamento_credito_loja == "sim" && continua == true)
                                {

                                    retorno += "<total /><pgto><MP><cMP>05</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_credito_loja_valor + "</vMP></MP>";
                                    if (Global.SAT_Param.Formas_Pagamento_dinheiro == "sim")
                                    {
                                        retorno += "<MP><cMP>01</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_dinheiro_valor + "</vMP></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_CD == "sim")
                                    {
                                        retorno += "<MP><cMP>04</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CD_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_cheque == "sim")
                                    {
                                        retorno += "<MP><cMP>02</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_cheque_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_CC == "sim")
                                    {
                                        retorno += "<MP><cMP>03</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CC_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CC_Codigo + "</cAdmC></MP>";
                                    }
                                                                       
                                    
                                    retorno += "</pgto></infCFe></CFe>";
                                    continua = false;
                                    
                                }
                                if (Global.SAT_Param.Formas_Pagamento_cheque == "sim" && continua == true)
                                {
                                    retorno += "<total /><pgto><MP><cMP>02</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_credito_loja_valor + "</vMP></MP>";

                                    if (Global.SAT_Param.Formas_Pagamento_dinheiro == "sim")
                                    {
                                        retorno += "<MP><cMP>01</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_dinheiro_valor + "</vMP></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_CD == "sim")
                                    {
                                        retorno += "<MP><cMP>04</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CD_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    }
                                    
                                    if (Global.SAT_Param.Formas_Pagamento_CC == "sim")
                                    {
                                        retorno += "<MP><cMP>03</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_CC_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CC_Codigo + "</cAdmC></MP>";
                                    }
                                    if (Global.SAT_Param.Formas_Pagamento_credito_loja == "sim")
                                    {
                                        retorno += "<MP><cMP>05</cMP><vMP>" + Global.SAT_Param.Formas_Pagamento_cheque_valor +
                                            "</vMP><cAdmC>" + Global.SAT_Param.Formas_Pagamento_CD_codigo + "</cAdmC></MP>";
                                    }

                                    retorno += "</pgto></infCFe></CFe>";
                                    

                                }
                            
                            }
                            
                        }
                        
                            
                    }
                      
                }
                
            }
            
            return retorno;


            
            
        }
        
        //*********************************************************************************************************
        //*********************************************************************************************************
        public String CancelaVenda_XML(string Cfe,string emulador_ou_SAT)
        {
            String retorno = "";
            if (emulador_ou_SAT == "emulador")
            {
                retorno = "<CFeCanc><infCFe chCanc=\"" + Cfe + "\"><ide><CNPJ>11111111111111</CNPJ><signAC>1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfeiuyt</signAC>" +
                "<numeroCaixa>001</numeroCaixa></ide><emit></emit><dest/><total></total></infCFe></CFeCanc>";    
            }
            if (emulador_ou_SAT == "produção")
            {
                retorno = "<CFeCanc><infCFe chCanc=\"" + Cfe + "\"><ide><CNPJ>" + Global.SAT_Param.CNPJ_SoftwareHouse + 
                "</CNPJ><signAC>" + Global.SAT_Param.signAC_344 + "</signAC>" + "<numeroCaixa>" + Global.SAT_Param.numeroCaixa + "</numeroCaixa></ide><emit></emit><dest/><total></total></infCFe></CFeCanc>";
            }
            
            return retorno;
        }
    }
}
