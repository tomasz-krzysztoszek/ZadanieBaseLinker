using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieBaseLinker
{
    public class BaseLinkerApiManagement : IApiManagement
    {
        public string GetOrder(string token, int id)
        {
            using (WebClient client = new WebClient())
            {

                client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                client.Headers["X-BLToken"] = token;

                var reqParam = new System.Collections.Specialized.NameValueCollection();
                reqParam.Add("method", "getOrders");
                reqParam.Add("parameters", "{\"order_id\": " + id +"}");

                byte[] responseBytes = client.UploadValues("https://api.baselinker.com/connector.php", "POST", reqParam);
                string responseBody = Encoding.UTF8.GetString(responseBytes);

                return responseBody;
            }
        }

        public string SendOrder(string token, string order)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                client.Headers["X-BLToken"] = token;

                var reqParam = new System.Collections.Specialized.NameValueCollection();
                reqParam.Add("method", "addOrder");
                reqParam.Add("parameters", order);

                byte[] responseBytes = client.UploadValues("https://api.baselinker.com/connector.php", "POST", reqParam);
                string responseBody = Encoding.UTF8.GetString(responseBytes);

                return responseBody;
            }
        }
    }
}
