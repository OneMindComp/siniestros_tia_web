using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Vehiculo
    {
        public string NumeroPoliza { get; private set; } = default!;
        public string Patente { get; private set; } = default!;
        public string NumeroMotor { get; private set; } = default!;

		private Vehiculo() { }

		private Vehiculo(string numeroPoliza, string patente, string numeroMotor) {
            NumeroPoliza = numeroPoliza;
            Patente = patente;
            NumeroMotor = numeroMotor;
        }

        public static Vehiculo Crear(
            string numeroPoliza,
            string patente,
            string numeroMotor

            )
        {
            return new Vehiculo(
                numeroPoliza,
                patente,
                numeroMotor
                );
        }
    }
}
