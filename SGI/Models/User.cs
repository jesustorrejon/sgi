using SGI.Data;
using SGI.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;

namespace SGI.Models
{
    public class User
    {
        private readonly DbHelper DB = new DbHelper(App.ClsCommon.ConnectionString, System.Data.CommandType.StoredProcedure);
        private readonly string entity = "Usuario";

        private int id;
        private string name;
        private string username;
        private string phone;
        private string password;
        private string status;
        private string profile;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Username { get => username; set => username = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
        public string Status { get => status; set => status = value; }
        public string Profile { get => profile; set => profile = value; }

        public DataTable Data()
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_usuarios_data", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        }

        public string Create()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_name", this.Name);
            DB.AddParameters("v_username", this.Username);
            DB.AddParameters("v_phone", this.Phone);
            DB.AddParameters("v_password", this.Password);
            DB.AddParameters("v_status", this.Status);
            DB.AddParameters("v_profile", this.Profile);

            int res = DB.CRUD("sp_usuarios_create");

            return (res == 1 ? $"{ App.ClsCommon.RowCreated } { entity } " : App.ClsCommon.NoRowsAdded);
        }

        public string Update()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_username", this.Username);
            DB.AddParameters("v_name", this.Name);
            DB.AddParameters("v_phone", this.Phone);
            DB.AddParameters("v_password", this.Password);
            DB.AddParameters("v_status", this.Status);
            DB.AddParameters("v_profile", this.Profile);
            int res = DB.CRUD("sp_usuarios_update");

            return (res == 1 ? $"{ App.ClsCommon.RowUpdated } { entity } " : App.ClsCommon.NoRowsUpdated);
        }

        public string Destroy()
        {
            DB.CommandType = CommandType.StoredProcedure;
            DB.AddParameters("v_id", this.Id);
            int res = DB.CRUD("sp_usuarios_destroy");
            
            return (res == 1 ? $"{ App.ClsCommon.RowDeleted } { entity } " : App.ClsCommon.NoRowsDeleted);

        }

        public DataTable Login()
        {
            DataTable info = new DataTable();
            try
            {
                /*DB.AddParameters("v_username", this.Username);
                DB.AddParameters("v_password", this.Password);
                info = DB.GetDataTable("sp_usuarios_login");
                */
                OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
                ora.Open();
                OracleCommand comando = new OracleCommand("sp_usuarios_login", ora);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("v_username", OracleType.VarChar).Value = this.Username;
                comando.Parameters.Add("v_password", OracleType.VarChar).Value = this.Password;
                comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

                OracleDataAdapter adaptador = new OracleDataAdapter();
                adaptador.SelectCommand = comando;
                adaptador.Fill(info);
                ora.Close();
            }
            catch (Exception ex)
            {

                return info;
            }

            return info;
        }

        public DataTable Search(string searchText)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand("sp_usuarios_search", ora);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.Add("v_palabra", OracleType.VarChar).Value = searchText;
            comando.Parameters.Add("registros", OracleType.Cursor).Direction = ParameterDirection.Output;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return tabla;
        }

        public bool SearchCode(string username)
        {
            OracleConnection ora = new OracleConnection(ClsCommon.ConnectionString);
            ora.Open();
            OracleCommand comando = new OracleCommand($"select username from usuarios where username = '{username}'", ora);
            comando.CommandType = System.Data.CommandType.Text;

            OracleDataAdapter adaptador = new OracleDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            ora.Close();
            return (tabla != null && tabla.Rows.Count > 0 ? true : false);
        }


    }
}
