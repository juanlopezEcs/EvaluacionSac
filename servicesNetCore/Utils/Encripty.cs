using System.Security.Cryptography;

public static class encripy
{
        //Convertir string to hash
        public static string GenerateSHA256Hash(string entry)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir el string de entrada a un array de bytes
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(entry);

                // Aplicar el hash SHA-256
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convertir el array de bytes del hash a un string hexadecimal
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

}