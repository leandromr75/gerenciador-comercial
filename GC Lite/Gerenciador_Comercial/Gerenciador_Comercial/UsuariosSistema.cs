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
    public partial class UsuariosSistema : Form
    {
        public UsuariosSistema()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form formPrincipal = new TelaPrincipal();

            GerenciadorDeFormulario.Abre(formPrincipal);
            GerenciadorDeFormulario.Fecha(this);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form vd = new VisualizaDanfe();
            vd.ShowDialog();
            
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
        }

        private void UsuariosSistema_Load(object sender, EventArgs e)
        {
            DataTable cor = DALCadastro.CoresRetorna(Global.Margem.Operador);
            this.Text += " ==> Operador: " + Global.Margem.Operador;
            DataTable cor10 = DALCadastro.CoresRetorna(Global.Margem.Operador);
            if (cor10.Rows.Count > 0)
            {
                panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["CorMenu"].ToString()));
                panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor2"].ToString()));
            }
            else
            {
                DataTable cor2 = DALCadastro.CoresRetorna("Default");
                if (cor2.Rows.Count > 0)
                {
                    panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["CorMenu"].ToString()));
                    panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor2"].ToString()));
                }
            }               
            
            dataGridView1.DataSource = DALCadastro.ListaUsrSistemaEdita();
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(textBox1.Text) == true || String.IsNullOrEmpty(textBox2.Text) == true || String.IsNullOrEmpty(textBox3.Text) == true)
            {
                MessageBox.Show("Todos os campos são de preenchimento obrigatório");
                textBox1.Focus();
            }
            if (String.IsNullOrEmpty(textBox1.Text) == false && String.IsNullOrEmpty(textBox2.Text) == false && String.IsNullOrEmpty(textBox3.Text) == false)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    if (dataGridView1.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (textBox1.Text == dataGridView1.Rows[i].Cells[1].Value.ToString())
                            {
                                MessageBox.Show("Já existe este usuário cadastrado");
                                textBox1.Focus();
                                return;
                            }
                            
                        }
                        Global.Margem.SenhaCadastroUsuario = textBox2.Text;
                        Global.Margem.OperadorTemp = textBox1.Text;
                        Global.Margem.editaUsrSist = "novo";
                        Global.Margem.SenhaCadastroUsuarioTemp = textBox2.Text;

                        Form perm = new Permissoes();
                        perm.ShowDialog();
                        if (Global.Margem.editaUsrSist == "novo")
                        {
                            MessageBox.Show("Criado usuário / operador :  " + Global.Margem.OperadorTemp);

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            Global.Margem.SenhaCadastroUsuario = "";
                            Global.Margem.OperadorTemp = "";
                            Global.Margem.editaUsrSist = "";
                            dataGridView1.DataSource = DALCadastro.ListaUsrSistemaEdita();
                            textBox1.Focus();    
                        }
                        if (Global.Margem.editaUsrSist == "não")
                        {
                            MessageBox.Show("Cancelada criação de novo operador / usuário");

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            Global.Margem.SenhaCadastroUsuario = "";
                            Global.Margem.OperadorTemp = "";
                            Global.Margem.editaUsrSist = "";
                            dataGridView1.DataSource = DALCadastro.ListaUsrSistemaEdita();
                            textBox1.Focus();
                        }


                        
                    }
                    if (dataGridView1.Rows.Count <= 0)
                    {
                        Global.Margem.SenhaCadastroUsuario = textBox2.Text;
                        Global.Margem.OperadorTemp = textBox1.Text;
                        Global.Margem.editaUsrSist = "novo";
                        Global.Margem.SenhaCadastroUsuarioTemp = textBox2.Text;

                        Form perm = new Permissoes();
                        perm.ShowDialog();
                        if (Global.Margem.editaUsrSist == "novo")
                        {
                            MessageBox.Show("Criado usuário / operador :  " + Global.Margem.OperadorTemp);

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            Global.Margem.SenhaCadastroUsuario = "";
                            Global.Margem.OperadorTemp = "";
                            Global.Margem.editaUsrSist = "";
                            dataGridView1.DataSource = DALCadastro.ListaUsrSistemaEdita();
                            textBox1.Focus();
                        }
                        if (Global.Margem.editaUsrSist == "não")
                        {
                            MessageBox.Show("Cancelada criação de novo operador / usuário");

                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            Global.Margem.SenhaCadastroUsuario = "";
                            Global.Margem.OperadorTemp = "";
                            Global.Margem.editaUsrSist = "";
                            dataGridView1.DataSource = DALCadastro.ListaUsrSistemaEdita();
                            textBox1.Focus();
                        }
                        
                    }

                    
                }
                else
                {
                    MessageBox.Show("Repetição da senha não é igual a senha digitada");
                    textBox3.Focus();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroUsuarios != "adm")
            {
                MessageBox.Show("Acesso não autorizado");                
                return;
            }
            Global.Margem.editaUsrSist = "edita";
            Global.Margem.OperadorTemp = label7.Text;
            Global.Margem.intCadUsr = label9.Text;
            Form perm = new Permissoes();
            perm.ShowDialog();
            if (Global.Margem.editaUsrSist == "não")
            {
                MessageBox.Show("Edição das permissões cancelada");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("CadUsuarios", "Iniciou e cancelou edição das permissões do Usuário :" + Global.Margem.OperadorTemp);
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                Global.Margem.SenhaCadastroUsuario = "";
                Global.Margem.OperadorTemp = "";
                Global.Margem.editaUsrSist = "";
                Global.Margem.intCadUsr = "";
                label6.Visible = false;
                label8.Visible = false;
                label7.Visible = false;
                label9.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                
            }
            if (Global.Margem.editaUsrSist == "edita")
            {
                MessageBox.Show("Permissões alteradas para usuário / operador :  " + Global.Margem.OperadorTemp);
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("CadUsuarios", "Alterou permissões do Usuário :" + Global.Margem.OperadorTemp);
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                Global.Margem.SenhaCadastroUsuario = "";
                Global.Margem.OperadorTemp = "";
                Global.Margem.editaUsrSist = "";
                Global.Margem.intCadUsr = "";
                label6.Visible = false;
                label8.Visible = false;
                label7.Visible = false;
                label9.Visible = false;
                button2.Visible = false;
                button3.Visible = false;    
            }
            
            //this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Global.Margem.CadastroUsuarios != "adm")
            {
                MessageBox.Show("Acesso não autorizado");
                return;
            }
            Global.Margem.OperadorTemp = label7.Text;
            Global.Margem.editaUsrSist = "sim";
            Global.Margem.intCadUsr = label9.Text;
            Form alterasenha = new AlteraSenha();
            alterasenha.ShowDialog();
            if (Global.Margem.editaUsrSist == "ok")
            {
                 MessageBox.Show("Senha do usuário / operador :" + Global.Margem.OperadorTemp + "  .\nAlterada com sucesso");
                 if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                 {
                     Ferramentas.CriaLog("CadUsuarios", "Alterada senha do Usuário :" + Global.Margem.OperadorTemp);
                 }
            }
            else
            {
                MessageBox.Show("Senha não foi alterada!");
                if (Global.Margem.ConfiguraçãoSistemaLOGs == "sim")
                {
                    Ferramentas.CriaLog("CadUsuarios", "Cancelada alteração se senha do Usuário :" + Global.Margem.OperadorTemp);
                }
            }
            
            Global.Margem.OperadorTemp = "";
            Global.Margem.intCadUsr = "";
            Global.Margem.SenhaCadastroUsuarioTemp = "";
            Global.Margem.editaUsrSist = "";
            label6.Visible = false;
            label8.Visible = false;
            label7.Visible = false;
            label9.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                label7.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[1].FormattedValue.ToString();
                label9.Text = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].FormattedValue.ToString();
                label6.Visible = true;
                label8.Visible = true;
                label7.Visible = true;
                label9.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.Cyan;
            

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.BackColor = System.Drawing.Color.White;
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = System.Drawing.Color.White;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.BackColor = System.Drawing.Color.Cyan;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.BackColor = System.Drawing.Color.White;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Ferramentas.Dedo_Duro();
            
            Application.Exit();
        }
    }
}
