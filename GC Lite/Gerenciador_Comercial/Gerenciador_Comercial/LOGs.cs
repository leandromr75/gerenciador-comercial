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
    public partial class LOGs : Form
    {
        public LOGs()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
            

            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form filtro = new FiltroLog();
            filtro.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form formPrincipal = new TelaPrincipal();
            //Faz a chamada ao gerenciador de formulário
            GerenciadorDeFormulario.Abre(formPrincipal);
            GerenciadorDeFormulario.Fecha(this);
        }

        private void LOGs_Load(object sender, EventArgs e)
        {
            this.Text = "[LOGs do Sistema. Operador ==> " + Global.Margem.Operador + "]"; 
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            string dia = monthCalendar1.SelectionStart.Day.ToString();
            if (dia.Length < 2)
            {
                dia = "0" + dia;
            }
            string mes = monthCalendar1.SelectionStart.Month.ToString();
            if (mes.Length < 2)
	        {
		        mes = "0" + mes;
	        }
            string ano = monthCalendar1.SelectionStart.Year.ToString();
            label8.Text = dia + "/" + mes + "/" +  ano;
        }

        private void LOGs_Load_1(object sender, EventArgs e)
        {
            this.Text = "[LOGs do Sistema. Operador ==> " + Global.Margem.Operador + "]";
            comboBox1.DataSource = DALCadastro.ListaUsrSistemaEdita();
            comboBox1.ValueMember = "Nome";
            comboBox1.DisplayMember = "Nome";
            comboBox1.SelectedItem = "";
            comboBox1.Refresh();
            string dia = monthCalendar1.SelectionStart.Day.ToString();
            if (dia.Length < 2)
            {
                dia = "0" + dia;
            }
            string mes = monthCalendar1.SelectionStart.Month.ToString();
            if (mes.Length < 2)
	        {
		        mes = "0" + mes;
	        }
            string ano = monthCalendar1.SelectionStart.Year.ToString();
            label8.Text = dia + "/" + mes + "/" +  ano;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty ( comboBox1.Text ) == false)
            {
                dataGridView1.DataSource = DALCadastro.ListaLog(comboBox1.Text);
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox1.Text) == false && String.IsNullOrEmpty(label8.Text) == false )
            {
                string temp1 = label8.Text.Replace("/","");
                string dia = temp1.Substring(0,2);
                string mes = temp1.Substring(2,2);
                string ano = temp1.Substring(4,4);
                string data = ano + mes + dia;
                int temp = Convert.ToInt32(data);
                string mod = "";
                if (comboBox2.Text == "Configurações do Sistema")
                {
                    mod = "config";
                }
                if (comboBox2.Text == "Cadastro de Participantes")
                {
                    mod = "CadParticipantes";
                }
                if (comboBox2.Text == "Cadastro de Produtos")
                {
                    mod = "CadProdutos";
                }
                if (comboBox2.Text == "Cadastro de Usuários")
                {
                    mod = "CadUsuarios";
                }
                if (comboBox2.Text == "Fluxo de Caixa")
                {
                    mod = "FluxoCaixa";
                }
                if (comboBox2.Text == "Caixa/Terminal de Vendas")
                {
                    mod = "CaixaTerminalVendas";
                }
                if (comboBox2.Text == "Contas a Receber")
                {
                    mod = "ContasReceber";
                }
                if (comboBox2.Text == "LOGs Sistema")
                {
                    mod = "LOG";
                }
                if (checkBox1.Checked == false)
                {
                    dataGridView1.DataSource = DALCadastro.ListaLogAnterior(temp, comboBox1.Text, mod);
                }
                if (checkBox1.Checked == true)
                {
                    dataGridView1.DataSource = DALCadastro.ListaLogAnteriorTudo(temp, comboBox1.Text);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox1.Text) == false && String.IsNullOrEmpty(label8.Text) == false)
            {
                string temp1 = label8.Text.Replace("/", "");
                string dia = temp1.Substring(0, 2);
                string mes = temp1.Substring(2, 2);
                string ano = temp1.Substring(4, 4);
                string data = ano + mes + dia;
                int temp = Convert.ToInt32(data);
                string mod = "";
                if (comboBox2.Text == "Configurações do Sistema")
                {
                    mod = "config";
                }
                if (comboBox2.Text == "Cadastro de Participantes")
                {
                    mod = "CadParticipantes";
                }
                if (comboBox2.Text == "Cadastro de Produtos")
                {
                    mod = "CadProdutos";
                }
                if (comboBox2.Text == "Cadastro de Usuários")
                {
                    mod = "CadUsuarios";
                }
                if (comboBox2.Text == "Fluxo de Caixa")
                {
                    mod = "FluxoCaixa";
                }
                if (comboBox2.Text == "Caixa/Terminal de Vendas")
                {
                    mod = "CaixaTerminalVendas";
                }
                if (comboBox2.Text == "Contas a Receber")
                {
                    mod = "ContasReceber";
                }
                if (comboBox2.Text == "LOGs Sistema")
                {
                    mod = "LOG";
                }
                if (checkBox1.Checked == false)
                {
                     dataGridView1.DataSource = DALCadastro.ListaLogPosterior(temp, comboBox1.Text, mod);
                }
                if (checkBox1.Checked == true)
                {
                    dataGridView1.DataSource = DALCadastro.ListaLogPosteriorTudo(temp, comboBox1.Text);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox1.Text) == false && String.IsNullOrEmpty(label8.Text) == false)
            {
                string temp1 = label8.Text.Replace("/", "");
                string dia = temp1.Substring(0, 2);
                string mes = temp1.Substring(2, 2);
                string ano = temp1.Substring(4, 4);
                string data = ano + mes + dia;
                int temp = Convert.ToInt32(data);
                string mod = "";
                if (comboBox2.Text == "Configurações do Sistema")
                {
                    mod = "config";
                }
                if (comboBox2.Text == "Cadastro de Participantes")
                {
                    mod = "CadParticipantes";
                }
                if (comboBox2.Text == "Cadastro de Produtos")
                {
                    mod = "CadProdutos";
                }
                if (comboBox2.Text == "Cadastro de Usuários")
                {
                    mod = "CadUsuarios";
                }
                if (comboBox2.Text == "Fluxo de Caixa")
                {
                    mod = "FluxoCaixa";
                }
                if (comboBox2.Text == "Caixa/Terminal de Vendas")
                {
                    mod = "CaixaTerminalVendas";
                }
                if (comboBox2.Text == "Contas a Receber")
                {
                    mod = "ContasReceber";
                }
                if (comboBox2.Text == "LOGs Sistema")
                {
                    mod = "LOG";
                }
                if (checkBox1.Checked == false)
                {
                    dataGridView1.DataSource = DALCadastro.ListaLogIgual(temp, comboBox1.Text, mod);
                }
                if (checkBox1.Checked == true)
                {
                    dataGridView1.DataSource = DALCadastro.ListaLogIgualTudo(temp, comboBox1.Text);
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Global.Margem.Logs == "adm")
            {
                string message = "Você deseja Excluír Todos os Registros de LOGs?";
                string caption = "Exclusão";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Mostra a MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    dataGridView1.DataSource = DALCadastro.DeletarLogs();
                    if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                    {
                        Ferramentas.CriaLog("LOG", "Excluiu todos os LOGs do Sistema");
                    }
                }
            }
        }
        

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = System.Drawing.Color.Red;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = System.Drawing.Color.Black;
        }
    }
}
