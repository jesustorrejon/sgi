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
    public class OrdendeCompra
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "OC";

        private decimal codigo;
        private string rut_proveedor;
        private string secuencia_proveedor;
        private DateTime fecha;
        private DateTime fecha_recepcion;
        private decimal total;

        public decimal Codigo { get => codigo; set => codigo = value; }
        public string Rut_proveedor { get => rut_proveedor; set => rut_proveedor = value; }
        public string Secuencia_proveedor { get => secuencia_proveedor; set => secuencia_proveedor = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Fecha_recepcion { get => fecha_recepcion; set => fecha_recepcion = value; }
        public decimal Total { get => total; set => total = value; }

        public DataTable Data()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_oc_data", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        }

        public string NextID()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_oc_nextid", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            string result = "";
            result = tabla.Rows[0].Field<decimal>("codigo").ToString();
            
            ora.Close();

            return result;
        }

        public bool Destroy()
        {
            DB.CommandType = CommandType.StoredProcedure;

            DB.AddParameters("v_cod_oc", this.Codigo);

            int res = DB.CRUD("sp_oc_destroy");

            return (res == 1 ? true : false);

        } // ELIMINAR OC
    }
}
