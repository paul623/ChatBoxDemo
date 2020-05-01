namespace Experiment1_TcpChatClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.lable_name = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.textbox_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textbox_chatbox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textbox_sendbox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_receive = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pic_show = new System.Windows.Forms.PictureBox();
            this.button_pic_send = new System.Windows.Forms.Button();
            this.button_pic_select = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_show)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.lable_name);
            this.groupBox1.Controls.Add(this.button_connect);
            this.groupBox1.Controls.Add(this.textbox_ip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "配置";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(81, 54);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(193, 25);
            this.textBox_name.TabIndex = 4;
            // 
            // lable_name
            // 
            this.lable_name.AutoSize = true;
            this.lable_name.Location = new System.Drawing.Point(7, 55);
            this.lable_name.Name = "lable_name";
            this.lable_name.Size = new System.Drawing.Size(52, 15);
            this.lable_name.TabIndex = 3;
            this.lable_name.Text = "用户名";
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(280, 27);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(165, 43);
            this.button_connect.TabIndex = 2;
            this.button_connect.Text = "开始连接";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // textbox_ip
            // 
            this.textbox_ip.Location = new System.Drawing.Point(81, 22);
            this.textbox_ip.Name = "textbox_ip";
            this.textbox_ip.Size = new System.Drawing.Size(193, 25);
            this.textbox_ip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textbox_chatbox);
            this.groupBox2.Location = new System.Drawing.Point(13, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 196);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "聊天框";
            // 
            // textbox_chatbox
            // 
            this.textbox_chatbox.Location = new System.Drawing.Point(10, 25);
            this.textbox_chatbox.Multiline = true;
            this.textbox_chatbox.Name = "textbox_chatbox";
            this.textbox_chatbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textbox_chatbox.Size = new System.Drawing.Size(435, 165);
            this.textbox_chatbox.TabIndex = 0;
            this.textbox_chatbox.TextChanged += new System.EventHandler(this.textbox_chatbox_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textbox_sendbox);
            this.groupBox3.Location = new System.Drawing.Point(12, 336);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 138);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送消息";
            // 
            // textbox_sendbox
            // 
            this.textbox_sendbox.Location = new System.Drawing.Point(10, 25);
            this.textbox_sendbox.Multiline = true;
            this.textbox_sendbox.Name = "textbox_sendbox";
            this.textbox_sendbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textbox_sendbox.Size = new System.Drawing.Size(196, 107);
            this.textbox_sendbox.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_stop);
            this.groupBox4.Controls.Add(this.button_receive);
            this.groupBox4.Controls.Add(this.button_send);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Location = new System.Drawing.Point(237, 308);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(240, 166);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "按钮";
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(11, 53);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(215, 32);
            this.button_stop.TabIndex = 4;
            this.button_stop.Text = "终止连接";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_receive
            // 
            this.button_receive.Location = new System.Drawing.Point(11, 91);
            this.button_receive.Name = "button_receive";
            this.button_receive.Size = new System.Drawing.Size(215, 32);
            this.button_receive.TabIndex = 3;
            this.button_receive.Text = "接收";
            this.button_receive.UseVisualStyleBackColor = true;
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(11, 129);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(215, 31);
            this.button_send.TabIndex = 2;
            this.button_send.Text = "发送";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button_send_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "目标用户";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(81, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_pic_select);
            this.groupBox5.Controls.Add(this.button_pic_send);
            this.groupBox5.Controls.Add(this.pic_show);
            this.groupBox5.Location = new System.Drawing.Point(483, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(335, 448);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "图片接收发送区域";
            // 
            // pic_show
            // 
            this.pic_show.Location = new System.Drawing.Point(7, 25);
            this.pic_show.Name = "pic_show";
            this.pic_show.Size = new System.Drawing.Size(322, 353);
            this.pic_show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_show.TabIndex = 0;
            this.pic_show.TabStop = false;
            // 
            // button_pic_send
            // 
            this.button_pic_send.Location = new System.Drawing.Point(227, 405);
            this.button_pic_send.Name = "button_pic_send";
            this.button_pic_send.Size = new System.Drawing.Size(102, 37);
            this.button_pic_send.TabIndex = 1;
            this.button_pic_send.Text = "发送";
            this.button_pic_send.UseVisualStyleBackColor = true;
            this.button_pic_send.Click += new System.EventHandler(this.button_pic_send_Click);
            // 
            // button_pic_select
            // 
            this.button_pic_select.Location = new System.Drawing.Point(7, 405);
            this.button_pic_select.Name = "button_pic_select";
            this.button_pic_select.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_pic_select.Size = new System.Drawing.Size(102, 37);
            this.button_pic_select.TabIndex = 2;
            this.button_pic_select.Text = "选择照片";
            this.button_pic_select.UseVisualStyleBackColor = true;
            this.button_pic_select.Click += new System.EventHandler(this.button_pic_select_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 482);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "聊天室客户端";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_show)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textbox_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textbox_chatbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textbox_sendbox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_receive;
        private System.Windows.Forms.Button button_send;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label lable_name;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_pic_send;
        private System.Windows.Forms.PictureBox pic_show;
        private System.Windows.Forms.Button button_pic_select;
    }
}

