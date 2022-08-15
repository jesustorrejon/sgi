using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Librerias
using System.Data;
using SGI.Data;
using System.Data.OracleClient;
using SGI.App;

namespace SGI.Models
{
    public class Producto
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Productos";

        private string codigo;
        private string secuencia;
        private string rut_proveedor;
        private decimal codigo_barra;
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
        public decimal Codigo_barra { get => codigo_barra; set => codigo_barra = value; }
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


        #region 'METODOS'
        public DataTable Data()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
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
        } // LISTAR TODOS LOS PRODUCTOS

        public DataTable ListUMedida()
        {
            DB.CommandType = CommandType.Text;
            return DB.GetDataTable("select * from unidad_medida order by descripcion");
        } // LISTAR UNIDADES DE MEDIDA

        public DataTable DataOrders()
        {
            //DB.AddParameters("v_familia_codigo", this.Familia_Codigo);
            //return DB.GetDataTable("sp_productos_data_touch");
            if (this.Familia_Codigo == "todos")
            {
                return Data();
            }
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_productos_data_touch", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_familia_codigo", OracleType.VarChar).Value = this.Familia_Codigo;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        } // LISTAR PRODUCTOS SEGÚN FAMILIA SELECCIONADA EN VENTANA DE VENTA

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
        } // CREAR PRODUCTO

        public string Update() 
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_codigo", this.Codigo);
            DB.AddParameters("v_rut_proveedor", this.Rut_proveedor);
            DB.AddParameters("v_codigo_barra",this.Codigo_barra);
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
        } // ACTUALIZAR PRODUCTO

        public string Destroy()
        {
            DB.CommandType = CommandType.StoredProcedure;
            //int res = DB.CRUD($"delete from productos where codigo = '{codigo_}'");
            
            DB.AddParameters("v_codigo", this.Codigo);
            int res = DB.CRUD("sp_productos_destroy");
            
            return (res == 1 ? $"{ App.ClsCommon.RowDeleted } { entity } " : App.ClsCommon.NoRowsDeleted );
            
        } // ELIMINAR PRODUCTO

        public DataTable Search(string searchText)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_productos_search", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_palabra", OracleType.VarChar).Value = searchText;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        } // BUSCAR PRODUCTO EN BARRA DE BUSQUEDA

        public DataTable SearchByCode(string barcode)
        {
            //DB.AddParameters("v_codigo_barra", barcode);

            //return DB.GetDataTable("sp_productos_search_bycode");

            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_productos_search_bycode", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_barcode", OracleType.Float).Value = Convert.ToDecimal(barcode);
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        } // BUSCAR POR CODIGO DE BARRA


        public bool SearchCode(string codigo_producto)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand($"select secuencia from productos where codigo = '{codigo_producto}'", ora);
            comando.CommandType = System.Data.CommandType.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return (tabla != null && tabla.Rows.Count > 0 ? true : false);
        } // BUSCAR SECUENCIA DEL PRODUCTO PARA VERIFICAR SI EXISTE

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

        public bool UpdateStock()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_cod_producto", this.Codigo);

            int res = DB.CRUD("sp_productos_updatestock");

            return (res == 1 ? true : false);
        } // ACTUALIZAR UNA LINEA DE RECEPCION

        public bool noStock(List<BoletaDetalle> productos)
        {
            bool res = false;
            decimal stock = 0;
            string codigo = "";
            DataTable dt = Data();
            
            for (int i = 0; i < dt.Rows.Count - 1; i++)
            {
                codigo = dt.Rows[i].Field<string>("codigo").ToString();
                stock = decimal.Parse(dt.Rows[i].Field<decimal>("stock").ToString());
                  
                foreach (var item in productos)
                {
                    if (item.Cod_producto == codigo)
                    {
                        if ((Convert.ToDecimal(item.Cantidad) - stock) < 0)
                        {
                            res = true;
                            break;
                        }
                    }
                }

            }

            
            return res;
        }
        #endregion
    }
}
