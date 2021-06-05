using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerias
using CommonProject.Data;
using System.Data;
using System.Data.OracleClient;

namespace CommonProject.Models
{
    public class Familia
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Familia";

        private string codigo;
        private int secuencia;
        private string descripcion;
        private string imagen;

        // Getters y Setters
        public string Codigo { get => codigo; set => codigo = value; }
        public int Secuencia { get => secuencia; set => secuencia = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Imagen { get => imagen; set => imagen = value; }


        // metodos
        // procedimiento almacenado para listar categorias de productos
        public DataTable Data() => DB.GetDataTable("select * from familia");

        public DataTable List()
        {
            DB.CommandType = CommandType.Text;
            return DB.GetDataTable("select * from familia");
        }
         

        public string Create()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_codigo", this.Codigo);
            DB.AddParameters("v_descripcion", this.Descripcion);
            int res = DB.CRUD("sp_familia_create"); // Procedimiento almacenado agregar familia

            // mensaje con interpolacion de exito y fracaso, haciendo referencia a mensajes de la clase ClsCommon
            return (res == 1 ? $"{App.ClsCommon.RowCreated} {entity}" : App.ClsCommon.NoRowsAdded);
        }

        public string Update()
        {
            DB.AddParameters("v_codigo", this.Codigo);
            DB.AddParameters("v_descripcion", this.Descripcion);
            int res = DB.CRUD("sgi.sp_familia_update");

            return (res == 1 ? $"{App.ClsCommon.RowUpdated} {entity}" : App.ClsCommon.NoRowsUpdated);
        }

        public string Destroy()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("V_codigo", this.Codigo);
            int res = DB.CRUD("sp_familia_destroy");

            return (res == 1 ? $"{App.ClsCommon.RowDeleted} {entity}" : App.ClsCommon.NoRowsDeleted);
        }

        public DataTable Search(string searchText)
        {
            DB.AddParameters("v_palabra", searchText);

            return DB.GetDataTable("sp_familia_search");
        }


        // metodo para NO permitir borrar categoria si tiene un producto asociado.
        public bool HasProduct(int familia_codigo)
        {
            DB.AddParameters("v_codigo", familia_codigo);
            DataTable info = DB.GetDataTable("sp_familia_hasproduct");

            // si info es mayor a cero, dara como resultado true.
            return (info != null && info.Rows.Count > 0 ? true : false);
        }

        // metodo para nor permitir duplicidad de categorias
        public bool FamiliaExists(int descripcion)
        {
            DB.AddParameters("v_descripcion", descripcion);
            DataTable info = DB.GetDataTable("sp_familia_exists");

            // si info es mayor a cero, dara como resultado true.
            return (info != null && info.Rows.Count > 0 ? true : false);
        }




    }
}
