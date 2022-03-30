using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHP_320
{
    public struct contrl_info
    {
        public byte mode;
        public double angle;
        public double speed;
        public double acc;
    }
    public class packageData
    {

        public static byte[] package_data(contrl_info sport_data)
        {
            byte[] data = new byte[14];

            data[0] = 0xAA;
            data[1] = 0xA5;
            data[2] = 0x55;
            data[3] = sport_data.mode;
            //mode  绝对  相对  速率
            //    x 0x11  0x12  0x13
            //    y 0x21  0x22  0x23
            //绝对和相对模式，角度和速度
            //速率模式，速度和加速度
            //绝对模式，方向位为0xA0,其他模式为0x00，
            //最后一位是校验位
            switch(sport_data.mode)
            {
                case 0x11:
                    data[8] = 0xA0;
                    doubleToByte(sport_data.angle, out data[4], out data[5], out data[6], out data[7]);
                    doubleToByte(sport_data.speed, out data[9], out data[10], out data[11], out data[12]);
                    break;
                case 0x12:
                    data[8] = 0x00;
                    doubleToByte(sport_data.angle, out data[4], out data[5], out data[6], out data[7]);
                    doubleToByte(sport_data.speed, out data[9], out data[10], out data[11], out data[12]);
                    break;
                case 0x13:
                    data[8] = 0x00;
                    doubleToByte(sport_data.speed, out data[4], out data[5], out data[6], out data[7]);
                    doubleToByte(sport_data.acc, out data[9], out data[10], out data[11], out data[12]);
                    break;
                case 0x21:
                    data[8] = 0xA0;
                    doubleToByte(sport_data.angle, out data[4], out data[5], out data[6], out data[7]);
                    doubleToByte(sport_data.speed, out data[9], out data[10], out data[11], out data[12]);
                    break;
                case 0x22:
                    data[8] = 0x00;
                    doubleToByte(sport_data.angle, out data[4], out data[5], out data[6], out data[7]);
                    doubleToByte(sport_data.speed, out data[9], out data[10], out data[11], out data[12]);
                    break;
                case 0x23:
                    data[8] = 0x00;
                    doubleToByte(sport_data.speed, out data[4], out data[5], out data[6], out data[7]);
                    doubleToByte(sport_data.acc, out data[9], out data[10], out data[11], out data[12]);
                    break;
            }
            checkout_sum(data, out data[13]);
            return data;
           
        }

        public static void checkout_sum(byte[] data,out byte checkout_data)
        {
            checkout_data = 0;
            for (int i = 0; i < data.Length - 1; i++)
                checkout_data += data[i];
            checkout_data &= 0xff;
        }

        public static void doubleToByte(double data, out byte bit_0_7, out byte bit_8_15, out byte bit_16_23, out byte bit_31_24)
        {
            bit_0_7 = (byte)(((int)(data * 10000)) & 0xFF);
            bit_8_15 = (byte)(((int)(data * 10000)) >> 8 & 0xFF);
            bit_16_23 = (byte)(((int)(data * 10000)) >> 16 & 0xFF);
            bit_31_24 = (byte)(((int)(data * 10000)) >> 24 & 0xFF);         
        }
    }
}
