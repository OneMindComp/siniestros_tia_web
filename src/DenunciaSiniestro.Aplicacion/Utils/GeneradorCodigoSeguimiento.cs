namespace DenunciaSiniestro.Aplicacion.Utils
{
    public static class GeneradorCodigoSeguimiento
    {
        public static string Generar()
        {
            // Ej: 20251023 + 3 letras + 3 numeros → "20251023-XKJ482"
            var datePart = DateTime.Now.ToString("yyyyMMdd");
            var randomPart = RandomString(3) + RandomNumber(3);
            return $"{datePart}-{randomPart}";
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string RandomNumber(int length)
        {
            const string digits = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(digits, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
