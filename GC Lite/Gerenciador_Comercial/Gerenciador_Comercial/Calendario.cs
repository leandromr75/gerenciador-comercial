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
    public partial class Calendario : Form
    {
        public Calendario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(label1.Text) == false)
            {
                
                
                
                Global.Margem.Calendario = label1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("Precisa selecionar uma data");
            }
            
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label1.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void Calendario_Load(object sender, EventArgs e)
        {
            if (Global.Margem.Calendario1 == "")
            {
                monthCalendar1.MinDate = monthCalendar1.SelectionStart.Date;    
            }
            
        }
    }
}
