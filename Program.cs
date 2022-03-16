using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace Haptic
{
    internal class Program
    {
        private static Communicator _communicator;

        static void Main(string[] args)
        {
            //create communication
            _communicator = new Communicator();
            _communicator.Send(Controller.Left, Motor.Front, 1);
            _communicator.Send(Controller.Right, Motor.Back, 60);

            while(Console.ReadKey().Key != ConsoleKey.Spacebar) { Thread.Sleep(1); } 
        }
    }
}
