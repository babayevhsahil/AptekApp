﻿using Core.Entities;
using DataAccess.Base;
using DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class DrugRepositroy : IRepository <Drug>
    {
        private static int id;

        public Drug Create(Drug entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Drugs.Add(entity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return entity;

        }

        public void Delete(Drug entity)
        {
            try
            {
                DbContext.Drugs.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Update(Drug entity)
        {
            try
            {
                var drug = DbContext.Drugs.Find(g => g.Id == entity.Id);
                if (drug != null)
                {
                    drug.Name = entity.Name;
                    drug.Count = entity.Count;
                    drug.Drugstores = entity.Drugstores;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public Drug Get(Predicate<Drug> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugs[0];
                }
                else
                {
                    return DbContext.Drugs.Find(filter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Drug> GetAll(Predicate<Drug> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Drugs;
                }
                else
                {
                    return DbContext.Drugs.FindAll(filter);
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
