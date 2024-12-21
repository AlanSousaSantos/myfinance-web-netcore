using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myfinance_web_netcore.Domain
{
    public class Transacao
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public required string Historico { get; set; }
        public required string Tipo { get; set; }
        public int PlanoContaId { get; set; }
        public required PlanoConta PlanoConta { get; set; }
    }
}
