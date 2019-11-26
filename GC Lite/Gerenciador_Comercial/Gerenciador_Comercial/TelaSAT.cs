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
    public partial class TelaSAT : Form
    {
        public TelaSAT()
        {
            InitializeComponent();
        }
        int cont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cont == 0)
            {
                label2.Text = "4 ...";
                
            }
            if (cont == 1)
            {
                label2.Text = "3 ...";
                
            }
            if (cont == 2)
            {
                label2.Text = "2 ...";

            }
            if (cont == 3)
            {
                label2.Text = "1 ...";

            }
            if (cont == 4)
            {
                label2.Text = "0 ...";
                this.Close();
            }
            cont++;
        }

        private void TelaSAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (Global.SAT_Param.Formas_Pagamento_CD != "sim" && Global.SAT_Param.Formas_Pagamento_CC != "sim")
                {
                    Global.Margem.CancelaSAT = "sim";
                    this.Close();    
                }
                
            }
        }
    }
}
