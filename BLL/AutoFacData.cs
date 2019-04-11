using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Autofac;

namespace BLL
{
    public class AutoFacData<T> where T : class, new()
    {
        public Opetate<T> AutoFac()
        {
            try
            {
                ContainerBuilder builder = new ContainerBuilder();
                //注册组件
                builder.RegisterGeneric(typeof(Common<>)).As(typeof(Opetate<>));
                using (var container = builder.Build())
                {
                    var manager = container.Resolve<Opetate<T>>();
                    return manager;
                }
            }
            catch (Exception e)
            {
                return default(Opetate<T>);
            }
        }
    }
}
