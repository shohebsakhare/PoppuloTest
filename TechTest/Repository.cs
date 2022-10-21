using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest
{
    public class Repository<T> : IRepository<T> where T : IStoreable
    {

        private List<T> lsStorage;

        public Repository()
        {
            lsStorage = new List<T>();
        }

        public IEnumerable<T> All()
        {
            try
            {
                return lsStorage;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Save(T item)
        {
            try
            {
                Delete(item.Id); // Remove existing data with same Id if existing
                lsStorage.Add(item);// Save new data
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(IComparable Id)
        {
            try
            {
                var itemToRemove = lsStorage.Find(MatchedId(Id));
                lsStorage.Remove(itemToRemove);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public T FindById(IComparable id)
        {
            try
            {
                return lsStorage.Find(MatchedId(id));
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private Predicate<T> MatchedId(IComparable id)
        {
            try
            {
                return match => match.Id.Equals(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
