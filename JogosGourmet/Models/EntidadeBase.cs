using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JogosGourmet.Models
{
    public abstract class EntidadeBase
    {

        Guid _Id;

        public EntidadeBase()
        {
            _Id = Guid.NewGuid();
        }

        public virtual Guid Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }
    }
}
