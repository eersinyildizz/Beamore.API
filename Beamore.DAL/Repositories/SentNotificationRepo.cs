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
    public class SentNotificationRepo : IRepository<SentNotification>
    {
        private DataContext db = new DataContext();
        public SentNotification add(SentNotification entity)
        {
            var result = db.SentNotifications.Add(entity);
            return result;
        }

        public bool Delete(SentNotification entity)
        {
            throw new NotImplementedException();
        }

        public SentNotification FindByExpBySingle(Expression<Func<SentNotification, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<SentNotification> FindByExxpression(Expression<Func<SentNotification, bool>> predicate)
        {
            List<SentNotification> result = db.SentNotifications.Where(predicate).ToList();
            return result;
        }

        public SentNotification FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SentNotification> getAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public SentNotification update(SentNotification entity)
        {
            throw new NotImplementedException();
        }
    }
}
