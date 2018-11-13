using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Main
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
            this.tb = new System.Windows.Forms.TableLayoutPanel();
            this.time1 = new System.Windows.Forms.Label();
            this.time2 = new System.Windows.Forms.Label();
            this.statistics = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb
            // 
            this.tb.AutoSize = true;
            this.tb.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tb.Location = new System.Drawing.Point(0, 0);
            this.tb.Name = "tb";
            this.tb.Padding = new System.Windows.Forms.Padding(3);
            this.tb.Size = new System.Drawing.Size(610, 453);
            this.tb.TabIndex = 1;
            // 
            // time1
            // 
            this.time1.AutoSize = true;
            this.time1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.time1.Location = new System.Drawing.Point(647, 63);
            this.time1.Name = "time1";
            this.time1.Size = new System.Drawing.Size(152, 25);
            this.time1.TabIndex = 0;
            this.time1.Text = "0000-00-00";
            // 
            // time2
            // 
            this.time2.AutoSize = true;
            this.time2.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.time2.Location = new System.Drawing.Point(647, 100);
            this.time2.Name = "time2";
            this.time2.Size = new System.Drawing.Size(114, 25);
            this.time2.TabIndex = 2;
            this.time2.Text = "00:00:00";
            // 
            // statistics
            // 
            this.statistics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.statistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.statistics.Location = new System.Drawing.Point(652, 199);
            this.statistics.Name = "statistics";
            this.statistics.Size = new System.Drawing.Size(124, 77);
            this.statistics.TabIndex = 3;
            this.statistics.Text = "통계";
            this.statistics.UseVisualStyleBackColor = true;
            this.statistics.Click += new System.EventHandler(this.statisticsClick);
            // 
            // exit
            // 
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Location = new System.Drawing.Point(652, 320);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(124, 77);
            this.exit.TabIndex = 4;
            this.exit.Text = "종료";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exitClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.statistics);
            this.Controls.Add(this.time2);
            this.Controls.Add(this.time1);
            this.Controls.Add(this.tb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainClosing);
            this.Load += new System.EventHandler(this.MainLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label time1;
        private System.Windows.Forms.TableLayoutPanel tb;
        private Label time2;
        private Button statistics;
        private Button exit;
    }
}