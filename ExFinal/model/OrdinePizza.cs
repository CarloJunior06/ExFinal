using ExFinal.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExFinal.models
{
    public class OrdinePizza
    {
        public BasePizza BasePizza { get; set; }
        public Impasto Impasto { get; set; }
        public List<Aggiunte> Aggiunte { get; set; }
        public int IdScontrino { get; set; }
        public static int _IdScontrino = 0;

        public  OrdinePizza() 
        {
            IdScontrino =  ++_IdScontrino;
        }
    }
}
