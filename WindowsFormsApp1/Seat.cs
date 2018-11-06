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
        private int totalPrice = 0;
        private int payPrice = 0;
        private string payMethod = "";
        internal DataGetEventHandler DataSendEvent;

        public Seat()
        {
            InitializeComponent();
        }

        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int PayPrice { get => payPrice; set => payPrice = value; }
        public string PayMethod { get => payMethod; set => payMethod = value; }

        public void SeatSet(int totalPrice, int payPrice, string payMethod, String orderText)
        {
            this.TotalPrice = totalPrice;
            this.PayPrice = payPrice;
            this.PayMethod = payMethod;

            SeatTextSet(orderText);
        }

        public void SeatSet(int totalPrice, string payMethod, String orderText)
        {
            this.TotalPrice = totalPrice;
            this.PayMethod = payMethod;

            SeatTextSet(orderText);
        }

        public void DefaultSet()
        {
            totalPrice = 0;
            payPrice = 0;
            payMethod = "";
            orderText.Text = "";
            totalPriceText.Text = "";
            payPriceText.Text = "";
        }


        private void SeatTextSet(String orderText)
        {
            this.orderText.Text = orderText;
            if (PayPrice != 0)
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
