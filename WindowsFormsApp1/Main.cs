using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Threading;

namespace WindowsFormsApp1
{
    public delegate void DataPushEventHandler(Seats seats);
    public delegate void DataGetEventHandler(Seats seats);

    public partial class Main : Form
    {
        const string databaseConfig = "server=localhost;user id=root;password=password;persistsecurityinfo=True;port=3306;database=restaurant;SslMode=none;CharSet=utf8";
        const int MAX_TABLE_SIZE = 9;
        const int MAX_TABLE_WIDTH = 3;
        const int MAX_TABLE_HEIGHT = MAX_TABLE_SIZE / MAX_TABLE_WIDTH + (MAX_TABLE_SIZE % MAX_TABLE_WIDTH == 0 ? 0 : 1);
        const float TABLE_CELL_WIDTH = (float)100 / MAX_TABLE_WIDTH;
        const float TABLE_CELL_HEIGHT = (float)100 / MAX_TABLE_HEIGHT;
        const int MAX_SEAT_ORDER_SIZE = 4;
        const string imagePath = "D:\\Dev\\C#\\PCCafeManagementProgram\\resources\\image\\";
        string query;
        private DateTime now = DateTime.Now;
        private System.Windows.Forms.Timer timer;
        private Thread timerThread;
        MySqlConnection scon = null;
        MySqlCommand scom = null;
        MySqlDataReader sdr = null;
        List<Food> menus = new List<Food>();
        Seat[] seats = new Seat[MAX_TABLE_SIZE];
        List<Order>[] seatOrders = new List<Order>[MAX_TABLE_SIZE];

        public static string ImagePath => imagePath;

        internal List<Order>[] SeatOrders { get => seatOrders; set => seatOrders = value; }
        public Seat[] Seats { get => seats; set => seats = value; }

        public Main()
        { 
            InitializeComponent();
        }


        private void MainLoad(object sender, EventArgs e)
        {
            Loading();
            DatabaseConnecting();
            SetTime();
            MenuLoad();
            CreateTables();
        }

        private void MainClosing(Object sender, CancelEventArgs e)
        {
            string message = "종료하시겠습니까?";
            string caption = "종료";
            var result = MessageBox.Show(message, caption,
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // cancel the closure of the form.
                return;
            }
            e.Cancel = true;
        }

        private void SetTime()
        {
            SetTimeText();
            timerThread = new Thread(new ThreadStart(SetTimer));
            timerThread.Start();
        }
            
        private void SetTimeText()
        {
            time1.Text = now.ToString("yyyy-MM-dd");
            time2.Text = now.ToString("HH:mm:ss");
        }

        private void SetTimer()
        {
            timer = new System.Windows.Forms.Timer();

            // 1초마다 발생
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timerTick);

            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            Console.WriteLine("hi");
            now.AddSeconds(1);
            SetTimeText();
        }

        private void Loading()
        {
            this.Hide();
            Loading loading = new Loading();
            loading.ShowDialog();
            loading.Closed += (s, e) =>
            {
                Show();
            };
        }

        //테이블들 만들기

