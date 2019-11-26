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
    public partial class ICMSselecao : Form
    {
        public ICMSselecao()
        {
            InitializeComponent();
        }

        private void ICMSselecao_Load(object sender, EventArgs e)
        {
            if (GlobalSAT.TributaçãoICMS == "00")
            {
                textBox2.ReadOnly = false;                
            }
            if (GlobalSAT.TributaçãoICMS == "20")
            {
                textBox2.ReadOnly = false;
            }
            if (GlobalSAT.TributaçãoICMS == "90" || GlobalSAT.TributaçãoICMS == "900")
            {
                textBox2.ReadOnly = false;
            }
            if (GlobalSAT.TributaçãoICMS == "40")
            {

            }
            if (GlobalSAT.TributaçãoICMS == "41")
            {

            }
            if (GlobalSAT.TributaçãoICMS == "50")
            {

            }
            if (GlobalSAT.TributaçãoICMS == "60")
            {

            }
            if (GlobalSAT.TributaçãoICMS == "102")
            {

            }
            if (GlobalSAT.TributaçãoICMS == "300")
            {

            }
            if (GlobalSAT.TributaçãoICMS == "500")
            {

            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (GlobalSAT.TributaçãoICMS == "900")
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false)
                {
                    XML_SAT.Orig_ICMSSN900 = textBox1.Text;
                    XML_SAT.CSOSN_ICMSSN900 = GlobalSAT.TributaçãoICMS;
                    XML_SAT.pICMS_ICMSSN900 = textBox2.Text;
                    GlobalSAT.ImpostoOK = "ok";
                    this.Close();
                }
                if (String.IsNullOrEmpty(textBox1.Text) == true || String.IsNullOrEmpty(textBox2.Text) == true)
                {
                    MessageBox.Show("Campo obrigatório não preenchido");
                    return;
                }
            }
            if (GlobalSAT.TributaçãoICMS == "00" || GlobalSAT.TributaçãoICMS == "20" || GlobalSAT.TributaçãoICMS == "90" )
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false)
                {
                    
                    XML_SAT.Orig_ICMS00 = textBox1.Text;
                    XML_SAT.CST_ICMS00 = GlobalSAT.TributaçãoICMS;
                    XML_SAT.pICMS00 = textBox2.Text;
                    
                    
                    GlobalSAT.ImpostoOK = "ok";
                    this.Close();
                }
                if (String.IsNullOrEmpty(textBox1.Text) == true || String.IsNullOrEmpty(textBox2.Text) == true)
                {
                    MessageBox.Show("Campo obrigatório não preenchido");
                    return;
                }

                
            }
            if (GlobalSAT.TributaçãoICMS == "40" || GlobalSAT.TributaçãoICMS == "41" || GlobalSAT.TributaçãoICMS == "50" || 
                    GlobalSAT.TributaçãoICMS == "60")
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false )
                {
                    XML_SAT.Orig_ICMS40 = textBox1.Text;
                    XML_SAT.CST_ICMS40 = GlobalSAT.TributaçãoICMS;
                    GlobalSAT.ImpostoOK = "ok";
                    this.Close();
                }
                if (String.IsNullOrEmpty(textBox1.Text) == true )
                {
                    MessageBox.Show("Campo obrigatório não preenchido");
                    return;
                }
            }
            if (GlobalSAT.TributaçãoICMS == "102" || GlobalSAT.TributaçãoICMS == "300" || GlobalSAT.TributaçãoICMS == "500" )
            {
                if (String.IsNullOrEmpty(textBox1.Text) == false)
                {
                    XML_SAT.Orig_ICMSSN102 = textBox1.Text;
                    XML_SAT.CSOSN_ICMSSN102 = GlobalSAT.TributaçãoICMS;
                    GlobalSAT.ImpostoOK = "ok";
                    this.Close();
                }
                if (String.IsNullOrEmpty(textBox1.Text) == true)
                {
                    MessageBox.Show("Campo obrigatório não preenchido");
                    return;
                }
            }
            
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;\n\n" +
            "1 - Estrangeira - Importação direta, exceto a indicada no código 6; 2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;\n\n" +
            "3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% (quarenta por cento) e inferior ou igual a 70% (setenta por cento);\n\n" +
            "4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as legislações citadas nos Ajustes;\n\n" +
            "5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;\n\n" +
            "6 - Estrangeira - Importação direta, sem similar nacional,constante em lista da CAMEX;\n\n" +
            "7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante em lista da CAMEX;\n\n" +
            "8 – Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70% (setenta por cento).");
        }
    }
}
