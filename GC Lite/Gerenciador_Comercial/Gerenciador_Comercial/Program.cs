using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

                         //Pega o nome do processo deste programa
                string TelaPrincipal = Process.GetCurrentProcess().ProcessName;

                //Busca os processos com este nome que estão em execução
                Process[] processos = Process.GetProcessesByName(TelaPrincipal);

                //Se já houver um aberto
                if (processos.Length > 1)
                {
                    //Mostra mensagem de erro e finaliza
                    MessageBox.Show("Não é possível abrir duas instâncias deste programa.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
                //Caso contrário continue normalmente
                else
                {
                    Global.Margem.ConfiguraçãoSistemaBancoDados = "local";
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    DataTable ver = DALCadastro.VersaoCheck();
                    if (ver.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(ver.Rows[0]["VersaoID"].ToString()) == 1001 && ver.Rows[0]["Cliente"].ToString() == "Mercearia Siqueira")
                        {
                            Form formPrincipal = new TelaPrincipal();
                            //Faz a chamada ao gerenciador de formulário
                            GerenciadorDeFormulario.Abre(formPrincipal);
                            Application.Run(formPrincipal);
                        }
                        if (Convert.ToInt32(ver.Rows[0]["VersaoID"].ToString()) != 1001 || ver.Rows[0]["Cliente"].ToString() != "Mercearia Siqueira")
                        {
                            MessageBox.Show("Informações sobre a versão da licença inválidas.\nFavor entrar em contato com o desenvolvedor do sistema.");
                            Application.Exit();
                            return;
                        }

                    }
                    if (ver.Rows.Count <= 0)
                    {
                        MessageBox.Show("Informações sobre a versão da licença inexistentes .\nFavor entrar em contato com o desenvolvedor do sistema.");
                        Application.Exit();
                        return;
                    }                  
                    
                    
                }

                
            
            
        }
    }
}
