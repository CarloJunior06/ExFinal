using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExFinal.factory;
using ExFinal.models;
namespace ExFinal.reader
{
    public class CSVReader
    {
        private string _filePath;
        private BasePizzaFactory _basePizzaFactory = new BasePizzaFactory();
        private ImpastoFactory _impastoFactory = new ImpastoFactory();
        private AggiunteFactory _aggiunteFactory = new AggiunteFactory();
        public CSVReader(string filePath)
        {
            _filePath = filePath;
        }
        public List<OrdinePizza> ReadCSV()
        {
            List<OrdinePizza> ordini = new List<OrdinePizza>();
            try
            {
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    int lineNumber = 0;
                    string firstLine = reader.ReadLine();
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        lineNumber++;   
                        string[] parts = line.Split(';');
                        BasePizza basePizza = _basePizzaFactory.CreateBasePizza(parts[0]);
                        Impasto impasto = _impastoFactory.CreateImpasto(parts[1]);
                        List<Aggiunte> aggiunte = parts[2].Split(',')
                                                           .Select(nome => nome.Trim())
                                                           .Select(nome => _aggiunteFactory.CreateAggiunta(nome))
                                                           .ToList();                            ;                                                  
                        OrdinePizza ordine = new OrdinePizza()
                        {
                            BasePizza = basePizza,
                            Impasto = impasto,
                            Aggiunte = aggiunte                           
                        };
                        ordini.Add(ordine);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore durante la lettura del file CSV: {ex.Message}");
            }
            return ordini;
        }
    }
}
 