using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Librerias
using ComponentFactory.Krypton.Toolkit;

namespace SGI
{
    public partial class Form1 : KryptonForm
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD= sgi; USER ID= sgi;");
            ora.Open();
            if(ora.State == ConnectionState.Open)
            {
                MessageBox.Show("Conectado");
                ora.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
