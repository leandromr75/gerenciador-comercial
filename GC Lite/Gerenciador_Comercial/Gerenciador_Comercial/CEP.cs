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
    public partial class CEP : Form
    {
        public CEP()
        {
            InitializeComponent();
        }

        private void CEP_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(new Uri("http://www.buscacep.correios.com.br"));
        }
    }
}
