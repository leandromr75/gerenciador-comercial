﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class AUXCadFinalidade : Form
    {
        public AUXCadFinalidade()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.ReadOnly == false && String.IsNullOrEmpty(textBox1.Text) == false )
            {
                bool jaexiste = false;
                bool controle = false;

                if (dataGridView1.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        if (controle == false)
                        {
                            if (textBox1.Text == dataGridView1.Rows[i].Cells[1].Value.ToString())
                            {
                                MessageBox.Show("Já existe este cadastro!");
                                jaexiste = true;
                            }
                        }

                    }
                }
                if (jaexiste == false)
                {
                    string Stored = "CriarCadFinalidade";

                    DALCadastro.AUXCadCriar(Stored, textBox1.Text);
                    dataGridView1.DataSource = DALCadastro.AUXCadListar("Listar_Finalidade");
                    textBox1.ReadOnly = true;
                    textBox1.Text = "";
                    label3.Text = "";
                }
            }
            
            
        }

        private void AUXCadFinalidade_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALCadastro.AUXCadListar("Listar_Finalidade");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && textBox1.ReadOnly == true && textBox1.Text != "SELECIONAR")
            {
                string resul = Convert.ToString(DALCadastro.ProcuraAUXCad("ExcluiCadAUXFinalidade", textBox1.Text));
                if (String.IsNullOrEmpty(resul) == false)
                {
                    MessageBox.Show("Descrição não pode ser excluída, porque existem produtos cadastrados que a utilizam");
                    textBox1.Text = "";
                    textBox1.ReadOnly = true;
                    label3.Text = "";
                }
                if (String.IsNullOrEmpty(resul) == true)
                {
                    string message = "Você deseja excluír ==> " + textBox1.Text;
                    string caption = "Exclusão";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    // Mostra a MessageBox.

                    result = MessageBox.Show(this, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                    if (result == DialogResult.Yes)
                    {
                        DALCadastro.ExcluiCadAUX("ExcluiFinalidade", label3.Text);
                        dataGridView1.DataSource = DALCadastro.AUXCadListar("Listar_Finalidade");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um registro para exclusão");
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox1.ReadOnly = true;
                textBox1.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                label3.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label3.Text = "";
            textBox1.ReadOnly = false;
            textBox1.Focus();
        }
    }
}