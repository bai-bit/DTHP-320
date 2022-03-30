using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Text;
using System.Drawing;
using System.Threading;


namespace DTHP_320
{
    public partial class Form1 : Form
    {
        bool calibration_flag = false;
        bool original_location_flag = false;
        bool init_table_speed_flag = false;
        bool check_gyr_running_flag = false;

        /// <summary>
        /// 回归原点
        /// </summary>
        public void original_location()
        {
            byte[] data = ctltable.ctl_table_run(0x11, 0, 100, 100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(1000);
            data = ctltable.ctl_table_run(0x21, 0, 100, 100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(1000);
            while (!check_location(0, 0))
                continue;
        }

        /// <summary>
        /// 检测目标与实际角度的状态
        /// </summary>
        /// <param name="x_angle"></param>
        /// <param name="y_angle"></param>
        /// <returns></目标与实际角度一致时返回true>
        public bool check_location(double x_angle, double y_angle)
        {
            //读取角度数值，和目标角度进行对比，误差在0.0002°之内，就返回true；否则返回false
            double x_practical, y_practical;
            //x_practical = Convert.ToDouble(textBox1.Text);
            //y_practical = Convert.ToDouble(textBox3.Text);
            x_practical = x_angle_;
            y_practical = y_angle_;

            if ((x_angle - x_practical <= 0.0002 && x_angle - x_practical >= -0.0002) && (y_angle - y_practical <= 0.0002 && y_angle - y_practical >= -0.0002))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 校准线程
        /// </summary>
        public void calibration_thread()
        {
            while (true)
            {
                if (check_gyr_running_flag)
                {
                    byte[] data = ctltable.ctl_table_run(0x12, 345, 100, 100);
                    ComDevice.Write(data, 0, data.Length);
                    textBox6.AppendText(" \r\n369\r\n \r\n");
                    check_gyr_running_flag = false;
                }

                if (calibration_flag)
                {
                    textBox6.AppendText("abc\r\n");
                    original_location();
                    Thread.Sleep(4000);

                    //六面校准
                    calibration_acc();
                    Thread.Sleep(8000);
                    //校准陀螺
                    calibration_gyr();
                    textBox6.AppendText("yhn\r\n");
                    calibration_flag = false;
                    textBox6.AppendText("ujm\r\n");
                }

                if (original_location_flag)
                {
                    original_location();
                    textBox6.AppendText("123\r\n");
                    original_location_flag = false;
                    textBox6.AppendText("456\r\n");
                }

                if (init_table_speed_flag)
                {
                    init_table_runuing();
                    textBox6.AppendText("789\r\n");
                    init_table_speed_flag = false;
                    textBox6.AppendText("741\r\n");
                }
            }
        }

        /// <summary>
        /// 初始化转台的速度
        /// </summary>
        public void init_table_runuing()
        {
            byte[] data = ctltable.ctl_table_run(0x13, 90, 100, 100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(500);
            data = ctltable.ctl_table_run(0x23, 90, 100, 100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(2000);
            original_location();

        }

        /// <summary>
        /// 校准加速度计
        /// </summary>
        public void calibration_acc()
        {
            Thread.Sleep(3000);
            byte[] data = ctltable.ctl_table_run(0x21, 90, 100, 100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(1000);
            while (!check_location(0, 90))
                continue;
            Thread.Sleep(6000);

            data = ctltable.ctl_table_run(0x21, 180, 100, 100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(1000);
            while (!check_location(0, 180))
                continue;
            Thread.Sleep(6000);

            data = ctltable.ctl_table_run(0x21, 270, 100, 100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(1000);
            while (!check_location(0, 270))
                continue;
            Thread.Sleep(6000);

            data = ctltable.ctl_table_run(0x11, 90, 100, 100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(1000);
            while (!check_location(90, 270))
                continue;
            Thread.Sleep(6000);

            data = ctltable.ctl_table_run(0x11, 270, 100, 100);
            ComDevice.Write(data, 0, data.Length);
            Thread.Sleep(1000);
            while (!check_location(270, 270))
                continue;
            Thread.Sleep(6000);

            original_location();
            while (!check_location(0, 0))
                continue;
        }

        /// <summary>
        /// 校准陀螺
        /// </summary>
        public void calibration_gyr()
        {
            Thread.Sleep(3000);
            byte[] data = ctltable.ctl_table_run(0x12, -720, 50, 100);
            ComDevice.Write(data, 0, data.Length);
            calib_acc_gyr_delay(0, 0);
            calib_acc_gyr_delay(0, 0);
            Thread.Sleep(7000);

            data = ctltable.ctl_table_run(0x22, -720, 50, 100);
            ComDevice.Write(data, 0, data.Length);
            calib_acc_gyr_delay(0, 0);
            calib_acc_gyr_delay(0, 0);
            Thread.Sleep(7000);

            data = ctltable.ctl_table_run(0x11, 90, 50, 100);
            ComDevice.Write(data, 0, data.Length);
            calib_acc_gyr_delay(90, 0);
            Thread.Sleep(7000);

            data = ctltable.ctl_table_run(0x22, -720, 50, 100);
            ComDevice.Write(data, 0, data.Length);
            calib_acc_gyr_delay(90, 0);
            calib_acc_gyr_delay(90, 0);
            Thread.Sleep(7000);

            original_location();
            while (!check_location(0, 0))
                continue;
        }

        /// <summary>
        /// 检测转台是否到位，如果不到位就死循环
        /// </summary>
        /// <param name="x_angle"></param>
        /// <param name="y_angle"></param>
        void calib_acc_gyr_delay(double x_angle, double y_angle)
        {
            Thread.Sleep(3000);
            while (!check_location(x_angle, y_angle))
                continue;
        }

        /// <summary>
        /// 校准触发函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_start_calib(object sender, EventArgs e)
        {
            if (calibration_flag == false)
                calibration_flag = true;

            //string cmd = textBox_Send.Text;
            //cmd += "\r\n";
            //byte[] sendData = System.Text.Encoding.ASCII.GetBytes(cmd);

            //SendData(sendData);
        }

        /// <summary>
        /// 检测按钮 触发 转345° 检测陀螺欧拉角误差
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_check_gyr(object sender, EventArgs e)
        {
            if (check_gyr_running_flag == false)
                check_gyr_running_flag = true;

        }

        /// <summary>
        /// 回归原点触发函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void button6_Click(object sender, EventArgs e)
        {
            if (original_location_flag == false)
                original_location_flag = true;
        }

        /// <summary>
        /// 初始化转台触发函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void init_table_speed(object sender, EventArgs e)
        {
            if (init_table_speed_flag == false)
                init_table_speed_flag = true;
        }
    }
}
