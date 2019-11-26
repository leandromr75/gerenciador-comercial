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
    public partial class PDV : Form
    {
        public PDV()
        {
            InitializeComponent();
            

        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Form formPrincipal = new TelaPrincipal();

            GerenciadorDeFormulario.Abre(formPrincipal);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Global.Margem.RetiradaCaixa = comboBox1.Text;
            if (dataGridView1.Rows.Count <= 0 && Global.Margem.Contador == "verde")
            {
                string message = "Você deseja Fechar o Caixa?";
                string caption = "Fechamento";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Mostra a MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    pictureBox17.Visible = true;
                    Global.Margem.CaixaAberto = comboBox1.Text;
                    Form fecha = new FecharCaixa();
                    fecha.ShowDialog();
                    pictureBox17.Visible = false;
                    if (Global.Margem.Cancelar != "OK")
                    {
                        using (StreamWriter writer = new StreamWriter("CaixaAberto.txt"))
                        {
                            writer.Write("não");

                        }
                        textBox1.Focus();
                        Form formPrincipal = new TelaPrincipal();

                        GerenciadorDeFormulario.Abre(formPrincipal);
                        GerenciadorDeFormulario.Fecha(this);
                    }
                    if (Global.Margem.Cancelar == "OK")
                    {
                        Global.Margem.Cancelar = "";
                    }
                    
                }
                if (result == DialogResult.No)
                {
                    using (StreamWriter writer = new StreamWriter("CaixaAberto.txt"))
                    {
                        writer.Write("sim");

                    }
                    textBox1.Focus();
                    Form formPrincipal = new TelaPrincipal();

                    GerenciadorDeFormulario.Abre(formPrincipal);
                    GerenciadorDeFormulario.Fecha(this);
                }
                
            }
            else
            {
                MessageBox.Show("Precisa Finalizar ou Cancelar a venda \nantes de sair do sistema!!");
            }
            
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            groupBox4.Text = Global.Margem.EmpresaCaixa;
            label13.Text = System.DateTime.Now.ToLongDateString();
            label14.Text = System.DateTime.Now.ToLongTimeString();
            
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Global.Margem.Impressora == "mp4200th")
            {
                int iRetorno = MP2032.Le_Status();

                
                
                if (iRetorno == 0)
                {
                    MessageBox.Show("Erro de comunicação com impressora");
                    //Application.Exit();
                }

                if (iRetorno == 5)
                {
                    MessageBox.Show("Impressora com pouco papel");
                    //Application.Exit();
                }

                if (iRetorno == 9)
                {
                    MessageBox.Show("Tampa da impressora aberta");
                    //Application.Exit();
                }

                if (iRetorno == 32)
                {
                    MessageBox.Show("Impressora sem papel");
                    //Application.Exit();
                } 
                /*string message = "Você deseja continuar?";
                string caption = "Aviso Impressora";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.No)
                {
                    return;
                }*/
            }
            if (dataGridView1.Rows.Count > 0)
            {
                Global.Margem.Troco = "não";
                Global.Margem.TrocoVenda = textBox3.Text;
                Global.Margem.Numvenda = label8.Text;
                pictureBox17.Visible = true;
                Form troco = new Troco();
                troco.ShowDialog();
                Global.Margem.Numvenda = "";
            }
            else
            {
                MessageBox.Show("Não existe venda para ser finalizada");
                pictureBox17.Visible = false;
                textBox1.Focus();
            }
            if (Global.Margem.Troco == "não")
            {
                pictureBox17.Visible = false;
                textBox1.Focus();
                return;
            }
            if (Global.Margem.Troco == "sim")
            {
                pictureBox17.Visible = true;
                Ferramentas.Dedo_Duro();
                if (Global.Margem.ExpirouLicença == "sim")
                {
                    Application.Exit();
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    Global.Margem.Numvenda = label8.Text;
                    Global.Margem.Totalvenda = textBox3.Text;
                    Form tipoPag = new tipoPagamento();
                    tipoPag.ShowDialog();
                    if (Global.Margem.Cancelar == "OK")
                    {
                        pictureBox17.Visible = false;
                        Global.Margem.Cancelar = "";
                        return;
                    }
                    Form print = new ImprimeCupom();
                    print.ShowDialog();
                    dataGridView1.DataSource = DALCadastro.listaVendas();
                    textBox1.Text = "";
                    textBox1.Focus();

                    textBox3.Text = "";
                    dataGridView1.Visible = false;
                    pictureBox2.Visible = true;
                    label13.Visible = true;

                    label17.Text = "";
                    label8.Text = "";
                    label18.Text = "";
                    textBox2.Text = "";
                    pictureBox1.Image = null;
                    pictureBox1.InitialImage = null;
                    Global.Margem.Contador = "verde";


                    Global.Margem.Totalvenda = "";
                    panel1.Visible = false;
                    label20.Text = "";
                    pictureBox17.Visible = false;
                    
                    if (Global.Margem.Impressora == "mp4200th")
                    {
                        string message = "Deseja abrir a gaveta?";
                        string caption = "Gaveta Dinheiro";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            const int charCode = 27;
                            const int charCode2 = 118;
                            const int charCode3 = 140;
                            var specialChar = Convert.ToChar(charCode);
                            var specialChar2 = Convert.ToChar(charCode2);
                            var specialChar3 = Convert.ToChar(charCode3);
                            string cmdText = "" + specialChar + specialChar2 + specialChar3;
                            int iRetorno = MP2032.ComandoTX(cmdText, cmdText.Length);
                        }
                        
                    }



                }
                else
                {
                    MessageBox.Show("Não existe venda para ser finalizada");
                    pictureBox17.Visible = false;
                    textBox1.Focus();

                }



                textBox1.Focus();
            }
            if (Global.Margem.Troco == "misto")
            {
                pictureBox17.Visible = true;
                Ferramentas.Dedo_Duro();
                if (Global.Margem.ExpirouLicença == "sim")
                {
                    Application.Exit();
                }
                Form print = new ImprimeCupom();
                print.ShowDialog();
                dataGridView1.DataSource = DALCadastro.listaVendas();
                textBox1.Text = "";
                textBox1.Focus();

                textBox3.Text = "";
                dataGridView1.Visible = false;
                pictureBox2.Visible = true;
                label13.Visible = true;

                label17.Text = "";
                label8.Text = "";
                label18.Text = "";
                textBox2.Text = "";
                pictureBox1.Image = null;
                pictureBox1.InitialImage = null;
                Global.Margem.Contador = "verde";


                Global.Margem.Totalvenda = "";
                panel1.Visible = false;
                label20.Text = "";
                pictureBox17.Visible = false;

                if (Global.Margem.Impressora == "mp4200th")
                {
                    string message = "Deseja abrir a gaveta?";
                    string caption = "Gaveta Dinheiro";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        const int charCode = 27;
                        const int charCode2 = 118;
                        const int charCode3 = 140;
                        var specialChar = Convert.ToChar(charCode);
                        var specialChar2 = Convert.ToChar(charCode2);
                        var specialChar3 = Convert.ToChar(charCode3);
                        string cmdText = "" + specialChar + specialChar2 + specialChar3;
                        int iRetorno = MP2032.ComandoTX(cmdText, cmdText.Length);
                    }

                }
                textBox1.Focus(); 
                   
            }
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CaixaTerminalVendas != "adm")
            {
                MessageBox.Show("Não autorizado");
                return;
            }
            string numVenda = label8.Text;
            string prodvend = "";
            int qtdeinicial = 0;
            string efrc = "não";
            if (String.IsNullOrEmpty(label18.Text) == false)
            {
                Int64 qtde;
                if (Int64.TryParse(textBox2.Text.Trim(), out qtde) == true)
                {
                    qtdeinicial = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
                    string idP = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(label18.Text)));
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[5].Value.ToString() == label18.Text)
                        {
                            prodvend += dataGridView1.Rows[i].Cells[0].Value.ToString() + " ==> Quantidade : "
                                + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        }
                    }
                    DALCadastro.baixaEstoqueRetorna(idP, Convert.ToString(qtdeinicial));
                    DALCadastro.deletaProduto(label18.Text);
                }
                else
                {
                    efrc = "sim";
                }
                
                if( efrc == "sim")                
                {
                    
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[5].Value.ToString() == label18.Text)
                        {
                            prodvend += dataGridView1.Rows[i].Cells[0].Value.ToString() + " ==> Quantidade : "
                                + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                        }
                        
                    }
                    string recebe = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].Value.ToString().Replace("gr", "");
                    string idP2 = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(label18.Text)));
                    //MessageBox.Show(idP2);
                    Int32 teste = Convert.ToInt32(idP2);
                    //MessageBox.Show(Convert.ToString(teste));
                    decimal somafrac = Convert.ToDecimal(recebe);
                    DataTable peso = DALCadastro.BaixaFracionadoRetorna(Convert.ToInt32(idP2));
                    decimal calc = Convert.ToDecimal(peso.Rows[0]["EstoquePeso"].ToString());
                    decimal re = calc + somafrac;
                    string rec = Convert.ToString(re);
                    decimal t30;
                    if (Decimal.TryParse(rec.Replace(".", ","), out t30))
                    {
                        DALCadastro.BaixaFracionado(Convert.ToString(t30).Replace(",", "."), Convert.ToInt32(idP2));
                        DALCadastro.deletaProduto(label18.Text);
                    }
                }  
                   
               
                

                
                dataGridView1.DataSource = DALCadastro.listaVendas();
                
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("CaixaTerminalVendas", "Excluiu ítem da Venda Número: " + label8.Text + " : " + prodvend );
                }
                textBox1.Text = "";
                textBox1.Focus();
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                int Qtde = 0;
                decimal sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Coral;
                    if (x == 1440 && y == 900)
                    {
                        dataGridView1.Columns[0].Width = 500;
                    }
                    if (x == 1366 && y == 768)
                    {
                        dataGridView1.Columns[0].Width = 450;
                    }
                    if (x == 1024 && y == 768)
                    {
                        dataGridView1.Columns[0].Width = 200;
                    }

                    dataGridView1.Columns[5].Width = 100;
                    dataGridView1.Columns[2].Width = 120;
                    dataGridView1.Columns[1].Width = 120;
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                    Int64 qtde2;
                    if (Int64.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(), out qtde2) == false)
                    {
                        Qtde += 1;

                    }
                    else
                    {
                        Qtde += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    }
                }

                
                textBox3.Text = Convert.ToString(sum);
                label17.Text = Convert.ToString(Qtde) + "   ítem(s).";
                textBox2.Text = "";
                label18.Text = "";
                if (Global.Margem.ConfiguraçãoSistemaEstoque == "sim")
                {
                    MessageBox.Show("Produto retirado da venda com sucesso\nDescrição e Quantidade do Produto retornado ao estoque:\n\n" 
                    + prodvend);
                }
                if (Global.Margem.ConfiguraçãoSistemaEstoque == "não")
                {
                    MessageBox.Show("Produto retirado da venda com sucesso");
                }
                pictureBox1.Image = null;
                pictureBox1.InitialImage = null;
                textBox1.Focus();
                dataGridView1.DataSource = DALCadastro.listaVendas();
                if (dataGridView1.Rows.Count <= 0)
                {
                    string message = "Você deseja cancelar esta venda?";
                    string caption = "Cancelar";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        pictureBox10.Visible = false;
                        textBox3.Text = "";
                        dataGridView1.Visible = false;
                        pictureBox2.Visible = true;
                        label13.Visible = true;
                        
                        label17.Text = "";
                        label8.Text = "";
                        label18.Text = "";
                        textBox2.Text = "";
                        pictureBox1.Image = null;
                        pictureBox1.InitialImage = null;
                        Global.Margem.Contador = "verde";

                        panel1.Visible = false;
                        label20.Text = "";
                        MessageBox.Show("Venda número: ==> " + numVenda + " ------cancelada--------");
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Cancelada Venda Número : " + numVenda);
                        }
                        textBox1.Focus();
                    }
                    if (result == DialogResult.No)
                    {
                        textBox1.Focus();
                    }
                }
                
            }
            else
            {
                textBox1.Focus();
            }

            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Int64 EAN = 0;
                
                if (Int64.TryParse(textBox1.Text.Trim(), out EAN) == true)
                {
                    if (textBox1.Text.Length > 7)
                    {
                        carregaProduto(DALCadastro.produtoVenda(textBox1.Text));
                        textBox2.Text = "";
                        label18.Text = ""; 
                    }
                    else
                    {
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                       
                    
                }
                else
                {
                    textBox1.Text = "";
                    textBox1.Focus();
                }             

            }

        }
        public void carregaImagem(string identificador)
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Imagens;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                //define a instrução SQL para somar Quantidade e agrupar resultados
                string id = identificador;

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
                
                
                
                pictureBox1.Image = imagem;     
                
               







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
        
        public void carregaProduto(DataTable produto)
        {
            string vai = "";
            Global.Margem.PreçoKiloAlternetivo = "não";
            string preço_peso = "";
            string pLiquido = "";
            string estoquePESO = "";
            Global.Margem.Frios = "";
            Global.Margem.Fracionado = "";
            string valorVenda = "";
            string codigo = "";
            if (Global.Margem.Contador == "verde")
            {
                //string x = "X";
                //label8.Text = Convert.ToString(DALCadastro.ValidaLicença(x));
                label8.Text = Convert.ToString(DALCadastro.contadorInc()); 
                        
               
                Global.Margem.Contador = "vermelho";
                
                
            }
            if (Global.Margem.PreçoManual == "sim")
            {
                Global.Margem.Frios = "sim";
                Global.Margem.Fracionado = produto.Rows[0]["ValorVenda"].ToString();
                preço_peso = Global.Margem.Fracionado;
                pLiquido = produto.Rows[0]["PesoLiquido"].ToString();
                estoquePESO = produto.Rows[0]["EstoquePeso"].ToString();
                string message = "Deseja informar manualmente o Peso/Preço deste Produto?\n\n" + produto.Rows[0]["DescInterna"].ToString() + "\n\n" +
                    "Caso contrário, o preço definido automaticamente será :\n\n "  + preço_peso + " Por KG";
                string caption = "Peso p/ KG";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    Form preço = new PesoPreço();
                    preço.ShowDialog();
                    if (String.IsNullOrEmpty(Global.Margem.PreçoPesoManual) == false)
                    {
                        Global.Margem.Fracionado = Global.Margem.PreçoPesoManual;
                        preço_peso = Global.Margem.PreçoPesoManual;
                        Global.Margem.PreçoPesoManual = "";
                        vai = "sim";
                    }
                   
                }    
                
            }
            if (produto.Rows.Count < 1)
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    codigo = textBox1.Text.Substring(1, 5);
                    preço_peso = textBox1.Text.Substring(7,5);
                    string inteiro = preço_peso.Substring(0,3);
                    string casas = preço_peso.Substring(3,2);
                    preço_peso = inteiro + "," + casas;
                    produto = DALCadastro.produtoVenda(codigo);
                    if (produto.Rows.Count > 0)
                    {
                        Global.Margem.Frios = "sim";
                        Global.Margem.Fracionado = preço_peso;
                        pLiquido = produto.Rows[0]["PesoLiquido"].ToString();
                        estoquePESO = produto.Rows[0]["EstoquePeso"].ToString();
                        
                    }
                    //procurar fracionado com preço por kilo alternativo
                    if (produto.Rows.Count <= 0)
                    {
                        //procurar alternativos
                        DataTable alternativo = DALCadastro.ListaFracionadoAlternativo();
                        if (alternativo.Rows.Count > 0)
                        {
                            for (int i = 0; i < alternativo.Rows.Count; i++)
                            {
                                if (codigo == alternativo.Rows[i]["Cod_Alternativo"].ToString())
                                {
                                    produto = DALCadastro.produtoVenda(alternativo.Rows[i]["Cod_Principal"].ToString());
                                    if (produto.Rows.Count > 0)
                                    {
                                        estoquePESO = produto.Rows[0]["EstoquePeso"].ToString();

                                        Global.Margem.Frios = "sim";
                                        Global.Margem.Fracionado = preço_peso;
                                        Global.Margem.PreçoKiloAlternetivo = "sim";
                                    }
                                }
                            }
                        }
                       
                        
                    }
                }
            }
            if (produto.Rows.Count > 0)
            {
                
                
                
                string Identificador = produto.Rows[0]["IdProd"].ToString();
                string descrição = produto.Rows[0]["DescInterna"].ToString();
                string unidade = produto.Rows[0]["Unidade"].ToString();
                
                if (Global.Margem.PreçoKiloAlternetivo == "sim")
                {
                    DataTable alternativo = DALCadastro.ListaFracionadoAlternativo();
                    if (alternativo.Rows.Count > 0)
                    {
                        for (int i = 0; i < alternativo.Rows.Count; i++)
                        {
                                if (codigo == alternativo.Rows[i]["Cod_Alternativo"].ToString())
                                {
                                    valorVenda = alternativo.Rows[i]["Preço"].ToString();
                                    descrição = alternativo.Rows[i]["Descrição"].ToString();
                  
                                }
                        }
                                         
   
                    }
                                    
                }
                if (Global.Margem.PreçoKiloAlternetivo == "não")
                {
                    if (vai != "sim")
                    {
                        valorVenda = produto.Rows[0]["ValorVenda"].ToString();     
                    }
                    if (vai == "sim")
                    {
                        valorVenda = preço_peso;
                    }
                    vai = "";

                }
                
                //verficar se valor de venda está zerado
                if (Convert.ToDecimal(valorVenda) <= 0)
                {
                    string message = "Valor de venda não informado para o produto :\n\n" + descrição + 
                        "\n\nGostaria de cadastrar o valor de venda agora?";
                    string caption = "Valor de Venda";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;
                    result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        Form val = new Valor(produto.Rows[0]["DescInterna"].ToString());
                        val.ShowDialog();
                        string temp5 = "";
                        decimal t29;
                        if (Decimal.TryParse(Global.Margem.DescontoValor, out t29))
                        {
                            Global.Margem.DescontoValor = Convert.ToString(t29);
                            temp5 = Global.Margem.DescontoValor;
                            Global.Margem.DescontoValor = Global.Margem.DescontoValor.Replace(",", ".");
                            
                        }
                        if (String.IsNullOrEmpty(Global.Margem.DescontoValor) == true || Convert.ToDecimal(Global.Margem.DescontoValor) <= 0 )
                        {
                            MessageBox.Show("Valor de venda não informado.");
                            dataGridView1.Visible = true;
                            pictureBox2.Visible = false;
                            label13.Visible = false;
                            pictureBox10.Visible = true;
                            if (dataGridView1.Rows.Count <= 0)
                            {
                                pictureBox2.Visible = true;
                                pictureBox10.Visible = false;
                                label13.Visible = true;
                            }
                            Global.Margem.Contador = "verde";
                            return;  
                        }
                        else
                        {
                            DALCadastro.InserePreço(Global.Margem.DescontoValor, Convert.ToInt32(produto.Rows[0]["IdProd"].ToString()));
                            valorVenda = temp5;
                            
                        }
                        Global.Margem.DescontoValor = "";
                    }
                    if (result == DialogResult.No)
                    {
                        dataGridView1.Visible = true;
                        pictureBox2.Visible = false;
                        label13.Visible = false;
                        pictureBox10.Visible = true;
                        if (dataGridView1.Rows.Count <= 0)
                        {
                            pictureBox2.Visible = true;
                            pictureBox10.Visible = false;
                            label13.Visible = true;
                        }
                        Global.Margem.Contador = "verde";
                        return;    
                    }

                    
                }

                string estoqueInt = produto.Rows[0]["EstoqueINT"].ToString();
                
                string venderPor = produto.Rows[0]["VenderPro"].ToString();
                
                string quantidade = "1";
                string situação = "não finalizada";
                string pagamento = "não definido";
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
                string cliente = "Consumidor";
                string tempVenda = valorVenda;
                if (venderPor == "Preço")
                {
                    string valorVendaKG = "";
                    decimal porkilo = Convert.ToDecimal(valorVenda);
                    //decimal porkilo = Convert.ToDecimal(valorVenda) / Convert.ToDecimal(pLiquido);
                    valorVendaKG = Convert.ToString(Math.Round(porkilo, 2)) + " /kg";
                    valorVenda = Global.Margem.Fracionado;
                    //MessageBox.Show(preço_peso + " | " + tempVenda);
                   
                    
                    decimal resultado = Convert.ToDecimal(preço_peso) * 1000;
                    
                    
                    //MessageBox.Show(Convert.ToString(resultado));
                    decimal resultado2 = Convert.ToDecimal(resultado) / porkilo;
                    //string mostra = Convert.ToString(Math.Round(resultado2, 2));
                    //MessageBox.Show(estoquePESO +  "  " + resultado2 );
                    decimal resultado3 = Convert.ToDecimal(Math.Round(resultado2, 3));


                    decimal estatual = Convert.ToDecimal(estoquePESO) - resultado3;

                    string mostra4 = Convert.ToString(Math.Round(estatual, 2));

                    decimal kg = estatual / 1000;

                    string mostra5 = Convert.ToString(Math.Round(kg, 2));
                    if (kg > 0)
                    {
                        label20.Text = "Estoque restante : [ " + mostra4 + " gramas  ==>  " + mostra5 + " Kg ]";
                            
                    }
                    else
                    {
                        label20.Text = "Estoque restante : Estoque zerado [ " + mostra4 + " gramas  ==>  " + mostra5 + " Kg ]";
                    }
                    quantidade = Convert.ToString(resultado3) + " gr";
                    decimal t30;
                    if (Decimal.TryParse(mostra4.Replace(".", ","), out t30))
                    {
                         DALCadastro.BaixaFracionado(Convert.ToString(t30).Replace(",","."), Convert.ToInt32(produto.Rows[0]["IdProd"].ToString())); 
                    }
                    decimal venda = Convert.ToDecimal(valorVenda);
                    valorVenda = Convert.ToString(venda);
                    valorVenda = valorVenda.Replace(".",",");
                    decimal resultado4 = Convert.ToDecimal(Math.Round(resultado3, 0));
                    quantidade = Convert.ToString(resultado4) + " gr";
                    DALCadastro.criarVenda(descrição, quantidade, unidade,  valorVendaKG, valorVenda, situação, pagamento,
                    label8.Text, label3.Text, comboBox1.Text, Global.Margem.ContaAberta, "não", data, datacalc, Identificador, cliente, Convert.ToInt32(Identificador));

                    Global.Margem.PreçoManual = "";                         
                }
                if (venderPor != "Preço")
                {
                    DALCadastro.criarVenda(descrição, quantidade, unidade, valorVenda, valorVenda, situação, pagamento,
                    label8.Text, label3.Text, comboBox1.Text, Global.Margem.ContaAberta, "não", data, datacalc, Identificador, cliente, Convert.ToInt32(Identificador));
                    Global.Margem.PreçoManual = "";
                }
                
                
                //criar codigo para baixar estoque<=====
                dataGridView1.Visible = true;
                pictureBox2.Visible = false;
                label13.Visible = false;
                pictureBox10.Visible = true;
                if (checkBox1.Checked == true)
                {
                    carregaImagem(Identificador);
                }
                //fazer baixa dos estoque
                panel1.Visible = true;
                
                if (Global.Margem.ConfiguraçãoSistemaEstoque == "sim")
                {
                   
                    if (Global.Margem.Frios != "sim")
                    {
                        int est = Convert.ToInt32(estoqueInt) - 1;
                        if (est <= 0)
                        {
                            label20.Text = "Estoque zerado!";
                            DALCadastro.baixaEstoque(Identificador, Convert.ToString(1));


                            //criar lembrete de estoque
                            //||||||||||||||||||
                        }
                        else
                        {
                            label20.Text = Convert.ToString(est) + "  " + unidade;
                            DALCadastro.baixaEstoque(Identificador, Convert.ToString(1));


                        }
                    }
                    
                }
                if (Global.Margem.ConfiguraçãoSistemaEstoque == "não")
                {
                    label20.Text = "0";

                }
                
                dataGridView1.DataSource = DALCadastro.listaVendas();
                textBox1.Text = "";
                textBox1.Focus();
                
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                
                int Qtde = 0;
                decimal sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    
                    
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Coral;
                    if (x == 1440 && y == 900)
                    {
                        dataGridView1.Columns[0].Width = 500;
                    }
                    if (x == 1366 && y == 768)
                    {
                        dataGridView1.Columns[0].Width = 450;
                    }
                    if (x == 1024 && y == 768)
                    {
                        dataGridView1.Columns[0].Width = 200;
                    }
                    if (x == 1280 && y == 1024)
                    {
                        dataGridView1.Columns[0].Width = 400;   
                    }
                    if (x > 1440)
                    {
                        dataGridView1.Columns[0].Width = 500;
                    }
                                            
                    dataGridView1.Columns[5].Width = 100;
                    dataGridView1.Columns[2].Width = 120;
                    dataGridView1.Columns[1].Width = 120;
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                    Int64 qtde;
                    if (Int64.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(), out qtde) == false)
                    {
                        Qtde += 1;

                    }
                    else
                    {
                        Qtde += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value); 
                    }
                }

                
                textBox3.Text = Convert.ToString(sum);
                label17.Text = Convert.ToString(Qtde) + "   ítem(s).";
                Global.Margem.PreçoManual = "";
                
            }
            if (produto.Rows.Count <= 0)
            {
                //Procura por EAN Trib
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    produto = DALCadastro.ProcurarProdutoEANTrib(textBox1.Text);
                    if (produto.Rows.Count <= 0)
                    {
                        if (dataGridView1.Rows.Count <= 0)
                        {
                            dataGridView1.Visible = false;
                            pictureBox10.Visible = false;
                            textBox3.Text = "";
                            pictureBox2.Visible = true;
                            label13.Visible = true;
                            label17.Text = "";
                            textBox1.Text = "";
                            textBox1.Focus();
                            Global.Margem.Contador = "verde";
                            MessageBox.Show("Não existe produto cadastrado com este código de barras");
                            return;
                        }
                        if (dataGridView1.Rows.Count > 0)
                        {
                            textBox1.Text = "";
                            textBox1.Focus();
                            MessageBox.Show("Não existe produto cadastrado com este código de barras");
                            return;
                        }
                    }
                    if (produto.Rows.Count > 0)
                    {
                        if (produto.Rows[0]["VenderPro"].ToString() == "Preço" || produto.Rows[0]["VenderPro"].ToString() == "Peso")
                        {
                            Global.Margem.PreçoManual = "sim";
                            
                            carregaProduto(produto);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Produto não cadastrado para ser vendido por peso");
                            return;
                        }


                    }
                                        
                    
                    
                }
                

                if (dataGridView1.Rows.Count <= 0)
                {
                    dataGridView1.Visible = false;
                    pictureBox10.Visible = false;
                    textBox3.Text = "";
                    pictureBox2.Visible = true;
                    label13.Visible = true;
                    label17.Text = "";
                    textBox1.Text = "";
                    textBox1.Focus();
                    Global.Margem.Contador = "verde";
                    MessageBox.Show("Não existe produto cadastrado com este código de barras");
                    return;
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    textBox1.Text = "";
                    textBox1.Focus();
                    MessageBox.Show("Não existe produto cadastrado com este código de barras");
                    return;
                }
            }
            
            
            


        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CaixaTerminalVendas != "adm")
            {
                MessageBox.Show("Não autorizado");
                return;
            }
            string numvenda = label8.Text;
            if (dataGridView1.Rows.Count > 0)
            {
                string message = "Você deseja cancelar esta venda?";
                string caption = "Cancelar";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        string msg = "Descrição e Quantidade de Produtos retornados ao estoque: \n\n";
                        string produtoretornado = "";
                        
                        decimal somafrac = 0;
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            
                            Int64 qtde;
                            if (Int64.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(), out qtde) == true)
                            {
                                int qtdeinicial2 = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                                string idP = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value)));
                                produtoretornado += dataGridView1.Rows[i].Cells[0].FormattedValue.ToString() + " ==> ";
                                produtoretornado += " Quantidade : " + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "\n";
                                DALCadastro.baixaEstoqueRetorna(idP, Convert.ToString(qtdeinicial2));  

                            }
                            else
                            {
                                somafrac = Convert.ToDecimal( dataGridView1.Rows[i].Cells[1].Value.ToString().Replace("gr", ""));
                                string idP2 = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value)));
                                produtoretornado += dataGridView1.Rows[i].Cells[0].FormattedValue.ToString() + " ==> ";
                                produtoretornado += " Quantidade : " + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "\n";
                                // criar codigo para retornar estoque 
                                DataTable peso = DALCadastro.BaixaFracionadoRetorna(Convert.ToInt32(idP2));
                                decimal calc = Convert.ToDecimal( peso.Rows[0]["EstoquePeso"].ToString());
                                decimal re = calc + somafrac;
                                string rec = Convert.ToString(re);
                                decimal t30;
                                if (Decimal.TryParse(rec.Replace(".", ","), out t30))
                                {
                                    DALCadastro.BaixaFracionado(Convert.ToString(t30).Replace(",", "."), Convert.ToInt32(idP2));
                                }
                               
                                
                            }
                            
                            
                            
                        }
                        
                        DALCadastro.deleteVenda();
                        dataGridView1.DataSource = DALCadastro.listaVendas();
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Cancelada Venda Número: " + label8.Text );
                        }
                        pictureBox10.Visible = false;
                        textBox3.Text = "";
                        dataGridView1.Visible = false;
                        pictureBox2.Visible = true;
                        label13.Visible = true;
                        label17.Text = "";
                        label8.Text = "";
                        label18.Text = "";
                        textBox2.Text = "";
                        pictureBox1.Image = null;
                        pictureBox1.InitialImage = null;
                        Global.Margem.Contador = "verde";
                        
                        panel1.Visible = false;
                        label20.Text = "";
                        if (Global.Margem.ConfiguraçãoSistemaEstoque == "sim")
                        {
                            MessageBox.Show("Venda número ==> " + numvenda + " ------ Cancelada--------\n" + msg + produtoretornado);    
                        }
                        if (Global.Margem.ConfiguraçãoSistemaEstoque == "não")
                        {
                            MessageBox.Show("Venda número ==> " + numvenda + " ------ Cancelada.");
                        }
                        
                        textBox1.Focus();
                    
                    }
                    

                }
                if (result == DialogResult.No)
                {
                    textBox1.Focus();
                    return;
                
                }
            }
            else
            {
                

                    pictureBox10.Visible = false;
                    textBox3.Text = "";
                    dataGridView1.Visible = false;
                    pictureBox2.Visible = true;
                    label13.Visible = true;
                    label17.Text = "";
                    label8.Text = "";
                    label18.Text = "";
                    textBox2.Text = "";
                    pictureBox1.Image = null;
                    pictureBox1.InitialImage = null;
                    Global.Margem.Contador = "verde";

                    panel1.Visible = false;
                    label20.Text = "";

                    MessageBox.Show("Venda número: ==> " + numvenda + " ---- Cancelada-------");
                    textBox1.Focus();

                
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.InitialImage = null;
            textBox2.ForeColor = System.Drawing.Color.Red;
            textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
            label18.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].FormattedValue.ToString();
            if (checkBox1.Checked == true)
            {
                carregaImagem(Convert.ToString(DALCadastro.retornaImagem(label18.Text)));
            }
            label20.Text = "";
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox1.InitialImage = null;
            
            label18.Text = "";
            textBox2.Text = "";
            label20.Text = "";
            textBox1.Focus();
        }

        private void PDV_Load(object sender, EventArgs e)
        {

            string linha;
            try
            {
                using (StreamReader reader = new StreamReader("Caixa.txt"))
                {
                    linha = reader.ReadLine();
                }
            }
            catch (Exception)
            {


                linha = "Caixa 1";
            }
            comboBox1.Text = linha;
            Global.Margem.CaixaSelecionado = linha;
            label3.Text = Global.Margem.Operador;
            Global.Margem.Contador = "verde";
            Form testa = new TestaConexao();
            testa.ShowDialog();
            if (Global.Margem.Erro == "no")
            {
                MessageBox.Show("Conexão não foi estabelecida com Banco de Dados!");
                Global.Margem.Erro = "";
                Application.Exit();
            }
            if (Global.Margem.Erro == "yes")
            {
                if (Global.Margem.Impressora == "mp4200th")
                {
                    //Configurando a impressora e sua porta
                    int iRetorno = 0;
                    iRetorno = MP2032.ConfiguraModeloImpressora(7);
                    iRetorno = MP2032.IniciaPorta("USB");
                    iRetorno = MP2032.AjustaLarguraPapel(80);



                    if (iRetorno <= 0) //testa se a conexão da porta foi bem sucedido
                    {
                        MessageBox.Show("Não foi possível conectar com a impressora!!!");

                    }

                }

                MessageBox.Show("Conexão estabelecida com Banco de Dados!");
                Global.Margem.Erro = "";
                textBox1.Focus();
                DataTable lista = DALCadastro.listaVendas();
                if (lista.Rows.Count > 0)
                {
                    MessageBox.Show("Existem vendas não finalizadas");
                    dataGridView1.DataSource = lista;
                    textBox1.Focus();
                    dataGridView1.Visible = true;
                    pictureBox2.Visible = false;
                    label13.Visible = false;
                    pictureBox10.Visible = true;
                    
                    panel1.Visible = true;

                    int x = Screen.PrimaryScreen.Bounds.Width;
                    int y = Screen.PrimaryScreen.Bounds.Height;

                    int Qtde = 0;
                    decimal sum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {


                        dataGridView1.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Coral;
                        if (x == 1440 && y == 900)
                        {
                            dataGridView1.Columns[0].Width = 500;
                             
                        }
                        if (x == 1366 && y == 768)
                        {
                            dataGridView1.Columns[0].Width = 450;
                        }
                        if (x == 1024 && y == 768)
                        {
                            dataGridView1.Columns[0].Width = 200;
                        }
                        if (y > 900)
                        {
                            dataGridView1.Columns[0].Width = 200;
                        }
                        if (x > 1440)
                        {
                            dataGridView1.Columns[0].Width = 500;
                        }

                        dataGridView1.Columns[5].Width = 100;
                        dataGridView1.Columns[2].Width = 120;
                        dataGridView1.Columns[1].Width = 120;
                        sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                        Int64 qtde;
                        if (Int64.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(), out qtde) == false)
                        {
                            Qtde += 1;

                        }
                        else
                        {
                            Qtde += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                        }
                    }


                    textBox3.Text = Convert.ToString(sum);
                    label17.Text = Convert.ToString(Qtde) + "   ítem(s).";
                }
                else
                {
                    textBox1.Focus();
                }
            }
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Selecione um ítem da venda para alterar quantidade!");
                textBox1.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Int64 qtde;
            if (Int64.TryParse(textBox2.Text.Trim(), out qtde) == false)
            {
                return;
            }
            if (String.IsNullOrEmpty(label18.Text) == false)
            {
                int qtdeinicial = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
                string idP = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(label18.Text)));
                if (qtdeinicial == 1 && qtdeinicial < Convert.ToInt32(textBox2.Text))
                {
                    int baixar = Convert.ToInt32(textBox2.Text) - 1;
                    DALCadastro.baixaEstoque(idP, Convert.ToString(baixar));
                }
                if (qtdeinicial > 1 && qtdeinicial < Convert.ToInt32(textBox2.Text))
                {
                    int resultado = Convert.ToInt32(textBox2.Text) - qtdeinicial;
                    DALCadastro.baixaEstoque(idP, Convert.ToString(resultado));
                }
                if (qtdeinicial == Convert.ToInt32(textBox2.Text))
                {
                    MessageBox.Show("Não houve alteração na quantidade");
                }
                
                Decimal dec = Convert.ToDecimal( dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString());
                Decimal result = dec * Convert.ToDecimal(textBox2.Text);

                
                
                
                //carregaProduto(DALCadastro.produtoVenda());
                DALCadastro.qtdeVenda(Convert.ToString(textBox2.Text),label18.Text,Convert.ToString(result));
                

                dataGridView1.DataSource = DALCadastro.listaVendas();
                textBox1.Text = "";
                textBox1.Focus();
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                int Qtde = 0;
                decimal sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Coral;
                    if (x == 1440 && y == 900)
                    {
                        dataGridView1.Columns[0].Width = 500;
                    }
                    if (x == 1366 && y == 768)
                    {
                        dataGridView1.Columns[0].Width = 450;
                    }
                    if (x == 1024 && y == 768)
                    {
                        dataGridView1.Columns[0].Width = 200;
                    }

                    dataGridView1.Columns[5].Width = 100;
                    dataGridView1.Columns[2].Width = 120;
                    dataGridView1.Columns[1].Width = 120;
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                    Int64 qtde2;
                    if (Int64.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(), out qtde2) == false)
                    {
                        Qtde += 1;

                    }
                    else
                    {
                        Qtde += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    }
                }

                textBox3.Text = Convert.ToString(sum);
                label17.Text = Convert.ToString(Qtde) + "   ítem(s).";

                label18.Text = "";
                textBox2.Text = "";
                
                MessageBox.Show("Qtde alterada com sucesso");
                textBox1.Focus();
            }
            else
            {
                pictureBox1.Image = null;
                pictureBox1.InitialImage = null;
                textBox1.Focus();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Int64 qtde;
            if (Int64.TryParse(textBox2.Text.Trim(), out qtde) == false)
            {
                return;
            }
            if (textBox2.Text == "")
            {
                textBox1.Focus();
            }
            else
            {
                int num = Convert.ToInt32(textBox2.Text);
                num++;
                textBox2.Text = Convert.ToString( num );
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                pictureBox1.Image = null;
                pictureBox1.InitialImage = null;
            }
            textBox1.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            label18.Text = "";
            textBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            pictureBox17.Visible = true;
            Form proc = new ProcurarPDV();
            proc.ShowDialog();
            pictureBox17.Visible = false;
            if (Global.Margem.RetornarIDaviso == "achei")
            {
               
                carregaProduto(DALCadastro.ProcurarProdutoSemCodeBarId(Global.Margem.RetornarID));
            }
            Global.Margem.RetornarID = "";
            Global.Margem.RetornarIDaviso = "";
            textBox1.Focus();
            

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.Text != Global.Margem.CaixaSelecionado)
            {
                string message = "Você deseja Mudar identificação deste Terminal no Sistema?";
                string caption = "identificação";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Mostra a MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    using (StreamWriter writer = new StreamWriter("Caixa.txt"))
                    {
                        writer.Write(comboBox1.Text);
                        if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                        {
                            Ferramentas.CriaLog("CaixaTerminalVendas", "Alterou Identificação do Caixa para : " + comboBox1.Text);
                        }

                    }
                }
                if (result == DialogResult.No)
                {
                    comboBox1.Text = Global.Margem.CaixaSelecionado;
                }
            }
            else
            {
                return;
            }

        }

        private void PDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                Global.Margem.RetiradaCaixa = comboBox1.Text;
                Form ret = new Retirada();
                ret.ShowDialog();
                Global.Margem.RetiradaCaixa = "";
            }
            if (e.KeyCode == Keys.F1)
            {

                MessageBox.Show("Ajuda :\nPressione F3 para Procurar/Localizar" + "\nF4 para confirmar alteração da quantidade" + 
                    "\nF5 para Selecionar Produto da Venda\nTecla de Espaço para selecionar Produto\nDel para excluír produto da venda\n" +
                    "ESC para cancelar\n+ para adicionar quantidade\nF10 para finalizar Venda\nF12 para cancelar Venda");
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (Global.Margem.CaixaTerminalVendas != "adm")
                {
                    MessageBox.Show("Não autorizado");
                    return;
                }
                string numVenda = label8.Text;
                string prodvend = "";
                int qtdeinicial = 0;
                if (String.IsNullOrEmpty(label18.Text) == false)
                {
                    Int64 qtde;
                    if (Int64.TryParse(textBox2.Text.Trim(), out qtde) == true)
                    {
                        qtdeinicial = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
                        string idP = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(label18.Text)));
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == label18.Text)
                            {
                                prodvend += dataGridView1.Rows[i].Cells[0].Value.ToString() + " ==> Quantidade : "
                                    + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                            }
                        }
                        DALCadastro.baixaEstoqueRetorna(idP, Convert.ToString(qtdeinicial));
                        DALCadastro.deletaProduto(label18.Text);
                    }
                    else
                    {
                        //qtdeinicial = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString().Replace("gr",""));
                        string idP = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(label18.Text)));
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[5].Value.ToString() == label18.Text)
                            {
                                prodvend += dataGridView1.Rows[i].Cells[0].Value.ToString() + " ==> Quantidade : "
                                    + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                            }
                        }
                        //volta para estoque peso
                        MessageBox.Show(prodvend);
                    }




                    dataGridView1.DataSource = DALCadastro.listaVendas();

                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("CaixaTerminalVendas", "Excluiu ítem da Venda Número: " + label8.Text + " : " + prodvend);
                    }
                    textBox1.Text = "";
                    textBox1.Focus();
                    int x = Screen.PrimaryScreen.Bounds.Width;
                    int y = Screen.PrimaryScreen.Bounds.Height;
                    int Qtde = 0;
                    decimal sum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        dataGridView1.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Coral;
                        if (x == 1440 && y == 900)
                        {
                            dataGridView1.Columns[0].Width = 500;
                        }
                        if (x == 1366 && y == 768)
                        {
                            dataGridView1.Columns[0].Width = 450;
                        }
                        if (x == 1024 && y == 768)
                        {
                            dataGridView1.Columns[0].Width = 200;
                        }

                        dataGridView1.Columns[5].Width = 100;
                        dataGridView1.Columns[2].Width = 120;
                        dataGridView1.Columns[1].Width = 120;
                        sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                        Qtde++;
                    }


                    textBox3.Text = Convert.ToString(sum);
                    label17.Text = Convert.ToString(Qtde) + "   ítem(s).";
                    textBox2.Text = "";
                    label18.Text = "";
                    if (Global.Margem.ConfiguraçãoSistemaEstoque == "sim")
                    {
                        MessageBox.Show("Produto retirado da venda com sucesso\nDescrição e Quantidade do Produto retornado ao estoque:\n\n"
                        + prodvend);
                    }
                    if (Global.Margem.ConfiguraçãoSistemaEstoque == "não")
                    {
                        MessageBox.Show("Produto retirado da venda com sucesso");
                    }
                    pictureBox1.Image = null;
                    pictureBox1.InitialImage = null;
                    textBox1.Focus();
                    dataGridView1.DataSource = DALCadastro.listaVendas();
                    if (dataGridView1.Rows.Count <= 0)
                    {
                        string message = "Você deseja cancelar esta venda?";
                        string caption = "Cancelar";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        if (result == DialogResult.Yes)
                        {
                            pictureBox10.Visible = false;
                            textBox3.Text = "";
                            dataGridView1.Visible = false;
                            pictureBox2.Visible = true;
                            label13.Visible = true;

                            label17.Text = "";
                            label8.Text = "";
                            label18.Text = "";
                            textBox2.Text = "";
                            pictureBox1.Image = null;
                            pictureBox1.InitialImage = null;
                            Global.Margem.Contador = "verde";

                            panel1.Visible = false;
                            label20.Text = "";
                            MessageBox.Show("Venda número: ==> " + numVenda + " ------cancelada--------");
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Cancelada Venda Número : " + numVenda);
                            }
                            textBox1.Focus();
                        }
                        if (result == DialogResult.No)
                        {
                            textBox1.Focus();
                        }
                    }

                }
                else
                {
                    textBox1.Focus();
                }
                return;
                
            }
            if (e.KeyCode == Keys.F3)
            {

                //abir localizar
                pictureBox17.Visible = true;
                Form proc = new ProcurarPDV();
                proc.ShowDialog();
                pictureBox17.Visible = false;
                if (Global.Margem.RetornarIDaviso == "achei")
                {
                    carregaProduto(DALCadastro.ProcurarProdutoSemCodeBarId(Global.Margem.RetornarID));
                }
                Global.Margem.RetornarID = "";
                Global.Margem.RetornarIDaviso = "";
                textBox1.Focus();
            }
            
            if (e.KeyCode == Keys.F10)
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Global.Margem.Troco = "não";
                    Global.Margem.TrocoVenda = textBox3.Text;
                    pictureBox17.Visible = true;
                    Form troco = new Troco();
                    troco.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Não existe venda para ser finalizada");
                    pictureBox17.Visible = false;
                    textBox1.Focus();
                }
                if (Global.Margem.Troco == "não")
                {
                    pictureBox17.Visible = false;
                    textBox1.Focus();
                    return;
                }
                if (Global.Margem.Troco == "sim")
                {
                    pictureBox17.Visible = true;
                    Ferramentas.Dedo_Duro();
                    if (Global.Margem.ExpirouLicença == "sim")
                    {
                        Application.Exit();
                    }
                    if (dataGridView1.Rows.Count > 0)
                    {
                        Global.Margem.Numvenda = label8.Text;
                        Global.Margem.Totalvenda = textBox3.Text;
                        Form tipoPag = new tipoPagamento();
                        tipoPag.ShowDialog();
                        if (Global.Margem.Cancelar == "OK")
                        {
                            pictureBox17.Visible = false;
                            Global.Margem.Cancelar = "";
                            return;
                        }
                        Form print = new ImprimeCupom();
                        print.ShowDialog();
                        dataGridView1.DataSource = DALCadastro.listaVendas();
                        textBox1.Text = "";
                        textBox1.Focus();

                        textBox3.Text = "";
                        dataGridView1.Visible = false;
                        pictureBox2.Visible = true;
                        label13.Visible = true;
                        label17.Text = "";
                        label8.Text = "";
                        label18.Text = "";
                        textBox2.Text = "";
                        pictureBox1.Image = null;
                        pictureBox1.InitialImage = null;
                        Global.Margem.Contador = "verde";

                        Global.Margem.Numvenda = "";
                        Global.Margem.Totalvenda = "";
                        panel1.Visible = false;
                        label20.Text = "";
                        pictureBox17.Visible = false;


                    }
                    else
                    {
                        MessageBox.Show("Não existe venda para ser finalizada");
                        textBox1.Focus();
                    }

                    textBox1.Focus();
                    return;
                }
                textBox1.Focus();
                return;
                
            }
            
            if (e.KeyCode == Keys.F12)
            {
                if (Global.Margem.CaixaTerminalVendas != "adm")
                {
                    MessageBox.Show("Não autorizado");
                    return;
                }
                string numvenda = label8.Text;
                if (dataGridView1.Rows.Count > 0)
                {
                    string message = "Você deseja cancelar esta venda?";
                    string caption = "Cancelar";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Displays the MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        if (dataGridView1.Rows.Count > 0)
                        {
                            string msg = "Descrição e Quantidade de Produtos retornados ao estoque: \n\n";
                            string produtoretornado = "";

                            decimal somafrac = 0;
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {

                                Int64 qtde;
                                if (Int64.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(), out qtde) == true)
                                {
                                    int qtdeinicial2 = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                                    string idP = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value)));
                                    produtoretornado += dataGridView1.Rows[i].Cells[0].FormattedValue.ToString() + " ==> ";
                                    produtoretornado += " Quantidade : " + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "\n";
                                    DALCadastro.baixaEstoqueRetorna(idP, Convert.ToString(qtdeinicial2));

                                }
                                else
                                {
                                    somafrac = Convert.ToDecimal(dataGridView1.Rows[i].Cells[1].Value.ToString().Replace("gr", ""));
                                    string idP2 = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value)));
                                    produtoretornado += dataGridView1.Rows[i].Cells[0].FormattedValue.ToString() + " ==> ";
                                    produtoretornado += " Quantidade : " + Convert.ToString(dataGridView1.Rows[i].Cells[1].Value) + "\n";
                                    // criar codigo para retornar estoque 
                                    DataTable peso = DALCadastro.BaixaFracionadoRetorna(Convert.ToInt32(idP2));
                                    decimal calc = Convert.ToDecimal(peso.Rows[0]["EstoquePeso"].ToString());
                                    decimal re = calc + somafrac;
                                    string rec = Convert.ToString(re);
                                    decimal t30;
                                    if (Decimal.TryParse(rec.Replace(".", ","), out t30))
                                    {
                                        DALCadastro.BaixaFracionado(Convert.ToString(t30).Replace(",", "."), Convert.ToInt32(idP2));
                                    }


                                }



                            }
                            

                            DALCadastro.deleteVenda();
                            dataGridView1.DataSource = DALCadastro.listaVendas();
                            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                            {
                                Ferramentas.CriaLog("CaixaTerminalVendas", "Cancelada Venda Número: " + label8.Text);
                            }
                            pictureBox10.Visible = false;
                            textBox3.Text = "";
                            dataGridView1.Visible = false;
                            pictureBox2.Visible = true;
                            label13.Visible = true;
                            label17.Text = "";
                            label8.Text = "";
                            label18.Text = "";
                            textBox2.Text = "";
                            pictureBox1.Image = null;
                            pictureBox1.InitialImage = null;
                            Global.Margem.Contador = "verde";

                            panel1.Visible = false;
                            label20.Text = "";
                            if (Global.Margem.ConfiguraçãoSistemaEstoque == "sim")
                            {
                                MessageBox.Show("Venda número ==> " + numvenda + " ------ Cancelada--------\n" + msg + produtoretornado);
                            }
                            if (Global.Margem.ConfiguraçãoSistemaEstoque == "não")
                            {
                                MessageBox.Show("Venda número ==> " + numvenda + " ------ Cancelada.");
                            }

                            textBox1.Focus();

                        }


                    }
                    if (result == DialogResult.No)
                    {
                        textBox1.Focus();
                        return;

                    }
                }
                else
                {


                    pictureBox10.Visible = false;
                    textBox3.Text = "";
                    dataGridView1.Visible = false;
                    pictureBox2.Visible = true;
                    label13.Visible = true;
                    label17.Text = "";
                    label8.Text = "";
                    label18.Text = "";
                    textBox2.Text = "";
                    pictureBox1.Image = null;
                    pictureBox1.InitialImage = null;
                    Global.Margem.Contador = "verde";

                    panel1.Visible = false;
                    label20.Text = "";

                    MessageBox.Show("Venda número: ==> " + numvenda + " ---- Cancelada-------");
                    textBox1.Focus();


                }
                return;
            }
            if (e.KeyCode == Keys.Space)
            {

                pictureBox1.Image = null;
                pictureBox1.InitialImage = null;
                textBox2.ForeColor = System.Drawing.Color.Red;
                textBox2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                label18.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].FormattedValue.ToString();
                if (checkBox1.Checked == true)
                {
                    carregaImagem(Convert.ToString(DALCadastro.retornaImagem(label18.Text)));
                }
                label20.Text = "";
                return;
            }
            if (e.KeyCode == Keys.F5)
            {
                dataGridView1.Focus();
                return;
            }
            if (e.KeyCode == Keys.F4)
            {
                Int64 qtde;
                if (Int64.TryParse(textBox2.Text.Trim(), out qtde) == false)
                {
                    return;
                }
                if (String.IsNullOrEmpty(label18.Text) == false)
                {
                    int qtdeinicial = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString());
                    string idP = Convert.ToString(DALCadastro.retornaIdProd(Convert.ToInt32(label18.Text)));
                    if (qtdeinicial == 1 && qtdeinicial < Convert.ToInt32(textBox2.Text))
                    {
                        int baixar = Convert.ToInt32(textBox2.Text) - 1;
                        DALCadastro.baixaEstoque(idP, Convert.ToString(baixar));
                    }
                    if (qtdeinicial > 1 && qtdeinicial < Convert.ToInt32(textBox2.Text))
                    {
                        int resultado = Convert.ToInt32(textBox2.Text) - qtdeinicial;
                        DALCadastro.baixaEstoque(idP, Convert.ToString(resultado));
                    }
                    if (qtdeinicial == Convert.ToInt32(textBox2.Text))
                    {
                        MessageBox.Show("Não houve alteração na quantidade");
                    }

                    Decimal dec = Convert.ToDecimal(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString());
                    Decimal result = dec * Convert.ToDecimal(textBox2.Text);




                    //carregaProduto(DALCadastro.produtoVenda());
                    DALCadastro.qtdeVenda(Convert.ToString(textBox2.Text), label18.Text, Convert.ToString(result));


                    dataGridView1.DataSource = DALCadastro.listaVendas();
                    textBox1.Text = "";
                    textBox1.Focus();
                    int x = Screen.PrimaryScreen.Bounds.Width;
                    int y = Screen.PrimaryScreen.Bounds.Height;
                    int Qtde = 0;
                    decimal sum = 0;
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        dataGridView1.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Coral;
                        if (x == 1440 && y == 900)
                        {
                            dataGridView1.Columns[0].Width = 500;
                        }
                        if (x == 1366 && y == 768)
                        {
                            dataGridView1.Columns[0].Width = 450;
                        }
                        if (x == 1024 && y == 768)
                        {
                            dataGridView1.Columns[0].Width = 200;
                        }

                        dataGridView1.Columns[5].Width = 100;
                        dataGridView1.Columns[2].Width = 120;
                        dataGridView1.Columns[1].Width = 120;
                        sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                        Int64 qtde2;
                        if (Int64.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(), out qtde2) == false)
                        {
                            Qtde += 1;

                        }
                        else
                        {
                            Qtde += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                        }
                    }

                    textBox3.Text = Convert.ToString(sum);
                    label17.Text = Convert.ToString(Qtde) + "   ítem(s).";

                    label18.Text = "";
                    textBox2.Text = "";

                    MessageBox.Show("Qtde alterada com sucesso");
                    textBox1.Focus();
                }
                else
                {
                    pictureBox1.Image = null;
                    pictureBox1.InitialImage = null;
                    textBox1.Focus();
                }
                return;

            }
            if (e.KeyCode == Keys.Escape)
            {
                label18.Text = "";
                textBox2.Text = "";
                textBox1.Focus();
                return;
            }
            if (e.KeyCode == Keys.Add)
            {
                Int64 qtde;
                if (Int64.TryParse(textBox2.Text.Trim(), out qtde) == false)
                {
                    return;
                }
                if (textBox2.Text == "")
                {
                    textBox1.Focus();
                }
                else
                {
                    int num = Convert.ToInt32(textBox2.Text);
                    num++;
                    textBox2.Text = Convert.ToString(num);
                }
                return;
            }
            
            

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Global.Margem.RetiradaCaixa = comboBox1.Text;
            Form ret = new Retirada();
            ret.ShowDialog();
            Global.Margem.RetiradaCaixa = "";
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.BackColor = System.Drawing.Color.YellowGreen;
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            pictureBox9.BackColor = System.Drawing.Color.Cyan;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (Global.Margem.Impressora == "mp4200th")
            {
                const int charCode = 27;
                const int charCode2 = 118;
                const int charCode3 = 140;
                var specialChar = Convert.ToChar(charCode);
                var specialChar2 = Convert.ToChar(charCode2);
                var specialChar3 = Convert.ToChar(charCode3);
                string cmdText = "" + specialChar + specialChar2 + specialChar3;
                int iRetorno = MP2032.ComandoTX(cmdText, cmdText.Length);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Form desc = new Desconto(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString());
                desc.ShowDialog();
                string id = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].FormattedValue.ToString();
               
                
                DALCadastro.InsereDesconto(Global.Margem.DescontoValor,Convert.ToInt32(id));                
                dataGridView1.DataSource = DALCadastro.listaVendas();
                Global.Margem.DescontoValor = "";
                int Qtde = 0;
                decimal sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {

                    int x = Screen.PrimaryScreen.Bounds.Width;
                    int y = Screen.PrimaryScreen.Bounds.Height;
                    dataGridView1.Rows[i].Cells[4].Style.BackColor = System.Drawing.Color.Coral;
                    if (x == 1440 && y == 900)
                    {
                        dataGridView1.Columns[0].Width = 500;
                    }
                    if (x == 1366 && y == 768)
                    {
                        dataGridView1.Columns[0].Width = 450;
                    }
                    if (x == 1024 && y == 768)
                    {
                        dataGridView1.Columns[0].Width = 200;
                    }

                    dataGridView1.Columns[5].Width = 100;
                    dataGridView1.Columns[2].Width = 120;
                    dataGridView1.Columns[1].Width = 120;
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);
                    Int64 qtde;
                    if (Int64.TryParse(dataGridView1.Rows[i].Cells[1].Value.ToString().Trim(), out qtde) == false)
                    {
                        Qtde += 1;

                    }
                    else
                    {
                        Qtde += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                    }
                }


                textBox3.Text = Convert.ToString(sum);
                label17.Text = Convert.ToString(Qtde) + "   ítem(s).";
            }
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Não é permitido localizar produto neste campo");
            return;
        }

       
    }
}
