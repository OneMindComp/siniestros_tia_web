namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Denunciante
    {
        public string Nombre{ get; set; } = default!;
        public string Apellidos{ get; set; } = default!;
        public string Rut{ get; set; } = default!;
        public string Celular { get; set; } = default!;
        public string Mail { get; set; } = default!;
        public Denunciante() { }
        public Denunciante(string nombre, string apellidos, string rut, string celular, string mail) { }

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
