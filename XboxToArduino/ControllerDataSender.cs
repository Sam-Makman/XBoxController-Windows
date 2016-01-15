using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XboxToArduino
{
    class ControllerDataSender
    {
        private byte[] dataPacket;
        private ControllerInput cInput;
        public ControllerDataSender(ControllerInput cInput)
        {
            this.cInput = cInput;


        }

        public void Update()
        {
            dataPacket = new byte[11];
            if (cInput.A)
            {
                dataPacket[0] += 1;
            }
            if (cInput.B)
            {
                dataPacket[0] += 2;
            }
            if (cInput.X)
            {
                dataPacket[0] += 4;
            }
            if (cInput.Y)
            {
                dataPacket[0] += 8;
            }


            byte[] bt = BitConverter.GetBytes(cInput.rightX);
            dataPacket[1] = bt[0];
            dataPacket[2] = bt[1];

            bt = BitConverter.GetBytes(cInput.rightY);
            dataPacket[3] = bt[0];
            dataPacket[4] = bt[1];

            bt = BitConverter.GetBytes(cInput.leftX);
            dataPacket[5] = bt[0];
            dataPacket[6] = bt[1];

            bt = BitConverter.GetBytes(cInput.leftY);
            dataPacket[7] = bt[0];
            dataPacket[8] = bt[1];

            //sets trigger value
            dataPacket[9] = cInput.rightTrigger;
            dataPacket[10] = cInput.leftTrigger;
        }

        public void Send()
        {
            SerialPort sPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            try
            {
                sPort.Open();

                sPort.Write(dataPacket, 0, dataPacket.Length);
                sPort.Close();
            }
            catch 
            {
                
            }
        }
    }
}
