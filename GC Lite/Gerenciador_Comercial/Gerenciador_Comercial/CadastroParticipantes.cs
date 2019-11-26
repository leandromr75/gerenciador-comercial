using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class CadastroParticipantes : Form
    {
        public CadastroParticipantes()
        {
            InitializeComponent();
        }

        private void CadastroParticipantes_Load(object sender, EventArgs e)
        {
            this.Text = "[Cadastro de Participantes. Operador ==> " + Global.Margem.Operador + "]";
            

            DataTable cor10 = DALCadastro.CoresRetorna(Global.Margem.Operador.ToString());
            if (cor10.Rows.Count > 0)
            {
                panel9.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["CorMenu"].ToString()));
                panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor2"].ToString()));
                tabPage3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor3"].ToString()));           
                panel4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor10.Rows[0]["Cor4"].ToString()));
                
            }
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form formPrincipal = new TelaPrincipal();
            //Faz a chamada ao gerenciador de formulário
            GerenciadorDeFormulario.Abre(formPrincipal);
            GerenciadorDeFormulario.Fecha(this);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Form cep = new CEP();
            cep.ShowDialog();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
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

                string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
                //define a instrução SQL para somar Quantidade e agrupar resultados

                String strSQL = "SELECT IDENT_CURRENT ( 'Participantes' )";

                //cria a conexão com o banco de dados
                OleDbConnection dbConnection = new OleDbConnection(strConnection);

                //cria a conexão com o banco de dados
                OleDbConnection con = new OleDbConnection(strConnection);
                //cria o objeto command para executar a instruçao sql
                OleDbCommand cmd = new OleDbCommand(strSQL, con);

                //abre a conexao
                con.Open();
                cmd.CommandType = CommandType.Text;
                label41.Text = Convert.ToString( cmd.ExecuteScalar() );
                
                

                con.Dispose();
                con.Close();
                cmd.Dispose();
                dbConnection.Dispose();
                dbConnection.Close();
                //atribui o datatable ao datagridview para exibir o resultado
                //dataGridView1.DataSource = clientes;
                comboBox21.Text = "Cliente";
                comboBox20.Text = "Ativo";
                comboBox13.Text = "Brasil";
                comboBox12.Text = "SP";
                textBox12.Text = "";
                textBox16.Text = "";
                textBox14.Text = "";
                textBox13.Text = "";
                textBox25.Text = "";
                richTextBox1.Text = "";
                textBox17.Text = "";
                textBox11.Text = "";
                textBox8.Text = "";
                textBox19.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";
                textBox7.Text = "";
                textBox24.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                Global.Margem.cadParticipantesEstado = "ok";
                
                MessageBox.Show("Aberto novo cadastro de Participantes");
            }
            if (result == DialogResult.No)
            {

                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            //cod para localizar clientes já cadastrados

           
            
                
            
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroParticipantes != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }             
            if (Global.Margem.cadParticipantesEstado == "ok")
            {
                textBox12.Text = Ferramentas.Retira_Meta(textBox12.Text);
                string pessoafisica = "";
                if (checkBox2.Checked == true)
                {
                    pessoafisica = "sim";
                   
                }
                if (checkBox2.Checked == false)
                {
                    pessoafisica = "não";
                }  
                DALCadastro.Cadastrar_Participante(/*finalidade*/comboBox21.Text,/*pessoaFisica*/pessoafisica,/*nome*/textBox12.Text,/*fantasia*/textBox16.Text,
                        /*cpf-cnpj*/textBox14.Text,/*inscrição estadual*/textBox13.Text,/*situação*/comboBox20.Text,/*atividade*/comboBox19.Text,
                        /*Empresa*/textBox25.Text,/*Observações*/richTextBox1.Text,/*contato*/textBox17.Text,/*email-nfe*/textBox11.Text,
                        /*email-contabil*/textBox8.Text,/*telefone1*/textBox27.Text,/*telefone2*/textBox26.Text,/*logradouro*/textBox19.Text,/*numero*/textBox22.Text,/*complemento*/textBox23.Text,
                        /*bairro*/textBox7.Text,/*cidade*/textBox24.Text,/*estado*/comboBox12.Text,/*país*/comboBox13.Text,/*cep*/textBox2.Text,
                        /*caixa-postal*/textBox4.Text);

                
                

                MessageBox.Show("Participante cadastrado com sucesso");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {

                    Ferramentas.CriaLog("CadParticipantes", "Salvou registro ==> " + label41.Text + " / " + textBox12.Text );
                }
                
                
            }
            if (Global.Margem.cadParticipantesEstado == "")
            {
                MessageBox.Show("Você deve clicar em novo cadastro ou em editar para fazer alterações");
                return;
            }
            if (Global.Margem.cadParticipantesEstado == "edita")
            {
                textBox12.Text = Ferramentas.Retira_Meta(textBox12.Text);
                string pessoafisica = "";
                if (checkBox2.Checked == true)
                {
                    pessoafisica = "sim";
                }
                if (checkBox2.Checked == false)
                {
                    pessoafisica = "não";
                }
                DALCadastro.Cadastrar_Participante_Edita(label41.Text,/*finalidade*/comboBox21.Text,/*pessoaFisica*/pessoafisica,/*nome*/textBox12.Text,/*fantasia*/textBox16.Text,
                    /*cpf-cnpj*/textBox14.Text,/*inscrição estadual*/textBox13.Text,/*situação*/comboBox20.Text,/*atividade*/comboBox19.Text,
                    /*Empresa*/textBox25.Text,/*Observações*/richTextBox1.Text,/*contato*/textBox17.Text,/*email-nfe*/textBox11.Text,
                    /*email-contabil*/textBox8.Text,/*telefone1*/textBox27.Text,/*telefone2*/textBox26.Text,/*logradouro*/textBox19.Text,/*numero*/textBox22.Text,/*complemento*/textBox23.Text,
                    /*bairro*/textBox7.Text,/*cidade*/textBox24.Text,/*estado*/comboBox12.Text,/*país*/comboBox13.Text,/*cep*/textBox2.Text,
                    /*caixa-postal*/textBox4.Text);

                

                

                    MessageBox.Show("Dados alterados com sucesso");
            }

            Global.Margem.cadParticipantesEstado = "";
            
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox12.Text) == false)
            {
                textBox12.Text = Ferramentas.Retira_Meta(textBox12.Text);
                Global.Margem.AchaNomePart = textBox12.Text;
                Form part = new VerificaParticipante();
                part.ShowDialog();
                if (Global.Margem.semaforoPart == "ok")
                {
                    abrirParticipante(DALCadastro.CarregaParticipante(Global.Margem.semaforoPartInt));
                }
                Global.Margem.AchaNomePart = "";
                Global.Margem.semaforoPart = "";
                Global.Margem.semaforoPartInt = "";

            }
        }
        public void abrirParticipante(DataTable participante)
        {
            if (participante.Rows.Count > 0)
            {
                textBox12.Text = "";
                textBox16.Text = "";
                textBox14.Text = "";
                textBox13.Text = "";
                textBox25.Text = "";
                richTextBox1.Text = "";
                textBox17.Text = "";
                textBox11.Text = "";
                textBox8.Text = "";
                textBox19.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";
                textBox7.Text = "";
                textBox24.Text = "";
                textBox2.Text = "";
                textBox4.Text = "";
                checkBox6.Visible = true;
                //||||||identificador==>0||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Identificador"].ToString())) == false)
                {
                    label41.Text = Convert.ToString(participante.Rows[0]["Identificador"].ToString());
                }
                //||||||finalidade==>2||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Finalidade"].ToString())) == false)
                {
                    comboBox21.Text = Convert.ToString(participante.Rows[0]["Finalidade"].ToString());
                }
                //||||||pessoa_fisica==>3||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Pessoa_fisica"].ToString())) == false)
                {
                    string pf = Convert.ToString(participante.Rows[0]["Pessoa_fisica"].ToString());
                    if (pf == "sim")
                    {
                        checkBox2.Checked = true;
                    }
                    if (pf == "não")
                    {
                        checkBox2.Checked = false;
                    }
                }
                //||||||nome-razão==>4||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Nome"].ToString())) == false)
                {
                    textBox12.Text = Convert.ToString(participante.Rows[0]["Nome"].ToString());
                }
                //||||||fantasia==>5||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Fantasia"].ToString())) == false)
                {
                    textBox16.Text = Convert.ToString(participante.Rows[0]["Fantasia"].ToString());
                }
                //||||||cpf-cnpj==>6||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["CPF_CNPJ"].ToString())) == false)
                {
                    textBox14.Text = Convert.ToString(participante.Rows[0]["CPF_CNPJ"].ToString());
                }
                //||||||insc_estadual==>7||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Insc_Estadual"].ToString())) == false)
                {
                    textBox13.Text = Convert.ToString(participante.Rows[0]["Insc_Estadual"].ToString());
                    if (textBox13.Text == "ISENTO")
                    {
                        checkBox3.Checked = true;
                    }
                }
                //||||||situação==>8||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Situação"].ToString())) == false)
                {
                    comboBox20.Text = Convert.ToString(participante.Rows[0]["Situação"].ToString());
                    if (comboBox20.Text == "SPC")
                    {
                        checkBox4.Checked = true;
                    }
                }
                //||||||atividade==>9||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Atividade"].ToString())) == false)
                {
                    comboBox19.Text = Convert.ToString(participante.Rows[0]["Atividade"].ToString());
                }
                //||||||empresa==>10||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Empresa"].ToString())) == false)
                {
                    textBox25.Text = Convert.ToString(participante.Rows[0]["Empresa"].ToString());
                }
                //||||||Observações==>11||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Observações"].ToString())) == false)
                {
                    richTextBox1.Text = Convert.ToString(participante.Rows[0]["Observações"].ToString());
                }
                //||||||contato==>12||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Contato"].ToString())) == false)
                {
                    textBox17.Text = Convert.ToString(participante.Rows[0]["Contato"].ToString());
                }
                //||||||email-nfe==>13||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Email_NFe"].ToString())) == false)
                {
                    textBox11.Text = Convert.ToString(participante.Rows[0]["Email_NFe"].ToString());
                }
                //||||||email-contabil==>14||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Email_Contabil"].ToString())) == false)
                {
                    textBox8.Text = Convert.ToString(participante.Rows[0]["Email_Contabil"].ToString());
                }
                //||||||telefone1==>15||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Telefone1"].ToString())) == false)
                {
                    textBox27.Text = Convert.ToString(participante.Rows[0]["Telefone1"].ToString());
                }
                //||||||telefone2==>16||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Telefone2"].ToString())) == false)
                {
                    textBox26.Text = Convert.ToString(participante.Rows[0]["Telefone2"].ToString());
                }
                //||||||logradouro==>17||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Logradouro"].ToString())) == false)
                {
                    textBox19.Text = Convert.ToString(participante.Rows[0]["Logradouro"].ToString());
                }
                //||||||numero==>18||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Numero"].ToString())) == false)
                {
                    textBox22.Text = Convert.ToString(participante.Rows[0]["Numero"].ToString());
                }
                //||||||complemento==>19||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Complemento"].ToString())) == false)
                {
                    textBox23.Text = Convert.ToString(participante.Rows[0]["Complemento"].ToString());
                }
                //||||||bairro==>20||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Bairro"].ToString())) == false)
                {
                    textBox7.Text = Convert.ToString(participante.Rows[0]["Bairro"].ToString());
                }
                //||||||cidade==>21||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Cidade"].ToString())) == false)
                {
                    textBox24.Text = Convert.ToString(participante.Rows[0]["Cidade"].ToString());
                }
                //||||||estado==>22||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Estado"].ToString())) == false)
                {
                    comboBox12.Text = Convert.ToString(participante.Rows[0]["Estado"].ToString());
                }
                //||||||país==>23||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Pais"].ToString())) == false)
                {
                    comboBox13.Text = Convert.ToString(participante.Rows[0]["Pais"].ToString());
                }
                //||||||cep==>24||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["CEP"].ToString())) == false)
                {
                    textBox2.Text = Convert.ToString(participante.Rows[0]["CEP"].ToString());
                }
                //||||||caixa-postal==>25||||||||||
                if (String.IsNullOrEmpty(Convert.ToString(participante.Rows[0]["Caixa_Postal"].ToString())) == false)
                {
                    textBox4.Text = Convert.ToString(participante.Rows[0]["Caixa_Postal"].ToString());
                }
                



                
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                textBox13.Text = "ISENTO";
                textBox13.ReadOnly = true;
            }
            if (checkBox3.Checked == false)
            {
                textBox13.Text = "";
                textBox13.ReadOnly = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                comboBox20.Text = "SPC";
            }
            if (checkBox4.Checked == false)
            {
                comboBox20.Text = "Ativo";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form pesqPart = new PesquisaParticipante();
            pesqPart.ShowDialog();
            if (Global.Margem.semaforoPart == "ok")
            {
                abrirParticipante(DALCadastro.CarregaParticipante(Global.Margem.semaforoPartInt));
            }
            Global.Margem.AchaNomePart = "";
            Global.Margem.semaforoPart = "";
            Global.Margem.semaforoPartInt = "";
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroParticipantes == "adm")
            {
                Global.Margem.cadParticipantesEstado = "edita";
                MessageBox.Show("Pronto para aceitar alterações neste registro");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {

                    Ferramentas.CriaLog("CadParticipantes", "Iniciou edição do registro ==> " + label41.Text + " / " + textBox12.Text);
                }
            }
            else
            {
                MessageBox.Show("Acesso não autorizado");
            }
            
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (textBox27.TextLength == 2)
            {


                textBox27.Text = "(" + textBox27.Text + ")";
                textBox27.Select(textBox27.Text.Length, 0);
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            if (textBox26.TextLength == 2)
            {


                textBox26.Text = "(" + textBox26.Text + ")";
                textBox26.Select(textBox27.Text.Length, 0);
            }
        }

        private void textBox14_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true )
            {

                //string temp = Ferramentas.Retira_Meta(textBox14.Text);
                if (checkBox7.Checked == true)
                {
                    if (textBox14.TextLength == 3)
                    {
                        textBox14.Text = textBox14.Text + ".";
                        textBox14.Select(textBox14.Text.Length,0);
                    }
                    if (textBox14.TextLength == 7)
                    {
                        textBox14.Text = textBox14.Text + ".";
                        textBox14.Select(textBox14.Text.Length, 0);
                    }
                    if (textBox14.TextLength == 11)
                    {
                        textBox14.Text = textBox14.Text + "-";
                        textBox14.Select(textBox14.Text.Length, 0);
                    }
                    if (textBox14.TextLength == 14)
                    {
                        string temp = Ferramentas.Retira_Meta(textBox14.Text);
                        bool teste = Ferramentas.IsCpf(temp);
                        if (teste == false)
                        {
                            MessageBox.Show("CPF em formato incorreto");
                            textBox14.Text = "";
                            textBox14.Focus();
                            
                        }
                        if (teste == true)
                        {
                            textBox13.Focus();
                            
                        }
                    }

                }
            }
            if (checkBox2.Checked == false)
            {
                if (checkBox7.Checked == true)
                {
                        if (textBox14.TextLength == 2)
                        {
                            textBox14.Text = textBox14.Text + ".";
                            textBox14.Select(textBox14.Text.Length, 0);
                        }
                        if (textBox14.TextLength == 6)
                        {
                            textBox14.Text = textBox14.Text + ".";
                            textBox14.Select(textBox14.Text.Length, 0);
                        }
                        if (textBox14.TextLength == 10)
                        {
                            textBox14.Text = textBox14.Text + "/";
                            textBox14.Select(textBox14.Text.Length, 0);
                        }
                        if (textBox14.TextLength == 15)
                        {
                            textBox14.Text = textBox14.Text + "-";
                            textBox14.Select(textBox14.Text.Length, 0);
                        }
                        if (textBox14.TextLength == 18)
                        {

                            string temp = Ferramentas.Retira_Meta(textBox14.Text);
                            bool teste = Ferramentas.IsCnpj(temp);
                            if (teste == false)
                            {
                                MessageBox.Show("CNPJ em formato incorreto");
                                textBox14.Text = "";
                                textBox14.Focus();
                                
                            }
                            if (teste == true)
                            {
                                textBox13.Focus();
                            }
                        }
                }
            }  
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
             

            Application.Exit();
        }
    }
 }
