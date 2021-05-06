using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Librerias


namespace SGI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            //OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD= hr; USER ID= hr;");
            //ora.Open();
            MessageBox.Show("Conectado");
            //ora.Close();
        }
    }
}
