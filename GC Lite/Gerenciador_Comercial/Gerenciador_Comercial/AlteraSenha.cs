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
    public partial class AlteraSenha : Form
    {
        public AlteraSenha()
        {
            InitializeComponent();
        }

        private void AlteraSenha_Load(object sender, EventArgs e)
        {
            label3.Text = Global.Margem.OperadorTemp;
            textBox1.Text = Convert.ToString(DALCadastro.carregaPermissao("CarregaSenha", Convert.ToInt32(Global.Margem.intCadUsr)));
            textBox2.Text = "";
            textBox2.Focus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    if (textBox2.Text != textBox1.Text)
                    {
                        //alterar senha
                        DALCadastro.UserSenhaEdita(Convert.ToInt32( Global.Margem.intCadUsr),textBox2.Text);
                        Global.Margem.editaUsrSist = "ok";
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Repetição da nova senha não confere, \nou nova senha é igual à senha anterior");
                        textBox3.Text = "";
                        textBox3.Focus();
                        return;
                    }
                }       
                
            }
            else
            {
                MessageBox.Show("Campo(s)  não preenchido(s)");
                return;
            }
        }
    }
}
