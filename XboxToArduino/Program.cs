using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SlimDX.XInput;

namespace XboxToArduino
{
    class Program
    {
        static void Main(string[] args)
        {
            ControllerInput CI  = new ControllerInput(UserIndex.One);
            ControllerDataSender CDS = new ControllerDataSender(CI);
            while (true)
            {

                CI.Update();
                CDS.Update();
                CDS.Send();
                Thread.Sleep(100);
            }
        }
    }
}
