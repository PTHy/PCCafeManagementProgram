using MySql.Data.MySqlClient;
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
    public partial class Ststistics : Form
    {
        const int STST_CATEGORIZE_SIZE = 150;
        const int STST_COUNT_SIZE = 75;
        const int STST_PRICE_SIZE = 75;
        MySqlCommand scom = null;
        MySqlDataReader sdr = null;
        DateTime selectedDate = DateTime.Now;
        List <Log> Logs = new List<Log> { };
        int totalPrice = 0;
        string query;

        public Ststistics(MySqlCommand scom)
        {
            InitializeComponent();
            DatabaseSetting(scom);
            StartStst();
            SetStst();
        }

        private void DatabaseSetting(MySqlCommand scom)
        {
            this.scom = scom;
        }

        private void StartStst()
        {
            StartMenuStst();
            StartCategoryStst();
            StartPayMethodStst();
        }

        private void StartPayMethodStst()
        {
            this.payMethodStst.BeginUpdate();
            this.payMethodStst.View = View.Details;
            this.payMethodStst.Columns.Add("결제방법", STST_CATEGORIZE_SIZE);
            this.payMethodStst.Columns.Add("수량", STST_COUNT_SIZE, HorizontalAlignment.Center);
            this.payMethodStst.Columns.Add("가격", STST_PRICE_SIZE, HorizontalAlignment.Center);
            this.payMethodStst.EndUpdate();
        }

        private void StartCategoryStst()
        {
            this.categoryStst.BeginUpdate();
            this.categoryStst.View = View.Details;
            this.categoryStst.Columns.Add("카테고리", STST_CATEGORIZE_SIZE);
            this.categoryStst.Columns.Add("수량", STST_COUNT_SIZE, HorizontalAlignment.Center);
            this.categoryStst.Columns.Add("가격", STST_PRICE_SIZE, HorizontalAlignment.Center);
            this.categoryStst.EndUpdate();
        }

        private void StartMenuStst()
        {
            this.menuStst.BeginUpdate();
            this.menuStst.View = View.Details;
            this.menuStst.Columns.Add("메뉴 이름", STST_CATEGORIZE_SIZE);
            this.menuStst.Columns.Add("수량", STST_COUNT_SIZE, HorizontalAlignment.Center);
            this.menuStst.Columns.Add("가격", STST_PRICE_SIZE, HorizontalAlignment.Center);
            this.menuStst.EndUpdate();
        }

        

        private void SetStst()
        {
            SetDefault();
            SetCategoryStst();
            SetMenuStst();
            SetPayMethodStst();
            SetTotalPrice();
        }

        private void SetDefault()
        {
            totalPrice = 0;
            menuStst.Items.Clear();
            categoryStst.Items.Clear();
            payMethodStst.Items.Clear();
        }

        private void SetTotalPrice()
        {
            lbTotalPrice.Text = String.Format("{0}원",totalPrice);
        }

        private void DateTimePickerChange(object sender, EventArgs e)
        {
            selectedDate = dateTimePicker.Value;
            SetStst();
        }

        private void SetPayMethodStst()
        {
            try
            {
                query = String.Format("SELECT pay_method,SUM(count) as count, SUM(price) as price,pay_date FROM  (SELECT pay_method,pay_date,count,price,name,category FROM pay_log JOIN pay_log_detail ON pay_log.idx = pay_log_detail.pay_log_idx JOIN menus ON pay_log_detail.menu = menus.idx {0})TEMP GROUP BY pay_method;",DayQuery());
                scom.CommandText = query;
                sdr = scom.ExecuteReader();
                
                this.payMethodStst.BeginUpdate();
                while (sdr.Read())
                {
                    ListViewItem lvi = new ListViewItem(sdr["pay_method"].ToString());
                    lvi.SubItems.Add(sdr["count"].ToString());
                    lvi.SubItems.Add(sdr["price"].ToString());
                    this.payMethodStst.Items.Add(lvi);
                }
                this.payMethodStst.EndUpdate();
            }
            catch (Exception error)
            {
                MessageBox.Show("통계 불러오기에 실패하였습니다\n" + error.Message, "통계 불러오기 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                }
            }
        }

        private string DayQuery()
        {
            return String.Format("WHERE pay_log.pay_date >= '{0} 00:00:00' AND pay_log.pay_date <= '{1} 24:00:00'", selectedDate.ToString("yyyy-MM-dd"), selectedDate.ToString("yyyy-MM-dd"));
        }

        private string GetCategoryName(string category)
        {
            switch(category)
            {
                case "Drink":
                    return "음료류";
                    break;
                case "Ramen":
                    return "라면류";
                    break;
                case "Hamberger":
                    return "버거류";
                    break;
                case "Rice":
                    return "밥류";
                    break;
                case "Snack":
                    return "과자류";
                    break;
            }
            return "";
        }

        private void SetCategoryStst()
        {
            try
            {
                query = String.Format("SELECT category, SUM(count) as count, SUM(price) as price, pay_date FROM (SELECT pay_method,pay_date,count,price,name,category FROM pay_log JOIN pay_log_detail ON pay_log.idx = pay_log_detail.pay_log_idx JOIN menus ON pay_log_detail.menu = menus.idx {0})TEMP GROUP BY category;",DayQuery());
                scom.CommandText = query;
                sdr = scom.ExecuteReader();
                this.categoryStst.BeginUpdate();
                while (sdr.Read())
                {
                    ListViewItem lvi = new ListViewItem(GetCategoryName(sdr["category"].ToString()));
                    lvi.SubItems.Add(sdr["count"].ToString());
                    lvi.SubItems.Add(sdr["price"].ToString());
                    this.categoryStst.Items.Add(lvi);
                }
                this.categoryStst.EndUpdate();
            }
            catch (Exception error)
            {
                MessageBox.Show("통계 불러오기에 실패하였습니다\n" + error.Message, "통계 불러오기 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            finally
            {
                if(sdr != null)
                {
                    sdr.Close();
                }
            }
        }

        private void SetMenuStst()
        {
            try
            {
                query = String.Format("SELECT name, SUM(count) as count, SUM(price) as price, pay_date FROM  (SELECT pay_method,pay_date,count,price,name,category FROM pay_log JOIN pay_log_detail ON pay_log.idx = pay_log_detail.pay_log_idx JOIN menus ON pay_log_detail.menu = menus.idx {0})TEMP GROUP BY name;",DayQuery());
                scom.CommandText = query;
                sdr = scom.ExecuteReader();

                this.menuStst.BeginUpdate();
                while (sdr.Read())
                {
                    ListViewItem lvi = new ListViewItem(sdr["name"].ToString());
                    lvi.SubItems.Add(sdr["count"].ToString());
                    lvi.SubItems.Add(sdr["price"].ToString());
                    totalPrice += Int32.Parse(sdr["price"].ToString());
                    this.menuStst.Items.Add(lvi);
                }
                this.menuStst.EndUpdate();
            }
            catch (Exception error)
            {
                MessageBox.Show("메뉴 불러오기에 실패하였습니다\n" + error.Message, "메뉴 불러오기 실패",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                }
            }
        }

        private void SetDate()
        {
            DateTime temp = dateTimePicker.Value;
            selectedDate = new DateTime(temp.Year, temp.Month, temp.Day);   
        }

        private void home_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
