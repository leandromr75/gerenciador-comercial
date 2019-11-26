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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty( textBox1.Text ) == true || String.IsNullOrEmpty( textBox2.Text ) == true)
            {
                
                    MessageBox.Show("Campo obrigatório não preenchido!");
                    textBox1.Focus();
                    return;
                
            }
            if (textBox1.Text == "ADMIN" && textBox2.Text == "admin")
            {
                
                string testa1 = Convert.ToString(DALCadastro.testaLicença());
                string testaLogin = Convert.ToString(DALCadastro.TestaLogin());
                if (String.IsNullOrEmpty(testa1) == true)
                {
                    MessageBox.Show("Detectado primeiro uso do sistema! \n\n" + "Será necessário cadastrar um novo usuário e senha de acesso\nno menu Usuários do Sistema" + 
                        "\n\nSerá necessário também fazer o download da ativação\nno menu Renovação da Licença.");
                    DALCadastro.MapearResolução(Convert.ToString(DateTime.Now.Year * 67), Convert.ToString(DateTime.Now.Month * 115), Convert.ToString(DateTime.Now.Day * 57),
                        Convert.ToString(DateTime.Now.Hour * 33), Convert.ToString(DateTime.Now.Minute * 33), Convert.ToString(DateTime.Now.Second * 33)); 
                    //DateTime data5 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                    //Global.Margem.Hora = data5;
                   
                    Global.Margem.Operador = "admin";
                    Global.Margem.Administrador = "não";
                    Global.Margem.CadastroUsuarios = "sim";
                    Global.Margem.CadastroProdutos = "não";
                    Global.Margem.CadastroParticipantes = "não";
                    Global.Margem.CaixaTerminalVendas = "não";
                    Global.Margem.Logs = "não";
                    Global.Margem.FluxoDeCaixa = "não";
                    Global.Margem.ContasPagar = "não";
                    Global.Margem.ContasReceber = "não";
                    Global.Margem.ConfiguraçãoSistema = "sim";
                    Form usuarios = new UsuariosSistema();
                    GerenciadorDeFormulario.Abre(usuarios);

                    this.Close();
                    return;
                    
                }
                if (String.IsNullOrEmpty(testa1) == false)
                {
                    
                    if (String.IsNullOrEmpty(testaLogin) == true)
                    {
                        
                        DateTime data4 = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                        Global.Margem.Hora = data4;
                        MessageBox.Show("Sistema está com a licença instalada.  " + 
                        "\n\nSerá necessário cadastrar um novo usuário e senha de acesso\nno menu Usuários do Sistema");
                        Global.Margem.Operador = "admin";
                        Global.Margem.Administrador = "não";
                        Global.Margem.CadastroUsuarios = "sim";
                        Global.Margem.CadastroProdutos = "não";
                        Global.Margem.CadastroParticipantes = "não";
                        Global.Margem.CaixaTerminalVendas = "não";
                        Global.Margem.Logs = "não";
                        Global.Margem.FluxoDeCaixa = "não";
                        Global.Margem.ContasPagar = "não";
                        Global.Margem.ContasReceber = "não";
                        Global.Margem.ConfiguraçãoSistema = "sim";
                        
                        
                        Form usuarios = new UsuariosSistema();
                        GerenciadorDeFormulario.Abre(usuarios);

                        this.Close();
                        return;
                    }
                    if (String.IsNullOrEmpty(testaLogin) == false)
                    {
                        MessageBox.Show("Usuário admin foi desabilitado, pois existem usuários cadastrados.");
                        //Global.Margem.Operador = "admin";
                        //Form usuarios = new UsuariosSistema();
                        //GerenciadorDeFormulario.Abre(usuarios);
                        textBox1.Text = "";
                        textBox2.Text = "";
                        return;
                        
                    }
                }
                
                

            }
            string testa2 = Convert.ToString(DALCadastro.testaLicença());
            if (String.IsNullOrEmpty(testa2) == false)
            {
                
                string autentica = Convert.ToString( DALCadastro.VerificaLogin(textBox1.Text,textBox2.Text) );
                if (String.IsNullOrEmpty(autentica) == false)
                {
                    
                    if (String.IsNullOrEmpty(testa2) == true)
                    {
                        MessageBox.Show("Não foi possível localizar informações sobre a licença do Sistema. \n\nFavor entrar em contato com o desenvolvedor do sistema");
                        Application.Exit();
                        //this.Close();
                        //return;
                    }
                    Ferramentas.Dedo_Duro();
                    if (Global.Margem.ExpirouLicença == "sim")
                    {
                        Application.Exit();
                    }
                    if (autentica == textBox2.Text && Global.Margem.ExpirouLicença != "sim")
                    {
                        
                        string x = Convert.ToString(DALCadastro.ValidaLicença("X"));

                        int resultX = Convert.ToInt32(x) / 77;

                        string y = Convert.ToString(DALCadastro.ValidaLicença("Y"));
                        int resultY = Convert.ToInt32(y) / 133;

                        string z = Convert.ToString(DALCadastro.ValidaLicença("Z"));
                        int resultZ = Convert.ToInt32(z) / 55;

                        //data aviso
                        string r = Convert.ToString(DALCadastro.ValidaLicença("R"));
                        int resultR = Convert.ToInt32(r) / 13;

                        string g = Convert.ToString(DALCadastro.ValidaLicença("G"));
                        int resultG = Convert.ToInt32(g) / 7;

                        string b = Convert.ToString(DALCadastro.ValidaLicença("B"));
                        int resultB = Convert.ToInt32(b) / 7;

                        //ultimo acesso
                        /*string res1 = Convert.ToString(DALCadastro.ValidaLicença("Res1"));
                        int resultRes1 = Convert.ToInt32(res1) / 67;

                        string res2 = Convert.ToString(DALCadastro.ValidaLicença("Res2"));
                        int resultRes2 = Convert.ToInt32(res2) / 115;

                        string res3 = Convert.ToString(DALCadastro.ValidaLicença("Res3"));
                        int resultRes3 = Convert.ToInt32(res3) / 57;

                        string res4 = Convert.ToString(DALCadastro.ValidaLicença("Res4"));
                        int resultRes4 = Convert.ToInt32(res4) / 33;

                        string res5 = Convert.ToString(DALCadastro.ValidaLicença("Res5"));
                        int resultRes5 = Convert.ToInt32(res5) / 33;*/

                        DateTime data3 = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                            DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        x = "20" + Convert.ToString(resultX);
                        resultX = Convert.ToInt32(x);

                        r = "20" + Convert.ToString(resultR);
                        resultR = Convert.ToInt32(r);

                        //MessageBox.Show(Convert.ToString( resultX) + Convert.ToString( resultR));


                        DateTime data1 = new DateTime(resultX, resultY, resultZ, 20, 00, 00);

                        DateTime data2 = new DateTime(resultR, resultG, resultB, 20, 00, 00);
                        //MessageBox.Show(Convert.ToString(data1) +"  "+ Convert.ToString(data2) +"   "+ Convert.ToString(data3));

                        int result = DateTime.Compare(data1, data3);
                        if (result < 0)
                        {
                            MessageBox.Show("Sistema Expirou. \n\nEntre em contato com o desenvolvedor. O sistema será fechado.");
                            Application.Exit();
                        }
                        else
                        {
                            int resul = DateTime.Compare(data2, data3);
                            if (resul < 0)
                            {
                                
                                string message = "Licença do sistema expira em: " + Convert.ToString(data1) + ". \nDeseja atualizar agora?";
                                string caption = "Sistema ==> Licença";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult resultado;

                                // Displays the MessageBox.

                                resultado = MessageBox.Show(this, message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                if (resultado == DialogResult.Yes)
                                {

                                    string id6 = Convert.ToString(DALCadastro.RetornaPermissão(textBox1.Text, textBox2.Text));
                                    if (String.IsNullOrEmpty(id6) == false)
                                    {
                                        
                                        Global.Margem.Operador = textBox1.Text;
                                        Global.Margem.Administrador = Convert.ToString(DALCadastro.carregaPermissao("CarregaADM", Convert.ToInt32(id6)));
                                        Global.Margem.CadastroUsuarios = Convert.ToString(DALCadastro.carregaPermissao("CarregaUm", Convert.ToInt32(id6)));
                                        Global.Margem.CadastroProdutos = Convert.ToString(DALCadastro.carregaPermissao("CarregaDois", Convert.ToInt32(id6)));
                                        Global.Margem.CadastroParticipantes = Convert.ToString(DALCadastro.carregaPermissao("CarregaTres", Convert.ToInt32(id6)));
                                        Global.Margem.CaixaTerminalVendas = Convert.ToString(DALCadastro.carregaPermissao("CarregaQuatro", Convert.ToInt32(id6)));
                                        Global.Margem.Logs = Convert.ToString(DALCadastro.carregaPermissao("CarregaCinco", Convert.ToInt32(id6)));
                                        Global.Margem.FluxoDeCaixa = Convert.ToString(DALCadastro.carregaPermissao("CarregaSeis", Convert.ToInt32(id6)));
                                        Global.Margem.ContasPagar = Convert.ToString(DALCadastro.carregaPermissao("CarregaSete", Convert.ToInt32(id6)));
                                        Global.Margem.ContasReceber = Convert.ToString(DALCadastro.carregaPermissao("CarregaOito", Convert.ToInt32(id6)));
                                        Global.Margem.ConfiguraçãoSistema = Convert.ToString(DALCadastro.carregaPermissao("CarregaNove", Convert.ToInt32(id6)));
                                        Global.Margem.Hora = data3;
                                        this.Visible = false;
                                        Form lice = new Licenca();
                                        
                                        lice.ShowDialog();


                                        lice.Update();
                                        lice.Close();
                                        
                                    }
                                    
                                    
                                }
                                else
                                {
                                    string id5 = Convert.ToString( DALCadastro.RetornaPermissão(textBox1.Text,textBox2.Text));
                                    if (String.IsNullOrEmpty(id5) == false)
                                    {
                                        Global.Margem.Operador = textBox1.Text;
                                        Global.Margem.Administrador = Convert.ToString( DALCadastro.carregaPermissao("CarregaADM",Convert.ToInt32(id5)));
                                        Global.Margem.CadastroUsuarios = Convert.ToString(DALCadastro.carregaPermissao("CarregaUm", Convert.ToInt32(id5)));
                                        Global.Margem.CadastroProdutos = Convert.ToString(DALCadastro.carregaPermissao("CarregaDois", Convert.ToInt32(id5)));
                                        Global.Margem.CadastroParticipantes = Convert.ToString(DALCadastro.carregaPermissao("CarregaTres", Convert.ToInt32(id5)));
                                        Global.Margem.CaixaTerminalVendas = Convert.ToString(DALCadastro.carregaPermissao("CarregaQuatro", Convert.ToInt32(id5)));
                                        Global.Margem.Logs = Convert.ToString(DALCadastro.carregaPermissao("CarregaCinco", Convert.ToInt32(id5)));
                                        Global.Margem.FluxoDeCaixa = Convert.ToString(DALCadastro.carregaPermissao("CarregaSeis", Convert.ToInt32(id5)));
                                        Global.Margem.ContasPagar = Convert.ToString(DALCadastro.carregaPermissao("CarregaSete", Convert.ToInt32(id5)));
                                        Global.Margem.ContasReceber = Convert.ToString(DALCadastro.carregaPermissao("CarregaOito", Convert.ToInt32(id5)));
                                        Global.Margem.ConfiguraçãoSistema = Convert.ToString(DALCadastro.carregaPermissao("CarregaNove", Convert.ToInt32(id5)));
                                        Global.Margem.Hora = data3;
                                        
                                        this.Close();
                                        
                                            
                                    }
                                    
                                }
                            }
                            if (resul > 0)
                            { 
                                 string id5 = Convert.ToString( DALCadastro.RetornaPermissão(textBox1.Text,textBox2.Text));
                                 if (String.IsNullOrEmpty(id5) == false)
                                 {
                                     Global.Margem.Operador = textBox1.Text;
                                     Global.Margem.Administrador = Convert.ToString(DALCadastro.carregaPermissao("CarregaADM", Convert.ToInt32(id5)));
                                     Global.Margem.CadastroUsuarios = Convert.ToString(DALCadastro.carregaPermissao("CarregaUm", Convert.ToInt32(id5)));
                                     Global.Margem.CadastroProdutos = Convert.ToString(DALCadastro.carregaPermissao("CarregaDois", Convert.ToInt32(id5)));
                                     Global.Margem.CadastroParticipantes = Convert.ToString(DALCadastro.carregaPermissao("CarregaTres", Convert.ToInt32(id5)));
                                     Global.Margem.CaixaTerminalVendas = Convert.ToString(DALCadastro.carregaPermissao("CarregaQuatro", Convert.ToInt32(id5)));
                                     Global.Margem.Logs = Convert.ToString(DALCadastro.carregaPermissao("CarregaCinco", Convert.ToInt32(id5)));
                                     Global.Margem.FluxoDeCaixa = Convert.ToString(DALCadastro.carregaPermissao("CarregaSeis", Convert.ToInt32(id5)));
                                     Global.Margem.ContasPagar = Convert.ToString(DALCadastro.carregaPermissao("CarregaSete", Convert.ToInt32(id5)));
                                     Global.Margem.ContasReceber = Convert.ToString(DALCadastro.carregaPermissao("CarregaOito", Convert.ToInt32(id5)));
                                     Global.Margem.ConfiguraçãoSistema = Convert.ToString(DALCadastro.carregaPermissao("CarregaNove", Convert.ToInt32(id5)));
                                     Global.Margem.Hora = data3;

                                     this.Close();
                                 }
                            }
                        }
                        //Global.Margem.Hora = data3;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Senha incorreta");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Usuário / Operador não cadastrado, \n e ou problemas na ativação da licença");
                }
            }













        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.LightBlue;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.White;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.Color.LightBlue;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.Color.White;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            
            

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                button1.Focus();
                button1.PerformClick();
            }
        }
    }
}
