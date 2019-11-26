using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public partial class TestaConexao : Form
    {
        public TestaConexao()
        {
            InitializeComponent();
        }
        public static int cont = 0;
        private void TestaConexao_Load(object sender, EventArgs e)
        {
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            String strSQL = "baixaEstoqueRetorna";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            try
            {
                //abre a conexao
                con.Open();
               
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão com o Banco de Dados" + "\n\nDescrição do problema: : \n\n" + ex.Message.ToString());
                Global.Margem.Erro = "no";
                this.Close();
                
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (cont <= 10)
            {
                
                progressBar1.PerformStep();
                
                
            }
            else
            {
                Global.Margem.Erro = "yes";
                timer1.Enabled = false;
                cont = 0;
                
                this.Close();
            }
            cont++;
        }
    }
}
