using MelhorRota.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelhorRota.Data.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DataContext>>()))
            {

                if (!context.Aeroporto.Any())
                {
                    context.Aeroporto.AddRange(
                    new Aeroporto
                    {
                        Nome = "Aeroporto em Guarulhos(GRU)",
                        Codigo = "GRU",
                    },
                    new Aeroporto
                    {
                        Nome = "Aeroporto de Bariloche(BRC)",
                        Codigo = "BRC",
                    },
                    new Aeroporto
                    {
                        Nome = "Aeroporto de Santiago(SCL)",
                        Codigo = "SCL",
                    },
                    new Aeroporto
                    {
                        Nome = "Aeroporto Executivo de Orlando(ORL)",
                        Codigo = "ORL",
                    },
                    new Aeroporto
                    {
                        Nome = "Aeroporto de Paris-Charles de Gaulle(CDG)",
                        Codigo = "CDG",
                    }
                );

                    context.SaveChanges();
                }


                if (!context.AeroportoRotas.Any())
                {
                    context.AeroportoRotas.AddRange(
                      new AeroportoRotas
                      {
                          Origem = "GRU",
                          Destino = "BRC",
                          Valor = 10.00m
                      },
                      new AeroportoRotas
                      {
                          Origem = "BRC",
                          Destino = "SCL",
                          Valor = 5.00m
                      },
                       new AeroportoRotas
                       {
                           Origem = "GRU",
                           Destino = "CDG",
                           Valor = 75.00m
                       },
                       new AeroportoRotas
                       {
                           Origem = "GRU",
                           Destino = "SCL",
                           Valor = 20.00m
                       },
                       new AeroportoRotas
                       {
                           Origem = "GRU",
                           Destino = "ORL",
                           Valor = 56.00m
                       },
                        new AeroportoRotas
                        {
                            Origem = "ORL",
                            Destino = "CDG",
                            Valor = 5.00m
                        },
                        new AeroportoRotas
                        {
                            Origem = "SCL",
                            Destino = "ORL",
                            Valor = 20.00m
                        });

                    context.SaveChanges();
                }
            }
        }
    }
}
