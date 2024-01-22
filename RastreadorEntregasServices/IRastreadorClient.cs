using RastreadorEntregasEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RastreadorEntregasServices
{
    public interface IRastreadorClient
    {
        Task<ViagemMilkrunResponse> Post(int viagem);
    }
}
