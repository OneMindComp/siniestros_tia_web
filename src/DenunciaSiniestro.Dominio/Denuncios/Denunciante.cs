namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Denunciante
    {
        public string Nombre{ get; private set; } = default!;
        public string Apellidos{ get; private set; } = default!;
        public string Rut{ get; private set; } = default!;
        public string Celular { get; private set; } = default!;
        public string Mail { get; private set; } = default!;

        private Denunciante() { }

		private Denunciante(string nombre, string apellidos, string rut, string celular, string mail) {
            Nombre = nombre;
            Apellidos = apellidos;
            Rut = rut;
            Celular = celular;
            Mail = mail;
        }

        public static Denunciante Crear(
            string nombre,
            string apellidos,
            string rut,
            string celular,
            string mail

            )
        {
            return new Denunciante(
                nombre,
                apellidos,
                rut,
                celular,
                mail
                );
        }
    }
}
