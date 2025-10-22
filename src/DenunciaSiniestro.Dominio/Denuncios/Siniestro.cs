using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Siniestro
    {
        public string Ubicacion { get; set; } = default!;
        public DateTime Fecha { get; set; }
        public string RelatoAccidente { get; set; } = default!;
        public string NumeroPartePolicial { get; set; } = default!;
        public Siniestro() { }
        public Siniestro(string ubicacion, DateTime fecha, string relatoAccidente, string numeroPartePolicial) { }

        public static Siniestro Crear(
            string ubicacion,
            DateTime fecha,
            string relatoAccidente,
            string numeroPartePolicial
            )
        {
            return new Siniestro(
                ubicacion,
                fecha,
                relatoAccidente,
                numeroPartePolicial
                );
        }
    }
}
