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
        private Timer clock;
        private DateTime now = DateTime.Now;
        public DataGetEventHandler PayRequest;
        public DataGetEventHandler SubmitRequest;
        const int MAX_TABLE_WIDTH = 2;
        const float TABLE_CELL_WIDTH = (float) 100/MAX_TABLE_WIDTH;
        const float TABLE_CELL_HEIGHT = 140;
        const int ORDER_LIST_MENU_NAME_SIZE = 150;
        const int ORDER_LIST_COUNT_SIZE = 75;
        const int ORDER_LIST_PRICE_SIZE = 75;
        private string rootPath = Application.StartupPath;
        private string imagePath = "";
        Seat seat;
        string defaultImage = "";
        private string barcodeString = string.Empty;
        List<Food> menus;

        bool isSubmited = false;
        public Seat Seat { get => seat; set => seat = value; }

        public Seats(Seat seat, List<Food> menus)
        {
            InitializeComponent();
            this.menus = menus;
            this.seat = seat;
            SeatSet(seat.SeatNum);

            // 주문을 한 적이 있던 경우
            if (seat.Orders.Count >= 0)
            {
                SeatOrderSet();
            }
        }

        private void SeatsLoad(object sender, EventArgs e)
        {
            MenuSet();
            OrderListSetting();
            SetTime();
            ImagePathSet();
        }

        private void ImagePathSet()
        {
            string[] path = rootPath.Split('\\');

            foreach (string temp in path)
            {
                defaultImage += String.Format("{0}\\", temp);
                if (temp.Equals("PCCafeManagementProgram"))
                {
                    break;
                }
            }
            defaultImage += "resources\\image\\default.png";
        }

        private void SetTime()
        {
            SetTimeText();
            clock = new System.Windows.Forms.Timer();
            clock.Interval = 1000;
            clock.Tick += new EventHandler(TickTock);

            clock.Start();
        }

        private void TickTock(object sender, EventArgs e)
        {
            now = now.AddSeconds(1);
            SetTimeText();
        }

        private void SetTimeText()
        {
            orderTime.Text = now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void SeatOrderSet()
        {
            foreach (Order order in seat.Orders)
            {
                OrderListAdd(order);
            }
            SetPayMethod(seat.PayMethod);
            SetPayPrice();
            TotalPriceReload();
        }

        private void SetPayPrice()
        {
            if (seat.PayPriceCheck() != -1) 
            {
                payPrice.SelectedIndex = payPrice.FindString(seat.PayPrice);
            } else
            {
                payPrice.SelectedIndex = 4;
            }
            return;
        }

        private void TotalPriceSet()
        {
            totalPrice.Text = seat.TotalPrice.ToString();
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
            this.seatNumText.Text = this.seat.SeatNum.ToString();
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

        private void SeatsClosing(Object sender, CancelEventArgs e)
        {
           if(orderList.Items.Count > 0 && !isSubmited)
            {
                string message = "주문하시지 않은 정보는 없어집니다\n정말 메인으로 가시겠습니까?";
                string caption = "경고";
                var result = MessageBox.Show(message, caption,
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    seat.DefaultSet();
                    return;
                }
                e.Cancel = true;
            }
        }

        private bool IsAlreadyOrdered(string menuName)
        {
            // 이미 주문을 한 상태이면

            foreach (Order seatOrder in seat.Orders)
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
            Order newOrder = new Order(selectedFood.Name, selectedFood.Price, DateTime.Now, selectedFood.Category_.ToString());
            seat.Orders.Add(newOrder);
            OrderListAdd(newOrder);
            seat.TotalPrice += newOrder.Price;
            TotalPriceReload();
        }

        private void TotalPriceReload()
        {
            totalPrice.Text = seat.TotalPrice.ToString();
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
                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            Button op = (Button)sender;

            string selectedMenuName = orderList.SelectedItems[0].Text;

            foreach (Order order in seat.Orders)
            {
                if (order.Name.Equals(selectedMenuName))
                {
                    if (op.Text.Equals("+"))
                    {
                        order.Count += 1;
                        seat.TotalPrice += order.Price;
                        TotalPriceReload();
                    }
                    else
                    {
                        if (order.Count == 1)
                        {
                            OrderListRemove(order);
                            seat.TotalPrice -= order.Price;
                            TotalPriceReload();
                            return;
                        }
                        order.Count -= 1;
                        seat.TotalPrice -= order.Price;
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
            seat.Orders.Remove(order);
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

        private void FoodImageSet(string menuName)
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
                FoodImageSet(orderList.SelectedItems[0].Text);
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
            seat.Orders.Clear();
            orderList.Items.Clear();
            SetDefaultImage();
            seat.TotalPrice = 0;
            TotalPriceReload();
        }

        private void SubmitClick(object sender, EventArgs e)
        {
            if (IsValidRequest())
            {
                SeatClone();
                SubmitRequest(seat);
                MessageBox.Show("주문이 되었습니다", "주문 성공",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                isSubmited = true;
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

            if(orderList.Items.Count <= 0)
            {
                MessageBox.Show("선택된 주문이 없습니다", "결제 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (cash.Checked == false && card.Checked == false)
            {
                MessageBox.Show("결제 방법을 선택해주세요", "주문 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (payPrice.SelectedIndex < 0) // 지불 금액이 선택되지 않았을 때
            {
                MessageBox.Show("지불 금액이 선택되지 않았습니다", "주문 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false; 
            }
            else if (int.TryParse(payPrice.SelectedItem as string, out temp)) // 지불 금액이 숫자일 때
            {
                if(temp < seat.TotalPrice)
                {
                    MessageBox.Show("지불 금액이 총 금액보다 적습니다", "주문 실패",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

            foreach (Order order in seat.Orders)
            {
                message += String.Format("{0} x {1} = {2}\n",order.Name, order.Count, order.GetPayMoney());

                if(++i > 5)
                {
                    break;
                }
            }

            message += "\n결제하시겠습니까?";

            return message;
        }

        private void SeatClone()
        {
            seat.PayMethod = GetPayMethod();
            seat.PayPrice = payPrice.SelectedItem.ToString();
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
                    isSubmited = true;
                    Close();
                    SeatClone();
                    PayRequest(seat);
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
