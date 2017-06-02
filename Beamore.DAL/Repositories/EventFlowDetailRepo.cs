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
    public class EventFlowDetailRepo : IRepository<EvenFlowDetail>
    {
        private DataContext db = new DataContext();
        public EvenFlowDetail add(EvenFlowDetail entity)
        {
            var result = db.EvenFlowDetails.Add(entity);
            return result;
        }

        public bool Delete(EvenFlowDetail entity)
        {
            throw new NotImplementedException();
        }

        public EvenFlowDetail FindByExpBySingle(Expression<Func<EvenFlowDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<EvenFlowDetail> FindByExxpression(Expression<Func<EvenFlowDetail, bool>> predicate)
        {
            List<EvenFlowDetail> result = db.EvenFlowDetails.Where(predicate).ToList();
            return result;
        }

        public EvenFlowDetail FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<EvenFlowDetail> getAll()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public EvenFlowDetail update(EvenFlowDetail entity)
        {
            db.EvenFlowDetails.Attach(entity);
            var entry = db.Entry(entity);
            entry.State = EntityState.Modified;
            return entity;
        }
    }
}
