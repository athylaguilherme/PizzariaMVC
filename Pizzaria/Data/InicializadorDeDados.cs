
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Pizzaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizzaria.Data
{
    public class InicializadorDeDados
    {
        public static void Inicializar(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var context = serviceScope
                    .ServiceProvider
                    .GetService<PizzariaDbContext>();

                context.Database.EnsureCreated();

           

                if (!context.Sabores.Any())
                {
                    context.Sabores.AddRange(new List<Sabor>()
                    {
                        new Sabor("Mussarela","https://static.clubeextra.com.br/img/uploads/1/0/583000.jpg"),
                        new Sabor("Calabresa","https://static.clubeextra.com.br/img/uploads/1/0/583000.jpg"),
                        new Sabor("Atum", "https://assets.instabuy.com.br/ib.item.image.big/b-6c422d7f69e344e4b17fb19e5596ace1.png")


                    });
                }

                if (!context.Tamanhos.Any())
                {
                    context.Tamanhos.AddRange(new List<Tamanho>()
                    {
                        new Tamanho("Pequeno"),
                        new Tamanho("Médio"),
                        new Tamanho("Grande")
     
                    });
                }

                if (!context.Pizzas.Any())
                {
                    context.Pizzas.AddRange(new List<Pizza>()
                    {
                        new Pizza("Mussarela","https://www.anamariabrogui.com.br/assets/uploads/receitas/fotos/usuario-1932-5a1b7911dfda6e3c351c30de564da267.jpg",30,1),
                        new Pizza("Calabresa","https://www.sabornamesa.com.br/media/k2/items/cache/513d7a0ab11e38f7bd117d760146fed3_L.jpg",30,2),
                        new Pizza("Atum","https://www.comidaereceitas.com.br/img/sizeswp/1200x675/2015/03/pizza_atum_especial.jpg", 27, 3)
                    });
                }

                if (!context.PizzasSabores.Any())
                {
                    context.PizzasSabores.AddRange(new List<PizzaSabor>()
                    {
                        new PizzaSabor(1, 1),
                        new PizzaSabor(2, 2),
                        new PizzaSabor(3, 3),
                  
                    });
                }
            }
        }
    }
}
