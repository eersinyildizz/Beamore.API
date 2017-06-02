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
    public class TempUserRepo : IRepository<TempUser>
    {
        private DataContext _db = new DataContext();
        public TempUser add(TempUser entity)
        {
           TempUser tUser =  _db.TempUsers.Add(entity);
            return tUser;
        }

        public bool Delete(TempUser entity)
        {
            
            TempUser result = _db.TempUsers.Remove(entity);
            if (result != null)
                return true;
            return false;
        }

        public TempUser FindByExpBySingle(Expression<Func<TempUser, bool>> predicate)
        {
            TempUser result = _db.TempUsers.SingleOrDefault(predicate);
            return result;
        }

        public List<TempUser> FindByExxpression(Expression<Func<TempUser, bool>> predicate)
        {
            List<TempUser> result = _db.TempUsers.Where(predicate).ToList();
            return result;
        }

        public TempUser FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<TempUser> getAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public TempUser update(TempUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
