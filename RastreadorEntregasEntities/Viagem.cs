using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorEntregasEntities
{
    public class Viagem
    {
        public string Code_5C { get; set; }
        public string Code_5P { get; set; }
        public List<string> Codes { get; set; }
        public string Fornecedor { get; set; }
        public List<string> Pedidos { get; set; }
    }
}
