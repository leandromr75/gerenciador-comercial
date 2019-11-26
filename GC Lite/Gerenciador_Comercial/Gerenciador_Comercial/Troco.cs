using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class Troco : Form
    {
        public Troco()
        {
            InitializeComponent();
        }
        
        private void Troco_Load(object sender, EventArgs e)
        {
            Global.Margem.Troco = "não";
            
            Global.Margem.TemTroco = "";
            textBox1.Text = Global.Margem.TrocoVenda;
            textBox2.Focus();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox7.Checked == false && checkBox8.Checked == false)
            {
                Global.SAT_Param.Forneceu_CNPJ_ou_CPF = "não";
            }
            string vai = "sim";
            if (checkBox7.Checked == true || checkBox8.Checked == true)
            {
                vai = "não";
            }
            
            if (String.IsNullOrEmpty(textBox9.Text) == false || vai == "não")
            {
                
                if (checkBox7.Checked == true)
                {
                    string temp = Ferramentas.Retira_Meta(textBox9.Text);
                    bool teste = Ferramentas.IsCpf(temp);
                    if (teste == false)
                    {
                        MessageBox.Show("CPF em formato incorreto");
                        textBox9.Text = "";
                        textBox9.Focus();
                        return;

                    }
                    if (teste == true)
                    {
                        Global.SAT_Param.Forneceu_CNPJ_ou_CPF = "CPF";
                        string temp2 = Ferramentas.Retira_Meta(textBox9.Text);
                        Global.SAT_Param.CPF_Destinatario = temp2;
                        Global.SAT_Param.Nome_Destinatario = textBox10.Text;
                    }
                }
                if (checkBox8.Checked == true)
                {
                    string temp = Ferramentas.Retira_Meta(textBox9.Text);
                    bool teste = Ferramentas.IsCnpj(temp);
                    if (teste == false)
                    {
                        MessageBox.Show("CNPJ em formato incorreto");
                        textBox9.Text = "";
                        textBox9.Focus();
                        return;

                    }
                    if (teste == true)
                    {
                        Global.SAT_Param.Forneceu_CNPJ_ou_CPF = "CNPJ";
                        string temp3 = Ferramentas.Retira_Meta(textBox9.Text);
                        Global.SAT_Param.CNPJ_Destinatario = temp3;
                        Global.SAT_Param.Nome_Destinatario = textBox10.Text;
                    }
                }
            }
            
            
           
            bool um = false;
            bool dois = false;
            bool tres = false;
            bool quatro = false;

            Global.SAT_Param.Formas_Pagamento_cheque = "";
            Global.SAT_Param.Formas_Pagamento_CC = "";
            Global.SAT_Param.Formas_Pagamento_CD = "";
            Global.SAT_Param.Formas_Pagamento_credito_loja = "";
            Global.SAT_Param.Formas_Pagamento_dinheiro = "";    
           
            if (checkBox1.Checked == true || checkBox2.Checked == true || checkBox3.Checked == true || checkBox4.Checked == true )
            {
                
                //bool cinco = false;

                int conta = 0;
                decimal soma = 0;
                if (checkBox1.Checked == true)
                {
                    decimal valor = 0;
                    textBox4.Text = textBox4.Text.Replace(".",",");
                    if (Decimal.TryParse(textBox4.Text, out valor) == true)
                    {
                        if (valor > 0)
                        {
                            conta++;
                            soma += Convert.ToDecimal(textBox4.Text);
                            um = true;
                        }
                        if (valor <= 0)
                        {
                            MessageBox.Show("Valor informado precisa ser maior que zero");
                            textBox4.Text = "";
                            textBox4.Focus();
                            conta = 0;
                            um = false;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valor incorreto");
                        textBox4.Text = "";
                        textBox4.Focus();
                        conta = 0;
                        um = false;
                        return;
                    }
                    
                }
                if (checkBox2.Checked == true)
                {
                    decimal valor = 0;
                    textBox5.Text = textBox5.Text.Replace(".", ",");
                    if (Decimal.TryParse(textBox5.Text, out valor) == true)
                    {
                        if (valor > 0)
                        {
                            conta++;
                            soma += Convert.ToDecimal(textBox5.Text);
                            dois = true;
                        }
                        if (valor <= 0)
                        {
                            MessageBox.Show("Valor informado precisa ser maior que zero");
                            textBox5.Text = "";
                            textBox5.Focus();
                            conta = 0;
                            dois = false;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valor incorreto");
                        textBox5.Text = "";
                        textBox5.Focus();
                        conta = 0;
                        dois = false;
                        return;
                    }
                }
                if (checkBox3.Checked == true)
                {
                    decimal valor = 0;
                    textBox6.Text = textBox6.Text.Replace(".", ",");
                    if (Decimal.TryParse(textBox6.Text, out valor) == true)
                    {
                        if (valor > 0)
                        {
                            conta++;
                            soma += Convert.ToDecimal(textBox6.Text);
                            tres = true;
                        }
                        if (valor <= 0)
                        {
                            MessageBox.Show("Valor informado precisa ser maior que zero");
                            textBox6.Text = "";
                            textBox6.Focus();
                            conta = 0;
                            tres = false;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valor incorreto");
                        textBox6.Text = "";
                        textBox6.Focus();
                        conta = 0;
                        tres = false;
                        return;
                    }
                }
                if (checkBox4.Checked == true)
                {
                    decimal valor = 0;
                    textBox7.Text = textBox7.Text.Replace(".", ",");
                    if (Decimal.TryParse(textBox7.Text, out valor) == true)
                    {
                        if (valor > 0)
                        {
                            conta++;
                            soma += Convert.ToDecimal(textBox7.Text);
                            quatro = true;
                        }
                        if (valor <= 0)
                        {
                            MessageBox.Show("Valor informado precisa ser maior que zero");
                            textBox7.Text = "";
                            textBox7.Focus();
                            conta = 0;
                            quatro = false;
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Valor incorreto");
                        textBox7.Text = "";
                        textBox7.Focus();
                        conta = 0;
                        quatro = false;
                        return;
                    }
                }
                
                if (conta > 1)
                {
                    string data = System.DateTime.Now.ToShortDateString();
                    string datacalc = "";
                    string ano = DateTime.Now.Year.ToString();
                    string mes = DateTime.Now.Month.ToString();
                    if (mes.Length < 2)
                    {
                        mes = "0" + mes;
                    }
                    string dia = DateTime.Now.Day.ToString();
                    if (dia.Length < 2)
                    {
                        dia = "0" + dia;
                    }
                    datacalc = ano + mes + dia;  
                    if (Convert.ToDecimal(textBox1.Text) > soma)
                    {
                        string um1 = "";
                        string dois2 = "";
                        string tres3 = "";
                        string quatro4 = "";
                        if (um == true)
                        {
                            um1 = textBox4.Text;
                        }
                        if (um == false)
                        {
                            um1 = "0,00";
                        }
                        if (tres == true)
                        {
                            tres3 = textBox6.Text;
                        }
                        if (tres == false)
                        {
                            tres3 = "0,00";
                        }
                        if (dois == true)
                        {
                            dois2 = textBox5.Text;
                        }
                        if (dois == false)
                        {
                            dois2 = "0,00";
                        }
                        if (quatro == true)
                        {
                            quatro4 = textBox7.Text;
                        }
                        if (quatro == false)
                        {
                            quatro4 = "0,00";
                        }
                        string message = "Valor informado menor que o total da venda [" + Global.Margem.Numvenda + "] -> R$ " + textBox1.Text +
                           "\n\n" + "Dinheiro -> R$ " + um1 + "\n" + "Cartão de Crédito -> R$ " + tres3 + "\n" + "Cartão de Débito -> R$ " + dois2 +
                           "\n" + "Cheque -> R$ " + quatro4 + "\n\nDeseja abrir Fiado para saldo devedor restante?\n" +
                           "-> R$ " + Convert.ToString( Convert.ToDecimal(textBox1.Text) - soma );
                        string caption = "Abrir Fiado";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Mostra a MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            Form clif = new FiadoClientes();
                            clif.ShowDialog();
                            //pega valor global.margem.clientefiadotemp
                           
                            decimal resto = Convert.ToDecimal(textBox1.Text);

                            DALCadastro.tipoVendaFiado(Global.Margem.ClienteFiadoTemp, Global.Margem.Numvenda);
                            DALCadastro.FiadoPAGParcial(Global.Margem.Numvenda);

                               
                               
                            if (um == true )
                            {
                                
                                DALCadastro.ParcialInsere(Global.Margem.ClienteFiadoTemp, textBox4.Text, "dinheiro", Global.Margem.CaixaSelecionado);
                                string parcial = Convert.ToString(resto - Convert.ToDecimal(textBox4.Text));
                               // DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado, textBox1.Text, parcial, DateTime.Now.ToLongDateString(), Global.Margem.Numvenda);
                                DALCadastro.InsereAUXVendas("Pagamento Parcial de Fiado", Global.Margem.Numvenda, Global.Margem.ClienteFiadoTemp, "dinheiro",
                                    "Pagamento Fiado Parcial", textBox4.Text, data, Convert.ToInt32(datacalc));
                                resto = Convert.ToDecimal(parcial);

                                //------------------SAT
                                Global.SAT_Param.Formas_Pagamento_dinheiro = "sim";
                                Global.SAT_Param.Formas_Pagamento_dinheiro_valor = textBox4.Text.Replace(",",".");

                                Global.Margem.PagParcialFiadoD = "Dinheiro R$ " + textBox4.Text ;

                            }
                            if (tres == true )
                            {
                                DALCadastro.ParcialInsere(Global.Margem.ClienteFiadoTemp, textBox6.Text, "cartão de crédito", Global.Margem.CaixaSelecionado);
                                string parcial = Convert.ToString(resto - Convert.ToDecimal(textBox6.Text));
                                //DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado, textBox1.Text, parcial, DateTime.Now.ToLongDateString(), Global.Margem.Numvenda);
                                DALCadastro.InsereAUXVendas("Pagamento Parcial de Fiado", Global.Margem.Numvenda, Global.Margem.ClienteFiadoTemp, "cartão de crédito",
                                    "Pagamento Fiado Parcial", textBox6.Text, data, Convert.ToInt32(datacalc));
                                resto = Convert.ToDecimal(parcial);

                                //------------------SAT
                                Global.SAT_Param.Formas_Pagamento_CC = "sim";
                                Global.SAT_Param.Formas_Pagamento_CC_valor = textBox6.Text.Replace(",", ".");
                                Global.SAT_Param.Formas_Pagamento_CC_Codigo = "001";

                                Global.Margem.PagParcialFiadoCC = "Cartão de Credito R$ " + textBox6.Text ;
                               
                            }
                            if (dois == true )
                            {
                                DALCadastro.ParcialInsere(Global.Margem.ClienteFiadoTemp, textBox5.Text, "cartão de débito", Global.Margem.CaixaSelecionado);
                                string parcial = Convert.ToString(resto - Convert.ToDecimal(textBox5.Text));
                               // DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado, textBox1.Text, parcial, DateTime.Now.ToLongDateString(), Global.Margem.Numvenda);
                                DALCadastro.InsereAUXVendas("Pagamento Parcial de Fiado", Global.Margem.Numvenda, Global.Margem.ClienteFiadoTemp, "cartão de débito",
                                    "Pagamento Fiado Parcial", textBox5.Text, data, Convert.ToInt32(datacalc));
                                resto = Convert.ToDecimal(parcial);

                                //------------------SAT
                                Global.SAT_Param.Formas_Pagamento_CD = "sim";
                                Global.SAT_Param.Formas_Pagamento_CD_valor = textBox5.Text.Replace(",", ".");
                                Global.SAT_Param.Formas_Pagamento_CD_codigo = "001";

                                Global.Margem.PagParcialFiadoCD = "Cartão de Débito R$ " + textBox5.Text;
                               
                            }
                            if (quatro == true )
                            {
                                DALCadastro.ParcialInsere(Global.Margem.ClienteFiadoTemp, textBox7.Text, "cheque", Global.Margem.CaixaSelecionado);
                                string parcial = Convert.ToString(resto - Convert.ToDecimal(textBox7.Text));
                                //DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado, textBox1.Text, parcial, DateTime.Now.ToLongDateString(), Global.Margem.Numvenda);
                                DALCadastro.InsereAUXVendas("Pagamento Parcial de Fiado", Global.Margem.Numvenda, Global.Margem.ClienteFiadoTemp, "cheque",
                                    "Pagamento Fiado Parcial", textBox7.Text, data, Convert.ToInt32(datacalc));
                                resto = Convert.ToDecimal(parcial);

                                //------------------SAT
                                Global.SAT_Param.Formas_Pagamento_cheque = "sim";
                                Global.SAT_Param.Formas_Pagamento_cheque_valor = textBox7.Text.Replace(",", ".");
                                

                                Global.Margem.PagParcialFiadoC = "Cheque R$ " + textBox7.Text ;
                            }

                           
                            DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiadoTemp, textBox1.Text, Convert.ToString(Convert.ToDecimal(textBox1.Text) - resto), DateTime.Now.ToLongDateString(), Global.Margem.Numvenda + "|");
                            MessageBox.Show("Saldo devedor restante de R$ " + Convert.ToString(resto) + " .\n\nCliente : " + Global.Margem.ClienteFiadoTemp);
                            Global.Margem.PagParcialFiadoSaldoDevedor = "Saldo Devedor R$ " + Convert.ToString(resto);
                            Global.Margem.PagParcialFiado = "sim";

                            //------------------SAT
                            Global.SAT_Param.Formas_Pagamento_credito_loja = "sim";
                            Global.SAT_Param.Formas_Pagamento_credito_loja_valor = Convert.ToString(resto).Replace(",", ".");
                            Global.SAT_Param.Formas_Pagamento_Qtde = "sim";
                            Global.Margem.CancelaSAT = "não";
                            Form sat = new TelaSAT();
                            sat.ShowDialog();

                            if (Global.Margem.CancelaSAT == "não")
                            {
                                EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "sim");    
                            }
                            

                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);

                            Global.Margem.Pagamento = "Pagamento a prazo";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : a prazo. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }
                            Global.Margem.Troco = "misto";
                            this.Close();
                        }
                        else
                        {
                            return;
                        }
                                               
                        
                    }
                    if (Convert.ToDecimal(textBox1.Text) < soma)
                    {
                        MessageBox.Show("Valor das formas de pagamento é maior que o total da venda");
                        return;                        
                    }
                    if (Convert.ToDecimal(textBox1.Text) == soma)
                    {
                        string um1 = "";
                        string dois2 = "";
                        string tres3 = "";
                        string quatro4 = "";
                        if (um == true)
                        {                            
                            um1 = textBox4.Text;   
                        }
                        if (um == false)
                        {
                            um1 = "0,00";
                        }
                        if (tres == true)
                        {
                            tres3 = textBox6.Text;
                        }
                        if (tres == false)
                        {
                            tres3 = "0,00";
                        }
                        if (dois == true)
                        {
                            dois2 = textBox5.Text;
                        }
                        if (dois == false)
                        {
                            dois2 = "0,00";
                        }
                        if (quatro == true)
                        {
                            quatro4 = textBox7.Text;
                        }
                        if (quatro == false)
                        {
                            quatro4 = "0,00";
                        }
                        string message = "Deseja concluir a venda [" + Global.Margem.Numvenda + "] com pagamento misto?\n\n" + "Dinheiro -> R$ " + um1  + "\n" +
                            "Cartão de Crédito -> R$ " + tres3 + "\n" + "Cartão de Débito -> R$ " + dois2 + "\n" + "Cheque -> R$ " + quatro4 ;
                        string caption = "Venda Mista";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Mostra a MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            if (um == true)
                            {
                                DALCadastro.InsereAUXVendas("Pagamento Misto Venda", Global.Margem.Numvenda, "Consumidor", "dinheiro",
                                             "Pagamento Misto", textBox4.Text, data, Convert.ToInt32(datacalc));


                                //-----------------SAT
                                Global.SAT_Param.Formas_Pagamento_dinheiro = "sim";
                                Global.SAT_Param.Formas_Pagamento_dinheiro_valor = textBox4.Text.Replace(",", ".");

                            }
                            if (tres == true)
                            {
                                DALCadastro.InsereAUXVendas("Pagamento Misto Venda", Global.Margem.Numvenda, "Consumidor", "cartão de crédito",
                                             "Pagamento Misto", textBox6.Text, data, Convert.ToInt32(datacalc));

                                //------------------SAT
                                Global.SAT_Param.Formas_Pagamento_CC = "sim";
                                Global.SAT_Param.Formas_Pagamento_CC_valor = textBox6.Text.Replace(",", ".");
                                Global.SAT_Param.Formas_Pagamento_CC_Codigo = "001";

                            }
                            if (dois == true)
                            {
                                DALCadastro.InsereAUXVendas("Pagamento Misto Venda", Global.Margem.Numvenda, "Consumidor", "cartão de débito",
                                             "Pagamento Misto", textBox5.Text, data, Convert.ToInt32(datacalc));

                                //------------------SAT
                                Global.SAT_Param.Formas_Pagamento_CD = "sim";
                                Global.SAT_Param.Formas_Pagamento_CD_valor = textBox5.Text.Replace(",", ".");
                                Global.SAT_Param.Formas_Pagamento_CD_codigo = "001";

                            }
                            if (quatro == true)
                            {
                                DALCadastro.InsereAUXVendas("Pagamento Misto Venda", Global.Margem.Numvenda, "Consumidor", "cheque",
                                             "Pagamento Misto", textBox7.Text, data, Convert.ToInt32(datacalc));

                                //------------------SAT
                                Global.SAT_Param.Formas_Pagamento_cheque = "sim";
                                Global.SAT_Param.Formas_Pagamento_cheque_valor = textBox7.Text.Replace(",", ".");

                            }

                            DALCadastro.tipoVenda("Pagamento_Misto", Global.Margem.Numvenda);
                           
                            //------------------SAT
                            Global.SAT_Param.Formas_Pagamento_credito_loja = "não";
                            Global.SAT_Param.Formas_Pagamento_Qtde = "sim";
                            Global.Margem.CancelaSAT = "não";
                            Form sat = new TelaSAT();
                            sat.ShowDialog();

                            if (Global.Margem.CancelaSAT == "não")
                            {
                                EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "sim");
                            }

                            DALCadastro.InsereImpressao(Global.Margem.Numvenda);
                            Global.Margem.Pagamento = "Pagamento Misto";
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : Misto. Número venda : " + Global.Margem.Numvenda +
                                    " Total : " + Global.Margem.Totalvenda);
                            }

                            Global.Margem.Troco = "misto";
                            this.Close();  
                        }
                        if (result == DialogResult.No)
                        {
                            return;
                        }
                        
                        
                    }
                }
                if (conta <= 1 && Convert.ToDecimal(textBox1.Text) == soma)
                {
                    MessageBox.Show("Informado apenas uma(1) forma de pagamento.");
                    if (checkBox1.Checked == true)
                    {
                        textBox4.Text = "";
                        textBox4.Focus();
                    }
                    if (checkBox2.Checked == true)
                    {
                        textBox5.Text = "";
                        textBox5.Focus();
                    }
                    if (checkBox3.Checked == true)
                    {
                        textBox6.Text = "";
                        textBox6.Focus();
                    }
                    if (checkBox4.Checked == true)
                    {
                        textBox7.Text = "";
                        textBox7.Focus();
                    }
                    return;
                }
                if (conta <= 1 && Convert.ToDecimal(textBox1.Text) > soma)
                {
                    string data = System.DateTime.Now.ToShortDateString();
                    string datacalc = "";
                    string ano = DateTime.Now.Year.ToString();
                    string mes = DateTime.Now.Month.ToString();
                    if (mes.Length < 2)
                    {
                        mes = "0" + mes;
                    }
                    string dia = DateTime.Now.Day.ToString();
                    if (dia.Length < 2)
                    {
                        dia = "0" + dia;
                    }
                    datacalc = ano + mes + dia; 
                    string message = "Informado apenas uma forma de pagamento.\n\nDeseja abrir Fiado para saldo devedor restante?" + " -> R$ " +
                        Convert.ToString( Convert.ToDecimal(textBox1.Text) - soma);
                    string caption = "Abrir Fiado";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Mostra a MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        Form clif = new FiadoClientes();
                        clif.ShowDialog();
                        //pega valor global.margem.clientefiadotemp
                        DALCadastro.tipoVendaFiado(Global.Margem.ClienteFiadoTemp, Global.Margem.Numvenda);
                        DALCadastro.FiadoPAGParcial(Global.Margem.Numvenda);
                        decimal resto = Convert.ToDecimal(textBox1.Text);
                        DataTable fi = DALCadastro.FluxoVendaFiado(Global.Margem.ClienteFiadoTemp);

                        if (um == true)
                        {
                            DALCadastro.ParcialInsere(Global.Margem.ClienteFiadoTemp, textBox4.Text, "dinheiro", Global.Margem.CaixaSelecionado);
                            string parcial = Convert.ToString(resto - Convert.ToDecimal(textBox4.Text));
                            // DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado, textBox1.Text, parcial, DateTime.Now.ToLongDateString(), Global.Margem.Numvenda);
                            DALCadastro.InsereAUXVendas("Pagamento Parcial de Fiado", Global.Margem.Numvenda, Global.Margem.ClienteFiadoTemp, "dinheiro",
                                "Pagamento Fiado Parcial", textBox4.Text, data, Convert.ToInt32(datacalc));
                            resto = Convert.ToDecimal(parcial);
                            Global.SAT_Param.Formas_Pagamento_dinheiro = "sim";
                            Global.SAT_Param.Formas_Pagamento_dinheiro_valor = textBox4.Text.Replace(",", ".");

                            Global.Margem.PagParcialFiadoD = "Dinheiro R$ " + textBox4.Text;

                        }
                        if (tres == true)
                        {
                            DALCadastro.ParcialInsere(Global.Margem.ClienteFiadoTemp, textBox6.Text, "cartão de crédito", Global.Margem.CaixaSelecionado);
                            string parcial = Convert.ToString(resto - Convert.ToDecimal(textBox6.Text));
                            //DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado, textBox1.Text, parcial, DateTime.Now.ToLongDateString(), Global.Margem.Numvenda);
                            DALCadastro.InsereAUXVendas("Pagamento Parcial de Fiado", Global.Margem.Numvenda, Global.Margem.ClienteFiadoTemp, "cartão de crédito",
                                "Pagamento Fiado Parcial", textBox6.Text, data, Convert.ToInt32(datacalc));
                            resto = Convert.ToDecimal(parcial);
                            
                            //------------------SAT
                            Global.SAT_Param.Formas_Pagamento_CC = "sim";
                            Global.SAT_Param.Formas_Pagamento_CC_valor = textBox6.Text.Replace(",", ".");
                            Global.SAT_Param.Formas_Pagamento_CC_Codigo = "001";


                            Global.Margem.PagParcialFiadoCC = "Cartão de Credito R$ " + textBox6.Text;

                        }
                        if (dois == true)
                        {
                            DALCadastro.ParcialInsere(Global.Margem.ClienteFiadoTemp, textBox5.Text, "cartão de débito", Global.Margem.CaixaSelecionado);
                            string parcial = Convert.ToString(resto - Convert.ToDecimal(textBox5.Text));
                            // DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado, textBox1.Text, parcial, DateTime.Now.ToLongDateString(), Global.Margem.Numvenda);
                            DALCadastro.InsereAUXVendas("Pagamento Parcial de Fiado", Global.Margem.Numvenda, Global.Margem.ClienteFiadoTemp, "cartão de débito",
                                "Pagamento Fiado Parcial", textBox5.Text, data, Convert.ToInt32(datacalc));
                            resto = Convert.ToDecimal(parcial);

                            //------------------SAT
                            Global.SAT_Param.Formas_Pagamento_CD = "sim";
                            Global.SAT_Param.Formas_Pagamento_CD_valor = textBox5.Text.Replace(",", ".");
                            Global.SAT_Param.Formas_Pagamento_CD_codigo = "001";

                            Global.Margem.PagParcialFiadoCD = "Cartão de Débito R$ " + textBox5.Text;

                        }
                        if (quatro == true)
                        {
                            DALCadastro.ParcialInsere(Global.Margem.ClienteFiadoTemp, textBox7.Text, "cheque", Global.Margem.CaixaSelecionado);
                            string parcial = Convert.ToString(resto - Convert.ToDecimal(textBox7.Text));
                            //DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiado, textBox1.Text, parcial, DateTime.Now.ToLongDateString(), Global.Margem.Numvenda);
                            DALCadastro.InsereAUXVendas("Pagamento Parcial de Fiado", Global.Margem.Numvenda, Global.Margem.ClienteFiadoTemp, "cheque",
                                "Pagamento Fiado Parcial", textBox7.Text, data, Convert.ToInt32(datacalc));
                            resto = Convert.ToDecimal(parcial);

                            //------------------SAT
                            Global.SAT_Param.Formas_Pagamento_cheque = "sim";
                            Global.SAT_Param.Formas_Pagamento_cheque_valor = textBox7.Text.Replace(",", ".");

                            Global.Margem.PagParcialFiadoC = "Cheque R$ " + textBox7.Text;
                        }

                        DALCadastro.CriaFiadoParcial(Global.Margem.ClienteFiadoTemp, textBox1.Text, Convert.ToString(Convert.ToDecimal(textBox1.Text) - resto), DateTime.Now.ToLongDateString(), Global.Margem.Numvenda + "|");
                        MessageBox.Show("Saldo devedor restante de R$ " + Convert.ToString(resto) + " .\n\nCliente : " + Global.Margem.ClienteFiadoTemp);

                        Global.Margem.PagParcialFiado = "sim";

                        //------------------SAT
                        Global.SAT_Param.Formas_Pagamento_credito_loja = "sim";
                        Global.SAT_Param.Formas_Pagamento_credito_loja_valor = Convert.ToString(resto).Replace(",", ".");
                        Global.SAT_Param.Formas_Pagamento_Qtde = "sim";
                        Global.Margem.CancelaSAT = "não";
                        Form sat = new TelaSAT();
                        sat.ShowDialog();

                        if (Global.Margem.CancelaSAT == "não")
                        {
                            EnviaSAT.EnviarDadosVenda(Convert.ToInt32(Global.Margem.Numvenda), "#lecoteco1975#", Global.Margem.Numvenda, "sim");
                        }

                        DALCadastro.InsereImpressao(Global.Margem.Numvenda);

                        Global.Margem.Pagamento = "Pagamento a prazo";
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Pagamento : a prazo. Número venda : " + Global.Margem.Numvenda +
                                " Total : " + Global.Margem.Totalvenda);
                        }
                        Global.Margem.Troco = "misto";
                        this.Close();
                    }
                    else
                    {
                        
                        return;
                    }
                   
                }
                return;
                //***************************************************************************************************
                //***************************************************************************************************

            }
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false)
            {
                textBox2.Text = textBox2.Text.Replace(".",",");
                int ponto = 0;
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (textBox2.Text.Substring(i,1) == ",")
                    {
                        ponto = ponto + 1;
                    }
                    if (ponto > 1)
                    {
                        MessageBox.Show("Valor em formato incorreto");
                        textBox2.Text = "";
                        textBox2.Focus();
                        return;
                    }
                }
                Int64 qtde;
                if (Int64.TryParse(textBox2.Text.Replace(",","").Trim(), out qtde) == false)
                {
                    MessageBox.Show("Favor informar somente valores numéricos");
                    textBox2.Text = "";
                    textBox2.Focus();
                    return;
                }
                if (Convert.ToDecimal(textBox2.Text) < Convert.ToDecimal(textBox1.Text))
                {
                    MessageBox.Show("Valor pago informado é menor que o total da venda.");
                    textBox2.Text = "";
                    textBox2.Focus();
                    return;
                }
                if (Convert.ToDecimal(textBox2.Text) == Convert.ToDecimal(textBox1.Text))
                {
                    textBox3.Text = "0,00";
                    MessageBox.Show("Troco = R$ " + textBox3.Text);
                    Global.Margem.Troco = "sim";
                    this.Close();
                    return;
                }
                if (Convert.ToDecimal(textBox2.Text) > Convert.ToDecimal(textBox1.Text))
                {
                    textBox3.Text = Convert.ToString( Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox1.Text));
                    MessageBox.Show("Troco = R$ " + textBox3.Text);
                    Global.Margem.Troco = "sim";
                    Global.Margem.TemTroco = "sim";
                    this.Close();
                }
            }
            if (String.IsNullOrEmpty(textBox2.Text) == true && String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox3.Text) == true)
            {
                Global.Margem.Troco = "sim";
                Global.Margem.TemTroco = "sim";
                this.Close();
            }
          
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) == false)
            {
                textBox2.Text = textBox2.Text.Replace(".", ",");
                int ponto = 0;
                for (int i = 0; i < textBox2.Text.Length; i++)
                {
                    if (textBox2.Text.Substring(i, 1) == ",")
                    {
                        ponto = ponto + 1;
                    }
                    if (ponto > 1)
                    {
                        MessageBox.Show("Valor em formato incorreto");
                        textBox2.Text = "";
                        textBox2.Focus();
                        return;
                    }
                }
                Int64 qtde;
                if (Int64.TryParse(textBox2.Text.Replace(",", "").Trim(), out qtde) == false)
                {
                    MessageBox.Show("Favor informar somente valores numéricos");
                    textBox2.Text = "";
                    textBox2.Focus();
                    return;
                }
                if (Convert.ToDecimal(textBox2.Text) > Convert.ToDecimal(textBox1.Text))
                {
                    textBox3.Text = Convert.ToString( Convert.ToDecimal(textBox2.Text) - Convert.ToDecimal(textBox1.Text));
                    return;
                   
                 }
                 if (Convert.ToDecimal(textBox2.Text) < Convert.ToDecimal(textBox1.Text))
                 {
                     MessageBox.Show("Valor pago informado é menor que o total da venda.");
                     textBox2.Text = "";
                     textBox2.Focus();
                     return;
                 }
                 if (Convert.ToDecimal(textBox2.Text) == Convert.ToDecimal(textBox1.Text))
                 {
                     textBox3.Text = "0,00";
                     return;
                     
                 }
            }
            textBox2.BackColor = System.Drawing.Color.White;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox4.ReadOnly = false;
                textBox4.Text = "";
                textBox4.Focus();
            }
            if (checkBox1.Checked == false)
            {
                textBox4.ReadOnly = true;
                textBox4.Text = "0,00";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox5.ReadOnly = false;
                textBox5.Text = "";
                textBox5.Focus();
            }
            if (checkBox2.Checked == false)
            {
                textBox5.ReadOnly = true;
                textBox5.Text = "0,00";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox6.ReadOnly = false;
                textBox6.Text = "";
                textBox6.Focus();
            }
            if (checkBox3.Checked == false)
            {
                textBox6.ReadOnly = true;
                textBox6.Text = "0,00";
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                textBox7.ReadOnly = false;
                textBox7.Text = "";
                textBox7.Focus();
            }
            if (checkBox4.Checked == false)
            {
                textBox7.ReadOnly = true;
                textBox7.Text = "0,00";
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                textBox8.ReadOnly = false;
                textBox8.Text = "";
                textBox8.Focus();
            }
            if (checkBox5.Checked == false)
            {
                textBox8.ReadOnly = true;
                textBox8.Text = "";
            }
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                return;
            }
            decimal soma = 0;
            if (checkBox2.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox5.Text) == false)
                {
                    if (Convert.ToDecimal(textBox5.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox5.Text);
                    }    
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }
                
            }
            if (checkBox3.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox6.Text) == false)
                {
                    if (Convert.ToDecimal(textBox6.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox6.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox4.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox7.Text) == false)
                {
                    if (Convert.ToDecimal(textBox7.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox7.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox5.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox8.Text) == false)
                {
                    if (Convert.ToDecimal(textBox8.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox8.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (Convert.ToDecimal(textBox1.Text) > soma)
            {
                textBox4.Text = Convert.ToString( Convert.ToDecimal(textBox1.Text) - soma );
            }
            if (Convert.ToDecimal(textBox1.Text) == soma)
            {
                MessageBox.Show("Valor total da venda coberto");
                return;
            }
            if (Convert.ToDecimal(textBox1.Text) < soma)
            {
                MessageBox.Show("Valor de pagamentos informados maior que o total da venda");
                return;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                return;
            }
            decimal soma = 0;
            if (checkBox1.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox4.Text) == false)
                {
                    if (Convert.ToDecimal(textBox4.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox4.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox3.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox6.Text) == false)
                {
                    if (Convert.ToDecimal(textBox6.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox6.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox4.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox7.Text) == false)
                {
                    if (Convert.ToDecimal(textBox7.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox7.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox5.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox8.Text) == false)
                {
                    if (Convert.ToDecimal(textBox8.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox8.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (Convert.ToDecimal(textBox1.Text) > soma)
            {
                textBox5.Text = Convert.ToString(Convert.ToDecimal(textBox1.Text) - soma);
            }
            if (Convert.ToDecimal(textBox1.Text) == soma)
            {
                MessageBox.Show("Valor total da venda coberto");
                return;
            }
            if (Convert.ToDecimal(textBox1.Text) < soma)
            {
                MessageBox.Show("Valor de pagamentos informados maior que o total da venda");
                return;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                return;
            }
            decimal soma = 0;
            if (checkBox2.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox5.Text) == false)
                {
                    if (Convert.ToDecimal(textBox5.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox5.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox1.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox4.Text) == false)
                {
                    if (Convert.ToDecimal(textBox4.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox4.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox4.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox7.Text) == false)
                {
                    if (Convert.ToDecimal(textBox7.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox7.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox5.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox8.Text) == false)
                {
                    if (Convert.ToDecimal(textBox8.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox8.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (Convert.ToDecimal(textBox1.Text) > soma)
            {
                textBox6.Text = Convert.ToString(Convert.ToDecimal(textBox1.Text) - soma);
            }
            if (Convert.ToDecimal(textBox1.Text) == soma)
            {
                MessageBox.Show("Valor total da venda coberto");
                return;
            }
            if (Convert.ToDecimal(textBox1.Text) < soma)
            {
                MessageBox.Show("Valor de pagamentos informados maior que o total da venda");
                return;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked == false)
            {
                return;
            }
            decimal soma = 0;
            if (checkBox2.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox5.Text) == false)
                {
                    if (Convert.ToDecimal(textBox5.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox5.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox3.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox6.Text) == false)
                {
                    if (Convert.ToDecimal(textBox6.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox6.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox1.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox4.Text) == false)
                {
                    if (Convert.ToDecimal(textBox4.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox4.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox5.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox8.Text) == false)
                {
                    if (Convert.ToDecimal(textBox8.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox8.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (Convert.ToDecimal(textBox1.Text) > soma)
            {
                textBox7.Text = Convert.ToString(Convert.ToDecimal(textBox1.Text) - soma);
            }
            if (Convert.ToDecimal(textBox1.Text) == soma)
            {
                MessageBox.Show("Valor total da venda coberto");
                return;
            }
            if (Convert.ToDecimal(textBox1.Text) < soma)
            {
                MessageBox.Show("Valor de pagamentos informados maior que o total da venda");
                return;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == false)
            {
                return;
            }
            decimal soma = 0;
            if (checkBox2.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox5.Text) == false)
                {
                    if (Convert.ToDecimal(textBox5.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox5.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox3.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox6.Text) == false)
                {
                    if (Convert.ToDecimal(textBox6.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox6.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox4.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox7.Text) == false)
                {
                    if (Convert.ToDecimal(textBox7.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox7.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (checkBox1.Checked == true)
            {
                if (String.IsNullOrEmpty(textBox4.Text) == false)
                {
                    if (Convert.ToDecimal(textBox4.Text) > 0)
                    {
                        soma += Convert.ToDecimal(textBox4.Text);
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor de pagamento");
                    return;
                }

            }
            if (Convert.ToDecimal(textBox1.Text) > soma)
            {
                textBox8.Text = Convert.ToString(Convert.ToDecimal(textBox1.Text) - soma);
            }
            if (Convert.ToDecimal(textBox1.Text) == soma)
            {
                MessageBox.Show("Valor total da venda coberto");
                return;
            }
            if (Convert.ToDecimal(textBox1.Text) < soma)
            {
                MessageBox.Show("Valor de pagamentos informados maior que o total da venda");
                return;
            }

        }

        

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox9.Text = "";
            textBox9.Focus();
            checkBox8.Checked = false; 
           
            
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            textBox10.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox9.Text = "";
            textBox9.Focus();
            
            checkBox7.Checked = false;
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true )
            {

                //string temp = Ferramentas.Retira_Meta(textBox14.Text);
                if (checkBox7.Checked == true)
                {
                    if (textBox9.TextLength == 3)
                    {
                        textBox9.Text = textBox9.Text + ".";
                        textBox9.Select(textBox9.Text.Length,0);
                    }
                    if (textBox9.TextLength == 7)
                    {
                        textBox9.Text = textBox9.Text + ".";
                        textBox9.Select(textBox9.Text.Length, 0);
                    }
                    if (textBox9.TextLength == 11)
                    {
                        textBox9.Text = textBox9.Text + "-";
                        textBox9.Select(textBox9.Text.Length, 0);
                    }
                    if (textBox9.TextLength == 14)
                    {
                        
                        string temp = Ferramentas.Retira_Meta(textBox9.Text);
                        Int64 teste2 = 0;
                        if (Int64.TryParse(textBox9.Text, out teste2) == true)
                        {
                            MessageBox.Show("CPF em formato incorreto");
                            textBox9.Text = "";
                            textBox9.Focus();
                            return;
                        }
                        bool teste = Ferramentas.IsCpf(temp);
                        if (teste == false)
                        {
                            MessageBox.Show("CPF em formato incorreto");
                            textBox9.Text = "";
                            textBox9.Focus();
                            
                        }
                        if (teste == true)
                        {
                            textBox9.Focus();
                            
                        }
                    }

                }
            }
            if (checkBox8.Checked == true)
            {
                if (checkBox8.Checked == true)
                {
                        if (textBox9.TextLength == 2)
                        {
                            textBox9.Text = textBox9.Text + ".";
                            textBox9.Select(textBox9.Text.Length, 0);
                        }
                        if (textBox9.TextLength == 6)
                        {
                            textBox9.Text = textBox9.Text + ".";
                            textBox9.Select(textBox9.Text.Length, 0);
                        }
                        if (textBox9.TextLength == 10)
                        {
                            textBox9.Text = textBox9.Text + "/";
                            textBox9.Select(textBox9.Text.Length, 0);
                        }
                        if (textBox9.TextLength == 15)
                        {
                            textBox9.Text = textBox9.Text + "-";
                            textBox9.Select(textBox9.Text.Length, 0);
                        }
                        if (textBox9.TextLength == 18)
                        {

                            string temp = Ferramentas.Retira_Meta(textBox9.Text);
                            Int64 teste3 = 0;
                            if (Int64.TryParse(textBox9.Text, out teste3) == true)
                            {
                                MessageBox.Show("CPF em formato incorreto");
                                textBox9.Text = "";
                                textBox9.Focus();
                                return;
                            }
                            bool teste = Ferramentas.IsCnpj(temp);
                            if (teste == false)
                            {
                                MessageBox.Show("CNPJ em formato incorreto");
                                textBox9.Text = "";
                                textBox9.Focus();
                                
                            }
                            if (teste == true)
                            {
                                textBox9.Focus();
                            }
                        }
                }
            }  
        
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            textBox9.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            textBox9.BackColor = System.Drawing.Color.White;         

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.Color.Cyan;

        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.BackColor = System.Drawing.Color.White;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.BackColor = System.Drawing.Color.White;
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox6.BackColor = System.Drawing.Color.White;
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            textBox7.BackColor = System.Drawing.Color.White;
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            textBox10.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            textBox10.BackColor = System.Drawing.Color.White;
        }
    }
}
