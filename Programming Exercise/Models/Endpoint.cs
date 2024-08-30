using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Exercise.Models
{
    public class Endpoint
    {
        public string SerialNumber { get; set; }
        public int MeterModelId { get; set; }
        public int MeterNumber { get; set; }
        public string FirmwareVersion { get; set; }
        public int SwitchState { get; set; } // 0: Desconectado, 1: Conectado, 2: Armado
    }
}
