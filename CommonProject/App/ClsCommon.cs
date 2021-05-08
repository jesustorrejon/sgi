using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.App
{
    class ClsCommon
    {
        public static int flag = 0;
        public static bool payCommited = false;
        public static string FileName_Ticket;

        public static readonly string version = "1.0.1";
        public static readonly string app = "Sistema Almacen Yuyitos";

        public static string Server = "xe";
        public static string Database = "sgi";
        public static string User = "sgi";
        public static string Password = "sgi";
        public static string ConnectionString = $"Server={Server};Database={Database};User id={User};Password{Password}";

        // mensajes de CRUD
        public static readonly string NoRowsAfected = "Ningun registro eliminado";
        public static readonly string NoRowsAdded = "No se guardó el registro, intenta nuevamente";
        public static readonly string NoRowsUpdated = "No se actualizó el registro";
        public static readonly string NoRowsDeleted = "No se eliminó el registro";

        public static readonly string RowCreated = "Se agrego correctamente el registro a la tabla";
        public static readonly string RowDeleted = "Se elimino correctamente el registro de la tabla";
        public static readonly string RowUpdated = "Se actualizó correctamente el registro en la tabla";
    }
}
