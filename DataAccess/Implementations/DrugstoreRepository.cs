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
    public class DrugstoreRepository : IRepository<Drugstore>
    {
        private static int id;

        public Drugstore Create(Drugstore entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Drugstores.Add(entity);
                return entity;
            }
            catch (Exception e)
            {

                Console.WriteLine("Something went wrong");
                return entity;
            }

        }

        public void Delete(Drugstore entity)
        {
            try
            {
                DbContext.Drugstores.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public void Update(Drugstore entity)
        {
            try
            {
                var drugstore = DbContext.Drugstores.Find(g => g.Id == entity.Id);
                if (drugstore != null)
                {
                    var Drugstore = DbContext.Drugstores.Find(d => d.Id == entity.Id);
                    drugstore.Name = entity.Name;
                    drugstore.Adress = entity.Adress;
                    drugstore.ContactNumber = entity.ContactNumber;
                    drugstore.Onwer = entity.Onwer;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        public Drugstore Get(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugstores[0];
                }
                else
                {
                    return DbContext.Drugstores.Find(filter);
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Drugstore> GetAll(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugstores;
                }
                else
                {
                    return DbContext.Drugstores.FindAll(filter);
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
