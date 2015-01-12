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
            this.t_ID = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(183, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 80);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect to Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_cpu
            // 
            this.tb_cpu.Location = new System.Drawing.Point(64, 53);
            this.tb_cpu.Name = "tb_cpu";
            this.tb_cpu.Size = new System.Drawing.Size(100, 20);
            this.tb_cpu.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(140, 151);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 60);
            this.button2.TabIndex = 3;
            this.button2.Text = "Get CPU and Memory";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Send);
            // 
            // tb_stor
            // 
            this.tb_stor.Location = new System.Drawing.Point(64, 108);
            this.tb_stor.Name = "tb_stor";
            this.tb_stor.Size = new System.Drawing.Size(100, 20);
            this.tb_stor.TabIndex = 4;
            // 
            // tb_mem
            // 
            this.tb_mem.Location = new System.Drawing.Point(64, 79);
            this.tb_mem.Name = "tb_mem";
            this.tb_mem.Size = new System.Drawing.Size(100, 20);
            this.tb_mem.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "CPU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Memory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Storage";
            // 
            // memBox
            // 
            this.memBox.Location = new System.Drawing.Point(12, 177);
            this.memBox.Name = "memBox";
            this.memBox.Size = new System.Drawing.Size(100, 20);
            this.memBox.TabIndex = 11;
            // 
            // stor
            // 
            this.stor.Location = new System.Drawing.Point(12, 229);
            this.stor.Name = "stor";
            this.stor.Size = new System.Drawing.Size(100, 20);
            this.stor.TabIndex = 10;
            // 
            // tbMSG
            // 
            this.tbMSG.Location = new System.Drawing.Point(12, 151);
            this.tbMSG.Name = "tbMSG";
            this.tbMSG.Size = new System.Drawing.Size(100, 20);
            this.tbMSG.TabIndex = 9;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(140, 226);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "Get Storage";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.SendStorage);
            // 
            // t_ID
            // 
            this.t_ID.Location = new System.Drawing.Point(25, 12);
            this.t_ID.Name = "t_ID";
            this.t_ID.Size = new System.Drawing.Size(100, 20);
            this.t_ID.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(140, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Set Client ID";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.t_ID);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.memBox);
            this.Controls.Add(this.stor);
            this.Controls.Add(this.tbMSG);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_mem);
            this.Controls.Add(this.tb_stor);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tb_cpu);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "CLIENT";
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox t_ID;
        private System.Windows.Forms.Button button3;
    }
}

