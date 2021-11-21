using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieBaseLinker
{
    public interface IApiManagement
    {
        string GetOrder(string token, int id);
        string SendOrder(string token, string order);
    }
}
