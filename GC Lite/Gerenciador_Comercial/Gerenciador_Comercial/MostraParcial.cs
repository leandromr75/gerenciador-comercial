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
    public partial class MostraParcial : Form
    {
        public MostraParcial()
        {
            InitializeComponent();
        }

        private void MostraParcial_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.ListaParcial(Global.Margem.ClienteFiado);
        }
    }
}
