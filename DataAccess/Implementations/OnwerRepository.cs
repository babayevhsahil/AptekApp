using Core.Entities;
using DataAccess.Base;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class OnwerRepository : IRepository<Onwer> 
    {
        private static int id;

        public Onwer Create(Onwer entity)
        {
            id++;
            entity.Id = id;
            DbContext.Onwers.Add(entity);
            return entity;
        }

        public void Delete(Onwer entiity)
        {
            DbContext.Onwers.Remove(entiity);
        }

        public void Update(Onwer entity)
        {
            var onwer = DbContext.Onwers.Find(g => g.Id == entity.Id);
            if (onwer != null)
            {
                onwer.Name = entity.Name;
                onwer.Surname = entity.Surname;
            }
        }

        public Onwer Get(Predicate<Onwer> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Onwers[0];
            }
            else
            {
                return DbContext.Onwers.Find(filter);
            }
        }

        public List<Onwer> GetAll(Predicate<Onwer> filter = null)
        {
            if (filter == null)
            {
                return DbContext.Onwers;
            }
            else
            {
                return DbContext.Onwers.FindAll(filter);
            }
        }
    }
}
