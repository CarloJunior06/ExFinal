using ExFinal.models;
using ExFinal.reader;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;

namespace ExFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=SdominoDatabase;User ID= Kvaraskhelia\\manue;Password=1926;SslMode=none;";

            string filePath = "ordini.csv";
            string fullPath = Path.GetFullPath(filePath);
            Console.WriteLine($"Percorso completo del file: {fullPath}");
            CSVReader reader = new CSVReader(filePath);
            List<OrdinePizza> ordini = reader.ReadCSV();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                foreach (var ordine in ordini)
                {
                    float prezzoTotale = ordine.BasePizza.Prezzo + ordine.Impasto.Prezzo + ordine.Aggiunte.Sum(a => a.Nome == "Ananas" ? 0.0f : a.Prezzo);
                    if (ordine.Aggiunte.Any(a => a.Nome == "Ananas"))
                    {
                        prezzoTotale = 0.0f;
                    }
                    string basePizza = ordine.BasePizza.Nome;
                    string impasto = ordine.Impasto.Nome;
                    string aggiunte = string.Join(", ", ordine.Aggiunte.Select(a => a.Nome));
                    int idScontrino = ordine.IdScontrino;
                    Console.WriteLine($"Base: {ordine.BasePizza.Nome}, Impasto: {ordine.Impasto.Nome}, Aggiunte: {string.Join(", ", ordine.Aggiunte.Select(a => a.Nome))}, ID Ordine: {ordine.IdScontrino}, Prezzo Totale: {prezzoTotale}");

                }

            }
        }
    }
}
 