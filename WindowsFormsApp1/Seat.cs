using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Seat : UserControl
    {
        const int MAX_SEAT_ORDER_SIZE = 4;
        private List<Order> orders = new List<Order>();
        private int totalPrice = 0;
        private string payPrice = "";
        private string payMethod = "";
        private int seatNum = 0;

        public Seat(int seatNum)
        {
            InitializeComponent();
            this.seatNum = seatNum;
            SeatSet();
        }

        public Seat(int seatNum, List<Order> orders)
        {
            InitializeComponent();
            this.seatNum = seatNum;
            this.orders = orders;
            SeatSet();
        }

        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string PayMethod { get => payMethod; set => payMethod = value; }
        public List<Order> Orders { get => orders; set => orders = value; }
        public int SeatNum { get => seatNum; set => seatNum = value; }
        public string PayPrice { get => payPrice; set => payPrice = value; }

        public void SeatSet()
        {
            this.seatNumText.Text = seatNum.ToString();
            if (orders.Count > 0)
                SeatOrderSet();
        }

        public void SeatOrderSet()
        {
            int cnt = 0;
            string orderText = "";
            foreach (Order order in orders)
            {
                if (cnt >= MAX_SEAT_ORDER_SIZE)
                {
                    orderText += "...";
                    break;
                }
                orderText += String.Format("{0} x {1}  {2} 원\n", order.Name, order.Count, order.GetPayMoney());
                cnt++;
            }
            SeatTextSet(orderText);
        }

         

        public void DefaultSet()
        {
            totalPrice = 0;
            PayPrice = "";
            payMethod = "";
            orderText.Text = "";
            totalPriceText.Text = "";
            payPriceText.Text = "";
            orders.Clear();
        }

        public int PayPriceCheck()
        {
            int tempPayPrice;

            if (payPrice != "")
            {
                if (int.TryParse(payPrice, out tempPayPrice))
                {
                    return tempPayPrice;
                }
                else
                {
                    return -1;
                }
            }

            return -1;
        }


        private void SeatTextSet(String orderText)
        {
            this.orderText.Text = orderText;
            if (PayPriceCheck() != -1)
            {
                this.totalPriceText.Text = String.Format("총 {0}원", TotalPrice);
                this.payPriceText.Text = String.Format("주문금액 {0}원({1})", PayPrice, PayMethod);
            } else
            {
                this.totalPriceText.Text = String.Format("총 {0}원({1})", TotalPrice,PayMethod);
            }
        }

        private void Seat_Load(object sender, EventArgs e)
        {
            this.orderText.Click += (s, args) => { this.OnClick(args); };
            this.totalPriceText.Click += (s, args) => { this.OnClick(args); };
            this.payPriceText.Click += (s, args) => { this.OnClick(args); };
        }
    }
}
