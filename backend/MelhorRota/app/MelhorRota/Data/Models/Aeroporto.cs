using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorRota.Data.Models
{
    public class Aeroporto
    {
        public long Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Nome { get; set; } = String.Empty;

        [Column(TypeName = "char(3)")]
        public string Codigo { get; set; } = String.Empty;
    }
}
