using SGI.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Models
{
    public class BoletaDetalle
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Boleta Detalle";

        private int numero_boleta;
        private string secuencia;
        private string cod_producto;
        private float cantidad;
        private float precio;

        public int Numero_boleta { get => numero_boleta; set => numero_boleta = value; }
        public string Secuencia { get => secuencia; set => secuencia = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public float Cantidad { get => cantidad; set => cantidad = value; }
        public float Precio { get => precio; set => precio = value; }

        public bool Create(int usuario_id, string rut)
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_numero_boleta", this.Numero_boleta);
            DB.AddParameters("v_cod_producto", this.Cod_producto);
            DB.AddParameters("v_cantidad", this.Cantidad);
            DB.AddParameters("v_precio", this.Precio);
            DB.AddParameters("v_usuario_id", usuario_id);
            DB.AddParameters("v_rut", rut);

            int res = DB.CRUD("sp_boletadetalle_create");

            return (res == 1 ? true : false);
        } // CREAR BOLETA DETALLE
    }
}
