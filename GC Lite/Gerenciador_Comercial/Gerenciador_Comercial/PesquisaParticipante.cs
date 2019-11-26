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
    public partial class PesquisaParticipante : Form
    {
        public PesquisaParticipante()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sum = Convert.ToInt32(textBox2.Text);
            if (sum <= 10000)
            {
                sum = sum + 200;
                textBox2.Text = Convert.ToString(sum);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = Convert.ToInt32(textBox2.Text);
            if (sum >= 200)
            {
                sum = sum - 200;
                textBox2.Text = Convert.ToString(sum);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Visible = true;
            button4.Visible = true;
            label2.Visible = true;
            if (dataGridView1.Rows.Count > 0)
            {
                label2.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
                
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                Global.Margem.semaforoPartInt = label2.Text;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked == true)
            {
                Global.Margem.Situação = "Ativo";
            }
            if (checkBox3.Checked == true)
            {
                Global.Margem.Situação = "SPC";
            }
            if (checkBox4.Checked == true)
            {
                Global.Margem.Situação = "Inativo";
            }
            if (checkBox1.Checked == false)
            {
                textBox1.Text = Ferramentas.Retira_Meta(textBox1.Text);
                dataGridView1.DataSource = DALCadastro.VerificaParticipante1(textBox1.Text, Global.Margem.Situação);
                Global.Margem.Situação = "";
            }
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox3.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkBox2.Checked = false;
                checkBox4.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                checkBox3.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Text = Ferramentas.Retira_Meta(textBox1.Text);
                string sum = textBox1.Text + "%";
                dataGridView1.DataSource = DALCadastro.VerificaParticipante2(sum);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox2.Visible = false;
                checkBox4.Visible = false;
                checkBox3.Visible = false;
            }
            if (checkBox1.Checked == false)
            {
                checkBox2.Visible = true;
                checkBox4.Visible = true;
                checkBox3.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                if (checkBox2.Checked == true)
                {
                    Global.Margem.Situação = "Ativo";
                }
                if (checkBox3.Checked == true)
                {
                    Global.Margem.Situação = "SPC";
                }
                if (checkBox4.Checked == true)
                {
                    Global.Margem.Situação = "Inativo";
                }
                dataGridView1.DataSource = DALCadastro.VerificaParticipante3(textBox2.Text, textBox4.Text, Global.Margem.Situação);
                Global.Margem.Situação = "";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int sum = Convert.ToInt32(textBox4.Text);
            if (sum <= 9000)
            {
                sum = sum + 200;
                textBox4.Text = Convert.ToString(sum);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int sum = Convert.ToInt32(textBox4.Text);
            if (sum >= 200)
            {
                sum = sum - 200;
                textBox4.Text = Convert.ToString(sum);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.VerificaParticipante4();
        }
    }
}
