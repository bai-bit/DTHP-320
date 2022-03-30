using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using System.Drawing;
using DTHP_320.Properties;
using System.Threading;
using System.IO;



namespace DTHP_320
{
    public partial class Form1 : Form
    {
        //定义转台控制类
        ctlTable ctltable = new ctlTable();
        //定义端口类
        private SerialPort ComDevice = new SerialPort();
       

        private connection m_connection = new connection();

        //校准线程
        Thread thread_calib;
        //更新转台姿态线程
        Thread thread_update_table_pose;

        bool x_motor_enable = false;
        bool y_motor_enable = false;

        private status state = status.kStatus_Idle_aa;
        private byte[] DataBuf = new byte[512];
        int num = 0;

        double x_speed;
        double y_speed;
        double x_angle_;
        double y_angle_;

        public Form1()
        {
            InitializeComponent();

            InitralConfig();
        }
        /// <summary>
        /// 配置初始化
        /// </summary>
        private void InitralConfig()
        {
            Thread table_serial_thread = null;

            //查询主机上存在的串口

            table_serial_thread = new Thread(table_serial);
            table_serial_thread.Name = Convert.ToString(1);
            table_serial_thread.IsBackground = true;//将线程转为后台线程
            table_serial_thread.Start();//传入串口号

            Thread hipnuc_serial_thread = null;
            hipnuc_serial_thread = new Thread(hipnuc_serial);
            hipnuc_serial_thread.Name = Convert.ToString(2);
            hipnuc_serial_thread.IsBackground = true;
            hipnuc_serial_thread.Start();

            m_connection.OnSendData += new connection.SendDataEventHandler(SendData);

        }

        /// <summary>
        /// 一旦ComDevice.DataReceived事件发生，就将从串口接收到的数据显示到接收端对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //开辟接收缓冲区
            byte[] ReDatas = new byte[ComDevice.BytesToRead];
            //从串口读取数据
            ComDevice.Read(ReDatas, 0, ReDatas.Length);
            //实现数据的解码与显示
            //AddData(ReDatas);
            PacketDecode(ReDatas);
            
        }

        private enum status
        {
            kStatus_Idle_aa,
            kStatus_Idle_a5,
            kStatus_Idle_55,
            kStatus_Cmd,
            kStatus_CRCLow,
            kStatus_CRCHigh,
            kStatus_Data,
        };


        //解析串口返回的数据
        public void PacketDecode(byte[] data)
        {
            
            byte check = 0;
            int i = 0;
            for (i = 0; i < data.Length; i++)
            {
                switch (state)
                {
                    case status.kStatus_Idle_aa:
                        if (0xAA == data[i])
                        {
                            state = status.kStatus_Idle_a5;
                            DataBuf[0] = data[i];
                        }
                           
                        break;
                    case status.kStatus_Idle_a5:
                        if (0xA5 == data[i])
                        {
                            state = status.kStatus_Idle_55;
                            DataBuf[1] = data[i];
                        }
                           
                        else
                            state = status.kStatus_Idle_aa;
                        break;
                    case status.kStatus_Idle_55:
                        if (0x55 == data[i])
                        {
                            state = status.kStatus_Data;
                            DataBuf[2] = data[i];
                            num = 3;
                        }
                        else
                            state = status.kStatus_Idle_aa;
                        break;
                    case status.kStatus_Data:
                        byte temp = data[i];
                        DataBuf[num++] = temp;
                        if (num == 22)
                        {
                            //  AA A5 55 FA 4C 32 00 00 00 00 00 02 18 55 33 00 00 00 00 00 00 BE
                            //  AA A5 55 FA 4C 32 00 00 00 00 00 02 19 55 33 00 FF FF FF FF 00 BB
                            //  AA A5 55  CC BF 2D 00  FF FF FF FF  00  A9 33 32 00  00 00 00 00 00  66
                            check = 0;
                            for (int j = 0; j < 21; j++)
                                check += DataBuf[j];

                            if ((check & 0xff) == DataBuf[21])
                            {
                                //AddData(DataBuf);
                                analysis_data(DataBuf);
                            }
                            state = status.kStatus_Idle_aa;
                            num = 0;
                        }
                        break;
                }
            }

        }

