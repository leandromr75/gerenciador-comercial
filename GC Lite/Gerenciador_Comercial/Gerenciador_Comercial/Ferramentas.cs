using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    class Ferramentas
    {
        public static void Dedo_Duro()
        {
            DateTime data1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            //ultimo acesso
            string res1 = Convert.ToString(DALCadastro.ValidaLicença("Res1"));
            int resultRes1 = Convert.ToInt32(res1) / 67;

            string res2 = Convert.ToString(DALCadastro.ValidaLicença("Res2"));
            int resultRes2 = Convert.ToInt32(res2) / 115;

            string res3 = Convert.ToString(DALCadastro.ValidaLicença("Res3"));
            int resultRes3 = Convert.ToInt32(res3) / 57;

            string res4 = Convert.ToString(DALCadastro.ValidaLicença("Res4"));
            int resultRes4 = Convert.ToInt32(res4) / 33;

            string res5 = Convert.ToString(DALCadastro.ValidaLicença("Res5"));
            int resultRes5 = Convert.ToInt32(res5) / 33;

            string res6 = Convert.ToString(DALCadastro.ValidaLicença("Res6"));
            int resultRes6 = Convert.ToInt32(res6) / 33;

            

           

            DateTime data2 = new DateTime(resultRes1, resultRes2, resultRes3, resultRes4, resultRes5, resultRes6);

            int result = DateTime.Compare(data1, data2);
            if (result < 0)
            {
                MessageBox.Show("Data " + Convert.ToString(data1) + "  é anterior à última atualização de hora do sistema: " + Convert.ToString(data2) +
                    "\n\nVerifique o relógio do computador. O sistema será fechado para evitar danos ao banco de dados.   " );
                Global.Margem.ExpirouLicença = "sim";
                

            }
            else
            {

                DALCadastro.MapearResolução(Convert.ToString(DateTime.Now.Year * 67), Convert.ToString(DateTime.Now.Month * 115), Convert.ToString(DateTime.Now.Day * 57),
                    Convert.ToString(DateTime.Now.Hour * 33), Convert.ToString(DateTime.Now.Minute * 33), Convert.ToString(DateTime.Now.Second * 33)); 
                                
            }
           
        }
        public static void CriaLog(string modulo, string descricao)
        {
            string mod = modulo;
            string oper = Global.Margem.Operador;
            string dia = DateTime.Now.Day.ToString();
            if (dia.Length < 2)
            {
                dia = "0" + dia;
            }
            string mes = DateTime.Now.Month.ToString();
            if (mes.Length < 2)
            {
                mes = "0" + mes;
            }
            string ano = DateTime.Now.Year.ToString();
            int dat = Convert.ToInt32( ano + mes + dia );
            string dataatual = dia + "/" + mes + "/" + ano + " [" + DateTime.Now.Hour.ToString() + 
                ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString() + "]";
            string descAction = descricao;
            
            DALCadastro.InsereLog(dataatual,dat,oper,mod,descAction);

        }
        public static string Retira_Meta(string campo)
        {
            string campoLimpo = campo;
            campoLimpo = campoLimpo.Replace("@","");
            campoLimpo = campoLimpo.Replace("#","");
            campoLimpo = campoLimpo.Replace("$", "");
            campoLimpo = campoLimpo.Replace("%", "");
            campoLimpo = campoLimpo.Replace("&", "");
            campoLimpo = campoLimpo.Replace("*", "");
            campoLimpo = campoLimpo.Replace("+", "");
            campoLimpo = campoLimpo.Replace("-", "");
            campoLimpo = campoLimpo.Replace("/", "");
            campoLimpo = campoLimpo.Replace("\\", "");
            campoLimpo = campoLimpo.Replace("^", "");
            campoLimpo = campoLimpo.Replace("?", "");
            campoLimpo = campoLimpo.Replace("{", "");
            campoLimpo = campoLimpo.Replace("}", "");
            campoLimpo = campoLimpo.Replace("=", "");
            campoLimpo = campoLimpo.Replace("!", "");
            campoLimpo = campoLimpo.Replace("|", "");
            campoLimpo = campoLimpo.Replace(".", "");
           

            
            return campoLimpo;
        }
        public static string Retira_Meta_PreparaDecimal(string campo1)
        {
            string campoLimpo1 = campo1;
            campoLimpo1 = campoLimpo1.Replace("@", "");
            campoLimpo1 = campoLimpo1.Replace("#", "");
            campoLimpo1 = campoLimpo1.Replace("$", "");
            campoLimpo1 = campoLimpo1.Replace("%", "");
            campoLimpo1 = campoLimpo1.Replace("&", "");
            campoLimpo1 = campoLimpo1.Replace("*", "");
            campoLimpo1 = campoLimpo1.Replace("+", "");
            campoLimpo1 = campoLimpo1.Replace("-", "");
            campoLimpo1 = campoLimpo1.Replace("/", "");
            campoLimpo1 = campoLimpo1.Replace("\\", "");
            campoLimpo1 = campoLimpo1.Replace("^", "");
            campoLimpo1 = campoLimpo1.Replace("?", "");
            campoLimpo1 = campoLimpo1.Replace("{", "");
            campoLimpo1 = campoLimpo1.Replace("}", "");
            campoLimpo1 = campoLimpo1.Replace("=", "");
            campoLimpo1 = campoLimpo1.Replace("!", "");
            campoLimpo1 = campoLimpo1.Replace("|", "");
            campoLimpo1 = campoLimpo1.Replace(".", ",");
            campoLimpo1 = campoLimpo1.Replace("a", "");
            campoLimpo1 = campoLimpo1.Replace("b", "");
            campoLimpo1 = campoLimpo1.Replace("c", "");
            campoLimpo1 = campoLimpo1.Replace("d", "");
            campoLimpo1 = campoLimpo1.Replace("e", "");
            campoLimpo1 = campoLimpo1.Replace("f", "");
            campoLimpo1 = campoLimpo1.Replace("g", "");
            campoLimpo1 = campoLimpo1.Replace("h", "");
            campoLimpo1 = campoLimpo1.Replace("i", "");
            campoLimpo1 = campoLimpo1.Replace("j", "");
            campoLimpo1 = campoLimpo1.Replace("k", "");
            campoLimpo1 = campoLimpo1.Replace("l", "");
            campoLimpo1 = campoLimpo1.Replace("m", "");
            campoLimpo1 = campoLimpo1.Replace("n", "");
            campoLimpo1 = campoLimpo1.Replace("o", "");
            campoLimpo1 = campoLimpo1.Replace("p", "");
            campoLimpo1 = campoLimpo1.Replace("q", "");
            campoLimpo1 = campoLimpo1.Replace("r", "");
            campoLimpo1 = campoLimpo1.Replace("s", "");
            campoLimpo1 = campoLimpo1.Replace("t", "");
            campoLimpo1 = campoLimpo1.Replace("u", "");
            campoLimpo1 = campoLimpo1.Replace("v", "");
            campoLimpo1 = campoLimpo1.Replace("x", "");
            campoLimpo1 = campoLimpo1.Replace("y", "");
            campoLimpo1 = campoLimpo1.Replace("z", "");
            campoLimpo1 = campoLimpo1.Replace("w", "");
            
           return campoLimpo1;
        }
        public static string FormataCasasDecimais(string valorNaoFormatado,int casasDecimais)
        {
            string campoLimpo2 = "";
            NumberFormatInfo culturaAtual = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();

            //diz quantos digitos deverá ter depois da vírgula

            culturaAtual.NumberDecimalDigits = casasDecimais;
            decimal din = Convert.ToDecimal(valorNaoFormatado);

            //formata o decimal

            campoLimpo2 = din.ToString("N", culturaAtual);
            return campoLimpo2;
        }
        public static bool IsCnpj(string cnpj)
		{
			int[] multiplicador1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
			int[] multiplicador2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			//cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
			   return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for(int i=0; i<12; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if ( resto < 2)
			   resto = 0;
			else
			   resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
			   soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
			    resto = 0;
			else
			   resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            //cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static string É_numero(string numero)
        {
            string retorno = "";

            Int64 num = 0;
            
            bool result = Int64.TryParse(numero, out num);
            if (result == true)
            {
                retorno = "sim";
            }
            if (result == false)
            {
                retorno = "não";
            }
            return retorno;
        }

        public static string É_decimal(string numDecimal)
        {
            string retorno = "";

            decimal num = 0;

            bool result = Decimal.TryParse(numDecimal, out num);
            if (result == true)
            {
                retorno = "sim";
            }
            if (result == false)
            {
                retorno = "não";
            }
            return retorno;
        }
        public static string É_Float(string numFloat)
        {
            string retorno = "";

            float num = 0;

            bool result = float.TryParse(numFloat, out num);
            if (result == true)
            {
                retorno = "sim";
            }
            if (result == false)
            {
                retorno = "não";
            }
            return retorno;
        }
	    public static string É_campoVazio(string campo)
        {
            string retorno = "";

            if (String.IsNullOrEmpty(campo) == true)
            {
                retorno = "sim";
            }
            if (String.IsNullOrEmpty(campo) == false)
            {
                retorno = "não";
            }

            
            return retorno;
        }

        public static string preparaDataCalculo(string data)
        {
            string retorno = "";
            
            string ano = data.Substring(6,4);
            string mes = data.Substring(3,2);
            string dia = data.Substring(0,2);
            retorno = ano + mes + dia;
            return retorno;
        }
    }
}
