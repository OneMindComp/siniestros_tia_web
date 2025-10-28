using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Lesionado
    {
        public string Nombre { get; private set; } = default!;
        public string Rut { get; private set; } = default!;
        public string Celular { get; private set; } = default!;
        public string Mail { get; private set; } = default!;

		private Lesionado() { }

		private Lesionado(string nombre, string rut, string celular, string mail) {
            Nombre = nombre;
            Rut = rut;
            Celular = celular;
            Mail = mail;
        }

        public static Lesionado Crear(
            string nombre,
            string rut,
            string celular,
            string mail

            )
        {
            return new Lesionado(
                nombre,
                rut,
                celular,
                mail
                );
        }
    }
}
