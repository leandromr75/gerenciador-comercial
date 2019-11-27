using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chave
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        
        public static int cont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            cont++;
            label2.Text = cont + " %";
            progressBar1.PerformStep();
            if (cont >= 100)
            {
                timer1.Enabled = false;
                button2.Visible = true;
                button1.Visible = false;
                MessageBox.Show("Licença do Sistema Renovada com Exito!");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
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
                //con.Open();
                label4.Text = Environment.MachineName.ToString();
                DAL.RealizaAtualização1("780","1440","900","255","255","255","255");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível estabelecer uma conexão com o Banco de Dados" + "\n\nDescrição do problema: : \n\n" + ex.Message.ToString());
                
                this.Close();
                
            }
            
        

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            string cod =  Convert.ToString( DAL.VerficaAtualização() );
            
            
                
            
            if (cod == "FFFFFFFKKJ")
            {
                MessageBox.Show("Atualização de Licença já foi Aplicada!");
                Application.Exit();
            }
            else
            {
                DAL.RealizaAtualização("FFFFFFFKKJ", "1386", "931", "1100", "195", "49", "105");
            }
            
            
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
