using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Web;

/// <summary>
/// Summary description for DAL
/// </summary>
public static class DAL
{
	public static DataTable Lista_Data(string data)
	{
        string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Loja;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
        //define a instrução SQL para somar Quantidade e agrupar resultados

        String strSQL = "Lista_Data";

        //cria a conexão com o banco de dados
        OleDbConnection dbConnection = new OleDbConnection(strConnection);

        //cria a conexão com o banco de dados
        OleDbConnection con = new OleDbConnection(strConnection);
        //cria o objeto command para executar a instruçao sql
        OleDbCommand cmd = new OleDbCommand(strSQL, con);

        //abre a conexao
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@data",data );
        //cria um dataadapter
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //cria um objeto datatable
        DataTable clientes = new DataTable();
        //preenche o datatable via dataadapter
        da.Fill(clientes);
        con.Dispose();
        con.Close();
        cmd.Dispose();
        dbConnection.Dispose();
        dbConnection.Close();
        //atribui o datatable ao datagridview para exibir o resultado
        //dataGridView1.DataSource = clientes;
        return clientes;
        //GridView1.DataSource = clientes;
        //GridView1.DataBind();
        //TextBox5.Text = GridView1.Rows[0].Cells[0].Text; 
	}
    public static void Inserir_Pedido(int id,string nome,string telefone,string endereço,string email)
    {
        string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=Loja;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
        //define a instrução SQL para somar Quantidade e agrupar resultados

        String strSQL = "Inserir_Pedido";

        //cria a conexão com o banco de dados
        OleDbConnection dbConnection = new OleDbConnection(strConnection);

        //cria a conexão com o banco de dados
        OleDbConnection con = new OleDbConnection(strConnection);
        //cria o objeto command para executar a instruçao sql
        OleDbCommand cmd = new OleDbCommand(strSQL, con);
        nome = nome.Replace("-","");
        nome = nome.Replace("%","");
        nome = nome.Replace("(","");
        nome = nome.Replace(")","");
        nome = nome.Replace("/","");
        nome = nome.Replace("\\","");
        nome = nome.Replace("&","");
        nome = nome.Replace("=","");
        nome = nome.Replace("@","");
        nome = nome.Replace("{", "");
        nome = nome.Replace("}", "");
        nome = nome.Replace("+", "");
        nome = nome.Replace("|", "");

        endereço = endereço.Replace("-", "");
        endereço = endereço.Replace("%", "");
        endereço = endereço.Replace("(", "");
        endereço = endereço.Replace(")", "");
        endereço = endereço.Replace("/", "");
        endereço = endereço.Replace("\\", "");
        endereço = endereço.Replace("&", "");
        endereço = endereço.Replace("=", "");
        endereço = endereço.Replace("@","");
        endereço = endereço.Replace("{", "");
        endereço = endereço.Replace("}", "");
        endereço = endereço.Replace("+", "");
        endereço = endereço.Replace("|", "");

        email = email.Replace("-", "");
        email = email.Replace("%", "");
        email = email.Replace("(", "");
        email = email.Replace(")", "");
        email = email.Replace("/", "");
        email = email.Replace("\\", "");
        email = email.Replace("&", "");
        email = email.Replace("=", "");
        email = email.Replace("@","");
        email = email.Replace("{", "");
        email = email.Replace("}", "");
        email = email.Replace("+", "");
        email = email.Replace("|", "");
        
        
        //abre a conexao
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@Nome",nome );
        cmd.Parameters.AddWithValue("@Telefone", telefone);
        cmd.Parameters.AddWithValue("@Endereço", endereço);
        cmd.Parameters.AddWithValue("@Email", email);
        //cria um dataadapter
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //cria um objeto datatable
        DataTable clientes = new DataTable();
        //preenche o datatable via dataadapter
        da.Fill(clientes);
        con.Dispose();
        con.Close();
        cmd.Dispose();
        dbConnection.Dispose();
        dbConnection.Close();
    }
    public static void Log_permissão(string nome,string data)
    {
        string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=chave;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
        //define a instrução SQL para somar Quantidade e agrupar resultados

        String strSQL = "Log_permissão";

        //cria a conexão com o banco de dados
        OleDbConnection dbConnection = new OleDbConnection(strConnection);

        //cria a conexão com o banco de dados
        OleDbConnection con = new OleDbConnection(strConnection);
        //cria o objeto command para executar a instruçao sql
        OleDbCommand cmd = new OleDbCommand(strSQL, con);

        //abre a conexao
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@Nome", nome);
        //cmd.Parameters.AddWithValue("@Telefone", telefone);
        //cmd.Parameters.AddWithValue("@Endereço", endereço);
        cmd.Parameters.AddWithValue("@Data", data);
        //cria um dataadapter
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        //cria um objeto datatable
        DataTable clientes = new DataTable();
        //preenche o datatable via dataadapter
        da.Fill(clientes);
        con.Dispose();
        con.Close();
        cmd.Dispose();
        dbConnection.Dispose();
        dbConnection.Close();
    }
    public static Object PodeAtualizar(string senha)
    {
        Object chave;
        string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=chave;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
        //define a instrução SQL para somar Quantidade e agrupar resultados

        String strSQL = "Permissão";

        //cria a conexão com o banco de dados
        OleDbConnection dbConnection = new OleDbConnection(strConnection);

        //cria a conexão com o banco de dados
        OleDbConnection con = new OleDbConnection(strConnection);
        //cria o objeto command para executar a instruçao sql
        OleDbCommand cmd = new OleDbCommand(strSQL, con);
        
        //abre a conexao
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Senha", senha);


        chave = cmd.ExecuteScalar();
        con.Dispose();
        con.Close();
        cmd.Dispose();
        dbConnection.Dispose();
        dbConnection.Close();
        //atribui o datatable ao datagridview para exibir o resultado
        //dataGridView1.DataSource = clientes;
        return chave;     
        
        
    }
    public static Object Permissão2(string Senha)
    {
        Object nome;
        string strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=chave;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
        //define a instrução SQL para somar Quantidade e agrupar resultados

        String strSQL = "Permissão2";

        //cria a conexão com o banco de dados
        OleDbConnection dbConnection = new OleDbConnection(strConnection);

        //cria a conexão com o banco de dados
        OleDbConnection con = new OleDbConnection(strConnection);
        //cria o objeto command para executar a instruçao sql
        OleDbCommand cmd = new OleDbCommand(strSQL, con);

        //abre a conexao
        con.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Senha", Senha);


        nome = cmd.ExecuteScalar();
        con.Dispose();
        con.Close();
        cmd.Dispose();
        dbConnection.Dispose();
        dbConnection.Close();
        //atribui o datatable ao datagridview para exibir o resultado
        //dataGridView1.DataSource = clientes;
        return nome;
    }
}