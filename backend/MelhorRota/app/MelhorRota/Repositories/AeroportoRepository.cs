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
            //_data.AddRange(new List<AeroportoRotas> {
            //    new AeroportoRotas() { Origem = "GRU",Destino= "BRC",Valor=10},
            //    new AeroportoRotas() { Origem = "BRC",Destino= "SCL",Valor=5},
            //    new AeroportoRotas() { Origem = "GRU",Destino= "CDG",Valor=75},
            //    new AeroportoRotas() { Origem = "GRU",Destino= "SCL",Valor=20},
            //    new AeroportoRotas() { Origem = "GRU",Destino= "ORL",Valor=56},
            //    new AeroportoRotas() { Origem = "ORL",Destino= "CDG",Valor=5},
            //    new AeroportoRotas() { Origem = "SCL",Destino= "ORL",Valor=20}
            //});

            //await _data.SaveChangesAsync();

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
