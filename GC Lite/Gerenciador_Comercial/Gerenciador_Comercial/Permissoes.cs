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
    public partial class Permissoes : Form
    {
        public Permissoes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                
                string nome = Global.Margem.OperadorTemp;

                string senha = Global.Margem.SenhaCadastroUsuarioTemp;
                string admistrador = "";
                if (checkBox1.Checked == true)
                {
                    admistrador = "sim";
                }
                if (checkBox1.Checked == false)
                {
                    admistrador = "não";
                }
                //cad usuarios
                string cadUsr = "";
                if (checkBox8.Checked == true)
                {
                    //normal
                    cadUsr = "sim";
                }
                if (checkBox7.Checked == true)
                {
                    //total
                    cadUsr = "adm";

                }
                if (checkBox8.Checked == false && checkBox7.Checked == false)
                {
                    cadUsr = "não";
                }
                //cad produtos
                string cadPro = "";
                if (checkBox2.Checked == true)
                {
                    //normal
                    cadPro = "sim";
                }
                if (checkBox5.Checked == true)
                {
                    //total
                    cadPro = "adm";
                }
                if (checkBox2.Checked == false && checkBox5.Checked == false)
                {
                    cadPro = "não";
                }
                //cad participantes
                string cadPart = "" ;
                if (checkBox10.Checked == true)
                {
                    //normal
                    cadPart = "sim";
                }
                if (checkBox11.Checked == true)
                {
                    //total
                    cadPart = "adm";
                }
                if (checkBox10.Checked == false && checkBox11.Checked == false)
                {
                    cadPart = "não";
                }
                //caixa
                string caixa = "";
                if (checkBox14.Checked == true)
                {
                    //normal
                    caixa = "sim";
                }
                if (checkBox15.Checked == true)
                {
                    //total
                    caixa = "adm";
                }
                if (checkBox14.Checked == false && checkBox15.Checked == false)
                {
                    caixa = "não";
                }
                //logs
                string log = "";
                if (checkBox18.Checked == true)
                {
                    //normal
                    log = "sim";
                }
                if (checkBox19.Checked == true)
                {
                    //total
                    log = "adm";
                }
                if (checkBox18.Checked == false && checkBox19.Checked == false)
                {
                    log = "não";
                }
                //fluxo de caixa
                string fluxoCaixa1 = "";
                if (checkBox22.Checked == true)
                {
                    //normal
                    fluxoCaixa1 = "sim";
                }
                if (checkBox23.Checked == true)
                {
                    //total
                    fluxoCaixa1 = "adm";
                } 
                if (checkBox22.Checked == false && checkBox23.Checked == false)
                {
                    fluxoCaixa1 = "não";
                }
                //contas a pagar
                string contas = "";
                if (checkBox26.Checked == true)
                {
                    //normal
                    contas = "sim";
                }
                if (checkBox27.Checked == true)
                {
                    //total
                    contas = "adm";
                }
                if (checkBox26.Checked == false && checkBox27.Checked == false)
                {
                    contas = "não";
                }
                //contas a receber
                string contasRec = "";
                if (checkBox30.Checked == true)
                {
                    //normal
                    contasRec = "sim";
                }
                if (checkBox31.Checked == true)
                {
                    //total
                    contasRec = "adm";
                }
                if (checkBox30.Checked == false && checkBox31.Checked == false)
                {
                    contasRec = "não";
                }
                //conf sistema
                string conf = "";
                if (checkBox34.Checked == true)
                {
                    //normal
                    conf = "sim";
                }
                if (checkBox35.Checked == true)
                {
                    //total
                    conf = "adm";
                }
                if (checkBox34.Checked == false && checkBox35.Checked == false)
                {
                    conf = "não";
                }
                if (checkBox8.Checked == true && checkBox2.Checked == true && checkBox10.Checked == true && checkBox14.Checked == true &&
                    checkBox18.Checked == true && checkBox22.Checked == true  &&  checkBox26.Checked == true && checkBox30.Checked == true
                    && checkBox34.Checked == true)
                {
                    checkBox1.Checked = false;
                    admistrador = "não";
                }
                if (Global.Margem.editaUsrSist == "novo")
                {
                    //cod para inserir
                    DALCadastro.InsereUsrSistema(nome,senha,admistrador,cadUsr,cadPro,cadPart,caixa,log,fluxoCaixa1,contas,contasRec,conf);
                    this.Close();
                }
                if (Global.Margem.editaUsrSist == "edita")
                {
                    DALCadastro.InsereUsrSistemaEdita(Convert.ToInt32(Global.Margem.intCadUsr),admistrador, cadUsr, cadPro, cadPart,
                                                      caixa, log, fluxoCaixa1, contas, contasRec, conf);
                    if (Global.Margem.OperadorTemp == Global.Margem.Operador)
                    {
                        string id7 = Global.Margem.intCadUsr;
                        Global.Margem.Administrador = Convert.ToString(DALCadastro.carregaPermissao("CarregaADM", Convert.ToInt32(id7)));
                        Global.Margem.CadastroUsuarios = Convert.ToString(DALCadastro.carregaPermissao("CarregaUm", Convert.ToInt32(id7)));
                        Global.Margem.CadastroProdutos = Convert.ToString(DALCadastro.carregaPermissao("CarregaDois", Convert.ToInt32(id7)));
                        Global.Margem.CadastroParticipantes = Convert.ToString(DALCadastro.carregaPermissao("CarregaTres", Convert.ToInt32(id7)));
                        Global.Margem.CaixaTerminalVendas = Convert.ToString(DALCadastro.carregaPermissao("CarregaQuatro", Convert.ToInt32(id7)));
                        Global.Margem.Logs = Convert.ToString(DALCadastro.carregaPermissao("CarregaCinco", Convert.ToInt32(id7)));
                        Global.Margem.FluxoDeCaixa = Convert.ToString(DALCadastro.carregaPermissao("CarregaSeis", Convert.ToInt32(id7)));
                        Global.Margem.ContasPagar = Convert.ToString(DALCadastro.carregaPermissao("CarregaSete", Convert.ToInt32(id7)));
                        Global.Margem.ContasReceber = Convert.ToString(DALCadastro.carregaPermissao("CarregaOito", Convert.ToInt32(id7)));
                        Global.Margem.ConfiguraçãoSistema = Convert.ToString(DALCadastro.carregaPermissao("CarregaNove", Convert.ToInt32(id7)));
                        MessageBox.Show("Novas permissões já estão em vigor para usuário atual");
                        Global.Margem.intCadUsr = "";
                    }
                    
                    //código para atualizar permissões
                    this.Close();
                }
                
        }

        private void Permissoes_Load(object sender, EventArgs e)
        {
            label19.Text = Global.Margem.OperadorTemp;
            if (Global.Margem.editaUsrSist == "edita")
            {
                label18.Text = "Editar permissões para :";
                string admini = Convert.ToString(DALCadastro.carregaPermissao("CarregaADM",Convert.ToInt32( Global.Margem.intCadUsr)));
                if (admini == "sim")
                {
                    checkBox1.Checked = true;
                    return;
                }
                if (admini == "não")
                {
                    checkBox1.Checked = false;
                }
                string cadUsrs1 = Convert.ToString(DALCadastro.carregaPermissao("CarregaUm", Convert.ToInt32(Global.Margem.intCadUsr)));
                if (cadUsrs1 == "sim")
                {
                    checkBox8.Checked = true;
                    
                }
                
                if (cadUsrs1 == "adm")
                {
                    checkBox7.Checked = true;
                }
                string cadProd1 = Convert.ToString(DALCadastro.carregaPermissao("CarregaDois", Convert.ToInt32(Global.Margem.intCadUsr)));
                if (cadProd1 == "sim")
                {
                    checkBox2.Checked = true;

                }

                if (cadProd1 == "adm")
                {
                    checkBox5.Checked = true;
                }
                string cadPart1 = Convert.ToString(DALCadastro.carregaPermissao("CarregaTres", Convert.ToInt32(Global.Margem.intCadUsr)));
                if (cadPart1 == "sim")
                {
                    checkBox10.Checked = true;

                }

                if (cadPart1 == "adm")
                {
                    checkBox11.Checked = true;
                }
                string cadCaixa1 = Convert.ToString(DALCadastro.carregaPermissao("CarregaQuatro", Convert.ToInt32(Global.Margem.intCadUsr)));
                if (cadCaixa1 == "sim")
                {
                    checkBox14.Checked = true;

                }

                if (cadCaixa1 == "adm")
                {
                    checkBox15.Checked = true;
                }
                string cadLog1 = Convert.ToString(DALCadastro.carregaPermissao("CarregaCinco", Convert.ToInt32(Global.Margem.intCadUsr)));
                if (cadLog1 == "sim")
                {
                    checkBox18.Checked = true;

                }

                if (cadLog1 == "adm")
                {
                    checkBox19.Checked = true;
                }
                string cadFluxo1 = Convert.ToString(DALCadastro.carregaPermissao("CarregaSeis", Convert.ToInt32(Global.Margem.intCadUsr)));
                if (cadFluxo1 == "sim")
                {
                    checkBox22.Checked = true;

                }

                if (cadFluxo1 == "adm")
                {
                    checkBox23.Checked = true;
                }
                string cadContas1 = Convert.ToString(DALCadastro.carregaPermissao("CarregaSete", Convert.ToInt32(Global.Margem.intCadUsr)));
                if (cadContas1 == "sim")
                {
                    checkBox26.Checked = true;

                }

                if (cadContas1 == "adm")
                {
                    checkBox27.Checked = true;
                }
                string cadContasRec1 = Convert.ToString(DALCadastro.carregaPermissao("CarregaOito", Convert.ToInt32(Global.Margem.intCadUsr)));
                if (cadContasRec1 == "sim")
                {
                    checkBox30.Checked = true;

                }

                if (cadContasRec1 == "adm")
                {
                    checkBox31.Checked = true;
                }
                string cadConf1 = Convert.ToString(DALCadastro.carregaPermissao("CarregaNove", Convert.ToInt32(Global.Margem.intCadUsr)));
                if (cadConf1 == "sim")
                {
                    checkBox34.Checked = true;

                }

                if (cadConf1 == "adm")
                {
                    checkBox35.Checked = true;
                }
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox7.Checked = true;
                checkBox5.Checked = true;
                checkBox11.Checked = true;
                checkBox15.Checked = true;
                checkBox19.Checked = true;
                checkBox23.Checked = true;
                checkBox27.Checked = true;
                checkBox31.Checked = true;
                checkBox35.Checked = true;

                checkBox8.Checked = false;
                checkBox2.Checked = false;
                checkBox10.Checked = false;
                checkBox14.Checked = false;
                checkBox18.Checked = false;
                checkBox22.Checked = false;
                checkBox26.Checked = false;
                checkBox30.Checked = false;
                checkBox34.Checked = false;

            }
            if (checkBox1.Checked == false)
            {

                checkBox7.Checked = false;
                checkBox5.Checked = false;
                checkBox11.Checked = false;
                checkBox15.Checked = false;
                checkBox19.Checked = false;
                checkBox23.Checked = false;
                checkBox27.Checked = false;
                checkBox31.Checked = false;
                checkBox35.Checked = false;

                checkBox8.Checked = false;
                checkBox2.Checked = false;
                checkBox10.Checked = false;
                checkBox14.Checked = false;
                checkBox18.Checked = false;
                checkBox22.Checked = false;
                checkBox26.Checked = false;
                checkBox30.Checked = false;
                checkBox34.Checked = false;
                
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                checkBox7.Checked = false;
                checkBox1.Checked = false;
            }
            
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox8.Checked = false;
                //checkBox1.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox5.Checked = false;
                checkBox1.Checked = false;

            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                checkBox11.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                checkBox10.Checked = false;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                checkBox15.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                checkBox14.Checked = false;
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked == true)
            {
                checkBox19.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked == true)
            {
                checkBox18.Checked = false;
            }
        }

        private void checkBox22_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox22.Checked == true)
            {
                checkBox23.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox23_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox23.Checked == true)
            {
                checkBox22.Checked = false;
            }
        }

        private void checkBox26_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox26.Checked == true)
            {
                checkBox27.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox27_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox27.Checked == true)
            {
                checkBox26.Checked = false;
            }
        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox30.Checked == true)
            {
                checkBox31.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox31_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox31.Checked == true)
            {
                checkBox30.Checked = false;
            }
        }

        private void checkBox34_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox34.Checked == true)
            {
                checkBox35.Checked = false;
                checkBox1.Checked = false;
            }
        }

        private void checkBox35_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox35.Checked == true)
            {
                checkBox34.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global.Margem.editaUsrSist = "não";
            this.Close();
        }
    }
}
