using MelhorRota.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorRota.Interfaces
{
    public interface IAeroportoService
    {
        Task<List<Aeroporto>> BuscarAeroportos();
        Task<List<AeroportoRotas>> BuscarRotas();
        Task<string> BuscarMelhorRota(string origem, string destino);
    }
}
