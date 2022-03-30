using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTHP_320
{
    public class connection
    {
        public delegate bool SendDataEventHandler(byte[] buffer);
        public event SendDataEventHandler OnSendData;

        public delegate void ReceivedDataEventHandler(byte[] buffer);
        public event ReceivedDataEventHandler OnReceviedData;

        public bool Send(byte[] buffer)
        {
            if (OnSendData != null)
            {
                return OnSendData(buffer);
            }
            else
            {
                return false;
            }
        }

        public void Input(byte[] buf)
        {
            if (OnReceviedData != null)
            {
                OnReceviedData(buf);
            }
        }
    }
}
