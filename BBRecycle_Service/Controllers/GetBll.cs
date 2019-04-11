using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using IDAL;

namespace BBRecycle_Service.Controllers
{
    public class GetBll<T> where T:class,new()
    {
        static Opetate<T> dal = null;
        static GetBll()
        {
            if (dal == null)
            {
                dal= new AutoFacData<T>().AutoFac();
            }
        }
        public static Opetate<T> createDal()
        {
            return dal;
        }
    }
}