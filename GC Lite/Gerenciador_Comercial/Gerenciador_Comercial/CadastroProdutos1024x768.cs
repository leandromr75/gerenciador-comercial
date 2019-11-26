using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class CadastroProdutos1024x768 : Form
    {
        public CadastroProdutos1024x768()
        {
            InitializeComponent();
        }

        int contador = 0;
        //string usuarioAtivo = "Leandro Mendonça Ribeiro";
        public void limpaForm()
        {

            textBox33.Text = "";
            textBox16.Text = "";
            textBox2.Text = "1";


            //this.Text = "Cadastro de Produtos e Serviços" + " ==> Operador:  " + usuarioAtivo;
            panel1.Width = 0;
            panel10.Width = 0;
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                if (pictureBox5.Image == null)
                {
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                }
                else
                {
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = true;
                }
            }
        }
        public void inicializaForm()
        {


            this.Text = "Cadastro de Produtos e Serviços" + " ==> Operador:  " + Global.Margem.Operador;
    
            panel1.Width = 0;
            panel10.Width = 0;
            if (String.IsNullOrEmpty(label93.Text) == false)
            {
                string strConnection = "";
                if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
                {
                    strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                }
                if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
                {
                    string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                    string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                    strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975";
                }
                string id = label93.Text;

                string strSQL = "Abre_imagem";

                //cria a conexão com o banco de dados
                OleDbConnection dbConnection = new OleDbConnection(strConnection);

                //cria a conexão com o banco de dados
                OleDbConnection con = new OleDbConnection(strConnection);
                //cria o objeto command para executar a instruçao sql
                OleDbCommand cmd = new OleDbCommand(strSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                //abre a conexao

                cmd.Parameters.AddWithValue("@identificador", id);
                //cmd.Parameters.AddWithValue(imagem, pictureBox1.Image);

                // cria o objeto SqlDataReader e carrega-o com os dados obtidos SqlDataReader DataReader; DataReader = Command.ExecuteReader();

                //cria o objeto SqlDataReader e carrega-o com os dados obtidos 
                Image imagem = null;
                byte[] imagem_aray = (byte[])cmd.ExecuteScalar();
                MemoryStream ms = new MemoryStream(imagem_aray);
                imagem = Image.FromStream(ms);
                pictureBox5.Image = imagem;







                //define o tipo do comando 

                //cria um dataadapter
                //OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                //cria um objeto datatable
                //DataTable clientes = new DataTable();

                //preenche o datatable via dataadapter
                //da.Fill(clientes);
                con.Dispose();
                con.Close();
                cmd.Dispose();
                dbConnection.Dispose();
                dbConnection.Close();
            }
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                if (pictureBox5.Image == null)
                {
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                }
                else
                {
                    button1.Visible = false;
                    button2.Visible = false;
                    button3.Visible = true;
                }
            }
            DataTable cor10 = DALCadastro.CoresRetorna(Global.Margem.Operador.ToString());
            if (cor10.Rows.Count > 0)
            {
                panel9.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["CorMenu"].ToString()));
                panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor2"].ToString()));
                tabPage3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));
                tabPage4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));
                tabPage5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));
                tabPage6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));
                tabPage7.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));
                tabPage8.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));
                tabPage9.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));

                panel3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor4"].ToString()));
                panel4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor4"].ToString()));
                panel5.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor4"].ToString()));
                panel6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor4"].ToString()));
                panel7.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor4"].ToString()));
                panel8.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor4"].ToString()));
            }
        }
        public void abrirRegistro(DataTable produtos)
        {
            if (produtos.Rows.Count > 0)
            {

                if (String.IsNullOrEmpty(label92.Text) == true)
                {
                    comboBox1.DataSource = DALCadastro.Listar_Finalidade();
                    comboBox1.ValueMember = "Descrição";
                    comboBox1.DisplayMember = "Descricao";
                    comboBox1.SelectedItem = "";
                    comboBox1.Refresh();
                    comboBox1.Text = "SELECIONAR";
                    //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
                    //fim
                    progressBar1.PerformStep();
                    label128.Text = "30%";
                    //preencher comboBox familia
                    //comboBox2.Items.Clear();
                    comboBox2.DataSource = DALCadastro.AUXCadListar("ListarCadFamilia");
                    comboBox2.ValueMember = "Descrição";
                    comboBox2.DisplayMember = "Descricao";
                    comboBox2.SelectedItem = "";
                    comboBox2.Refresh();
                    comboBox2.Text = "SELECIONAR";
                    //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
                    //fim

                    //barra progresso 60%
                    label128.Text = "40%";
                    progressBar1.PerformStep();


                    //preencher comboBox marca
                    //comboBox3.Items.Clear();
                    comboBox3.DataSource = DALCadastro.AUXCadListar("ListarCadMarca");
                    comboBox3.ValueMember = "Descrição";
                    comboBox3.DisplayMember = "Descricao";
                    comboBox3.SelectedItem = "";
                    comboBox3.Refresh();
                    comboBox3.Text = "SELECIONAR";
                    //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
                    //fim
                    //preencher comboBox modelo
                    //comboBox4.Items.Clear();
                    comboBox4.DataSource = DALCadastro.AUXCadListar("ListarCadModelo");
                    comboBox4.ValueMember = "Descrição";
                    comboBox4.DisplayMember = "Descricao";
                    comboBox4.SelectedItem = "";
                    comboBox4.Refresh();
                    comboBox4.Text = "SELECIONAR";
                    //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
                    //fim
                    progressBar1.PerformStep();
                    label128.Text = "50%";
                    //preencher comboBox unidade
                    //comboBox5.Items.Clear();
                    comboBox5.DataSource = DALCadastro.AUXCadListar("ListarCadUnidade");
                    comboBox5.ValueMember = "Descrição";
                    comboBox5.DisplayMember = "Descricao";
                    comboBox5.SelectedItem = "";
                    comboBox5.Refresh();
                    comboBox5.Text = "SELECIONAR";
                    //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
                    //fim

                    //barra progresso 80%
                    label128.Text = "60%";
                    progressBar1.PerformStep();


                    //preencher comboBox genero
                    //comboBox6.Items.Clear();
                    comboBox6.DataSource = DALCadastro.AUXCadListar("ListarCadGenero");
                    comboBox6.ValueMember = "Codigo";
                    comboBox6.DisplayMember = "Codigo";
                    comboBox6.SelectedItem = "";
                    comboBox6.Refresh();
                    //comboBox6.Text = "SELECIONAR";
                    //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
                    //fim
                    //preencher comboBox NCM
                    //comboBox8.Items.Clear();
                    comboBox8.DataSource = DALCadastro.AUXCadListar("ListarCadNCM");
                    comboBox8.ValueMember = "Codigo_NCM";
                    comboBox8.DisplayMember = "Codigo_NCM";
                    comboBox8.SelectedItem = "";
                    comboBox8.Refresh();
                    //comboBox8.Text = "SELECIONAR";
                    //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
                    //fim
                    progressBar1.PerformStep();
                    label128.Text = "70%";
                    //preencher comboBox moeda compra
                    //comboBox9.Items.Clear();
                    comboBox9.DataSource = DALCadastro.AUXCadListar("ListarCadMoeda");
                    comboBox9.ValueMember = "Descrição";
                    comboBox9.DisplayMember = "Descricao";
                    comboBox9.SelectedItem = "";
                    comboBox9.Refresh();
                    comboBox9.Text = "SELECIONAR";
                    //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
                    //fim
                    progressBar1.PerformStep();
                    label128.Text = "80%";
                    //preencher comboBox marca
                    //comboBox10.Items.Clear();
                    comboBox10.DataSource = DALCadastro.AUXCadListar("ListarCadMoeda");
                    comboBox10.ValueMember = "Descrição";
                    comboBox10.DisplayMember = "Descricao";
                    comboBox10.SelectedItem = "";
                    comboBox10.Refresh();
                    comboBox10.Text = "SELECIONAR";
                    //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
                    //fim
                    progressBar1.PerformStep();
                    label128.Text = "100%";
                    //preencher comboBox Empresa
                    //comboBox11.Items.Clear();
                    comboBox11.DataSource = DALCadastro.AUXCadListar("ListarCadEmpresa");
                    comboBox11.ValueMember = "Descrição";
                    comboBox11.DisplayMember = "Descricao";
                    comboBox11.SelectedItem = "";
                    comboBox11.Refresh();
                    comboBox11.Text = "SELECIONAR";
                }

                //||||||identificador==>0||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["IdProd"].ToString())) == false)
                {
                    label93.Text = Convert.ToString(produtos.Rows[0]["IdProd"].ToString());
                }
                //||||||revisão==>1||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Revisão"].ToString())) == false)
                {
                    label92.Text = Convert.ToString(produtos.Rows[0]["Revisão"].ToString());
                }
                //||||||CodDNF==>2||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CodDNF"].ToString())) == false)
                {
                    textBox1.Text = Convert.ToString(produtos.Rows[0]["CodDNF"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CodDNF"].ToString())) == true)
                {
                    textBox1.Text = "";
                }
                //||||||CodEAN==>3||||||||||
                textBox9.ReadOnly = false;
                checkBox5.Enabled = true;
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CodEAN"].ToString())) == false)
                {
                    textBox9.Text = Convert.ToString(produtos.Rows[0]["CodEAN"].ToString());
                    Global.Margem.EANTemp = Convert.ToString(produtos.Rows[0]["CodEAN"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CodEAN"].ToString())) == true)
                {
                    textBox9.Text = "";
                }
                //|||||CodEANTrib==>4||||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CodEANTrib"].ToString())) == false)
                {
                    textBox3.Text = Convert.ToString(produtos.Rows[0]["CodEANTrib"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CodEANTrib"].ToString())) == true)
                {
                    textBox3.Text = "";
                }
                //|||||CodFornecimento==>5|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CodFornecimento"].ToString())) == false)
                {
                    textBox6.Text = Convert.ToString(produtos.Rows[0]["CodFornecimento"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CodFornecimento"].ToString())) == true)
                {
                    textBox6.Text = "";
                }
                //|||||referência==>6|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Referência"].ToString())) == false)
                {
                    textBox5.Text = Convert.ToString(produtos.Rows[0]["Referência"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Referência"].ToString())) == true)
                {
                    textBox5.Text = "";
                }
                //|||||Inativo==>7|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Inativo"].ToString())) == false)
                {
                    if (Convert.ToChar(produtos.Rows[0]["Inativo"].ToString()) == 'S')
                    {
                        checkBox1.Checked = true;
                    }
                    if (Convert.ToChar(produtos.Rows[0]["Inativo"].ToString()) == 'N')
                    {
                        checkBox1.Checked = false;
                    }
                }
                //|||||Finalidade==>8|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Finalidade"].ToString())) == false)
                {

                    comboBox1.Text = (Convert.ToString(produtos.Rows[0]["Finalidade"].ToString()));

                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Finalidade"].ToString())) == true)
                {

                    comboBox1.Text = "SELECIONAR";

                }

                //|||||Familia==>9|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Familia"].ToString())) == false)
                {

                    comboBox2.Text = (Convert.ToString(produtos.Rows[0]["Familia"].ToString()));

                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Familia"].ToString())) == true)
                {

                    comboBox2.Text = "SELECIONAR";

                }
                //|||||Marca==>10|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Marca"].ToString())) == false)
                {

                    comboBox3.Text = (Convert.ToString(produtos.Rows[0]["Marca"].ToString()));

                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Marca"].ToString())) == true)
                {

                    comboBox3.Text = "SELECIONAR";

                }
                //|||||Modelo==>11|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Modelo"].ToString())) == false)
                {
                    comboBox4.Text = Convert.ToString(produtos.Rows[0]["Modelo"].ToString());

                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Modelo"].ToString())) == true)
                {

                    comboBox4.Text = "SELECIONAR";

                }
                //|||||Unidade==>12|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Unidade"].ToString())) == false)
                {

                    comboBox5.Text = Convert.ToString(produtos.Rows[0]["Unidade"].ToString());

                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Unidade"].ToString())) == true)
                {

                    comboBox5.Text = "SELECIONAR";

                }
                //|||||DescInterna==>13|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["DescInterna"].ToString())) == false)
                {
                    textBox10.Text = Convert.ToString(produtos.Rows[0]["DescInterna"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["DescInterna"].ToString())) == true)
                {
                    textBox10.Text = "";
                }
                //|||||Grade==>14|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Grade"].ToString())) == false)
                {
                    textBox15.Text = Convert.ToString(produtos.Rows[0]["Grade"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Grade"].ToString())) == true)
                {
                    textBox15.Text = "";
                }
                //|||||Gênero==>15|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Gênero"].ToString())) == false)
                {

                    comboBox6.Text = Convert.ToString(produtos.Rows[0]["Gênero"].ToString());

                }
                //|||||CF_NCM==>16|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CF_NCM"].ToString())) == false)
                {

                    comboBox8.Text = Convert.ToString(produtos.Rows[0]["CF_NCM"].ToString());

                }
                //|||||EX_IPI==>17|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["EX_IPI"].ToString())) == false)
                {
                    textBox18.Text = Convert.ToString(produtos.Rows[0]["EX_IPI"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["EX_IPI"].ToString())) == true)
                {
                    textBox18.Text = "";
                }
                //|||||MoedaCompra==>18|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["MoedaCompra"].ToString())) == false)
                {

                    comboBox9.Text = Convert.ToString(produtos.Rows[0]["MoedaCompra"].ToString());

                }
                //|||||MoedaFaturamento==>19|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["MoedaFaturamento"].ToString())) == false)
                {

                    comboBox10.Text = Convert.ToString(produtos.Rows[0]["MoedaFaturamento"].ToString());

                }
                //|||||PesoBruto==>20|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["PesoBruto"].ToString())) == false)
                {
                    textBox21.Text = Convert.ToString(produtos.Rows[0]["PesoBruto"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["PesoBruto"].ToString())) == true)
                {
                    textBox21.Text = "";
                }
                //|||||PesoLiquido==>21|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["PesoLiquido"].ToString())) == false)
                {
                    textBox20.Text = Convert.ToString(produtos.Rows[0]["PesoLiquido"].ToString());
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["PesoLiquido"].ToString())) == true)
                {
                    textBox20.Text = "";
                }
                //|||||Empresa==>22|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Empresa"].ToString())) == false)
                {

                    comboBox11.Text = Convert.ToString(produtos.Rows[0]["Empresa"].ToString());

                }


                //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
                //|||||||||||||||||||Preenche campos adicionais||||||||||||||||||||
                //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||


                //||||||Nome Original NF==>23||||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["NomeOriginalNF"].ToString())) == false)
                {

                    textBox32.Text = Convert.ToString(produtos.Rows[0]["NomeOriginalNF"].ToString());

                }
                //||||||Nome do Fabricante==>24||||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["NomeFabricante"].ToString())) == false)
                {

                    textBox31.Text = Convert.ToString(produtos.Rows[0]["Empresa"].ToString());

                }
                //|||||Observações==>25||||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Observações"].ToString())) == false)
                {

                    textBox30.Text = Convert.ToString(produtos.Rows[0]["Observações"].ToString());

                }
                //|||||Grupo de compradores==>26|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["GrupoCompradores"].ToString())) == false)
                {

                    comboBox12.Text = Convert.ToString(produtos.Rows[0]["GrupoCompradores"].ToString());

                }
                //|||||Garantia==>27|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Garantia"].ToString())) == false)
                {

                    textBox28.Text = Convert.ToString(produtos.Rows[0]["Garantia"].ToString());

                }
                //|||||Início==>28|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Início"].ToString())) == false)
                {

                    dateTimePicker1.Text = Convert.ToString(produtos.Rows[0]["Início"].ToString());

                }
                //|||||Final==>29|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Final"].ToString())) == false)
                {

                    dateTimePicker2.Text = Convert.ToString(produtos.Rows[0]["Final"].ToString());

                }
                //|||||Método de Suprimento==>30|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["MétodoSuprimento"].ToString())) == false)
                {

                    comboBox16.Text = Convert.ToString(produtos.Rows[0]["MétodoSuprimento"].ToString());

                }
                //|||||Impacto==>31|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Impacto"].ToString())) == false)
                {

                    textBox24.Text = Convert.ToString(produtos.Rows[0]["Impacto"].ToString());

                }
                //|||||Original==>32|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Original"].ToString())) == false)
                {

                    if (Convert.ToString(produtos.Rows[0]["Original"].ToString()) == "S")
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }

                }
                //|||||DataCadastro==>32|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["DataCadastro"].ToString())) == false)
                {

                    label67.Text = Convert.ToString(produtos.Rows[0]["DataCadastro"].ToString());

                }
                //|||||usuario cadastrou==>33|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["UsrCadastrou"].ToString())) == false)
                {

                    textBox23.Text = Convert.ToString(produtos.Rows[0]["UsrCadastrou"].ToString());

                }
                //|||||grupo tributario saídas==>34|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["GrupoTribSaídas"].ToString())) == false)
                {

                    comboBox17.Text = Convert.ToString(produtos.Rows[0]["GrupoTribSaídas"].ToString());

                }
                //|||||Grupo tributario entradas==>35|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["GrupoTribEntradas"].ToString())) == false)
                {

                    textBox38.Text = Convert.ToString(produtos.Rows[0]["GrupoTribEntradas"].ToString());

                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["GrupoTribEntradas"].ToString())) == true)
                {

                    textBox38.Text = "";

                }

                //|||||CodServiçoSefaz==>36|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CodServiçoSefaz"].ToString())) == false)
                {

                    comboBox19.Text = Convert.ToString(produtos.Rows[0]["CodServiçoSefaz"].ToString());

                }
                //|||||IPI==>37|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["IPI"].ToString())) == false)
                {

                    comboBox17.Text = Convert.ToString(produtos.Rows[0]["IPI"].ToString());

                }
                //|||||VenderPro==>38|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["VenderPro"].ToString())) == false)
                {

                    comboBox7.Text = Convert.ToString(produtos.Rows[0]["VenderPro"].ToString());
                    if (produtos.Rows[0]["VenderPro"].ToString() == "Preço" || produtos.Rows[0]["VenderPro"].ToString() == "Peso")
                    {
                        comboBox7.Visible = true;

                        checkBox5.Enabled = true;
                        Global.Margem.VenderPeso = "true";
                        checkBox5.Checked = true;
                    }
                    else
                    {
                        comboBox7.Visible = true;
                        comboBox7.Text = "não";
                        Global.Margem.VenderPeso = "false";
                        checkBox5.Checked = false;
                    }

                }
                else
                {
                    comboBox7.Text = "não";
                    Global.Margem.VenderPeso = "false";
                    checkBox5.Checked = false;
                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["VenderPro"].ToString())) == true)
                {
                    comboBox7.Text = "não";
                }
                //|||||ValorInicial==>39|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["ValorInicial"].ToString())) == false)
                {

                    textBox7.Text = Convert.ToString(produtos.Rows[0]["ValorInicial"].ToString());

                }
                //|||||ValorMédio==>40|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["ValorMédio"].ToString())) == false)
                {

                    textBox4.Text = Convert.ToString(produtos.Rows[0]["ValorMédio"].ToString());

                }
                //|||||DescCompra==>41|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["DescCompra"].ToString())) == false)
                {

                    textBox11.Text = Convert.ToString(produtos.Rows[0]["DescCompra"].ToString());

                }
                //|||||valor de compra==>42|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["ValorCompra"].ToString())) == false)
                {

                    string custo = Convert.ToString(produtos.Rows[0]["ValorCompra"].ToString());
                    string virgula = "";
                    for (int i = 0; i < custo.Length; i++)
                    {
                        if (virgula == "")
                        {
                            if (custo.Substring(i, 1) == "," || custo.Substring(i, 1) == ".")
                            {
                                virgula = custo.Substring(0, i + 3);
                            }
                        }
                    }
                    textBox8.Text = virgula;

                }
                //|||||Custo Corrigido==>43|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["CustoCorrigido"].ToString())) == false)
                {

                    textBox12.Text = Convert.ToString(produtos.Rows[0]["CustoCorrigido"].ToString());

                }
                //|||||Margem Inversa==>44|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["MargemInversa"].ToString())) == false)
                {

                    if (Convert.ToString(produtos.Rows[0]["MargemInversa"].ToString()) == "S")
                    {
                        checkBox3.Checked = true;
                    }
                    else
                    {
                        checkBox3.Checked = false;
                    }

                }
                //|||||Margem==>45|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Margem"].ToString())) == false)
                {

                    textBox33.Text = Convert.ToString(produtos.Rows[0]["Margem"].ToString());

                }
                textBox16.ReadOnly = true;
                //|||||valor venda==>46|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["ValorVenda"].ToString())) == false)
                {

                    textBox16.Text = Convert.ToString(produtos.Rows[0]["ValorVenda"].ToString());

                }
                //|||||Venda Corrigido==>47|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["VendaCorrigido"].ToString())) == false)
                {

                    textBox14.Text = Convert.ToString(produtos.Rows[0]["VendaCorrigido"].ToString());

                }
                //|||||Valor Mínimo==>48|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["ValorMínimo"].ToString())) == false)
                {

                    textBox25.Text = Convert.ToString(produtos.Rows[0]["ValorMínimo"].ToString());

                }
                //|||||Margem Mínima==>49|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["MargemMínima"].ToString())) == false)
                {

                    textBox22.Text = Convert.ToString(produtos.Rows[0]["MargemMínima"].ToString());

                }
                //|||||Valor promoção==>50|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["ValorPromoção"].ToString())) == false)
                {

                    textBox19.Text = Convert.ToString(produtos.Rows[0]["ValorPromoção"].ToString());

                }
                //|||||Ativar promoção==>51|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Promoção"].ToString())) == false)
                {

                    if (Convert.ToString(produtos.Rows[0]["Promoção"].ToString()) == "S")
                    {
                        checkBox4.Checked = true;
                    }
                    else
                    {
                        checkBox4.Checked = false;
                    }

                }
                //|||||Grupo de carregamento==>52|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["GrupoCarregamento"].ToString())) == false)
                {

                    comboBox22.Text = Convert.ToString(produtos.Rows[0]["GrupoCarregamento"].ToString());

                }
                //|||||Múltiplo==>53|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["Múltiplo"].ToString())) == false)
                {

                    textBox17.Text = Convert.ToString(produtos.Rows[0]["Múltiplo"].ToString());

                }
                //|||||Estoque==>54|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["EstoqueINT"].ToString())) == false)
                {

                    textBox2.Text = Convert.ToString(produtos.Rows[0]["EstoqueINT"].ToString());

                }
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["EstoquePeso"].ToString())) == false)
                {
                    if (produtos.Rows[0]["VenderPro"].ToString() == "Preço" || produtos.Rows[0]["VenderPro"].ToString() == "Peso")
                    {
                        decimal resultado2 = Convert.ToDecimal(produtos.Rows[0]["EstoquePeso"].ToString()) / 1000;
                        //decimal resultado4 = Convert.ToDecimal(produtos.Rows[0]["EstoquePeso"].ToString()) / Convert.ToDecimal( produtos.Rows[0]["PesoLiquido"].ToString());
                        textBox40.Text = produtos.Rows[0]["EstoquePeso"].ToString();
                        //string mostra = Convert.ToString(Math.Round(resultado2, 2));
                        //MessageBox.Show(estoquePESO +  "  " + resultado2 );
                        decimal resultado3 = Convert.ToDecimal(Math.Round(resultado2, 2));
                        textBox39.Text = Convert.ToString(resultado3);
                    }
                    else
                    {
                        textBox39.Text = "Este Produto não é vendido por peso ";
                        textBox40.Text = "0.0";
                    }


                }
                else
                {
                    textBox39.Text = "Este Produto não é vendido por peso ";
                }
                //|||||Qtde reservada==>56|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["QtdReservado"].ToString())) == false)
                {

                    textBox27.Text = Convert.ToString(produtos.Rows[0]["QtdReservado"].ToString());

                }
                //|||||localização física==>57|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["LocFisica"].ToString())) == false)
                {

                    comboBox24.Text = Convert.ToString(produtos.Rows[0]["LocFisica"].ToString());

                }
                //|||||Dias sem vender==>58|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["DiasSemVender"].ToString())) == false)
                {

                    textBox13.Text = Convert.ToString(produtos.Rows[0]["DiasSemVender"].ToString());

                }
                //|||||Tempo reposição==>59|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["TempoReposição"].ToString())) == false)
                {
                    string venc = produtos.Rows[0]["TempoReposição"].ToString();
                    if (venc.Length == 8)
                    {

                        textBox26.Text = venc.Substring(6, 2) + "/" + venc.Substring(4, 2) + "/" + venc.Substring(0, 4);
                    }

                }
                //|||||Tipo de comissão==>60|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["TipoComissão"].ToString())) == false)
                {

                    if (Convert.ToInt32(produtos.Rows[0]["TipoComissão"].ToString()) == 1)
                    {
                        radioButton1.Checked = true;
                    }
                    if (Convert.ToInt32(produtos.Rows[0]["TipoComissão"].ToString()) == 2)
                    {
                        radioButton2.Checked = true;
                    }
                    if (Convert.ToInt32(produtos.Rows[0]["TipoComissão"].ToString()) == 3)
                    {
                        radioButton3.Checked = true;
                    }
                    if (Convert.ToInt32(produtos.Rows[0]["TipoComissão"].ToString()) == 4)
                    {
                        radioButton4.Checked = true;
                    }
                }
                //|||||Tempo reposição==>61|||||
                if (String.IsNullOrEmpty(Convert.ToString(produtos.Rows[0]["ComissãoFixa"].ToString())) == false)
                {

                    textBox29.Text = Convert.ToString(produtos.Rows[0]["ComissãoFixa"].ToString());

                }


                //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
                //|||||||||||||||||||Carrega Imagem||||||||||||||||||||||||||||||||
                //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
                string strConnection = "";
                if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
                {
                    strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                }
                if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
                {
                    string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                    string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                    strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975";
                }
                
                string id = label93.Text;

                string strSQL = "Abre_imagem";

                //cria a conexão com o banco de dados
                OleDbConnection dbConnection = new OleDbConnection(strConnection);

                //cria a conexão com o banco de dados
                OleDbConnection con = new OleDbConnection(strConnection);
                //cria o objeto command para executar a instruçao sql
                OleDbCommand cmd = new OleDbCommand(strSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                //abre a conexao

                cmd.Parameters.AddWithValue("@identificador", id);
                //cmd.Parameters.AddWithValue(imagem, pictureBox1.Image);

                // cria o objeto SqlDataReader e carrega-o com os dados obtidos SqlDataReader DataReader; DataReader = Command.ExecuteReader();

                //cria o objeto SqlDataReader e carrega-o com os dados obtidos 
                Image imagem = null;
                byte[] imagem_aray = (byte[])cmd.ExecuteScalar();
                if (imagem_aray != null)
                {
                    MemoryStream ms = new MemoryStream(imagem_aray);
                    imagem = Image.FromStream(ms);
                }



                pictureBox5.Image = imagem;
                //define o tipo do comando 

                //cria um dataadapter
                //OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                //cria um objeto datatable
                //DataTable clientes = new DataTable();

                //preenche o datatable via dataadapter
                //da.Fill(clientes);
                con.Dispose();
                con.Close();
                cmd.Dispose();
                dbConnection.Dispose();
                dbConnection.Close();

                if (String.IsNullOrEmpty(label92.Text) == false)
                {
                    if (pictureBox5.Image == null)
                    {
                        button1.Visible = true;
                        button2.Visible = false;
                        button3.Visible = false;
                    }
                    else
                    {
                        button1.Visible = false;
                        button2.Visible = false;
                        button3.Visible = true;
                    }
                }


            }
            else
            {
                MessageBox.Show("Cadastro inexistente");
            }

        }

        public void inicializaNovoRegistro()
        {
            comboBox6.DataSource = null;
            comboBox6.Items.Clear();
            comboBox8.DataSource = null;
            comboBox8.Items.Clear();
            comboBox7.Text = "não";
            tabControl2.SelectedTab = tabPage3;

            textBox9.ReadOnly = false;
            checkBox5.Enabled = true;
            progressBar1.Visible = true;
            label128.Visible = true;
            //barra peogresso 20%
            //passa paremetro para progressbar
            progressBar1.PerformStep();
            label128.Text = "10%";

            //reseta data com valores nulos
            /*dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " ";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = " ";*/



            label128.Text = "20%";
            progressBar1.PerformStep();

            label93.Text = Convert.ToString(DALCadastro.Revisao());
            label92.Text = "não finalizado";
            timer1.Enabled = true;

            textBox1.Text = "";
            textBox9.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox10.Text = "";
            textBox15.Text = "";
            textBox18.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox32.Text = "";
            textBox31.Text = "";
            textBox30.Text = "";
            textBox28.Text = "";
            textBox24.Text = "";
            textBox23.Text = "";
            //comissão valor inicial
            radioButton1.Checked = true;
            textBox17.Text = "1";
            label67.Text = Convert.ToString(DateTime.Now);
            textBox21.Text = "0,0000";//peso bruto
            textBox20.Text = "0,0000";//peso liquido
            textBox7.Text = "0,00";//valor inicial
            textBox4.Text = "0,0000";//valor médio
            textBox11.Text = "0,00";//desconto compra
            textBox8.Text = "0,00";//valor de compra
            textBox12.Text = "0,00000";//custo corrigido
            textBox33.Text = "0,0000";//margem
            textBox16.Text = "0,00";//valor venda
            textBox14.Text = "0,0000";//venda corrigido
            textBox25.Text = "0,00";//valor minimo
            textBox22.Text = "0,0000";//margem minima
            textBox19.Text = "0,00";//valor promoção
            textBox17.Text = "1";
            textBox27.Text = "0";
            textBox13.Text = "0";
            //textBox26.Text = "0";
            textBox29.Text = "0,0000";
            textBox2.Text = "0";
            textBox38.Text = "";


            //preencher comboBox finalidade
            //comboBox1.Items.Clear();
            comboBox1.DataSource = DALCadastro.Listar_Finalidade();
            comboBox1.ValueMember = "Descrição";
            comboBox1.DisplayMember = "Descricao";
            comboBox1.SelectedItem = "";
            comboBox1.Refresh();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim
            progressBar1.PerformStep();
            label128.Text = "30%";
            //preencher comboBox familia
            //comboBox2.Items.Clear();
            comboBox2.DataSource = DALCadastro.AUXCadListar("ListarCadFamilia");
            comboBox2.ValueMember = "Descrição";
            comboBox2.DisplayMember = "Descricao";
            comboBox2.SelectedItem = "";
            comboBox2.Refresh();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim

            //barra progresso 60%
            label128.Text = "40%";
            progressBar1.PerformStep();


            //preencher comboBox marca
            comboBox3.DataSource = DALCadastro.AUXCadListar("ListarCadMarca");
            comboBox3.ValueMember = "Descrição";
            comboBox3.DisplayMember = "Descricao";
            comboBox3.SelectedItem = "";
            comboBox3.Refresh();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim
            //preencher comboBox modelo
            comboBox4.DataSource = DALCadastro.AUXCadListar("ListarCadModelo");
            comboBox4.ValueMember = "Descrição";
            comboBox4.DisplayMember = "Descricao";
            comboBox4.SelectedItem = "";
            comboBox4.Refresh();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim
            progressBar1.PerformStep();
            label128.Text = "50%";
            //preencher comboBox unidade
            comboBox5.DataSource = DALCadastro.AUXCadListar("ListarCadUnidade");
            comboBox5.ValueMember = "Descrição";
            comboBox5.DisplayMember = "Descricao";
            comboBox5.SelectedItem = "";
            comboBox5.Refresh();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim

            //barra progresso 80%
            label128.Text = "60%";
            progressBar1.PerformStep();


            //preencher comboBox genero
            /*comboBox6.DataSource = DALCadastro.AUXCadListar("ListarCadGenero");
            comboBox6.ValueMember = "Codigo";
            comboBox6.DisplayMember = "Codigo";
            comboBox6.SelectedItem = "";
            comboBox6.Refresh();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim
            //preencher comboBox NCM
            comboBox8.DataSource = DALCadastro.AUXCadListar("ListarCadNCM");
            comboBox8.ValueMember = "Codigo_NCM";
            comboBox8.DisplayMember = "Codigo_NCM";
            comboBox8.SelectedItem = "";
            comboBox8.Refresh();*/
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim
            progressBar1.PerformStep();
            label128.Text = "70%";
            //preencher comboBox moeda compra
            comboBox9.DataSource = DALCadastro.AUXCadListar("ListarCadMoeda");
            comboBox9.ValueMember = "Descrição";
            comboBox9.DisplayMember = "Descricao";
            comboBox9.SelectedItem = "";
            comboBox9.Refresh();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim
            progressBar1.PerformStep();
            label128.Text = "80%";
            //preencher comboBox marca
            comboBox10.DataSource = DALCadastro.AUXCadListar("ListarCadMoeda");
            comboBox10.ValueMember = "Descrição";
            comboBox10.DisplayMember = "Descricao";
            comboBox10.SelectedItem = "";
            comboBox10.Refresh();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim
            progressBar1.PerformStep();
            label128.Text = "100%";
            //preencher comboBox Empresa
            comboBox11.DataSource = DALCadastro.AUXCadListar("ListarCadEmpresa");
            comboBox11.ValueMember = "Descrição";
            comboBox11.DisplayMember = "Descricao";
            comboBox11.SelectedItem = "";
            comboBox11.Refresh();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("Produto Calórico");
            //fim
            //barra progresso 100%
            label128.Text = "100%";
            progressBar1.PerformStep();

            pictureBox5.Image = null;
            pictureBox5.InitialImage = null;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            MessageBox.Show("Entre com Código EAN");
            progressBar1.Visible = false;
            label128.Visible = false;
            textBox9.Focus();
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label92.Text) == true)
            {

                if (panel10.Width >= 972 || panel1.Width >= 972)
                {
                    tabControl2.SelectedTab = tabPage3;
                    return;

                }
                else
                {
                    tabControl2.SelectedTab = tabPage3;
                }
                textBox38.Text = "";
                inicializaNovoRegistro();
                
                return;
            }
            if (label92.Text == "não finalizado" || label92.Text == "0")
            {
                MessageBox.Show("Cadastro não finalizado!");
                return;
            }
            if (Convert.ToInt32(label92.Text) >= 1)
            {
                string message = "Você deseja abrir um novo cadastro?";
                string caption = "Novo Cadastro";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    if (panel10.Width >= 972 || panel1.Width >= 972)
                    {
                        tabControl2.SelectedTab = tabPage3;
                        return;

                    }
                    tabControl2.SelectedTab = tabPage3;
                    inicializaNovoRegistro();

                }
                if (result == DialogResult.No)
                {

                    return;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel10.Width >= 972 || panel1.Width >= 972)
            {
                tabControl2.SelectedTab = tabPage3;
                return;
            }

            timer1.Enabled = true;
            panel1.Visible = false;
            panel1.Width = 0;
            tabControl2.SelectedTab = tabPage3;
            panel10.Visible = true;
            panel10.Width = 0;

            groupBox12.Visible = false;
            while (panel10.Width < 972)
            {
                Application.UseWaitCursor = true;
                panel10.Width = panel10.Width + 40;


            }
            panel10.Width = 972;
            Application.UseWaitCursor = false;
            groupBox12.Visible = true;
            dataGridView1.DataSource = DALCadastro.ListarXMLEstoque();
        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.Cyan;
            pictureBox7.Visible = true;
            label7.ForeColor = System.Drawing.Color.Red;
            label7.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label7.BackColor = System.Drawing.Color.Cyan;
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                textBox1.BackColor = System.Drawing.Color.White;
                panel4.Focus();
                pictureBox7.Visible = false;
                label7.Font = new Font(label17.Font, FontStyle.Regular);
                label7.BackColor = System.Drawing.Color.Transparent;
                label7.ForeColor = System.Drawing.Color.Black;
                return;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.White;
            pictureBox7.Visible = false;
            label7.Font = new Font(label7.Font, FontStyle.Regular);
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.ForeColor = System.Drawing.Color.Black;
        }

        private void CadastroProdutos1024x768_Load(object sender, EventArgs e)
        {

            /*
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados
            string id = "1";

            string strSQL = "Abre_imagem";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();

            //abre a conexao

            cmd.Parameters.AddWithValue("@identificador", id);
            //cmd.Parameters.AddWithValue(imagem, pictureBox1.Image);

            // cria o objeto SqlDataReader e carrega-o com os dados obtidos SqlDataReader DataReader; DataReader = Command.ExecuteReader();

            //cria o objeto SqlDataReader e carrega-o com os dados obtidos 
            Image imagem = null;
            byte[] imagem_aray = (byte[])cmd.ExecuteScalar();
            MemoryStream ms = new MemoryStream(imagem_aray);
            imagem = Image.FromStream(ms);
            pictureBox5.Image = imagem;







            //define o tipo do comando 

            //cria um dataadapter
            //OleDbDataAdapter da = new OleDbDataAdapter(cmd);

            //cria um objeto datatable
            //DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            //da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();*/

            inicializaForm();
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (panel10.Width >= 972 || panel1.Width >= 972)
            {
                tabControl2.SelectedTab = tabPage3;
                return;
            }


            timer1.Enabled = true;
            panel10.Width = 0;
            panel10.Visible = false;
            tabControl2.SelectedTab = tabPage3;
            panel1.Visible = true;
            panel1.Width = 0;
            groupBox11.Visible = false;
            while (panel1.Width < 972)
            {
                Application.UseWaitCursor = true;
                panel1.Width = panel1.Width + 40;


            }
            panel1.Width = 972;
            Application.UseWaitCursor = false;
            groupBox11.Visible = true;
            textBox36.Focus();
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Global.Margem.EANTemp2 = textBox9.Text;
            textBox20.Text = textBox20.Text.Replace(".", ",");
            textBox21.Text = textBox21.Text.Replace(".", ",");
            if (panel10.Width >= 972 || panel1.Width >= 972)
            {
                tabControl2.SelectedTab = tabPage3;
                return;

            }
            if (String.IsNullOrEmpty(label93.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro antes de salvar registro");
                return;
            }
            //||||||||||||||||||||||||||||||||||||||||||||
            //|||||||Testa cadastro básico||||||||||||||||
            //||||||||||||||||||||||||||||||||||||||||||||
            if (label92.Text == "não finalizado")
            {
                timer1.Enabled = true;


                if (String.IsNullOrEmpty(textBox1.Text) == true)
                {
                    textBox1.Text = "";
                }
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    Int64 qtde;
                    if (Int64.TryParse(textBox1.Text.Trim(), out qtde) == false)
                    {
                        MessageBox.Show("O campo Código DNF só aceita valores numéricos");
                        textBox1.Focus();
                        return;


                    }
                }
                if (String.IsNullOrEmpty(textBox9.Text) == true)
                {
                    string message = "Você deseja cadastrar produto sem código de barras?";
                    string caption = "EAN";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        textBox9.Text = "";

                    }
                    if (result == DialogResult.No)
                    {
                        textBox9.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(textBox9.Text) == false)
                {
                    Int64 qtde2;
                    if (Int64.TryParse(textBox9.Text.Trim(), out qtde2) == false)
                    {
                        MessageBox.Show("O campo Código EAN só aceita valores numéricos");

                        textBox9.Focus();
                        return;

                    }
                    if (textBox9.Text.Length < 5)
                    {
                        MessageBox.Show("Formato EAN incorreto");
                        textBox9.Focus();
                        return;

                    }
                    //verifica se EAN já está cadastrado
                    String recebe = Convert.ToString(DALCadastro.TemEAN(textBox9.Text));
                    if (String.IsNullOrEmpty(recebe) == false)
                    {
                        DataTable testa = DALCadastro.produtoVenda(textBox9.Text);
                        if (testa.Rows.Count == 1)
                        {
                            MessageBox.Show("Existe cadastro com este código de barras.\n" + testa.Rows[0]["DescInterna"].ToString() + "\n==> Id produto: " +
                                testa.Rows[0]["IdProd"].ToString());
                            textBox9.Text = "";
                            textBox9.Focus();
                            return;
                        }
                    }
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Text = "";
                }
                if (String.IsNullOrEmpty(textBox3.Text) == false)
                {
                    Int64 qtde3;
                    if (Int64.TryParse(textBox3.Text.Trim(), out qtde3) == false)
                    {
                        MessageBox.Show("O campo Código EAN Tributado só aceita valores numéricos");

                        textBox3.Focus();
                        return;

                    }
                    if (textBox3.Text.Length < 5)
                    {
                        MessageBox.Show("Formato EAN incorreto");
                        textBox3.Focus();
                        return;
                    }

                }
                if (String.IsNullOrEmpty(textBox6.Text) == true)
                {
                    textBox6.Text = "";
                }
                if (String.IsNullOrEmpty(textBox5.Text) == true)
                {
                    MessageBox.Show("Campo Referência não preenchido");
                    textBox5.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox1.Text) == true)
                {
                    MessageBox.Show("Campo Finalidade  não selecionado");
                    comboBox1.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox2.Text) == true)
                {
                    MessageBox.Show("Campo Família  não selecionado");
                    comboBox2.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox3.Text) == true)
                {
                    MessageBox.Show("Campo Marca não selecionado");
                    comboBox3.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox4.Text) == true)
                {
                    MessageBox.Show("Campo Modelo não selecionado");
                    comboBox4.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox5.Text) == true)
                {
                    MessageBox.Show("Campo Unidade não selecionado");
                    comboBox5.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(textBox10.Text) == true)
                {
                    MessageBox.Show("Campo descrição interna não preenchido");
                    textBox10.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(textBox15.Text) == true)
                {
                    textBox15.Text = "";
                }
                /*if (String.IsNullOrEmpty(comboBox6.Text) == true)
                {
                    MessageBox.Show("Campo Gênero não selecionado");
                    comboBox6.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(comboBox8.Text) == true)
                {
                    MessageBox.Show("Campo NCM não selecionado");
                    comboBox8.Focus();
                    return;
                }
                if (comboBox6.Text != comboBox8.Text.Substring(0, 2))
                {
                    MessageBox.Show("Campo Gênero tem que ser igual aos 2 (dois) primeiros digitos do código NCM ");
                    comboBox6.Focus();
                    return;
                }*/
                if (String.IsNullOrEmpty(textBox18.Text) == true)
                {
                    textBox18.Text = "";
                }

                if (String.IsNullOrEmpty(textBox18.Text) == false)
                {
                    Int32 qtde10;
                    if (int.TryParse(textBox18.Text.Trim(), out qtde10) == false)
                    {
                        MessageBox.Show("O campo Código EX IPI só aceita valores numéricos");

                        textBox18.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(comboBox9.Text) == true)
                {
                    MessageBox.Show("Campo Moeda compra não selecionado");
                    comboBox9.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(comboBox10.Text) == true)
                {
                    MessageBox.Show("Campo Moeda Faturamento não selecionado");
                    comboBox10.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox15.Text) == true)
                {
                    textBox15.Text = "";
                }
                if (String.IsNullOrEmpty(textBox21.Text) == false)
                {

                    decimal pesoBruto;
                    if (Decimal.TryParse(textBox21.Text.Trim(), out pesoBruto) == false)
                    {
                        MessageBox.Show("O campo peso Bruto está em formato incorreto");
                        textBox21.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(textBox20.Text) == false)
                {
                    decimal pesoliquido;
                    if (Decimal.TryParse(textBox20.Text.Trim(), out pesoliquido) == false)
                    {
                        MessageBox.Show("O campo peso liquido está em formato incorreto");
                        textBox20.Focus();
                        return;
                    }
                    if (Decimal.TryParse(textBox20.Text.Trim(), out pesoliquido) == true && checkBox5.Checked == true)
                    {
                        if (pesoliquido <= 0)
                        {
                            MessageBox.Show("O campo peso liquido não pode estar com valor igual a zero,\nquando a integração com a balança estiver ativa.");
                            textBox20.Focus();
                            return;
                        }
                    }
                }
                
                if (String.IsNullOrEmpty(comboBox11.Text) == true)
                {
                    MessageBox.Show("Campo Empresa não selecionado");
                    comboBox11.Focus();
                    return;
                }
                label92.Text = "0";
                tabControl2.SelectedTab = tabPage4;

                MessageBox.Show("Cadastro básico OK");
                textBox9.ReadOnly = true;
                checkBox5.Enabled = false;
                textBox32.Focus();

                if (label92.Text == "0")
                {
                    return;
                }


                // ||||||||||||||||||||||||||||||||||||||||||||
                // ||||||||||||||||||||||||||||||||||||||||||||
                // ||funciona após validação cadastro basico|||
                // ||||||||||||||||||||||||||||||||||||||||||||
                // ||||||||||||||||||||||||||||||||||||||||||||

            }
            //string para armazenar opção de inativo e outros
            char inativo = 'v';
            char itemOriginal = 'v';
            char margemInversa = 'v';
            char comissao = 'v';
            char promoção = 'v';
            char tipoComissao = 'S';

            if (edita == false && Convert.ToInt32(label92.Text) > 0)
            {
                MessageBox.Show("Precisa abrir edição do cadastro");
            }
            if (edita == false && label92.Text == "0")
            {
                timer1.Enabled = true;


                if (String.IsNullOrEmpty(textBox1.Text) == true)
                {
                    textBox1.Text = null;
                }
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    Int64 qtde;
                    if (Int64.TryParse(textBox1.Text.Trim(), out qtde) == false)
                    {
                        MessageBox.Show("O campo Código DNF só aceita valores numéricos");
                        tabControl2.SelectedTab = tabPage3;
                        textBox1.Focus();
                        return;


                    }
                }
                if (String.IsNullOrEmpty(textBox9.Text) == true)
                {
                    string message = "Você deseja cadastrar produto sem código de barras?";
                    string caption = "EAN";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        textBox9.Text = null;

                    }
                    if (result == DialogResult.No)
                    {
                        tabControl2.SelectedTab = tabPage3;
                        textBox9.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(textBox9.Text) == false)
                {
                    Int64 qtde2;
                    if (Int64.TryParse(textBox9.Text.Trim(), out qtde2) == false)
                    {
                        MessageBox.Show("O campo Código EAN só aceita valores numéricos");
                        tabControl2.SelectedTab = tabPage3;
                        textBox9.Focus();
                        return;

                    }
                    if (textBox9.Text.Length < 5)
                    {
                        MessageBox.Show("Formato EAN incorreto");
                        tabControl2.SelectedTab = tabPage3;
                        textBox9.Focus();
                        return;

                    }
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Text = null;
                }
                if (String.IsNullOrEmpty(textBox3.Text) == false)
                {
                    Int64 qtde3;
                    if (Int64.TryParse(textBox3.Text.Trim(), out qtde3) == false)
                    {
                        MessageBox.Show("O campo Código EAN Tributado só aceita valores numéricos");
                        tabControl2.SelectedTab = tabPage3;
                        textBox3.Focus();
                        return;

                    }
                    if (textBox3.Text.Length < 5)
                    {
                        MessageBox.Show("Formato EAN incorreto");
                        tabControl2.SelectedTab = tabPage3;
                        textBox3.Focus();
                        return;
                    }

                }
                if (String.IsNullOrEmpty(textBox6.Text) == true)
                {
                    textBox6.Text = null;
                }
                if (String.IsNullOrEmpty(textBox5.Text) == true)
                {
                    MessageBox.Show("Campo Referência não preenchido");
                    tabControl2.SelectedTab = tabPage3;
                    textBox5.Focus();
                    return;

                }
                if (checkBox1.Checked == true)
                {
                    inativo = 'S';
                }
                if (checkBox1.Checked == false)
                {
                    inativo = 'N';
                }

                if (String.IsNullOrEmpty(comboBox1.Text) == true)
                {
                    MessageBox.Show("Campo Finalidade  não selecionado");
                    tabControl2.SelectedTab = tabPage3;
                    comboBox1.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox2.Text) == true)
                {
                    MessageBox.Show("Campo Família  não selecionado");
                    tabControl2.SelectedTab = tabPage3;
                    comboBox2.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox3.Text) == true)
                {
                    MessageBox.Show("Campo Marca não selecionado");
                    tabControl2.SelectedTab = tabPage3;
                    comboBox3.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox4.Text) == true)
                {
                    MessageBox.Show("Campo Modelo não selecionado");
                    tabControl2.SelectedTab = tabPage3;
                    comboBox4.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox5.Text) == true)
                {
                    MessageBox.Show("Campo Unidade não selecionado");
                    tabControl2.SelectedTab = tabPage3;
                    comboBox5.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(textBox10.Text) == true)
                {
                    MessageBox.Show("Campo descrição interna não preenchido");
                    tabControl2.SelectedTab = tabPage3;
                    textBox10.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(textBox15.Text) == true)
                {
                    textBox15.Text = null;
                }
                
                /*if (String.IsNullOrEmpty(comboBox8.Text) == true)
                {
                    MessageBox.Show("Campo NCM não selecionado");
                    comboBox8.Focus();
                    return;
                }*/
                if (String.IsNullOrEmpty(textBox18.Text) == true)
                {
                    textBox18.Text = null;
                }
                if (String.IsNullOrEmpty(textBox18.Text) == true)
                {
                    textBox18.Text = null;
                }
                if (String.IsNullOrEmpty(textBox18.Text) == false)
                {
                    Int32 qtde10;
                    if (int.TryParse(textBox18.Text.Trim(), out qtde10) == false)
                    {
                        MessageBox.Show("O campo Código EX IPI só aceita valores numéricos");

                        textBox18.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(comboBox9.Text) == true)
                {
                    MessageBox.Show("Campo Moeda compra não selecionado");
                    comboBox9.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(comboBox10.Text) == true)
                {
                    MessageBox.Show("Campo Moeda Faturamento não selecionado");
                    comboBox10.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox21.Text) == true)
                {
                    textBox21.Text = "0,0000";//peso bruto
                }
                if (String.IsNullOrEmpty(textBox21.Text) == false)
                {
                    decimal pesoBruto;
                    if (Decimal.TryParse(textBox21.Text.Trim(), out pesoBruto) == false)
                    {
                        MessageBox.Show("O campo peso Bruto está em formato incorreto");

                        textBox21.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(textBox20.Text) == true)
                {
                    textBox20.Text = "0,0000";
                }
                if (String.IsNullOrEmpty(textBox20.Text) == false)
                {
                    decimal pesoliquido;
                    if (Decimal.TryParse(textBox20.Text.Trim(), out pesoliquido) == false)
                    {
                        MessageBox.Show("O campo peso liquido está em formato incorreto");
                        textBox20.Focus();
                        return;
                    }
                    if (Decimal.TryParse(textBox20.Text.Trim(), out pesoliquido) == true && checkBox5.Checked == true)
                    {
                        if (pesoliquido <= 0)
                        {
                            MessageBox.Show("O campo peso liquido não pode estar com valor igual a zero,\nquando a integração com a balança estiver ativa.");
                            tabControl2.SelectedTab = tabPage3;
                            textBox20.Focus();
                            return;
                        }
                    }
                }
                if (String.IsNullOrEmpty(comboBox11.Text) == true)
                {
                    MessageBox.Show("Campo Empresa não selecionado");
                    tabControl2.SelectedTab = tabPage3;
                    comboBox11.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox32.Text) == true)
                {
                    textBox32.Text = null;
                }
                if (String.IsNullOrEmpty(textBox31.Text) == true)
                {
                    textBox31.Text = null;
                }
                if (String.IsNullOrEmpty(textBox30.Text) == true)
                {
                    textBox30.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox12.Text) == true)
                {
                    comboBox12.Text = null;
                }
                if (String.IsNullOrEmpty(textBox28.Text) == true)
                {
                    textBox28.Text = null;
                }
                if (String.IsNullOrEmpty(textBox28.Text) == false)
                {

                }

                if (String.IsNullOrEmpty(comboBox15.Text) == true)
                {
                    comboBox15.Text = null;
                }
                if (String.IsNullOrEmpty(dateTimePicker1.Text) == true)
                {
                    dateTimePicker1.Text = null;
                }

                if (String.IsNullOrEmpty(dateTimePicker2.Text) == true)
                {
                    dateTimePicker2.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox16.Text) == true)
                {
                    comboBox16.Text = null;
                }
                if (String.IsNullOrEmpty(textBox24.Text) == true)
                {
                    textBox24.Text = null;
                }
                if (checkBox2.Checked == true)
                {
                    itemOriginal = 'S';
                }
                if (checkBox2.Checked == false)
                {
                    itemOriginal = 'N';
                }
                if (String.IsNullOrEmpty(textBox23.Text) == true)
                {
                    textBox23.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox17.Text) == true)
                {
                    comboBox17.Text = null;
                }

                if (String.IsNullOrEmpty(textBox38.Text) == true)
                {
                    textBox38.Text = "";
                }
                if (String.IsNullOrEmpty(comboBox19.Text) == true)
                {
                    comboBox19.Text = null;
                }
                if (String.IsNullOrEmpty(textBox21.Text) == true)
                {
                    textBox21.Text = "0,0000";//peso bruto
                }
                if (String.IsNullOrEmpty(textBox21.Text) == false)
                {
                    decimal pesoBruto;
                    if (Decimal.TryParse(textBox21.Text.Trim(), out pesoBruto) == false)
                    {
                        MessageBox.Show("O campo peso Bruto está em formato incorreto");
                        tabControl2.SelectedTab = tabPage3;
                        textBox21.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(textBox20.Text) == true)
                {
                    textBox20.Text = "0,0000";
                }
                if (String.IsNullOrEmpty(textBox20.Text) == false)
                {
                    decimal pesoliquido;
                    if (Decimal.TryParse(textBox20.Text.Trim(), out pesoliquido) == false)
                    {
                        MessageBox.Show("O campo peso liquido está em formato incorreto");
                        tabControl2.SelectedTab = tabPage3;
                        textBox20.Focus();
                        return;
                    }
                    if (Decimal.TryParse(textBox20.Text.Trim(), out pesoliquido) == true && checkBox5.Checked == true)
                    {
                        if (pesoliquido <= 0)
                        {
                            MessageBox.Show("O campo peso liquido não pode estar com valor igual a zero,\nquando a integração com a balança estiver ativa.");
                            tabControl2.SelectedTab = tabPage3;
                            textBox20.Focus();
                            return;
                        }
                    }
                }
                if (String.IsNullOrEmpty(comboBox7.Text) == true)
                {
                    comboBox7.Text = null;
                }
                if (String.IsNullOrEmpty(textBox7.Text) == true)
                {
                    textBox7.Text = "0,00";//valor inicial
                }
                if (String.IsNullOrEmpty(textBox4.Text) == true)
                {
                    textBox4.Text = "0,0000";//valor médio
                }
                if (String.IsNullOrEmpty(textBox11.Text) == true)
                {
                    textBox11.Text = "0,00";//desconto de compra
                }
                if (String.IsNullOrEmpty(textBox8.Text) == true)
                {
                    MessageBox.Show("Campo valor de compra não preenchido");
                    tabControl2.SelectedTab = tabPage6;
                    textBox8.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox8.Text) == false)
                {
                    decimal dec1;
                    if (Decimal.TryParse(textBox8.Text.Trim(), out dec1) == false)
                    {
                        MessageBox.Show("Insira somente valores numéricos");
                        tabControl2.SelectedTab = tabPage6;
                        textBox8.Text = "";
                        textBox8.Focus();
                        return;
                    }
                    if (Decimal.TryParse(textBox8.Text.Trim(), out dec1) == true)
                    {
                        if (dec1 <= 0)
                        {
                            string message = "Valor de compra deste ítem não informado.\nDeseja fornecer os valores de compra/venda? ";
                            string caption = "Valor";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;

                            // Mostra a MessageBox.

                            result = MessageBox.Show(this, message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                            if (result == DialogResult.Yes)
                            {
                                tabControl2.SelectedTab = tabPage6;
                                textBox8.Focus();
                                return;
                            }


                        }
                    }
                }

                if (String.IsNullOrEmpty(textBox12.Text) == true)
                {
                    textBox12.Text = "0,00000";//custo corrigido
                }
                if (checkBox3.Checked == true)
                {
                    margemInversa = 'S';
                }
                if (checkBox3.Checked == false)
                {
                    margemInversa = 'N';
                }
                if (String.IsNullOrEmpty(textBox33.Text) == true)
                {
                    MessageBox.Show("Campo margem não preenchido");
                    tabControl2.SelectedTab = tabPage6;
                    textBox33.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox16.Text) == true)
                {
                    textBox16.Text = "0,00";//valor de venda
                }
                if (String.IsNullOrEmpty(textBox14.Text) == true)
                {
                    textBox14.Text = "0,0000";//venda corrigido
                }
                if (String.IsNullOrEmpty(textBox25.Text) == true)
                {
                    textBox25.Text = "0,00";//valor minimo
                }


                if (String.IsNullOrEmpty(textBox22.Text) == true)
                {
                    textBox22.Text = "0,0000";//margem minima
                }
                if (String.IsNullOrEmpty(textBox19.Text) == true)
                {
                    textBox19.Text = "0,00";//valor promoção
                }
                if (checkBox4.Checked == true)
                {
                    promoção = 'S';
                }
                if (checkBox4.Checked == false)
                {
                    promoção = 'N';
                }
                if (String.IsNullOrEmpty(comboBox22.Text) == true)
                {
                    comboBox22.Text = null;
                }
                if (String.IsNullOrEmpty(textBox17.Text) == true)
                {
                    textBox17.Text = null;
                }
                if (String.IsNullOrEmpty(textBox2.Text) == true)
                {
                    textBox2.Text = "0";
                }
                if (String.IsNullOrEmpty(textBox2.Text) == false)
                {
                    if (Convert.ToInt32(textBox2.Text) <= 0)
                    {
                        string message = "Você deseja cadastrar este ítem com estoque 0 (zero) ?";
                        string caption = "Estoque";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Mostra a MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.No)
                        {
                            tabControl2.SelectedTab = tabPage7;
                            textBox2.Focus();
                            return;
                        }
                    }
                }
                if (String.IsNullOrEmpty(textBox27.Text) == true)
                {
                    textBox27.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox24.Text) == true)
                {
                    comboBox24.Text = null;
                }
                if (String.IsNullOrEmpty(textBox13.Text) == true)
                {
                    textBox13.Text = null;
                }
                if (String.IsNullOrEmpty(textBox13.Text) == false)
                {

                    Int32 qtde4;
                    if (int.TryParse(textBox13.Text.Trim(), out qtde4) == false)
                    {
                        MessageBox.Show("O campo avisar dias sem vender só aceita valores numéricos");

                        textBox13.Focus();
                        return;
                    }

                }
                
                if (String.IsNullOrEmpty(textBox26.Text) == true)
                {
                    textBox26.Text = null;
                }
                string data = "";
                if (String.IsNullOrEmpty(textBox26.Text) == false)
                {

                    data = textBox26.Text.Replace("/", "");

                    string ano = data.Substring(4, 4);
                    string mes = data.Substring(2, 2);
                    string dia = data.Substring(0, 2);
                    data = ano + mes + dia;

                }
                if (radioButton1.Checked == true)
                {
                    comissao = '1';
                    textBox29.Text = "0,0000";

                }
                if (radioButton3.Checked == true)
                {
                    comissao = '3';
                    textBox29.Text = "0,0000";
                }
                if (radioButton2.Checked == true)
                {
                    if (String.IsNullOrEmpty(textBox29.Text) == true)
                    {
                        MessageBox.Show("Favor fornecer um valor para comissão fixa");
                        textBox29.Focus();
                        return;
                    }
                    else
                    {
                        Decimal qtde4;
                        if (Decimal.TryParse(textBox29.Text.Trim(), out qtde4) == false)
                        {
                            MessageBox.Show("O campo comissão fixa está em formato incorreto");

                            textBox29.Focus();
                            return;
                        }
                        if (Decimal.TryParse(textBox29.Text.Trim(), out qtde4) == true)
                        {
                            comissao = '2';

                        }
                    }
                }
                if (radioButton2.Checked == false)
                {
                    textBox29.Text = "0,0000";
                }
                if (label92.Text == "0")
                {
                    label92.Text = "1";
                    decimal t21;
                    if (Decimal.TryParse(textBox21.Text, out t21))
                    {
                        textBox21.Text = Convert.ToString(t21);
                        textBox21.Text = textBox21.Text.Replace(",", ".");

                    }
                    else
                    {
                        MessageBox.Show("Campo Peso Bruto em formato incorreto");
                        return;
                    }

                    decimal t20;
                    if (Decimal.TryParse(textBox20.Text, out t20))
                    {
                        textBox20.Text = Convert.ToString(t20);
                        textBox20.Text = textBox20.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Peso Líquido em formato incorreto");
                        return;
                    }

                    decimal t7;
                    if (Decimal.TryParse(textBox7.Text, out t7))
                    {
                        textBox7.Text = Convert.ToString(t7);
                        textBox7.Text = textBox7.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo valor inicial em formato incorreto");
                        return;
                    }

                    decimal t4;
                    if (Decimal.TryParse(textBox4.Text, out t4))
                    {
                        textBox4.Text = Convert.ToString(t4);
                        textBox4.Text = textBox4.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor médio em formato incorreto");
                        return;
                    }

                    decimal t11;
                    if (Decimal.TryParse(textBox11.Text, out t11))
                    {
                        textBox11.Text = Convert.ToString(t11);
                        textBox11.Text = textBox11.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Desconto Compra em formato incorreto");
                        return;
                    }

                    decimal t8;
                    if (Decimal.TryParse(textBox8.Text, out t8))
                    {
                        textBox8.Text = Convert.ToString(t8);
                        textBox8.Text = textBox8.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor de compre em formato incorreto");
                        return;
                    }

                    decimal t12;
                    if (Decimal.TryParse(textBox12.Text, out t12))
                    {
                        textBox12.Text = Convert.ToString(t12);
                        textBox12.Text = textBox12.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo custo corrigido em formato incorreto");
                        return;
                    }

                    decimal t33;
                    if (Decimal.TryParse(textBox33.Text, out t33))
                    {
                        textBox33.Text = Convert.ToString(t33);
                        textBox33.Text = textBox33.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo margem em formato incorreto");
                        return;
                    }

                    decimal t16;
                    if (Decimal.TryParse(textBox16.Text, out t16))
                    {
                        textBox16.Text = Convert.ToString(t16);
                        textBox16.Text = textBox16.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor de venda em formato incorreto");
                        return;
                    }

                    decimal t14;
                    if (Decimal.TryParse(textBox14.Text, out t14))
                    {
                        textBox14.Text = Convert.ToString(t14);
                        textBox14.Text = textBox14.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Venda corrigido em formato incorreto");
                        return;
                    }

                    decimal t25;
                    if (Decimal.TryParse(textBox25.Text, out t25))
                    {
                        textBox25.Text = Convert.ToString(t25);
                        textBox25.Text = textBox25.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor mínimo em formato incorreto");
                        return;
                    }

                    decimal t22;
                    if (Decimal.TryParse(textBox22.Text, out t22))
                    {
                        textBox22.Text = Convert.ToString(t22);
                        textBox22.Text = textBox22.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Margem mínima em formato incorreto");
                        return;
                    }

                    decimal t19;
                    if (Decimal.TryParse(textBox19.Text, out t19))
                    {
                        textBox19.Text = Convert.ToString(t19);
                        textBox19.Text = textBox19.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor promoção em formato incorreto");
                        return;
                    }

                    decimal t29;
                    if (Decimal.TryParse(textBox29.Text, out t29))
                    {
                        textBox29.Text = Convert.ToString(t29);
                        textBox29.Text = textBox29.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor médio em formato incorreto");
                        return;
                    }


                    //decimal estPeso;
                    string estoqueP;
                    estoqueP = "0.0";
                    if (comboBox7.Text == "Preço" || comboBox7.Text == "Peso")
                    {
                        int temppp = Convert.ToInt32(textBox2.Text) * 1000;

                        decimal t30;
                        if (Decimal.TryParse(textBox20.Text.Replace(".", ","), out t30))
                        {

                            estoqueP = Convert.ToString(t30 * temppp);
                            
                            estoqueP = estoqueP.Replace(",", ".");
                        }
                        else
                        {
                            MessageBox.Show("Campo peso liquido com valor incorreto");
                            return;
                        }
                        textBox2.Text = "0";
                    }
                    //verifica se EAN já está cadastrado
                    if (Global.Margem.EANTemp2 != Global.Margem.EANTemp)
                    {
                        String recebe = Convert.ToString(DALCadastro.TemEAN(Global.Margem.EANTemp2));
                        if (String.IsNullOrEmpty(recebe) == false)
                        {
                            DataTable testa = DALCadastro.produtoVenda(textBox9.Text);
                            if (testa.Rows.Count == 1)
                            {
                                MessageBox.Show("Existe cadastro com este código de barras.\n" + testa.Rows[0]["DescInterna"].ToString() + "\n==> Id produto: " +
                                    testa.Rows[0]["IdProd"].ToString());
                                textBox9.Text = "";
                                textBox9.Focus();
                                Global.Margem.EANTemp2 = "";
                                return;
                            }
                        }
                    }
                    DALCadastro.Cadastrar_Produto(/*1 Revisão*/ label92.Text, /*2 Código DNF*/ textBox1.Text, /*3 cod EAN*/ textBox9.Text,
                        /*4 EAN Trib*/ textBox3.Text, /*5 cod fornecimento*/ textBox6.Text, /* 6 referência*/ textBox5.Text, /* 7 inativo*/ inativo,
                        /*8 finalidade*/ comboBox1.Text, /*9 familia*/comboBox2.Text, /*10 marca*/comboBox3.Text, /*11 modelo*/comboBox4.Text,
                        /*12 unidade*/comboBox5.Text, /*13 descrição interna*/textBox10.Text, /*14 grade*/textBox15.Text, /*15 gênero*/comboBox6.Text,
                        /*16 NCM*/comboBox8.Text, /*17 EX IPI*/textBox18.Text, /*18 moeda compra*/comboBox9.Text, /*19 moeda faturamento*/comboBox10.Text,
                        /*20 peso bruto*/textBox21.Text, /*21 peso líquido*/textBox20.Text, /*22 empresa*/comboBox11.Text,
                        /*23 nome original NF*/textBox32.Text,/*24 nome fabricante*/textBox31.Text, /*25 observações*/textBox30.Text,
                        /*26 grupo compradores*/comboBox12.Text, /*27 garantia*/textBox28.Text, /*28 inicio*/dateTimePicker1.Text,
                        /*29 final*/dateTimePicker2.Text,/*30 método suprimento*/comboBox16.Text, /*31 impacto*/textBox24.Text,
                        /*32 original*/itemOriginal, /*33 data cadastro*/label67.Text,
                        /*34 usuario cadastrou*/textBox23.Text, /*35 grupo tributário saídas*/comboBox17.Text,
                        /*36 grupo tributário entradas*/textBox38.Text, /*37 cod serviço SEFAZ*/comboBox19.Text, /*38 IPI*/comboBox20.Text,
                        /*39 vender por*/comboBox7.Text, /*40 valor inicial*/textBox7.Text, /*41 valor médio*/textBox4.Text, /*42 desc compra*/textBox11.Text,
                        /*43 valor compra*/textBox8.Text, /*44 custo corrigido*/textBox12.Text, /*45 margem inversa*/margemInversa,
                        /*46 margem*/textBox33.Text, /*47 valor venda*/textBox16.Text, /*48 venda corrigido*/textBox14.Text,
                        /*49 valor minimo*/textBox25.Text, /*50 margem minima*/textBox22.Text, /*51 valor promoção*/textBox19.Text, /*52 promoção*/promoção,
                        /*53 grupo carregamento*/comboBox22.Text, /*54 múltiplo*/textBox17.Text, /*55 estoque INT*/textBox2.Text,
                        /*56 estoque peso*/estoqueP, /*57 qtd reservada*/textBox27.Text, /*58 localização física*/comboBox24.Text,
                        /*59 dias sem vender*/textBox13.Text, /*60 tempo de reposição*/data, /*61 marca dias sem vender*/tipoComissao,
                        /*62 tipo comissão*/comissao, /*63 comissão fixa*/textBox29.Text);

                    Form cadC = new OK();
                    cadC.ShowDialog();
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CadProdutos", "Novo Cadastro : " + textBox5.Text);
                    }

                    //||||||||||||||Criar eventos|||||||||||
                    //||||||||||||||||||||||||||||||||||||||
                    if (Convert.ToInt32(textBox27.Text) > 0)
                    {
                        DALCadastro.criarEvento("Reservado", label93.Text, textBox10.Text, "XXXXXXXXXXX", textBox27.Text);
                    }

                    if (Convert.ToInt32(textBox13.Text) > 0)
                    {
                        DateTime temp = DateTime.Now.AddDays(Convert.ToInt32(textBox13.Text));

                        DALCadastro.criarEvento("Dias Sem Vender", label93.Text, textBox10.Text,
                            Convert.ToString(temp.ToShortDateString()), "Produto ficou " + textBox13.Text + " dias sem vender");
                    }
                    if (String.IsNullOrEmpty(textBox26.Text) == false)
                    {
                        //DateTime temp1 = DateTime.Now.AddDays(Convert.ToInt32(textBox26.Text));
                       
                        DALCadastro.criarEvento("Tempo de Reposição", label93.Text, textBox10.Text,
                            data, "Data do aviso de vencimento : " + textBox26.Text );
                    }

                    limpaForm();
                    Global.Margem.Reload = "Sim";
                    tabControl2.SelectedTab = tabPage3;
                    comboBox7.Visible = false;
                    textBox9.ReadOnly = false;
                    checkBox5.Enabled = true;
                    textBox16.ReadOnly = true;
                    abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(label93.Text)));
                    return;
                }
            }
            if (edita == true)
            {
                timer1.Enabled = true;


                if (String.IsNullOrEmpty(textBox1.Text) == true)
                {
                    textBox1.Text = null;
                }
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    Int64 qtde;
                    if (Int64.TryParse(textBox1.Text.Trim(), out qtde) == false)
                    {
                        MessageBox.Show("O campo Código DNF só aceita valores numéricos");
                        textBox1.Focus();
                        return;


                    }
                }
                if (String.IsNullOrEmpty(textBox9.Text) == true)
                {
                    string message = "Você deseja cadastrar produto sem código de barras?";
                    string caption = "EAN";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        textBox9.Text = null;

                    }
                    if (result == DialogResult.No)
                    {
                        textBox9.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(textBox9.Text) == false)
                {
                    Int64 qtde2;
                    if (Int64.TryParse(textBox9.Text.Trim(), out qtde2) == false)
                    {
                        MessageBox.Show("O campo Código EAN só aceita valores numéricos");

                        textBox9.Focus();
                        return;

                    }
                    if (textBox9.Text.Length < 5)
                    {
                        MessageBox.Show("Formato EAN incorreto");
                        textBox9.Focus();
                        return;

                    }
                }
                if (String.IsNullOrEmpty(textBox3.Text) == true)
                {
                    textBox3.Text = null;
                }
                if (String.IsNullOrEmpty(textBox3.Text) == false)
                {
                    Int64 qtde3;
                    if (Int64.TryParse(textBox3.Text.Trim(), out qtde3) == false)
                    {
                        MessageBox.Show("O campo Código EAN Tributado só aceita valores numéricos");

                        textBox3.Focus();
                        return;

                    }
                    if (textBox3.Text.Length < 5)
                    {
                        MessageBox.Show("Formato EAN incorreto");
                        textBox3.Focus();
                        return;
                    }

                }
                if (String.IsNullOrEmpty(textBox6.Text) == true)
                {
                    textBox6.Text = null;
                }
                if (String.IsNullOrEmpty(textBox5.Text) == true)
                {
                    MessageBox.Show("Campo Referência não preenchido");
                    textBox5.Focus();
                    return;

                }
                if (checkBox1.Checked == true)
                {
                    inativo = 'S';
                }
                if (checkBox1.Checked == false)
                {
                    inativo = 'N';
                }

                if (String.IsNullOrEmpty(comboBox1.Text) == true)
                {
                    MessageBox.Show("Campo Finalidade  não selecionado");
                    comboBox1.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox2.Text) == true)
                {
                    MessageBox.Show("Campo Família  não selecionado");
                    comboBox2.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox3.Text) == true)
                {
                    MessageBox.Show("Campo Marca não selecionado");
                    comboBox3.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox4.Text) == true)
                {
                    MessageBox.Show("Campo Modelo não selecionado");
                    comboBox4.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(comboBox5.Text) == true)
                {
                    MessageBox.Show("Campo Unidade não selecionado");
                    comboBox5.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(textBox10.Text) == true)
                {
                    MessageBox.Show("Campo descrição interna não preenchido");
                    textBox10.Focus();
                    return;

                }
                if (String.IsNullOrEmpty(textBox15.Text) == true)
                {
                    textBox15.Text = null;
                }
                /*if (String.IsNullOrEmpty(comboBox6.Text) == true)
                {
                    MessageBox.Show("Campo Gênero não selecionado");

                    return;
                }
                if (String.IsNullOrEmpty(comboBox8.Text) == true)
                {
                    MessageBox.Show("Campo NCM não selecionado");
                    comboBox8.Focus();
                    return;
                }*/
                if (String.IsNullOrEmpty(textBox18.Text) == true)
                {
                    textBox18.Text = null;
                }
                if (String.IsNullOrEmpty(textBox18.Text) == true)
                {
                    textBox18.Text = null;
                }
                if (String.IsNullOrEmpty(textBox18.Text) == false)
                {
                    Int32 qtde10;
                    if (int.TryParse(textBox18.Text.Trim(), out qtde10) == false)
                    {
                        MessageBox.Show("O campo Código EX IPI só aceita valores numéricos");

                        textBox18.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(comboBox9.Text) == true)
                {
                    MessageBox.Show("Campo Moeda compra não selecionado");
                    comboBox9.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(comboBox10.Text) == true)
                {
                    MessageBox.Show("Campo Moeda Faturamento não selecionado");
                    comboBox10.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox21.Text) == true)
                {
                    textBox21.Text = "0,0000";//peso bruto
                }
                if (String.IsNullOrEmpty(textBox21.Text) == false)
                {
                    decimal pesoBruto;
                    if (Decimal.TryParse(textBox21.Text.Trim(), out pesoBruto) == false)
                    {
                        MessageBox.Show("O campo peso Bruto está em formato incorreto");

                        textBox21.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(textBox20.Text) == true)
                {
                    textBox20.Text = "0,0000";
                }
                if (String.IsNullOrEmpty(textBox20.Text) == false)
                {
                    decimal pesoliquido;
                    if (Decimal.TryParse(textBox20.Text.Trim(), out pesoliquido) == false)
                    {
                        MessageBox.Show("O campo peso liquido está em formato incorreto");

                        textBox20.Focus();
                        return;
                    }
                }
                if (String.IsNullOrEmpty(comboBox11.Text) == true)
                {
                    MessageBox.Show("Campo Empresa não selecionado");
                    comboBox11.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox32.Text) == true)
                {
                    textBox32.Text = null;
                }
                if (String.IsNullOrEmpty(textBox31.Text) == true)
                {
                    textBox31.Text = null;
                }
                if (String.IsNullOrEmpty(textBox30.Text) == true)
                {
                    textBox30.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox12.Text) == true)
                {
                    comboBox12.Text = null;
                }
                if (String.IsNullOrEmpty(textBox28.Text) == true)
                {
                    textBox28.Text = null;
                }
                if (String.IsNullOrEmpty(textBox28.Text) == false)
                {

                }

                if (String.IsNullOrEmpty(comboBox15.Text) == true)
                {
                    comboBox15.Text = null;
                }
                if (String.IsNullOrEmpty(dateTimePicker1.Text) == true)
                {
                    dateTimePicker1.Text = null;
                }

                if (String.IsNullOrEmpty(dateTimePicker2.Text) == true)
                {
                    dateTimePicker2.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox16.Text) == true)
                {
                    comboBox16.Text = null;
                }
                if (String.IsNullOrEmpty(textBox24.Text) == true)
                {
                    textBox24.Text = null;
                }
                if (checkBox2.Checked == true)
                {
                    itemOriginal = 'S';
                }
                if (checkBox2.Checked == false)
                {
                    itemOriginal = 'N';
                }
                if (String.IsNullOrEmpty(textBox23.Text) == true)
                {
                    textBox23.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox17.Text) == true)
                {
                    comboBox17.Text = null;
                }

                if (String.IsNullOrEmpty(textBox38.Text) == true)
                {
                    textBox38.Text = "";
                }
                if (String.IsNullOrEmpty(comboBox19.Text) == true)
                {
                    comboBox19.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox20.Text) == true)
                {
                    comboBox20.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox7.Text) == true)
                {
                    comboBox7.Text = null;
                }
                if (String.IsNullOrEmpty(textBox7.Text) == true)
                {
                    textBox7.Text = "0,00";//valor inicial
                }
                if (String.IsNullOrEmpty(textBox4.Text) == true)
                {
                    textBox4.Text = "0,0000";//valor médio
                }
                if (String.IsNullOrEmpty(textBox11.Text) == true)
                {
                    textBox11.Text = "0,00";//desconto de compra
                }
                if (String.IsNullOrEmpty(textBox8.Text) == true)
                {
                    MessageBox.Show("Campo valor de compra não preenchido");
                    tabControl2.SelectedTab = tabPage6;
                    textBox8.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox8.Text) == false)
                {
                    decimal dec1;
                    if (Decimal.TryParse(textBox8.Text.Trim(), out dec1) == false)
                    {
                        MessageBox.Show("Insira somente valores numéricos");
                        textBox8.Text = "";
                        textBox8.Focus();
                        return;
                    }
                }

                if (String.IsNullOrEmpty(textBox12.Text) == true)
                {
                    textBox12.Text = "0,00000";//custo corrigido
                }
                if (checkBox3.Checked == true)
                {
                    margemInversa = 'S';
                }
                if (checkBox3.Checked == false)
                {
                    margemInversa = 'N';
                }
                if (String.IsNullOrEmpty(textBox33.Text) == true)
                {
                    MessageBox.Show("Campo margem não preenchido");
                    tabControl2.SelectedTab = tabPage6;
                    textBox33.Focus();
                    return;
                }
                if (String.IsNullOrEmpty(textBox16.Text) == true)
                {
                    textBox16.Text = "0,00";//valor de venda
                }
                if (String.IsNullOrEmpty(textBox14.Text) == true)
                {
                    textBox14.Text = "0,0000";//venda corrigido
                }
                if (String.IsNullOrEmpty(textBox25.Text) == true)
                {
                    textBox25.Text = "0,00";//valor minimo
                }


                if (String.IsNullOrEmpty(textBox22.Text) == true)
                {
                    textBox22.Text = "0,0000";//margem minima
                }
                if (String.IsNullOrEmpty(textBox19.Text) == true)
                {
                    textBox19.Text = "0,00";//valor promoção
                }
                if (checkBox4.Checked == true)
                {
                    promoção = 'S';
                }
                if (checkBox4.Checked == false)
                {
                    promoção = 'N';
                }
                if (String.IsNullOrEmpty(comboBox22.Text) == true)
                {
                    comboBox22.Text = null;
                }
                if (String.IsNullOrEmpty(textBox17.Text) == true)
                {
                    textBox17.Text = null;
                }
                if (String.IsNullOrEmpty(textBox2.Text) == true)
                {
                    textBox2.Text = null;
                }
                if (String.IsNullOrEmpty(textBox27.Text) == true)
                {
                    textBox27.Text = null;
                }
                if (String.IsNullOrEmpty(comboBox24.Text) == true)
                {
                    comboBox24.Text = null;
                }
                if (String.IsNullOrEmpty(textBox13.Text) == true)
                {
                    textBox13.Text = null;
                }
                if (String.IsNullOrEmpty(textBox13.Text) == false)
                {

                    Int32 qtde4;
                    if (int.TryParse(textBox13.Text.Trim(), out qtde4) == false)
                    {
                        MessageBox.Show("O campo avisar dias sem vender só aceita valores numéricos");

                        textBox13.Focus();
                        return;
                    }

                }
                if (String.IsNullOrEmpty(textBox26.Text) == true)
                {
                    textBox26.Text = null;
                }
                string data = "";
                if (String.IsNullOrEmpty(textBox26.Text) == false)
                {

                    data = textBox26.Text.Replace("/", "");

                    string ano = data.Substring(4, 4);
                    string mes = data.Substring(2, 2);
                    string dia = data.Substring(0, 2);
                    data = ano + mes + dia;

                }
                if (radioButton1.Checked == true)
                {
                    comissao = '1';
                    textBox29.Text = "0,0000";

                }
                if (radioButton3.Checked == true)
                {
                    comissao = '3';
                    textBox29.Text = "0,0000";
                }
                if (radioButton2.Checked == true)
                {
                    if (String.IsNullOrEmpty(textBox29.Text) == true)
                    {
                        MessageBox.Show("Favor fornecer um valor para comissão fixa");
                        textBox29.Focus();
                        return;
                    }
                    else
                    {
                        Decimal qtde4;
                        if (Decimal.TryParse(textBox29.Text.Trim(), out qtde4) == false)
                        {
                            MessageBox.Show("O campo comissão fixa está em formato incorreto");

                            textBox29.Focus();
                            return;
                        }
                        if (Decimal.TryParse(textBox29.Text.Trim(), out qtde4) == true)
                        {
                            comissao = '2';

                        }
                    }
                }
                if (radioButton2.Checked == false)
                {
                    textBox29.Text = "0,0000";
                }
                if (label92.Text == "0")
                {
                    label92.Text = "1";
                    decimal t21;
                    if (Decimal.TryParse(textBox21.Text, out t21))
                    {
                        textBox21.Text = Convert.ToString(t21);
                        textBox21.Text = textBox21.Text.Replace(",", ".");

                    }
                    else
                    {
                        MessageBox.Show("Campo Peso Bruto em formato incorreto");
                        return;
                    }

                    decimal t20;
                    if (Decimal.TryParse(textBox20.Text, out t20))
                    {
                        textBox20.Text = Convert.ToString(t20);
                        textBox20.Text = textBox20.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Peso Líquido em formato incorreto");
                        return;
                    }

                    decimal t7;
                    if (Decimal.TryParse(textBox7.Text, out t7))
                    {
                        textBox7.Text = Convert.ToString(t7);
                        textBox7.Text = textBox7.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo valor inicial em formato incorreto");
                        return;
                    }

                    decimal t4;
                    if (Decimal.TryParse(textBox4.Text, out t4))
                    {
                        textBox4.Text = Convert.ToString(t4);
                        textBox4.Text = textBox4.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor médio em formato incorreto");
                        return;
                    }

                    decimal t11;
                    if (Decimal.TryParse(textBox11.Text, out t11))
                    {
                        textBox11.Text = Convert.ToString(t11);
                        textBox11.Text = textBox11.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Desconto Compra em formato incorreto");
                        return;
                    }

                    decimal t8;
                    if (Decimal.TryParse(textBox8.Text, out t8))
                    {
                        textBox8.Text = Convert.ToString(t8);
                        textBox8.Text = textBox8.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor de compre em formato incorreto");
                        return;
                    }

                    decimal t12;
                    if (Decimal.TryParse(textBox12.Text, out t12))
                    {
                        textBox12.Text = Convert.ToString(t12);
                        textBox12.Text = textBox12.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo custo corrigido em formato incorreto");
                        return;
                    }

                    decimal t33;
                    if (Decimal.TryParse(textBox33.Text, out t33))
                    {
                        textBox33.Text = Convert.ToString(t33);
                        textBox33.Text = textBox33.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo margem em formato incorreto");
                        return;
                    }

                    decimal t16;
                    if (Decimal.TryParse(textBox16.Text, out t16))
                    {
                        textBox16.Text = Convert.ToString(t16);
                        textBox16.Text = textBox16.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor de venda em formato incorreto");
                        return;
                    }

                    decimal t14;
                    if (Decimal.TryParse(textBox14.Text, out t14))
                    {
                        textBox14.Text = Convert.ToString(t14);
                        textBox14.Text = textBox14.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Venda corrigido em formato incorreto");
                        return;
                    }

                    decimal t25;
                    if (Decimal.TryParse(textBox25.Text, out t25))
                    {
                        textBox25.Text = Convert.ToString(t25);
                        textBox25.Text = textBox25.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor mínimo em formato incorreto");
                        return;
                    }

                    decimal t22;
                    if (Decimal.TryParse(textBox22.Text, out t22))
                    {
                        textBox22.Text = Convert.ToString(t22);
                        textBox22.Text = textBox22.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Margem mínima em formato incorreto");
                        return;
                    }

                    decimal t19;
                    if (Decimal.TryParse(textBox19.Text, out t19))
                    {
                        textBox19.Text = Convert.ToString(t19);
                        textBox19.Text = textBox19.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor promoção em formato incorreto");
                        return;
                    }

                    decimal t29;
                    if (Decimal.TryParse(textBox29.Text, out t29))
                    {
                        textBox29.Text = Convert.ToString(t29);
                        textBox29.Text = textBox29.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor médio em formato incorreto");
                        return;
                    }


                    
                }
                if (label92.Text == "editando" && edita == true)
                {
                    int rev = Convert.ToInt32(copia);
                    rev++;
                    copia = Convert.ToString(rev);

                    decimal t21;
                    if (Decimal.TryParse(textBox21.Text, out t21))
                    {
                        textBox21.Text = Convert.ToString(t21);
                        textBox21.Text = textBox21.Text.Replace(",", ".");

                    }
                    else
                    {
                        MessageBox.Show("Campo Peso Bruto em formato incorreto");
                        return;
                    }

                    decimal t20;
                    if (Decimal.TryParse(textBox20.Text, out t20))
                    {
                        textBox20.Text = Convert.ToString(t20);
                        textBox20.Text = textBox20.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Peso Líquido em formato incorreto");
                        return;
                    }

                    decimal t7;
                    if (Decimal.TryParse(textBox7.Text, out t7))
                    {
                        textBox7.Text = Convert.ToString(t7);
                        textBox7.Text = textBox7.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo valor inicial em formato incorreto");
                        return;
                    }

                    decimal t4;
                    if (Decimal.TryParse(textBox4.Text, out t4))
                    {
                        textBox4.Text = Convert.ToString(t4);
                        textBox4.Text = textBox4.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor médio em formato incorreto");
                        return;
                    }

                    decimal t11;
                    if (Decimal.TryParse(textBox11.Text, out t11))
                    {
                        textBox11.Text = Convert.ToString(t11);
                        textBox11.Text = textBox11.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Desconto Compra em formato incorreto");
                        return;
                    }

                    decimal t8;
                    if (Decimal.TryParse(textBox8.Text, out t8))
                    {
                        textBox8.Text = Convert.ToString(t8);
                        textBox8.Text = textBox8.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor de compre em formato incorreto");
                        return;
                    }

                    decimal t12;
                    if (Decimal.TryParse(textBox12.Text, out t12))
                    {
                        textBox12.Text = Convert.ToString(t12);
                        textBox12.Text = textBox12.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo custo corrigido em formato incorreto");
                        return;
                    }

                    decimal t33;
                    if (Decimal.TryParse(textBox33.Text, out t33))
                    {
                        textBox33.Text = Convert.ToString(t33);
                        textBox33.Text = textBox33.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo margem em formato incorreto");
                        return;
                    }

                    decimal t16;
                    if (Decimal.TryParse(textBox16.Text, out t16))
                    {
                        textBox16.Text = Convert.ToString(t16);
                        textBox16.Text = textBox16.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor de venda em formato incorreto");
                        return;
                    }

                    decimal t14;
                    if (Decimal.TryParse(textBox14.Text, out t14))
                    {
                        textBox14.Text = Convert.ToString(t14);
                        textBox14.Text = textBox14.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Venda corrigido em formato incorreto");
                        return;
                    }

                    decimal t25;
                    if (Decimal.TryParse(textBox25.Text, out t25))
                    {
                        textBox25.Text = Convert.ToString(t25);
                        textBox25.Text = textBox25.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor mínimo em formato incorreto");
                        return;
                    }

                    decimal t22;
                    if (Decimal.TryParse(textBox22.Text, out t22))
                    {
                        textBox22.Text = Convert.ToString(t22);
                        textBox22.Text = textBox22.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Margem mínima em formato incorreto");
                        return;
                    }

                    decimal t19;
                    if (Decimal.TryParse(textBox19.Text, out t19))
                    {
                        textBox19.Text = Convert.ToString(t19);
                        textBox19.Text = textBox19.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor promoção em formato incorreto");
                        return;
                    }

                    decimal t29;
                    if (Decimal.TryParse(textBox29.Text, out t29))
                    {
                        textBox29.Text = Convert.ToString(t29);
                        textBox29.Text = textBox29.Text.Replace(",", ".");
                    }
                    else
                    {
                        MessageBox.Show("Campo Valor médio em formato incorreto");
                        return;
                    }


                    //decimal estPeso;
                    string estoqueP;
                    estoqueP = "0.0";

                    if (comboBox7.Text == "Preço" || comboBox7.Text == "Peso")
                    {
                        int temppp = Convert.ToInt32(textBox2.Text) * 1000;

                        decimal t30;
                        if (Decimal.TryParse(textBox20.Text.Replace(".", ","), out t30))
                        {

                            estoqueP = Convert.ToString(t30 * temppp);
                            if (Convert.ToInt32(label93.Text) > 0 && Convert.ToDecimal(textBox40.Text) > 0)
                            {
                                estoqueP = Convert.ToString(Convert.ToDecimal(estoqueP) + Convert.ToDecimal(textBox40.Text));
                            }
                            estoqueP = estoqueP.Replace(",", ".");
                        }
                        else
                        {
                            MessageBox.Show("Campo peso liquido com valor incorreto");
                            return;
                        }
                        textBox2.Text = "0";
                    }
                    //verifica se EAN já está cadastrado
                    if (Global.Margem.EANTemp2 != Global.Margem.EANTemp)
                    {
                        String recebe = Convert.ToString(DALCadastro.TemEAN(Global.Margem.EANTemp2));
                        if (String.IsNullOrEmpty(recebe) == false)
                        {
                            DataTable testa = DALCadastro.produtoVenda(Global.Margem.EANTemp2);
                            if (testa.Rows.Count == 1)
                            {
                                MessageBox.Show("Existe cadastro com este código de barras.\n" + testa.Rows[0]["DescInterna"].ToString() + "\n==> Id produto: " +
                                    testa.Rows[0]["IdProd"].ToString());
                                textBox9.Text = "";
                                textBox9.Focus();
                                Global.Margem.EANTemp2 = "";
                                return;
                            }
                        }
                    }
                    DALCadastro.Cadastrar_Produto_Editar(/*informa identificador a ser editado*/ label93.Text, /*1 Revisão*/ copia,
                        /*2 Código DNF*/ textBox1.Text, /*3 cod EAN*/ textBox9.Text, /*4 EAN Trib*/ textBox3.Text, /*5 cod fornecimento*/ textBox6.Text,
                        /* 6 referência*/ textBox5.Text, /* 7 inativo*/ inativo, /*8 finalidade*/ comboBox1.Text, /*9 familia*/comboBox2.Text,
                        /*10 marca*/comboBox3.Text, /*11 modelo*/comboBox4.Text,
                        /*12 unidade*/comboBox5.Text, /*13 descrição interna*/textBox10.Text, /*14 grade*/textBox15.Text, /*15 gênero*/comboBox6.Text,
                        /*16 NCM*/comboBox8.Text, /*17 EX IPI*/textBox18.Text, /*18 moeda compra*/comboBox9.Text, /*19 moeda faturamento*/comboBox10.Text,
                        /*20 peso bruto*/textBox21.Text, /*21 peso líquido*/textBox20.Text, /*22 empresa*/comboBox11.Text,
                        /*23 nome original NF*/textBox32.Text,/*24 nome fabricante*/textBox31.Text, /*25 observações*/textBox30.Text,
                        /*26 grupo compradores*/comboBox12.Text, /*27 garantia*/textBox28.Text, /*28 inicio*/dateTimePicker1.Text,
                        /*29 final*/dateTimePicker2.Text,/*30 método suprimento*/comboBox16.Text, /*31 impacto*/textBox24.Text,
                        /*32 original*/itemOriginal, /*33 data cadastro*/label67.Text,
                        /*34 usuario cadastrou*/textBox23.Text, /*35 grupo tributário saídas*/comboBox17.Text,
                        /*36 grupo tributário entradas*/textBox38.Text, /*37 cod serviço SEFAZ*/comboBox19.Text, /*38 IPI*/comboBox20.Text,
                        /*39 vender por*/comboBox7.Text, /*40 valor inicial*/textBox7.Text, /*41 valor médio*/textBox4.Text, /*42 desc compra*/textBox11.Text,
                        /*43 valor compra*/textBox8.Text, /*44 custo corrigido*/textBox12.Text, /*45 margem inversa*/margemInversa,
                        /*46 margem*/textBox33.Text, /*47 valor venda*/textBox16.Text, /*48 venda corrigido*/textBox14.Text,
                        /*49 valor minimo*/textBox25.Text, /*50 margem minima*/textBox22.Text, /*51 valor promoção*/textBox19.Text, /*52 promoção*/promoção,
                        /*53 grupo carregamento*/comboBox22.Text, /*54 múltiplo*/textBox17.Text, /*55 estoque INT*/textBox2.Text,
                        /*56 estoque peso*/estoqueP, /*57 qtd reservada*/textBox27.Text, /*58 localização física*/comboBox24.Text,
                        /*59 dias sem vender*/textBox13.Text, /*60 tempo de reposição*/data, /*61 marca dias sem vender*/tipoComissao,
                        /*62 tipo comissão*/comissao, /*63 comissão fixa*/textBox29.Text);

                    edita = false;
                    Form cadC = new OK();
                    cadC.ShowDialog();
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CadProdutos", "Edição de registro de produto : " + textBox5.Text);
                    }
                    //||||||||||||||Criar eventos|||||||||||
                    //||||||||||||||||||||||||||||||||||||||
                    if (Convert.ToInt32(textBox27.Text) > 0)
                    {
                        DALCadastro.criarEvento("Reservado", label93.Text, textBox10.Text, "XXXXXXXXXXX", textBox27.Text);
                    }

                    if (Convert.ToInt32(textBox13.Text) > 0)
                    {
                        DateTime temp = DateTime.Now.AddDays(Convert.ToInt32(textBox13.Text));

                        DALCadastro.criarEvento("Dias Sem Vender", label93.Text, textBox10.Text,
                            Convert.ToString(temp.ToShortDateString()), "Produto ficou " + textBox13.Text + " dias sem vender");
                    }
                    if (String.IsNullOrEmpty(textBox26.Text) == false)
                    {
                        //DateTime temp1 = DateTime.Now.AddDays(Convert.ToInt32(textBox26.Text));
                        
                        DALCadastro.criarEvento("Tempo de Reposição", label93.Text, textBox10.Text,
                            data, "Data do aviso de vencimento : " + textBox26.Text );
                    }

                    limpaForm();
                    copia = "";

                    label92.Text = "";
                    tabControl2.SelectedTab = tabPage3;
                    comboBox7.Visible = false;
                    textBox9.ReadOnly = false;
                    checkBox5.Enabled = true;
                    textBox16.ReadOnly = true;
                    abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(label93.Text)));
                    return;
                }
                if (Convert.ToInt32(label92.Text) >= 1 && edita == false)
                {
                    MessageBox.Show("já cadastrado");

                }

            
            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            Form cor = new CadCores();
            cor.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            if (panel10.Width >= 972 || panel1.Width >= 972)
            {
                tabControl2.SelectedTab = tabPage3;
                return;

            }
            timer1.Enabled = true;
            //pictureBox5.Image = null;


            Form formPrincipal = new TelaPrincipal();

            GerenciadorDeFormulario.Abre(formPrincipal);
            GerenciadorDeFormulario.Fecha(this);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (panel10.Width >= 972 || panel1.Width >= 972)
            {
                tabControl2.SelectedTab = tabPage3;
                return;

            }
            timer1.Enabled = true;


            Application.Exit();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (panel10.Width >= 972 || panel1.Width >= 972)
            {
                tabControl2.SelectedTab = tabPage3;



            }
            if (String.IsNullOrEmpty(label92.Text) || label92.Text == "não finalizado")
            {
                tabControl2.SelectedTab = tabPage3;
            }
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            textBox9.BackColor = System.Drawing.Color.Cyan;
            pictureBox12.Visible = true;
            label8.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label8.BackColor = System.Drawing.Color.Cyan;
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                panel4.Focus();
                textBox9.BackColor = System.Drawing.Color.White;
                pictureBox12.Visible = false;
                label8.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
                label8.BackColor = System.Drawing.Color.Transparent;
                return;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            textBox9.BackColor = System.Drawing.Color.White;
            pictureBox12.Visible = false;
            label8.Font = new Font(label18.Font, FontStyle.Regular);
            label8.BackColor = System.Drawing.Color.Transparent;
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.BackColor = System.Drawing.Color.Cyan;
            pictureBox13.Visible = true;
            label9.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label9.ForeColor = System.Drawing.Color.Red;
            label9.BackColor = System.Drawing.Color.Cyan;
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                panel4.Focus();
                textBox3.BackColor = System.Drawing.Color.White;
                pictureBox13.Visible = false;
                label9.ForeColor = System.Drawing.Color.Black;
                label9.Font = new Font(label19.Font, FontStyle.Regular);
                label9.BackColor = System.Drawing.Color.Transparent;
                return;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.BackColor = System.Drawing.Color.White;
            pictureBox13.Visible = false;
            label9.ForeColor = System.Drawing.Color.Black;
            label9.Font = new Font(label19.Font, FontStyle.Regular);
            label9.BackColor = System.Drawing.Color.Transparent;
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.BackColor = System.Drawing.Color.Cyan;
            pictureBox14.Visible = true;
            label10.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label10.ForeColor = System.Drawing.Color.Red;
            label10.BackColor = System.Drawing.Color.Cyan;


            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                textBox6.BackColor = System.Drawing.Color.White;
                panel4.Focus();
                pictureBox14.Visible = false;
                label10.ForeColor = System.Drawing.Color.Black;
                label10.Font = new Font(label10.Font, FontStyle.Regular);
                label10.BackColor = System.Drawing.Color.Transparent;
                label10.Font = new Font("Microsoft Sans Serif", 8.0F);

                return;
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

            textBox6.BackColor = System.Drawing.Color.White;
            pictureBox14.Visible = false;
            label10.ForeColor = System.Drawing.Color.Black;

            label10.Font = new Font(label10.Font, FontStyle.Regular);
            label10.Font = new Font("Microsoft Sans Serif", 8.0F);

            label10.BackColor = System.Drawing.Color.Transparent;
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.BackColor = System.Drawing.Color.Cyan;
            pictureBox15.Visible = true;
            label11.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label11.BackColor = System.Drawing.Color.Cyan;
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                textBox5.BackColor = System.Drawing.Color.White;
                panel4.Focus();
                pictureBox15.Visible = false;
                label11.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
                label11.BackColor = System.Drawing.Color.Transparent;
                return;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.BackColor = System.Drawing.Color.White;
            pictureBox15.Visible = false;
            label11.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label11.BackColor = System.Drawing.Color.Transparent;
            textBox10.Text = textBox5.Text;
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void checkBox1_Enter(object sender, EventArgs e)
        {
            pictureBox17.Visible = true;
            label12.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label12.ForeColor = System.Drawing.Color.Red;
            label12.BackColor = System.Drawing.Color.Cyan;
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                panel4.Focus();
                pictureBox17.Visible = false;
                label12.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
                label12.ForeColor = System.Drawing.Color.Black;
                label12.BackColor = System.Drawing.Color.Transparent;
                return;
            }
        }

        private void checkBox1_Leave(object sender, EventArgs e)
        {
            pictureBox17.Visible = false;
            label12.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label12.ForeColor = System.Drawing.Color.Black;
            label12.BackColor = System.Drawing.Color.Transparent;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (label92.Text == "editando")
            {
                if (checkBox1.Checked == true)
                {
                    MessageBox.Show("Produto Inativado");
                    Global.Margem.Reload = "Sim";
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CadProdutos", "Produto Inativado : " + textBox5.Text);
                    }


                }
                else
                {
                    MessageBox.Show("Produto Ativo");
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CadProdutos", "Produto Reativado : " + textBox5.Text);
                    }

                }
            }
            else
            {
                checkBox1.Checked = false;


            }
            
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            pictureBox16.Visible = true;
            label13.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label13.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Focus();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            pictureBox16.Visible = false;
            label13.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label13.BackColor = System.Drawing.Color.Transparent;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            pictureBox18.Visible = true;
            label14.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label14.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            pictureBox18.Visible = false;
            label14.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label14.BackColor = System.Drawing.Color.Transparent;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Focus();
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            pictureBox19.Visible = true;
            label15.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label15.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox3_Leave(object sender, EventArgs e)
        {
            pictureBox19.Visible = false;
            label15.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label15.BackColor = System.Drawing.Color.Transparent;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Focus();
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            pictureBox20.Visible = true;
            label16.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label16.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox4_Leave(object sender, EventArgs e)
        {
            pictureBox20.Visible = false;
            label16.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label16.BackColor = System.Drawing.Color.Transparent;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Focus();
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            pictureBox21.Visible = true;
            label17.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label17.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox5_Leave(object sender, EventArgs e)
        {
            pictureBox21.Visible = false;
            label17.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label17.BackColor = System.Drawing.Color.Transparent;
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            textBox10.BackColor = System.Drawing.Color.Cyan;
            pictureBox22.Visible = true;
            label18.Font = new Font(label18.Font, FontStyle.Bold);
            label18.BackColor = System.Drawing.Color.Cyan;
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                textBox10.BackColor = System.Drawing.Color.White;
                panel4.Focus();
                pictureBox22.Visible = false;
                label18.BackColor = System.Drawing.Color.White;
                label18.Font = new Font(label18.Font, FontStyle.Regular);
                return;
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            textBox10.BackColor = System.Drawing.Color.White;
            pictureBox22.Visible = false;
            label18.BackColor = System.Drawing.Color.White;
            label18.Font = new Font(label18.Font, FontStyle.Regular);
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox15.Focus();

            }
        }

        private void textBox15_Enter(object sender, EventArgs e)
        {
            textBox15.BackColor = System.Drawing.Color.Cyan;
            pictureBox23.Visible = true;
            label19.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label19.ForeColor = System.Drawing.Color.Red;
            label19.BackColor = System.Drawing.Color.Cyan;
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                textBox15.BackColor = System.Drawing.Color.White;
                panel4.Focus();
                pictureBox23.Visible = false;
                label19.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
                label19.ForeColor = System.Drawing.Color.Black;
                label19.BackColor = System.Drawing.Color.Transparent;
                return;
            }
        }

        private void textBox15_Leave(object sender, EventArgs e)
        {
            textBox15.BackColor = System.Drawing.Color.White;
            pictureBox23.Visible = false;
            label19.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label19.ForeColor = System.Drawing.Color.Black;
            label19.BackColor = System.Drawing.Color.Transparent;
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            pictureBox24.Visible = true;
            label20.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label20.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox6_Leave(object sender, EventArgs e)
        {
            pictureBox24.Visible = false;
            label20.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label20.BackColor = System.Drawing.Color.Transparent;
        }

        private void comboBox8_Click(object sender, EventArgs e)
        {
            pictureBox25.Visible = true;
            label21.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label21.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox8_Leave(object sender, EventArgs e)
        {
            pictureBox25.Visible = false;
            label21.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label21.BackColor = System.Drawing.Color.Transparent;
        }

        private void textBox18_Enter(object sender, EventArgs e)
        {
            textBox18.BackColor = System.Drawing.Color.Cyan;
            pictureBox26.Visible = true;
            label22.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label22.ForeColor = System.Drawing.Color.Red;
            label22.BackColor = System.Drawing.Color.Cyan;

            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                textBox18.BackColor = System.Drawing.Color.White;
                panel4.Focus();
                pictureBox26.Visible = false;
                label22.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
                label22.ForeColor = System.Drawing.Color.Black;
                label22.BackColor = System.Drawing.Color.Transparent;
                return;
            }
        }

        private void textBox18_Leave(object sender, EventArgs e)
        {
            textBox21.BackColor = System.Drawing.Color.White;
            pictureBox26.Visible = false;
            label25.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label25.ForeColor = System.Drawing.Color.Black;
            label25.BackColor = System.Drawing.Color.Transparent;
        }

        private void comboBox9_Click(object sender, EventArgs e)
        {
            pictureBox27.Visible = true;
            label23.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label23.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox9_Leave(object sender, EventArgs e)
        {
            pictureBox27.Visible = false;
            label23.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label23.BackColor = System.Drawing.Color.Transparent;
        }

        private void comboBox10_Click(object sender, EventArgs e)
        {
            pictureBox28.Visible = true;
            label24.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label24.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox10_Leave(object sender, EventArgs e)
        {
            pictureBox28.Visible = false;
            label24.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label24.BackColor = System.Drawing.Color.Transparent;
        }

        private void textBox21_Enter(object sender, EventArgs e)
        {
            textBox21.BackColor = System.Drawing.Color.Cyan;
            pictureBox29.Visible = true;
            label25.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label25.ForeColor = System.Drawing.Color.Red;
            label25.BackColor = System.Drawing.Color.Cyan;
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                textBox21.BackColor = System.Drawing.Color.White;
                panel4.Focus();
                pictureBox29.Visible = false;
                label25.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
                label25.ForeColor = System.Drawing.Color.Black;
                label25.BackColor = System.Drawing.Color.Transparent;

                return;
            }
        }

        private void textBox21_Leave(object sender, EventArgs e)
        {
            textBox21.BackColor = System.Drawing.Color.White;
            pictureBox29.Visible = false;
            label25.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label25.ForeColor = System.Drawing.Color.Black;
            label25.BackColor = System.Drawing.Color.Transparent;
        }

        private void textBox20_Enter(object sender, EventArgs e)
        {
            textBox20.BackColor = System.Drawing.Color.Cyan;
            pictureBox30.Visible = true;
            label26.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label26.ForeColor = System.Drawing.Color.Red;
            label26.BackColor = System.Drawing.Color.Cyan;

            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Você deve abrir um novo cadastro ");
                textBox20.BackColor = System.Drawing.Color.White;
                panel4.Focus();
                pictureBox30.Visible = false;
                label26.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
                label26.ForeColor = System.Drawing.Color.Black;
                label26.BackColor = System.Drawing.Color.Transparent;

                return;
            }
        }

        private void textBox20_Leave(object sender, EventArgs e)
        {
            textBox20.BackColor = System.Drawing.Color.White;
            pictureBox30.Visible = false;
            label26.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label26.ForeColor = System.Drawing.Color.Black;
            label26.BackColor = System.Drawing.Color.Transparent;
        }

        private void comboBox11_Click(object sender, EventArgs e)
        {
            pictureBox31.Visible = true;
            label27.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Bold);
            label27.BackColor = System.Drawing.Color.Cyan;
        }

        private void comboBox11_Leave(object sender, EventArgs e)
        {
            pictureBox31.Visible = false;
            label27.Font = new Font("Microsoft Sans Serif", 8.0F, FontStyle.Regular);
            label27.BackColor = System.Drawing.Color.Transparent;
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form finalidadeCad = new AUXCadFinalidade();
                finalidadeCad.ShowDialog();
                if (finalidadeCad.DialogResult == DialogResult.Cancel)
                {
                    comboBox1.DataSource = DALCadastro.Listar_Finalidade();
                    comboBox1.ValueMember = "Descrição";
                    comboBox1.DisplayMember = "Descricao";
                    comboBox1.SelectedItem = "";
                    comboBox1.Refresh();
                }

            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form familiaCad = new AUXCadFamilia();
                familiaCad.ShowDialog();
                if (familiaCad.DialogResult == DialogResult.Cancel)
                {
                    comboBox2.DataSource = DALCadastro.AUXCadListar("ListarCadFamilia");
                    comboBox2.ValueMember = "Descrição";
                    comboBox2.DisplayMember = "Descricao";
                    comboBox2.SelectedItem = "";
                    comboBox2.Refresh();

                }

            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form marcaCad = new AUXCadMarca();
                marcaCad.ShowDialog();
                if (marcaCad.DialogResult == DialogResult.Cancel)
                {
                    comboBox3.DataSource = DALCadastro.AUXCadListar("ListarCadMarca");
                    comboBox3.ValueMember = "Descrição";
                    comboBox3.DisplayMember = "Descricao";
                    comboBox3.SelectedItem = "";
                    comboBox3.Refresh();

                }
            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form modeloCad = new AUXCadModelo();
                modeloCad.ShowDialog();
                if (modeloCad.DialogResult == DialogResult.Cancel)
                {
                    comboBox4.DataSource = DALCadastro.AUXCadListar("ListarCadModelo");
                    comboBox4.ValueMember = "Descrição";
                    comboBox4.DisplayMember = "Descricao";
                    comboBox4.SelectedItem = "";
                    comboBox4.Refresh();

                }
            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form unidadeCad = new AUXCadUnidade();
                unidadeCad.ShowDialog();
                if (unidadeCad.DialogResult == DialogResult.Cancel)
                {
                    comboBox5.DataSource = DALCadastro.AUXCadListar("ListarCadUnidade");
                    comboBox5.ValueMember = "Descrição";
                    comboBox5.DisplayMember = "Descricao";
                    comboBox5.SelectedItem = "";
                    comboBox5.Refresh();

                }
            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form generoCad = new AUXCadGenero();
                generoCad.ShowDialog();
                if (generoCad.DialogResult == DialogResult.Cancel)
                {
                    comboBox6.DataSource = DALCadastro.AUXCadListar("ListarCadGenero");
                    comboBox6.ValueMember = "Codigo";
                    comboBox6.DisplayMember = "Codigo";
                    comboBox6.SelectedItem = "";
                    comboBox6.Refresh();
                    comboBox6.Text = Global.Margem.generoTemp;

                    MessageBox.Show("Descrição do código de Gênero selecionado : \n\n" + Global.Margem.generoTemp2);
                    Global.Margem.generoTemp = "";
                    Global.Margem.generoTemp2 = "";

                }
            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form ncmCad = new AUXCadNCM();
                ncmCad.ShowDialog();
                if (ncmCad.DialogResult == DialogResult.Cancel)
                {
                    comboBox8.DataSource = DALCadastro.AUXCadListar("ListarCadNCM");
                    comboBox8.ValueMember = "Codigo_NCM";
                    comboBox8.DisplayMember = "Codigo_NCM";
                    comboBox8.SelectedItem = "";
                    comboBox8.Refresh();

                    comboBox8.Text = Global.Margem.NCMTemp;

                    MessageBox.Show("Descrição do código de Gênero selecionado : \n\n" + Global.Margem.NCMTemp2);

                    comboBox6.DataSource = DALCadastro.AUXCadListar("ListarCadGenero");
                    comboBox6.ValueMember = "Codigo";
                    comboBox6.DisplayMember = "Codigo";
                    comboBox6.SelectedItem = "";
                    comboBox6.Refresh();
                    if (String.IsNullOrEmpty(Global.Margem.NCMTemp) == false)
                    {
                        comboBox6.Text = Global.Margem.NCMTemp.Substring(0, 2);
                    }

                    Global.Margem.NCMTemp = "";
                    Global.Margem.NCMTemp2 = "";

                }
            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form moedaCad = new AUXCadMoeda();
                moedaCad.ShowDialog();
                if (moedaCad.DialogResult == DialogResult.Cancel)
                {
                    comboBox9.DataSource = DALCadastro.AUXCadListar("ListarCadMoeda");
                    comboBox9.ValueMember = "Descrição";
                    comboBox9.DisplayMember = "Descricao";
                    comboBox9.SelectedItem = "";
                    comboBox9.Refresh();

                    comboBox10.DataSource = DALCadastro.AUXCadListar("ListarCadMoeda");
                    comboBox10.ValueMember = "Descrição";
                    comboBox10.DisplayMember = "Descricao";
                    comboBox10.SelectedItem = "";
                    comboBox10.Refresh();

                }
            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form moedaCad = new AUXCadMoeda();
                moedaCad.ShowDialog();
                if (moedaCad.DialogResult == DialogResult.Cancel)
                {

                    comboBox9.DataSource = DALCadastro.AUXCadListar("ListarCadMoeda");
                    comboBox9.ValueMember = "Descrição";
                    comboBox9.DisplayMember = "Descricao";
                    comboBox9.SelectedItem = "";
                    comboBox9.Refresh();

                    comboBox10.DataSource = DALCadastro.AUXCadListar("ListarCadMoeda");
                    comboBox10.ValueMember = "Descrição";
                    comboBox10.DisplayMember = "Descricao";
                    comboBox10.SelectedItem = "";
                    comboBox10.Refresh();

                }
            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == false)
            {
                Form cadEmpresa = new AUXCadEmpresa();
                cadEmpresa.ShowDialog();
                if (cadEmpresa.DialogResult == DialogResult.Cancel)
                {
                    comboBox11.DataSource = DALCadastro.AUXCadListar("ListarCadEmpresa");
                    comboBox11.ValueMember = "Descrição";
                    comboBox11.DisplayMember = "Descricao";
                    comboBox11.SelectedItem = "";
                    comboBox11.Refresh();



                }

            }
            else
            {
                MessageBox.Show("Você deve abrir um novo cadastro");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (String.IsNullOrEmpty(textBox10.Text) == false && String.IsNullOrEmpty(label93.Text) == false)
            {
                // Displays an OpenFileDialog so the user can select a Cursor.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Cursor Files|*.jpg";
                openFileDialog1.Title = "Selecione uma imagem para o produto";

                // Show the Dialog.
                // If the user clicked OK in the dialog and
                // a .CUR file was selected, open it.
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Assign the cursor in the Stream to the Form's Cursor property.
                    Image Imagem = Image.FromFile(openFileDialog1.FileName);
                    string caminho = openFileDialog1.FileName;
                    label108.Text = caminho;
                    pictureBox5.Image = Imagem;
                    button2.Visible = true;

                }
            }
            else
            {
                MessageBox.Show("Cadastro de produto vazio!");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (String.IsNullOrEmpty(textBox10.Text) == false && String.IsNullOrEmpty(label93.Text) == false)
            {
                string strConnection = "";
                if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
                {
                    strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                }
                if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
                {
                    string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                    string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                    strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975";
                }
                string strSQL = "Alterar_imagem";
                // Displays an OpenFileDialog so the user can select a Cursor.
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Cursor Files|*.jpg";
                openFileDialog1.Title = "Selecione uma imagem para o produto";

                // Show the Dialog.
                // If the user clicked OK in the dialog and
                // a .CUR file was selected, open it.
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Assign the cursor in the Stream to the Form's Cursor property.
                    Image Imagem = Image.FromFile(openFileDialog1.FileName);
                    string message = "Você deseja alterar a imagem do  produto:\n" + textBox10.Text + "\n\n" + "Por esta imagem: \n" + openFileDialog1.FileName.ToString();
                    string caption = "Imagem";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("Alteração de imagem cancelada");
                        return;

                    }
                    string caminho = openFileDialog1.FileName;
                    label108.Text = caminho;
                    pictureBox5.Image = Imagem;
                    FileStream fs = new FileStream(label108.Text, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    byte[] imagemArray = br.ReadBytes((int)fs.Length);
                    //cria a conexão com o banco de dados
                    OleDbConnection dbConnection = new OleDbConnection(strConnection);

                    //cria a conexão com o banco de dados
                    OleDbConnection con = new OleDbConnection(strConnection);
                    //cria o objeto command para executar a instruçao sql
                    OleDbCommand cmd = new OleDbCommand(strSQL, con);


                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@identificador", label93.Text);
                    cmd.Parameters.AddWithValue("@imagem", imagemArray);

                    try
                    {

                        cmd.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(Convert.ToString(ex));
                    }
                    finally
                    {
                        cmd.Connection.Close();
                        cmd.Connection.Dispose();
                        br.Close();
                        fs.Close();

                        MessageBox.Show("Imagem: \n" + label108.Text + "\n" + "\nInserida com sucesso!");
                        label108.Text = "";
                    }

                }

            }
            else
            {
                MessageBox.Show("Cadastro de produto vazio!");
            }
            
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975";
            }
           
            string strSQL = "Inserir_imagem";

            //Trabsnf. foto em Bites 

            FileStream fs = new FileStream(label108.Text, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            byte[] imagemArray = br.ReadBytes((int)fs.Length);




            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);


            cmd.Connection.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@identificador", label93.Text);
            cmd.Parameters.AddWithValue("@imagem", imagemArray);

            try
            {
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
                br.Close();
                fs.Close();
                MessageBox.Show("Imagem: " + label108.Text + "\nInserida com sucesso no banco de dados");
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                label108.Text = "";

            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;

            contador++;

            if (contador == 4)
            {
                Application.UseWaitCursor = false;
                contador = 0;
                timer1.Enabled = false;
            }
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            groupBox11.Visible = false;
            Application.UseWaitCursor = true;
            panel1.Visible = true;
            while (panel1.Width > 0)
            {
                panel1.Width = panel1.Width - 40;
            }

            panel1.Width = 0;
            panel1.Visible = false;
            Application.UseWaitCursor = false;
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            groupBox13.Visible = false;
            Application.UseWaitCursor = true;
            panel10.Visible = true;
            while (panel10.Width > 0)
            {
                panel10.Width = panel10.Width - 40;
            }

            panel10.Width = 0;
            panel10.Visible = false;
            Application.UseWaitCursor = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (label92.Text == "editando")
            {
                MessageBox.Show("Edição aberta!");
                return;
            }
            if (label92.Text == "não finalizado")
            {
                MessageBox.Show("Precisa salvar registro primeiro");
                return;
            }
            if (String.IsNullOrEmpty(label92.Text) == true)
            {
                MessageBox.Show("Selecione registro para edição");
                return;
            }

            if (Convert.ToInt32(label92.Text) >= 1)
            {
                Form al3 = new Alert3();
                al3.ShowDialog();
                if (Global.Margem.EditarCad == "sim")
                {
                    copia = label92.Text;
                    edita = true;
                    label92.Text = "editando";
                    //textBox26.Text = "";
                    Global.Margem.EditarCad = "";

                }
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form ajudaean = new AjudaEAN();
            ajudaean.Show();
        }

        private void pictureBox57_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label93.Text) == false && label92.Text == "editando")
            {
                if (Global.Margem.CadastroProdutos != "adm")
                {
                    MessageBox.Show("Acesso não autorizado");
                    return;
                }
                Global.Margem.xProd = textBox10.Text;
                Global.Margem.IdProdSAT = label93.Text;
                Global.Margem.EstoqueCusto = textBox8.Text;
                Global.Margem.EstoqueValor = textBox16.Text;
                Global.Margem.EstoqueQtde = textBox2.Text;
                Global.Margem.EstoqueUnd = comboBox5.Text;
                Form estoque = new AuxCadEstoque();
                estoque.ShowDialog();
                textBox2.Text = Global.Margem.EstoqueQtde;
                Global.Margem.xProd = "";
                Global.Margem.IdProdSAT = "";
                Global.Margem.EstoqueCusto = "";
                Global.Margem.EstoqueValor = "";
                Global.Margem.EstoqueQtde = "";
                Global.Margem.EstoqueUnd = "";
                return;
            }
            if (String.IsNullOrEmpty(label93.Text) == false && Convert.ToInt32(label92.Text) > 0)
            {
                if (Global.Margem.CadastroProdutos != "adm")
                {
                    MessageBox.Show("Acesso não autorizado");
                    return;
                }
                Global.Margem.xProd = textBox10.Text;
                Global.Margem.IdProdSAT = label93.Text;
                Global.Margem.EstoqueCusto = textBox8.Text;
                Global.Margem.EstoqueValor = textBox16.Text;
                Global.Margem.EstoqueQtde = textBox2.Text;
                Global.Margem.EstoqueUnd = comboBox5.Text;
                Form estoque = new AuxCadEstoque();
                estoque.ShowDialog();
                textBox2.Text = Global.Margem.EstoqueQtde;
                Global.Margem.xProd = "";
                Global.Margem.IdProdSAT = "";
                Global.Margem.EstoqueCusto = "";
                Global.Margem.EstoqueValor = "";
                Global.Margem.EstoqueQtde = "";
                Global.Margem.EstoqueUnd = "";
            }
            if (String.IsNullOrEmpty(label93.Text) == false && Convert.ToInt32(label92.Text) == 0)
            {
                if (Global.Margem.CadastroProdutos != "adm")
                {
                    MessageBox.Show("Acesso não autorizado");
                    return;
                }
                Global.Margem.TemCad = "não";
                Global.Margem.xProd = textBox10.Text;
                Global.Margem.IdProdSAT = label93.Text;
                Global.Margem.EstoqueCusto = textBox8.Text;
                Global.Margem.EstoqueValor = textBox16.Text;
                Global.Margem.EstoqueQtde = textBox2.Text;
                Global.Margem.EstoqueUnd = comboBox5.Text;
                Form estoque = new AuxCadEstoque();
                estoque.ShowDialog();
                textBox2.Text = Global.Margem.EstoqueQtde;
                Global.Margem.xProd = "";
                Global.Margem.IdProdSAT = "";
                Global.Margem.EstoqueCusto = "";
                Global.Margem.EstoqueValor = "";
                Global.Margem.EstoqueQtde = "";
                Global.Margem.EstoqueUnd = "";
                Global.Margem.TemCad = "";
            }
            //código para atualizar estoque
        }

        private void pictureBox55_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == false)
            {
                Global.Margem.MargemTipo = "normal";
            }
            if (checkBox3.Checked == true)
            {
                Global.Margem.MargemTipo = "inversa";
            }
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (String.IsNullOrEmpty(textBox33.Text) == false && String.IsNullOrEmpty(textBox8.Text) == false)
            {

                Form margem = new AuxCadCalculaMargem(label93.Text, textBox10.Text, textBox8.Text,textBox16.Text);
                margem.ShowDialog();
                if (Global.Margem.MargemLocal == "sim")
                {
                    textBox33.Text = Global.Margem.MargemM;
                    textBox16.Text = Global.Margem.Valor;
                }
                Global.Margem.MargemLocal = "";
            }
            
        }

        private void label107_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox59_Click(object sender, EventArgs e)
        {
            Form image = new ImagemInternet();
            image.ShowDialog();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox37.Text) == false)
            {

                if (String.IsNullOrEmpty(label93.Text) == true)
                {
                    if (dataGridView4.Rows.Count > 0)
                    {
                        
                        abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString())));
                        panel1.Width = 0;
                        return;    
                    }
                    

                }
                if (String.IsNullOrEmpty(label93.Text) == false)
                {
                    int ident = Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString());

                    if (ident == Convert.ToInt32(label93.Text))
                    {
                        //MessageBox.Show("Registro já está aberto");
                        string message = "Registro já está aberto. Deseja continuar?";
                        string caption = "Aviso";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            if (dataGridView4.Rows.Count > 0)
                            {
                                
                                abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString())));
                                panel1.Width = 0;
                                return;
                            }

                        }
                        if (result == DialogResult.No)
                        {

                            return;
                        }

                    }
                    else
                    {
                        if (dataGridView4.Rows.Count > 0)
                        {
                            
                            abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString())));
                            panel1.Width = 0;
                            return;
                        }
                    }

                }
            }
            if (String.IsNullOrEmpty(textBox37.Text) == true)
            {
                MessageBox.Show("Selecione um Registro");

            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                textBox37.Text = "";
                textBox37.ReadOnly = false;
                textBox37.Focus();
                textBox37.BackColor = System.Drawing.Color.Cyan;
               // button14.Visible = false;
                //label134.Visible = false;

                //código para pesquisar np banco de dados
            }
            if (checkBox8.Checked == false)
            {
                textBox37.Text = "";
                textBox37.ReadOnly = true;
                textBox37.Focus();
                textBox37.BackColor = System.Drawing.Color.White;
               // button14.Visible = true;
                //label134.Visible = true;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = DALCadastro.listaProdutosTodos();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            textBox37.ReadOnly = true;
            checkBox8.Checked = false;
            textBox37.Text = dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            //textBox37.Focus();
        }
        bool edita = false;
        string copia = "";
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (Global.Margem.VenderPeso == "true")
            {
                checkBox5.Checked = true;
                Global.Margem.VenderPeso = "";
                return;
            }
            if (Global.Margem.VenderPeso == "false")
            {
                checkBox5.Checked = false;
                Global.Margem.VenderPeso = "";
                return;
            }
            if (checkBox5.Checked == true)
            {
                Form bal = new Balança();
                bal.ShowDialog();
                if (Global.Margem.Balança == "sim")
                {
                    if (String.IsNullOrEmpty(textBox9.Text) == false)
                    {
                        if (textBox9.Text.Length == 13)
                        {
                            //string ean = "2000030001808";
                            string codigo = textBox9.Text.Substring(1, 5);
                            textBox9.Text = codigo;

                            checkBox5.Enabled = false;
                            //comboBox7.Visible = true;
                            comboBox7.Text = "Preço";
                            textBox9.ReadOnly = true;
                            textBox9.Focus();

                            return;



                        }
                        if (textBox9.Text.Length != 13)
                        {
                            MessageBox.Show("O formato padrão para integrar com a balança é EAN 13");
                            textBox9.Text = "";
                            textBox9.Focus();
                            checkBox5.Checked = false;
                            return;
                        }

                    }
                    if (String.IsNullOrEmpty(textBox9.Text) == true)
                    {
                        //checkBox5.Checked = false;
                        MessageBox.Show("Favor digitar manualmente o código deste produto conforme balança comercial.");
                        textBox9.Focus();
                        comboBox7.Text = "Preço";
                        return;
                    }
                }
                else
                {
                    checkBox5.Checked = false;
                }
            }
            if (checkBox5.Checked == false)
            {
                comboBox7.Text = "não";
                checkBox5.Checked = false;
            }
        }

        private void pictureBox60_Click(object sender, EventArgs e)
        {
            if (label92.Text == "editando")
            {
                string message = "Você deseja encerrar edição do registro deste produto?";
                string caption = "Edição";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    label92.Text = copia;
                    copia = "";
                    edita = false;
                    tabControl2.SelectedTab = tabPage3;
                    MessageBox.Show("Edição cancelada");
                    textBox16.ReadOnly = true;
                    return;

                }
                if (result == DialogResult.No)
                {

                    return;
                }

            }
            if (label92.Text == "não finalizado" || label92.Text == "0")
            {
                string message = "Você deseja encerrar novo cadastro de produto?";
                string caption = "Novo Cadastro";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    label93.Text = null;
                    label92.Text = null;
                    return;

                }
                if (result == DialogResult.No)
                {

                    return;
                }

            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkBox3.Checked == true)
            {
                textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                textBox8.Text = textBox8.Text.Replace(",", "");
                textBox8.Text = textBox8.Text.Replace(".", "");
                if (textBox8.Text.Length >= 3)
                {
                    string inteiro = textBox8.Text.Substring(0, textBox8.Text.Length - 2);
                    string fração = textBox8.Text.Substring(textBox8.Text.Length - 2, 2);
                    string virgula = ",";
                    textBox8.Text = inteiro + virgula + fração;
                }
                if (textBox8.Text.Length == 2)
                {
                    textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                    textBox8.Text = textBox8.Text.Replace(",", "");
                    textBox8.Text = textBox8.Text.Replace(".", "");
                    textBox8.Text = textBox8.Text + ",00";
                }
                if (textBox8.Text.Length == 1)
                {
                    textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                    if (textBox8.Text == ",")
                    {
                        textBox8.Text = "";
                        textBox8.Focus();
                    }
                    textBox8.Text = textBox8.Text + ",00";
                }
                if (String.IsNullOrEmpty(textBox8.Text) == true)
                {
                    textBox8.Focus();
                    return;
                }
                textBox33.Text = Global.Margem.ConfiguraçãoSistemaFinanceiroMargem;
                decimal valorCusto = Convert.ToDecimal(textBox8.Text);
                string marg = "0," + textBox33.Text.Replace(",", "");
                decimal margen = Convert.ToDecimal(marg);
                decimal num = 1;
                decimal divisor = num - margen;
                
                decimal venda = valorCusto / divisor;
                textBox16.Text = Convert.ToString(Math.Round(venda, 2));
            }
            if (checkBox3.Checked == false)
            {
                textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                textBox8.Text = textBox8.Text.Replace(",", "");
                textBox8.Text = textBox8.Text.Replace(".", "");
                if (textBox8.Text.Length >= 3)
                {
                    string inteiro = textBox8.Text.Substring(0, textBox8.Text.Length - 2);
                    string fração = textBox8.Text.Substring(textBox8.Text.Length - 2, 2);
                    string virgula = ",";
                    textBox8.Text = inteiro + virgula + fração;
                }
                if (textBox8.Text.Length == 2)
                {
                    textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                    textBox8.Text = textBox8.Text.Replace(",", "");
                    textBox8.Text = textBox8.Text.Replace(".", "");
                    textBox8.Text = textBox8.Text + ",00";
                }
                if (textBox8.Text.Length == 1)
                {
                    textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                    if (textBox8.Text == ",")
                    {
                        textBox8.Text = "";
                        textBox8.Focus();
                    }
                    textBox8.Text = textBox8.Text + ",00";
                }
                if (String.IsNullOrEmpty(textBox8.Text) == true)
                {
                    textBox8.Focus();
                    return;
                }
                textBox33.Text = Global.Margem.ConfiguraçãoSistemaFinanceiroMargem;
                decimal valorCusto = Convert.ToDecimal(textBox8.Text);
                string marg = "1," + textBox33.Text.Replace(",", "");
                decimal margen = Convert.ToDecimal(marg);
                decimal venda = valorCusto * margen;
                textBox16.Text = Convert.ToString(Math.Round(venda, 2));
            }
        

    
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                textBox8.Text = textBox8.Text.Replace(",", "");
                textBox8.Text = textBox8.Text.Replace(".", "");
                if (textBox8.Text.Length >= 3)
                {
                    string inteiro = textBox8.Text.Substring(0, textBox8.Text.Length - 2);
                    string fração = textBox8.Text.Substring(textBox8.Text.Length - 2, 2);
                    string virgula = ",";
                    textBox8.Text = inteiro + virgula + fração;
                }
                if (textBox8.Text.Length == 2)
                {
                    textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                    textBox8.Text = textBox8.Text.Replace(",", "");
                    textBox8.Text = textBox8.Text.Replace(".", "");
                    textBox8.Text = textBox8.Text + ",00";
                }
                if (textBox8.Text.Length == 1)
                {
                    textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                    if (textBox8.Text == ",")
                    {
                        textBox8.Text = "";
                        textBox8.Focus();
                    }
                    textBox8.Text = textBox8.Text + ",00";
                }
                if (String.IsNullOrEmpty(textBox8.Text) == true)
                {
                    textBox8.Focus();
                    return;
                }
                textBox33.Text = Global.Margem.ConfiguraçãoSistemaFinanceiroMargem;
                decimal valorCusto = Convert.ToDecimal(textBox8.Text);
                string marg = "0," + textBox33.Text.Replace(",", "");
                decimal margen = Convert.ToDecimal(marg);
                decimal num = 1;
                decimal divisor = num - margen;

                decimal venda = valorCusto / divisor;
                textBox16.Text = Convert.ToString(Math.Round(venda, 2));
            }
            if (checkBox3.Checked == false)
            {
                textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                textBox8.Text = textBox8.Text.Replace(",", "");
                textBox8.Text = textBox8.Text.Replace(".", "");
                if (textBox8.Text.Length >= 3)
                {
                    string inteiro = textBox8.Text.Substring(0, textBox8.Text.Length - 2);
                    string fração = textBox8.Text.Substring(textBox8.Text.Length - 2, 2);
                    string virgula = ",";
                    textBox8.Text = inteiro + virgula + fração;
                }
                if (textBox8.Text.Length == 2)
                {
                    textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                    textBox8.Text = textBox8.Text.Replace(",", "");
                    textBox8.Text = textBox8.Text.Replace(".", "");
                    textBox8.Text = textBox8.Text + ",00";
                }
                if (textBox8.Text.Length == 1)
                {
                    textBox8.Text = Ferramentas.Retira_Meta_PreparaDecimal(textBox8.Text);
                    if (textBox8.Text == ",")
                    {
                        textBox8.Text = "";
                        textBox8.Focus();
                    }
                    textBox8.Text = textBox8.Text + ",00";
                }
                if (String.IsNullOrEmpty(textBox8.Text) == true)
                {
                    textBox8.Focus();
                    return;
                }
                textBox33.Text = Global.Margem.ConfiguraçãoSistemaFinanceiroMargem;
                decimal valorCusto = Convert.ToDecimal(textBox8.Text);
                string marg = "1," + textBox33.Text.Replace(",", "");
                decimal margen = Convert.ToDecimal(marg);
                decimal venda = valorCusto * margen;
                textBox16.Text = Convert.ToString(Math.Round(venda, 2));
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroProdutos != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
        }

        private void pictureBox62_Click(object sender, EventArgs e)
        {
            textBox17.Text = "1";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                int mult = Convert.ToInt32(textBox17.Text);
                mult = mult - 1;
                if (mult >= 1)
                {
                    textBox17.Text = Convert.ToString(mult);
                }
                else
                {
                    textBox17.Text = "1";
                    MessageBox.Show("Não aceita valor negativo");
                }

            }
            if (checkBox10.Checked == true)
            {
                int mult = Convert.ToInt32(textBox17.Text);
                mult = mult - 10;
                if (mult >= 1)
                {
                    textBox17.Text = Convert.ToString(mult);
                }
                else
                {
                    textBox17.Text = "1";
                    MessageBox.Show("Não aceita valor negativo");
                }
            }
            if (checkBox11.Checked == true)
            {
                int mult = Convert.ToInt32(textBox17.Text);
                mult = mult - 100;
                if (mult >= 1)
                {
                    textBox17.Text = Convert.ToString(mult);
                }
                else
                {
                    textBox17.Text = "1";
                    MessageBox.Show("Não aceita valor negativo");
                }
            }
            if (checkBox12.Checked == true)
            {
                int mult = Convert.ToInt32(textBox17.Text);
                mult = mult - 1000;
                if (mult >= 1)
                {
                    textBox17.Text = Convert.ToString(mult);
                }
                else
                {
                    textBox17.Text = "1";
                    MessageBox.Show("Não aceita valor negativo");
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                int mult = Convert.ToInt32(textBox17.Text);
                mult = mult + 1;
                textBox17.Text = Convert.ToString(mult);
            }
            if (checkBox10.Checked == true)
            {
                int mult = Convert.ToInt32(textBox17.Text);
                mult = mult + 10;
                textBox17.Text = Convert.ToString(mult);
            }
            if (checkBox11.Checked == true)
            {
                int mult = Convert.ToInt32(textBox17.Text);
                mult = mult + 100;
                textBox17.Text = Convert.ToString(mult);
            }
            if (checkBox12.Checked == true)
            {
                int mult = Convert.ToInt32(textBox17.Text);
                mult = mult + 1000;
                textBox17.Text = Convert.ToString(mult);
            }
        }

        private void pictureBox63_Click(object sender, EventArgs e)
        {
            Form calendario = new Calendario();
            calendario.ShowDialog();

            textBox26.Text = Global.Margem.Calendario;
            Global.Margem.Calendario = "";
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                checkBox9.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            Int64 qtde;
            if (Int64.TryParse(label92.Text.Trim(), out qtde) == true)
            {

                if (String.IsNullOrEmpty(label93.Text) == false && Convert.ToInt32(label92.Text) > 0)
                {
                    Global.Margem.IdProdSAT = label93.Text;
                    Global.Margem.xProd = textBox10.Text;
                    DataTable sat = DALCadastro.VerificaSAT(Convert.ToInt32(Global.Margem.IdProdSAT));
                    if (sat.Rows.Count > 0)
                    {
                        this.WindowState = FormWindowState.Minimized;
                        Form emu = new EmuladorSAT();
                        emu.ShowDialog();
                        this.WindowState = FormWindowState.Maximized;
                    }
                    if (sat.Rows.Count <= 0)
                    {
                        MessageBox.Show("Produto não possui informações necessárias no cadastro");
                    }

                }
                else
                {
                    MessageBox.Show("Cadastro básico deste ítem incompleto");
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Int64 qtde;
            if (Int64.TryParse(label92.Text.Trim(), out qtde) == true)
            {

                if (String.IsNullOrEmpty(label93.Text) == false && Convert.ToInt32(label92.Text) > 0)
                {
                    Global.Margem.IdProdSAT = label93.Text;

                    DataTable satV = DALCadastro.VerificaSAT(Convert.ToInt32(Global.Margem.IdProdSAT));
                    if (satV.Rows.Count <= 0)
                    {
                        Form esat = new SAT();
                        esat.ShowDialog();
                    }
                    if (satV.Rows.Count > 0)
                    {
                        string message = "Este Item já possui um Cadastro SAT - CFe.\nDeseja editar as Informações?";
                        string caption = "Cadastro SAT - CFe existente";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            Form esat = new SAT();
                            esat.ShowDialog();
                            Global.Margem.EditaSAT = "sim";
                        }

                    }


                }
                else
                {
                    MessageBox.Show("Cadastro básico deste ítem incompleto");
                }
            }
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            Form cf = new CFOP_Entrada();
            cf.ShowDialog();
            if (String.IsNullOrEmpty(Global.Margem.CFOP_Entr) == false)
            {
                textBox38.Text = Global.Margem.CFOP_Entr;
            }
            Global.Margem.CFOP_Entr = "";
        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Alteração deste parâmetro não permitido");
            return;
        }

        private void textBox36_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (String.IsNullOrEmpty(textBox36.Text) == false)
                {

                    DataTable teste = DALCadastro.produtoVenda(textBox36.Text);
                    if (teste.Rows.Count > 0)
                    {

                        textBox36.Text = "";

                        panel1.Width = 0;

                        abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(teste.Rows[0]["IdProd"].ToString())));
                        return;
                    }
                    if (teste.Rows.Count <= 0 && textBox36.Text.Length > 5)
                    {
                        string codigo = textBox36.Text.Substring(1, 5);

                        DataTable produto = DALCadastro.produtoVenda(codigo);
                        if (produto.Rows.Count > 0)
                        {
                            abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(produto.Rows[0]["IdProd"].ToString())));
                            textBox36.Text = "";
                            groupBox11.Visible = false;

                            panel1.Width = 0;

                        }
                        else
                        {
                            MessageBox.Show("Produto não cadastrado");
                            textBox36.Text = "";
                            textBox36.Focus();
                        }

                    }


                }
            }
        }

        private void pictureBox64_Click(object sender, EventArgs e)
        {
            textBox8.Text = "0,00";
            textBox33.Text = "0,00";
            textBox16.ReadOnly = false;
            textBox16.Text = "";
            textBox16.Focus();
        }

        private void pictureBox78_Click(object sender, EventArgs e)
        {
            DALCadastro.BaixaFracionado("0000.0000", Convert.ToInt32(label93.Text));
            textBox39.Text = "0.0";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            dataGridView4.DataSource = DALCadastro.ProcurarProdutoSemCodeBarDescInt("%" + textBox37.Text + "%");
            textBox37.Text = "";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (label93.Text == "não finalizado" || label93.Text == "0")
            {
                return;
            }
            if (comboBox7.Text == "Peso" || comboBox7.Text == "Preço")
            {
                Form frac = new FracionadoAlternativo(textBox9.Text);
                frac.ShowDialog();
            }
            else
            {
                MessageBox.Show("Opção disponível apenas para produtos vendidos por peso");
            }
        }

        private void pictureBox11_Click_1(object sender, EventArgs e)
        {
            Form frac = new Fracionados();
            frac.ShowDialog();
            if (String.IsNullOrEmpty(Global.Margem.AbrirFracionado) == false)
            {
                tabControl2.SelectedTab = tabPage3;
                abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(Global.Margem.AbrirFracionado)));
            }
            Global.Margem.AbrirFracionado = "";
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            label106.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            label106.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            label64.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            label64.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            label105.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            label105.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox60_MouseEnter(object sender, EventArgs e)
        {
            label107.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox60_MouseLeave(object sender, EventArgs e)
        {
            label107.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
            label94.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            label94.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = System.Drawing.Color.Black;
        }

        private void textBox36_Enter(object sender, EventArgs e)
        {
            textBox36.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox36_Leave(object sender, EventArgs e)
        {
            textBox36.BackColor = System.Drawing.Color.White;
        }

        private void textBox37_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (String.IsNullOrEmpty(textBox37.Text) == false && textBox37.ReadOnly == false)
                {
                    dataGridView4.DataSource = DALCadastro.ProcurarProdutoSemCodeBarDescInt("%" + textBox37.Text + "%");
                    dataGridView4.Focus();
                    textBox37.Text = "";
                }
                if (String.IsNullOrEmpty(textBox37.Text) == false && textBox37.ReadOnly == true)
                {
                    if (String.IsNullOrEmpty(textBox37.Text) == false)
                    {

                        if (String.IsNullOrEmpty(label93.Text) == true)
                        {
                            if (dataGridView4.Rows.Count > 0)
                            {
                                abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString())));
                                panel1.Width = 0;
                                return;    
                            }                           

                        }
                        if (String.IsNullOrEmpty(label93.Text) == false)
                        {
                            int ident = Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString());

                            if (ident == Convert.ToInt32(label93.Text))
                            {
                                //MessageBox.Show("Registro já está aberto");
                                string message = "Registro já está aberto. Deseja continuar?";
                                string caption = "Aviso";
                                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                                DialogResult result;

                                // Displays the MessageBox.

                                result = MessageBox.Show(this, message, caption, buttons,
                                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                                if (result == DialogResult.Yes)
                                {
                                    if (dataGridView4.Rows.Count > 0)
                                    {
                                        abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString())));
                                        panel1.Width = 0;
                                        return;
                                    }    

                                }
                                if (result == DialogResult.No)
                                {

                                    return;
                                }

                            }
                            else
                            {
                                if (dataGridView4.Rows.Count > 0)
                                {
                                    abrirRegistro(DALCadastro.listaProdutos(Convert.ToInt32(dataGridView4.Rows[dataGridView4.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString())));
                                    panel1.Width = 0;
                                    
                                }    
                            }

                        }
                    }
                    if (String.IsNullOrEmpty(textBox37.Text) == true)
                    {
                        MessageBox.Show("Selecione um Registro");

                    }
                }
            }
        }

        private void textBox37_Click(object sender, EventArgs e)
        {
            textBox37.ReadOnly = false;
            checkBox8.Checked = true;
        }

        private void pictureBox80_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label93.Text) == false)
            {
                Int32 testa = 0;
                if (Int32.TryParse(label92.Text, out testa) == true)
                {
                    Form eanin = new EANInterno(textBox10.Text, label93.Text);
                    eanin.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Necessário abrir um registro de produto para gerar EAN Interno");
                }
            }
        }

        private void pictureBox80_MouseEnter(object sender, EventArgs e)
        {
            label61.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox80_MouseLeave(object sender, EventArgs e)
        {
            label61.ForeColor = System.Drawing.Color.Black;
        }
    }
}
