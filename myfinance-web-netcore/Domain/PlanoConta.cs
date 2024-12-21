using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Domain
{
    public class PlanoConta
    {
        public int? Id { get; set; }
        public required string Nome { get; set; }
        public required string Tipo { get; set; }
    }
}
