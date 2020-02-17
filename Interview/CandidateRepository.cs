using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview
{
    public class CandidateRepository<T, I> : IRepository<T, I> where T : IStoreable<I> where I : IComparable
    {
        private readonly List<T> candidates;
        public CandidateRepository()
        {
            candidates = new List<T>();
        }

        public void Delete(I id)
        {
            var item = this.Get(id);

            if (item != null)
            {
                candidates.Remove(item);
            }
        }

        public T Get(I id)
        {
            return candidates.Find(c => c.Id.Equals(id));
        }

        public IEnumerable<T> GetAll()
        {
            return candidates;
        }

        public void Save(T item)
        {
            if(this.Get(item.Id) != null)
            {
                this.Delete(item.Id);
            }
            candidates.Add(item);
        }
    }
}
