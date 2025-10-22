namespace DenunciaSiniestro.Dominio
{
    public class Seccion
    {
        public string Nombre { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public List<Campo> Campos { get; set; } = new List<Campo>();
    }
}
