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
    public partial class COFINSQtde : Form
    {
        public COFINSQtde()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) == false)
            {
                XML_SAT.CST_COFINSQtde = textBox1.Text;
                XML_SAT.vAliqProd_COFINSQtde = textBox2.Text;
                GlobalSAT.ImpostoOK = "ok";
                this.Close();
            }
            else
            {
                MessageBox.Show("Campo obrigatório não preenchido");
                textBox2.Focus();
            }
        }

        private void COFINSQtde_Load(object sender, EventArgs e)
        {
            textBox2.Focus();
        }
    }
}
