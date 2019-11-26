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
    public partial class Fracionados : Form
    {
        public Fracionados()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fracionados_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.ListaFracionadosBalança();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (String.IsNullOrEmpty(dataGridView1.Rows[i].Cells[3].Value.ToString()) == false)
                    {
                        if (Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value.ToString()) > 0)
                        {
                            decimal tep = Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value.ToString()) / 1000;
                            dataGridView1.Rows[i].Cells[3].Value = Convert.ToString(Math.Round(tep,2) );
                        }    
                    }
                    
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                label3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                if (String.IsNullOrEmpty(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].FormattedValue.ToString()) == false)
                {
                    dataGridView2.DataSource = DALCadastro.FracionadoAlternativo(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[5].FormattedValue.ToString());    
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty( label3.Text ) == false)
            {
                Global.Margem.AbrirFracionado = label3.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Favor selecionar um registro");
            }
        }
    }
}
