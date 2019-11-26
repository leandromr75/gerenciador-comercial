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
    public partial class AuxCadCalculaMargem : Form
    {
        public AuxCadCalculaMargem(string identificador, string produto, string valorCompra, string valorvenda)
        {
            InitializeComponent();
            this.textBox1.Text = identificador;
            this.textBox2.Text = produto;
            this.textBox8.Text = valorCompra;
            this.textBox6.Text = valorvenda;
        }
        string margemTemp = "";
        public AuxCadCalculaMargem()
        {

        }

        private void AuxCadCalculaMargem_Load(object sender, EventArgs e)
        {
            textBox5.Text = "40";
            textBox5.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Global.Margem.MargemM = margemTemp;
            Global.Margem.Valor = textBox6.Text;
            Global.Margem.MargemLocal = "sim";
            button1.Visible = false;
            this.Close();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            string MarGem = "";
            
            
            if (String.IsNullOrEmpty(textBox5.Text) == false)
            {
                int qtde;
                if (Int32.TryParse(textBox5.Text.Trim(), out qtde) == false)
                {
                    MessageBox.Show("O campo margem aceita somente valores numéricos");
                    textBox5.Text = "";
                    textBox5.Focus();
                    return;

                }
                MarGem = textBox5.Text;
                margemTemp = textBox5.Text;
                margemTemp = margemTemp + ",00";
                if (Global.Margem.MargemTipo == "inversa")
                {
                    decimal valorCusto = Convert.ToDecimal(textBox8.Text);
                    if (MarGem.Length <= 2)
                    {
                        MarGem = "0," + MarGem.Replace(",", "");
                        
                    }
                    if (MarGem.Length == 3)
                    {
                        MessageBox.Show("Margem inversa não permitida acima de 99%");
                        
                        return;
                    }

                    decimal margen = Convert.ToDecimal(MarGem);
                    decimal num = 1;
                    decimal divisor = num - margen;

                    decimal venda = valorCusto / divisor;
                    textBox6.Text = Convert.ToString(Math.Round(venda, 2));
                   
                }
                if (Global.Margem.MargemTipo == "normal")
                {

                        decimal valorCusto = Convert.ToDecimal(textBox8.Text);
                        if (MarGem.Length == 2)
                        {
                            MarGem = "1," + MarGem;
                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "1")
                            {
                                MarGem = "2," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "2")
                            {
                                MarGem = "3," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "3")
                            {
                                MarGem = "4," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "4")
                            {
                                MarGem = "5," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "5")
                            {
                                MarGem = "6," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "6")
                            {
                                MarGem = "7," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "7")
                            {
                                MarGem = "8," + MarGem.Substring(1, 2);
                            }

                        }
                        if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "8")
                            {
                                MarGem = "9," + MarGem.Substring(1, 2);
                            }

                        } if (MarGem.Length == 3)
                        {
                            if (MarGem.Substring(0, 1) == "9")
                            {
                                
                                MessageBox.Show("Neste caso, é preciso fazer alteração manual do valor de venda");
                                
                                return;


                            }

                        }
                        MessageBox.Show(MarGem);
                        decimal margen = Convert.ToDecimal(MarGem);
                        decimal venda = valorCusto * margen;
                        textBox6.Text = Convert.ToString(Math.Round(venda, 2));
                        
                        //Global.Margem.MargemTipo = "";
                        
                    }
                
            }
            button1.Visible = true;
            
        }
               

        private void textBox5_Enter(object sender, EventArgs e)
        {
            button1.Visible = false;
            textBox5.Text = "";
        }
        
    
     }

}
