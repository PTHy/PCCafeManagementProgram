using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Seats
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Seats));
            this.process1 = new System.Diagnostics.Process();
            this.Rice = new System.Windows.Forms.Button();
            this.Ramen = new System.Windows.Forms.Button();
            this.Snack = new System.Windows.Forms.Button();
            this.Drink = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.totalPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.payPrice = new System.Windows.Forms.ComboBox();
            this.cash = new System.Windows.Forms.RadioButton();
            this.card = new System.Windows.Forms.RadioButton();
            this.foodImage = new System.Windows.Forms.PictureBox();
            this.seatNumText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMenus = new System.Windows.Forms.TableLayoutPanel();
            this.orderList = new System.Windows.Forms.ListView();
            this.order_time = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.home = new System.Windows.Forms.Button();
            this.pay = new System.Windows.Forms.Button();
            this.orderTime = new System.Windows.Forms.Label();
            this.All = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.foodImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // Rice
            // 
            this.Rice.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Rice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Rice.Location = new System.Drawing.Point(61, 46);
            this.Rice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rice.Name = "Rice";
            this.Rice.Size = new System.Drawing.Size(55, 34);
            this.Rice.TabIndex = 0;
            this.Rice.Text = "밥류";
            this.Rice.UseVisualStyleBackColor = false;
            this.Rice.Click += new System.EventHandler(this.CategoryClick);
            // 
            // Ramen
            // 
            this.Ramen.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Ramen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ramen.Location = new System.Drawing.Point(117, 46);
            this.Ramen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ramen.Name = "Ramen";
            this.Ramen.Size = new System.Drawing.Size(57, 34);
            this.Ramen.TabIndex = 1;
            this.Ramen.Text = "라면류";
            this.Ramen.UseVisualStyleBackColor = false;
            this.Ramen.Click += new System.EventHandler(this.CategoryClick);
            // 
            // Snack
            // 
            this.Snack.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Snack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Snack.Location = new System.Drawing.Point(175, 46);
            this.Snack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Snack.Name = "Snack";
            this.Snack.Size = new System.Drawing.Size(57, 34);
            this.Snack.TabIndex = 2;
            this.Snack.Text = "과자류";
            this.Snack.UseVisualStyleBackColor = false;
            this.Snack.Click += new System.EventHandler(this.CategoryClick);
            // 
            // Drink
            // 
            this.Drink.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Drink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Drink.Location = new System.Drawing.Point(233, 46);
            this.Drink.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Drink.Name = "Drink";
            this.Drink.Size = new System.Drawing.Size(57, 34);
            this.Drink.TabIndex = 3;
            this.Drink.Text = "음료류";
            this.Drink.UseVisualStyleBackColor = false;
            this.Drink.Click += new System.EventHandler(this.CategoryClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(302, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "전체금액 :";
            // 
            // totalPrice
            // 
            this.totalPrice.AutoSize = true;
            this.totalPrice.Location = new System.Drawing.Point(399, 178);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(11, 12);
            this.totalPrice.TabIndex = 7;
            this.totalPrice.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "지불금액 :";
            // 
            // payPrice
            // 
            this.payPrice.FormattingEnabled = true;
            this.payPrice.Items.AddRange(new object[] {
            "1000",
            "5000",
            "10000",
            "50000",
            "금액에 맞게"});
            this.payPrice.Location = new System.Drawing.Point(368, 208);
            this.payPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.payPrice.Name = "payPrice";
            this.payPrice.Size = new System.Drawing.Size(87, 20);
            this.payPrice.TabIndex = 9;
            // 
            // cash
            // 
            this.cash.AutoSize = true;
            this.cash.Location = new System.Drawing.Point(312, 304);
            this.cash.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cash.Name = "cash";
            this.cash.Size = new System.Drawing.Size(47, 16);
            this.cash.TabIndex = 10;
            this.cash.TabStop = true;
            this.cash.Text = "현금";
            this.cash.UseVisualStyleBackColor = true;
            // 
            // card
            // 
            this.card.AutoSize = true;
            this.card.Location = new System.Drawing.Point(312, 324);
            this.card.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.card.Name = "card";
            this.card.Size = new System.Drawing.Size(47, 16);
            this.card.TabIndex = 11;
            this.card.TabStop = true;
            this.card.Text = "카드";
            this.card.UseVisualStyleBackColor = true;
            // 
            // foodImage
            // 
            this.foodImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("foodImage.BackgroundImage")));
            this.foodImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.foodImage.Location = new System.Drawing.Point(459, 200);
            this.foodImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.foodImage.Name = "foodImage";
            this.foodImage.Size = new System.Drawing.Size(169, 148);
            this.foodImage.TabIndex = 13;
            this.foodImage.TabStop = false;
            // 
            // seatNumText
            // 
            this.seatNumText.AutoSize = true;
            this.seatNumText.Location = new System.Drawing.Point(18, 23);
            this.seatNumText.Name = "seatNumText";
            this.seatNumText.Size = new System.Drawing.Size(11, 12);
            this.seatNumText.TabIndex = 14;
            this.seatNumText.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "번 테이블";
            // 
            // tbMenus
            // 
            this.tbMenus.AutoScroll = true;
            this.tbMenus.AutoSize = true;
            this.tbMenus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbMenus.Location = new System.Drawing.Point(0, 0);
            this.tbMenus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMenus.Name = "tbMenus";
            this.tbMenus.Size = new System.Drawing.Size(262, 262);
            this.tbMenus.TabIndex = 0;
            // 
            // orderList
            // 
            this.orderList.FullRowSelect = true;
            this.orderList.GridLines = true;
            this.orderList.Location = new System.Drawing.Point(301, 46);
            this.orderList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.orderList.Name = "orderList";
            this.orderList.Size = new System.Drawing.Size(326, 123);
            this.orderList.TabIndex = 17;
            this.orderList.UseCompatibleStateImageBehavior = false;
            this.orderList.View = System.Windows.Forms.View.Details;
            this.orderList.SelectedIndexChanged += new System.EventHandler(this.OrderListSelectedIndexChanged);
            // 
            // order_time
            // 
            this.order_time.AutoSize = true;
            this.order_time.Location = new System.Drawing.Point(318, 19);
            this.order_time.Name = "order_time";
            this.order_time.Size = new System.Drawing.Size(65, 12);
            this.order_time.TabIndex = 18;
            this.order_time.Text = "주문 시간 :";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(382, 239);
            this.submit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(73, 52);
            this.submit.TabIndex = 19;
            this.submit.Text = "주문";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.SubmitClick);
            // 
            // reset
            // 
            this.reset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reset.Location = new System.Drawing.Point(301, 239);
            this.reset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(75, 52);
            this.reset.TabIndex = 20;
            this.reset.Text = "리셋";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.ResetClick);
            // 
            // home
            // 
            this.home.Location = new System.Drawing.Point(569, 10);
            this.home.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(58, 31);
            this.home.TabIndex = 21;
            this.home.Text = "Home";
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.HomeClick);
            // 
            // pay
            // 
            this.pay.Location = new System.Drawing.Point(381, 296);
            this.pay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pay.Name = "pay";
            this.pay.Size = new System.Drawing.Size(72, 51);
            this.pay.TabIndex = 22;
            this.pay.Text = "결제";
            this.pay.UseVisualStyleBackColor = true;
            this.pay.Click += new System.EventHandler(this.PayClick);
            // 
            // orderTime
            // 
            this.orderTime.AutoSize = true;
            this.orderTime.Location = new System.Drawing.Point(399, 19);
            this.orderTime.Name = "orderTime";
            this.orderTime.Size = new System.Drawing.Size(113, 12);
            this.orderTime.TabIndex = 23;
            this.orderTime.Text = "0000-00-00 00:00:00";
            // 
            // All
            // 
            this.All.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.All.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.All.Location = new System.Drawing.Point(4, 46);
            this.All.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.All.Name = "All";
            this.All.Size = new System.Drawing.Size(57, 34);
            this.All.TabIndex = 4;
            this.All.Text = "전체";
            this.All.UseVisualStyleBackColor = false;
            this.All.Click += new System.EventHandler(this.CategoryClick);
            // 
            // plus
            // 
            this.plus.Enabled = false;
            this.plus.Location = new System.Drawing.Point(458, 171);
            this.plus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(78, 26);
            this.plus.TabIndex = 24;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.OperatorClick);
            // 
            // minus
            // 
            this.minus.Enabled = false;
            this.minus.Location = new System.Drawing.Point(549, 171);
            this.minus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(78, 26);
            this.minus.TabIndex = 25;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.OperatorClick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tbMenus);
            this.panel1.Location = new System.Drawing.Point(4, 86);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 265);
            this.panel1.TabIndex = 26;
            // 
            // Seats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 360);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.orderTime);
            this.Controls.Add(this.pay);
            this.Controls.Add(this.home);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.order_time);
            this.Controls.Add(this.orderList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.seatNumText);
            this.Controls.Add(this.foodImage);
            this.Controls.Add(this.card);
            this.Controls.Add(this.cash);
            this.Controls.Add(this.payPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.All);
            this.Controls.Add(this.Drink);
            this.Controls.Add(this.Snack);
            this.Controls.Add(this.Ramen);
            this.Controls.Add(this.Rice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Seats";
            this.Text = "PC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeatsClosing);
            this.Load += new System.EventHandler(this.SeatsLoad);
            ((System.ComponentModel.ISupportInitialize)(this.foodImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Diagnostics.Process process1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Drink;
        private System.Windows.Forms.Button Snack;
        private System.Windows.Forms.Button Ramen;
        private System.Windows.Forms.Button Rice;
        private System.Windows.Forms.Label totalPrice;
        private System.Windows.Forms.ComboBox payPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton cash;
        private System.Windows.Forms.RadioButton card;
        private System.Windows.Forms.PictureBox foodImage;
        private System.Windows.Forms.Label seatNumText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tbMenus;
        private System.Windows.Forms.ListView orderList;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label order_time;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button home;
        private System.Windows.Forms.Button pay;
        private System.Windows.Forms.Label orderTime;
        private System.Windows.Forms.Button All;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Panel panel1;
    }
}

