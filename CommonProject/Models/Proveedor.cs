using CommonProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.Models
{
    public class Proveedor
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Proveedores";

        private string rut;
        private string secuencia;
        private string razon_social;
        private string giro;
        private string direccion;
        private string comuna;
        private string ciudad;
        private int telefono;
        private string contacto;

        public string Rut { get => rut; set => rut = value; }
        public string Secuencia { get => secuencia; set => secuencia = value; }
        public string Razon_social { get => razon_social; set => razon_social = value; }
        public string Giro { get => giro; set => giro = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Comuna { get => comuna; set => comuna = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Contacto { get => contacto; set => contacto = value; }

        public DataTable Data()
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD= sgi; USER ID= sgi;");
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_proveedores_data", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        }

        public bool SearchRut(string rut_)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD= sgi; USER ID= sgi;");
            ora.Open();
            OracleCommand comando = new OracleCommand($"select rut from proveedores where rut = '{rut_}'", ora);
            comando.CommandType = System.Data.CommandType.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            //return tabla;
            return (tabla != null && tabla.Rows.Count > 0 ? true : false);
        }

        public string Create()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_rut", this.Rut);
            DB.AddParameters("v_razon_social", this.Razon_social);
            DB.AddParameters("v_giro", this.Giro);
            DB.AddParameters("v_direccion", this.Direccion);
            DB.AddParameters("v_comuna", this.Comuna);
            DB.AddParameters("v_ciudad", this.Ciudad);
            DB.AddParameters("v_telefono", this.Telefono);
            DB.AddParameters("v_contacto", this.Contacto);
            int res = DB.CRUD("sp_proveedores_create"); // Procedimiento almacenado agregar proveedor

            // mensaje con interpolacion de exito y fracaso, haciendo referencia a mensajes de la clase ClsCommon
            return (res == 1 ? $"{App.ClsCommon.RowCreated} {entity}" : App.ClsCommon.NoRowsAdded);
        }

        public string Update()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_rut", this.Rut);
            DB.AddParameters("v_razon_social", this.Razon_social);
            DB.AddParameters("v_giro", this.Giro);
            DB.AddParameters("v_direccion", this.Direccion);
            DB.AddParameters("v_comuna", this.Comuna);
            DB.AddParameters("v_ciudad", this.Ciudad);
            DB.AddParameters("v_telefono", this.Telefono);
            DB.AddParameters("v_contacto", this.Contacto);
            int res = DB.CRUD("sp_proveedores_update");

            return (res == 1 ? $"{App.ClsCommon.RowUpdated} {entity}" : App.ClsCommon.NoRowsUpdated);
        }

        public string Destroy()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_codigo", this.Rut);
            int res = DB.CRUD("sp_proveedores_destroy");

            return (res == 1 ? $"{App.ClsCommon.RowDeleted} {entity}" : App.ClsCommon.NoRowsDeleted);
        }

        public DataTable Search(string searchText)
        {
            OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD= sgi; USER ID= sgi;");
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_proveedores_search", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_palabra", OracleType.VarChar).Value = searchText;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        }
    }
}
