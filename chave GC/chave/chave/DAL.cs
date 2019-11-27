using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chave
{
    class DAL
    {
        public static void RealizaAtualização1(string codAt, string x, string y, string z, string r, string g, string b)
        {
            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            String strSQL = "RealizaAtualização1";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@codFornecimento", codAtualização);
            cmd.Parameters.AddWithValue("@codAtualização", codAt);
            cmd.Parameters.AddWithValue("@X", x);
            cmd.Parameters.AddWithValue("@Y", y);
            cmd.Parameters.AddWithValue("@Z", z);
            cmd.Parameters.AddWithValue("@R", r);
            cmd.Parameters.AddWithValue("@G", g);
            cmd.Parameters.AddWithValue("@B", b);

            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            
        }
        public static Object VerficaAtualização()
        {
            Object codAtualização;
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            String strSQL = "VerificaAtualização";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@codFornecimento", codAtualização);
            

            codAtualização = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return codAtualização;
        }
        public static void RealizaAtualização(string codAtualização,string x,string y,string z,
            string r,string g,string b)
        {
            
            string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            //define a instrução SQL para somar Quantidade e agrupar resultados

            String strSQL = "RealizaAtualização";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codAtualização",codAtualização );
            cmd.Parameters.AddWithValue("@X", x);
            cmd.Parameters.AddWithValue("@Y", y);
            cmd.Parameters.AddWithValue("@Z", z);
            cmd.Parameters.AddWithValue("@R", r);
            cmd.Parameters.AddWithValue("@G", g);
            cmd.Parameters.AddWithValue("@B", b);


            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            
        }
    }
}
