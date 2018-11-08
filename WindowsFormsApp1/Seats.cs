using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Seats : Form
    {
        public DataGetEventHandler PayRequest;
        public DataGetEventHandler SubmitRequest;
        Seats sendSeat;
        const int MAX_TABLE_WIDTH = 2;
        const float TABLE_CELL_WIDTH = (float) 100/MAX_TABLE_WIDTH;
        const float TABLE_CELL_HEIGHT = 140;
        const int ORDER_LIST_MENU_NAME_SIZE = 150;
        const int ORDER_LIST_COUNT_SIZE = 75;
        const int ORDER_LIST_PRICE_SIZE = 75;

        List<Order> seatOrders = new List<Order>();
        Seat seat;
        Seats tempSeats;
        int tempTotalPrice = 0;
        int seatNum;
        string tempPayMethod;
        string tempPayPrice;
        string defaultImage = Main.ImagePath + "default.png";
        private string barcodeString = string.Empty;
        List<Food> menus;

        public int SeatNum { get => seatNum; set => seatNum = value; }
        public int TempTotalPrice { get => tempTotalPrice; set => tempTotalPrice = value; }
        public string TempPayMethod { get => tempPayMethod; set => tempPayMethod = value; }
        public string TempPayPrice { get => tempPayPrice; set => tempPayPrice = value; }
        public List<Order> SeatOrders { get => seatOrders; set => seatOrders = value; }

        // 주문을 한 적이 없던 경우

        public Seats(int seatNum, List<Food> menus)
        {
            InitializeComponent();
            this.menus = menus;
            SeatSet(seatNum);
        }

        // 주문을 한 적이 있던 경우

        public Seats(int seatNum, List<Order> seatOrders,Seat seat, List<Food> menus)
        {
            InitializeComponent();
            this.seatOrders = seatOrders;
            this.seat = seat;
            this.menus = menus;
            SeatSet(seatNum);
            SeatOrderSet();
        }

        private void Seats_Load(object sender, EventArgs e)
        {
            MenuSet();
            OrderListSetting();
        }

        private void SeatOrderSet()
        {
            foreach (Order seatOrder in SeatOrders)
            {
                OrderListAdd(seatOrder);
                TempTotalPrice += seatOrder.GetPayMoney();
            }
            SetPayMethod(seat.PayMethod);
            SetPayPrice(seat.PayPrice);
            TotalPriceReload();
        }

        private void SetPayPrice(int payPrice)
        {
            if (payPrice != 0) 
            {
                this.payPrice.SelectedIndex = this.payPrice.FindString(payPrice.ToString());
            } else
            {
                this.payPrice.SelectedIndex = 4;
            }
            return;
        }

        private void TotalPriceSet()
        {
            totalPrice.Text = TempTotalPrice.ToString();
        }

        private void OrderListSetting()
        {
            this.orderList.BeginUpdate();
            this.orderList.Columns.Add("메뉴 이름", ORDER_LIST_MENU_NAME_SIZE);
            this.orderList.Columns.Add("수량", ORDER_LIST_COUNT_SIZE, HorizontalAlignment.Center);
            this.orderList.Columns.Add("가격", ORDER_LIST_PRICE_SIZE, HorizontalAlignment.Center);
            this.orderList.EndUpdate();
        }

        private void SeatSet(int seatNum)
        {
            this.SeatNum = seatNum;
            this.seatNumText.Text = this.SeatNum.ToString();
        }

        private void MenuSet()
        {
            int columnCnt = 0;
            int rowCnt = 0;

            foreach (Food menu in menus)
            {
                Menu newMenu = AddMenu(menu);
                tbMenus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, MAX_TABLE_WIDTH));
                tbMenus.Controls.Add(newMenu, columnCnt, rowCnt);
                columnCnt++;

                if (columnCnt >= MAX_TABLE_WIDTH)
                {
                    tbMenus.RowStyles.Add(new RowStyle(SizeType.Absolute, TABLE_CELL_HEIGHT));
                    columnCnt = 0;
                    rowCnt++;
                }
            }
            tbMenus.ColumnCount = MAX_TABLE_WIDTH;
            tbMenus.RowCount = rowCnt;
        }

        private void MenuSet(String category)
        {
            int columnCnt = 0;
            int rowCnt = 0;

            foreach(Food menu in menus)
            {
                if((menu.Category_.ToString()).Equals(category))
                {
                    Menu newMenu = AddMenu(menu);
                    tbMenus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, MAX_TABLE_WIDTH));
                    tbMenus.Controls.Add(newMenu, columnCnt, rowCnt);
                    columnCnt++;
 
                    if (columnCnt >= MAX_TABLE_WIDTH)
                    {
                        tbMenus.RowStyles.Add(new RowStyle(SizeType.Absolute, TABLE_CELL_HEIGHT));
                        columnCnt = 0;
                        rowCnt++;
                    }
                }
            }
            tbMenus.ColumnCount = MAX_TABLE_WIDTH;
            tbMenus.RowCount = rowCnt;
        }

        private Menu AddMenu(Food menu)
        {
            Menu newMenu = new Menu();
            newMenu.MenuName.Text = menu.Name;
            newMenu.MenuPrice.Text = menu.Price.ToString();
            newMenu.Cursor = Cursors.Hand;
            newMenu.Click += (s, e) =>
            {
                MenuClick(s, e);
            };

            try
            {
                newMenu.BackgroundImage = new Bitmap(menu.Image);
            }
            catch(Exception e) { }

            return newMenu;
        }

        private void MenuClick(object s, EventArgs e)
        {
            Menu selectedMenu = (Menu)s;
            string menuName = selectedMenu.MenuName.Text;

            foodImageSet(selectedMenu);

            if(IsAlreadyOrdered(selectedMenu.MenuName.Text))
            {
                return;
            }
            

            Food searchFood = menus.Find(x => x.Name == selectedMenu.MenuName.Text);

            if(searchFood != null)
            {
                AddOrder(searchFood);
            }
        }

        private bool IsAlreadyOrdered(string menuName)
        {
            // 이미 주문을 한 상태이면

            foreach (Order seatOrder in SeatOrders)
            {
                if (seatOrder.Name.Equals(menuName))
                {
                    return true;
                }
            }

            return false;
        }

        private void AddOrder(Food selectedFood)
        {
            Order newOrder = new Order(selectedFood.Name, selectedFood.Price, DateTime.Now);
            SeatOrders.Add(newOrder);
            OrderListAdd(newOrder);
            TempTotalPrice += newOrder.Price;
            TotalPriceReload();
        }

        private void TotalPriceReload()
        {
            totalPrice.Text = TempTotalPrice.ToString();
        }

        private void OrderListAdd(Order order)
        {
            this.orderList.BeginUpdate();
            ListViewItem lvi = new ListViewItem(order.Name);
            lvi.SubItems.Add(order.Count.ToString());
            lvi.SubItems.Add(order.GetPayMoney().ToString());
            this.orderList.Items.Add(lvi);
            this.orderList.EndUpdate();
        }

        private void CategoryClick(object sender, EventArgs s)
        {
            tbMenus.Controls.Clear();
            tbMenus.ColumnCount = 0;
            tbMenus.RowCount = 0;
            Button selected = (Button)sender;
            if (selected.Name.Equals("All"))
            {
                MenuSet();
            } else {
                MenuSet(selected.Name);
            }
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            if (orderList.SelectedItems.Count < 0)
            {
                MessageBox.Show("주문선택이 되지 않은 채 버튼이 눌렸습니다", "수정 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            Button op = (Button)sender;

            string selectedMenuName = orderList.SelectedItems[0].Text;

            foreach (Order order in SeatOrders)
            {
                if (order.Name.Equals(selectedMenuName))
                {
                    if (op.Text.Equals("+"))
                    {
                        order.Count += 1;
                        TempTotalPrice += order.Price;
                        TotalPriceReload();
                    }
                    else
                    {
                        if (order.Count == 1)
                        {
                            OrderListRemove(order);
                            TempTotalPrice -= order.Price;
                            TotalPriceReload();
                            return;
                        }
                        order.Count -= 1;
                        TempTotalPrice -= order.Price;
                        TotalPriceReload();
                    }
                    OrderListSet(order);
                }
            }
        }

        private void OrderListSet(Order order)
        {
            orderList.SelectedItems[0].SubItems[1].Text = order.Count.ToString(); // 주문한 메뉴 개수
            orderList.SelectedItems[0].SubItems[2].Text = order.GetPayMoney().ToString();
        }

        private void OrderListRemove(Order order)
        {
            SeatOrders.Remove(order);
            foreach (ListViewItem eachItem in orderList.SelectedItems)
            {
                orderList.Items.Remove(eachItem);
            }
        }

        private void foodImageSet(Menu selectedMenu)
        {
            try
            {
                foodImage.BackgroundImage = new Bitmap(selectedMenu.BackgroundImage);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        private void foodImageSet(string menuName)
        {
            foreach(Food menu in menus)
            {
                if(menu.Name.Equals(menuName))
                {
                    try
                    {
                        foodImage.BackgroundImage = new Bitmap(menu.Image);
                    }
                    catch (Exception) { }
                }
            }
        }

        private void OrderListSelectedIndexChanged(object sender, EventArgs e)
        {
            bool selected = orderList.SelectedItems.Count > 0;

            if (selected)
            {
                EnableOperators();
                foodImageSet(orderList.SelectedItems[0].Text);
            }
            else
            {
                DisableOperators();
                SetDefaultImage();
            }
        }

        private void EnableOperators()
        {
            plus.Enabled = true;
            minus.Enabled = true;
        }

        private void DisableOperators()
        {
            plus.Enabled = false;
            minus.Enabled = false;
        }

        private void SetDefaultImage()
        {
            try
            {
                foodImage.BackgroundImage = new Bitmap(defaultImage);
            }
            catch (Exception) { }
        }

        private void ResetClick(object sender, EventArgs e)
        {
            SeatOrders.Clear();
            orderList.Items.Clear();
            SetDefaultImage();
            TempTotalPrice = 0;
            TotalPriceReload();
        }

        private void SeatsClone()
        {
            tempSeats = new Seats(seatNum, menus);
            tempSeats.tempPayMethod = this.GetPayMethod();
            tempSeats.SeatOrders = this.SeatOrders;
            tempSeats.seat = this.seat;
            tempSeats.tempTotalPrice = this.tempTotalPrice;
            tempSeats.TempPayPrice = payPrice.SelectedItem as string;
        }

        //private void SubmitClick(object sender, EventArgs e)
        //{
        //    if(IsValidRequest())
        //    {
        //        return;
        //    }

        //    int intPayPrice;
        //    string payMethod = "";
        //    Loading.Main.SeatOrders[SeatNum - 1] = seatOrders;

        //    payMethod = GetPayMethod();
        //    if (int.TryParse(payPrice.SelectedItem as string, out intPayPrice))
        //    {
        //        Loading.Main.SeatOrderSet(SeatNum, TempTotalPrice, intPayPrice, payMethod);
        //    }
        //    else
        //    {
        //        Loading.Main.SeatOrderSet(SeatNum, TempTotalPrice, payPrice.SelectedItem as string, payMethod);
        //    }
        //    MessageBox.Show("주문이 되었습니다", "주문 성공",
        //    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

        //    Hide();
        //    Loading.Main.Show();
        //}

        private void SubmitClick(object sender, EventArgs e)
        {
            if (IsValidRequest())
            {
                SeatsClone();

                SubmitRequest(tempSeats);
                MessageBox.Show("주문이 되었습니다", "주문 성공",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                Close();
            }

        }

        private void SetPayMethod(string payMethod)
        {
            if (payMethod == "현금")
            {
                cash.Checked = true;
                return;
            }
            else if (payMethod == "카드")
            {
                card.Checked = true;
                return;
            }
            else return;
        }
        
        private string GetPayMethod()
        {
            if (cash.Checked == true) return "현금";
            else if (card.Checked == true) return "카드";
            else return "";
        }

        private bool IsValidRequest()
        {
            int temp;

            if(SeatOrders == null)
            {
                MessageBox.Show("선택된 주문이 없습니다", "결제 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return false;
            }
            if (cash.Checked == false && card.Checked == false)
            {
                MessageBox.Show("결제 방법을 선택해주세요", "주문 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return false;
            }
            if (payPrice.SelectedIndex < 0) // 지불 금액이 선택되지 않았을 때
            {
                MessageBox.Show("지불 금액이 선택되지 않았습니다", "주문 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return false; 
            }
            else if (int.TryParse(payPrice.SelectedItem as string, out temp)) // 지불 금액이 숫자일 때
            {
                if(temp < TempTotalPrice)
                {
                    MessageBox.Show("지불 금액이 총 금액보다 적습니다", "주문 실패",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    return false;
                }
            }

            return true;
        }

        private void HomeClick(object sender, EventArgs e)
        {
            Close();
        }

        private string GetPayMessage()
        {
            string message = "";
            int i = 0;

            foreach (Order seatOrder in SeatOrders)
            {
                message += String.Format("{0} x {1} = {2}\n",seatOrder.Name, seatOrder.Count, seatOrder.GetPayMoney());

                if(++i > 5)
                {
                    break;
                }
            }

            message += "\n결제하시겠습니까?";

            return message;
        }

        private void PayClick(object sender, EventArgs e)
        {

            string message = GetPayMessage();
            string caption = "결제";
            var result = MessageBox.Show(message, caption,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                // cancel the closure of the form.
                return;
            } else
            {
                if (IsValidRequest())
                {
                    SeatsClone();
                    Close();
                    PayRequest(tempSeats);
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            this.ActiveControl = null;
            if (msg.Msg == 0x100)
            {
                string log = string.Format("ProcessCmdKey KeyData: {0}", keyData);
                if (keyData == Keys.Return)
                {
                    Food selectedFood = GetSelectedFoodByBarcode(barcodeString);
                    if (selectedFood != null && !IsAlreadyOrdered(selectedFood.Name))
                    {
                        AddOrder(selectedFood);
                    }
                    barcodeString = string.Empty;
                }
                else
                {
                    barcodeString += char.ConvertFromUtf32((int)keyData);
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private Food GetSelectedFoodByBarcode(string barcodeString)
        {
            Food searchFood = menus.Find(x => x.Barcode.Equals(barcodeString));

            return searchFood;
        }
    }
}
