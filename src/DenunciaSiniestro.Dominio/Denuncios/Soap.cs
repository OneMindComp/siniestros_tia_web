namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Soap
    {
        public Vehiculo Vehiculo { get; private set; } = default!;
        public Denunciante Denunciante { get; private set; } = default!;
        public Conductor Conductor { get; private set; } = default!;
        public Lesionado Lesionado { get; private set; } = default!;
        public Siniestro Siniestro { get; private set; } = default!;

		private Soap() { }

		private Soap(Vehiculo vehiculo, Denunciante denunciante, Conductor conductor, Lesionado lesionado, Siniestro siniestro) {
            Vehiculo = vehiculo;
            Denunciante = denunciante;
            Conductor = conductor;
            Lesionado = lesionado;
            Siniestro = siniestro;
        }

        public static Soap Crear(
            Vehiculo vehiculo,
            Denunciante denunciante,
            Conductor conductor,
            Lesionado lesionado,
            Siniestro siniestro
            )
        {
            return new Soap(
                vehiculo,
                denunciante,
                conductor,
                lesionado,
                siniestro
                );
        }
    }
}
