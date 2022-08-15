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
    class Rec_OC_Detalle
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "OC_DETALLE";

        private decimal cod_oc;
        private string secuencia;
        private string cod_producto;
        private decimal cantidad;
        private decimal pendiente;

        public decimal Cod_oc { get => cod_oc; set => cod_oc = value; }
        public string Secuencia { get => secuencia; set => secuencia = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public decimal Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Pendiente { get => pendiente; set => pendiente = value; }

        public DataTable Data(string codigoOC)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_recocdetalle_data", ora);
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

        public bool Update(Rec_OC roc, decimal usuario_id)
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_cod_oc", this.Cod_oc);
            DB.AddParameters("v_fecha", roc.Fecha);
            DB.AddParameters("v_cod_producto", this.Cod_producto);
            DB.AddParameters("v_cantidad", this.Cantidad);
            DB.AddParameters("v_estado", roc.Estado);
            DB.AddParameters("v_usuario_id", usuario_id);

            int res = DB.CRUD("sp_recocdetalle_update");

            return (res == 1 ? true : false);
        } // ACTUALIZAR UNA LINEA DE RECEPCION
    }
}
