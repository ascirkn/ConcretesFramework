using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkBetony.Model.Order
{
    class Order
    {
        internal string amount { get; set; }
        internal string netPrice { get; set; }
        internal string price { get; set; }
        internal string customer { get; set; }
        public Payment PaymentMethod { get; set; }
        internal Merchandise MerchandiseType { get; set; }
        public Status StatusType { get; set; }
    }
}
