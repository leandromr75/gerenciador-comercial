using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class TelaPrincipal : Form
    {
        public TelaPrincipal()
        {
            InitializeComponent();
        }
        int x = 11;
        //int dedoDURO = 0;
        string sem = "";
        string impress = "";
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(sem) == true)
            {
                if (Global.Margem.ServidorImpressao == "sim")
                {
                    impress = " - [Servidor de Impressão Ativo]";
                }
                
                sem = "beleza";
            }
            string adm2 = Global.Margem.Administrador;
            if (adm2 != "sim")
	        {
		        adm2 = "";
	        }
            if (adm2 == "sim")
            {
                adm2 = "Administrador do Sistema";
            }
            
            groupBox3.Text = " [Operador] : [" + Global.Margem.Operador + "] " + adm2 + " - [Sql Server : " + Global.Margem.ConfiguraçãoSistemaBancoDados +
                "] - ["
                +  DateTime.Now.ToLongDateString() + "] - [" + DateTime.Now.ToLongTimeString() + "]" +  impress  ;
            pictureBox3.SetBounds(x,32,377,162);

            if (x < Screen.PrimaryScreen.Bounds.Width - 750)
            {
                x = x + 25;
            }
            else
            {
                x = 11;
            }
            

            
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form cadastroprodutos = new CadastroProdutos();
            GerenciadorDeFormulario.Abre(cadastroprodutos);
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            /*string ano = Convert.ToString(DateTime.Now.Year);
            string primeirodigito = ano.Substring(2, 1);
            string segundodigito = ano.Substring(3, 1);
            string soma = primeirodigito + segundodigito;
            int armazena = Convert.ToInt32(soma) * 67;
            ano = Convert.ToString(armazena);
            DateTime DedoDuro = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);*/
            Ferramentas.Dedo_Duro();
            //DALCadastro.MapearResolução(Convert.ToString(DateTime.Now.Year * 67), Convert.ToString(DateTime.Now.Month * 115), Convert.ToString(DateTime.Now.Day * 57),
              // Convert.ToString(DateTime.Now.Hour * 33), Convert.ToString(DateTime.Now.Minute * 33), Convert.ToString(DateTime.Now.Second * 33)); 
            
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            Ferramentas.Dedo_Duro();
            if (Global.Margem.ExpirouLicença == "sim")
            {
                Application.Exit();
            }
            if (Global.Margem.CadastroProdutos == "sim" || Global.Margem.CadastroProdutos == "adm")
            {

                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;

                if (x < 1024 || y < 768)
                {
                    MessageBox.Show("Resolução Mínima: 1024 x 768 px");
                    return;
                }

                if (x >= 1024 && y >= 768 && x < 1360)
                {
                    Form cadastraprodutos1024x768 = new CadastroProdutos1024x768();
                    GerenciadorDeFormulario.Abre(cadastraprodutos1024x768);
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CadProdutos", "Acessou Cadastro de Produtos do Sistema");
                    }
                    return;
                }

                if (x >= 1360 && y >= 768 && x < 1440)
                {
                    Form cadastroprodutos1366x768 = new CadastroProdutos1366x768();
                    GerenciadorDeFormulario.Abre(cadastroprodutos1366x768);
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CadProdutos", "Acessou Cadastro de Produtos do Sistema");
                    }
                    return;
                }

                if (x >= 1440 && y >= 768)
                {
                    Form cadastroprodutos = new CadastroProdutos();
                    GerenciadorDeFormulario.Abre(cadastroprodutos);
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CadProdutos", "Acessou Cadastro de Produtos do Sistema");
                    }
                    return;
                }
            }
            if (Global.Margem.CadastroProdutos == "não")
            {
                MessageBox.Show("Usuário / Operador não tem permissão para acessar cadastro de produtos");
                
            }

            



        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Red;
            groupBox1.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Black;
            groupBox1.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Red;
           // pictureBox1.SetBounds(45,44,30,30);
            groupBox1.BackColor = System.Drawing.Color.YellowGreen;
            
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Black;
            //pictureBox1.SetBounds(45, 44, 22, 22);
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            groupBox5.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            groupBox5.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox17.Visible = true;
            Form av = new Avisos();
            av.ShowDialog();
            if (Global.Margem.AbreAviso == "ok")
            {
                pictureBox17.Visible = false;
            }
            else
            {
                pictureBox17.Visible = false;
            }
            Global.Margem.AbreAviso = "";   

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
            if (monthCalendar1.Visible == true )
            {
                monthCalendar1.Visible = false;
                return;
            }
            monthCalendar1.Visible = true;

        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            groupBox1.BackColor = System.Drawing.Color.YellowGreen;
            label6.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            groupBox1.BackColor = System.Drawing.Color.Transparent;
            label6.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            label9.ForeColor = System.Drawing.Color.Red;

            // pictureBox1.SetBounds(45,44,30,30);
            groupBox2.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = System.Drawing.Color.Black;

            // pictureBox1.SetBounds(45,44,30,30);
            groupBox2.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
            if (Global.Margem.ExpirouLicença == "sim")
            {
                Application.Exit();
            }
            if (Global.Margem.CadastroUsuarios == "adm")
            {
                Form usuarios = new UsuariosSistema();
                GerenciadorDeFormulario.Abre(usuarios);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("CadUsuarios", "Acessou Cadastro de Usuários do Sistema");
                }
                return;
            }
            if (Global.Margem.CadastroUsuarios == "sim")
            {
                Form usuarios = new UsuariosSistema();
                GerenciadorDeFormulario.Abre(usuarios);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("CadUsuarios", "Acessou Cadastro de Usuários do Sistema");
                }
                return;
            }
            if (Global.Margem.CadastroUsuarios == "não")
            {
                MessageBox.Show("Acesso não autorizado");
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
            if (Global.Margem.ExpirouLicença == "sim")
            {
                Application.Exit();
            }
            if (Global.Margem.CaixaTerminalVendas == "adm")
            {
                string linha;
                try
                {
                    using (StreamReader reader = new StreamReader("CaixaAberto.txt"))
                    {
                        linha = reader.ReadLine();
                    }
                }
                catch (Exception)
                {


                    linha = "não";
                }
                
                if (linha == "não")
                {
                    pictureBox17.Visible = true;
                    Form abre = new AbrirCaixa();
                    abre.ShowDialog();
                    pictureBox17.Visible = false; ;
                    if (Global.Margem.SemContaCadastrada == "sim")
                    {
                        Global.Margem.SemContaCadastrada = "";
                        return;
                    }
                    Form frente = new PDV();
                    GerenciadorDeFormulario.Abre(frente);
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CaixaTerminalVendas", "Acessou Caixa / Terminal de Vendas");
                    }
                }
                if (linha == "sim")
                {
                    string conta;
                    try
                    {
                        using (StreamReader reader = new StreamReader("Conta.txt"))
                        {
                            conta = reader.ReadLine();
                            Global.Margem.ContaAberta = conta;
                        }
                    }
                    catch (Exception)
                    {


                        conta = "";
                    }
                    string valor;
                    try
                    {
                        using (StreamReader reader = new StreamReader("Valor.txt"))
                        {
                            valor = reader.ReadLine();
                            Global.Margem.ValorAberto = valor;
                        }
                    }
                    catch (Exception)
                    {


                        valor = "";
                    }
                    if (String.IsNullOrEmpty(valor) == true || String.IsNullOrEmpty(conta) == true)
                    {
                        using (StreamWriter writer = new StreamWriter("CaixaAberto.txt"))
                        {
                            writer.Write("não");
                            return;
                        }
                    }
                    string empresa;
                    try
                    {
                        using (StreamReader reader = new StreamReader("Empresa.txt"))
                        {
                            empresa = reader.ReadLine();
                            Global.Margem.EmpresaCaixa = empresa;
                        }
                    }
                    catch (Exception)
                    {


                        conta = "";
                    }
                    
                    
                    pictureBox17.Visible = true;
                    Form al = new Alert2();
                    al.ShowDialog();
                    
                    Form frente = new PDV();
                    GerenciadorDeFormulario.Abre(frente);
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CaixaTerminalVendas", "Acessou Caixa / Terminal de Vendas");
                    }
                    pictureBox17.Visible = false;
                    //carrega conf de caixa aberto
                }

                return;
            }
            if (Global.Margem.CaixaTerminalVendas == "sim")
            {
                string linha;
                try
                {
                    using (StreamReader reader = new StreamReader("CaixaAberto.txt"))
                    {
                        linha = reader.ReadLine();
                    }
                }
                catch (Exception)
                {


                    linha = "não";
                }

                if (linha == "não")
                {
                    pictureBox17.Visible = true;
                    Form abre = new AbrirCaixa();
                    abre.ShowDialog();
                    pictureBox17.Visible = false; 
                    if (Global.Margem.SemContaCadastrada == "sim")
                    {
                        Global.Margem.SemContaCadastrada = "";
                        return;
                    }
                    Form frente = new PDV();
                    GerenciadorDeFormulario.Abre(frente);
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CaixaTerminalVendas", "Acessou Caixa / Terminal de Vendas");
                    }
                }
                if (linha == "sim")
                {
                    string conta;
                    try
                    {
                        using (StreamReader reader = new StreamReader("Conta.txt"))
                        {
                            conta = reader.ReadLine();
                            Global.Margem.ContaAberta = conta;
                        }
                    }
                    catch (Exception)
                    {


                        conta = "";
                    }
                    string valor;
                    try
                    {
                        using (StreamReader reader = new StreamReader("Valor.txt"))
                        {
                            valor = reader.ReadLine();
                            Global.Margem.ValorAberto = valor;
                        }
                    }
                    catch (Exception)
                    {


                        valor = "";
                    }
                    if (String.IsNullOrEmpty(valor) == true || String.IsNullOrEmpty(conta) == true)
                    {
                        using (StreamWriter writer = new StreamWriter("CaixaAberto.txt"))
                        {
                            writer.Write("não");
                            return;
                        }
                    }
                    MessageBox.Show("[ Este Caixa não foi Finalizado / Fechado e será reaberto. ]");
                    Form frente = new PDV();
                    GerenciadorDeFormulario.Abre(frente);
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CaixaTerminalVendas", "Acessou Caixa / Terminal de Vendas");
                    }
                    //carrega conf de caixa aberto
                }

                return;
            }
            if (Global.Margem.CaixaTerminalVendas == "não")
            {
                MessageBox.Show("Acesso não autorizado");
            }
            
            
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
            if (Global.Margem.ExpirouLicença == "sim")
            {
                Application.Exit();
            }
            if (Global.Margem.FluxoDeCaixa == "adm")
            {
                Form movCaixa = new MovimentoCaixa();
                GerenciadorDeFormulario.Abre(movCaixa);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("FluxoCaixa", "Acessou Fluxo de Caixa");
                }
                return;
            }
            if (Global.Margem.FluxoDeCaixa == "sim")
            {
                Form movCaixa = new MovimentoCaixa();
                GerenciadorDeFormulario.Abre(movCaixa);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("FluxoCaixa", "Acessou Fluxo de Caixa");
                }
                return;
            }
            if (Global.Margem.FluxoDeCaixa == "não")
            {
                MessageBox.Show("Acesso não autorizado");
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
           
            if (Global.Margem.Logs == "adm")
            {
                Ferramentas.Dedo_Duro();
                Form log = new LOGs();
                GerenciadorDeFormulario.Abre(log);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("LOG", "Acessou LOGs do Sistema");
                }
                return;
            }
            if (Global.Margem.Logs == "sim")
            {
                Ferramentas.Dedo_Duro();
                Form log = new LOGs();
                GerenciadorDeFormulario.Abre(log);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("LOG", "Acessou LOGs do Sistema");
                }
                return;
            }
            if (Global.Margem.Logs == "não")
            {
                MessageBox.Show("Acesso não autorizado");
            }     
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
            if (Global.Margem.ExpirouLicença == "sim")
            {
                Application.Exit();
            }
            if (Global.Margem.ConfiguraçãoSistema == "adm")
            {
                Form conf = new Config();
                GerenciadorDeFormulario.Abre(conf);

                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("config","Acessou Configurações do Sistema");
                }
                return;
            }
            if (Global.Margem.ConfiguraçãoSistema == "sim")
            {
                Form conf = new Config();
                GerenciadorDeFormulario.Abre(conf);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("config", "Acessou Configurações do Sistema");
                }
                return;
            }
            if (Global.Margem.ConfiguraçãoSistema == "não")
            {
                MessageBox.Show("Acesso não autorizado");
            }     
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            
            pictureBox17.Visible = true;
            Form login = new Login();
            login.ShowDialog();
            GerenciadorDeFormulario.Fecha(login);
            pictureBox17.Visible = false;
            DataTable cor = DALCadastro.CoresRetorna(Global.Margem.Operador);

            if (cor.Rows.Count > 0)
            {
                panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor5"].ToString()));
            }
        }

        private void TelaPrincipal_Load(object sender, EventArgs e)
        {

            string impressora;
            try
            {
                using (StreamReader reader = new StreamReader("Impressora.txt"))
                {
                    impressora = reader.ReadLine();
                    Global.Margem.Impressora = impressora;
                }
            }
            catch (Exception)
            {


                impressora = "";
            }
            if (String.IsNullOrEmpty(impressora) == true)
            {
                using (StreamWriter writer = new StreamWriter("Impressora.txt"))
                {
                    writer.Write("generic");
                    Global.Margem.Impressora = "generic";

                }
            }
            string impressao;
            try
            {
                using (StreamReader reader = new StreamReader("SI.txt"))
                {
                    impressao = reader.ReadLine();
                    Global.Margem.ServidorImpressao = impressao;
                }
            }
            catch (Exception)
            {


                impressao = "";
            }
            if (String.IsNullOrEmpty(impressao) == true)
            {
                using (StreamWriter writer = new StreamWriter("SI.txt"))
                {
                    writer.Write("não");
                    Global.Margem.ServidorImpressao = "não";
                    
                }
            }
            if (Global.Margem.ServidorImpressao == "sim")
            {
                Form impres = new ServidorImpressao();
                impres.Show();

            }
            string linha;
            try
            {
                using (StreamReader reader = new StreamReader("BD.txt"))
                {
                    linha = reader.ReadLine();
                }
            }
            catch (Exception)
            {
                
               
                linha = "local";
            }
           
            if (linha == "local")
            {
                Global.Margem.ConfiguraçãoSistemaBancoDados = "local";
            }
            if (linha == "rede")
            {
                Global.Margem.ConfiguraçãoSistemaBancoDados = "rede";
                using (StreamReader reader = new StreamReader("BDIp.txt"))
                {

                    Global.Margem.ConfiguraçãoSistemaBancoDadosIp = reader.ReadLine();
                }
                using (StreamReader reader = new StreamReader("BDPorta.txt"))
                {

                    Global.Margem.ConfiguraçãoSistemaBancoDadosPorta = reader.ReadLine();
                }

            }
            string log;
            try
            {
                using (StreamReader reader = new StreamReader("LOG.txt"))
                {
                    log = reader.ReadLine();
                }
            }
            catch (Exception)
            {


                log = "sim";
            }

            if (log == "sim")
            {
                Global.Margem.ConfiguraçãoSistemaLOGs = "sim";
                
            }
            if (log == "não")
            {
                Global.Margem.ConfiguraçãoSistemaLOGs = "não";
                
            }
            
            
            pictureBox17.Visible = true;
            Form login = new Login();
            login.ShowDialog();
            
            GerenciadorDeFormulario.Fecha(login);
            pictureBox17.Visible = false;
            
            DataTable cor = DALCadastro.CoresRetorna(Global.Margem.Operador);
            
            if (cor.Rows.Count > 0)
            {
                panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor5"].ToString()));  
            }
            DataTable inicio = DALCadastro.TestaConfiVazia("1");
            if (inicio.Rows.Count > 0)
            {
                Global.Margem.ConfiguraçãoSistemaFinanceiroMargem = inicio.Rows[0]["Campo1"].ToString();
                Global.Margem.ConfiguraçãoSistemaFinanceiroImpostos = inicio.Rows[0]["Campo2"].ToString();
                Global.Margem.ConfiguraçãoSistemaFinanceiroComissão = inicio.Rows[0]["Campo3"].ToString();
            }
            inicio.Clear();
            inicio = DALCadastro.TestaConfiVazia("2");
            if (inicio.Rows.Count > 0)
            {
                Global.Margem.ConfiguraçãoSistemaEstoque = inicio.Rows[0]["Campo1"].ToString();
                
            }
            inicio.Clear();
            inicio = DALCadastro.TestaConfiVazia("3");
            if (inicio.Rows.Count > 0)
            {
                Global.Margem.ConfiguraçãoSistemaLOGs = inicio.Rows[0]["Campo1"].ToString();
                
            }
            inicio.Clear();
            inicio = DALCadastro.TestaConfiVazia("4");
            if (inicio.Rows.Count > 0)
            {
                Global.Margem.ConfiguraçãoSistemaCaixaTerminalVendas = inicio.Rows[0]["Campo1"].ToString();               
            }
            Ferramentas.CriaLog("Login","Fez Login no Sistema");
            //listar avisos
            string dia = DateTime.Now.Day.ToString();
            if (dia.Length == 1)
            {
                dia = "0" + dia;  
            }
            string mes = DateTime.Now.Month.ToString();
            if (mes.Length == 1)
            {
                mes = "0" + mes;
            }
            string ano = DateTime.Now.Year.ToString();
            int compara = Convert.ToInt32(ano + mes + dia);
            
            DataTable list = DALCadastro.ListaEventos();
            if (list.Rows.Count > 0)
            {
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    int temp = Convert.ToInt32( list.Rows[i]["DataGatilho"].ToString());
                    if (temp <= compara )
                    {
                        pictureBox17.Visible = true;
                        Form al = new Alert();
                        al.ShowDialog();
                        if (Global.Margem.AbreAviso == "sim")
                        {
                            Form av = new Avisos();
                            av.ShowDialog();
                        }
                        else
                        {
                            pictureBox17.Visible = false;
                        }
                        if (Global.Margem.AbreAviso == "ok")
                        {
                            pictureBox17.Visible = false;
                        }
                        else
                        {
                            pictureBox17.Visible = false;
                        }
                        Global.Margem.AbreAviso = "";
                        return;
                    }
                }
            }
            
          
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
            if (Global.Margem.ExpirouLicença == "sim")
            {
                Application.Exit();
            }
            pictureBox17.Visible = true;
            Form licença = new Licenca();
            licença.ShowDialog();
            
            licença.Close();
            pictureBox17.Visible = false;
            
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            
            pictureBox17.Visible = true;
            Form sobre = new Sobre();
            sobre.ShowDialog();
            pictureBox17.Visible = false;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
            if (Global.Margem.ExpirouLicença == "sim")
            {
                Application.Exit();
            }
            if (Global.Margem.CadastroParticipantes == "adm")
            {
                Form cadPart = new CadastroParticipantes();
                GerenciadorDeFormulario.Abre(cadPart);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    
                    Ferramentas.CriaLog("CadParticipantes", "Acessou Cadastro de Participantes do Sistema");   
                }
                return;
            }
            if (Global.Margem.CadastroParticipantes == "sim" )
            {
                Form cadPart = new CadastroParticipantes();
                GerenciadorDeFormulario.Abre(cadPart);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("CadParticipantes", "Acessou Cadastro de Participantes do Sistema");
                }
                return;
            }
            if (Global.Margem.CadastroParticipantes == "não" )
            {
                MessageBox.Show("Acesso não autorizado");
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Disponível em futuras atualizações");
            //Form print = new ServidorImpressao();
            //print.Show();
        }

        private void pictureBox18_Click_1(object sender, EventArgs e)
        {
            pictureBox17.Visible = true;

            Form cores = new CadCores();
            cores.ShowDialog();
            pictureBox17.Visible = false;
            DataTable cor10 = DALCadastro.CoresRetorna(Global.Margem.Operador);
            if (cor10.Rows.Count > 0)
            {
                panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor5"].ToString()));
            }
            else
            {
                DataTable cor2 = DALCadastro.CoresRetorna("Default");
                if (cor2.Rows.Count > 0)
                {
                    panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor2.Rows[0]["Cor5"].ToString()));
                }
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
            if (Global.Margem.ExpirouLicença == "sim")
            {
                Application.Exit();
            }
            if (Global.Margem.ContasReceber == "adm")
            {
                Form contarecebe = new ContasReceber();
                GerenciadorDeFormulario.Abre(contarecebe);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("ContasReceber", "Acessou Cadastro de contas a Receber");
                }
                return;
            }
            if (Global.Margem.ContasReceber == "sim")
            {
                Form contarecebe = new ContasReceber();
                GerenciadorDeFormulario.Abre(contarecebe);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("ContasReceber", "Acessou Cadastro de contas a Receber");
                }
                return;
            }
            if (Global.Margem.ContasReceber == "não")
            {
                MessageBox.Show("Acesso não autorizado");
            }
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = System.Drawing.Color.Red;
            groupBox2.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = System.Drawing.Color.Black;
            groupBox2.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            label12.ForeColor = System.Drawing.Color.Red;
            groupBox7.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            label12.ForeColor = System.Drawing.Color.Black;
            groupBox7.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            label10.ForeColor = System.Drawing.Color.Red;
            groupBox6.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = System.Drawing.Color.Black;
            groupBox6.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = System.Drawing.Color.Red;
            groupBox6.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = System.Drawing.Color.Black;
            groupBox6.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            label11.ForeColor = System.Drawing.Color.Red;
            groupBox6.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            label11.ForeColor = System.Drawing.Color.Black;
            groupBox6.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = System.Drawing.Color.Red;
            groupBox2.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = System.Drawing.Color.Black;
            groupBox2.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Red;
            groupBox2.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Black;
            groupBox2.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox18_MouseEnter(object sender, EventArgs e)
        {
            label13.ForeColor = System.Drawing.Color.Red;
            groupBox2.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox18_MouseLeave(object sender, EventArgs e)
        {
            label13.ForeColor = System.Drawing.Color.Black;
            groupBox2.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox19_MouseEnter(object sender, EventArgs e)
        {
            label14.ForeColor = System.Drawing.Color.Red;
            groupBox2.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox19_MouseLeave(object sender, EventArgs e)
        {
            label14.ForeColor = System.Drawing.Color.Black;
            groupBox2.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox20_MouseEnter(object sender, EventArgs e)
        {
            label15.ForeColor = System.Drawing.Color.Red;
            groupBox2.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox20_MouseLeave(object sender, EventArgs e)
        {
            label15.ForeColor = System.Drawing.Color.Black;
            groupBox2.BackColor = System.Drawing.Color.Transparent;
        }
       

    }
}
