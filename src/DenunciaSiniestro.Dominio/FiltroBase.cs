using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenunciaSiniestro.Dominio
{
    public abstract class FiltroBase<TId> : IAggregateFilter
    {
        public TId? Id { get; set; }
    }
}
