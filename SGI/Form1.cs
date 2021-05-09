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
            //OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD= sgi; USER ID= sgi;");
            CommonProject.Data.DbHelper ora = new CommonProject.Data.DbHelper(CommonProject.App.ClsCommon.ConnectionString, CommandType.StoredProcedure);

            CommonProject.Models.Familia familia = new CommonProject.Models.Familia();
            


            ora.Connection.Open();
            if(ora.Connection.State == ConnectionState.Open)
            {
                familia.Codigo = "PRUEBA3";
                familia.Descripcion = "PRUEBA3";
                familia.Create();
                /*
                OracleCommand comando = new OracleCommand("sp_familia_create", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("v_codigo", OracleType.VarChar).Value = "PRUEBA2";
                comando.Parameters.Add("v_descripcion", OracleType.VarChar).Value = "PRUEBA";
                comando.ExecuteNonQuery();
                */
                ora.Connection.Close();
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
