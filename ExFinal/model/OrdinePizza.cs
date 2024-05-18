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
    }
}
