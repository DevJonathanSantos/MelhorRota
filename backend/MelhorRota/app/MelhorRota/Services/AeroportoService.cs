using MelhorRota.Data.Models;
using MelhorRota.Entities;
using MelhorRota.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MelhorRota.Services
{
    public class AeroportoService : IAeroportoService
    {
        private readonly IAeroportoRepository _aeroportoRepository;
        public AeroportoService(IAeroportoRepository aeroportoRepository)
        {
            _aeroportoRepository = aeroportoRepository;
        }
        public async Task<List<Aeroporto>> BuscarAeroportos()
        {
            return await _aeroportoRepository.BuscarAeroportos();
        }

        public async Task<List<AeroportoRotas>> BuscarRotas()
        {
            return await _aeroportoRepository.BuscarRotas();
        }

        public async Task<string> BuscarMelhorRota(string origem, string destino)
        {
            var rotasDePara = await _aeroportoRepository.BuscarRotas();

            var rotas = new List<Rota>();

            foreach (var item in rotasDePara.Where(w => w.Origem == origem))
            {
                var rota = BuscarParadas(item, destino, rotasDePara);

                rotas.Add(new Rota()
                {
                    Paradas = rota.Paradas,
                    Valor = rota.Valor
                });
            }

            var maisBarata = rotas.OrderBy(o => o.Valor).FirstOrDefault();

            var json = JsonSerializer.Serialize(maisBarata);

            return json;

        }

        private static Parada BuscarParadas(AeroportoRotas rota, string destino, List<AeroportoRotas> rotasDePara)
        {
            decimal valor = 0;
            bool buscarProxima = true;

            List<string> list = new List<string>();
            list.Add(rota.Origem);
            list.Add(rota.Destino);
            valor += Convert.ToDecimal(rota.Valor);

            AeroportoRotas proxima = null;
            int x = 0;

            if (rota.Destino != destino)
            {
                do
                {
                    if (x == 0)
                        proxima = rotasDePara.SingleOrDefault(s => s.Origem == rota.Destino);

                    else
                        proxima = rotasDePara.SingleOrDefault(s => s.Origem == proxima.Destino);

                    if (proxima != null)
                    {
                        if (proxima != null && proxima.Destino == destino)
                        {
                            list.Add(proxima.Destino);
                            valor += Convert.ToDecimal(proxima.Valor);
                            buscarProxima = false;
                        }
                        else
                        {
                            list.Add(proxima.Destino);
                            valor += Convert.ToDecimal(proxima.Valor);
                        }
                        x++;
                    }
                    else
                    {
                        buscarProxima = false;
                    }


                } while (buscarProxima);
            }

            var parada = new Parada()
            {
                Paradas = list.ToList(),
                Valor = valor
            };

            return parada;
        }
    }
}
