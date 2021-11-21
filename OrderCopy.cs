using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieBaseLinker.Model;

namespace ZadanieBaseLinker
{
    public class OrderCopy
    {
        IOrderCopy orderCopy;
        public OrderCopy(IOrderCopy orderCopyIn)
        {
            orderCopy = orderCopyIn;
        }
        public OrderNew CopyOrder(Order order)
        {
            return orderCopy.Copy(order);
        }

        public void AddFreePoz(OrderNew order)
        {
            orderCopy.AddPoz(order);
        }
    }
}
