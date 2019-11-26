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
    public partial class CadCores : Form
    {
        public CadCores()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
                panel2.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog1.Color;
                panel3.BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.BackColor = colorDialog1.Color;
                tabPage1.BackColor = colorDialog1.Color;
                tabPage2.BackColor = colorDialog1.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.BackColor = colorDialog1.Color;
                panel4.BackColor = colorDialog1.Color;
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
                panel2.BackColor = colorDialog1.Color;
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog1.Color;
                panel3.BackColor = colorDialog1.Color;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.BackColor = colorDialog1.Color;
                tabPage1.BackColor = colorDialog1.Color;
                tabPage2.BackColor = colorDialog1.Color;
            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox4.BackColor = colorDialog1.Color;
                panel4.BackColor = colorDialog1.Color;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable cor = DALCadastro.CoresRetorna(Global.Margem.Operador);
            if (cor.Rows.Count <= 0)
            {
                int cor1 = Convert.ToInt32(pictureBox1.BackColor.ToArgb());
                int cor2 = Convert.ToInt32(pictureBox2.BackColor.ToArgb());
                int cor3 = Convert.ToInt32(pictureBox3.BackColor.ToArgb());
                int cor4 = Convert.ToInt32(pictureBox4.BackColor.ToArgb());
                int cor5 = Convert.ToInt32(pictureBox8.BackColor.ToArgb());
                DALCadastro.OperadorCoresInsere(Global.Margem.Operador, Convert.ToString(cor1), Convert.ToString(cor2), Convert.ToString(cor3),
                    Convert.ToString(cor4), Convert.ToString(cor5));
                
                MessageBox.Show("Aparência alterada com sucesso!");
            }
            if (cor.Rows.Count > 0)
            {
                int cor1 = Convert.ToInt32(pictureBox1.BackColor.ToArgb());
                int cor2 = Convert.ToInt32(pictureBox2.BackColor.ToArgb());
                int cor3 = Convert.ToInt32(pictureBox3.BackColor.ToArgb());
                int cor4 = Convert.ToInt32(pictureBox4.BackColor.ToArgb());
                int cor5 = Convert.ToInt32(pictureBox8.BackColor.ToArgb());
                DALCadastro.OperadorCores(Global.Margem.Operador, Convert.ToString(cor1), Convert.ToString(cor2), Convert.ToString(cor3),
                    Convert.ToString(cor4),Convert.ToString( cor5 ));
                
                MessageBox.Show("Aparência alterada com sucesso!");
            }
            
        }

        private void CadCores_Load(object sender, EventArgs e)
        {
            DataTable corDefault = DALCadastro.CoresRetorna("Default");
            
            if (corDefault.Rows.Count <= 0)
            {
                int cor11 = Convert.ToInt32(pictureBox1.BackColor.ToArgb());
                int cor21 = Convert.ToInt32(pictureBox2.BackColor.ToArgb());
                int cor31 = Convert.ToInt32(pictureBox3.BackColor.ToArgb());
                int cor41 = Convert.ToInt32(pictureBox4.BackColor.ToArgb());

                int cor51 = Convert.ToInt32(pictureBox8.BackColor.ToArgb());

                DALCadastro.OperadorCoresInsere("Default", Convert.ToString(cor11), Convert.ToString(cor21), Convert.ToString(cor31),
                    Convert.ToString(cor41), Convert.ToString(cor51));
            }
            textBox2.Text = Global.Margem.Operador;
            DataTable cor = DALCadastro.CoresRetorna(Global.Margem.Operador);
            if (cor.Rows.Count > 0)
            {
                panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["CorMenu"].ToString()));
                pictureBox1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["CorMenu"].ToString()));
                panel3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor2"].ToString()));
                pictureBox2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor2"].ToString()));
                tabPage1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor3"].ToString()));
                tabPage2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor3"].ToString()));
                pictureBox3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor3"].ToString()));
                panel4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor4"].ToString()));
                pictureBox4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor4"].ToString()));
                panel6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor5"].ToString()));
                pictureBox8.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor5"].ToString()));
            }
            if (cor.Rows.Count <= 0)
            {
                int cor1 = Convert.ToInt32(pictureBox1.BackColor.ToArgb());
                int cor2 = Convert.ToInt32(pictureBox2.BackColor.ToArgb());
                int cor3 = Convert.ToInt32(pictureBox3.BackColor.ToArgb());
                int cor4 = Convert.ToInt32(pictureBox4.BackColor.ToArgb());

                int cor5 = Convert.ToInt32(pictureBox8.BackColor.ToArgb());

                DALCadastro.OperadorCoresInsere(Global.Margem.Operador, Convert.ToString(cor1), Convert.ToString(cor2), Convert.ToString(cor3),
                    Convert.ToString(cor4), Convert.ToString(cor5));
            }
            
            
             
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string def = "Default";
            DataTable cor = DALCadastro.CoresRetorna(def);
            if (cor.Rows.Count > 0)
            {
                panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["CorMenu"].ToString()));
                pictureBox1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["CorMenu"].ToString()));
                panel3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor2"].ToString()));
                pictureBox2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor2"].ToString()));
                tabPage1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor3"].ToString()));
                tabPage2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor3"].ToString()));
                pictureBox3.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor3"].ToString()));
                panel4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor4"].ToString()));
                pictureBox4.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor4"].ToString()));
                panel6.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor5"].ToString()));
                pictureBox8.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(cor.Rows[0]["Cor5"].ToString()));
                MessageBox.Show("Aparência original restaurada");
                return;
            }
            if (cor.Rows.Count <= 0)
            {
                int cor1 = Convert.ToInt32(pictureBox1.BackColor.ToArgb());
                int cor2 = Convert.ToInt32(pictureBox2.BackColor.ToArgb());
                int cor3 = Convert.ToInt32(pictureBox3.BackColor.ToArgb());
                int cor4 = Convert.ToInt32(pictureBox4.BackColor.ToArgb());

                int cor5 = Convert.ToInt32(pictureBox8.BackColor.ToArgb());

                DALCadastro.OperadorCoresInsere(def, Convert.ToString(cor1), Convert.ToString(cor2), Convert.ToString(cor3),
                    Convert.ToString(cor4), Convert.ToString(cor5));
                MessageBox.Show("Aparência original restaurada");
            }
            

            




            
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox8.BackColor = colorDialog1.Color;
                panel6.BackColor = colorDialog1.Color;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox8.BackColor = colorDialog1.Color;
                panel6.BackColor = colorDialog1.Color;
            }
        }
    }
}
