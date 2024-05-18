using ExFinal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExFinal.factory
{
    public class AggiunteFactory
    {
        public Aggiunte CreateAggiunta(string nome)
        {
            switch (nome)
            {
                case "Prosciutto cotto":
                    return new Aggiunte { Nome = nome, Prezzo = 1.0f };
                case "Funghi":
                    return new Aggiunte { Nome = nome, Prezzo = 2.0f };
                case "Prosciutto crudo":
                    return new Aggiunte { Nome = nome, Prezzo = 2.0f };
                case "Ananas":
                    return new Aggiunte { Nome = nome, Prezzo = 0.0f }; 
                default:
                    throw new ArgumentException("prodotto non riconosciuto");
            }
        }
    }

}
