namespace DTHP_320
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

            if (!IsHandleCreated)
            {
                this.Close();
                base.Dispose(disposing);
            }
            ComDevice.Close();
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Status = new System.Windows.Forms.PictureBox();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.comboBox_Port = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Switch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton_ASCII = new System.Windows.Forms.RadioButton();
            this.radioButton_Hex = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_Receive = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button_Send = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Status)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox_Status);
            this.groupBox1.Controls.Add(this.comboBox_BaudRate);
            this.groupBox1.Controls.Add(this.comboBox_Port);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_Switch);
            this.groupBox1.Location = new System.Drawing.Point(6, 383);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "转台端口";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "刷新串口";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "端口";
            // 
            // pictureBox_Status
            // 
            this.pictureBox_Status.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_Status.Location = new System.Drawing.Point(99, 106);
            this.pictureBox_Status.Name = "pictureBox_Status";
            this.pictureBox_Status.Size = new System.Drawing.Size(26, 23);
            this.pictureBox_Status.TabIndex = 11;
            this.pictureBox_Status.TabStop = false;
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "43000",
            "56000",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600"});
            this.comboBox_BaudRate.Location = new System.Drawing.Point(70, 63);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(121, 20);
            this.comboBox_BaudRate.TabIndex = 1;
            // 
            // comboBox_Port
            // 
            this.comboBox_Port.FormattingEnabled = true;
            this.comboBox_Port.Location = new System.Drawing.Point(70, 27);
            this.comboBox_Port.Name = "comboBox_Port";
            this.comboBox_Port.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Port.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "波特率";
            // 
            // button_Switch
            // 
            this.button_Switch.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button_Switch.Location = new System.Drawing.Point(4, 106);
            this.button_Switch.Name = "button_Switch";
            this.button_Switch.Size = new System.Drawing.Size(89, 23);
            this.button_Switch.TabIndex = 10;
            this.button_Switch.Text = "开启";
            this.button_Switch.UseVisualStyleBackColor = true;
            this.button_Switch.Click += new System.EventHandler(this.button_Switch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton_ASCII);
            this.groupBox2.Controls.Add(this.radioButton_Hex);
            this.groupBox2.Location = new System.Drawing.Point(263, 486);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(266, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "编码方式";
            this.groupBox2.UseWaitCursor = true;
            // 
            // radioButton_ASCII
            // 
            this.radioButton_ASCII.AutoSize = true;
            this.radioButton_ASCII.Location = new System.Drawing.Point(185, 21);
            this.radioButton_ASCII.Name = "radioButton_ASCII";
            this.radioButton_ASCII.Size = new System.Drawing.Size(53, 16);
            this.radioButton_ASCII.TabIndex = 1;
            this.radioButton_ASCII.Text = "ASCII";
            this.radioButton_ASCII.UseVisualStyleBackColor = true;
            this.radioButton_ASCII.UseWaitCursor = true;
            // 
            // radioButton_Hex
            // 
            this.radioButton_Hex.AutoSize = true;
            this.radioButton_Hex.Checked = true;
            this.radioButton_Hex.Location = new System.Drawing.Point(21, 21);
            this.radioButton_Hex.Name = "radioButton_Hex";
            this.radioButton_Hex.Size = new System.Drawing.Size(59, 16);
            this.radioButton_Hex.TabIndex = 0;
            this.radioButton_Hex.TabStop = true;
            this.radioButton_Hex.Text = "16进制";
            this.radioButton_Hex.UseVisualStyleBackColor = true;
            this.radioButton_Hex.UseWaitCursor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_Receive);
            this.groupBox3.Location = new System.Drawing.Point(18, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(568, 302);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收端";
            this.groupBox3.UseWaitCursor = true;
            // 
            // textBox_Receive
            // 
            this.textBox_Receive.Location = new System.Drawing.Point(6, 28);
            this.textBox_Receive.Multiline = true;
            this.textBox_Receive.Name = "textBox_Receive";
            this.textBox_Receive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox_Receive.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Receive.Size = new System.Drawing.Size(559, 268);
            this.textBox_Receive.TabIndex = 0;
            this.textBox_Receive.UseWaitCursor = true;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button9.Location = new System.Drawing.Point(6, 180);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(155, 32);
            this.button9.TabIndex = 17;
            this.button9.Text = "检测运动";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_check_gyr);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.Location = new System.Drawing.Point(726, 459);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 34);
            this.button7.TabIndex = 16;
            this.button7.Text = "启动";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(87, 129);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 34);
            this.button6.TabIndex = 15;
            this.button6.Text = "回位";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(6, 216);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 36);
            this.button3.TabIndex = 15;
            this.button3.Text = "退出";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(86, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 15;
            this.button2.Text = "暂停";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button_Send
            // 
            this.button_Send.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Send.Location = new System.Drawing.Point(6, 83);
            this.button_Send.Name = "button_Send";
            this.button_Send.Size = new System.Drawing.Size(75, 34);
            this.button_Send.TabIndex = 4;
            this.button_Send.Text = "开始";
            this.button_Send.UseVisualStyleBackColor = true;
            this.button_Send.Click += new System.EventHandler(this.button_start_calib);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox2);
            this.groupBox5.Location = new System.Drawing.Point(263, 536);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(627, 110);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送端";
            this.groupBox5.UseWaitCursor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(16, 20);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(605, 84);
            this.textBox2.TabIndex = 0;
            this.textBox2.UseWaitCursor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.checkBox1);
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.checkBox2);
            this.groupBox6.Enabled = false;
            this.groupBox6.Location = new System.Drawing.Point(242, 385);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(146, 143);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "使能指令";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(38, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 24);
            this.label10.TabIndex = 5;
            this.label10.Text = "Y轴使能";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(17, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(38, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 24);
            this.label9.TabIndex = 4;
            this.label9.Text = "X轴使能";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(17, 83);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button4);
            this.groupBox7.Controls.Add(this.pictureBox1);
            this.groupBox7.Controls.Add(this.button5);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.comboBox1);
            this.groupBox7.Controls.Add(this.comboBox2);
            this.groupBox7.Location = new System.Drawing.Point(18, 493);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(224, 145);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "传感器串口";
            this.groupBox7.UseWaitCursor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(133, 104);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "刷新串口";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.UseWaitCursor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(101, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 23);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 104);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(89, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "开启";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "波特率";
            this.label3.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "端口";
            this.label4.UseWaitCursor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.UseWaitCursor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Location = new System.Drawing.Point(0, 0);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 14;
            this.comboBox2.UseWaitCursor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox6);
            this.groupBox8.Controls.Add(this.groupBox4);
            this.groupBox8.Controls.Add(this.groupBox6);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.textBox1);
            this.groupBox8.Controls.Add(this.textBox5);
            this.groupBox8.Controls.Add(this.textBox3);
            this.groupBox8.Controls.Add(this.label7);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.textBox4);
            this.groupBox8.Controls.Add(this.groupBox1);
            this.groupBox8.Controls.Add(this.menuStrip1);
            this.groupBox8.Location = new System.Drawing.Point(6, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(576, 680);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = " 转台控制区";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(3, 45);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(567, 320);
            this.textBox6.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button_Send);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button6);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(403, 385);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(167, 267);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "执行文件控制";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button8.Location = new System.Drawing.Point(6, 25);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(155, 32);
            this.button8.TabIndex = 20;
            this.button8.Text = "初始化转台";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.init_table_speed);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(21, 540);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "X轴角度：";
            this.label5.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(19, 604);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Y轴角度：";
            this.label6.UseWaitCursor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(101, 537);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(108, 26);
            this.textBox1.TabIndex = 10;
            // 
            // textBox5
            // 
            this.textBox5.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox5.Location = new System.Drawing.Point(101, 633);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(108, 26);
            this.textBox5.TabIndex = 14;
            // 
            // textBox3
            // 
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(101, 601);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(108, 26);
            this.textBox3.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(21, 572);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "X轴速度：";
            this.label7.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(19, 636);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Y轴速度：";
            this.label8.UseWaitCursor = true;
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.Location = new System.Drawing.Point(101, 569);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(108, 26);
            this.textBox4.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 17);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(570, 25);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.另存为ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.另存为ToolStripMenuItem.Text = "另存为";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItem.Text = "扩展控制";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(200, 100);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(613, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(458, 335);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 695);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.button7);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "HIpnuc";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Status)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_Switch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        //  private System.Windows.Forms.ComboBox comboBox_CheckBits;
        //  private System.Windows.Forms.ComboBox comboBox_StopBits;
        //  private System.Windows.Forms.ComboBox comboBox_DataBits;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.ComboBox comboBox_Port;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton_ASCII;
        private System.Windows.Forms.RadioButton radioButton_Hex;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_Receive;
        private System.Windows.Forms.Button button_Send;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.PictureBox pictureBox_Status;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button8;
        public System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}

