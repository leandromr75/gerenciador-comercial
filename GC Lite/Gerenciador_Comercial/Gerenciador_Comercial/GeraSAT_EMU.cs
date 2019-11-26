using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace Gerenciador_Comercial
{
    class GeraSAT_EMU
    {
        public String EnviaXML(int idSAT, string emulador_ou_SAT)
        {
            String retorno = "";

            //***************************************************
            //Envia XML para Emulador
            //***************************************************
            if (emulador_ou_SAT == "emulador")
            {
                DataTable sat = DALCadastro.CarregaSAT(idSAT);
                if (sat.Rows.Count > 0)
                {
                    retorno += "<CFe><infCFe versaoDadosEnt=\"0.03\"><ide><CNPJ>11111111111111</CNPJ><signAC>1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfeiuyt</signAC>" +
                            "<numeroCaixa>001</numeroCaixa></ide><emit><CNPJ>11111111111111</CNPJ><IE>111111111111</IE><IM>123123</IM><indRatISSQN>N</indRatISSQN></emit><dest /><det nItem=\"1\">";

                    string icms = "";
                    //string pis = "";
                    //string cofins = "";
                    //pegar dados produto
                    DataTable prod = DALCadastro.listaProdutos(idSAT);
                    if (prod.Rows.Count > 0)
                    {

                        string grana = prod.Rows[0]["ValorVenda"].ToString();
                        grana = grana.Replace(",", ".");
                        retorno += "<prod><cProd>" + Convert.ToString(idSAT) +
                               "</cProd><cEAN>" + prod.Rows[0]["CodEAN"].ToString() +
                               "</cEAN><xProd>" + prod.Rows[0]["DescInterna"].ToString() +
                               "</xProd><NCM>" + prod.Rows[0]["CF_NCM"].ToString() +
                               "</NCM><CFOP>" + sat.Rows[0]["CFOP"].ToString() +
                               "</CFOP><uCom>" + prod.Rows[0]["Unidade"].ToString() +
                               "</uCom><qCom>" + "1.0000" +
                               "</qCom><vUnCom>" + grana + "</vUnCom><indRegra>" + sat.Rows[0]["RegraCalculo"].ToString() +
                               "</indRegra></prod><imposto><vItem12741>" + grana + "</vItem12741><ICMS>";
                        if (sat.Rows[0]["ICMS"].ToString() == "00" || sat.Rows[0]["ICMS"].ToString() == "20" ||
                            sat.Rows[0]["ICMS"].ToString() == "90")
                        {
                            icms = "ICMS00";
                            retorno += "<" + icms + "><Orig>" + sat.Rows[0]["ICMS_Origem"].ToString() + "</Orig>" +
                           "<CST>" + sat.Rows[0]["ICMS"].ToString() + "</CST><pICMS>" + sat.Rows[0]["ICMS_Aliq"].ToString() +
                           "</pICMS></" + icms + "></ICMS>";
                        }
                        if (sat.Rows[0]["ICMS"].ToString() == "40" || sat.Rows[0]["ICMS"].ToString() == "41" ||
                            sat.Rows[0]["ICMS"].ToString() == "50" || sat.Rows[0]["ICMS"].ToString() == "60")
                        {
                            icms = "ICMS40";
                            retorno += "<" + icms + "><Orig>" + sat.Rows[0]["ICMS_Origem"].ToString() + "</Orig>" +
                            "<CST>" + sat.Rows[0]["ICMS"].ToString() + "</CST></" +
                            icms + "></ICMS>";
                        }
                        if (sat.Rows[0]["ICMS"].ToString() == "102" || sat.Rows[0]["ICMS"].ToString() == "300" ||
                            sat.Rows[0]["ICMS"].ToString() == "500")
                        {
                            icms = "ICM102";
                            retorno += "<" + icms + "><Orig>" + sat.Rows[0]["ICMS_Origem"].ToString() + "</Orig>" +
                            "<CSOSN>" + sat.Rows[0]["ICMS"].ToString() + "</CSOSN></" +
                            icms + "></ICMS>";
                        }
                        if (sat.Rows[0]["ICMS"].ToString() == "900")
                        {
                            icms = "ICMS900";
                            retorno += "<" + icms + "><Orig>" + sat.Rows[0]["ICMS_Origem"].ToString() + "</Orig>" +
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
                                "</CST><qBCProd>" + sat.Rows[0]["PIS_qBCProd"].ToString() +
                                "</qBCProd><vAliqProd>" + sat.Rows[0]["PIS_vAliqProd"].ToString() + "</vAliqProd></PISQtde></PIS>";
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
                                "</CST><qBCProd>" + sat.Rows[0]["PIS_qBCProd"].ToString() +
                                "</qBCProd><vAliqProd>" + sat.Rows[0]["PIS_vAliqProd"].ToString() + "</vAliqProd></PISOutr></PIS>";
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
                            retorno += "<PISST><qBCProd>" + sat.Rows[0]["PISST_qBCProd"].ToString() +
                                "</qBCProd><vAliqProd>" + sat.Rows[0]["PISST_vAliqProd"].ToString() +
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
                               "</CST><qBCProd>" + sat.Rows[0]["COFINS_qBCProd"].ToString() +
                               "</qBCProd><vAliqProd>" + sat.Rows[0]["COFINS_vAliqProd"].ToString() +
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
                               "</CST><qBCProd>" + sat.Rows[0]["COFINS_qBCProd"].ToString() +
                               "</qBCProd><vAliqProd>" + sat.Rows[0]["COFINS_vAliqProd"].ToString() +
                               "</vAliqProd></COFINSOutr></COFINS>";
                        }

                        //cofinsst
                        if (sat.Rows[0]["COFINSST"].ToString() == "COFINSSTPercentual")
                        {
                            retorno += "<COFINSST><vBC>" + sat.Rows[0]["COFINSST_vBC"].ToString() +
                                "</vBC><pCOFINS>" + sat.Rows[0]["COFINSST_pCOFINS"].ToString() +
                                "</pCOFINS></COFINSST></imposto>";
                        }
                        if (sat.Rows[0]["COFINSST"].ToString() == "COFINSSTValor")
                        {
                            retorno += "<COFINSST><qBCProd>" + sat.Rows[0]["COFINSST_qBCProd"].ToString() +
                               "</qBCProd><vAliqProd>" + sat.Rows[0]["COFINSST_vAliqProd"].ToString() +
                               "</vAliqProd></COFINSST></imposto>";
                        }
                        retorno += "</det><total /><pgto><MP><cMP>01</cMP><vMP>" + grana + "</vMP></MP></pgto></infCFe></CFe>";
                        //retorno += "</det><total /><pgto><MP><cMP>01</cMP><vMP>100.00</vMP></MP></pgto></infCFe></CFe>";
                    }

                }

            }


            return retorno;
        }

        //*********************************************************************************************************
        //*********************************************************************************************************
        public String CancelaVenda_XML(string Cfe, string emulador_ou_SAT)
        {
            String retorno = "";

            retorno = "<CFeCanc><infCFe chCanc=\"" + Cfe + "\"><ide><CNPJ>11111111111111</CNPJ><signAC>1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfe1234567890qwertyuiok1234567890drfeiuyt</signAC>" +
                "<numeroCaixa>001</numeroCaixa></ide><emit></emit><dest/><total></total></infCFe></CFeCanc>";
            return retorno;
        }
    }
}
