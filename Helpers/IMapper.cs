using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCodeCamp.Helpers
{
    public interface IMapper <out T, in TU>
    {
        public IEnumerable<T> MapMultiple(IEnumerable<TU> results);

        public T MapSingle(TU result);
    }
}
