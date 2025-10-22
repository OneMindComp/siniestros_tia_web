using DenunciaSiniestro.Infraestructura.Persistencia.Modelo;
using DenunciaSiniestro.Infraestructura.Persistencia.Seeds.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenunciaSiniestro.Infraestructura.Persistencia.Seeds
{
    internal class TipoDenuncioSeed : ISeed
    {
        public void Seed(ModelBuilder builder)
        {
            builder.Entity<TipoDenuncio>().HasData(
                new TipoDenuncio
                {
                    IdTipoDenuncio = 1,
                    Nombre = "Accidente de Tránsito",
                    // ... propiedades
                }
            );
        }
    }
}
