using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haptic
{
    public class Communicator
    {
        private List<SerialPort> _ports = new List<SerialPort>();
        private byte[] _buffer = new byte[2];
        private byte _controllerInfo = 0;

        public Communicator(Config config = null)
        {
            if(config == null)
            {
                config = new Config();
                config.ComPorts = SerialPort.GetPortNames();
            }
            for (int i = 0; i < config.ComPorts.Length; i++)
            {
                _ports.Add(new SerialPort(config.ComPorts[i], config.BaudRate, config.Parity, config.DataBits, config.StopBits));
                _ports[i].Handshake = config.Handshake;
                try
                {
                    _ports[i].Open();
                }
                catch { }
            }
        }
        
        public SerializationFeedback Send(Controller controller, Motor motor, byte motorPosition)
        {
            _controllerInfo = 0;
            var didOpen = false;
            for (int i = 0; i < _ports.Count; i++)
            {
                if (!_ports[i].IsOpen) continue;

                _controllerInfo |= (byte)((int)controller << 0);
                _controllerInfo |= (byte)((int)motor << 1);                
                _buffer[0] = _controllerInfo;
                _buffer[1] = motorPosition;
                _ports[i].Write(_buffer, 0, _buffer.Length);
            }
            return didOpen == true ? SerializationFeedback.Successful : SerializationFeedback.CantOpenPort;
        }

        public void Dispose()
        {
            for (int i = 0; i < _ports.Count; i++)
            {
                _ports[i].Close();
            }
        }
    }
}
