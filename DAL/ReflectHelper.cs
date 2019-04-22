using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace DAL
{
    public class ReflectHelper<T> where T : new()
    {
        //添加语句
        public static string GetAddStr(T t)
        {
            Type type = typeof(T);
            StringBuilder sb = new StringBuilder();
            sb.Append("insert into " + type.Name + " values(");
            string sql = "";
            foreach (var item in type.GetProperties())
            {
                if (item.GetCustomAttribute(typeof(KeyAttribute), true) == null)
                {
                    sb.Append("'").Append(item.GetValue(t) + "',");
                }
            }
            sql = sb.ToString().Substring(0, sb.ToString().Length - 1) + ")";
            return sql;
        }
        //查询语句
        public static string GetStr()
        {
            Type type = typeof(T);
            return "select *from " + type.Name;
        }
        //获取集合
        public static List<T> GetList(DataTable dt)
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            foreach (DataRow item in dt.Rows)
            {
                T t = new T();
                foreach (var p in type.GetProperties())
                {
                    p.SetValue(t, item[p.Name]);
                }
                list.Add(t);
            }
            return list;
        }
        //删除
        public static string GetDelStr(object id)
        {
            Type type = typeof(T);
            string sql = "delete from " + type.Name;
            foreach (var item in type.GetProperties())
            {
                if (item.GetCustomAttribute(typeof(KeyAttribute), true) != null)
                {
                    sql += item.Name + "=" + id;
                }
            }
            return sql;
        }
        //修改
        public static string GetUpdStr(T t)
        {
            Type type = typeof(T);
            string sql = "update " + type.Name + " set ";
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            foreach (var item in type.GetProperties())
            {
                if (item.GetCustomAttribute(typeof(KeyAttribute), true) != null)
                {
                    sb1.Append("where " + item.Name + "='" + item.GetValue(t) + "'");
                }
                else
                {
                    if (item.GetValue(t)!=null || Convert.ToInt32(item.GetValue(t)) != 0)
                    { 
                        sb2.Append(item.Name + "='" + item.GetValue(t) + "',");
                    }
                }
            }
            sql += sb2.ToString().Substring(0, sb2.ToString().Length - 1) + sb1.ToString();
            return sql;
        }
    }
}