        void table_serial()
        {
            comboBox_Port.Items.AddRange(SerialPort.GetPortNames());
            if (comboBox_Port.Items.Count > 0)
            {
                comboBox_Port.SelectedIndex = 0;
            }
            else
            {
                comboBox_Port.Text = "未检测到串口";
            }

            comboBox_BaudRate.SelectedIndex = 6;
            // comboBox_DataBits.SelectedIndex = 0;
            // comboBox_StopBits.SelectedIndex = 0;
            // comboBox_CheckBits.SelectedIndex = 0;
            // pictureBox_Status.BackgroundImage = Properties.Resources.red;

            //向ComDevice.DataReceived（是一个事件）注册一个方法Com_DataReceived，当端口类接收到信息时时会自动调用Com_DataReceived方法
            ComDevice.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }

        void hipnuc_serial()
        {
            
        }

        void update_table_pose_thread()
        {

        }


        public void analysis_data(byte[] data)
        {
            //解析数据
            x_angle_ = (float)BitConverter.ToInt32(data, 3) / 10000.0;
            y_angle_ = (float)BitConverter.ToInt32(data, 12) / 10000.0;
            x_speed = (float)BitConverter.ToInt32(data, 7) / 10000.0;
            y_speed = (float)BitConverter.ToInt32(data, 16) / 10000.0;
            textBox1.Text = string.Format("{0:#, ##0.0000}", Convert.ToDouble((data[3] | data[4] << 8 | data[5] << 16 | data[6] << 24) / 10000.0));
            textBox4.Text = string.Format("{0:#, ##0.0000}", Convert.ToDouble(x_speed));
            textBox3.Text = string.Format("{0:#, ##0.0000}", Convert.ToDouble((data[12] | data[13] << 8 | data[14] << 16 | data[15] << 24) / 10000.0));
            textBox5.Text = string.Format("{0:#, ##0.0000}", Convert.ToDouble(y_speed));

            //解析电机使能状态
            if(data[11] == 0x1)
            {
                //x轴电机使能
                x_motor_enable = true;
                //checkBox1.Checked = true;
            }
            else
            {
                //x轴电机失能
                x_motor_enable = false;
                //checkBox1.Checked= false;
            }

            if(data[20] == 0x1)
            {
                //y轴电机使能
                //checkBox2.Checked = true;
            }
            else
            {
                //y轴电机失能
                //checkBox2.Checked = false;
            }

        }

