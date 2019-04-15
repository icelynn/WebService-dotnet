using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServices.Models.External
{
    public class Plan
    {
        public string PlanCode { get; }
        public string PlanName { get; }
        public uint Amount { get; }
        public string AmountUnit { get; }
        public byte Period { get; }
        public uint Premium { get; }
    }
}
