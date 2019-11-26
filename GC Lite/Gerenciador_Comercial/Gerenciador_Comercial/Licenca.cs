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
    public partial class Licenca : Form
    {
        public Licenca()
        {
            InitializeComponent();
            
        }

        private void Licenca_Load(object sender, EventArgs e)
        {
            DataTable ver = DALCadastro.VersaoCheck();
            if (ver.Rows.Count > 0)
            {
                if (Convert.ToInt32( ver.Rows[0]["VersaoID"].ToString()) == 1001 && ver.Rows[0]["Cliente"].ToString() == "Mercearia Siqueira")
                {
                    label10.Text = ver.Rows[0]["Cliente"].ToString();
                }
                if (Convert.ToInt32(ver.Rows[0]["VersaoID"].ToString()) != 1001 || ver.Rows[0]["Cliente"].ToString() != "Mercearia Siqueira")
                {
                    MessageBox.Show("Informações sobre a versão da licença inválidas.\nFavor entrar em contato com o desenvolvedor do sistema.");
                    this.Close();
                    return;
                }
                
            }
            if (ver.Rows.Count <= 0)
            {
                MessageBox.Show("Informações sobre a versão da licença inexistentes .\nFavor entrar em contato com o desenvolvedor do sistema.");
                this.Close();
                return;
            }
            webBrowser1.Navigate(new Uri("http://lmr-informatica.azurewebsites.net/chave.aspx"));
            
            label4.Text = Environment.MachineName.ToString() + "      /    Logon Windows :  " + Environment.UserName.ToString();
            label5.Text = Environment.OSVersion.ToString();

            if (Environment.Is64BitOperatingSystem == true)
            {
                label7.Text = "Sistema Operacional de 64 bits";
            }
            else
            {
                label7.Text = "Sistema Operacional de 32 bits";
            }


            string testa = Convert.ToString(DALCadastro.testaLicença());
            if (String.IsNullOrEmpty(testa) == true)
            {
                label2.Text = "Licença do sistema expira em: Licença não Instalada!" ;
                                
            }
            else
            {
                //data limite
                string x = Convert.ToString(DALCadastro.ValidaLicença("X"));

                int resultX = Convert.ToInt32(x) / 77;

                string y = Convert.ToString(DALCadastro.ValidaLicença("Y"));
                int resultY = Convert.ToInt32(y) / 133;

                string z = Convert.ToString(DALCadastro.ValidaLicença("Z"));
                int resultZ = Convert.ToInt32(z) / 55;

                x = "20" + Convert.ToString(resultX);
                resultX = Convert.ToInt32(x);

                DateTime data1 = new DateTime(resultX, resultY, resultZ, 20, 00, 00);

                label2.Text = "Licença do sistema expira em: " + Convert.ToString(data1);
            }
            
            
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form info = new InfoOS();
            info.ShowDialog();
        }
    }
}