        /// <summary>
        /// 解码过程
        /// </summary>
        /// <param name="data">串口通信的数据编码方式因串口而异，需要查询串口相关信息以获取</param>
        public void AddData(byte[] data)
        {
            if (radioButton_Hex.Checked)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x2}" + " ", data[i]);
                }
                AddContent(sb.ToString().ToUpper());
                
            }
            else if (radioButton_ASCII.Checked)
            {
                AddContent(new ASCIIEncoding().GetString(data));
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.AppendFormat("{0:x2}" + " ", data[i]);
                }
                AddContent(sb.ToString().ToUpper());
            }
        }

        /// <summary>
        /// 接收端对话框显示消息
        /// </summary>
        /// <param name="content"></param>
        private void AddContent(string content)
        {
            BeginInvoke(new MethodInvoker(delegate
            {              
                textBox_Receive.AppendText(content);
                textBox_Receive.AppendText("\r\n");
            }));
        }

        /// <summary>
        /// 串口开关
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Switch_Click(object sender, EventArgs e)
        {
            if (comboBox_Port.Items.Count <= 0)
            {
                MessageBox.Show("未发现可用串口，请检查硬件设备");
                return;
            }

            if (ComDevice.IsOpen == false)
            {
                //设置串口相关属性
                ComDevice.PortName = comboBox_Port.SelectedItem.ToString();
                ComDevice.BaudRate = Convert.ToInt32(comboBox_BaudRate.SelectedItem.ToString());
             //   ComDevice.Parity = (Parity)Convert.ToInt32(comboBox_CheckBits.SelectedIndex.ToString());
             //   ComDevice.DataBits = Convert.ToInt32(comboBox_DataBits.SelectedItem.ToString());
             //   ComDevice.StopBits = (StopBits)Convert.ToInt32(comboBox_StopBits.SelectedItem.ToString());
                try
                {
                    //开启串口
                    ComDevice.Open();
                    button_Send.Enabled = true;
                    groupBox6.Enabled = true;
                    groupBox4.Enabled = true;
                    if(thread_calib == null)
                    {
                        thread_calib = new Thread(calibration_thread);
                        thread_calib.Start();
                        thread_calib.IsBackground = true;
                        thread_calib.Priority = ThreadPriority.AboveNormal;
                    }
                    if(thread_update_table_pose == null)
                    {
                        thread_update_table_pose = new Thread(update_table_pose_thread);
                        thread_update_table_pose.Start();
                    }
 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "未能成功开启串口", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                button_Switch.Text = "关闭";
                pictureBox_Status.BackgroundImage = Properties.Resources.green;
            }
            else
            {
                try
                {
                    //关闭串口
                    ComDevice.Close();
                    groupBox6.Enabled = false;
                    button_Send.Enabled = false;
                    groupBox4.Enabled = false;
                    //if (thread_calib != null)
                    //    thread_calib.Abort();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "串口关闭错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button_Switch.Text = "开启";
                pictureBox_Status.BackgroundImage = Properties.Resources.red;
            }

            comboBox_Port.Enabled = !ComDevice.IsOpen;
            comboBox_BaudRate.Enabled = !ComDevice.IsOpen;
            // comboBox_DataBits.Enabled = !ComDevice.IsOpen;
            // comboBox_StopBits.Enabled = !ComDevice.IsOpen;
            // comboBox_CheckBits.Enabled = !ComDevice.IsOpen;

        }

        /// <summary>
        /// 此函数将编码后的消息传递给串口
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool SendData(byte[] data)
        {
            if (ComDevice.IsOpen)
            {
                try
                {
                    //将消息传递给串口
                    ComDevice.Write(data, 0, data.Length);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "发送失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("串口未开启", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Int32 last_baud = Convert.ToInt32(iniFile.Read("SerialPort", "Baudrate"));

            //ToolStripItemCollection DropDownCollection = item.DropDownItems;
            //DropDownCollection.Clear();

            //DropDownCollection.Add("刷新串口");
            //foreach (string portName in System.IO.Ports.SerialPort.GetPortNames())
            //{
            //    DropDownCollection.Add("COM" + Regex.Replace(portName.Substring("COM".Length, portName.Length - "COM".Length), "[^.0-9]", "\0") + ", " + 115200.ToString());
            //}
            //DropDownCollection.Add(toolStripMenuItemOpenSerialConnectionDialog);
        }


        /// <summary>
        /// x轴电机状态显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            byte[] data = new byte[14];
            if (checkBox1.Checked)
            {
                data = ctltable.ctl_table_status(0x1E, true);
                Thread.Sleep(100);
                label9.BackColor = Color.Green;
                if(!x_motor_enable)
                {
                    checkBox1.Checked = false;
                }
                
            }
            else
            {
                data = ctltable.ctl_table_status(0x1E, false);
                Thread.Sleep(100);
                label9.BackColor = Color.Red;
            }
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(200);
        }

        /// <summary>
        /// y轴电机状态显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            byte[] data = new byte[14];
            if (checkBox2.Checked)
            {
                data = ctltable.ctl_table_status(0x2E, true);
                label10.BackColor = Color.Green;
            }
            else
            {
                data = ctltable.ctl_table_status(0x2E, false);
                label10.BackColor = Color.Red;
            }
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(200);
        }

        /// <summary>
        /// 扩展控制窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //扩展控制类
            extensionCtrl extSportFrm = null;

            if (extSportFrm == null || extSportFrm.IsDisposed)
            {
                extSportFrm = new extensionCtrl(m_connection);
            }
            extSportFrm.Show(); //显示子窗口
            extSportFrm.Focus();
        }

        private void textBox_file_TextChanged(object sender, EventArgs e)
        {

        }

        bool IsTextChanged = false;
        string TextFileName = "";
        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //文件操作类
            //Thread open = new Thread(open_file);
            //open.Start();
            //operation_file oper_file = new operation_file();
            //oper_file.open_file();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "open file";
            ofd.Filter = "text|*.txt|all file|*.*";
            ofd.InitialDirectory = Application.StartupPath;


            DialogResult status = ofd.ShowDialog();
            if (status == DialogResult.OK)
            {
                TextFileName = ofd.FileName;
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                StreamReader sr = new StreamReader(fs, Encoding.Default);
                //textBox6.Text = "";
                richTextBox1.Text = "";
                while (sr.EndOfStream == false)
                {
                    string line = sr.ReadLine();
                    //textBox6.Text = textBox6.Text + line + "\r\n";
                    //textBox6.Text = sr.ReadToEnd();

                    richTextBox1.Text = richTextBox1.Text + line + "\r\n";
                    richTextBox1.Text = sr.ReadToEnd();
                }
                sr.Close();
                fs.Close();
                IsTextChanged = false;
            }
            textBox6.BackColor = Color.Green;
        }

        public void open_file()
        {
            while(true)
            {
                if (read_file_flag)
                {
                    string[] arr = new string[richTextBox1.Lines.Length];
                    int total = 0,temp = 0;
                    for (int i = 0; i < richTextBox1.Lines.Length; i++)
                    {
                        arr[i] = richTextBox1.Lines[i];
                        while(i > 0)
                        {
                            richTextBox1.Select(temp, richTextBox1.Lines[i - 1].Length + 1);
                            //richTextBox1.SelectionColor = Color.Black;
                            richTextBox1.SelectionBackColor = Color.White;
                            break;
                        }
                        Thread.Sleep(100);

                        richTextBox1.Select(total, richTextBox1.Lines[i].Length + 1);
                        //richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.SelectionBackColor = Color.Blue;

                        temp = total;
                        total += richTextBox1.Lines[i].Length + 1;
                        
                        Thread.Sleep(100);
                        //textBox6.Lines[i]. =  Color.Red;
                        //textBox6.
                    }
                    read_file_flag = false;
                }
            }
            
            
        }

        bool read_file_flag = false;
        Thread open_file_th = null;

        private void button7_Click(object sender, EventArgs e)
        {
            //string endline = textBox6.Lines[textBox6.Lines.Length - 1];
            if (open_file_th == null)
            {
                open_file_th = new Thread(open_file);
                open_file_th.Start();
            }

            if (read_file_flag == false)
                read_file_flag = true;
            //string[] arr = new string[richTextBox1.Lines.Length];
            //int total = 0;
            //for (int i = 0; i < richTextBox1.Lines.Length; i++)
            //{
            //    arr[i] = richTextBox1.Lines[i];
                
            //    richTextBox1.Select(total, richTextBox1.Lines[i].Length);
            //    richTextBox1.SelectionColor = Color.Red;
            //    richTextBox1.SelectionBackColor = Color.Blue;
            //    total += richTextBox1.Lines[i].Length;
            //    Thread.Sleep(1000);
            //    //textBox6.Lines[i]. =  Color.Red;
            //    //textBox6.
            //}

        }
    }
}
