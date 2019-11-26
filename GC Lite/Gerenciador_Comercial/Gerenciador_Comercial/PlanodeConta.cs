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
    public partial class PlanodeConta : Form
    {
        public PlanodeConta()
        {
            InitializeComponent();
        }

        private void PlanodeConta_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "DESPESAS ADMINISTRATIVAS";
            dataGridView1.DataSource = DALCadastro.ListaPlanoDeContas();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                Global.Margem.PlanoDeConta = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
