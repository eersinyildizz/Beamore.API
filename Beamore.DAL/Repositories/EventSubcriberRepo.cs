using Beamore.DAL.Contents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Beamore.DAL.Contents;
using System.Data.Entity;

namespace Beamore.DAL.Repositories
{
    public class EventSubcriberRepo : IRepository<EventSubcriber>
    {
        private DataContext db = new DataContext();
        public EventSubcriber add(EventSubcriber entity)
        {
            db.EventSubcribers.Add(entity);
            return entity;
        }

        public bool Delete(EventSubcriber entity)
        {
            EventSubcriber result = db.EventSubcribers.Remove(entity);
            if (result != null)
                return true;
            return false;
        }

        public EventSubcriber FindByExpBySingle(Expression<Func<EventSubcriber, bool>> predicate)
        {
            EventSubcriber result = db.EventSubcribers.SingleOrDefault(predicate);
            return result; 
        }

        public List<EventSubcriber> FindByExxpression(Expression<Func<EventSubcriber, bool>> predicate)
        {
            List<EventSubcriber> result = db.EventSubcribers.Where(predicate).ToList();
            return result;
        }

        public EventSubcriber FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EventSubcriber> getAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public EventSubcriber update(EventSubcriber entity)
        {
            db.EventSubcribers.Attach(entity);
            var entry = db.Entry(entity);
            entry.State = EntityState.Modified;
            return entity;
        }
    }
}
