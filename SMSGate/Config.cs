using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SMSGate
{
    public static class Config
    {
        public static string GateUrl { get; set; }
        public static string GateLogin { get; set; }
        public static string GatePass { get; set; }
        public static string UserAgent { get; set; }
    }
}
