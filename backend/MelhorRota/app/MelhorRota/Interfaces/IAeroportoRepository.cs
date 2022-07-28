using MelhorRota.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorRota.Interfaces
{
    public interface IAeroportoRepository
    {
        Task<List<Aeroporto>> BuscarAeroportos();
        Task<List<AeroportoRotas>> BuscarRotas();
    }
}
