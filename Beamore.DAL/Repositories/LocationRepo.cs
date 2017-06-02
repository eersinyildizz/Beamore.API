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
    public class LocationRepo : IRepository<Location>
    {
        private DataContext db = new DataContext();
        public Location add(Location entity)
        {
            db.Locations.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public bool Delete(Location entity)
        {
            throw new NotImplementedException();
        }

        public Location FindByExpBySingle(Expression<Func<Location, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Location> FindByExxpression(Expression<Func<Location, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Location FindById(int id)
        {
            return db.Locations.SingleOrDefault(p=>p.Id == id);

        }

        public List<Location> getAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Location update(Location entity)
        {
            throw new NotImplementedException();
        }
    }
}
