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
            this.SuspendLayout();
            // 
            // tb
            // 
            this.tb.AutoSize = true;
            this.tb.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tb.Location = new System.Drawing.Point(0, 0);
            this.tb.Name = "tb";
            this.tb.Padding = new System.Windows.Forms.Padding(3);
            this.tb.Size = new System.Drawing.Size(604, 453);
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
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.time2);
            this.Controls.Add(this.time1);
            this.Controls.Add(this.tb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
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
    }
}