namespace DenunciaSiniestro.Dominio.Denuncios
{
    public class Soap
    {
        public Vehiculo Vehiculo { get; set; } = default!;
        public Denunciante Denunciante { get; set; } = default!;
        public Conductor Conductor { get; set; } = default!;
        public Lesionado Lesionado { get; set; } = default!;
        public Siniestro Siniestro { get; set; } = default!;

        public Soap() { }
        public Soap(Vehiculo vehiculo, Denunciante denunciante, Conductor conductor, Lesionado lesionado, Siniestro siniestro) { }

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
