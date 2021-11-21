using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZadanieBaseLinker.Model
{
    public class ProductNew
    {
        public string storage { get; set; }
        public int storage_id { get; set; }
        public string product_id { get; set; }
        public int variant_id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string ean { get; set; }
        public float price_brutto { get; set; }
        public int tax_rate { get; set; }
        public int quantity { get; set; }
        public float weight { get; set; }
    }
}
