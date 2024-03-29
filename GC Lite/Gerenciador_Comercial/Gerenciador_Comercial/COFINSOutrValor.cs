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
    public partial class COFINSOutrValor : Form
    {
        public COFINSOutrValor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false)
            {
                XML_SAT.QBCProd_COFINSOutr = textBox1.Text;
                XML_SAT.vAliqProd_COFINSOutr = textBox2.Text;
                GlobalSAT.ImpostoOK = "ok";
                this.Close();
            }
            else
            {
                MessageBox.Show("Campos obrigatórios não preenchidos");
            }
        }

        private void COFINSOutrValor_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
