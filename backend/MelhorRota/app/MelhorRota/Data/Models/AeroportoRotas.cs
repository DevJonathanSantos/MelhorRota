using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorRota.Data.Models
{
    public class AeroportoRotas
    {
        public long Id { get; set; }

        [Column(TypeName = "char(3)")]
        public string Origem { get; set; } = string.Empty;

        [Column(TypeName = "char(3)")]
        public string Destino { get; set; } = string.Empty;
        public decimal Valor { get; set; } 
    }
}
