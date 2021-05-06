using SGI.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Models
{
    class Producto
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Productos";

        private string codigo;
        private int secuencia;
        private string rut_proveedor;
        private int codigo_barra;
        private string codigo_familia;
        private int secuencia_familia;
        private DateTime fecha_vencimiento;
        private string descripcion;
        private string unidad_medida;
        private float precio_compra;
        private float precio_venta;
        private float stock;
        private float stock_critico;
        private string imagen;

        public string Codigo { get => codigo; set => codigo = value; }
        public int Secuencia { get => secuencia; set => secuencia = value; }
        public string Rut_proveedor { get => rut_proveedor; set => rut_proveedor = value; }
        public int Codigo_barra { get => codigo_barra; set => codigo_barra = value; }
        public string Codigo_familia { get => codigo_familia; set => codigo_familia = value; }
        public int Secuencia_familia { get => secuencia_familia; set => secuencia_familia = value; }
        public DateTime Fecha_vencimiento { get => fecha_vencimiento; set => fecha_vencimiento = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public float Precio_compra { get => precio_compra; set => precio_compra = value; }
        public float Precio_venta { get => precio_venta; set => precio_venta = value; }
        public float Stock { get => stock; set => stock = value; }
        public float Stock_critico { get => stock_critico; set => stock_critico = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Unidad_medida { get => unidad_medida; set => unidad_medida = value; }


        // METODOS
        public DataTable Data() => DB.GetDataTable("sp_productos_data");

        public DataTable DataOrders()
        {
            DB.AddParameters("familia_codigo", this.Codigo_familia);
            return DB.GetDataTable("sp_productos_data_touch");
        }

        public string Create()
        {
            DB.AddParameters("codigo_", this.Codigo);
            DB.AddParameters("rut_proveedor_", this.Rut_proveedor);
            DB.AddParameters("codigo_familia_", this.Codigo_familia);
            DB.AddParameters("fecha_vencimiento_", this.Fecha_vencimiento);
            DB.AddParameters("descripcion_", this.Descripcion);
            DB.AddParameters("unidad_medida_", this.Unidad_medida);
            DB.AddParameters("precio_compra_", this.Precio_compra);
            DB.AddParameters("precio_venta_", this.Precio_venta);
            DB.AddParameters("stock_", this.Stock);
            DB.AddParameters("stock_critico_", this.Stock_critico);
            DB.AddParameters("imagen_", this.Imagen);
            int res = DB.CRUD("sp_productos_create");

            return (res == 1 ? $"{ App.ClsCommon.RowCreated } { entity } " : App.ClsCommon.NoRowsAdded);
        }

        public string Update()
        {
            DB.AddParameters("codigo_", this.Codigo);
            DB.AddParameters("rut_proveedor_", this.Rut_proveedor);
            DB.AddParameters("codigo_familia_", this.Codigo_familia);
            DB.AddParameters("fecha_vencimiento_", this.Fecha_vencimiento);
            DB.AddParameters("descripcion_", this.Descripcion);
            DB.AddParameters("unidad_medida_", this.Unidad_medida);
            DB.AddParameters("precio_compra_", this.Precio_compra);
            DB.AddParameters("precio_venta_", this.Precio_venta);
            DB.AddParameters("stock_", this.Stock);
            DB.AddParameters("stock_critico_", this.Stock_critico);
            DB.AddParameters("imagen_", this.Imagen);
            int res = DB.CRUD("sp_productos_update");

            return (res == 1 ? $"{ App.ClsCommon.RowUpdated } { entity } " : App.ClsCommon.NoRowsUpdated );
        }

        public string Destroy()
        {
            DB.AddParameters("codigo_", this.Codigo);
            int res = DB.CRUD("sp_productos_destroy");

            return (res == 1 ? $"{ App.ClsCommon.RowDeleted } { entity } " : App.ClsCommon.NoRowsDeleted);
        }

        public DataTable Search( string searchText)
        {
            DB.AddParameters("txt", searchText);
            return DB.GetDataTable("sp_productos_search");
        }

        public DataTable SearchByCode( string barcode)
        {
            DB.AddParameters("codigo_barra", barcode);

            return DB.GetDataTable("sp_productos_search_bycode");
        }

        /*public DataTable GetBarcode()
        {
            DataTable code = DB.GetDataTable("sp_barcode_next");

            if(code !=null && code.Rows.Count > 0)
            {
                return code.Rows[0].Field<ulong>("id").ToString("D10");
            }
            else
            {
                return 0.ToString("D10");
            }
        }*/
    }
}
