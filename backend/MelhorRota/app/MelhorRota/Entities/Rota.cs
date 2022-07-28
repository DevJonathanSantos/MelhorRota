using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorRota.Entities
{
    public class Rota
    {
        public List<string>? Paradas { get; set; }
        public decimal Valor { get; set; }
    }
}
