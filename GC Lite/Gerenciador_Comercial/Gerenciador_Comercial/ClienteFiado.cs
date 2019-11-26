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
    public partial class ClienteFiado : Form
    {
        public ClienteFiado()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox12.Text) == false)
            {
                //textBox12.Text = Ferramentas.Retira_Meta(textBox12.Text);
                dataGridView1.DataSource = DALCadastro.VerificaParticipanteFiado(textBox12.Text, "Ativo");    
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                
                textBox12.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
                textBox19.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[16].FormattedValue.ToString();
                textBox7.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[19].FormattedValue.ToString();
                textBox22.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[17].FormattedValue.ToString();
                textBox27.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[14].FormattedValue.ToString();
                textBox26.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[15].FormattedValue.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox12.Text) == false)
            {
                //textBox12.Text = Ferramentas.Retira_Meta(textBox12.Text);

                DataTable cli = DALCadastro.VerificaParticipanteFiado(textBox12.Text, "Ativo");
                if (cli.Rows.Count <= 0)
                {
                    DALCadastro.CadClienteFiado(textBox12.Text, textBox19.Text, textBox22.Text, textBox7.Text, textBox27.Text, textBox26.Text);
                    this.Close();      
                }
                if (cli.Rows.Count > 0)
                {
                    MessageBox.Show("Cadastro já existente");
                    dataGridView1.DataSource = cli;
                }
                  
            }
            
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            if (textBox27.TextLength == 2)
            {


                textBox27.Text = "(" + textBox27.Text + ")";
                textBox27.Select(textBox27.Text.Length, 0);
            }
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            if (textBox26.TextLength == 2)
            {


                textBox26.Text = "(" + textBox26.Text + ")";
                textBox26.Select(textBox26.Text.Length, 0);
            }
        }

        private void ClienteFiado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (String.IsNullOrEmpty(textBox12.Text) == false)
                {
                   // textBox12.Text = Ferramentas.Retira_Meta(textBox12.Text);


                    DataTable cli = DALCadastro.VerificaParticipanteFiado(textBox12.Text, "Ativo");
                    if (cli.Rows.Count <= 0)
                    {
                        DALCadastro.CadClienteFiado(textBox12.Text, textBox19.Text, textBox22.Text, textBox7.Text, textBox27.Text, textBox26.Text);
                        this.Close();
                    }
                    if (cli.Rows.Count > 0)
                    {
                        MessageBox.Show("Cadastro já existente");
                        dataGridView1.DataSource = cli;
                    }
                    
                }
            }
            if (e.KeyCode == Keys.F5)
            {
                if (String.IsNullOrEmpty(textBox12.Text) == false)
                {
                    //textBox12.Text = Ferramentas.Retira_Meta(textBox12.Text);
                    dataGridView1.DataSource = DALCadastro.VerificaParticipanteFiado(textBox12.Text, "Ativo");
                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