        private void CreateTables()
        {
            tb.ColumnCount = MAX_TABLE_WIDTH;
            tb.RowCount = MAX_TABLE_HEIGHT;
            int cnt = 1;

            for (int i = 0; i < tb.RowCount; i++)
            {
                for(int j = 0; j < tb.ColumnCount; j++)
                {
                    String seatNum = cnt.ToString();
                    Seat newSeat = AddSeat(seatNum);
                    Seats[cnt - 1] = newSeat;
                    tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, TABLE_CELL_WIDTH));
                    tb.Controls.Add(newSeat,j,i);
                    cnt++;
                }
                tb.RowStyles.Add(new RowStyle(SizeType.Percent, TABLE_CELL_HEIGHT));
            }
        }

        // 좌석 추가

        private Seat AddSeat(string seatNum, List<Order> orders)
        {
            Seat seat = new Seat();
            seat.TableNumber.Text = seatNum;
            int cnt = 0;
            seat.TabIndex = 1;
            seat.Cursor = Cursors.Hand;
            seat.Click += (s, e) =>
            {
                SeatClick(s, e);
            };

            /*foreach (Order order in orders)
            {
                string order_element = order.Name + "        " + order.Price;
                Label order_label  = new Label() { Text = order_element };
                seat.Controls.Add(order_label);
                cnt++;
            }*/

            return seat;
        }

        // 좌석 추가

        private Seat AddSeat(string seatNum)
        {
            Seat seat = new Seat();
            int intSeatNum = Int32.Parse(seatNum);
            seat.TableNumber.Text = seatNum;
            seat.Cursor = Cursors.Hand;
            seat.Click += (s, e) =>
            {
                SeatClick(s, e);
            };
            

            // SeatOrdersLoad(seat);
            // seat.Size = new Size(SEAT_WIDTH, SEAT_HEIGHT);
            return seat;
        }

        private void PayRequest(Seats seats)
        {
            seatOrders[seats.SeatNum - 1] = seats.SeatOrders;
            Pay(seats.SeatNum, seats.TempTotalPrice, seats.TempPayMethod);
        }

        private void SubmitRequest(Seats seats)
        {
            seatOrders[seats.SeatNum - 1] = seats.SeatOrders;
            int intPayPrice;
            if (int.TryParse(seats.TempPayPrice, out intPayPrice))
            {
                SeatOrderSet(seats.SeatNum, seats.TempTotalPrice, intPayPrice, seats.TempPayMethod);
            }
            else
            {
               SeatOrderSet(seats.SeatNum, seats.TempTotalPrice, seats.TempPayPrice, seats.TempPayMethod);
            }
        }

        public void SeatOrderSet(int seatNum, int totalPrice, string payPrice, string payMethod)
        {
            seats[seatNum - 1].DefaultSet();
            List<Order> seatOrder = SeatOrders[seatNum - 1];
            int cnt = 0;
            string orderText = "";
            foreach (Order order in seatOrder)
            {
                if (cnt >= MAX_SEAT_ORDER_SIZE)
                {
                    orderText += "...";
                    break;
                }
                orderText += String.Format("{0} x {1}  {2} 원\n",order.Name, order.Count, order.GetPayMoney());
                cnt++;
            }
            seats[seatNum - 1].SeatSet(totalPrice, payMethod, orderText);
        }

        public void SeatOrderSet(int seatNum, int totalPrice, int payPrice, string payMethod)
        {
            seats[seatNum - 1].DefaultSet();
            List<Order> seatOrder = SeatOrders[seatNum - 1];
            int cnt = 0;
            string orderText = "";
            foreach (Order order in seatOrder)
            {
                if (cnt >= MAX_SEAT_ORDER_SIZE)
                {
                    orderText += "...";
                    break;
                }
                orderText += String.Format("{0} x {1}  {2} 원\n", order.Name, order.Count, order.GetPayMoney());
                cnt++;
            }
            seats[seatNum - 1].SeatSet(totalPrice, payPrice, payMethod, orderText); 
        }

        // 좌석 클릭

        private void SeatClick(object s, EventArgs e)
        {
            Hide();
            Seat seat = (Seat)s;
            int seatNum = Int32.Parse(seat.TableNumber.Text);
            Seats od;
            if (seatOrders[seatNum - 1] == null)
            {
                od = new Seats(seatNum, menus);
            } else
            {
                od = new Seats(seatNum, seatOrders[seatNum - 1], seats[seatNum - 1], menus);
            }
            od.Closed += (a, args) => Show();
            od.PayRequest = new DataGetEventHandler(this.PayRequest);
            od.SubmitRequest = new DataGetEventHandler(this.SubmitRequest);
            od.ShowDialog();
        }

        private void DatabaseConnecting()
        {
            try
            {
                scon = new MySqlConnection(databaseConfig);
                scon.Open();
                scom = new MySqlCommand();
                scom.Connection = scon;
            } catch (Exception error)
            {
                MessageBox.Show("DB 연결에 실패하였습니다\n"+error.Message, "DB 연결 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }
        private void MenuLoad()
        {
            try
            {
                query = "SELECT * FROM menus";
                scom.CommandText = query;
                sdr = scom.ExecuteReader();

                while (sdr.Read())
                {
                    int price = int.Parse(sdr["price"].ToString());
                    string name = sdr["name"].ToString();
                    string image = ImagePath + name+".jpg";
                    string category = sdr["category"].ToString();
                    string barcode = sdr["barcode"].ToString();
                    menus.Add(new Food(price, name, image, category,barcode));
                }
            } catch (Exception error)
            {
                MessageBox.Show("메뉴 불러오기에 실패하였습니다\n"+error.Message, "메뉴 불러오기 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            } finally
            {
                sdr.Close();
            }
        }

        private void Pay(int seatNum, int totalPrice, string payMethod)
        {
            try
            {
                query = String.Format("INSERT INTO pay_log (table_idx, total_price, pay_method) VALUES ({0}, {1}, '{2}');", seatNum, totalPrice, payMethod);
                scom.CommandText = query;
                scom.ExecuteNonQuery();

                long lastIdx = scom.LastInsertedId;

                foreach(Order seatOrder in seatOrders[seatNum - 1])
                {
                    LogEachOrder(lastIdx,seatOrder);
                }

                seatOrders[seatNum - 1] = null;
                seats[seatNum - 1].DefaultSet();
                MessageBox.Show("결제가 되었습니다", "결제 성공",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            } catch (Exception error)
            {
                MessageBox.Show("결제에 실패하였습니다\n" + error.Message, "결제 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void LogEachOrder(long lastIdx,Order seatOrder)
        {
            try
            {
                query = String.Format("INSERT INTO pay_log_detail (pay_log_idx, menu, count) VALUES ({0}, (SELECT idx FROM menus WHERE name LIKE '{1}'), {2});;", lastIdx, seatOrder.Name, seatOrder.Count);
                scom.CommandText = query;
                scom.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show("결제에 실패하였습니다\n" + error.Message, "결제 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void exitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void statisticsClick(object sender, EventArgs e)
        {
            this.Hide();
            Ststistics st = new Ststistics(scom);
            st.Closed += (s, args) => { Show(); };
            st.ShowDialog();
        }
    }
}
