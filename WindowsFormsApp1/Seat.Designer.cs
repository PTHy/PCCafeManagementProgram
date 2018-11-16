using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Seat
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.seatNumText = new System.Windows.Forms.Label();
            this.orderText = new System.Windows.Forms.Label();
            this.payPriceText = new System.Windows.Forms.Label();
            this.totalPriceText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // seatNumText
            // 
            this.seatNumText.AutoSize = true;
            this.seatNumText.Location = new System.Drawing.Point(0, 0);
            this.seatNumText.Name = "seatNumText";
            this.seatNumText.Size = new System.Drawing.Size(77, 12);
            this.seatNumText.TabIndex = 0;
            this.seatNumText.Text = "tableNumber";
            // 
            // orderText
            // 
            this.orderText.AutoSize = true;
            this.orderText.Font = new System.Drawing.Font("굴림", 8F);
            this.orderText.Location = new System.Drawing.Point(13, 21);
            this.orderText.Name = "orderText";
            this.orderText.Size = new System.Drawing.Size(0, 11);
            this.orderText.TabIndex = 0;
            // 
            // payPriceText
            // 
            this.payPriceText.AutoSize = true;
            this.payPriceText.Location = new System.Drawing.Point(13, 80);
            this.payPriceText.Name = "payPriceText";
            this.payPriceText.Size = new System.Drawing.Size(0, 12);
            this.payPriceText.TabIndex = 1;
            // 
            // totalPriceText
            // 
            this.totalPriceText.AutoSize = true;
            this.totalPriceText.Location = new System.Drawing.Point(13, 92);
            this.totalPriceText.Name = "totalPriceText";
            this.totalPriceText.Size = new System.Drawing.Size(0, 12);
            this.totalPriceText.TabIndex = 2;
            // 
            // Seat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.totalPriceText);
            this.Controls.Add(this.payPriceText);
            this.Controls.Add(this.orderText);
            this.Controls.Add(this.seatNumText);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Seat";
            this.Size = new System.Drawing.Size(175, 111);
            this.Load += new System.EventHandler(this.Seat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label seatNumText;
        private Label orderText;
        private Label payPriceText;
        private Label totalPriceText;

        public Label TableNumber { get => seatNumText; set => seatNumText = value; }
    }
}
