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
    public partial class COFINSNT : Form
    {
        public COFINSNT()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("04 - Operação Tributável (tributação monofásica (alíquota zero));\n\n" +
                "06 - Operação Tributável (alíquota zero);\n\n" + "07 - Operação Isenta da Contribuição;\n\n" +
                "08 - Operação Sem Incidência da Contribuição;\n\n" + "09 - Operação com Suspensão da Contribuição;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                XML_SAT.CST_COFINSNT = textBox1.Text;
                GlobalSAT.ImpostoOK = "ok";
                this.Close();
            }
            else
            {
                MessageBox.Show("Campo obrigatório não preenchido");
                textBox1.Focus();
            }
        }

        private void COFINSNT_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
