using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class SqlDbHelper
    {
        static string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static SqlConnection con = null;
        static SqlDbHelper()
        {
            if (con == null)
            {
                con = new SqlConnection(conStr);
            }
        }
        //增删改操作
        public static int ADU(string sql)
        {
            con.Open();
            SqlCommand com = new SqlCommand(sql, con);
            int result = com.ExecuteNonQuery();
            con.Close();
            return result;
        }
        //返回集合
        public static DataTable Get(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
        //调用存储过程
        public static DataTable Get(string procName,SqlParameter[] pars)
        {
            SqlCommand com = new SqlCommand(procName,con);
            com.CommandType = CommandType.StoredProcedure;
            if (pars != null)
            {
                foreach (var item in pars)
                {
                    com.Parameters.Add(item);
                }
            }
            SqlDataAdapter dap = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            return dt;
        }
    }
}
