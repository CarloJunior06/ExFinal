using ExFinal.models;
using ExFinal.reader;

namespace ExFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "ordini.csv";
            string fullPath = Path.GetFullPath(filePath);
            Console.WriteLine($"Percorso completo del file: {fullPath}");
            CSVReader reader = new CSVReader(filePath);
            List<OrdinePizza> ordini = reader.ReadCSV();

            foreach (var ordine in ordini)
            {
                float prezzoTotale = ordine.BasePizza.Prezzo + ordine.Impasto.Prezzo  + ordine.Aggiunte.Sum(a => a.Nome == "Ananas" ? 0.0f : a.Prezzo);
                if (ordine.Aggiunte.Any(a => a.Nome == "Ananas"))
                {
                    prezzoTotale = 0.0f;
                }
                Console.WriteLine($"Base: {ordine.BasePizza.Nome}, Impasto: {ordine.Impasto.Nome}, Aggiunte: {string.Join(", ", ordine.Aggiunte.Select(a => a.Nome))}, ID Ordine: {ordine.IdScontrino}, Prezzo Totale: {prezzoTotale}");
            }
        }
    }
}
