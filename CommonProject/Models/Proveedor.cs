using CommonProject.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.Models
{
    public class Proveedor
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Familia";

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

        public DataTable List()
        {
            DB.CommandType = CommandType.Text;
            return DB.GetDataTable("select * from proveedores order by razon_social");
        }

    }
}
