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
    public partial class FiadoClientes : Form
    {
        public FiadoClientes()
        {
            InitializeComponent();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            string s = e.KeyData.ToString();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString().Substring(0, 1) == s)
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];

                    }
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form cadFiado = new ClienteFiado();
            cadFiado.ShowDialog();
            dataGridView1.DataSource = DALCadastro.ListaClienteFiado();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false)
            {
                Global.Margem.ClienteFiadoTemp = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Selecione um cliente");
            }
        }

        private void FiadoClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.ListaClienteFiado();
        }
    }
}
