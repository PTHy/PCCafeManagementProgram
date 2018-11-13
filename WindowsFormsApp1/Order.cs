using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Order : Food
    {
        private int count = 1;
        private DateTime orderTime;
        public int Count { get => count; set => count = value; }

        public Order(string name, int price, DateTime orderTime, string category):base(price, name, category)
        {
            this.orderTime = orderTime;
        }

        public int GetPayMoney()
        {
            return base.Price * this.count;
        }
    }
}
