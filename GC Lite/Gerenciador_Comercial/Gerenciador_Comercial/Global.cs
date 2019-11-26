using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gerenciador_Comercial
{
    class Global
    {
        public static class SAT_Ativo
        {
            private static string ativo = ""; //sim,não
            public static string SATativado
            {
                get { return ativo; }
                set { ativo = value; }
            }
            private static string cs = ""; //sim,não
            public static string CupomSATativado
            {
                get { return cs; }
                set { cs = value; }
            }
            private static string mo = ""; //sim,não
            public static string SATativadoModoOperação
            {
                get { return mo; }
                set { mo = value; }
            }
        }
        public static class SAT_Param
        {
            
            private static string dezesseis60 = "";
            public static string Informa_IM
            {
                get { return dezesseis60; }
                set { dezesseis60 = value; }
            }
            private static string dezesseis50 = "";
            public static string Formas_Pagamento_credito_loja_valor
            {
                get { return dezesseis50; }
                set { dezesseis50 = value; }
            }
            private static string dezesseis5 = "";
            public static string Formas_Pagamento_credito_loja
            {
                get { return dezesseis5; }
                set { dezesseis5 = value; }
            }
            private static string dezesseis22 = "";
            public static string Formas_Pagamento_CD_valor
            {
                get { return dezesseis22; }
                set { dezesseis22 = value; }
            }
            private static string dezesseis20 = "";
            public static string Formas_Pagamento_CD_codigo
            {
                get { return dezesseis20; }
                set { dezesseis20 = value; }
            }
            private static string dezesseis4 = "";
            public static string Formas_Pagamento_CD
            {
                get { return dezesseis4; }
                set { dezesseis4 = value; }
            }
            private static string dezesseis12 = "";
            public static string Formas_Pagamento_CC_valor
            {
                get { return dezesseis12; }
                set { dezesseis12 = value; }
            }
            private static string dezesseis8 = "";
            public static string Formas_Pagamento_CC
            {
                get { return dezesseis8; }
                set { dezesseis8 = value; }
            }
            private static string dezesseis10 = "";
            public static string Formas_Pagamento_CC_Codigo
            {
                get { return dezesseis10; }
                set { dezesseis10 = value; }
            }
            private static string dezesseis2 = "";
            public static string Formas_Pagamento_cheque
            {
                get { return dezesseis2; }
                set { dezesseis2 = value; }
            }
            private static string dezesseis7 = "";
            public static string Formas_Pagamento_cheque_valor
            {
                get { return dezesseis7; }
                set { dezesseis7 = value; }
            }
            private static string dezesseis6 = "";
            public static string Formas_Pagamento_dinheiro_valor
            {
                get { return dezesseis6; }
                set { dezesseis6 = value; }
            }
            private static string dezesseis = "";
            public static string Formas_Pagamento_dinheiro
            {
                get { return dezesseis; }
                set { dezesseis = value; }
            }
            private static string quinze = "";
            public static string Formas_Pagamento_Qtde
            {
                get { return quinze; }
                set { quinze = value; }
            }
            private static string quatorze = "";
            public static string vItem14741_Campo
            {
                get { return quatorze; }
                set { quatorze = value; }
            }
            private static string treze = "";
            public static string qCom_QTDE_Comercial
            {
                get { return treze; }
                set { treze = value; }
            }
            private static string doze = "";
            public static string Numero_Items
            {
                get { return doze; }
                set { doze = value; }
            }
            private static string onze = "";
            public static string Nome_Destinatario
            {
                get { return onze; }
                set { onze = value; }
            }
            private static string dez = "";
            public static string CNPJ_Destinatario
            {
                get { return dez; }
                set { dez = value; }
            }
            private static string nove = "";
            public static string CPF_Destinatario
            {
                get { return nove; }
                set { nove = value; }
            }
            private static string oito = "";
            public static string Forneceu_CNPJ_ou_CPF
            {
                get { return oito; }
                set { oito = value; }
            }
            private static string sete = "";
            public static string IM_Emitente
            {
                get { return sete; }
                set { sete = value; }
            }
            private static string seis = "";
            public static string IE_Emitente
            {
                get { return seis; }
                set { seis = value; }
            }
            private static string cinco = "";
            public static string CNPJ_Emitente
            {
                get { return cinco; }
                set { cinco = value; }
            }
            private static string quatro = "";
            public static string numeroCaixa
            {
                get { return quatro; }
                set { quatro = value; }
            }
            private static string tres = "";
            public static string signAC_344
            {
                get { return tres; }
                set { tres = value; }
            }
            private static string dois = "";
            public static string CNPJ_SoftwareHouse
            {
                get { return dois; }
                set { dois = value; }
            }
            private static string um = "0.03";
            public static string VersaoDadosEntrada
            {
                get { return um; }
                set { um = value; }
            }
            private static string produção = "";
            public static string SAT_Produção
            {
                get { return produção; }
                set { produção = value; }
            }
        }

        //_________________________________________________
        //-------------------------------------------------
        //#################################################
        public static class Margem
        {
            private static string msg177 = "";
            public static string CodeBarURL
            {
                get { return msg177; }
                set { msg177 = value; }
            }
            private static string msg227 = "";
            public static string CodeBarTexto
            {
                get { return msg227; }
                set { msg227 = value; }
            }


            private static string msg77 = "";
            public static string CancelaSAT
            {
                get { return msg77; }
                set { msg77 = value; }
            }
            private static string msg7 = "";
            public static string CupomResumido
            {
                get { return msg7; }
                set { msg7 = value; }
            }
            private static string msg6 = "";
            public static string PagParcialFiadoSaldoDevedor
            {
                get { return msg6; }
                set { msg6 = value; }
            }
            private static string msg5 = "";
            public static string PagParcialFiado
            {
                get { return msg5; }
                set { msg5 = value; }
            }
            private static string msg4 = "";
            public static string PagParcialFiadoC
            {
                get { return msg4; }
                set { msg4 = value; }
            }
            private static string msg3 = "";
            public static string PagParcialFiadoCC
            {
                get { return msg3; }
                set { msg3 = value; }
            }
            private static string msg2 = "";
            public static string PagParcialFiadoD
            {
                get { return msg2; }
                set { msg2 = value; }
            }
            private static string msg = "";
            public static string PagParcialFiadoCD
            {
                get { return msg; }
                set { msg = value; }
            }
            private static string clienteTemp = "";
            public static string ClienteFiadoTemp
            {
                get { return clienteTemp; }
                set { clienteTemp = value; }
            }
            private static string vendTemp = "";
            public static string BaixaVendasFiado
            {
                get { return vendTemp; }
                set { vendTemp = value; }
            }
            private static string abrefrac = "";
            public static string AbrirFracionado
            {
                get { return abrefrac; }
                set { abrefrac = value; }
            }
           
            private static string preçopesomanual = "";
            public static string PreçoPesoManual
            {
                get { return preçopesomanual; }
                set { preçopesomanual = value; }
            }
            private static string preçomanual = "";
            public static string PreçoManual
            {
                get { return preçomanual; }
                set { preçomanual = value; }
            }
            private static string fechamentof = "";
            public static string FechamentoCaixaf
            {
                get { return fechamentof; }
                set { fechamentof = value; }
            }
            private static string fechamentoc = "";
            public static string FechamentoCaixac
            {
                get { return fechamentoc; }
                set { fechamentoc = value; }
            }
            private static string fechamentocc = "";
            public static string FechamentoCaixacc
            {
                get { return fechamentocc; }
                set { fechamentocc = value; }
            }
            private static string fechamentocd = "";
            public static string FechamentoCaixacd
            {
                get { return fechamentocd; }
                set { fechamentocd = value; }
            }
            private static string fechamentod = "";
            public static string FechamentoCaixad
            {
                get { return fechamentod; }
                set { fechamentod = value; }
            }
            private static string fechamento = "";
            public static string FechamentoCaixa
            {
                get { return fechamento; }
                set { fechamento = value; }
            }
            private static string valordesc = "";
            public static string DescontoValor
            {
                get { return valordesc; }
                set { valordesc = value; }
            }
            private static string precokilo = "";
            public static string PreçoKiloAlternetivo
            {
                get { return precokilo; }
                set { precokilo = value; }
            }
            private static string temtroco = "";
            public static string TemTroco
            {
                get { return temtroco; }
                set { temtroco = value; }
            }
            private static string impress = "";
            public static string Impressora
            {
                get { return impress; }
                set { impress = value; }
            }
            private static string eantemp1 = "";
            public static string EANTemp
            {
                get { return eantemp1; }
                set { eantemp1 = value; }
            }
            private static string eantemp = "";
            public static string EANTemp2
            {
                get { return eantemp; }
                set { eantemp = value; }
            }
            private static string generotemp2 = "";
            public static string generoTemp2
            {
                get { return generotemp2; }
                set { generotemp2 = value; }
            }
            private static string generotemp = "";
            public static string generoTemp
            {
                get { return generotemp; }
                set { generotemp = value; }
            }
            private static string ncmtemp2 = "";
            public static string NCMTemp2
            {
                get { return ncmtemp2; }
                set { ncmtemp2 = value; }
            }
            private static string ncmtemp = "";
            public static string NCMTemp
            {
                get { return ncmtemp; }
                set { ncmtemp = value; }
            }
            private static string cfoptemp = "";
            public static string CFOP_Entr
            {
                get { return cfoptemp; }
                set { cfoptemp = value; }
            }
            private static string editareg = "";
            public static string EditarCad
            {
                get { return editareg; }
                set { editareg = value; }
            }
            private static string abreAviso = "";
            public static string AbreAviso
            {
                get { return abreAviso; }
                set { abreAviso = value; }
            }
            private static string margemM = "";
            public static string MargemM
            {
                get { return margemM; }
                set { margemM = value; }
            }
            private static string margemtipo = "";
            public static string MargemTipo
            {
                get { return margemtipo; }
                set { margemtipo = value; }
            }
            private static string margemP = "";
            public static string MargemPersonalizada
            {
                get { return margemP; }
                set { margemP = value; }
            }
            private static string eanTemp = "";
            public static string EANCadRapido
            {
                get { return eanTemp; }
                set { eanTemp = value; }
            }
            private static string IdTemp = "";
            public static string IDCadRapido
            {
                get { return IdTemp; }
                set { IdTemp = value; }
            }
            private static string cadrap = "";
            public static string CadRapido
            {
                get { return cadrap; }
                set { cadrap = value; }
            }
            private static string peso = "";
            public static string VenderPeso
            {
                get { return peso; }
                set { peso = value; }
            }
            private static string pcad = "";
            public static string TemCad
            {
                get { return pcad; }
                set { pcad = value; }
            }
            private static string troco = "";
            public static string Troco
            {
                get { return troco; }
                set { troco = value; }
            }
            private static string trocoTOT = "";
            public static string TrocoVenda
            {
                get { return trocoTOT; }
                set { trocoTOT = value; }
            }
            private static string pagquita = "";
            public static string QuitafiadoPag
            {
                get { return pagquita; }
                set { pagquita = value; }
            }
            private static string compraatual = "";
            public static string CompraAtual
            {
                get { return compraatual; }
                set { compraatual = value; }
            }
            private static string saldoFiado = "";
            public static string SaldoDevedorFiado
            {
                get { return saldoFiado; }
                set { saldoFiado = value; }
            }
            private static string estund = "";
            public static string EstoqueUnd
            {
                get { return estund; }
                set { estund = value; }
            }
            private static string estqtde = "";
            public static string EstoqueQtde 
            {
                get { return estqtde; }
                set { estqtde = value; }
            }
            private static string estvalor = "";
            public static string EstoqueValor
            {
                get { return estvalor; }
                set { estvalor = value; }
            }
            private static string estcusto = "";
            public static string EstoqueCusto
            {
                get { return estcusto; }
                set { estcusto = value; }
            }
            private static string nomeProd = "";
            public static string xProd
            {
                get { return nomeProd; }
                set { nomeProd = value; }
            }
            private static string editSAT = "";
            public static string EditaSAT
            {
                get { return editSAT; }
                set { editSAT = value; }
            }
            private static string IdProdSAT00 = "";
            public static string IdProdSAT
            {
                get { return IdProdSAT00; }
                set { IdProdSAT00 = value; }
            }
            private static string imprimefiado = "";
            public static string ImprimeFiado
            {
                get { return imprimefiado; }
                set { imprimefiado = value; }
            }
            private static string cupomtxt2 = "";
            public static string CupomTexto2
            {
                get { return cupomtxt2; }
                set { cupomtxt2 = value; }
            }
            private static string cupomtxt1 = "";
            public static string CupomTexto1
            {
                get { return cupomtxt1; }
                set { cupomtxt1 = value; }
            }
            private static string cupomie = "";
            public static string CupomIE
            {
                get { return cupomie; }
                set { cupomie = value; }
            }
            private static string cupomCNPJ = "";
            public static string CupomCNPJ
            {
                get { return cupomCNPJ; }
                set { cupomCNPJ = value; }
            }
            private static string cupomEmpresa = "";
            public static string CupomEmpresa
            {
                get { return cupomEmpresa; }
                set { cupomEmpresa = value; }
            }
            private static string retiradaCaixa = "";
            public static string RetiradaCaixa
            {
                get { return retiradaCaixa; }
                set { retiradaCaixa = value; }
            }
            private static string IDretornoaviso = "";
            public static string RetornarIDaviso
            {
                get { return IDretornoaviso; }
                set { IDretornoaviso = value; }
            }
            private static string IDretorno = "";
            public static string RetornarID
            {
                get { return IDretorno; }
                set { IDretorno = value; }
            }
            private static string servidorImpressao = "";
            public static string ServidorImpressao
            {
                get { return servidorImpressao; }
                set { servidorImpressao = value; }
            }
            private static string clientefiado = "";
            public static string ClienteFiado
            {
                get { return clientefiado; }
                set { clientefiado = value; }
            }
            private static string empres = "";
            public static string EmpresaCaixa
            {
                get { return empres; }
                set { empres = value; }
            }
            private static string caixaaberto = "";
            public static string CaixaAberto
            {
                get { return caixaaberto; }
                set { caixaaberto = value; }
            }
            private static string valoraberto = "";
            public static string ValorAberto
            {
                get { return valoraberto; }
                set { valoraberto = value; }
            }
            private static string contaaberta = "";
            public static string ContaAberta
            {
                get { return contaaberta; }
                set { contaaberta = value; }
            }
            
            private static string caixaselecionado = "";
            public static string CaixaSelecionado
            {
                get { return caixaselecionado; }
                set { caixaselecionado = value; }
            }
            private static string semconta = "";
            public static string SemContaCadastrada
            {
                get { return semconta; }
                set { semconta = value; }
            }
            private static string numvenda = "";
            public static string Numvenda
            {
                get { return numvenda; }
                set { numvenda = value; }
            }
            private static string vendatot = "";
            public static string Totalvenda
            {
                get { return vendatot; }
                set { vendatot = value; }
            }
            private static string ferrouLicença = "";
            public static string ExpirouLicença
            {
                get { return ferrouLicença; }
                set { ferrouLicença = value; }
            }
            private static string balança = "";
            public static string Balança
            {
                get { return balança; }
                set { balança = value; }
            }
            private static string margemLocal = "";
            public static string MargemLocal
            {
                get { return margemLocal; }
                set { margemLocal = value; }
            }
            private static string corprincipal = "";
            public static string AtualizaPrincipal
            {
                get { return corprincipal; }
                set { corprincipal = value; }
            }
            private static string senhasa = "";
            public static string senhaSA
            {
                get { return senhasa; }
                set { senhasa = value; }
            }
            //carrega configuração do sistema
            private static string confFinanceiro = "";
            public static string ConfiguraçãoSistemaFinanceiroMargem
            {
                get { return confFinanceiro; }
                set { confFinanceiro = value; }
            }
            private static string confFinanceiroImpostos = "";
            public static string ConfiguraçãoSistemaFinanceiroImpostos
            {
                get { return confFinanceiroImpostos; }
                set { confFinanceiroImpostos = value; }
            }
            private static string confFinanceiroComissao = "";
            public static string ConfiguraçãoSistemaFinanceiroComissão
            {
                get { return confFinanceiroComissao; }
                set { confFinanceiroComissao = value; }
            }
            private static string confEstoque = "";
            public static string ConfiguraçãoSistemaEstoque
            {
                get { return confEstoque; }
                set { confEstoque = value; }
            }
            private static string confLogs = "";
            public static string ConfiguraçãoSistemaLOGs
            {
                get { return confLogs; }
                set { confLogs = value; }
            }
            private static string confCaixaTerminal = "";
            public static string ConfiguraçãoSistemaCaixaTerminalVendas
            {
                get { return confCaixaTerminal; }
                set { confCaixaTerminal = value; }
            }
            private static string confBD = "";
            public static string ConfiguraçãoSistemaBancoDados
            {
                get { return confBD; }
                set { confBD = value; }
            }
            private static string confBDIp = "";
            public static string ConfiguraçãoSistemaBancoDadosIp
            {
                get { return confBDIp; }
                set { confBDIp = value; }
            }
            private static string confBDPorta = "";
            public static string ConfiguraçãoSistemaBancoDadosPorta
            {
                get { return confBDPorta; }
                set { confBDPorta = value; }
            }
            
            private static string fracionado = "";
            public static string Fracionado
            {
                get { return fracionado; }
                set { fracionado = value; }
            }
            private static string frios = "";
            public static string Frios
            {
                get { return frios; }
                set { frios = value; }
            }
            private static string saldoReceber = "";
            public static string SaldoReceber
            {
                get { return saldoReceber; }
                set { saldoReceber = value; }
            }
            private static string calendario1 = "";
            public static string Calendario1
            {
                get { return calendario1; }
                set { calendario1 = value; }
            }
            private static string saldoContasReceber = "";
            public static string SaldoContasReceber
            {
                get { return saldoContasReceber; }
                set { saldoContasReceber = value; }
            }

            private static string idContasReceber = "";
            public static string IdContasReceber
            {
                get { return idContasReceber; }
                set { idContasReceber = value; }
            }
            private static string cadContasReceber = "";
            public static string CadastroContasReceber
            {
                get { return cadContasReceber; }
                set { cadContasReceber = value; }
            }
            private static string representante = "";
            public static string Representante
            {
                get { return representante; }
                set { representante = value; }
            }
            private static string representanteid = "";
            public static string RepresentanteId
            {
                get { return representanteid; }
                set { representanteid = value; }
            }
            private static string clienteCR = "";
            public static string ClienteContaReceber
            {
                get { return clienteCR; }
                set { clienteCR = value; }
            }
            private static string clienteCRId= "";
            public static string ClienteCRId 
            {
                get { return clienteCRId; }
                set { clienteCRId = value; }
            }
            private static string planodeconta = "";
            public static string PlanoDeConta
            {
                get { return planodeconta; }
                set { planodeconta = value; }
            }

            private static string calendario = "";
            public static string Calendario
            {
                get { return calendario; }
                set { calendario = value; }
            }
            private static string calendariodia = "";
            public static string CalendarioDia
            {
                get { return calendariodia; }
                set { calendariodia = value; }
            }
            private static string calendariomes = "";
            public static string CalendarioMes
            {
                get { return calendariomes; }
                set { calendariomes = value; }
            }
            private static string calendarioano  = "";
            public static string CalendarioAno
            {
                get { return calendarioano; }
                set { calendarioano = value; }
            }
            private static string cadparticipantes = "";
            public static string cadParticipantesEstado
            {
                get { return cadparticipantes; }
                set { cadparticipantes = value; }
            }

            private static string situação = "";
            public static string Situação
            {
                get { return situação; }
                set { situação = value; }
            }

            private static string nomePart = "";
            public static string AchaNomePart
            {
                get { return nomePart; }
                set { nomePart = value; }
            }

            private static string semaforopart = "";
            public static string semaforoPart
            {
                get { return semaforopart; }
                set { semaforopart = value; }
            }
            private static string semaforoint = "";
            public static string semaforoPartInt
            {
                get { return semaforoint; }
                set { semaforoint = value; }
            }

            private static DateTime dedoduro ;
            public static DateTime Hora
            {
                get { return dedoduro; }
                set { dedoduro = value; }
            }

            private static string margem = "";
            public static string Valor
            {
                get { return margem; }
                set { margem = value; }
            }
            private static string cont = "";
            public static string Contador
            {
                get { return cont; }
                set { cont = value; }
            }
            private static string recarrega = "";
            public static string Reload
            {
                get { return recarrega; }
                set { recarrega = value; }
            }

            
            
            
            private static string nome = "";
            public static string Operador
            {
                get { return nome; }
                set { nome = value; }
            }
            private static string senha = "";
            public static string SenhaCadastroUsuario
            {
                get { return senha; }
                set { senha = value; }
            }
            private static string id1 = "";
            public static string intCadUsr
            {
                get { return id1; }
                set { id1 = value; }
            }
            private static string senha_temp = "";
            public static string SenhaCadastroUsuarioTemp
            {
                get { return senha_temp; }
                set { senha_temp = value; }
            }
            private static string nome_temp = "";
            public static string OperadorTemp
            {
                get { return nome_temp; }
                set { nome_temp = value; }
            }
            private static string editaUsuarioSistema = "";
            public static string editaUsrSist
            {
                get { return editaUsuarioSistema; }
                set { editaUsuarioSistema = value; }
            }
            private static string idUsuario = "";
            public static string IdUsr
            {
                get { return idUsuario; }
                set { idUsuario = value; }
            }
            private static string administrador = "";
            public static string Administrador
            {
                get { return administrador; }
                set { administrador = value; }
            }
            private static string cadUsuario = "";
            public static string CadastroUsuarios
            {
                get { return cadUsuario; }
                set { cadUsuario = value; }
            }
            private static string cadProdutos = "";
            public static string CadastroProdutos
            {
                get { return cadProdutos; }
                set { cadProdutos = value; }
            }
            private static string cadParticipantes = "";
            public static string CadastroParticipantes
            {
                get { return cadParticipantes; }
                set { cadParticipantes = value; }
            }
            private static string caixa = "";
            public static string CaixaTerminalVendas
            {
                get { return caixa; }
                set { caixa = value; }
            }
            private static string LogSistema = "";
            public static string Logs
            {
                get { return LogSistema; }
                set { LogSistema = value; }
            }
            private static string fluxoCaixa = "";
            public static string FluxoDeCaixa
            {
                get { return fluxoCaixa; }
                set { fluxoCaixa = value; }
            }
            private static string contasPagar = "";
            public static string ContasPagar
            {
                get { return contasPagar; }
                set { contasPagar = value; }
            }
            private static string contasReceber = "";
            public static string ContasReceber
            {
                get { return contasReceber; }
                set { contasReceber = value; }
            }
            private static string config = "";
            public static string ConfiguraçãoSistema
            {
                get { return config; }
                set { config = value; }
            }






           
            
            private static string tipoPagamento = "";
            public static string Pagamento
            {
                get { return tipoPagamento; }
                set { tipoPagamento = value; }
            }

            private static string cancel = "";
            public static string Cancelar
            {
                get { return cancel; }
                set { cancel = value; }
            }

            private static string erro = "";
            public static string Erro
            {
                get { return erro; }
                set { erro = value; }
            }
        }
        
    }
}
