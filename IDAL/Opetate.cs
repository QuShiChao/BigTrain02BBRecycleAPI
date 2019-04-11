using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IDAL
{
    public interface Opetate<T>
    {
        int Add(T t);
        List<T> Get();
        int Upd(T t);
        int Del(object id);
    }
}
