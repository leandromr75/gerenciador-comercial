using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;



namespace Gerenciador_Comercial
{

    class DALCadastro
    {
        public static void InsereAUXVendas(string descrição, string vendanum,string cliente, string pagamento,string situação,string valor_total,
            string data, int data_calculo)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "InsereAUXVendas";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Descrição", descrição);
            cmd.Parameters.AddWithValue("@VendaNumero", vendanum);
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            cmd.Parameters.AddWithValue("@Pagamento", pagamento);
            cmd.Parameters.AddWithValue("@Situação", situação);
            cmd.Parameters.AddWithValue("@Valor_Total", valor_total);
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Data_Calculo", data_calculo);

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
        public static DataTable ListaAUXVendas(string data)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaAUXVendas";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Data", data);
            //cmd.Parameters.AddWithValue("@CodEANTrib", codeantrib);

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
        }
        public static DataTable PegaIdVendaSAT(string idvenda)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "PegaIdVendaSAT";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVenda", idvenda);
            //cmd.Parameters.AddWithValue("@CodEANTrib", codeantrib);

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
        }
        public static DataTable ListaFracionadosBalança()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaFracionadosBalança";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@EstoquePeso", estoquepeso);
            //cmd.Parameters.AddWithValue("@CodEANTrib", codeantrib);

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
        }
        public static DataTable ProcurarProdutoEANTrib(string codeantrib)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ProcurarProdutoEANTrib";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@EstoquePeso", estoquepeso);
            cmd.Parameters.AddWithValue("@CodEANTrib", codeantrib);

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
        }
        public static void InserePreço(string valorvenda, int identificador)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "InserePreco";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Preco", valorvenda);
            cmd.Parameters.AddWithValue("@IdProd", identificador);

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
            // return clientes;
        }
        public static void InsereDesconto(string valortotal, int identificador)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "InsereDesconto";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Valor_Total", valortotal);
            cmd.Parameters.AddWithValue("@Identificador", identificador);
            
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
            // return clientes;
        }
        public static void CriaFracionadoAlternativo(string codprinc, string codalt, string desc, string preço)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "CriaFracionadoAlternativo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Cod_Principal", codprinc);
            cmd.Parameters.AddWithValue("@Cod_Alternativo", codalt);
            cmd.Parameters.AddWithValue("@Descrição", desc );
            cmd.Parameters.AddWithValue("@Preço", preço);

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
            // return clientes;
        }
        public static void EditaFracionadoAlternativo(string codalt, string desc, string preço)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "EditaFracionadoAlternativo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

           
            cmd.Parameters.AddWithValue("@Cod_Alternativo", codalt);
            cmd.Parameters.AddWithValue("@Descrição", desc);
            cmd.Parameters.AddWithValue("@Preço", preço);

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
            // return clientes;
        }
        public static void ExcluiFracionadoAlternativo(string codalt)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ExcluiFracionadoAlternativo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Cod_Alternativo", codalt);
           

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
            // return clientes;
        }
        public static DataTable FracionadoAlternativo(string cod)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FracAlt";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@EstoquePeso", estoquepeso);
            cmd.Parameters.AddWithValue("@Cod", cod);

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
        }
        public static DataTable ListaFracionadoAlternativo()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaFracionadoAlternativo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@EstoquePeso", estoquepeso);
            //cmd.Parameters.AddWithValue("@IdProd", idprod);

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
        }
        public static DataTable BaixaFracionadoRetorna(int idprod)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "BaixaFracionadoRetorna";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@EstoquePeso", estoquepeso);
            cmd.Parameters.AddWithValue("@IdProd", idprod);

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
        }
        public static void BaixaFracionado(string estoquepeso, int idprod)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "BaixaFracionado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EstoquePeso", estoquepeso);
            cmd.Parameters.AddWithValue("@IdProd", idprod);

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
            // return clientes;
        }
        public static DataTable PodeApagarCFOP(string cfop_codigo)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "PodeApagarCFOP";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);

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
        }
        public static void ProcCFOP(string cfop_codigo)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ProcCFOP";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);
            
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
            // return clientes;
        }
        public static void CriaCFOP(string cfop_codigo, string descrição)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "CriaCFOP";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@CFOP_Codigo", cfop_codigo);
            cmd.Parameters.AddWithValue("@Descrição", descrição);
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
            // return clientes;
        }
        public static DataTable ListaCFOP()
        {

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaCFOP";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Caixa", caixa);
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
        }
        public static DataTable VersaoCheck()
        {

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "VersaoCheck";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Caixa", caixa);
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
        }
        public static DataTable ParcialLista(string caixa)
        {

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ParcialLista";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Caixa", caixa);
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
        }
        public static DataTable ListaMisto(string vendanumero)
        {

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaMisto";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VendaNumero", vendanumero);
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
        }
        public static DataTable ParcialDeleta(string caixa)
        {

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ParcialDeleta";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Caixa", caixa);
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
        }
        public static void ParcialInsere(string cliente, string valorparcial,string pagamento,string caixa)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ParcialInsere";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            cmd.Parameters.AddWithValue("@Valor", valorparcial);
            cmd.Parameters.AddWithValue("@Pagamento", pagamento);
            cmd.Parameters.AddWithValue("@Caixa", caixa);
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
            // return clientes;
        }
        public static void AtualizaParcialFiado(int id, string cliente,string valorparcial)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "AtualizaParcialFiado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            cmd.Parameters.AddWithValue("@Valor_Parcial", valorparcial);
            //cmd.Parameters.AddWithValue("@EstoqueINT", tot);
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
            // return clientes;
        }
        public static void QuitaVendaParcial(string vendanum,string pagamento)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "QuitaVendaParcial";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Venda_Numero", vendanum);
            cmd.Parameters.AddWithValue("@Pagamento", pagamento);
            //cmd.Parameters.AddWithValue("@EstoqueINT", tot);
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
            // return clientes;
        }
        public static void DeletaFiadoParcial(int id,string cliente)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "DeletaFiadoParcial";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            //cmd.Parameters.AddWithValue("@EstoqueINT", tot);
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
            // return clientes;
        }
        public static void CriaFiadoParcial(string cliente,string total_devedor,string valor_parcial,string data, string vendas)
        {

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "CriaFiadoParcial";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            cmd.Parameters.AddWithValue("@Total_Devedor", total_devedor);
            cmd.Parameters.AddWithValue("@Valor_Parcial", valor_parcial);
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Vendas", vendas);
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
            // return clientes;
        }
        public static void FiadoPAGParcial(string numvenda)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FiadoPAGParcial";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumVenda", numvenda);
            //cmd.Parameters.AddWithValue("@EstoqueINT", tot);
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
            // return clientes;
        }
        public static DataTable ListaParcial(string cliente)
        {

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaParcial";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cliente", cliente);
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
        }
        public static void Qtde_Produto(int idprod,int tot)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "Qtde_Produto";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProd", idprod);
            cmd.Parameters.AddWithValue("@EstoqueINT", tot);
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
            // return clientes;
        }
        public static DataTable CarregaSAT(int id)
        {

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "CarregaSAT";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
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
        }
        public static void DeletaSAT(int id)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "DeletaSAT";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
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
            // return clientes;
        }
        public static DataTable VerificaSAT(int id)
        {

            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "VerificaSAT";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
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
        }
        public static void InserirSATCadastro(Int32 Id,string ICMS,string ICMS_Origem,string ICMS_Aliq,string PIS,string PIS_CodSitTrib,
            string PIS_vBC,string PIS_pPIS,string PIS_qBCProd,string PIS_vAliqProd,string PISST,string PISST_vBC,string PISST_pPIS,
            string PISST_qBCProd,string PISST_vAliqProd,string COFINS,string COFINS_CodSitTrib,string COFINS_vBC,string COFINS_pCOFINS,
            string COFINS_qBCProd,string COFINS_vAliqProd,string COFINSST,string COFINSST_vBC,string COFINSST_pCOFINS,
            string COFINSST_qBCProd, string COFINSST_vAliqProd, string CFOP, string RegraCalculo, string vItem12741)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "InserirSATCadastro";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",Id);
            cmd.Parameters.AddWithValue("@ICMS",ICMS);
            cmd.Parameters.AddWithValue("@ICMS_Origem",ICMS_Origem);
            cmd.Parameters.AddWithValue("@ICMS_Aliq",ICMS_Aliq);
            cmd.Parameters.AddWithValue("@PIS",PIS);
            cmd.Parameters.AddWithValue("@PIS_CodSitTrib",PIS_CodSitTrib);
            cmd.Parameters.AddWithValue("@PIS_vBC",PIS_vBC);
            cmd.Parameters.AddWithValue("@PIS_pPIS",PIS_pPIS);
            cmd.Parameters.AddWithValue("@PIS_qBCProd",PIS_qBCProd);
            cmd.Parameters.AddWithValue("@PIS_vAliqProd",PIS_vAliqProd);
            cmd.Parameters.AddWithValue("@PISST",PISST);
            cmd.Parameters.AddWithValue("@PISST_vBC",PISST_vBC);
            cmd.Parameters.AddWithValue("@PISST_pPIS",PISST_pPIS);
            cmd.Parameters.AddWithValue("@PISST_qBCProd",PISST_qBCProd);
            cmd.Parameters.AddWithValue("@PISST_vAliqProd",PISST_vAliqProd);
            cmd.Parameters.AddWithValue("@COFINS",COFINS);
            cmd.Parameters.AddWithValue("@COFINS_CodSitTrib",COFINS_CodSitTrib);
            cmd.Parameters.AddWithValue("@COFINS_vBC",COFINS_vBC);
            cmd.Parameters.AddWithValue("@COFINS_pCOFINS",COFINS_pCOFINS);
            cmd.Parameters.AddWithValue("@COFINS_qBCProd",COFINS_qBCProd);
            cmd.Parameters.AddWithValue("@COFINS_vAliqProd",COFINS_vAliqProd);
            cmd.Parameters.AddWithValue("@COFINSST",COFINSST);
            cmd.Parameters.AddWithValue("@COFINSST_vBC",COFINSST_vBC);
            cmd.Parameters.AddWithValue("@COFINSST_pCOFINS",COFINSST_pCOFINS);
            cmd.Parameters.AddWithValue("@COFINSST_qBCProd",COFINSST_qBCProd);
            cmd.Parameters.AddWithValue("@COFINSST_vAliqProd",COFINSST_vAliqProd);
            cmd.Parameters.AddWithValue("@CFOP",CFOP);
            cmd.Parameters.AddWithValue("@RegraCalculo",RegraCalculo);
            cmd.Parameters.AddWithValue("@vItem12741",vItem12741);
            
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
            // return clientes;
        }
        public static DataTable  CadProdRapido(string codean, string unidade,string descinterna,string empresa, string valorcompra , string valorvenda, string estoqueint)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "CadProdRapido";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CodEAN", codean);
            cmd.Parameters.AddWithValue("@Unidade", unidade);
            cmd.Parameters.AddWithValue("@DescInterna", descinterna);
            cmd.Parameters.AddWithValue("@Empresa", empresa);
            cmd.Parameters.AddWithValue("@ValorCompra", valorcompra);
            cmd.Parameters.AddWithValue("@ValorVenda", valorvenda);
            cmd.Parameters.AddWithValue("@EstoqueINT", estoqueint);
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
        }
        public static DataTable ExisteTextoCupom()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ExisteTextoCupom";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            
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
        }
        public static void CriaTextoCupom(string empresa, string cnpj, string ie, string textoadicional1, string textoadicional2)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "CriaTextoCupom";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Empresa", empresa);
            cmd.Parameters.AddWithValue("@CNPJ", cnpj);
            cmd.Parameters.AddWithValue("@IE", ie);
            cmd.Parameters.AddWithValue("@TextoAdicional1", textoadicional1);
            cmd.Parameters.AddWithValue("@TextoAdicional2", textoadicional2);
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
            // return clientes;
        }
        public static void InsereTextoCupom(string empresa, string cnpj, string ie, string textoadicional1, string textoadicional2)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "InsereTextoCupom";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Empresa", empresa);
            cmd.Parameters.AddWithValue("@CNPJ", cnpj);
            cmd.Parameters.AddWithValue("@IE", ie);
            cmd.Parameters.AddWithValue("@TextoAdicional1", textoadicional1);
            cmd.Parameters.AddWithValue("@TextoAdicional2", textoadicional2);
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
            // return clientes;
        }
        public static void CriarRetirada(string valor,string motivo,string caixa,string fornecedor)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "CriarRetirada";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Valor", valor);
            cmd.Parameters.AddWithValue("@Motivo",motivo);
            cmd.Parameters.AddWithValue("@Caixa",caixa);
            cmd.Parameters.AddWithValue("@Fornecedor", fornecedor);
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
            // return clientes;
        }
        public static DataTable ListaRetirada(string caixa)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaRetirada";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Caixa", caixa);
            
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
        }
        public static void DeletaRetirada(string caixa)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "DeletaRetirada";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Caixa", caixa);

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
            // return clientes;
        }
        public static void deletaVendaFiadoImpressao()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "deletaVendaFiadoImpressao";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue("@Caixa", caixa);

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
            // return clientes;
        }

        public static DataTable ProcurarProdutoSemCodeBarDescInt(string descinterna)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ProcurarProdutoSemCodeBarDescInt";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DescInterna",descinterna);
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
            return clientes;
        }
        public static DataTable ProcurarProdutoCodeBar(string ean)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ProcurarProdutoCodeBar";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EAN", ean);
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
            return clientes;
        }
        public static DataTable ProcurarProdutoSemCodeBarId(string numinterno )
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ProcurarProdutoSemCodeBarId";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProd",Convert.ToInt32( numinterno ));
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
            return clientes;
        }
        public static DataTable ListaImpressao()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaImpressao";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;            
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
            return clientes;
        }
        public static DataTable ProcuraVendaImpressao(string numvenda)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ProcuraVendaImpressao";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumVenda", numvenda);
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
            return clientes;
        }
        public static void InsereImpressao(string numvenda)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "InsereImpressao";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumVenda", numvenda);
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
           // return clientes;
        }
        public static void DeletaImpressao(string numvenda)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "DeletaImpressao";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumVenda", numvenda);
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
            // return clientes;
        }
        public static DataTable FechamentoCaixa(string caixa)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FechamentoCaixa";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Caixa", caixa);
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
        }
        public static DataTable ListarContaAbrirCaixa()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListarContaAbrirCaixa";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
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
        }
        public static DataTable ListaLogAnteriorTudo(int data, string operador)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaLogAnteriorTudo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Operador", operador);
           
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
        }
        public static DataTable ListaLogAnterior(int data,string operador,string modulo)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaLogAnterior";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Operador", operador);
            cmd.Parameters.AddWithValue("@Modulo", modulo);
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
        }
        public static DataTable ListaLogPosteriorTudo(int data, string operador)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaLogPosteriorTudo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Operador", operador);
            
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
        }
        public static DataTable ListaLogPosterior(int data, string operador, string modulo)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaLogPosterior";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Operador", operador);
            cmd.Parameters.AddWithValue("@Modulo", modulo);
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
        }
        public static DataTable ListaLogIgual(int data, string operador, string modulo)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaLogIgual";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Operador", operador);
            cmd.Parameters.AddWithValue("@Modulo", modulo);
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
        }
        public static DataTable ListaLogIgualTudo(int data, string operador)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaLogIgualTudo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Operador", operador);
            
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
        }
        public static DataTable DeletarLogs()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "DeletarLogs";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            
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
        }
        public static DataTable ListaLog(string operador)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaLog";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Operador", operador);
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
        }
        public static void InsereLog(string data, int datacalc, string operador,string modulo, string descrição)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "InsereLog";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Data_Calc",datacalc );
            cmd.Parameters.AddWithValue("@Operador", operador);
            cmd.Parameters.AddWithValue("@Modulo", modulo);
            cmd.Parameters.AddWithValue("@Descrição", descrição);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
        }
        public static DataTable ExcluiCadAUX(string stored, string id)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }

            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = stored;

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@Id",Convert.ToInt32( id ));
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static Object ProcuraAUXCad(string stored, string descrição)
        {
            Object id;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = stored;
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@Descrição", descrição);
            id = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return id;
        }
        public static Object TemEAN(string ean)
        {
            Object id;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "TemEAN";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EAN", ean);
            id = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return id;
        }
        public static Object TemCodBalança(string codalternativo)
        {
            Object id;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "TemCodBalança";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Cod_Alternativo", codalternativo);
            id = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return id;
        }
        public static DataTable TemDesc(string descinterna)
        {
            
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "TemDesc";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DescInterna", descinterna);
            
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
            
        }
        public static DataTable Insere_Banco(string codigo, string nome, string ativo)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";    
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975"; 
            }
            
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Insere_Banco";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Código", codigo);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Ativo", ativo);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Atualiza_Banco(string id, string ativo)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Atualiza_Banco";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            
            cmd.Parameters.AddWithValue("@Ativo", ativo);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Lista_Contas_Corrente(string id)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
           
            //define a instrução SQL para somar Quantidade e agrupar resultados

            string strSQL = "Lista_Contas_Corrente";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));

            
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Insere_Contas_Corrente(string codigo_banco,string agencia,string digito_agencia,
            string conta,string digito_conta,string	banco,string nome,string ativo,string idbanco)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }            
            string strSQL = "Insere_Contas_Corrente";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@Código_Banco", codigo_banco);
            cmd.Parameters.AddWithValue("@Agência", agencia);
            cmd.Parameters.AddWithValue("@Dígito_Agência", digito_agencia);
            cmd.Parameters.AddWithValue("@Conta", conta);
            cmd.Parameters.AddWithValue("@Dígito_Conta", digito_conta);
            cmd.Parameters.AddWithValue("@Banco", banco);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Ativo", ativo);
            cmd.Parameters.AddWithValue("@IdBanco", Convert.ToInt32(idbanco));
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Inativa_Contas_Corrente(string id,  string ativo)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Inativa_Contas_Corrente";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@Ativo", ativo);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Inativa_Contas_Corrente_Lista()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Inativa_Contas_Corrente_Lista";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Lista_Banco()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Lista_Banco";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Lista_Banco_Inativo()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Lista_Banco_Inativo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable TestaConfiVazia(string id)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local" )
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "TestaConfigVazia";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable InsereConfig(string id,string campo1,string campo2,string campo3,string campo4,string campo5,string campo6,
            string campo7,string campo8,string campo9,string campo10)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "InsereConfig";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@Campo1", campo1);
            cmd.Parameters.AddWithValue("@Campo2", campo2);
            cmd.Parameters.AddWithValue("@Campo3", campo3);
            cmd.Parameters.AddWithValue("@Campo4", campo4);
            cmd.Parameters.AddWithValue("@Campo5", campo5);
            cmd.Parameters.AddWithValue("@Campo6", campo6);
            cmd.Parameters.AddWithValue("@Campo7", campo7);
            cmd.Parameters.AddWithValue("@Campo8", campo8);
            cmd.Parameters.AddWithValue("@Campo9", campo9);
            cmd.Parameters.AddWithValue("@Campo10", campo10);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable CriaConfig(string id, string campo1, string campo2, string campo3, string campo4, string campo5, string campo6,
            string campo7, string campo8, string campo9, string campo10)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "CriaConfig";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@Campo1", campo1);
            cmd.Parameters.AddWithValue("@Campo2", campo2);
            cmd.Parameters.AddWithValue("@Campo3", campo3);
            cmd.Parameters.AddWithValue("@Campo4", campo4);
            cmd.Parameters.AddWithValue("@Campo5", campo5);
            cmd.Parameters.AddWithValue("@Campo6", campo6);
            cmd.Parameters.AddWithValue("@Campo7", campo7);
            cmd.Parameters.AddWithValue("@Campo8", campo8);
            cmd.Parameters.AddWithValue("@Campo9", campo9);
            cmd.Parameters.AddWithValue("@Campo10", campo10);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable ListaPlanoDeContas()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "ListaPlanoDeContas";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Nome", temp);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Lista_Contas_Receber(string situação)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Lista_Contas_Receber";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Situação", situação);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Lista_Contas_Recebe_Tudor()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Lista_Contas_Receber_Tudo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Situação", situação);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Baixa_Contas_Receber(string id)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Baixa_Contas_Receber";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Lista_Contas_Receber_Atrasadas(int data)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Lista_Contas_Receber_Atrasadas";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DataAtual", data);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Lista_Contas_Receber_Hoje(int data)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Lista_Contas_Receber_Hoje";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DataAtual", data);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Cad_Conta_Receber(string numero_titulo,string parcela,string data_cadastro,string data_cadastro_calculo,
            string tipo_cobrança,string duplicata,string vencimento,string vencimento_calculo,string valor,string valor_À_receber,string desconto_dia,
            string desconto,string multa_juros,string mora,string multa,string dias,string representante,string idrepresentante,
            string cliente,string idcliente,string plano_de_conta,string observações,string situação)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Cad_Conta_Receber";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Numero_Titulo",numero_titulo);//1
            cmd.Parameters.AddWithValue("@Parcela", parcela);//2
            cmd.Parameters.AddWithValue("@Data_Cadastro", data_cadastro);//3
            cmd.Parameters.AddWithValue("@Data_Cadastro_Calculo", data_cadastro_calculo);//4
            cmd.Parameters.AddWithValue("@Tipo_Cobrança", tipo_cobrança);//5
            cmd.Parameters.AddWithValue("@Duplicata", duplicata);//6
            cmd.Parameters.AddWithValue("@Vencimento", vencimento);//7
            cmd.Parameters.AddWithValue("@Vencimento_Calculo", Convert.ToInt32(vencimento_calculo));//8
            cmd.Parameters.AddWithValue("@Valor", valor);
            cmd.Parameters.AddWithValue("@Valor_À_Receber", valor_À_receber);
            cmd.Parameters.AddWithValue("@Desconto_Dia", desconto_dia);//9
            cmd.Parameters.AddWithValue("@Desconto", desconto);//11
            cmd.Parameters.AddWithValue("@Multa_Juros", multa_juros);//12
            cmd.Parameters.AddWithValue("@Mora", mora);//13
            cmd.Parameters.AddWithValue("@Multa", multa);//14
            cmd.Parameters.AddWithValue("@Dias", dias);//15
            cmd.Parameters.AddWithValue("@Representante", representante);//17
            cmd.Parameters.AddWithValue("@IdRepresentante", idrepresentante);
            cmd.Parameters.AddWithValue("@Cliente", cliente);//18
            cmd.Parameters.AddWithValue("@IdCliente", idcliente);
            cmd.Parameters.AddWithValue("@Plano_De_Conta", plano_de_conta);//19
            cmd.Parameters.AddWithValue("@Observações", observações);//20
            cmd.Parameters.AddWithValue("@Situação", situação);//20
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static void CadClienteFiado(string nome, string endereço, string numero, string bairro, string telefone1, string telefone2)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "CadClienteFiado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Endereço", endereço);
            cmd.Parameters.AddWithValue("@Numero", numero);
            cmd.Parameters.AddWithValue("@Bairro", bairro);
            cmd.Parameters.AddWithValue("@Telefone1", telefone1);
            cmd.Parameters.AddWithValue("@Telefone2", telefone2);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
        }
        public static DataTable CarregaParticipante(string id)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "CarregaParticipante";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id",Convert.ToInt32( id));//1
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable CarregaRepresentante()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Representantes";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable CarregaCliente()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Cliente";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable CarregaClienteNome(string nome)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string temp = nome;
            temp = temp + "%";
            string strSQL = "Cliente2";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", temp);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Cadastrar_Participante(string finalidade,string pessoa_fisica, string nome,string fantasia,string cpf_cnpj,string insc_estadual,
            string situação,string atividade,string empresa,string observações,string contato,string emailnfe,string emailcontabil,string telefone1,string telefone2,
            string logradouro,string numero,string complemento,string bairro,string cidade,string estado,string pais,string cep,string caixapostal)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Cadastrar_Participante";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Finalidade", finalidade);//1
            cmd.Parameters.AddWithValue("@Pessoa_fisica", pessoa_fisica);//2
            cmd.Parameters.AddWithValue("@Nome", nome);//2
            cmd.Parameters.AddWithValue("@Fantasia", fantasia);//3
            cmd.Parameters.AddWithValue("@CPF_CNPJ", cpf_cnpj);//4
            cmd.Parameters.AddWithValue("@Insc_Estadual", insc_estadual);//5
            cmd.Parameters.AddWithValue("@Situação", situação);//6
            cmd.Parameters.AddWithValue("@Atividade", atividade);//7
            cmd.Parameters.AddWithValue("@Empresa", empresa);//8
            cmd.Parameters.AddWithValue("@Observações", observações);//9
            cmd.Parameters.AddWithValue("@Contato", contato);//10
            cmd.Parameters.AddWithValue("@Email_NFe", emailnfe);//11
            cmd.Parameters.AddWithValue("@Emai_Contabil", emailcontabil);
            cmd.Parameters.AddWithValue("@Telefone1", telefone1);
            cmd.Parameters.AddWithValue("@Telefone2", telefone2);
            cmd.Parameters.AddWithValue("@Logradouro", logradouro);//13
            cmd.Parameters.AddWithValue("@Numero", numero);//14
            cmd.Parameters.AddWithValue("@Complemento", complemento);//15
            cmd.Parameters.AddWithValue("@Bairro", bairro);//16
            cmd.Parameters.AddWithValue("@Cidade", cidade);//17
            cmd.Parameters.AddWithValue("@Estado", estado);//18
            cmd.Parameters.AddWithValue("@Pais", pais);//19
            cmd.Parameters.AddWithValue("@CEP", cep);//20
            cmd.Parameters.AddWithValue("@Caixa_Postal", caixapostal);//21
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable Cadastrar_Participante_Edita(string id,string finalidade, string pessoa_fisica, string nome, string fantasia, string cpf_cnpj, string insc_estadual,
            string situação, string atividade, string empresa, string observações, string contato, string emailnfe, string emailcontabil,string telefone1,string telefone2,
            string logradouro, string numero, string complemento, string bairro, string cidade, string estado, string pais, string cep, string caixapostal)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Cadastrar_Participante_Edita";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@Finalidade", finalidade);//1
            cmd.Parameters.AddWithValue("@Pessoa_fisica", pessoa_fisica);//2
            cmd.Parameters.AddWithValue("@Nome", nome);//2
            cmd.Parameters.AddWithValue("@Fantasia", fantasia);//3
            cmd.Parameters.AddWithValue("@CPF_CNPJ", cpf_cnpj);//4
            cmd.Parameters.AddWithValue("@Insc_Estadual", insc_estadual);//5
            cmd.Parameters.AddWithValue("@Situação", situação);//6
            cmd.Parameters.AddWithValue("@Atividade", atividade);//7
            cmd.Parameters.AddWithValue("@Empresa", empresa);//8
            cmd.Parameters.AddWithValue("@Observações", observações);//9
            cmd.Parameters.AddWithValue("@Contato", contato);//10
            cmd.Parameters.AddWithValue("@Email_NFe", emailnfe);//11
            cmd.Parameters.AddWithValue("@Emai_Contabil", emailcontabil);//12
            cmd.Parameters.AddWithValue("@Telefone1", telefone1);
            cmd.Parameters.AddWithValue("@Telefone2", telefone2);
            cmd.Parameters.AddWithValue("@Logradouro", logradouro);//13
            cmd.Parameters.AddWithValue("@Numero", numero);//14
            cmd.Parameters.AddWithValue("@Complemento", complemento);//15
            cmd.Parameters.AddWithValue("@Bairro", bairro);//16
            cmd.Parameters.AddWithValue("@Cidade", cidade);//17
            cmd.Parameters.AddWithValue("@Estado", estado);//18
            cmd.Parameters.AddWithValue("@Pais", pais);//19
            cmd.Parameters.AddWithValue("@CEP", cep);//20
            cmd.Parameters.AddWithValue("@Caixa_Postal", caixapostal);//21
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable VerificaParticipante(string primeiraletra)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "VerificaParticipante";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PrimeiraLetra", primeiraletra);//1
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable VerificaParticipanteFiado(string nome, string situação)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "VerificaParticipanteFiado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", nome);//1
            cmd.Parameters.AddWithValue("@Situação", situação);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable VerificaParticipante1(string nome,string situação)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "VerificaParticipante1";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", nome);//1
            cmd.Parameters.AddWithValue("@Situação", situação);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable VerificaParticipante2(string nomep)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "VerificaParticipante2";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomeP", nomep);//1
            //cmd.Parameters.AddWithValue("@Situação", situação);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable VerificaParticipante3(string identificador,string inicio,string sit)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "VerificaParticipante3";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Identificador", Convert.ToInt32( identificador));//1
            cmd.Parameters.AddWithValue("@Inicio", Convert.ToInt32( inicio));
            cmd.Parameters.AddWithValue("@Situaçao",sit );
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable VerificaParticipante4()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "VerificaParticipante4";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }
        public static DataTable FluxoVendaTudoPag5(string data)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FluxoVendaTudoPag5";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            //cmd.Parameters.AddWithValue("@Pagamento", pagamento);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes2 = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes2);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes2;
        }
        public static DataTable FluxoVendaTudoPag(string data,string pagamento)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FluxoVendaTudoPag";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Pagamento", pagamento);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes2 = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes2);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes2;
        }
        public static DataTable FluxoVendaFiado(string cliente)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FluxoVendaFiado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes2 = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes2);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes2;
        }
        public static DataTable FluxoVendaFiado2(string cliente)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FluxoVendaFiado2";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes2 = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes2);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes2;
        }
        public static DataTable FluxoVendaFiadoQuitaConta(string cliente,string pagamento)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FluxoVendaFiadoQuitaConta";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            cmd.Parameters.AddWithValue("@Pagamento", pagamento);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes2 = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes2);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes2;
        }
        public static DataTable FluxoVendaFiadoMov(string cliente)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FluxoVendaFiadoMov";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cliente", cliente);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes2 = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes2);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes2;
        }
        public static DataTable FluxoVendaTudo(string data)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FluxoVendaTudo";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Data", data);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
        }
        public static DataTable FluxoVendaTudo1()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "FluxoVendaTudo1";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Data", data);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
        }
        public static void UserSenhaEdita(int id, string senha)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "UserSenhaEdita";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Senha", senha);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;

        }
        public static DataTable ListaClienteFiado()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "ListaClienteFiado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Data", data);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

            

        }
        public static Object RetornaPermissão(string nome,string senha)
        {
            Object id;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "RetornaPermissão";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Senha", senha);
            id = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return id;
        }
        public static Object TestaLogin()
        {
            Object testalogin;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "TestaLogin";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            testalogin = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return testalogin;
        }
        public static Object VerificaLogin(string nome1, string senha1)
        {
            Object login;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "VerificaLogin";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome", nome1);
            cmd.Parameters.AddWithValue("@Senha", senha1);
            login = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return login;
        }
        public static Object carregaPermissao(string sql,int id)
        {
            Object permissão;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = sql;
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            permissão = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return permissão;
        }
        public static DataTable ListaUsrSistemaEdita()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "ListaUsrSistemaEdita";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
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

        }
        public static void InsereUsrSistemaEdita(int id, string adm, string um, string dois, string tres, string quatro, string cinco,
            string seis, string sete, string oito, string nove)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "InsereUsrSistemaEdita";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Administrador", adm);
            cmd.Parameters.AddWithValue("@Um", um);
            cmd.Parameters.AddWithValue("@Dois", dois);
            cmd.Parameters.AddWithValue("@Tres", tres);
            cmd.Parameters.AddWithValue("@Quatro", quatro);
            cmd.Parameters.AddWithValue("@Cinco", cinco);
            cmd.Parameters.AddWithValue("@Seis", seis);
            cmd.Parameters.AddWithValue("@Sete", sete);
            cmd.Parameters.AddWithValue("@Oito", oito);
            cmd.Parameters.AddWithValue("@Nove", nove);
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

        }
        public static void InsereUsrSistema(string nome,string senha,string adm,string um,string dois,string tres, string quatro,string cinco,
            string seis,string sete, string oito,string nove)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "InsereUsrSistema";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nome",nome );
            cmd.Parameters.AddWithValue("@Senha", senha);
            cmd.Parameters.AddWithValue("@Administrador", adm);
            cmd.Parameters.AddWithValue("@Um", um);
            cmd.Parameters.AddWithValue("@Dois", dois);
            cmd.Parameters.AddWithValue("@Tres", tres);
            cmd.Parameters.AddWithValue("@Quatro", quatro);
            cmd.Parameters.AddWithValue("@Cinco", cinco);
            cmd.Parameters.AddWithValue("@Seis", seis);
            cmd.Parameters.AddWithValue("@Sete", sete);
            cmd.Parameters.AddWithValue("@Oito", oito);
            cmd.Parameters.AddWithValue("@Nove", nove);
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

        }
        public static Object testaLicença()
        {
            Object resposta;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";

            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "testaLicença";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            resposta = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return resposta;
        }
        
        public static void MapearResolução(string res1, string res2, string res3, string res4, string res5, string res6)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "MapearResoluçãoRes1";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Res1", res1);
            cmd.Parameters.AddWithValue("@Res2", res2);
            cmd.Parameters.AddWithValue("@Res3", res3);
            cmd.Parameters.AddWithValue("@Res4", res4);
            cmd.Parameters.AddWithValue("@Res5", res5);
            cmd.Parameters.AddWithValue("@Res6", res6);
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
            
        }
        public static Object ValidaLicença(string letra)
        {
            Object coordenada;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = Convert.ToString( letra );
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            coordenada = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return coordenada;
        }
        
        public static DataTable deleteVenda()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "deleteVenda";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@IdProd", ident);
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
        }
        public static DataTable listaVendas()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "listaVendas";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
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
        }
        public static DataTable produtoVenda(string EAN)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "produtoVenda";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EAN", EAN);
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
        }
        public static DataTable criarVenda(string produto, string quantidade, string unidade, string valorUnitario, string valorTotal,
            string situação, string pagamento, string vendaNumero, string operador,string caixa,string conta,string finalizada, string data,
            string datacalculo,string Imagem,string Cliente,int idproduto1)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "criarVenda";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Produto", produto);
            cmd.Parameters.AddWithValue("@Quantidade", quantidade);
            cmd.Parameters.AddWithValue("@Unidade", unidade);
            cmd.Parameters.AddWithValue("@Valor_Unitário", valorUnitario);
            cmd.Parameters.AddWithValue("@Valor_Total", valorTotal);
            cmd.Parameters.AddWithValue("@Situação", situação);
            cmd.Parameters.AddWithValue("@Pagamento", pagamento);
            cmd.Parameters.AddWithValue("@Venda_Numero", vendaNumero);
            cmd.Parameters.AddWithValue("@Operador", operador);
            cmd.Parameters.AddWithValue("@Caixa", caixa);
            cmd.Parameters.AddWithValue("@Conta", conta);
            cmd.Parameters.AddWithValue("@Finalizada", finalizada);
            cmd.Parameters.AddWithValue("@Data", data);
            cmd.Parameters.AddWithValue("@Data_Calculo", Convert.ToInt32(datacalculo));
            cmd.Parameters.AddWithValue("@Imagem", Imagem);
            cmd.Parameters.AddWithValue("@Cliente", Cliente);
            cmd.Parameters.AddWithValue("@IdProduto", idproduto1);
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
        }
        public static DataTable listaProdutos(int ident)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "listaProdutos";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProd", ident);
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
        }
        public static DataTable listaProdutosTodos()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "listaProdutosTodos";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@IdProd", ident);
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
        }
        public static DataTable apagaXML_OK()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "apagaXML_OK";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
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
        }

        public static DataTable listaXML_OK()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "listaXML_OK";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
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
        }
        public static DataTable alterarStatusXMLVinculado(int linha)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "alterarStatusXMLVinculado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@linha", linha);
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
        }

        public static DataTable criarStatusXMLVinculado(string sit)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "criarStatusXMLVinculado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sit", sit);
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
        }
        public static Object vincularXMLCod(string codFornec)
        {
            Object codFornecimento;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "vincularXMLCod";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codFornecimento", codFornec);
            codFornecimento = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return codFornecimento;
        }
        public static Object vincularXML(string ean)
        {
            Object EAN;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "vincularXML";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EAN", ean);
            EAN = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return EAN;
        }
        public static DataTable InserirXMLEstoque(string Cod_Prod, string Descrição, string Cod_EAN, string Cod_EAN_Trib, string Qtde, string Und, string Valor)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "InserirXMLEstoque";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            Valor = Valor.Replace(".", ",");
            Qtde = Qtde.Replace(".", ",");
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cod_Prod", Convert.ToInt32(Cod_Prod));
            cmd.Parameters.AddWithValue("@Descrição", Descrição);
            cmd.Parameters.AddWithValue("@Cod_EAN", Cod_EAN);
            cmd.Parameters.AddWithValue("@Cod_EAN_Trib", Cod_EAN_Trib);
            cmd.Parameters.AddWithValue("@Qtde", Convert.ToDecimal(Qtde));
            cmd.Parameters.AddWithValue("@Und", Und);
            cmd.Parameters.AddWithValue("@Valor", Convert.ToDecimal(Valor));
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
            return clientes;
        }

        public static DataTable ListarXMLEstoque()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "ListarXMLEstoque";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
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
        }
        public static Object Revisao()
        {
            Object id ;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "SELECT IDENT_CURRENT ( 'Produtos' )";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.Text;
            id = cmd.ExecuteScalar();
            int idt = Convert.ToInt32(id);
            idt++;
            id = idt;
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return id;
        }
        public static Object Numero_Titulo()
        {
            Object id;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "SELECT IDENT_CURRENT ( 'ContasReceber' )";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.Text;
            id = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return id;
        }
        public static DataTable Cadastrar_Produto(string Revisão,string CodDNF,string CodEAN,string CodEANTrib,string CodFornecimento,string Referência,
            char Inativo,string	Finalidade, string Familia,string Marca, string Modelo,string Unidade,string DescInterna,string Grade,string Gênero,
            string CF_NCM,string EX_IPI,string MoedaCompra,string MoedaFaturamento,string PesoBruto,string PesoLiquido,string Empresa,string NomeOriginalNF,
            string NomeFabricante,string Observações,string GrupoCompradores,string Garantia,string Início,string Final,string MétodoSuprimento,string Impacto,
            char Original,string DataCadastro,string UsrCadastrou,string GrupoTribSaídas,string GrupoTribEntradas,string CodServiçoSefaz,string IPI,
            string VenderPro,string ValorInicial,string ValorMédio,string DescCompra,string ValorCompra,string CustoCorrigido,char MargemInversa,
            string Margem,string ValorVenda,string VendaCorrigido,string ValorMínimo,string MargemMínima,string ValorPromoção,char Promoção,
            string GrupoCarregamento,string Múltiplo,string EstoqueINT,string EstoquePeso,string QtdReservado,string LocFisica,string DiasSemVender,
            string TempoReposição,char MarcaDiasSemVender,char TipoComissão,string ComissãoFixa)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Cadastrar_Produto";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Revisão",Convert.ToInt32( Revisão ));//1
            cmd.Parameters.AddWithValue("@CodDNF",CodDNF);//2
            cmd.Parameters.AddWithValue("@CodEAN",CodEAN );//3
            cmd.Parameters.AddWithValue("@CodEANTrib",CodEANTrib );//4
            cmd.Parameters.AddWithValue("@CodFornecimento",CodFornecimento );//5
            cmd.Parameters.AddWithValue("@Referência",Referência );//6
            cmd.Parameters.AddWithValue("@Inativo",Inativo);//7
            cmd.Parameters.AddWithValue("@Finalidade", Finalidade);//8
            cmd.Parameters.AddWithValue("@Familia",Familia );//9
            cmd.Parameters.AddWithValue("@Marca",Marca );//10
            cmd.Parameters.AddWithValue("@Modelo",Modelo );//11
            cmd.Parameters.AddWithValue("@Unidade",Unidade );//12
            cmd.Parameters.AddWithValue("@DescInterna",DescInterna );//13
            cmd.Parameters.AddWithValue("@Grade",Grade );//14
            cmd.Parameters.AddWithValue("@Gênero",Gênero );//15
            cmd.Parameters.AddWithValue("@CF_NCM",CF_NCM );//16
            cmd.Parameters.AddWithValue("@EX_IPI", EX_IPI);//17
            cmd.Parameters.AddWithValue("@MoedaCompra",MoedaCompra );//18
            cmd.Parameters.AddWithValue("@MoedaFaturamento",MoedaFaturamento );//19
            cmd.Parameters.AddWithValue("@PesoBruto", PesoBruto);//20
            cmd.Parameters.AddWithValue("@PesoLiquido", PesoLiquido);//21
            cmd.Parameters.AddWithValue("@Empresa", Empresa);//22
            cmd.Parameters.AddWithValue("@NomeOriginalNF", NomeOriginalNF);//23
            cmd.Parameters.AddWithValue("@NomeFabricante",NomeFabricante );//24
            cmd.Parameters.AddWithValue("@Observações",Observações );//25
            cmd.Parameters.AddWithValue("@GrupoCompradores",GrupoCompradores );//26
            cmd.Parameters.AddWithValue("@Garantia",Garantia );//27
            cmd.Parameters.AddWithValue("@Início",Início );//28
            cmd.Parameters.AddWithValue("@Final",Final );//29
            cmd.Parameters.AddWithValue("@MétodoSuprimento",MétodoSuprimento );//30
            cmd.Parameters.AddWithValue("@Impacto",Impacto );//31
            cmd.Parameters.AddWithValue("@Original",Original);//32
            cmd.Parameters.AddWithValue("@DataCadastro",DataCadastro );//33
            cmd.Parameters.AddWithValue("@UsrCadastrou",UsrCadastrou );//34
            cmd.Parameters.AddWithValue("@GrupoTribSaídas",GrupoTribSaídas );//35
            cmd.Parameters.AddWithValue("@GrupoTribEntradas",GrupoTribEntradas );//36
            cmd.Parameters.AddWithValue("@CodServiçoSefaz",CodServiçoSefaz );//37
            cmd.Parameters.AddWithValue("@IPI",IPI );//38
            cmd.Parameters.AddWithValue("@VenderPro",VenderPro );//39
            cmd.Parameters.AddWithValue("@ValorInicial", ValorInicial);//40
            cmd.Parameters.AddWithValue("@ValorMédio", ValorMédio);//41
            cmd.Parameters.AddWithValue("@DescCompra", DescCompra);//42
            cmd.Parameters.AddWithValue("@ValorCompra",ValorCompra);//43
            cmd.Parameters.AddWithValue("@CustoCorrigido", CustoCorrigido);//44
            cmd.Parameters.AddWithValue("@MargemInversa",MargemInversa);//45
            cmd.Parameters.AddWithValue("@Margem", Margem);//46
            cmd.Parameters.AddWithValue("@ValorVenda", ValorVenda);//47
            cmd.Parameters.AddWithValue("@VendaCorrigido",VendaCorrigido);//48
            cmd.Parameters.AddWithValue("@ValorMínimo", ValorMínimo);//49
            cmd.Parameters.AddWithValue("@MargemMínima",MargemMínima);//50
            cmd.Parameters.AddWithValue("@ValorPromoção",ValorPromoção);//51
            cmd.Parameters.AddWithValue("@Promoção",Promoção);//52
            cmd.Parameters.AddWithValue("@GrupoCarregamento",GrupoCarregamento );//53
            cmd.Parameters.AddWithValue("@Múltiplo",Múltiplo );//54
            cmd.Parameters.AddWithValue("@EstoqueINT",EstoqueINT);//55
            cmd.Parameters.AddWithValue("@EstoquePeso", EstoquePeso);//56
            cmd.Parameters.AddWithValue("@QtdReservado",QtdReservado);//57
            cmd.Parameters.AddWithValue("@LocFisica",LocFisica );//58
            cmd.Parameters.AddWithValue("@DiasSemVender",DiasSemVender);//59
            cmd.Parameters.AddWithValue("@TempoReposição",TempoReposição);//60
            cmd.Parameters.AddWithValue("@MarcaDiasSemVender",MarcaDiasSemVender);//61
            cmd.Parameters.AddWithValue("@TipoComissão",TipoComissão);//62
            cmd.Parameters.AddWithValue("@ComissãoFixa",ComissãoFixa);//63
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
            
        }


        public static DataTable Cadastrar_Produto_Editar( string Identificador, string Revisão, string CodDNF, string CodEAN, string CodEANTrib, string CodFornecimento, string Referência,
            char Inativo, string Finalidade, string Familia, string Marca, string Modelo, string Unidade, string DescInterna, string Grade, string Gênero,
            string CF_NCM, string EX_IPI, string MoedaCompra, string MoedaFaturamento, string PesoBruto, string PesoLiquido, string Empresa, string NomeOriginalNF,
            string NomeFabricante, string Observações, string GrupoCompradores, string Garantia, string Início, string Final, string MétodoSuprimento, string Impacto,
            char Original, string DataCadastro, string UsrCadastrou, string GrupoTribSaídas, string GrupoTribEntradas, string CodServiçoSefaz, string IPI,
            string VenderPro, string ValorInicial, string ValorMédio, string DescCompra, string ValorCompra, string CustoCorrigido, char MargemInversa,
            string Margem, string ValorVenda, string VendaCorrigido, string ValorMínimo, string MargemMínima, string ValorPromoção, char Promoção,
            string GrupoCarregamento, string Múltiplo, string EstoqueINT, string EstoquePeso, string QtdReservado, string LocFisica, string DiasSemVender,
            string TempoReposição, char MarcaDiasSemVender, char TipoComissão, string ComissãoFixa)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Cadastrar_Produto_Editar";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Identificador", Identificador);
            cmd.Parameters.AddWithValue("@Revisão", Convert.ToInt32(Revisão));//1
            cmd.Parameters.AddWithValue("@CodDNF", CodDNF);//2
            cmd.Parameters.AddWithValue("@CodEAN", CodEAN);//3
            cmd.Parameters.AddWithValue("@CodEANTrib", CodEANTrib);//4
            cmd.Parameters.AddWithValue("@CodFornecimento", CodFornecimento);//5
            cmd.Parameters.AddWithValue("@Referência", Referência);//6
            cmd.Parameters.AddWithValue("@Inativo", Inativo);//7
            cmd.Parameters.AddWithValue("@Finalidade", Finalidade);//8
            cmd.Parameters.AddWithValue("@Familia", Familia);//9
            cmd.Parameters.AddWithValue("@Marca", Marca);//10
            cmd.Parameters.AddWithValue("@Modelo", Modelo);//11
            cmd.Parameters.AddWithValue("@Unidade", Unidade);//12
            cmd.Parameters.AddWithValue("@DescInterna", DescInterna);//13
            cmd.Parameters.AddWithValue("@Grade", Grade);//14
            cmd.Parameters.AddWithValue("@Gênero", Gênero);//15
            cmd.Parameters.AddWithValue("@CF_NCM", CF_NCM);//16
            cmd.Parameters.AddWithValue("@EX_IPI", EX_IPI);//17
            cmd.Parameters.AddWithValue("@MoedaCompra", MoedaCompra);//18
            cmd.Parameters.AddWithValue("@MoedaFaturamento", MoedaFaturamento);//19
            cmd.Parameters.AddWithValue("@PesoBruto", PesoBruto);//20
            cmd.Parameters.AddWithValue("@PesoLiquido", PesoLiquido);//21
            cmd.Parameters.AddWithValue("@Empresa", Empresa);//22
            cmd.Parameters.AddWithValue("@NomeOriginalNF", NomeOriginalNF);//23
            cmd.Parameters.AddWithValue("@NomeFabricante", NomeFabricante);//24
            cmd.Parameters.AddWithValue("@Observações", Observações);//25
            cmd.Parameters.AddWithValue("@GrupoCompradores", GrupoCompradores);//26
            cmd.Parameters.AddWithValue("@Garantia", Garantia);//27
            cmd.Parameters.AddWithValue("@Início", Início);//28
            cmd.Parameters.AddWithValue("@Final", Final);//29
            cmd.Parameters.AddWithValue("@MétodoSuprimento", MétodoSuprimento);//30
            cmd.Parameters.AddWithValue("@Impacto", Impacto);//31
            cmd.Parameters.AddWithValue("@Original", Original);//32
            cmd.Parameters.AddWithValue("@DataCadastro", DataCadastro);//33
            cmd.Parameters.AddWithValue("@UsrCadastrou", UsrCadastrou);//34
            cmd.Parameters.AddWithValue("@GrupoTribSaídas", GrupoTribSaídas);//35
            cmd.Parameters.AddWithValue("@GrupoTribEntradas", GrupoTribEntradas);//36
            cmd.Parameters.AddWithValue("@CodServiçoSefaz", CodServiçoSefaz);//37
            cmd.Parameters.AddWithValue("@IPI", IPI);//38
            cmd.Parameters.AddWithValue("@VenderPro", VenderPro);//39
            cmd.Parameters.AddWithValue("@ValorInicial", ValorInicial);//40
            cmd.Parameters.AddWithValue("@ValorMédio", ValorMédio);//41
            cmd.Parameters.AddWithValue("@DescCompra", DescCompra);//42
            cmd.Parameters.AddWithValue("@ValorCompra", ValorCompra);//43
            cmd.Parameters.AddWithValue("@CustoCorrigido", CustoCorrigido);//44
            cmd.Parameters.AddWithValue("@MargemInversa", MargemInversa);//45
            cmd.Parameters.AddWithValue("@Margem", Margem);//46
            cmd.Parameters.AddWithValue("@ValorVenda", ValorVenda);//47
            cmd.Parameters.AddWithValue("@VendaCorrigido", VendaCorrigido);//48
            cmd.Parameters.AddWithValue("@ValorMínimo", ValorMínimo);//49
            cmd.Parameters.AddWithValue("@MargemMínima", MargemMínima);//50
            cmd.Parameters.AddWithValue("@ValorPromoção", ValorPromoção);//51
            cmd.Parameters.AddWithValue("@Promoção", Promoção);//52
            cmd.Parameters.AddWithValue("@GrupoCarregamento", GrupoCarregamento);//53
            cmd.Parameters.AddWithValue("@Múltiplo", Múltiplo);//54
            cmd.Parameters.AddWithValue("@EstoqueINT", EstoqueINT);//55
            cmd.Parameters.AddWithValue("@EstoquePeso",EstoquePeso);//56
            cmd.Parameters.AddWithValue("@QtdReservado", QtdReservado);//57
            cmd.Parameters.AddWithValue("@LocFisica", LocFisica);//58
            cmd.Parameters.AddWithValue("@DiasSemVender", DiasSemVender);//59
            cmd.Parameters.AddWithValue("@TempoReposição", TempoReposição);//60
            cmd.Parameters.AddWithValue("@MarcaDiasSemVender", MarcaDiasSemVender);//61
            cmd.Parameters.AddWithValue("@TipoComissão", TipoComissão);//62
            cmd.Parameters.AddWithValue("@ComissãoFixa", ComissãoFixa);//63
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;

        }

        public static DataTable Listar_Finalidade()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "Listar_Finalidade";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
        }
        public static DataTable ListaEventos()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "ListaEventos";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
        }
        public static DataTable ListaEventosHistorico()
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "ListaEventosHistorico";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
        }
        public static Object contadorInc()
        {
            Object num;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "contadorInc";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            num = cmd.ExecuteScalar();
            //OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            //da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return num;
        }
        
        public static Object RevisaoVenda()
        {
            Object id;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "pegarNumVenda";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            id = cmd.ExecuteScalar();
            int idt = Convert.ToInt32(id);
            id = idt;
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return id;
        }

        public static  DataTable AUXCadCriar( string storedProcedure, string descrição)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = storedProcedure;
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
                     
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descrição",Convert.ToString( descrição));
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
            
            
            
        }
        public static DataTable CriarCadNCM(string codigo_ncm, string descrição)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "CriarCadNCM";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Codigo_NCM", codigo_ncm);
            cmd.Parameters.AddWithValue("@descrição", descrição);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;



        }
        public static DataTable CriarCadGenero(string codigo, string descrição)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = "CriarCadGenero";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", codigo);
            cmd.Parameters.AddWithValue("@descrição", descrição);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;



        }
        public static DataTable AUXCadListar(string storedProcedure)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = storedProcedure;
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
        }
        public static DataTable AUXCadCriarEmpresa(string storedProcedure, string descrição, string cnpj)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = storedProcedure;
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descrição", Convert.ToString(descrição));
            cmd.Parameters.AddWithValue("@cnpj", Convert.ToString(cnpj));
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;



        }
        public static DataTable AUXCadCriarGenero(string storedProcedure, string codigo, string descrição)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            string strSQL = storedProcedure;
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codigo", Convert.ToInt32 (codigo));
            cmd.Parameters.AddWithValue("@descrição", descrição);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();

            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;



        }

        public static Object ValidarCadExclusao(string strored, string campo)
        {
            Object id;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = strored;
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@descrição", Convert.ToString(campo));
            id = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;
            return id;
        }

        public static void tipoVenda(string tipoVenda,string numvenda)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }   
            String strSQL = tipoVenda;
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumVenda", numvenda);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
           
        }
        public static void tipoVendaFiado(string cliente,string numvenda)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "tipoVendaFiado";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Cliente",cliente);
            cmd.Parameters.AddWithValue("@NumVenda", numvenda);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            
        }
        public static void OperadorCores(string operador,string cormenu,string cor2,string cor3, string cor4, string cor5)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "OperadorCores";

            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);

            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);

            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Operador", operador);
            cmd.Parameters.AddWithValue("@CorMenu", cormenu);
            cmd.Parameters.AddWithValue("@Cor2", cor2);
            cmd.Parameters.AddWithValue("@Cor3", cor3);
            cmd.Parameters.AddWithValue("@Cor4", cor4);
            cmd.Parameters.AddWithValue("@Cor5", cor5);

            cmd.ExecuteScalar();

            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            //atribui o datatable ao datagridview para exibir o resultado
            //dataGridView1.DataSource = clientes;

        }
        public static void qtdeVenda(string quantidade,string id,string valorTotal)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "qtdeVenda";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Quantidade", quantidade);
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@valorTotal", valorTotal);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            
        }
        public static void criarEvento(string eventotipo, string idprod, string desc, string datagatilho,string qtde)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "criarEvento";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventoTipo", eventotipo);
            cmd.Parameters.AddWithValue("@IdProd", idprod);
            cmd.Parameters.AddWithValue("@Descrição", desc);
            cmd.Parameters.AddWithValue("@DataGatilho", datagatilho);
            cmd.Parameters.AddWithValue("@Qtde", qtde);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
          
        }
        public static void criarEventoHistorico(string eventotipo, string idprod, string desc, string datagatilho, string qtde)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "criarEventoHistorico";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventoTipo", eventotipo);
            cmd.Parameters.AddWithValue("@IdProd", idprod);
            cmd.Parameters.AddWithValue("@Descrição", desc);
            cmd.Parameters.AddWithValue("@DataGatilho", datagatilho);
            cmd.Parameters.AddWithValue("@Qtde", qtde);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();

        }
        public static void DeletaEventos(int idevento)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "DeletaEventos";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdProd", idevento);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();

        }
        public static void OperadorCoresInsere(string operador,string cormenu,string cor2, string cor3, string cor4,string cor5)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "OperadorCoresInsere";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Operador", operador);
            cmd.Parameters.AddWithValue("@CorMenu", cormenu);
            cmd.Parameters.AddWithValue("@Cor2", cor2);
            cmd.Parameters.AddWithValue("@Cor3", cor3);
            cmd.Parameters.AddWithValue("@Cor4", cor4);
            cmd.Parameters.AddWithValue("@Cor5", cor5);
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            
        }
        
        public static DataTable CoresRetorna (string nome)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_AUX;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "OperadorCoresRetorna";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Operador", nome);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable clientes = new DataTable();
            //preenche o datatable via dataadapter
            da.Fill(clientes);
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return clientes;
        }
        public static void deletaProduto(string id)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "deletaProduto";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            
        }
        public static Object retornaIdProd(int id)
        {
            Object idP = "";
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "retornaIdProd";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idvenda", id);
            idP = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return idP;
            
        }
        public static void baixaEstoque(string id, string qtde)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "baixaEstoque";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@Qtde", Convert.ToInt32(qtde));
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
           
        }
        public static void baixaEstoqueRetorna(string id, string qtde)
        {
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "baixaEstoqueRetorna";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            cmd.Parameters.AddWithValue("@Qtde", Convert.ToInt32(qtde));
            cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            
        }
        public static Object retornaImagem(string id)
        {
            Object imagem;
            string strConnection = "";
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "local")
            {
                strConnection = "Data Source=.\\SQLEXPRESS;Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975 ;Provider=SQLOLEDB";
            }
            if (Global.Margem.ConfiguraçãoSistemaBancoDados == "rede")
            {
                string ip = Global.Margem.ConfiguraçãoSistemaBancoDadosIp;
                string porta = Global.Margem.ConfiguraçãoSistemaBancoDadosPorta;
                strConnection = "Provider=sqloledb;Network Library=DBMSSOCN;Data Source=" + ip + "," + porta + ";Initial Catalog=GC_Vendas;User ID=sa;Password=#lecoteco1975";
            }
            String strSQL = "retornaImagem";
            //cria a conexão com o banco de dados
            OleDbConnection dbConnection = new OleDbConnection(strConnection);
            //cria a conexão com o banco de dados
            OleDbConnection con = new OleDbConnection(strConnection);
            //cria o objeto command para executar a instruçao sql
            OleDbCommand cmd = new OleDbCommand(strSQL, con);
            //abre a conexao
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(id));
            imagem = cmd.ExecuteScalar();
            con.Dispose();
            con.Close();
            cmd.Dispose();
            dbConnection.Dispose();
            dbConnection.Close();
            return imagem;
        }
        
    }
}
