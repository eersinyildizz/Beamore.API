using Beamore.DAL.Contents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Beamore.DAL.Contents;

namespace Beamore.DAL.Repositories
{
    public class EventRepo : IRepository<Event>
    {
        private DataContext db = new DataContext();
        public Event add(Event entity)
        {
            db.Events.Add(entity);
            return entity;
        }

        public bool Delete(Event entity)
        {
            throw new NotImplementedException();
        }

        public Event FindByExpBySingle(Expression<Func<Event, bool>> predicate)
        {
            var result = db.Events.SingleOrDefault(predicate);

            return result;
        }

        public List<Event> FindByExxpression(Expression<Func<Event, bool>> predicate)
        {
            List<Event> result = db.Events.Where(predicate).ToList();
            return result;
        }

        public Event FindById(int id)
        {
            Event result = db.Events.SingleOrDefault(p => p.Id == id);
            return result;
        }

        public List<Event> getAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Event update(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}
