using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Siniestro
    {
        public string Ubicacion { get; private set; } = default!;
        public DateTime Fecha { get; private set; }
        public string RelatoAccidente { get; private set; } = default!;
        public string NumeroPartePolicial { get; private set; } = default!;

		private Siniestro() { }

		private Siniestro(string ubicacion, DateTime fecha, string relatoAccidente, string numeroPartePolicial) {
            Ubicacion = ubicacion;
            Fecha = fecha;
            RelatoAccidente = relatoAccidente;
            NumeroPartePolicial = numeroPartePolicial;
        }

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
