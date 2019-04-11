using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DAL;
using System.Data.SqlClient;

namespace BLL
{
    public class Common<T> : Opetate<T> where T : class, new()
    {
        public int Add(T t)
        {
            string sql = ReflectHelper<T>.GetAddStr(t);
            return SqlDbHelper.ADU(sql);
        }
        public int Del(object id)
        {
            string sql = ReflectHelper<T>.GetDelStr(id);
            return SqlDbHelper.ADU(sql);
        }
        public List<T> Get()
        {
            string sql = ReflectHelper<T>.GetStr();
            return ReflectHelper<T>.GetList(SqlDbHelper.Get(sql));
        }
        public int Upd(T t)
        {
            string sql = ReflectHelper<T>.GetUpdStr(t);
            return SqlDbHelper.ADU(sql);
        }
    }
}
