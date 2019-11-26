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
    public partial class VerificaParticipante : Form
    {
        public VerificaParticipante()
        {
            InitializeComponent();
        }

        private void VerificaParticipante_Load(object sender, EventArgs e)
        {
            this.Text += " ==> " + Global.Margem.AchaNomePart;
            dataGridView1.DataSource = DALCadastro.VerificaParticipante(Global.Margem.AchaNomePart);


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                label1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[7].FormattedValue.ToString();
                label2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Deseja editar este cadastro?";
            string caption = "Editar Cadastro";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                Global.Margem.semaforoPart = "ok";
                Global.Margem.semaforoPartInt = label1.Text;
                this.Close();
            }
        }
    }
}
