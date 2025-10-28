using DenunciaSiniestro.Aplicacion.Dtos.Request;

namespace DenunciaSiniestro.Aplicacion.Utils
{
    public static class ExtractorDatos
    {
        /// <summary>
        /// Convierte una colección de valores de una sección específica a un diccionario para fácil búsqueda.
        /// </summary>
        /// <param name="valoresSeccion">La colección de KeyValuePair de la sección.</param>
        /// <returns>Un diccionario con los nombres de las propiedades en minúsculas como claves y sus valores como strings.</returns>
        public static Dictionary<string, string> ConvertirADiccionario(
            IEnumerable<KeyValuePair<string, InputRequest>> valoresSeccion)
        {
            return valoresSeccion?
                .ToDictionary(
                    k => k.Key.ToLowerInvariant(),
                    v => v.Value?.Valor?.ToString() ?? string.Empty
                ) ?? new Dictionary<string, string>();
        }

        /// <summary>
        /// Crea un objeto T de un diccionario de valores, mapeando por nombre de propiedad.
        /// </summary>
        /// <typeparam name="T">El tipo de objeto a crear (e.g., Vehiculo, Denunciante).</typeparam>
        /// <param name="dict">El diccionario con los datos a mapear.</param>
        /// <param name="crearFunc">Función que toma la función GetValue y devuelve una instancia de T.</param>
        /// <returns>Una instancia del tipo T.</returns>
        public static T MapearObjeto<T>(
            Dictionary<string, string> dict,
            Func<Func<string, string>, T> crearFunc)
        {
            string GetValue(string name)
            {
                string searchKey = name.ToLowerInvariant();

                foreach (var kvp in dict)
                {
                    if (kvp.Key.ToLowerInvariant().Contains(searchKey))
                    {
                        return kvp.Value;
                    }
                }
                return string.Empty;
            }

            return crearFunc(GetValue);
        }
    }
}
