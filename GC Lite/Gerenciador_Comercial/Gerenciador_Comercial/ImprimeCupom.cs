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
    public partial class ImprimeCupom : Form
    {
        public ImprimeCupom()
        {
            InitializeComponent();
        }
        int num = 0;

        private void ImprimeCupom_Load(object sender, EventArgs e)
        {
            this.Text = " Venda finalizada $$$$$ \n\n" + Global.Margem.Pagamento.ToString();
            label2.Text = "";
            timer1.Enabled = true;
            num = 4;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            num = num - 1;
            label2.Text = Convert.ToString(num);
            if (num == 0)
            {
                timer1.Enabled = false;

                this.Close();
                
                Form frente = new PDV();
                GerenciadorDeFormulario.Abre(frente);
                
            }
        }

        
        
    }
}
