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
    public class OrdendeCompraDetalle
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "OC_DETALLE";

        private decimal cod_oc;
        private string secuencia;
        private string cod_producto;
        private decimal cantidad;
        private decimal precio_unitario;

        public decimal Cod_oc { get => cod_oc; set => cod_oc = value; }
        public string Secuencia { get => secuencia; set => secuencia = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Precio_unitario { get => precio_unitario; set => precio_unitario = value; }

        public DataTable Data(string codigoOC)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_ocdetalle_data", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_cod_oc", OracleType.VarChar).Value = codigoOC;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        }


        public bool Create(OrdendeCompra oc)
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_cod_oc", this.Cod_oc);
            DB.AddParameters("v_fecha", oc.Fecha);
            DB.AddParameters("v_cod_producto", this.Cod_producto);
            DB.AddParameters("v_cantidad", this.Cantidad);
            DB.AddParameters("v_rut_proveedor", oc.Rut_proveedor);


            int res = DB.CRUD("sp_ocdetalle_create");

            return (res == 1 ? true : false) ;
        } // CREAR OC Y UNA LINEA DE DETALLE

        public bool Destroy()
        {
            DB.CommandType = CommandType.StoredProcedure;

            DB.AddParameters("v_cod_producto", this.Cod_producto);
            DB.AddParameters("v_cod_oc", this.Cod_oc);

            int res = DB.CRUD("sp_ocdetalle_destroy");

            return (res == 1 ? true : false);

        } // ELIMINAR OC DETALLE
    }
}
