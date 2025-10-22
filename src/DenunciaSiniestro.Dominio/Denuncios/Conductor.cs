using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Conductor
    {
        public string Nombre { get; set; } = default!;
        public string Rut { get; set; } = default!;

        public Conductor() { }
        
        public Conductor(string nombre, string rut) { 
            Nombre = nombre;
            Rut = rut;
        }

        public static Conductor Crear(
            string nombre,
            string rut

            )
        {
            return new Conductor(
                nombre,
                rut
                );
        }
    }
}
