using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntennaSetupAPP.Model
{
    class modelCNX
    {
        internal class CNX
        {
            public string ConnectionMode { get; set; }
            public string Name { get; set; }
            public string IPAddress { get; set; }
            public string IPPort { get; set; }
            public string IPPortA { get; set; }
            public string ComPort { get; set; }
            public string InitialBaudRate { get; set; }
            public string FinalBaudRate { get; set; }
            public int[] KanbanAntenaList { get; set; }
            public int[] PositionAntenaList { get; set; }
            public int[] DirectionAntenaList { get; set; }
            public string AliveTagList { get; set; }
            public string ImproperTagList { get; set; }
            public bool SendAlwaysReadTags { get; set; }
            public string SpecialParameter { get; set; }
            public string Supplier { get; set; }
            public List<AntenaProps> AntenaList { get; set; }
        }
        internal class AntenaProps
        {
            public int Antena { get; set; }
            public bool Used { get; set; }
        }
    }
}
