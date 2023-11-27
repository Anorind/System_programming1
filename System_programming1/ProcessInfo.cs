using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_programming1
{
    internal class ProcessInfo
    {
        public string ProcessName { get; set; }
        public int Id { get; set; }
        public int ThreadCount { get; set; }
        public int HandleCount { get; set; }
    }
}
