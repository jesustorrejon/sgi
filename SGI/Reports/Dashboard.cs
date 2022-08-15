using SGI.App;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Reports
{
    public class Dashboard
    {
        public DataTable topSales()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_dashboard_topsales", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        }

        public DataTable lastSales()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_dashboard_lastsales", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        }
    }
}
