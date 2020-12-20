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
            SqlConnection con = new SqlConnection(_connection);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sprocName;

            if (args.Length != 0)
            {
                foreach (var par in args)
                {
                    SqlParameter spar = new SqlParameter(par.Item1, par.Item2);
                    cmd.Parameters.Add(spar);
                }
            }
            var retParam = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
            retParam.Direction = ParameterDirection.ReturnValue;

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return (int)retParam.Value;
        }
    }
}