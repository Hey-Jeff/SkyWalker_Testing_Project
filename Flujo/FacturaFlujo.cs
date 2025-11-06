using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracciones.Interfaces.DA;
using Abstracciones.Interfaces.Flujo;

namespace Flujo
{
    public class FacturaFlujo : iFacturaFlujo
    {
        private readonly iFacturaFlujo _facturaDA;

        public FacturaFlujo(iFacturaFlujo facturaDA)
        {
            _facturaDA = facturaDA;
        }
    }
}
