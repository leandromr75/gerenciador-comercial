using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using Zen.Barcode;



namespace Gerenciador_Comercial
{
    public partial class EmuladorSAT : Form
    {
        public EmuladorSAT()
        {
            InitializeComponent();
        }
       
        int numsess = 1;
        
        string chave2 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            
            DataTable sat = DALCadastro.VerificaSAT(Convert.ToInt32(Global.Margem.IdProdSAT));
            if (sat.Rows.Count == 1)
            {
                label3.Text = "";
                string message = "O Emulador precisa estar executando para o teste.\nPodemos continuar?";
                string caption = "Emulador SAT";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    string codativação = "123456789";
                                        
                    string sessao = "";
                    GeraSAT_EMU gera = new GeraSAT_EMU(); 
                    //IntPtr teste = SAT_Emulador_Funcoes.ConsultarSAT(numsess);
                    //int num = Marshal.ReadInt32(teste);

                    
                    

                    
                    IntPtr recebe =  SAT_Emulador_Funcoes.EnviarDadosVenda(numsess, codativação,gera.EnviaXML(Convert.ToInt32(Global.Margem.IdProdSAT),"emulador"));
                    //IntPtr recebe = SAT_Emulador_Funcoes.EnviarDadosVenda(numsess, codativação, gera.EnviaXML(20, "produção", "44"));
                    
                    string stringB = Marshal.PtrToStringAnsi(recebe);
                    using (StreamWriter writer = new StreamWriter("Cfe.txt"))
                    {
                        writer.Write(stringB.ToString());
                    }

                    string time = "";
                    string chave = "";
                    string total = "";
                    string assinatura = "";
                    string sucesso = "";
                    int barra = 0;
                    for (int i = 0; i < stringB.Length; i++)
                    {
                        
                        
                        if (stringB.Substring(i , 1 ) == "|")
                        {
                                barra++;
                        }
                        if (barra < 1)
                        {
                            label3.Text += stringB.Substring(i, 1);
                        }
                        if (barra <= 4)
                        {
                            sucesso += stringB.Substring(i, 1);
                        }
                        if (barra == 7)
                        {
                            time += stringB.Substring(i, 1);
                        }
                        if (barra == 8)
                        {
                            chave += stringB.Substring(i, 1);
                        }
                        if (barra == 9)
                        {
                            total += stringB.Substring(i , 1);
                        }
                        if (barra == 11)
                        {
                            assinatura += stringB.Substring(i, 1);
                        }
                        
                    }
                    
                    string url = chave + time + total + assinatura;
                    QRCodeEncoder qrencod = new QRCodeEncoder();
                    Bitmap qrcode = qrencod.Encode(url);
                    pictureBox2.Image = qrcode as Image;
                    chave = chave.Replace("|","");
                    chave2 = chave;
                    string caminho = chave;
                    
                    chave = chave.Replace("C", "");
                    chave = chave.Replace("F", "");
                    chave = chave.Replace("e", "");
                    
                    Code128BarcodeDraw cod128 = new Code128BarcodeDraw(Code128Checksum.Instance);
                    if (String.IsNullOrEmpty(chave) == false)
                    {
                        pictureBox1.Image = cod128.Draw(chave, 50, 1);    
                    }
                    else
                    {
                        return;
                    }                   
                    
                    if (Convert.ToString(numsess).Length == 1)
                    {
                        sessao = "00000" + Convert.ToString(numsess);
                    }
                    if (Convert.ToString(numsess).Length == 2)
                    {
                        sessao = "0000" + Convert.ToString(numsess);
                    }
                    if (Convert.ToString(numsess).Length == 3)
                    {
                        sessao = "000" + Convert.ToString(numsess);
                    }
                    if (Convert.ToString(numsess).Length == 4)
                    {
                        sessao = "00" + Convert.ToString(numsess);
                    }
                    if (Convert.ToString(numsess).Length == 5)
                    {
                        sessao = "0" + Convert.ToString(numsess);
                    }
                    if (Global.Margem.xProd.Length >= 15)
                    {
                        label18.Text = "001 7890000000001 " + Global.Margem.xProd.Substring(0, 15) + " 1 pcX0,00 T 18% 0,00";    
                    }
                    if (Global.Margem.xProd.Length < 15)
                    {
                        label18.Text = "001 7890000000001 " + Global.Margem.xProd.Substring(0, Global.Margem.xProd.Length) + " 1 pcX0,00 T 18% 0,00";
                    }
                    label21.Text = chave;
                    //System.Diagnostics.Process.Start("C:\\SAT\\CFes\\" + caminho + ".XML");
                    //webBrowser1.Navigate(new Uri("C:\\SAT\\CFes\\" + caminho + ".XML"));
                    string caminho2 = caminho.Replace("C","A");
                    caminho2 = caminho2.Replace("F","D");
                    caminho2 = caminho2.Replace("e","");
                    // caminho e nome atual do arquivo
                    string antigo = "C:\\SAT\\CFes\\" + caminho + ".XML";

                    string path = Directory.GetCurrentDirectory();
                    // caminho e novo nome do arquivo
                    string novo = path + "\\SAT_EMU\\copias_de_segurança\\Emitidos\\" + caminho2 + ".XML";

                    // vamos renomear o arquivo
                    File.Move(antigo, novo);
                    webBrowser1.Navigate(new Uri(novo));
                    numsess = numsess + 1;
                    MessageBox.Show(sucesso + "\nCFe" + chave);
                    button2.Visible = true;

                    
                }
            }
            

        }

        private void EmuladorSAT_Load(object sender, EventArgs e)
        {
            textBox2.Text = Global.Margem.IdProdSAT;
            textBox1.Text = Global.Margem.xProd;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "";
            geraSAT ger = new geraSAT();
            MessageBox.Show(Convert.ToString(numsess) + "  " +  chave2 );
            string cod = "#lecoteco1975#";
            
            IntPtr rec = SAT_Emulador_Funcoes.CancelarUltimaVenda(numsess,cod,chave2,ger.CancelaVenda_XML(chave2,"emulador"));
            
            string stringB = Marshal.PtrToStringAnsi(rec);
            using (StreamWriter writer = new StreamWriter("CfeCancelado.txt"))
            {
                writer.Write(stringB.ToString());
            }
            string time = "";
            string chave = "";
            string total = "";
            string assinatura = "";
            string sucesso = "";
            int barra = 0;
           
            for (int i = 0; i < stringB.Length; i++)
            {


                if (stringB.Substring(i, 1) == "|")
                {
                    barra++;
                }
                if (barra < 1)
                {
                    label3.Text += stringB.Substring(i, 1);
                }
                if (barra <= 4)
                {
                    sucesso += stringB.Substring(i, 1);
                }
                if (barra == 7)
                {
                    time += stringB.Substring(i, 1);
                }
                if (barra == 8)
                {
                    chave += stringB.Substring(i, 1);
                }
                if (barra == 9)
                {
                    total += stringB.Substring(i, 1);
                }
                if (barra == 11)
                {
                    assinatura += stringB.Substring(i, 1);
                }

            }

            string url = chave + time + total + assinatura;
            QRCodeEncoder qrencod = new QRCodeEncoder();
            Bitmap qrcode = qrencod.Encode(url);
            pictureBox2.Image = qrcode as Image;
            
            chave = chave.Replace("|", "");
            chave2 = chave;
            string caminho = chave;

            chave = chave.Replace("C", "");
            chave = chave.Replace("F", "");
            chave = chave.Replace("e", "");

            Code128BarcodeDraw cod128 = new Code128BarcodeDraw(Code128Checksum.Instance);
            pictureBox1.Image = cod128.Draw(chave, 50, 1);
           
            string caminho2 = caminho.Replace("C", "A");
            caminho2 = caminho2.Replace("F", "D");
            caminho2 = caminho2.Replace("e", "C");
            
            // caminho e nome atual do arquivo
            string antigo = "C:\\SAT\\CFesCancelados\\" + caminho + ".XML";

            string path = Directory.GetCurrentDirectory();
            // caminho e novo nome do arquivo
            string novo = path + "\\SAT_EMU\\copias_de_segurança\\Cancelados\\" + caminho2 + ".XML";
            
            // vamos renomear o arquivo
            File.Move(antigo, novo);
            webBrowser1.Navigate(new Uri(novo));
            label21.Text = chave;
            numsess = numsess + 1;
            MessageBox.Show(sucesso + "\nCFe" + chave);
            button2.Visible = false;
            numsess++;
        }
    }
}
