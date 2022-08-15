using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerias
using SGI.Data;
using System.Data;
using System.Data.OracleClient;
using SGI.App;

namespace SGI.Models
{
    public class Familia
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Familia";

        private string codigo;
        private string secuencia;
        private string descripcion;
        private string imagen;

        // Getters y Setters
        public string Codigo { get => codigo; set => codigo = value; }
        public string Secuencia { get => secuencia; set => secuencia = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Imagen { get => imagen; set => imagen = value; }


        // metodos
        // procedimiento almacenado para listar categorias de productos
        public DataTable Data()
        {
            DB.CommandType = CommandType.Text;
            return DB.GetDataTable("select secuencia, codigo, descripcion, imagen from familia");
        }

        public DataTable List()
        {
            DB.CommandType = CommandType.Text;
            return DB.GetDataTable("select codigo, descripcion, imagen from familia");
        }
         

        public string Create()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_codigo", this.Codigo);
            DB.AddParameters("v_descripcion", this.Descripcion);
            DB.AddParameters("v_imagen", this.Imagen);
            int res = DB.CRUD("sp_familia_create"); // Procedimiento almacenado agregar familia

            // mensaje con interpolacion de exito y fracaso, haciendo referencia a mensajes de la clase ClsCommon
            return (res == 1 ? $"{App.ClsCommon.RowCreated} {entity}" : App.ClsCommon.NoRowsAdded);
        }

        public string Update()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_codigo", this.Codigo);
            DB.AddParameters("v_descripcion", this.Descripcion);
            DB.AddParameters("v_imagen", this.Imagen);
            int res = DB.CRUD("sp_familia_update");

            return (res == 1 ? $"{App.ClsCommon.RowUpdated} {entity}" : App.ClsCommon.NoRowsUpdated);
        }

        public string Destroy()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("V_codigo", this.Codigo);
            int res = DB.CRUD("sp_familia_destroy");

            return (res == 1 ? $"{App.ClsCommon.RowDeleted} {entity}" : App.ClsCommon.NoRowsDeleted);
        }


        // metodo para NO permitir borrar categoria si tiene un producto asociado.
        public bool HasProduct(string familia_codigo)
        {
            //DB.AddParameters("v_codigo", familia_codigo);
            //DataTable info = DB.GetDataTable("sp_familia_hasproduct");

            // si info es mayor a cero, dara como resultado true.
            //return (info != null && info.Rows.Count > 0 ? true : false);

            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_familia_hasproduct", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_codigo_familia", OracleType.VarChar).Value = familia_codigo;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return (tabla != null && tabla.Rows.Count > 0 ? true : false);
        }

        // metodo para nor permitir duplicidad de categorias
        public bool FamiliaExists(string familia_descripcion)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_familia_exists", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_descripcion", OracleType.VarChar).Value = familia_descripcion;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();


            // si info es mayor a cero, dara como resultado true.
            return (tabla != null && tabla.Rows.Count > 0 ? true : false);
        }

        public DataTable Search(string searchText)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_familia_search", ora);
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
