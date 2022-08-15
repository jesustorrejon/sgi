using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// LIBRERIAS
//using MySql.Data.MySqlClient; // Conector a base de datos Mysql
using System.Collections.Generic; // Trabajar con listas
using System.Data.Common; // para trabajar con la conexion generica de nuestro motor db
using System.Data.OracleClient; // Oracle Database
using System.Data;
using SGI.Models;
using SGI.App;

namespace SGI.Data
{
    public class DbHelper
    {
        // propiedades
        private string ConnectionString = "";
        // Clase abstracta que representa una conexion a una base de datos
        private DbConnection _Connection;
        // Clase abstracta que representa una sentencia sql o procedimiento almacenado
        private DbCommand _Command;
        // Clase abstracta que provee un conjunto de metodos para crear instancias de conexion a distintos motores de db
        private DbProviderFactory _factory = null;
        private DbProviders _provider;
        // Objeto de tipo ENUM que indica como se va interpretar la propiedad CommandText del comando (1 = query, 4 = procedimientos, 512 = TableDirect)
        private CommandType _Commandtype;

        // Getters y Setters
        public string ConnectionString1 { get => ConnectionString; set => ConnectionString = value; }
        public DbConnection Connection { get => _Connection; set => _Connection = value; }
        public DbCommand Command { get => _Command; set => _Command = value; }
        public CommandType CommandType { get => _Commandtype; set => _Commandtype = value; }


        // Constructor

        public DbHelper(string ConnectString, CommandType CommandType, DbProviders ProviderName = DbHelper.DbProviders.Oracle)
        {
            _provider = ProviderName;

            _Commandtype = CommandType;

            _factory = OracleClientFactory.Instance;

            _Connection = _factory.CreateConnection();

            Connection.ConnectionString = ConnectString;

            Command = _factory.CreateCommand();

            Command.Connection = Connection;
        }
        

        private void BeginTransaction()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            Command.Transaction = Connection.BeginTransaction();
        }

        // Metodo encargado de confirmar la transaccion a la base de datos
        private void CommitTransaction()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Command.Transaction.Commit();
                Connection.Close();
            }
        }

        // Validaciones que no hayan inconsistencias en la base de datos, en caso que haya desace los cambios a como estaba
        private void RollbackTransaction()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Command.Transaction.Rollback();
                Connection.Close();
            }
        }

        public int CRUD(string query)
        {
            Command.CommandText = query;
            Command.CommandType = _Commandtype;
            int i = -1;

            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                BeginTransaction();
                i = Command.ExecuteNonQuery(); // contar filas afectadas.
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                //logs
            }
            finally
            {
                Command.Parameters.Clear();
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    Connection.Dispose(); // liberar recursos utilizados
                    Command.Dispose();
                }
            }

            return i;

        }

        public DataTable GetDataTable(string query)
        {
            DbDataAdapter adapter = _factory.CreateDataAdapter();
            Command.CommandText = query;
            Command.CommandType = _Commandtype;
            adapter.SelectCommand = Command;
            DataSet ds = new DataSet();

            try
            {
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {

                //logs
            }
            finally
            {
                Command.Parameters.Clear();
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    Connection.Dispose();
                    Command.Dispose();
                }
            }

            return ds.Tables[0];
        }


        //Metodo para auxiliar los parametros solicitados por las consultas o procedimientos almacenados
        public int AddParameters(string name, object value)
        {
            DbParameter parm = _factory.CreateParameter();
            parm.ParameterName = name;
            parm.Value = value;

            return Command.Parameters.Add(parm);
        }

        public static bool BoletaTransaction(Boleta  boleta, List<BoletaDetalle> productos)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            OracleTransaction transaction;
            bool result = false;

            ora.Open();
            transaction = ora.BeginTransaction();

            try
            {
                OracleCommand cmd1 = new OracleCommand("sp_boletas_create", ora);
                OracleCommand cmd2;

                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new OracleParameter("v_rut", OracleType.VarChar));
                cmd1.Parameters["v_rut"].Value = boleta.Rut;
                //cmd1.Parameters.Add(new OracleParameter("@v_fecha", OracleType.DateTime));
                //cmd1.Parameters["@v_fecha"].Value = boleta.Fecha;
                cmd1.Parameters.Add(new OracleParameter("v_total", OracleType.Float));
                cmd1.Parameters["v_total"].Value = boleta.Total;
                cmd1.Parameters.Add(new OracleParameter("v_mediopago", OracleType.VarChar));
                cmd1.Parameters["v_mediopago"].Value = boleta.Mediopago;
                cmd1.Parameters.Add(new OracleParameter("v_fecha_compromiso", OracleType.VarChar));
                cmd1.Parameters["v_fecha_compromiso"].Value = boleta.Fecha_compromiso;
                cmd1.Parameters.Add(new OracleParameter("v_items", OracleType.Int32));
                cmd1.Parameters["v_items"].Value = boleta.Items;
                cmd1.ExecuteNonQuery();


                foreach (var item in productos)
                {
                    cmd2 = new OracleCommand("sp_boletadetalle_create", ora);
                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.Add("v_numero_boleta", OracleType.Int32, 38);
                    cmd2.Parameters["v_numero_boleta"].Value = item.Numero_boleta;
                    cmd2.Parameters.Add("v_cod_produto", OracleType.VarChar, 20);
                    cmd2.Parameters["v_cod_producto"].Value = item.Cod_producto;
                    cmd2.Parameters.Add("v_cantidad", OracleType.Float);
                    cmd2.Parameters["v_cantidad"].Value = item.Cantidad;
                    cmd2.Parameters.Add("v_precio", OracleType.Float);
                    cmd2.Parameters["v_precio"].Value = item.Precio;

                    cmd2.Parameters.Add("v_usuario_id", OracleType.Float);
                    cmd2.Parameters["v_usuario_id"].Value = boleta.Usuario_id;
                    cmd2.Parameters.Add("v_rut", OracleType.VarChar);
                    cmd2.Parameters["v_rut"].Value = boleta.Rut;

                    cmd2.ExecuteNonQuery();

                }

                transaction.Commit();
                result = true;

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                result = false;
            }
            finally
            {
                ora.Close();
                ora.Dispose();
            }

            return result;
        }










        // lista de proveedores de bases de datos
        public enum DbProviders
        {
            MySQL, SqlServer, Oracle, OleDb, SQLite
        }
    }
}
