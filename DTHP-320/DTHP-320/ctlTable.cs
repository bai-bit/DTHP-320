using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHP_320
{
    public class ctlTable
    {
        packageData data = new packageData();

        /// <summary>
        /// 控制运动
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="ang"></param>
        /// <param name="speed"></param>
        /// <param name="acc"></param>
        /// <returns></returns>
        public  byte[] ctl_table_run(byte mode, double ang, double speed, double acc)
        {
            //串口打开之后发送通讯指令，没有ack包：AA A5 55 0F 00 00 00 00 01 00 00 00 00 B4
            //关闭串口之后，没有指令。

            //x轴位置运动：位置100°，速度100°/s  AA A5 55 11 40 42 0F 00 A0 40 42 0F 00 77
            //x轴位置运动：相对100°，速度100°/s  AA A5 55 12 40 42 0F 00 00 40 42 0F 00 D8
            //x轴速率运动：速度100,加速度100       AA A5 55 13 40 42 0F 00 00 40 42 0F 00 D9
            //x轴停止：                            AA A5 55 1F 00 00 00 00 00 00 00 00 00 C3
            //y轴位置运动：位置100°，速度100°/s  AA A5 55 21 40 42 0F 00 A0 40 42 0F 00 87
            //y轴位置运动：相对100°，速度100°/s  AA A5 55 22 40 42 0F 00 00 40 42 0F 00 E8
            //y轴位置运动：相对-100°，速度100°/s AA A5 55 22 C0 BD F0 FF 00 40 42 0F 00 C3
            //y轴速率运动：速度100，加速度100      AA A5 55 23 40 42 0F 00 00 40 42 0F 00 E9
            //y轴停止：                            AA A5 55 2F 00 00 00 00 00 00 00 00 00 D3

            contrl_info val = new contrl_info();
            val.mode = mode;
            val.angle = ang;
            val.speed = speed;
            val.acc = acc;

            return packageData.package_data(val);
        }

      
        /// <summary>
        /// 使能
        /// </summary>
        /// <param name="axis"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public byte[] ctl_table_status(byte axis, bool status)
        {
            //使能或者关闭xy轴运动使能
            //使能x轴：                            AA A5 55 1E 00 00 00 00 00 00 00 00 00 C2
            //取消使能x轴：                        AA A5 55 1E 00 00 00 00 80 00 00 00 00 42
            //使能y轴：                            AA A5 55 2E 00 00 00 00 00 00 00 00 00 D2
            //取消使能y轴：                        AA A5 55 2E 00 00 00 00 80 00 00 00 00 52
            //if(x_status)
            byte[] data = new byte[14];
            data[0] = 0xAA;
            data[1] = 0xA5;
            data[2] = 0x55;

            switch(axis)
            {
                case 0x1E:
                    data[3] = 0x1E;
                    if (status)
                        data[13] = 0xC2;
                    else
                    {
                        data[8] = 0x80;
                        data[13] = 0x42;
                    }
                    break;
                case 0x2E:
                    data[3] = 0x2E;
                    if (status)
                        data[13] = 0xD2;
                    else
                    {
                        data[8] = 0x80;
                        data[13] = 0x52;
                    }    
                    break;
            }
            return data;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        public byte[] ctl_table_stop(byte axis)
        {
            //全部停止
            //x轴停止：                            AA A5 55 1F 00 00 00 00 00 00 00 00 00 C3
            //y轴停止：                            AA A5 55 2F 00 00 00 00 00 00 00 00 00 D3

            byte[] data = new byte[14];
            data[0] = 0xAA;
            data[1] = 0xA5;
            data[2] = 0x55;

            switch (axis)
            {
                case 0x1F:
                    data[3] = 0x1F;
                    data[13] = 0xC3;
                    break;
                case 0x2F:
                    data[3] = 0x2F;
                    data[13] = 0xD3;
                    break;
            }
            return data;
        }

    }
}
