using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieBaseLinker.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IApiManagement>().To<BaseLinkerApiManagement>();
            Bind<IOrderCopy>().To<BaseLinkerOrderCopy>();
        }
    }
}
