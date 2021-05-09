using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerias
using CommonProject.Data;
using System.Data;

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
        public DataTable Data() => DB.GetDataTable("sp_familia_data");

        public DataTable List() => DB.GetDataTable("sp_familia_list");

        public string Create()
        {
            DB.AddParameters("codigo_", this.Codigo);
            DB.AddParameters("descripcion_", this.Descripcion);
            int res = DB.CRUD("sp_familia_create"); // Procedimiento almacenado agregar categoria

            // mensaje con interpolacion de exito y fracaso, haciendo referencia a mensajes de la clase ClsCommon
            return (res == 1 ? $"{App.ClsCommon.RowCreated} {entity}" : App.ClsCommon.NoRowsAdded);
        }

        public string Update()
        {
            DB.AddParameters("codigo_", this.Codigo);
            DB.AddParameters("descripcion_", this.Descripcion);
            int res = DB.CRUD("sp_familia_update");

            return (res == 1 ? $"{App.ClsCommon.RowUpdated} {entity}" : App.ClsCommon.NoRowsUpdated);
        }

        public string Destroy()
        {
            DB.AddParameters("codigo_", this.Codigo);
            int res = DB.CRUD("sp_familia_destroy");

            return (res == 1 ? $"{App.ClsCommon.RowDeleted} {entity}" : App.ClsCommon.NoRowsDeleted);
        }

        public DataTable Search(string searchText)
        {
            DB.AddParameters("txt", searchText);

            return DB.GetDataTable("sp_familia_search");
        }


        // metodo para NO permitir borrar categoria si tiene un producto asociado.
        public bool HasProduct(int familia_codigo)
        {
            DB.AddParameters("codigo_", familia_codigo);
            DataTable info = DB.GetDataTable("sp_familia_hasproduct");

            // si info es mayor a cero, dara como resultado true.
            return (info != null && info.Rows.Count > 0 ? true : false);
        }

        // metodo para nor permitir duplicidad de categorias
        public bool FamiliaExists(int descripcion)
        {
            DB.AddParameters("descripcion_", descripcion);
            DataTable info = DB.GetDataTable("sp_familia_exists");

            // si info es mayor a cero, dara como resultado true.
            return (info != null && info.Rows.Count > 0 ? true : false);
        }




    }
}
