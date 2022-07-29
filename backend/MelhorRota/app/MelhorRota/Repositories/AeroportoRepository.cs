using MelhorRota.Data.Context;
using MelhorRota.Data.Models;
using MelhorRota.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorRota.Repositories
{
    public class AeroportoRepository : IAeroportoRepository
    {
        private readonly DataContext _data;
        public AeroportoRepository(DataContext data)
        {
            _data = data;
        }
        public async Task<List<Aeroporto>> BuscarAeroportos()
        {
            var aeroportos = _data.Aeroporto.ToList();
            return aeroportos;
        }

        public async Task<List<AeroportoRotas>> BuscarRotas()
        {
            var rotas =  _data.AeroportoRotas.ToList();

            return rotas;
        }
    }
}
