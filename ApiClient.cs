using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieBaseLinker.Model;

namespace ZadanieBaseLinker
{
    public class ApiClient
    {
        IApiManagement orderManager;
        public ApiClient(IApiManagement orderManagerIn)
        {
            orderManager = orderManagerIn;
        }

        public OrderRoot GetOrderById(string token, int id)
        {
            string orderStr = orderManager.GetOrder(token, id);
            var deserializedOrderRoot = JsonConvert.DeserializeObject<OrderRoot>(orderStr);

            return deserializedOrderRoot;
        }

        public int AddNewOrder(string token, OrderNew order)
        {
            string serializedOrder = JsonConvert.SerializeObject(order);
            string orderStr = orderManager.SendOrder(token, serializedOrder);
            var deserializedAddOrderResult = JsonConvert.DeserializeObject<AddOrderResult>(orderStr);

            if (deserializedAddOrderResult.status != "SUCCESS")
                throw new Exception("Błąd dodawania zamówienia.");

            return deserializedAddOrderResult.order_id;
        }
    }
}
