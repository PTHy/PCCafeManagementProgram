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
    public delegate void DataPushEventHandler(Seat seats);
    public delegate void DataGetEventHandler(Seat seats);

    public partial class Main : Form
    {
        const int MAX_TABLE_SIZE = 9;
        const int MAX_TABLE_WIDTH = 3;
        const int MAX_TABLE_HEIGHT = MAX_TABLE_SIZE / MAX_TABLE_WIDTH + (MAX_TABLE_SIZE % MAX_TABLE_WIDTH == 0 ? 0 : 1);
        const float TABLE_CELL_WIDTH = (float)100 / MAX_TABLE_WIDTH;
        const float TABLE_CELL_HEIGHT = (float)100 / MAX_TABLE_HEIGHT;
        private string rootPath = Application.StartupPath;
        private string imagePath = "";
        string query;
        DatabaseManager dm = new DatabaseManager();
        private DateTime now = DateTime.Now;
        List<Food> menus = new List<Food>();
        Seat[] seats = new Seat[MAX_TABLE_SIZE];
        private System.Windows.Forms.Timer clock;

        public Seat[] Seats { get => seats; set => seats = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }

        public Main()
        { 
            InitializeComponent();
        }

        private void MainLoad(object sender, EventArgs e)
        {
            Loading();
            ImagePathSet();
            SetTime();
            MenuLoad();
            CreateTables();
        }

        private void ImagePathSet()
        {
            string[] path = rootPath.Split('\\');

            foreach(string temp in path)
            {
                ImagePath += String.Format("{0}\\",temp);  
                if (temp.Equals("PCCafeManagementProgram"))
                {
                    break;
                }
            }
            ImagePath += "resources\\image\\";
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
            time1.Text = now.ToString("yyyy-MM-dd");
            time2.Text = now.ToString("HH:mm:ss");
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
            int seatNum = 1;

            for (int i = 0; i < tb.RowCount; i++)
            {
                for(int j = 0; j < tb.ColumnCount; j++)
                {
                    Seat newSeat = AddSeat(seatNum);
                    Seats[seatNum - 1] = newSeat;
                    tb.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, TABLE_CELL_WIDTH));
                    tb.Controls.Add(newSeat,j,i);
                    seatNum++;
                }
                tb.RowStyles.Add(new RowStyle(SizeType.Percent, TABLE_CELL_HEIGHT));
            }
        }

        // 좌석 추가

        private Seat AddSeat(int seatNum, List<Order> orders)
        {
            Seat seat = new Seat(seatNum, orders);
            seat.SeatOrderSet();
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

        private Seat AddSeat(int seatNum)
        {
            Seat seat = new Seat(seatNum);
            seat.Cursor = Cursors.Hand;
            seat.Click += (s, e) =>
            {
                SeatClick(s, e);
            };
            

            // SeatOrdersLoad(seat);
            // seat.Size = new Size(SEAT_WIDTH, SEAT_HEIGHT);
            return seat;
        }

        private void PayRequest(Seat seat)
        {
            this.seats[seat.SeatNum - 1] = seat;
            Pay(seat);
        }

        private void SubmitRequest(Seat seat)
        {
            seats[seat.SeatNum - 1] = seat;
            seats[seat.SeatNum - 1].SeatOrderSet();
        }

        // 좌석 클릭

        private void SeatClick(object s, EventArgs e)
        {
            Hide();
            Seat seat = (Seat)s;
            int seatNum = Int32.Parse(seat.TableNumber.Text);
            Seats od;
            od = new Seats(seat, menus);
            od.Closed += (a, args) => Show();
            od.PayRequest = new DataGetEventHandler(this.PayRequest);
            od.SubmitRequest = new DataGetEventHandler(this.SubmitRequest);
            od.ShowDialog();
        }
        private void MenuLoad()
        {
            DataSet ds;
            try
            {
                query = "SELECT * FROM menus";
                ds = dm.Select(query);
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    int price = int.Parse(r["price"].ToString());
                    string name = r["name"].ToString();
                    string image = ImagePath + name + ".jpg";
                    string category = r["category"].ToString();
                    string barcode = r["barcode"].ToString();
                    menus.Add(new Food(price, name, image, category, barcode));    
                }
            } catch (Exception error)
            {
                MessageBox.Show("메뉴 불러오기에 실패하였습니다\n"+error.Message, "메뉴 불러오기 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void Pay(Seat seat)
        {
            try
            {
                query = String.Format("INSERT INTO pay_log (table_idx, total_price, pay_method) VALUES ({0}, {1}, '{2}');", seat.SeatNum, seat.TotalPrice, seat.PayMethod);

                long lastIdx = dm.Insert(query);

                foreach(Order order in seats[seat.SeatNum - 1].Orders)
                {
                    LogEachOrder(lastIdx,order);
                }

                seats[seat.SeatNum - 1].DefaultSet();
                MessageBox.Show("결제가 되었습니다", "결제 성공",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            } catch (Exception error)
            {
                MessageBox.Show("결제에 실패하였습니다\n" + error.Message, "결제 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void LogEachOrder(long lastIdx,Order order)
        {
            try
            {
                query = String.Format("INSERT INTO pay_log_detail (pay_log_idx, menu, count) VALUES ({0}, (SELECT idx FROM menus WHERE name LIKE '{1}'), {2});", lastIdx, order.Name, order.Count);
                dm.Insert(query);
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
            Ststistics st = new Ststistics();
            st.Closed += (s, args) => { Show(); };
            st.ShowDialog();
        }
    }
}
