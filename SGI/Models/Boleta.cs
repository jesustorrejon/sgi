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
    public class Boleta
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Boleta";


        private int numero;
        private string rut;
        private DateTime fecha;
        private decimal total;
        private string mediopago;
        private DateTime fecha_compromiso;
        private decimal items;
        private int usuario_id;

        public int Numero { get => numero; set => numero = value; }
        public string Rut { get => rut; set => rut = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public decimal Total { get => total; set => total = value; }
        public string Mediopago { get => mediopago; set => mediopago = value; }
        public DateTime Fecha_compromiso { get => fecha_compromiso; set => fecha_compromiso = value; }
        public decimal Items { get => items; set => items = value; }
        public int Usuario_id { get => usuario_id; set => usuario_id = value; }



        #region 'METODOS'
        public DataTable Data()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_boletas_data", ora);
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
            //DB.AddParameters("sgi", ClsCommon.Database);

            //DB.GetDataTable("sp_next_numero").Rows[0].Field<ulong>("numero");

            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_boletas_nextid", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            string result = "";
            result = tabla.Rows[0].Field<decimal>("numero").ToString();
            /*
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                result = tabla.Rows[i].Field<decimal>("numero").ToString();
            }
            */
            ora.Close();
            
            return result;
        }

        public bool Create(Boleta boleta, List<BoletaDetalle> productos)
        {
            //bool res = DbHelper.BoletaTransaction(boleta, productos);
            
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_rut", boleta.Rut);
            DB.AddParameters("v_total", boleta.Total);
            DB.AddParameters("v_mediopago", boleta.Mediopago);
            DB.AddParameters("v_fecha", DateTime.Now);
            DB.AddParameters("v_fecha_compromiso", boleta.Fecha_compromiso);
            DB.AddParameters("v_items", boleta.Items);

            int res = DB.CRUD("sp_boletas_create");
            if (res == 1)
            {
                foreach (var item in productos)
                {
                    BoletaDetalle detalle = new BoletaDetalle();

                    detalle.Numero_boleta = item.Numero_boleta;
                    detalle.Cod_producto = item.Cod_producto;
                    detalle.Cantidad = item.Cantidad;
                    detalle.Precio = item.Precio;

                    detalle.Create(boleta.Usuario_id, boleta.Rut );

                }
            }
            
            //return (res == 1 ? $"{ App.ClsCommon.RowCreated } { entity } " : App.ClsCommon.NoRowsAdded);


            return (res == 1 ? true : false);
        }

        public string Update()
        {
            DB.AddParameters("v_numero", this.Numero);
            DB.AddParameters("v_rut", this.Rut);
            //DB.AddParameters("v_fecha", this.Fecha);
            DB.AddParameters("v_total", this.Total);
            DB.AddParameters("v_mediopago", this.Mediopago);
            DB.AddParameters("v_fecha_compromiso", this.Fecha_compromiso);

            int res = DB.CRUD("sp_boletas_update");
            return (res == 1 ? $"{ App.ClsCommon.RowUpdated } { entity }" : App.ClsCommon.NoRowsUpdated );
        }

        public string Destroy()
        {
            DB.AddParameters("v_numero", this.Numero);
            int res = DB.CRUD("sp_boletas_destroy");

            return (res == 1 ? $"{ App.ClsCommon.RowDeleted } { entity }" : App.ClsCommon.NoRowsDeleted);
        }

        public DataTable Search(string searchtext)
        {
            DB.AddParameters("v_search", searchtext);
            return DB.GetDataTable("sp_boletas_search");
        }


        #endregion


    }
}
