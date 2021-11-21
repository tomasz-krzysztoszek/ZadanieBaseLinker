using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZadanieBaseLinker.Model;

namespace ZadanieBaseLinker
{
    class BaseLinkerOrderCopy : IOrderCopy
    {
        public void AddPoz(OrderNew order)
        {
            order.products.Add(new ProductNew()
            {
                name = "GRATIS",
                price_brutto = 1,
                ean = "",
                product_id = "1",
                quantity = 1,
                sku = "",
                storage = "db",
                storage_id = 0,
                tax_rate = 23,
                variant_id = 1,
                weight = 1
            });
        }

        public OrderNew Copy(Order order)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderNew>();
                cfg.CreateMap<Product, ProductNew>();
            });

            var mapper = new Mapper(config);
            var newOrder = mapper.Map<OrderNew>(order);

            newOrder.user_comments += $" Zamówienie utworzone na podstawie : {order.order_id}";

            return newOrder;
        }
    }
}
