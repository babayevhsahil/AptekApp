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

        public Owner Create(Owner entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Owners.Add(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Onwer entiity)
        {
            try
            {
                DbContext.Owners.Remove(entity);
            }
            catch
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(Onwer entity)
        {
            try
            {
                var onwer = DbContext.Onwers.Find(g => g.Id == entity.Id);
                if (onwer != null)
                {
                    onwer.Name = entity.Name;
                    onwer.Surname = entity.Surname;
                }
            }
            catch (Exception e)
            {
              Console.WriteLine(e.Message);
            }
        }

        public Onwer Get(Predicate<Onwer> filter = null)
        {
            try
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Onwer> GetAll(Predicate<Onwer> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Owners;
                }
                else
                {
                    return DbContext.Owners.FindAll(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
