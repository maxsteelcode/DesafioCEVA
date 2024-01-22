using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorEntregasEntities
{
    public class SincronizarCutOffResult
    {
        public object Acao { get; set; }
        public object Erro { get; set; }
        public bool ExecutouOK { get; set; }
        public List<Viagem> Viagem { get; set; }
    }
   
}
