using SGI.App;
using SGI.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Models
{
    public class Cliente
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Clientes";


        private string rut;
        private string nombre;
        private string direccion;
        private string comuna;
        private string ciudad;
        private decimal telefono;

        public string Rut { get => rut; set => rut = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Comuna { get => comuna; set => comuna = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public decimal Telefono { get => telefono; set => telefono = value; }
        
        #region 'METODOS'

        public DataTable Data()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_clientes_data", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        } // LISTAR TODOS LOS CLIENTES 

        public bool SearchRut(string rut_cliente)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand($"select rut from clientes where rut = '{rut_cliente}'", ora);
            comando.CommandType = System.Data.CommandType.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return (tabla != null && tabla.Rows.Count > 0 ? true : false);
        } // BUSCAR RUT DEL CLIENTE PARA VERIFICAR SI EXISTE

        public string Create()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_rut", this.Rut);
            DB.AddParameters("v_nombre", this.Nombre);
            DB.AddParameters("v_direccion", this.Direccion);
            DB.AddParameters("v_comuna", this.Comuna);
            DB.AddParameters("v_ciudad", this.Ciudad);
            DB.AddParameters("v_telefono", this.Telefono);
            int res = DB.CRUD("sp_clientes_create");

            return (res == 1 ? $"{ App.ClsCommon.RowCreated } { entity } " : App.ClsCommon.NoRowsAdded);
        } // CREAR CLIENTE

        public string Update()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_rut", this.Rut);
            DB.AddParameters("v_nombre", this.Nombre);
            DB.AddParameters("v_direccion", this.Direccion);
            DB.AddParameters("v_comuna", this.Comuna);
            DB.AddParameters("v_ciudad", this.Ciudad);
            DB.AddParameters("v_telefono", this.Telefono);
            int res = DB.CRUD("sp_clientes_update");

            return (res == 1 ? $"{ App.ClsCommon.RowUpdated } { entity } " : App.ClsCommon.NoRowsUpdated);
        } // ACTUALIZAR CLIENTE

        public string Destroy()
        {
            
            DB.AddParameters("v_rut", this.Rut);
            int res = DB.CRUD("sp_clientes_destroy");
            return (res == 1 ? $"{ App.ClsCommon.RowDeleted } { entity } " : App.ClsCommon.NoRowsDeleted);

        } // ELIMINAR CLIENTE

        #endregion
    }
}
