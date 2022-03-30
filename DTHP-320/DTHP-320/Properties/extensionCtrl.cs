using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace DTHP_320.Properties
{
    public partial class extensionCtrl : Form
    {
        ctlTable extentable = new ctlTable();
        public connection connect_func;
        bool original_location_flag = false;
        bool table_stop_flag = false;
        bool active_flag = false;

        public extensionCtrl(connection c)
        {
            InitializeComponent();

            connect_func = c;
            Thread th = new Thread(exten_ctrl);
            th.IsBackground = true;
            th.Start();
        }

        

        public void exten_ctrl()
        {
            while(true)
            {
                if(active_flag)
                {
                    table_exten_ctrl();
                    active_flag = false;
                }

                if(original_location_flag)
                {
                    original_location();
                    original_location_flag = false;
                }

                if(table_stop_flag)
                {
                    table_stop();
                    table_stop_flag = false;
                }
            }
        }

        public void table_exten_ctrl()
        {
            bool x_check_status = radioButton1.Checked;
            bool y_check_status = radioButton2.Checked;
            bool absolute_angle = radioButton4.Checked;
            bool relative_angle = radioButton5.Checked;
            bool speed_mode = radioButton6.Checked;
            int input_angle = Convert.ToInt32(textBox1.Text);
            int input_speed = Convert.ToInt32(textBox2.Text);
            int input_acc = Convert.ToInt32(textBox3.Text);
            byte axis = 0;
            byte motor_mode = 0;
            byte param = 0;
            byte[] data = new byte[14];

            if (x_check_status && !y_check_status)
                axis = 0x10;
            else if (!x_check_status && y_check_status)
                axis = 0x20;
            else
                axis = 0;

            if (absolute_angle && !relative_angle && !speed_mode)
                motor_mode = 0x1;
            else if (!absolute_angle && relative_angle && !speed_mode)
                motor_mode = 0x2;
            else if (!absolute_angle && !relative_angle && speed_mode)
                motor_mode = 0x3;
            else
                motor_mode = 0;

            param = (byte)(axis | motor_mode);

            data = extentable.ctl_table_run(param, input_angle, input_speed, input_acc);

            //form1_func.SendData(data);
            connect_func.Send(data);
            param = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                radioButton2.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                radioButton1.Checked = false;
        }
  
        /// <summary>
        /// 停止函数
        /// </summary>
        public void table_stop()
        {
            byte[] data = new byte[14];

            data = extentable.ctl_table_stop(0x1F);
            connect_func.Send(data);
            Thread.Sleep(100);

            data = extentable.ctl_table_stop(0x2F);
            connect_func.Send(data);
            Thread.Sleep(100);
        }
        /// <summary>
        /// 回归原点
        /// </summary>
        public void original_location()
        {
            byte[] data = extentable.ctl_table_run(0x11, 0, 100, 100);
            connect_func.Send(data);
            Thread.Sleep(1000);
            data = extentable.ctl_table_run(0x21, 0, 100, 100);
            connect_func.Send(data);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (active_flag == false)
                active_flag = true;
        }

        /// <summary>
        /// 暂停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (table_stop_flag == false)
                table_stop_flag = true;
        }

        /// <summary>
        /// 回位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (original_location_flag == false)
                original_location_flag = true;
        }
    }
}
