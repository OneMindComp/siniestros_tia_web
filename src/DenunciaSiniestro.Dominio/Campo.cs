namespace DenunciaSiniestro.Dominio
{
    public class Campo
    {
        public string Nombre { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public TipoCampo Tipo { get; set; }
        public bool Requerido { get; set; }
        public List<Opcion> Opciones { get; set; } = new List<Opcion>();
    }
}
