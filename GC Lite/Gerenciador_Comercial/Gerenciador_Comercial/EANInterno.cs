using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.BarCode;

namespace Gerenciador_Comercial
{
    public partial class EANInterno : Form
    {
        public EANInterno(string desc,string num)
        {
            InitializeComponent();
            textBox1.Text = desc;
            textBox2.Text = num;
            BarCodeBuilder bb = new BarCodeBuilder();

            //Set the Code text for the barcode
            bb.CodeText = textBox2.Text;
            pictureBox1.Image = bb.BarCodeImage;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            BarCodeBuilder bb = new BarCodeBuilder();

            //Set the Code text for the barcode
            bb.CodeText = textBox2.Text;
            pictureBox1.Image = bb.BarCodeImage;
            
            bb.Save("CodeBar\\" + textBox2.Text + ".bmp",bb.BarCodeImage.RawFormat);
            Global.Margem.CodeBarURL = "CodeBar\\" + textBox2.Text + ".bmp";
            Global.Margem.CodeBarTexto = textBox1.Text;
            
            DALCadastro.InsereImpressao("ImprimeCodeBar");
            //System.Diagnostics.Process.Start(Global.Margem.CodeBarURL);
            MessageBox.Show("Código de barras enviado para a impressora");
            this.Close();
        }
    }
}
