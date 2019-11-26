using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gerenciador_Comercial
{
    class FerramentasNaoEstaticas
    {
        public string RetornaDiasAtraso(string ano_vencimento,string mes_vencimento,string dia_vencimento,
            string ano_atual,string mes_atual,string dia_atual)
        {
            string diasAtraso = "";

            int ano = 0;
            int mes = 0;
            int dia = 0;
            int calculo = 0;

            if (mes_vencimento.Length < 2)
            {
                mes_vencimento = "0" + mes_vencimento;
            }
            if (dia_vencimento.Length < 2)
            {
                dia_vencimento = "0" + dia_vencimento;
            }
            if (mes_atual.Length < 2)
            {
                mes_atual = "0" + mes_atual;
            }
            if (dia_atual.Length < 2)
            {
                dia_atual = "0" + dia_atual;
            }

            if ( Convert.ToInt32(ano_vencimento) == Convert.ToInt32(ano_atual) )
            {
                ano = 0;
                if (Convert.ToInt32(mes_vencimento) < Convert.ToInt32(mes_atual))
                {
                    mes = Convert.ToInt32(Convert.ToInt32(mes_atual) - Convert.ToInt32(mes_vencimento) );
                }
                if (Convert.ToInt32(dia_vencimento) >= Convert.ToInt32(dia_atual))
                {
                    int temp = 30;
                    dia = Convert.ToInt32(Convert.ToInt32(dia_vencimento) - Convert.ToInt32(dia_atual));
                    dia = temp - dia;
                    if (mes >= 1 )
                    {
                        mes = mes - 1;
                    }
                }
                if (Convert.ToInt32(dia_vencimento) < Convert.ToInt32(dia_atual))
                {
                    dia = Convert.ToInt32(Convert.ToInt32(dia_atual) - Convert.ToInt32(dia_vencimento) );
                }
            }
            if (Convert.ToInt32(ano_vencimento) < Convert.ToInt32(ano_atual))
            {
                ano = Convert.ToInt32(Convert.ToInt32(ano_atual) - Convert.ToInt32(ano_vencimento));
                if (Convert.ToInt32(mes_vencimento) == Convert.ToInt32(mes_atual))
                {
                    mes = 0;
                }
                if (Convert.ToInt32(mes_vencimento) < Convert.ToInt32(mes_atual))
                {
                    mes = Convert.ToInt32(Convert.ToInt32(mes_atual) - Convert.ToInt32(mes_vencimento));
                }
                if (Convert.ToInt32(mes_vencimento) > Convert.ToInt32(mes_atual))
                {
                    int temp2 = 12;
                    mes = Convert.ToInt32( Convert.ToInt32(mes_vencimento) - Convert.ToInt32(mes_atual) );
                    mes = temp2 - mes;
                    if (ano >= 1)
                    {
                        ano = ano - 1;
                    }
                }
                if (Convert.ToInt32(dia_vencimento) <= Convert.ToInt32(dia_atual))
                {
                    dia = Convert.ToInt32(Convert.ToInt32(dia_atual) - Convert.ToInt32(dia_vencimento));
                }
                if (Convert.ToInt32(dia_vencimento) > Convert.ToInt32(dia_atual))
                {
                    int temp3 = 0;
                    dia = Convert.ToInt32(Convert.ToInt32(dia_vencimento) - Convert.ToInt32(dia_atual));
                    dia = temp3 - dia;
                    if (mes == 0)
                    {
                        ano = ano - 1;
                    }
                    if (mes >= 1)
                    {
                        mes = mes - 1;
                    }
                }

            }
            calculo = (ano * 365) + (mes * 30) + (dia);
            diasAtraso = Convert.ToString(calculo);


            return diasAtraso;
        }
    }
}
