using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlimDX.XInput;

namespace XboxToArduino
{
    internal class ControllerInput
    {



        public readonly Controller controller;
        private readonly UserIndex uIndex;
        private uint lastPacket;

        public ControllerInput(UserIndex userIndex)
        {
            uIndex = userIndex;
            controller = new Controller(uIndex);

        }

        public bool A { get; private set; }
        public bool B { get; private set; }
        public bool X { get; private set; }
        public bool Y { get; private set; }

        public byte rightTrigger { get; private set; }
        public byte leftTrigger { get; private set; }
        public short rightX { get; private set; }
        public short rightY { get; private set; }
        public short leftX { get; private set; }
        public short leftY { get; private set; }


        public bool Connected
        {
            get { return controller.IsConnected; }
        }

        public void Update()
        {
            if (!Connected) return;

            var state = controller.GetState();
            if (lastPacket == state.PacketNumber) return;
            lastPacket = state.PacketNumber;

            var gamepadState = state.Gamepad;

            //gets state of all gamepad buttons 
            A = (gamepadState.Buttons & GamepadButtonFlags.A) != 0;
            B = (gamepadState.Buttons & GamepadButtonFlags.B) != 0;
            X = (gamepadState.Buttons & GamepadButtonFlags.X) != 0;
            Y = (gamepadState.Buttons & GamepadButtonFlags.Y) != 0;
            
            //gets states of gamepad sticks 
            leftX = gamepadState.LeftThumbX;
            leftY = gamepadState.LeftThumbY;
        
            rightX = gamepadState.RightThumbX;
            rightY = gamepadState.RightThumbY;

            //gets state of bumpers 
            rightTrigger = gamepadState.RightTrigger;
            leftTrigger = gamepadState.LeftTrigger;
        }

        public void start()
        {
            Update();

        }
    }
}
