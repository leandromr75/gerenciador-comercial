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
    public partial class HistoricoComprasFiado : Form
    {
        public HistoricoComprasFiado()
        {
            InitializeComponent();
        }

        private void HistoricoComprasFiado_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.FluxoVendaFiadoMov(Global.Margem.ClienteFiado);
        }
    }
}
