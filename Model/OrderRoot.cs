using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieBaseLinker.Model
{
    public class OrderRoot
    {
        public string status { get; set; }
        public Order[] orders { get; set; }
    }
}
