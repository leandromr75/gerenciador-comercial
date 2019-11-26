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
    public partial class ContasReceber : Form
    {
        public ContasReceber()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            label4.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = System.Drawing.Color.White;
            label4.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            tabControl2.Visible = false;
            Global.Margem.CadastroContasReceber = "salvar";
            Form novoreceber = new ContasReceberNovo();
            novoreceber.ShowDialog();

            tabControl2.Visible = true;
        }

        private void ContasReceber_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Por Número/Título";
            comboBox2.Text = "Procurar Por:";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == true)
            {
                dataGridView1.DataSource = DALCadastro.Lista_Contas_Recebe_Tudor();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text ==  "Títulos (Em Aberto)")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DALCadastro.Lista_Contas_Receber("Em Aberto");
                textBox2.Text = "";
                textBox3.Text = "";
            }
            if (comboBox2.Text == "Títulos (Recebidos)")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DALCadastro.Lista_Contas_Receber("Recebidos");
                textBox2.Text = "";
                textBox3.Text = "";
            }
            if (comboBox2.Text == "Títulos (Vencidos)")
            {
                dataGridView1.DataSource = null;
                string ano = DateTime.Now.Year.ToString();
                string mes = DateTime.Now.Month.ToString();
                string dia = DateTime.Now.Day.ToString();
                if (dia.Length < 2 )
                {
                    dia = "0" + dia;
                }
                if (mes.Length < 2)
                {
                    mes = "0" + mes;
                }
                string tudo = ano + mes + dia;
                int calc = Convert.ToInt32(tudo);
                dataGridView1.DataSource = DALCadastro.Lista_Contas_Receber_Atrasadas(calc);
                textBox2.Text = "";
                textBox3.Text = "";
            }
            if (comboBox2.Text == "Todos os Títulos")
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = DALCadastro.Lista_Contas_Recebe_Tudor();
                textBox2.Text = "";
                textBox3.Text = "";
            }
            if (comboBox2.Text == "Recebimentos (Hoje)")
            {
                dataGridView1.DataSource = null;
               
                string ano = DateTime.Now.Year.ToString();
                string mes = DateTime.Now.Month.ToString();
                string dia = DateTime.Now.Day.ToString();
                if (dia.Length < 2)
                {
                    dia = "0" + dia;
                }
                if (mes.Length < 2)
                {
                    mes = "0" + mes;
                }
                string tudo = ano + mes + dia;
                int calc = Convert.ToInt32(tudo);
                dataGridView1.DataSource = DALCadastro.Lista_Contas_Receber_Hoje(calc);
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (Global.Margem.ContasReceber != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
            {
                Ferramentas.CriaLog("ContasReceber", "Excluiu título :");
            }
            tabControl2.Visible = false;
            Global.Margem.CadastroContasReceber = "baixar";
            Global.Margem.SaldoReceber = textBox2.Text;
            Form novoreceber = new ContasReceberNovo();
            novoreceber.ShowDialog();
            

            tabControl2.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                //this.Text += " Cliente : " + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[4].FormattedValue.ToString();
                //this.Text += " .Título :" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[2].FormattedValue.ToString();
                //this.Text += "/" + dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[3].FormattedValue.ToString();
                
                Global.Margem.IdContasReceber = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                
                decimal sum = 0;
                string temp = "";
                decimal areceber2 = 0;
                string temp2 = "";
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                temp = Convert.ToString(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[6].Value);
                temp = temp.Replace(".",",");
                sum = Convert.ToDecimal(temp);

                temp2 = Convert.ToString(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[7].Value);
                temp2 = temp2.Replace(".",",");
                areceber2 = Convert.ToDecimal(temp) - Convert.ToDecimal(temp2);
                
                //}
                textBox2.Text = Convert.ToString(sum);
                textBox3.Text = Convert.ToString(areceber2);
                Global.Margem.SaldoContasReceber = textBox3.Text;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (Global.Margem.ContasReceber != "adm")
            {
                MessageBox.Show("Acesso não autorizado");                
                return;
            }
            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
            {
                Ferramentas.CriaLog("ContasReceber", "Excluiu título :");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Global.Margem.ContasReceber != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
            {
                Ferramentas.CriaLog("ContasReceber", "Editou título :");
            }
        }
    }
}
