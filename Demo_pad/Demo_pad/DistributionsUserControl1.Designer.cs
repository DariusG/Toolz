namespace Demo_pad
{
    partial class DistributionsUserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbstdeviation = new System.Windows.Forms.TextBox();
            this.tbmeanWaitime = new System.Windows.Forms.TextBox();
            this.cbTimeUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbProbability = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.lbMax = new System.Windows.Forms.Label();
            this.lbAlpha = new System.Windows.Forms.Label();
            this.lbBeta = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbstdeviation
            // 
            this.tbstdeviation.Location = new System.Drawing.Point(65, 53);
            this.tbstdeviation.Name = "tbstdeviation";
            this.tbstdeviation.Size = new System.Drawing.Size(146, 20);
            this.tbstdeviation.TabIndex = 16;
            this.tbstdeviation.Visible = false;
            // 
            // tbmeanWaitime
            // 
            this.tbmeanWaitime.Location = new System.Drawing.Point(65, 28);
            this.tbmeanWaitime.Name = "tbmeanWaitime";
            this.tbmeanWaitime.Size = new System.Drawing.Size(146, 20);
            this.tbmeanWaitime.TabIndex = 15;
            this.tbmeanWaitime.Visible = false;
            // 
            // cbTimeUnit
            // 
            this.cbTimeUnit.FormattingEnabled = true;
            this.cbTimeUnit.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours",
            "Days"});
            this.cbTimeUnit.Location = new System.Drawing.Point(65, 203);
            this.cbTimeUnit.Name = "cbTimeUnit";
            this.cbTimeUnit.Size = new System.Drawing.Size(146, 21);
            this.cbTimeUnit.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Unit:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Std. Dev.:";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mean:";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Value:";
            this.label1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 18;
            this.textBox1.Visible = false;
            // 
            // lbProbability
            // 
            this.lbProbability.AutoSize = true;
            this.lbProbability.Location = new System.Drawing.Point(0, 81);
            this.lbProbability.Name = "lbProbability";
            this.lbProbability.Size = new System.Drawing.Size(58, 13);
            this.lbProbability.TabIndex = 19;
            this.lbProbability.Text = "Probability:";
            this.lbProbability.Visible = false;
            // 
            // lbMin
            // 
            this.lbMin.AutoSize = true;
            this.lbMin.Location = new System.Drawing.Point(31, 106);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(27, 13);
            this.lbMin.TabIndex = 20;
            this.lbMin.Text = "Min:";
            this.lbMin.Visible = false;
            // 
            // lbMax
            // 
            this.lbMax.AutoSize = true;
            this.lbMax.Location = new System.Drawing.Point(28, 131);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(30, 13);
            this.lbMax.TabIndex = 21;
            this.lbMax.Text = "Max:";
            this.lbMax.Visible = false;
            // 
            // lbAlpha
            // 
            this.lbAlpha.AutoSize = true;
            this.lbAlpha.Location = new System.Drawing.Point(21, 156);
            this.lbAlpha.Name = "lbAlpha";
            this.lbAlpha.Size = new System.Drawing.Size(37, 13);
            this.lbAlpha.TabIndex = 22;
            this.lbAlpha.Text = "Alpha:";
            this.lbAlpha.Visible = false;
            // 
            // lbBeta
            // 
            this.lbBeta.AutoSize = true;
            this.lbBeta.Location = new System.Drawing.Point(26, 181);
            this.lbBeta.Name = "lbBeta";
            this.lbBeta.Size = new System.Drawing.Size(32, 13);
            this.lbBeta.TabIndex = 23;
            this.lbBeta.Text = "Beta:";
            this.lbBeta.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(66, 78);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 20);
            this.textBox2.TabIndex = 24;
            this.textBox2.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(66, 103);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(146, 20);
            this.textBox3.TabIndex = 25;
            this.textBox3.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(66, 128);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(146, 20);
            this.textBox4.TabIndex = 26;
            this.textBox4.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(65, 153);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(146, 20);
            this.textBox5.TabIndex = 27;
            this.textBox5.Visible = false;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(66, 178);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(146, 20);
            this.textBox6.TabIndex = 28;
            this.textBox6.Visible = false;
            // 
            // DistributionsUserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbBeta);
            this.Controls.Add(this.lbAlpha);
            this.Controls.Add(this.lbMax);
            this.Controls.Add(this.lbMin);
            this.Controls.Add(this.lbProbability);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbstdeviation);
            this.Controls.Add(this.tbmeanWaitime);
            this.Controls.Add(this.cbTimeUnit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "DistributionsUserControl1";
            this.Size = new System.Drawing.Size(221, 232);
            this.Load += new System.EventHandler(this.DistributionsUserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTimeUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbstdeviation;
        private System.Windows.Forms.TextBox tbmeanWaitime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbProbability;
        private System.Windows.Forms.Label lbMin;
        private System.Windows.Forms.Label lbMax;
        private System.Windows.Forms.Label lbAlpha;
        private System.Windows.Forms.Label lbBeta;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;


    }
}
