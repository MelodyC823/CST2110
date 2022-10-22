using System;
using System.Collections.Generic;
using System.Text;

namespace _2110_Sep2022.Queue
{
    public class Order
    {
        public string OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDateTime { get; set; }
        public List<Address> DeliveryAddresses { get; set; }

        public override string ToString()
        {
            return string.Format("OrderID:{0} - CutomerID:{1}", this.OrderID, this.CustomerID);
        }
    }
}
