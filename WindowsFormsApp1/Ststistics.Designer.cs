namespace WindowsFormsApp1
{
    partial class Ststistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.home = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.menuStst = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.categoryStst = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.payMethodStst = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // home
            // 
            this.home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home.Location = new System.Drawing.Point(723, 21);
            this.home.Name = "home";
            this.home.Size = new System.Drawing.Size(96, 39);
            this.home.TabIndex = 1;
            this.home.Text = "뒤로가기";
            this.home.UseVisualStyleBackColor = true;
            this.home.Click += new System.EventHandler(this.home_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.CustomFormat = "";
            this.dateTimePicker.Location = new System.Drawing.Point(489, 26);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker.TabIndex = 3;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.DateTimePickerChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F);
            this.label1.Location = new System.Drawing.Point(42, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "총합 : ";
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Font = new System.Drawing.Font("굴림", 15F);
            this.lbTotalPrice.Location = new System.Drawing.Point(123, 26);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(25, 25);
            this.lbTotalPrice.TabIndex = 5;
            this.lbTotalPrice.Text = "0";
            // 
            // menuStst
            // 
            this.menuStst.GridLines = true;
            this.menuStst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.menuStst.LabelWrap = false;
            this.menuStst.Location = new System.Drawing.Point(47, 117);
            this.menuStst.Name = "menuStst";
            this.menuStst.Size = new System.Drawing.Size(357, 338);
            this.menuStst.TabIndex = 6;
            this.menuStst.UseCompatibleStateImageBehavior = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(43, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "메뉴 별 매출";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(447, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "카테고리 별 매출";
            // 
            // categoryStst
            // 
            this.categoryStst.GridLines = true;
            this.categoryStst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.categoryStst.LabelWrap = false;
            this.categoryStst.Location = new System.Drawing.Point(451, 117);
            this.categoryStst.Name = "categoryStst";
            this.categoryStst.Size = new System.Drawing.Size(368, 186);
            this.categoryStst.TabIndex = 9;
            this.categoryStst.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(449, 317);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "결제 방법 별 매출";
            // 
            // payMethodStst
            // 
            this.payMethodStst.GridLines = true;
            this.payMethodStst.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.payMethodStst.LabelWrap = false;
            this.payMethodStst.Location = new System.Drawing.Point(453, 352);
            this.payMethodStst.Name = "payMethodStst";
            this.payMethodStst.Size = new System.Drawing.Size(366, 103);
            this.payMethodStst.TabIndex = 11;
            this.payMethodStst.UseCompatibleStateImageBehavior = false;
            // 
            // Ststistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 485);
            this.Controls.Add(this.payMethodStst);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.categoryStst);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStst);
            this.Controls.Add(this.lbTotalPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.home);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Ststistics";
            this.Text = "Ststistics";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button home;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.ListView menuStst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView categoryStst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView payMethodStst;
    }
}