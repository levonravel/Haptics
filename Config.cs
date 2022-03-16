using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haptic
{
    public class Config
    {        
        public int BaudRate = 19200;
        public int DataBits = 8;
        public string[] ComPorts;
        public Parity Parity = Parity.None;
        public StopBits StopBits = StopBits.One;
        public Handshake Handshake = Handshake.None;
    }
}
