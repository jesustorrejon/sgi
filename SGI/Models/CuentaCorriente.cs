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
    public class CuentaCorriente
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, CommandType.StoredProcedure);
        private readonly string entity = "Cuenta Corriente";

        private string rut_cliente;
        private string secuencia;
        private DateTime fecha;
        private DateTime fecha_compromiso;
        private decimal cargo;
        private decimal abono;

        public string Rut_cliente { get => rut_cliente; set => rut_cliente = value; }
        public string Secuencia { get => secuencia; set => secuencia = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public DateTime Fecha_compromiso { get => fecha_compromiso; set => fecha_compromiso = value; }
        public decimal Cargo { get => cargo; set => cargo = value; }
        public decimal Abono { get => abono; set => abono = value; }

        public DataTable Data()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_cuentascorrientes_data", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_rut_cliente", OracleType.VarChar).Value = this.Rut_cliente;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        } // LISTAR MOVIMIENTOS EN CUENTA CORRIENTE DE CLIENTE

        public bool Create(Boleta boleta)
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_rut_cliente", boleta.Rut);
            DB.AddParameters("v_fecha", DateTime.Now);
            DB.AddParameters("v_fecha_compromiso", boleta.Fecha_compromiso);
            DB.AddParameters("v_cargo", boleta.Total);
            DB.AddParameters("v_boleta", boleta.Numero);

            int res = DB.CRUD("sp_cuentascorrientes_create");

            return (res == 1 ? true : false);
        } // AGREGAR CARGO A CUENTA CORRIENTE

        public bool Pay()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_rut_cliente", this.Rut_cliente);
            DB.AddParameters("v_fecha", DateTime.Now);
            DB.AddParameters("v_abono", this.Abono);

            int res = DB.CRUD("sp_cuentascorrientes_pay");

            return (res == 1 ? true : false);
        } // AGREGAR ABONO A CUENTA CORRIENTE

        public DataTable Search()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_cuentascorrientes_search", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_rut_cliente", OracleType.VarChar).Value = this.Rut_cliente;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        } // BUSCAR POR RUT DE CLIENTE
    }
}
