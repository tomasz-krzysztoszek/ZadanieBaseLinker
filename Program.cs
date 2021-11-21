using AutoMapper;
using Ninject;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZadanieBaseLinker.Model;

namespace ZadanieBaseLinker
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            try
            {
                string token = Properties.Settings.Default.Token;

                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
                var orderMng = kernel.Get<IApiManagement>();
                var orderCpy = kernel.Get<IOrderCopy>();

                Console.WriteLine("Podaj numer zamówienia BaseLinker");
                var nrZamStr = Console.ReadLine();
                int nrZam;

                if (!Int32.TryParse(nrZamStr, out nrZam))
                {
                    logger.Warn("Wprowadzono błedny format");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                var apiClient = new ApiClient(orderMng);
                var order = apiClient.GetOrderById(token, nrZam);

                if(order.orders.Length == 0)
                {
                    logger.Warn("Brak zamówenia o podanym numerze");
                    Console.ReadLine();
                    Environment.Exit(0);
                }

                var orderCopy = new OrderCopy(orderCpy);
                var newOrder = orderCopy.CopyOrder(order.orders.FirstOrDefault());
                orderCopy.AddFreePoz(newOrder);

                var newOrderId = apiClient.AddNewOrder(token, newOrder);

                logger.Info($"Pomyślnie dodano zamówienie o numerze: {newOrderId}");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
