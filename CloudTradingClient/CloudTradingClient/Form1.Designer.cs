namespace CloudTradingClient
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.tb_cpu = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_stor = new System.Windows.Forms.TextBox();
            this.tb_mem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.memBox = new System.Windows.Forms.TextBox();
            this.stor = new System.Windows.Forms.TextBox();
            this.tbMSG = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.clid = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.top_up_tb = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(248, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect to Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_cpu
            // 
            this.tb_cpu.Enabled = false;
            this.tb_cpu.Location = new System.Drawing.Point(82, 55);
            this.tb_cpu.Name = "tb_cpu";
            this.tb_cpu.Size = new System.Drawing.Size(100, 26);
            this.tb_cpu.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(242, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 60);
            this.button2.TabIndex = 3;
            this.button2.Text = "Get CPU and Memory";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Send);
            // 
            // tb_stor
            // 
            this.tb_stor.Enabled = false;
            this.tb_stor.Location = new System.Drawing.Point(82, 133);
            this.tb_stor.Name = "tb_stor";
            this.tb_stor.Size = new System.Drawing.Size(100, 26);
            this.tb_stor.TabIndex = 4;
            // 
            // tb_mem
            // 
            this.tb_mem.Enabled = false;
            this.tb_mem.Location = new System.Drawing.Point(82, 94);
            this.tb_mem.Name = "tb_mem";
            this.tb_mem.Size = new System.Drawing.Size(100, 26);
            this.tb_mem.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "CPU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Memory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Storage";
            // 
            // memBox
            // 
            this.memBox.Location = new System.Drawing.Point(82, 83);
            this.memBox.Name = "memBox";
            this.memBox.Size = new System.Drawing.Size(100, 26);
            this.memBox.TabIndex = 11;
            // 
            // stor
            // 
            this.stor.Location = new System.Drawing.Point(82, 120);
            this.stor.Name = "stor";
            this.stor.Size = new System.Drawing.Size(100, 26);
            this.stor.TabIndex = 10;
            // 
            // tbMSG
            // 
            this.tbMSG.Location = new System.Drawing.Point(82, 43);
            this.tbMSG.Name = "tbMSG";
            this.tbMSG.Size = new System.Drawing.Size(100, 26);
            this.tbMSG.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(242, 106);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 37);
            this.button4.TabIndex = 13;
            this.button4.Text = "Get Storage";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SendStorage);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(248, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 30);
            this.button3.TabIndex = 15;
            this.button3.Text = "Set Client ID";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.top_up_tb);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbMSG);
            this.groupBox1.Controls.Add(this.stor);
            this.groupBox1.Controls.Add(this.memBox);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 189);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 187);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Request";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clid);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.tb_cpu);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.tb_stor);
            this.groupBox2.Controls.Add(this.tb_mem);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 171);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Client Details";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Storage";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "CPU";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Memory";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Client ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(185, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "GB";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(188, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "MIPS";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(185, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "MB";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(185, 124);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "GB";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(188, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "MIPS";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(185, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "MB";
            // 
            // clid
            // 
            this.clid.FormattingEnabled = true;
            this.clid.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.clid.Location = new System.Drawing.Point(82, 23);
            this.clid.Name = "clid";
            this.clid.Size = new System.Drawing.Size(100, 28);
            this.clid.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(185, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 20);
            this.label14.TabIndex = 25;
            this.label14.Text = "Units";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(10, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 20);
            this.label15.TabIndex = 24;
            this.label15.Text = "Credits";
            // 
            // top_up_tb
            // 
            this.top_up_tb.Location = new System.Drawing.Point(82, 155);
            this.top_up_tb.Name = "top_up_tb";
            this.top_up_tb.Size = new System.Drawing.Size(100, 26);
            this.top_up_tb.TabIndex = 23;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(242, 144);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(111, 37);
            this.button5.TabIndex = 26;
            this.button5.Text = "Top Up";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(436, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_cpu;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tb_stor;
        private System.Windows.Forms.TextBox tb_mem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox memBox;
        private System.Windows.Forms.TextBox stor;
        private System.Windows.Forms.TextBox tbMSG;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox clid;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox top_up_tb;
    }
}

