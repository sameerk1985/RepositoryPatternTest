using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class Candidate<T> : IStoreable<T> where T : IComparable
    {
        public T Id { get; set; }
    }
}
