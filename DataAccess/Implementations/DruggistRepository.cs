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
    public class DruggistRepository : IRepository<Druggist>
    {
        private static int id;

        public Druggist Create(Druggist entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Druggists.Add(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine("Something went wrong");
            }
            return entity;

        }

        public void Delete(Druggist entity)
        {
            try
            {
                DbContext.Druggists.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public void Update(Druggist entity)
        {
            try
            {
                var druggist = DbContext.Druggists.Find(g => g.Id == entity.Id);
                if (druggist != null)
                {
                    druggist.Name = entity.Name;
                    druggist.Surname = entity.Surname;
                    druggist.Age = entity.Age;
                    druggist.Experience = entity.Experience;
                    druggist.Drugstore = entity.Drugstore;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Druggist Get(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Druggists[0];
                }
                else
                {
                    return DbContext.Druggists.Find(filter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Druggist> GetAll(Predicate<Druggist> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Druggists;
                }
                else
                {
                    return DbContext.Druggists.FindAll(filter);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("Something went wrong");
                return null;
            }
        }
    }
}
