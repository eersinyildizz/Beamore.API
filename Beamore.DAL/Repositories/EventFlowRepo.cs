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
    public class EventFlowRepo : IRepository<EventFlow>
    {
        private DataContext db = new DataContext();
        public EventFlow add(EventFlow entity)
        {
            var result = db.EventFlows.Add(entity);
            return result;
        }

        public bool Delete(EventFlow entity)
        {
            throw new NotImplementedException();
        }

        public EventFlow FindByExpBySingle(Expression<Func<EventFlow, bool>> predicate)
        {
            var result = db.EventFlows.SingleOrDefault(predicate);

            return result;
        }

        public List<EventFlow> FindByExxpression(Expression<Func<EventFlow, bool>> predicate)
        {
            var result = db.EventFlows.Where(predicate).ToList();
            
            return result;
        }

        public EventFlow FindById(int id)
        {
            EventFlow result = db.EventFlows.FirstOrDefault(p => p.EventId == id);
            return result;
        }

        public List<EventFlow> getAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public EventFlow update(EventFlow entity)
        {
            db.EventFlows.Attach(entity);
            var entry = db.Entry(entity);
            entry.State = EntityState.Modified;
            return entity;

        }

     

       
}
}
