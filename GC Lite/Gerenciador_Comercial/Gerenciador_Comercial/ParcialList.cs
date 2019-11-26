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
    public partial class ParcialList : Form
    {
        public ParcialList()
        {
            InitializeComponent();
        }

        private void ParcialList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.ParcialLista(Global.Margem.CaixaSelecionado);
        }
    }
}
