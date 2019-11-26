using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gerenciador_Comercial
{
    class CadastrarProdutoSAT
    {
        public void InsereSATCadastro()
        {
            string icms = "";
            string icmsOrig = "";
            string pICMS = "";
            if (GlobalSAT.TributaçãoICMS == "102" || GlobalSAT.TributaçãoICMS == "300" || GlobalSAT.TributaçãoICMS == "500")
            {
                icms = XML_SAT.CSOSN_ICMSSN102;
                icmsOrig = XML_SAT.Orig_ICMSSN102;
                pICMS = "";
            }
            if (GlobalSAT.TributaçãoICMS == "40" || GlobalSAT.TributaçãoICMS == "41" || GlobalSAT.TributaçãoICMS == "50" ||
                GlobalSAT.TributaçãoICMS == "60")
            {
                icms = XML_SAT.CST_ICMS40;
                icmsOrig = XML_SAT.Orig_ICMS40;
                pICMS = "";
            }
            if (GlobalSAT.TributaçãoICMS == "00" ||  GlobalSAT.TributaçãoICMS == "20" || GlobalSAT.TributaçãoICMS == "90")
            {
                icms = XML_SAT.CST_ICMS00;
                icmsOrig = XML_SAT.Orig_ICMS00;
                pICMS = XML_SAT.pICMS00;
            }
            if (GlobalSAT.TributaçãoICMS == "900")
            {
                icms = XML_SAT.CSOSN_ICMSSN900;
                icmsOrig = XML_SAT.Orig_ICMSSN900;
                pICMS = XML_SAT.pICMS_ICMSSN900;
		                
            }
            if (GlobalSAT.PIS == "PISNT")
            {
                if (GlobalSAT.PISST == "Percentual")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig,pICMS,
                                "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                                "PISSTPercentual",XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTPercentual/COFINAliq/COFINSSTPercentual

                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                                "PISSTPercentual",XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq,XML_SAT.pCOFINS_COFINSAliq, "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "", 
                               "PISSTPercentual",XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq,XML_SAT.pCOFINS_COFINSAliq, "", "", 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTPercentual/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "", 
                                "PISSTPercentual",XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "",XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;

                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "", 
                               "PISSTPercentual",XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSQtdeq", XML_SAT.CST_COFINSQtde, "", "",XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "", 
                                "PISSTPercentual",XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "","", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                                XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTPercentual/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
                if (GlobalSAT.PISST == "Valor")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTValor/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                               "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                               "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTValor/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                              "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTValor/COFINAliq/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                              "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTValor/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTValor/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTValor/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                            "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                            "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                            "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                            "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                            XML_SAT.CFOP, XML_SAT.indRegra,
                            XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTValor/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTValor/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {

                            //icms/PISNT/PISSTValor/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTValor/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISNT/PISSTValor/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISNT/PISSTValor/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISNT", XML_SAT.CST_PIS_PISNT, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
            }
            if (GlobalSAT.PIS == "PISAliq")
            {
                if (GlobalSAT.PISST == "Percentual")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                                XML_SAT.CFOP, XML_SAT.indRegra, XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINAliq/COFINSSTPercentual

                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq,XML_SAT.pCOFINS_COFINSAliq, "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "", 
                               "PISSTPercentual",XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq,XML_SAT.pCOFINS_COFINSAliq, "", "", 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "", 
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;

                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "", 
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSQtdeq", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                                XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTPercentual/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
                if (GlobalSAT.PISST == "Valor")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTValor/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                               "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                               "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTValor/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                              "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTValor/COFINAliq/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                              "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTValor/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTValor/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTValor/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                            "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                            "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                            "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                            "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                            XML_SAT.CFOP, XML_SAT.indRegra,
                            XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTValor/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTValor/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {

                            //icms/PISAliq/PISSTValor/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISAliq/PISSTValor/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISAliq/PISSTValor/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {

                            //icms/PISAliq/PISSTValor/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISAliq", XML_SAT.CST_PIS_PISAliq, XML_SAT.vBC_PIS_PISAliq, XML_SAT.pPIS_PIS_PISAliq, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
            }
            if (GlobalSAT.PIS == "PISQtde")
            {
                if (GlobalSAT.PISST == "Percentual")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                                XML_SAT.CFOP, XML_SAT.indRegra, XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINAliq/COFINSSTPercentual

                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "", 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;

                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSQtdeq", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                                XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTPercentual/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
                if (GlobalSAT.PISST == "Valor")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTValor/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                               "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                               "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTValor/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                              "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTValor/COFINAliq/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                              "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTValor/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTValor/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTValor/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                            "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                            "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                            "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                            "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                            XML_SAT.CFOP, XML_SAT.indRegra,
                            XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTValor/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTValor/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {

                            //icms/PISQtde/PISSTValor/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISQtde/PISSTValor/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISQtde/PISSTValor/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {

                            //icms/PISQtde/PISSTValor/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISQtde", XML_SAT.CST_PIS_PISQtde, "", "", XML_SAT.QBCProd_PIS_PISQtde, XML_SAT.vAliqProd_PIS_PISQtde,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
            }
            if (GlobalSAT.PIS == "PISSN")
            {
                if (GlobalSAT.PISST == "Percentual")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTPercentual/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                                XML_SAT.CFOP, XML_SAT.indRegra, XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTPercentual/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTPercentual/COFINAliq/COFINSSTPercentual

                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq,
                                XML_SAT.pCOFINS_COFINSAliq, "", "", "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTPercentual/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "", 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTPercentual/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;

                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTPercentual/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSQtdeq", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTPercentual/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTPercentual/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                                XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSSN/PISSTPercentual/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTPercentual/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTPercentual/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTPercentual/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
                if (GlobalSAT.PISST == "Valor")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTValor/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                               "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                               "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTValor/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                              "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTValor/COFINAliq/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                              "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTValor/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTValor/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTValor/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                            "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                            "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                            "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                            "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                            XML_SAT.CFOP, XML_SAT.indRegra,
                            XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTValor/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTValor/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {

                            //icms/PISSN/PISSTValor/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISSN/PISSTValor/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISSN/PISSTValor/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {

                            //icms/PISSN/PISSTValor/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISSN", XML_SAT.CST_PIS_PISSN, "", "", "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
            }
            if (GlobalSAT.PIS == "PISOutrPercentual")
            {
                if (GlobalSAT.PISST == "Percentual")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                                XML_SAT.CFOP, XML_SAT.indRegra, XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINAliq/COFINSSTPercentual

                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "", 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;

                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSQtdeq", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                                XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTPercentual/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
                if (GlobalSAT.PISST == "Valor")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                               "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                               "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                              "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINAliq/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                              "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                            "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                            "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                            "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                            "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                            XML_SAT.CFOP, XML_SAT.indRegra,
                            XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {

                            //icms/PISOutrPercentual/PISSTValor/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrPercentual/PISSTValor/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {

                            //icms/PISOutrPercentual/PISSTValor/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrPercentual", XML_SAT.CST_PIS_PISOutr, XML_SAT.vBC_PIS_PISOutr, XML_SAT.pPIS_PIS_PISOutr, "", "",
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
            }
            if (GlobalSAT.PIS == "PISOutrValor")
            {
                if (GlobalSAT.PISST == "Percentual")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                                XML_SAT.CFOP, XML_SAT.indRegra, XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINAliq/COFINSSTPercentual

                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "", 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;

                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                               "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                               "COFINSQtdeq", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde, 
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST, XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;

                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS, 
                                "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "", 
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "", 
                                "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "", XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                                "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                                "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                                "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                                "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                                XML_SAT.CFOP, XML_SAT.indRegra,
                                XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTPercentual/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                               "PISSTPercentual", XML_SAT.vBC_PISST, XML_SAT.pPIS_PISST, "", "",
                               "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                               "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
                if (GlobalSAT.PISST == "Valor")
                {
                    if (GlobalSAT.COFINS == "COFINSNT")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINSNT/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                               "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                               "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                               "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                               "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                               XML_SAT.CFOP, XML_SAT.indRegra,
                               XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINSNT/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSNT", XML_SAT.CST_COFINSNT, "", "", "", "",
                              "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }

                    }
                    if (GlobalSAT.COFINS == "COFINSAliq")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINAliq/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                              "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                              "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                              "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                              "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                              XML_SAT.CFOP, XML_SAT.indRegra,
                              XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINSAliq/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSAliq", XML_SAT.CST_COFINSAliq, XML_SAT.vBC_COFINSAliq, XML_SAT.pCOFINS_COFINSAliq, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSQtde")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINQtde/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINSQtde/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                            "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                            "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                            "COFINSQtde", XML_SAT.CST_COFINSQtde, "", "", XML_SAT.QBCProd_COFINSQtde, XML_SAT.vAliqProd_COFINSQtde,
                            "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                            XML_SAT.CFOP, XML_SAT.indRegra,
                            XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSSN")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINSSN/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINSSN/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSSN", XML_SAT.CST_COFINSSN, "", "", "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrPercentual")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {

                            //icms/PISOutrValor/PISSTValor/COFINSOutrPercentual/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINSOutrPercentual/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrPercentual", XML_SAT.CST_COFINSOutr, XML_SAT.vBC_COFINSOutr, XML_SAT.pCOFINS_COFINSOutr, "", "",
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                    if (GlobalSAT.COFINS == "COFINSOutrValor")
                    {
                        if (GlobalSAT.COFINSST == "Percentual")
                        {
                            //icms/PISOutrValor/PISSTValor/COFINSOutrValor/COFINSSTPercentual
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTPercentual", XML_SAT.vBC_COFINSST, XML_SAT.pCOFINS_COFINSST, "", "",
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                        if (GlobalSAT.COFINSST == "Valor")
                        {

                            //icms/PISOutrValor/PISSTValor/COFINSOutrValor/COFINSSTValor
                            DALCadastro.InserirSATCadastro(Convert.ToInt32(Global.Margem.IdProdSAT), icms, icmsOrig, pICMS,
                             "PISOutrValor", XML_SAT.CST_PIS_PISOutr, "", "", XML_SAT.QBCProd_PIS_PISOutr, XML_SAT.vAliqProd_PIS_PISOutr,
                             "PISSTValor", "", "", XML_SAT.QBCProd_PISST, XML_SAT.vAliqProd_PISST,
                             "COFINSOutrValor", XML_SAT.CST_COFINSOutr, "", "", XML_SAT.QBCProd_COFINSOutr, XML_SAT.vAliqProd_COFINSOutr,
                             "COFINSSTValor", "", "", XML_SAT.QBCProd_COFINSST, XML_SAT.vAliqProd_COFINSST,
                             XML_SAT.CFOP, XML_SAT.indRegra,
                             XML_SAT.vItem12741);
                            return;
                        }
                    }
                }
            }
            
        }
    }
}
