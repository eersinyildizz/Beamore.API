using Beamore.DAL.Contents;
using Beamore.DAL.Contents.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Beamore.DAL.Repositories
{
    public class UserRepo : IRepository<User>
    {
        private DataContext db = new DataContext();
        public User add(User entity)
        {
            var result = db.Users.Add(entity);
            return result;
        }

        public bool Delete(User entity)
        {
            User result = db.Users.Remove(entity);
            if (result != null)
                return true;
            return false;
        }

        public List<User> FindByExxpression(Expression<Func<User, bool>> predicate)
        {
            List<User> result = db.Users.Where(predicate).ToList();
            return result;
        }
        
        public User FindById(int id)
        {
            User result = db.Users.SingleOrDefault(p => p.Id == id);
            return result;
        }

        public List<User> getAll()
        {
            List<User> result = db.Users.ToList();
            return result;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public User update(User entity)
        {
            db.Users.Attach(entity);
            var entry = db.Entry(entity);
            entry.State = EntityState.Modified;
            return entity;
        }
        

        public User FindByExpBySingle(Expression<Func<User, bool>> predicate)
        {
            User result = db.Users.SingleOrDefault(predicate);
            return result;
        }
    }
}
