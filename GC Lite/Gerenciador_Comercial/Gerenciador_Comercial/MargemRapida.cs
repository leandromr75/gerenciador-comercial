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
    public partial class MargemRapida : Form
    {
        public MargemRapida()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int qtde;
            if (Int32.TryParse(textBox1.Text.Trim(), out qtde) == false)
            {
                MessageBox.Show("O campo margem aceita somente valores numéricos");
                textBox1.Text = "";
                textBox1.Focus();
                return;

            }
            else
            {
                Global.Margem.MargemPersonalizada = textBox1.Text;
                this.Close();
            }
            
        }
    }
}
