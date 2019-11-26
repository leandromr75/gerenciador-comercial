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
    public partial class SenhaBD : Form
    {
        public SenhaBD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                if (textBox1.Text == "#lecoteco1975")
                {
                    Global.Margem.senhaSA = textBox1.Text;
                    this.Close();
                }
                else
                {
                    label1.Text = "Senha incorreta";
                    
                    
                    
                }
            }
            else
            {
                label1.Text = "Campo senha vazio";
                
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
