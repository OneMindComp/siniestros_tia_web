namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Conductor
    {
        public string Nombre { get; private set; } = default!;
        public string Rut { get; private set; } = default!;

        private Conductor() { }

        private Conductor(string nombre, string rut) { 
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
