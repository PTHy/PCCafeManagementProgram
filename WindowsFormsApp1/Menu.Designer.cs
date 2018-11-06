using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Menu
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
            this.menuName = new System.Windows.Forms.Label();
            this.menuPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuName
            // 
            this.menuName.AutoSize = true;
            this.menuName.Location = new System.Drawing.Point(3, 0);
            this.menuName.Name = "menuName";
            this.menuName.Size = new System.Drawing.Size(42, 15);
            this.menuName.TabIndex = 1;
            this.menuName.Text = "name";
            // 
            // menuPrice
            // 
            this.menuPrice.AutoSize = true;
            this.menuPrice.Location = new System.Drawing.Point(99, 125);
            this.menuPrice.Name = "menuPrice";
            this.menuPrice.Size = new System.Drawing.Size(38, 15);
            this.menuPrice.TabIndex = 2;
            this.menuPrice.Text = "price";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.menuPrice);
            this.Controls.Add(this.menuName);
            this.Name = "Menu";
            this.Size = new System.Drawing.Size(140, 140);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label menuName;
        private System.Windows.Forms.Label menuPrice;

        public Label MenuName { get => menuName; set => menuName = value; }
        public Label MenuPrice { get => menuPrice; set => menuPrice = value; }
    }
}
