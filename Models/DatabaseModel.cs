using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace User_System_Test_App.Models
{
    public class DatabaseModel
    {
        private string _connection = "";

        public DatabaseModel(string connectionString)
        {
            _connection = connectionString;
        }

        public int RunSproc(string sprocName, string connectionString, params (string, object)[] args)
        {
            _connection = connectionString;
            return RunSproc(sprocName, args);
        }

        public int RunSproc(string sprocName, params (string, object)[] args)
        {
            var cmd = new DatabaseCommand(sprocName, args);
            cmd.OpenConnection(_connection);
            cmd.Command.ExecuteNonQuery();
            cmd.CloseConnection();
            return cmd.ReturnValue;
        }

        public DataSet RunSprocSet(string sprocName, string setName, string connectionString, params (string, object)[] args)
        {
            _connection = connectionString;
            return RunSprocSet(sprocName, setName, args);
        }

        public DataSet RunSprocSet(string sprocName, string setName, params (string, object)[] args)
        {
            var cmd = new DatabaseCommand(sprocName, args);
            cmd.OpenConnection(_connection);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd.Command;
            DataSet set = new DataSet(setName);
            da.Fill(set, setName);
            cmd.CloseConnection();
            return set;
        }

        
    }

    public class DatabaseCommand
    {
        public string CommandName => Command.CommandText;
        private SqlConnection _con;
        public SqlCommand Command { get; }
        private SqlParameter _return;
        public int ReturnValue => (int)_return?.Value;

        public DatabaseCommand(string sprocName, params (string, object)[] args)
        {
            Command = new SqlCommand();
            Command.CommandType = CommandType.StoredProcedure;
            Command.CommandText = sprocName;

            if (args.Length != 0)
            {
                foreach (var par in args)
                {
                    SqlParameter spar = new SqlParameter(par.Item1, par.Item2);
                    Command.Parameters.Add(spar);
                }
            }
            _return = Command.Parameters.Add("@ReturnVal", SqlDbType.Int);
            _return.Direction = ParameterDirection.ReturnValue;
        }

        public void OpenConnection(string connectionString)
        {
            _con = new SqlConnection(connectionString);
            Command.Connection = _con;
            _con.Open();
        }

        public void CloseConnection()
        {
            _con.Close();
        }
    }
}