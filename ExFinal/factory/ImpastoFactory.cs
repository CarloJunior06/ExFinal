using ExFinal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExFinal.factory
{
    public class ImpastoFactory
    {
        public Impasto CreateImpasto(string nome)
        {
            switch (nome)
            {
                case "Normale":
                    return new Impasto { Nome = nome, Prezzo = 0.0f };
                case "Integrale":
                    return new Impasto { Nome = nome, Prezzo = 1.0f };
                default:
                    throw new ArgumentException("Tipo di impasto non valido");
            }
        }
    }

}
