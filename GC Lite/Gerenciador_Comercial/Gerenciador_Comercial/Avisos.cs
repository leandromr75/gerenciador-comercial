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
    public partial class Avisos : Form
    {
        public Avisos()
        {
            InitializeComponent();
        }

        private void Avisos_Load(object sender, EventArgs e)
        {
            string dia = DateTime.Now.Day.ToString();
            if (dia.Length == 1)
            {
                dia = "0" + dia;
            }
            string mes = DateTime.Now.Month.ToString();
            if (mes.Length == 1)
            {
                mes = "0" + mes;
            }
            string ano = DateTime.Now.Year.ToString();
            int compara = Convert.ToInt32(ano + mes + dia);
            DataTable list = DALCadastro.ListaEventos();
            if (list.Rows.Count > 0)
            {
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    int temp = Convert.ToInt32(list.Rows[i]["DataGatilho"].ToString());
                    if (temp <= compara)
                    {
                        richTextBox1.Text += "#   Produto  || " + list.Rows[i]["Descrição"].ToString() + " || " + list.Rows[i]["Qtde"].ToString() + "\n"; 
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Global.Margem.AbreAviso = "ok";
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Você deseja limpar lista de avisos?";
            string caption = "Limpar";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(this, message, caption, buttons,
            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                string dia = DateTime.Now.Day.ToString();
                if (dia.Length == 1)
                {
                    dia = "0" + dia;
                }
                string mes = DateTime.Now.Month.ToString();
                if (mes.Length == 1)
                {
                    mes = "0" + mes;
                }
                string ano = DateTime.Now.Year.ToString();
                int compara = Convert.ToInt32(ano + mes + dia);
                DataTable list = DALCadastro.ListaEventos();
                if (list.Rows.Count > 0)
                {
                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        int temp = Convert.ToInt32(list.Rows[i]["DataGatilho"].ToString());
                        if (temp <= compara)
                        {
                            DALCadastro.criarEventoHistorico(list.Rows[i]["EventoTipo"].ToString(),
                                list.Rows[i]["IdProd"].ToString(),
                                list.Rows[i]["Descrição"].ToString(),
                                list.Rows[i]["DataGatilho"].ToString(), list.Rows[i]["Qtde"].ToString());

                            DALCadastro.DeletaEventos(Convert.ToInt32(list.Rows[i]["IdEvento"].ToString()));
                        }
                    }

                }
                MessageBox.Show("Avisos excluídos com sucesso.");
                richTextBox1.Text = "";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            DataTable list = DALCadastro.ListaEventosHistorico();
            if (list.Rows.Count > 0)
            {
                for (int i = 0; i < list.Rows.Count; i++)
                {
                    
                        richTextBox1.Text += "#   Produto  || " + list.Rows[i]["Descrição"].ToString() + " || " + list.Rows[i]["Qtde"].ToString() + "\n";
                    
                }
            }
        }
    }
}
