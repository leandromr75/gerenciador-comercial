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
    public partial class Representante : Form
    {
        public Representante()
        {
            InitializeComponent();
        }

        private void Representante_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.CarregaRepresentante();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                Global.Margem.Representante = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                Global.Margem.RepresentanteId = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
