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

                Console.WriteLine(e.Message);
                return entity;
            }

        }

        public void Delete(Drugstore entity)
        {
            try
            {
                DbContext.DrugStores.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(Drugstore entity)
        {
            try
            {
                var drugstore = DbContext.DrugStores.Find(g => g.Id == entity.Id);
                if (drugstore != null)
                {
                    var drugstore = DbContext.DrugStores.Find(d => d.Id == entity.Id);
                    drugstore.Name = entity.Name;
                    drugstore.Adress = entity.Adress;
                    drugstore.ContactNumber = entity.ContactNumber;
                    drugstore.Onwer = entity.Onwer;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Drugstore Get(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.DrugStores[0];
                }
                else
                {
                    return DbContext.DrugStores.Find(filter);
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Drugstore> GetAll(Predicate<Drugstore> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.DrugStores;
                }
                else
                {
                    return DbContext.DrugStores.FindAll(filter);
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
