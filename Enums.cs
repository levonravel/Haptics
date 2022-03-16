using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haptic
{
    public enum Controller
    {
        Left = 0,
        Right = 1,
    }

    public enum Motor
    {
        Front = 0,
        Back = 1
    }
    
    public enum SerializationFeedback
    {
        CantOpenPort,
        ComUnitNotAvailable,
        Successful
    }
}
