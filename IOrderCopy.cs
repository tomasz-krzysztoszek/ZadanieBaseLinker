using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieBaseLinker.Model;

namespace ZadanieBaseLinker
{
    public interface IOrderCopy
    {
        OrderNew Copy(Order order);
        void AddPoz(OrderNew order);
    }
}
