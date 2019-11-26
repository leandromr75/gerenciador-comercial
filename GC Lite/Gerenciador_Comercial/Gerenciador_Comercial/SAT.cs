using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Gerenciador_Comercial
{
    public partial class SAT : Form
    {
        public SAT()
        {
            InitializeComponent();
        }
        //Int32 numsess = 000001;
        
        
        private void button2_Click(object sender, EventArgs e)
        {
            
            if (pictureBox11.Visible == true && pictureBox12.Visible == true && pictureBox13.Visible == true && pictureBox14.Visible == true && 
                pictureBox15.Visible == true  )
            {
                if (String.IsNullOrEmpty(textBox5.Text) == false && String.IsNullOrEmpty(textBox8.Text) == false)
                {
                    XML_SAT.cProd = Global.Margem.IdProdSAT;
                    XML_SAT.cEAN = textBox2.Text;
                    XML_SAT.xProd = textBox3.Text;
                    XML_SAT.NCM = textBox4.Text;
                    XML_SAT.CFOP = textBox5.Text;
                    XML_SAT.uCom = textBox6.Text;
                    XML_SAT.vItem12741 = textBox9.Text;
                    XML_SAT.indRegra = textBox8.Text;
                    if (Global.Margem.EditaSAT == "sim")
                    {

                        string message = "As informações fiscais SAT CFe serão atualizadas.\nDeseja continuar?";
                        string caption = "Atualizar informações";
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;

                        // Displays the MessageBox.

                        result = MessageBox.Show(this, message, caption, buttons,
                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                        
                        if (result == DialogResult.Yes)
                        {
                            //deletar registro
                            DALCadastro.DeletaSAT(Convert.ToInt32(Global.Margem.IdProdSAT));

                            CadastrarProdutoSAT cad = new CadastrarProdutoSAT();
                            cad.InsereSATCadastro();

                            DataTable esat = DALCadastro.VerificaSAT(Convert.ToInt32(Global.Margem.IdProdSAT));
                            if (esat.Rows.Count == 1)
                            {
                                MessageBox.Show("Cadastro concluído com sucesso.\nItem cProd = " + Global.Margem.IdProdSAT);
                                this.Close();
                                
                            }

                        }
                       
                        
                    }
                    if (Global.Margem.EditaSAT == "")
                    {
                        
                        DataTable esat1 = DALCadastro.VerificaSAT(Convert.ToInt32(Global.Margem.IdProdSAT));
                        if (esat1.Rows.Count == 1)
                        {
                            string message = "Já existe cadastro SAT CFe para este item.\nDeseja editar informações?";
                            string caption = "Cadastro Existente";
                            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                            DialogResult result;

                            // Displays the MessageBox.

                            result = MessageBox.Show(this, message, caption, buttons,
                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);


                            if (result == DialogResult.Yes)
                            {
                                DALCadastro.DeletaSAT(Convert.ToInt32(Global.Margem.IdProdSAT));
                                                                
                            }
                            if (result == DialogResult.No)
                            {
                                return;
                            }
                        }

                        
                         CadastrarProdutoSAT cad = new CadastrarProdutoSAT();
                         cad.InsereSATCadastro();

                         DataTable esat = DALCadastro.VerificaSAT(Convert.ToInt32( Global.Margem.IdProdSAT ));
                         if (esat.Rows.Count == 1)
                         {
                             MessageBox.Show("Cadastro concluído com sucesso.\nItem cProd = " + Global.Margem.IdProdSAT);
                             this.Close();
                         }
                        
                    }
                    
                    
                }
                else
                {
                    MessageBox.Show("Campos obrigatórios não preenchidos");
                }
            }
            else
            {
                MessageBox.Show("Campos obrigatórios não preenchidos");
            }

            Global.Margem.EditaSAT = "";
          

            
        }

        
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobalSAT.TributaçãoICMS = comboBox1.Text;
            if (comboBox1.Text == "00 - Tributada integralmente")
            {
                GlobalSAT.TributaçãoICMS = "00";
            }
            if (comboBox1.Text == "20 - Com redução de base de cálculo")
            {
                GlobalSAT.TributaçãoICMS = "20";
            }
            if (comboBox1.Text == "90 - Outros")
            {
                GlobalSAT.TributaçãoICMS = "90";
            }
            if (comboBox1.Text == "40 - Isenta")
            {
                GlobalSAT.TributaçãoICMS = "40";

            }
            if (comboBox1.Text == "41 - Não tributada")
            {
                GlobalSAT.TributaçãoICMS = "41";
            }
            if (comboBox1.Text == "50 - Suspensão")
            {
                GlobalSAT.TributaçãoICMS = "50";
            }
            if (comboBox1.Text == "60 - ICMS cobrado anteriormente por substituição tributária")
            {
                GlobalSAT.TributaçãoICMS = "60";
            }
            if (comboBox1.Text == "102 - Simples Nacional - sem permissão de crédito")
            {
                GlobalSAT.TributaçãoICMS = "102";
            }
            if (comboBox1.Text == "300 - Simples Nacional - Imune")
            {
                GlobalSAT.TributaçãoICMS = "300";
            }
            if (comboBox1.Text == "500 - Simples Nacional -  ICMS cobrado anteriormente por substituição tributária.")
            {
                GlobalSAT.TributaçãoICMS = "500";
            }
            if (comboBox1.Text == "900 - Simples Nacional - Outros")
            {
                GlobalSAT.TributaçãoICMS = "900";
            }
            Form icmsselec = new ICMSselecao();
            icmsselec.ShowDialog();
            if (GlobalSAT.ImpostoOK == "ok")
            {
                pictureBox11.Visible = true;
                GlobalSAT.ImpostoOK = "";
                comboBox2.Focus();
            }

            
        }

       

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Não Tributado")
            {

                GlobalSAT.PIS = "PISNT";
                Form pisnt = new PISNT();
                pisnt.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox12.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox3.Focus();
                }
                
                
            }
            if (comboBox2.Text == "Alíquota")
            {
                GlobalSAT.PIS = "PISAliq";
                Form pisaliq = new PISAliq();
                pisaliq.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox12.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox3.Focus();
                }


            }
            if (comboBox2.Text == "Quantidade")
            {
                GlobalSAT.PIS = "PISQtde";
                Form pisqtde = new PISQtde();
                pisqtde.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox12.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox3.Focus();
                }

            }
            if (comboBox2.Text == "Simples Nacional")
            {
                XML_SAT.CST_PIS_PISSN = "49";
                GlobalSAT.PIS = "PISSN";
                pictureBox12.Visible = true;
                comboBox3.Focus();

            }
            if (comboBox2.Text == "Outras Operações")
            {
                XML_SAT.CST_PIS_PISOutr = "99";
                //GlobalSAT.PIS = "PISOutr";
                Form pisoutrSelec = new OutrPISSelect();
                pisoutrSelec.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox12.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox3.Focus();
                }
            }

        }

        private void SAT_Load(object sender, EventArgs e)
        {
            DataTable sat = DALCadastro.listaProdutos(Convert.ToInt32(Global.Margem.IdProdSAT));
            if (sat.Rows.Count > 0 )
            {
                if (String.IsNullOrEmpty(sat.Rows[0]["IdProd"].ToString()) == false )
                {
                    textBox1.Text = sat.Rows[0]["IdProd"].ToString();
                    textBox1.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Campo referência não cadastrado");
                    this.Close();
                }
                if (String.IsNullOrEmpty(sat.Rows[0]["CodEAN"].ToString()) == false)
                {
                    textBox2.Text = sat.Rows[0]["CodEAN"].ToString();
                    textBox2.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Campo EAN (código de barras) não cadastrado.\nA informação do código EAN será suprimida do XML SAT");
                    
                }
                if (String.IsNullOrEmpty(sat.Rows[0]["DescInterna"].ToString()) == false)
                {
                    textBox3.Text = sat.Rows[0]["DescInterna"].ToString();
                    textBox3.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Campo Descrição Interna não cadastrado");
                    this.Close();
                }
                if (String.IsNullOrEmpty(sat.Rows[0]["CF_NCM"].ToString()) == false)
                {
                    textBox4.Text = sat.Rows[0]["CF_NCM"].ToString();
                    textBox4.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Campo NCM não cadastrado");
                    this.Close();
                }
                if (String.IsNullOrEmpty(sat.Rows[0]["Unidade"].ToString()) == false)
                {
                    textBox6.Text = sat.Rows[0]["Unidade"].ToString();
                    textBox6.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Campo Unidade não cadastrado");
                    this.Close();
                }
                if (String.IsNullOrEmpty(sat.Rows[0]["ValorVenda"].ToString()) == false)
                {
                    textBox7.Text = sat.Rows[0]["ValorVenda"].ToString();
                    textBox7.ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("Campo Valor Unitário não cadastrado");
                    this.Close();
                }
                textBox5.Focus();

                
            }
            else
            {
                MessageBox.Show("Não foi possível localizar cadastro do Produto");
                this.Close();
            }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            pictureBox11.Visible = false;
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            pictureBox12.Visible = false;
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            pictureBox13.Visible = false;
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Aliquota em Percentual")
            {
                GlobalSAT.PISST = "Percentual";
                Form pistPerc = new PISSTPercentual();
                pistPerc.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox13.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox4.Focus();
                }

            }
            if (comboBox3.Text == "Aliquota em Valor")
            {
                GlobalSAT.PISST = "Valor";
                Form pisstValor = new PISSTValor();
                pisstValor.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox13.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox4.Focus();
                }

            }
        }

        private void comboBox4_Click(object sender, EventArgs e)
        {
            pictureBox14.Visible = false;
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Não Tributado")
            {

                GlobalSAT.COFINS = "COFINSNT";
                Form cofinssnt = new COFINSNT();
                cofinssnt.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox14.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox5.Focus();
                }


            }
            if (comboBox4.Text == "Alíquota")
            {
                GlobalSAT.COFINS = "COFINSAliq";
                Form cofinsliq = new COFINSAliq();
                cofinsliq.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox14.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox5.Focus();
                }


            }
            if (comboBox4.Text == "Quantidade")
            {
                GlobalSAT.COFINS = "COFINSQtde";
                Form cofinsqtde = new COFINSQtde();
                cofinsqtde.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox14.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox5.Focus();
                }

            }
            if (comboBox4.Text == "Simples Nacional")
            {
                XML_SAT.CST_COFINSSN = "49";
                GlobalSAT.COFINS = "COFINSSN";
                pictureBox14.Visible = true;
                comboBox5.Focus();

            }
            if (comboBox4.Text == "Outras Operações")
            {
                XML_SAT.CST_COFINSOutr = "99";
                //GlobalSAT.COFINS = "COFINSOutr";
                Form cofinssoutrSelec = new OutrCOFINSSelect();
                cofinssoutrSelec.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox14.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    comboBox5.Focus();
                }
            }
        }

        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox5.Text == "Aliquota em Percentual")
            {
                GlobalSAT.COFINSST = "Percentual";
                Form cofinsstPerc = new COFINSSTPercentual();
                cofinsstPerc.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox15.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    button2.Focus();
                }

            }
            if (comboBox5.Text == "Aliquota em Valor")
            {
                GlobalSAT.COFINSST = "Valor";
                Form cofinsstValor = new COFINSSTValor();
                cofinsstValor.ShowDialog();
                if (GlobalSAT.ImpostoOK == "ok")
                {
                    pictureBox15.Visible = true;
                    GlobalSAT.ImpostoOK = "";
                    button2.Focus();
                }

            }
        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            pictureBox15.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }
    }
}
