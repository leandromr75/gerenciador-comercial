using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class ContasReceberNovo : Form
    {
        public ContasReceberNovo()
        {
            InitializeComponent();
            
        }
        string[] datas = new string[60];
        string[] datas_calc = new string[60];
        string[] desc = new string[60];
        string pararjuros = "";
        string diferença = "";
        string desconto23 = "";

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Form calendario = new Calendario();
            calendario.ShowDialog();

            textBox3.Text = Global.Margem.Calendario;
            Global.Margem.Calendario = "";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Global.Margem.Calendario1 = "anterior";
            Form calendario = new Calendario();
            calendario.ShowDialog();
            textBox6.Text = Global.Margem.Calendario;
            Global.Margem.Calendario = "";

            if (String.IsNullOrEmpty(textBox4.Text) == false)
            {
                string veccalc = Ferramentas.preparaDataCalculo(textBox4.Text);
            
          
                string ano = veccalc.Substring(0, 4);
                string mes = veccalc.Substring(4, 2);
                if (mes.Length < 2)
                {
                    mes = "0" + mes;
                }
                string dia = veccalc.Substring(6, 2);
                if (dia.Length < 2)
                {
                    dia = "0" + dia;
                }
                string data4 = ano + mes + dia;
           
                
                
                string desc = Ferramentas.preparaDataCalculo(textBox6.Text);
                string ano2 = desc.Substring(0, 4);
                string mes2 = desc.Substring(4, 2);
                if (mes2.Length < 2)
                {
                    mes2 = "0" + mes2;
                }
                string dia2 = desc.Substring(6, 2);
                if (dia2.Length < 2)
                {
                    dia2 = "0" + dia2;
                }
                string data3 = ano2 + mes2 + dia2;
                if (Convert.ToInt32(data3) < Convert.ToInt32(data4))
	            {

                    textBox7.ReadOnly = false;
                    textBox7.Focus();
	            }
                else
                {
                    textBox7.ReadOnly = true;
                }
            }
            Global.Margem.Calendario1 = "";
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form calendario = new Calendario();
            calendario.ShowDialog();

            textBox4.Text = Global.Margem.Calendario;
            textBox6.Text = Global.Margem.Calendario;
            string temp = textBox4.Text.Replace("/","");
            Global.Margem.CalendarioDia = temp.Substring(0,2);
            Global.Margem.CalendarioMes = temp.Substring(2,2);
            Global.Margem.CalendarioAno = temp.Substring(4,4);
            button3.Visible = true;

            Global.Margem.Calendario = "";
            
        }

        private void ContasReceberNovo_Load(object sender, EventArgs e)
        {
            
            if (Global.Margem.CadastroContasReceber == "salvar")
            {
                textBox3.Text = DateTime.Now.Date.ToShortDateString();
                comboBox1.Text = "Boleto Bancário";
                comboBox2.Text = "DM - Mercantil";
                textBox1.Text = Convert.ToString(DALCadastro.Numero_Titulo());
                textBox2.Text = "1";

            }
            if (Global.Margem.CadastroContasReceber == "baixar")
            {
                checkBox3.Visible = true;
                tabControl1.SelectedTab = tabPage2;
                
                tabControl2.SelectedTab = tabPage3;
                tabPage3.Focus();
                textBox23.Text = DateTime.Now.Date.ToShortDateString();
                string indet = Global.Margem.IdContasReceber;
                BaixarContaReceber(DALCadastro.Baixa_Contas_Receber(indet));

                if (Convert.ToDouble(textBox18.Text) > 0)
                {
                    checkBox3.Visible = false;
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int number = 0;
            bool result = Int32.TryParse(textBox2.Text, out number);
            if (result == true)
            {
                if (Convert.ToInt32(  textBox2.Text ) >= 60)
                {
                    MessageBox.Show("Sistema configurado para permitir no máximo 60 parcelas");
                    textBox2.Text = "60";
                    return;

                }
            }
            if (result == false)
            {
                MessageBox.Show("Insira somente valores numéricos");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty( textBox4.Text ) == false && String.IsNullOrEmpty(textBox2.Text) == false)
            {
                int number = 0;
                bool result = Int32.TryParse(textBox2.Text, out number);
                if (result)
                {
                    string dia = Global.Margem.CalendarioDia;
                    string mes = Global.Margem.CalendarioMes;
                    string ano = Global.Margem.CalendarioAno;
                    for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                    {
                        
                        if (Convert.ToInt32(dia) > 30)
                        {
                            dia = "30";
                        }
                        if (Convert.ToInt32(mes) == 2)
                        {
                            if (Convert.ToInt32(dia) >= 28)
                            {
                                string diatemp = "27";
                                datas[i] = diatemp + "/" + mes + "/" + ano;
                            }
                            else
                            {
                                datas[i] = dia + "/" + mes + "/" + ano;
                            }
                        }
                        
                        if (Convert.ToInt32(mes) != 2)
                        {
                            datas[i] = dia + "/" + mes + "/" + ano;
                        }
                        

                        if (Convert.ToInt32(mes) == 12)
                        {
                            mes = "1";
                            ano = Convert.ToString (Convert.ToInt32(ano) + 1);
                        }
                        else
                        {
                            mes = Convert.ToString(Convert.ToInt32(mes) + 1);
                            
                        }



                    }    
                }
                string saida = "";
                for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                {
                    
                    saida += "Parcela ==> " + (i + 1) + " : " + datas[i] + "\n";
                    
                }
                MessageBox.Show(saida);
            }
            else
            {
                MessageBox.Show("Data vencimento não informada");
            }
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text) == false)
            {
                decimal temp = Convert.ToDecimal(textBox5.Text);
                if (temp < 1)
                {
                    MessageBox.Show("Valor não informado");
                    textBox5.Text = "";
                    textBox5.Focus();
                    return;
                }    
            }
            
            string verifica = Ferramentas.É_campoVazio(textBox1.Text);
            if (verifica == "sim")
            {
                MessageBox.Show("Campo NR Título vazio");
                textBox1.Focus();
                return;
            }

            verifica = Ferramentas.É_numero(textBox2.Text);
            if (verifica == "não")
            {
                MessageBox.Show("Campo Parcelas em formato Incorreto");
                textBox2.Text = "";
                textBox2.Focus();
                return;
            }
            verifica = Ferramentas.É_campoVazio(textBox4.Text);
            if (verifica == "sim")
            {
                MessageBox.Show("Campo Data Vencimento vazio");
                textBox4.Focus();
                return;
            }
            verifica = Ferramentas.É_campoVazio(textBox5.Text);
            if (verifica == "sim")
            {
                MessageBox.Show("Campo valor do Título vazio");
                textBox5.Focus();
                return;
            }
            verifica = Ferramentas.É_campoVazio(textBox13.Text);
            if (verifica == "sim")
            {
                MessageBox.Show("Campo Cliente vazio");
                textBox13.Focus();
                return;
            }
            verifica = Ferramentas.É_campoVazio(textBox15.Text);
            if (verifica == "sim")
            {
                MessageBox.Show("Campo Plano de Conta vazio");
                textBox15.Focus();
                return;
            }
            string multa_juro = "";
            if (checkBox1.Checked == true)
            {
                multa_juro = "sim";
            }
            if (checkBox1.Checked == false)
            {
                multa_juro = "não";
            }
            string veccalc = Ferramentas.preparaDataCalculo(textBox4.Text);
            string dataCadcalc = Ferramentas.preparaDataCalculo(textBox3.Text);
          
            string ano = veccalc.Substring(0, 4);
            string mes = veccalc.Substring(4, 2);
            string dia = veccalc.Substring(6, 2);
            string data4 = ano + mes + dia;
           
            if (String.IsNullOrEmpty(textBox6.Text) == true)
            {
                MessageBox.Show("Campo Pagamento desconto vazio!");
                return;
                
            }
            if(String.IsNullOrEmpty(textBox6.Text) == false)
            {
                string desc = Ferramentas.preparaDataCalculo(textBox6.Text);
                string ano2 = desc.Substring(0, 4);
                string mes2 = desc.Substring(4, 2);
                string dia2 = desc.Substring(6, 2);
                string data3 = ano2 + mes2 + dia2;
                if (Convert.ToInt32(data3) > Convert.ToInt32(data4))
	            {
		            MessageBox.Show("Escolheu uma data de desconto maior que o vencimento");
                    textBox6.Text = "";
                    textBox6.Focus();
                    return;
	            }
                else
	            {
                    diferença = Convert.ToString( Convert.ToInt32( dia) - Convert.ToInt32(dia2));
	            }
                
                
            }
            

           
            
            
            string situ = "Em Aberto";
            

            
            for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
            {
                if (mes.Length < 2)
                {
                    mes = "0" + mes;
                }
                
                
                 if (Convert.ToInt32(dia) > 30)
                 {
                            dia = "30";
                 }
                 if (Convert.ToInt32(mes) == 2)
                 {
                     if (Convert.ToInt32(dia) >= 28)
                     {
                                string diatemp = "27";
                               
                                datas[i] = diatemp + "/"  + mes + "/" + ano;
                                
                                datas_calc[i] = ano +  mes + diatemp;
                                string temp4 = Convert.ToString(Convert.ToInt32( diatemp ) - Convert.ToInt32(diferença));
                                if (temp4.Length < 2)
                                {
                                    temp4 = "0" + temp4;
                                }
                                if (mes.Length < 2)
                                {
                                    mes = "0" + mes;
                                }
                                desc[i] = temp4 + "/" + mes + "/" + ano;
                                
                     }
                     else
                     {
                                datas[i] = dia + "/" + mes + "/" + ano;
                                
                                datas_calc[i] = ano +  mes + dia;
                                string temp4 = Convert.ToString(Convert.ToInt32(dia) - Convert.ToInt32(diferença));
                                if (temp4.Length < 2)
                                {
                                    temp4 = "0" + temp4;
                                }
                                if (mes.Length < 2)
                                {
                                    mes = "0" + mes;
                                }
                                desc[i] = temp4 + "/" + mes + "/" + ano;
                               
                     }
                  }
                        
                  if (Convert.ToInt32(mes) != 2)
                  {
                            if (Convert.ToInt32(mes) <= 9)
                            {
                                datas[i] = dia + "/" + mes + "/" + ano;
                                datas_calc[i] = ano + mes + dia;
                                string temp5 = Convert.ToString(Convert.ToInt32(dia) - Convert.ToInt32(diferença));
                                if (temp5.Length < 2)
                                {
                                    temp5 = "0" + temp5;
                                }
                                if (mes.Length < 2)
                                {
                                    mes = "0" + mes;
                                }
                                desc[i] = temp5 + "/" + mes + "/" + ano;


                            }
                            else
                            {
                                datas[i] = dia + "/" + mes + "/" + ano;
                                datas_calc[i] = ano + mes + dia;
                                string temp5 = Convert.ToString(Convert.ToInt32(dia) - Convert.ToInt32(diferença));
                                if (temp5.Length < 2)
                                {
                                    temp5 = "0" + temp5;
                                }
                                if (mes.Length < 2)
                                {
                                    mes = "0" + mes;
                                }
                                desc[i] = temp5 + "/" + mes + "/" + ano;

                            }
                  }
                        

                  if (Convert.ToInt32(mes) == 12)
                  {
                            mes = "1";
                            ano = Convert.ToString (Convert.ToInt32(ano) + 1);
                            
                   }
                   else
                   {
                            mes = Convert.ToString(Convert.ToInt32(mes) + 1);
                            
                   }
                  if (Global.Margem.CadastroContasReceber == "salvar")
                  {
                      DALCadastro.Cad_Conta_Receber(textBox1.Text, Convert.ToString(i + 1), textBox3.Text, dataCadcalc, comboBox1.Text, comboBox2.Text, datas[i], datas_calc[i], textBox5.Text,
                                 textBox5.Text,desc[i], textBox7.Text, multa_juro, textBox8.Text, textBox9.Text, textBox10.Text, textBox12.Text, textBox11.Text, textBox13.Text,
                                 textBox14.Text, textBox15.Text, richTextBox1.Text, situ);     
                  }
                    

                         
                                             
                       

            }

            string saida = "";
            for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
            {

                saida += "NR. Título : " + textBox1.Text + " / Parcela #  " + (i + 1) + "   ==> Vencimento em : " + datas[i] + "    [Cadastrado]\n";

            }
            MessageBox.Show(saida);
            button3.Visible = false;
            textBox7.ReadOnly = false;
            textBox5.Text = "0,00";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "0,00";
            textBox8.Text = "1";
            textBox9.Text = "1";
            textBox10.Text = "2";
            textBox14.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox15.Text = "";
            richTextBox1.Text = "";
            textBox1.Text = Convert.ToString(DALCadastro.Numero_Titulo());

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox7.Text);
            textBox7.Select(textBox7.TextLength, textBox7.TextLength);
            // pega a cultura atual usada na sua máquina - na minha pt-BR

            
            
            
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox7.Text) == false)
            {
                textBox7.Text = Ferramentas.FormataCasasDecimais(textBox7.Text,2);
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox8.Text) == false)
            {
                textBox8.Text = Ferramentas.FormataCasasDecimais(textBox8.Text, 2);
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox9.Text) == false)
            {
                textBox9.Text = Ferramentas.FormataCasasDecimais(textBox9.Text, 2);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Convert.ToInt32( textBox10.Text ) <= 30)
            {
                int temp = Convert.ToInt32(textBox10.Text) + 1;
                textBox10.Text = Convert.ToString(temp);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox10.Text) > 2)
            {
                int temp = Convert.ToInt32(textBox10.Text) - 1;
                textBox10.Text = Convert.ToString(temp);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox5.Text);
            textBox5.Select(textBox5.TextLength, textBox5.TextLength);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox5.Text) == false)
            {
                string temp = textBox5.Text;
                temp = temp.Replace(",","");
                temp = temp.Replace(".","");
                string inteiro = temp.Substring(0,temp.Length - 2);
                string fração = temp.Substring(temp.Length - 2, 2);
                textBox5.Text = inteiro + "," + fração;
                
               
            }
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form repre = new Representante();
            repre.ShowDialog();
            textBox11.Text = Global.Margem.RepresentanteId;
            textBox12.Text = Global.Margem.Representante;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form cli = new Clinte();
            cli.ShowDialog();
            textBox14.Text = Global.Margem.ClienteCRId;
            textBox13.Text = Global.Margem.ClienteContaReceber;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form plano = new PlanodeConta();
            this.Visible = false;
            
            plano.ShowDialog();
            textBox15.Text = Global.Margem.PlanoDeConta;
            this.Visible = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                textBox8.Text = "0";
                textBox9.Text = "0";
                textBox10.Text = "0";
            }
            if (checkBox1.Checked == true)
            {
                textBox8.Text = "1";
                textBox9.Text = "1";
                textBox10.Text = "2";
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(DALCadastro.Numero_Titulo());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string data = Ferramentas.preparaDataCalculo(textBox4.Text);
            MessageBox.Show(data);
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Global.Margem.Calendario1 = "anterior";
            Form calendario = new Calendario();
            calendario.ShowDialog();

            textBox23.Text = Global.Margem.Calendario;
            string indet = Global.Margem.IdContasReceber;
            BaixarContaReceber(DALCadastro.Baixa_Contas_Receber(indet));
            checkBox3.Visible = true;
            Global.Margem.Calendario = "";
        }
        public void BaixarContaReceber(DataTable baixa)
        {
            if (baixa.Rows.Count > 0)
            {
                desconto23 = baixa.Rows[0]["Desconto"].ToString();
                if (String.IsNullOrEmpty(Convert.ToString(baixa.Rows[0]["Desconto_Dia"].ToString())) == false)
                {
                    string desconto = baixa.Rows[0]["Desconto_Dia"].ToString();
                    desconto = desconto.Replace("/", "");
                    string diavenc = desconto.Substring(0, 2);
                    string mesvenc = desconto.Substring(2, 2);
                    string anovenc = desconto.Substring(4, 4);
                    string comp = anovenc + mesvenc + diavenc;
                    string data_atual = textBox23.Text;
                    data_atual = data_atual.Replace("/","");
                    string diaatual = data_atual.Substring(0, 2);
                    if (diaatual.Length < 2)
                    {
                        diaatual = "0" + diaatual;
                    }
                    string mesatual = data_atual.Substring(2,2);
                    if (mesatual.Length < 2)
                    {
                        mesatual = "0" + mesatual;
                    }
                    string anoatual = data_atual.Substring(4,4);
                    string datacomp = anoatual + mesatual + diaatual;
                    if (Convert.ToInt32(comp) <= Convert.ToInt32(datacomp))
                    {
                        textBox18.Text = baixa.Rows[0]["Desconto"].ToString();
                        
                    }
                    else
                    {
                        textBox18.Text = "0,00";
                        
                    }
                }
                textBox17.Text = Global.Margem.SaldoReceber;
                string dois = "";


                if (String.IsNullOrEmpty(Convert.ToString(baixa.Rows[0]["Multa_Juros"].ToString())) == false)
                {
                    if (baixa.Rows[0]["Multa_Juros"].ToString() == "sim")
                    {
                        int dias_atraso = Convert.ToInt32(baixa.Rows[0]["Dias"].ToString());
                        string venc2 = baixa.Rows[0]["Vencimento_Calculo"].ToString();
                        
                        string ano1 = venc2.Substring(0, 4);
                        int ano = Convert.ToInt32( ano1 );

                        string mes1 = venc2.Substring(4, 2);
                        int mes = Convert.ToInt32(mes1);
                        string dia1 = venc2.Substring(6, 2);
                        int dia = Convert.ToInt32(dia1);
                        int tem10 = dia + dias_atraso;
                        if (mes == 2)
                        {
                            if (tem10 > 28)
                            {
                                int temp = 28;
                                dia = dia + dias_atraso;
                                dia = dia - temp;
                                if (mes < 12)
                                {
                                    mes = mes + 1;
                                }
                                if (mes == 12)
                                {
                                    ano = ano + 1;
                                    mes = 1;
                                }
                            }
                                                     
                         
                            if (tem10 < 28)
                            {
                                dia = dia + dias_atraso;
                            }
                        }
                        if (mes != 02 || mes != 2)
                        {
                            if (tem10 > 30)
                            {
                                int temp = 30;
                                dia = dia + dias_atraso;
                                dia = dia - temp;
                                if (mes < 12)
                                {
                                    mes = mes + 1;
                                }
                                if (mes == 12)
                                {
                                    ano = ano + 1;
                                    mes = 1;
                                }

                            }
                            if (tem10 < 30)
                            {
                                dia = dia + dias_atraso;
                            }
                            
                        }
                        string d = Convert.ToString(dia);
                        string m = Convert.ToString(mes);
                        string a = Convert.ToString(ano);
                        if (m.Length < 2)
	                    {
		                    m = "0" + m;
	                    }
                        if (d.Length < 2)
	                    {
		                    d = "0" + d;
	                    }
                        dois = a + m + d;
                        MessageBox.Show(dois);

                        FerramentasNaoEstaticas ferramenta = new FerramentasNaoEstaticas();
                        string data_atual2 = textBox23.Text;
                        data_atual2 = data_atual2.Replace("/", "");
                        string diaatual2 = data_atual2.Substring(0, 2);
                        if (diaatual2.Length < 2)
                        {
                            diaatual2 = "0" + diaatual2;
                        }
                        string mesatual2 = data_atual2.Substring(2, 2);
                        if (mesatual2.Length < 2)
                        {
                            mesatual2 = "0" + mesatual2;
                        }
                        string anoatual2 = data_atual2.Substring(4, 4);
                        string atual = anoatual2 + mesatual2 + diaatual2;
                        


                        
                        MessageBox.Show(atual + "   " + dois);
                        if (Convert.ToInt32(atual) > Convert.ToInt32(dois))
                        {
                            int resposta = Convert.ToInt32(ferramenta.RetornaDiasAtraso(a, m, d, anoatual2, mesatual2, diaatual2));
                            string mora = baixa.Rows[0]["Mora"].ToString();
                            
                            string multa = baixa.Rows[0]["Multa"].ToString();
                            
                            string val = baixa.Rows[0]["valor"].ToString();
                            
                            decimal valor = Convert.ToDecimal(val);
                            
                            decimal moraresult = valor / 100; 
                            moraresult = moraresult * Convert.ToDecimal( mora);
                            MessageBox.Show(Convert.ToString(moraresult));
                            
                            MessageBox.Show(Convert.ToString(resposta));
                            moraresult = moraresult / 30;
                            moraresult = moraresult * resposta;
                            
                            
                            
                            decimal multaresult = valor / 100;
                            multaresult = multaresult * Convert.ToDecimal( multa);
                            MessageBox.Show(Convert.ToString(multaresult));
                            decimal valortotal = moraresult + multaresult;
                            valortotal = Math.Round(valortotal,2);
                            string total = Convert.ToString(valortotal);
                            
                            textBox16.Text = total ;
                            
                        }
                        

                        
                    }
                }
                textBox21.Text = Convert.ToString( Convert.ToDecimal(textBox17.Text) + (Convert.ToDecimal(textBox16.Text) - Convert.ToDecimal(textBox18.Text)));
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                if (Global.Margem.ContasReceber != "adm")
                {
                    MessageBox.Show("Somente administrador do Sistema pode realizar esta operação");
                    checkBox2.Checked = false;

                }
                else
                {
                    pararjuros = textBox16.Text;
                    textBox16.Text = "0,00";
                    textBox21.Text = Convert.ToString(Convert.ToDecimal(textBox17.Text) + (Convert.ToDecimal(textBox16.Text) - Convert.ToDecimal(textBox18.Text)));
                    

                }
            }
            if (checkBox2.Checked == false)
            {
                textBox16.Text = pararjuros;
                textBox21.Text = Convert.ToString(Convert.ToDecimal(textBox17.Text) + (Convert.ToDecimal(textBox16.Text) - Convert.ToDecimal(textBox18.Text)));
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                if (Global.Margem.ContasReceber == "adm")
                {
                    textBox18.Text = desconto23;
                    textBox21.Text = Convert.ToString(Convert.ToDecimal(textBox17.Text) + (Convert.ToDecimal(textBox16.Text) - Convert.ToDecimal(textBox18.Text)));
                }
                else
                {
                    MessageBox.Show("Somente administrador do Sistema pode realizar esta operação");
                    checkBox3.Checked = false;
                    textBox18.Text = "0,00";
                    textBox21.Text = Convert.ToString(Convert.ToDecimal(textBox17.Text) + (Convert.ToDecimal(textBox16.Text) - Convert.ToDecimal(textBox18.Text)));
                }
                 
            }
            if (checkBox3.Checked == false)
            {
                textBox18.Text = "0,00";
                textBox21.Text = Convert.ToString(Convert.ToDecimal(textBox17.Text) + (Convert.ToDecimal(textBox16.Text) - Convert.ToDecimal(textBox18.Text)));
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32( textBox9.Text );
            if (temp <= 100 )
            {
                temp = temp + 1;
                textBox9.Text = Convert.ToString(temp);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(textBox9.Text);
            if (temp >= 1)
            {
                temp = temp - 1;
                textBox9.Text = Convert.ToString(temp);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(textBox8.Text);
            if (temp <= 100)
            {
                temp = temp + 1;
                textBox8.Text = Convert.ToString(temp);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(textBox8.Text);
            if (temp >= 1)
            {
                temp = temp - 1;
                textBox8.Text = Convert.ToString(temp);
            }
        }
    }
}
