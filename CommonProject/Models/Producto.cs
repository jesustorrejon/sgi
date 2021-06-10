using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerias
using System.Data;
using CommonProject.Data;
using System.Data.OracleClient;

namespace CommonProject.Models
{
    public class Producto
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Productos";

        private string codigo;
        private string secuencia;
        private string rut_proveedor;
        private int codigo_barra;
        private string familia_codigo;
        private string familia_secuencia;
        private string fecha_vencimiento;
        private string descripcion;
        private string unidad_medida;
        private float precio_compra;
        private float precio_venta;
        private float stock;
        private float stock_critico;
        private string imagen;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Secuencia { get => secuencia; set => secuencia = value; }
        public string Rut_proveedor { get => rut_proveedor; set => rut_proveedor = value; }
        public int Codigo_barra { get => codigo_barra; set => codigo_barra = value; }
        public string Familia_Codigo { get => familia_codigo; set => familia_codigo = value; }
        public string Familia_Secuencia { get => familia_secuencia; set => familia_secuencia = value; }
        public string Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float Precio_compra { get => precio_compra; set => precio_compra = value; }
        public float Precio_venta { get => precio_venta; set => precio_venta = value; }
        public float Stock { get => stock; set => stock = value; }
        public float Stock_critico { get => stock_critico; set => stock_critico = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Unidad_medida { get => unidad_medida; set => unidad_medida = value; }


        // METODOS
        public DataTable Data()
        {
            
            //DB.CommandType = CommandType.StoredProcedure;
            //return DB.GetDataTable("select p.codigo, p.descripcion, um.descripcion as UMedida from productos p join umedida um on p.unidad_medida = um.codigo;");
            /*return DB.GetDataTable("select p.CODIGO, p.DESCRIPCION, u.DESCRIPCION as UMedida, f.DESCRIPCION as FAMILIA" +
                                    "from productos p" +
                                    "join unidad_medida u on p.unidad_medida = u.codigo" +
                                    "join familia f on p.codigo_familia = f.codigo" +
                                    "order by P.codigo");
            */
            OracleConnection ora = new OracleConnection("DATA SOURCE = xe; PASSWORD= sgi; USER ID= sgi;");
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_productos_data", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;
            
            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        }

        public DataTable ListUMedida()
        {
            DB.CommandType = CommandType.Text;
            return DB.GetDataTable("select * from unidad_medida order by descripcion");
        }

        public DataTable DataOrders()
        {
            DB.AddParameters("v_familia_codigo", this.Familia_Codigo);
            return DB.GetDataTable("sp_productos_data_touch");
        }

        public string Create()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_codigo", this.Codigo);
            DB.AddParameters("v_rut_proveedor", this.Rut_proveedor);
            DB.AddParameters("v_codigo_barra", this.Codigo_barra);
            DB.AddParameters("v_codigo_familia", this.Familia_Codigo);
            DB.AddParameters("v_fecha_vencimiento", this.Fecha_vencimiento);
            DB.AddParameters("v_descripcion", this.Descripcion);
            DB.AddParameters("v_unidad_medida", this.Unidad_medida);
            DB.AddParameters("v_precio_compra", this.Precio_compra);
            DB.AddParameters("v_precio_venta", this.Precio_venta);
            DB.AddParameters("v_stock", this.Stock);
            DB.AddParameters("v_stock_critico", this.Stock_critico);
            DB.AddParameters("v_imagen", this.Imagen);
            
            int res = DB.CRUD("sp_productos_create");

            return (res == 1 ? $"{ App.ClsCommon.RowCreated } { entity } " : App.ClsCommon.NoRowsAdded);
        }

        public string Update()
        {
            DB.AddParameters("v_codigo", this.Codigo);
            DB.AddParameters("v_rut_proveedor", this.Rut_proveedor);
            DB.AddParameters("v_codigo_familia", this.Familia_Codigo);
            DB.AddParameters("v_fecha_vencimiento", this.Fecha_vencimiento);
            DB.AddParameters("v_descripcion", this.Descripcion);
            DB.AddParameters("v_unidad_medida", this.Unidad_medida);
            DB.AddParameters("v_precio_compra", this.Precio_compra);
            DB.AddParameters("v_precio_venta", this.Precio_venta);
            DB.AddParameters("v_stock", this.Stock);
            DB.AddParameters("v_stock_critico", this.Stock_critico);
            DB.AddParameters("v_imagen", this.Imagen);
            int res = DB.CRUD("sp_productos_update");

            return (res == 1 ? $"{ App.ClsCommon.RowUpdated } { entity } " : App.ClsCommon.NoRowsUpdated);
        }

        public string Destroy(string codigo_)
        {
            DB.CommandType = CommandType.Text;
            int res = DB.CRUD($"delete from productos where codigo = '{codigo_}'");
            /*
            DB.AddParameters("v_codigo", this.Codigo);
            int res = DB.CRUD("sp_productos_destroy");
            */
            return (res == 1 ? $"{ App.ClsCommon.RowDeleted } { entity } " : App.ClsCommon.NoRowsDeleted );
            
        }

        public DataTable Search(string searchText)
        {
            DB.AddParameters("v_palabra", searchText);
            return DB.GetDataTable("sp_productos_search");
        }

        public DataTable SearchByCode(string barcode)
        {
            DB.AddParameters("v_codigo_barra", barcode);

            return DB.GetDataTable("sp_productos_search_bycode");
        }


        /*public DataTable SearchCode(string codigo_producto)
        {
            string query = $"select * from productos where codigo = '{codigo_producto}'";
            DB.Command.CommandText = query;
            DB.Reader(registro) = DB.Command.ExecuteReader();
            
        }*/
        /*public DataTable GetBarcode()
        {
            DataTable code = DB.GetDataTable("sp_barcode_next");

            if(code !=null && code.Rows.Count > 0)
            {
                return code.Rows[0].Field<ulong>("codigo").ToString("D10");
            }
            else
            {
                return 0.ToString("D10");
            }
        }*/
    }
}
