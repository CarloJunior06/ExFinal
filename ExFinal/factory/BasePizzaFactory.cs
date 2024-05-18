using ExFinal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExFinal.factory
{
    public class BasePizzaFactory
    {
        public BasePizza CreateBasePizza(string nome)
        {
            switch (nome)
            {
                case "Margherita":
                    return new BasePizza { Nome = nome, Prezzo = 7.0f };
                case "Bianca":
                    return new BasePizza { Nome = nome, Prezzo = 5.0f };
                case "Napoletana":
                    return new BasePizza { Nome = nome, Prezzo = 3.0f };
                default:
                    throw new ArgumentException("prodotto non riconosciuto");    
            }
        }
    }

}
