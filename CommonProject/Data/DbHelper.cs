using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.Data
{
    class DbHelper
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













        // lista de proveedores de bases de datos
        public enum DbProviders
        {
            MySQL, SqlServer, Oracle, OleDb, SQLite
        }

    }
}
