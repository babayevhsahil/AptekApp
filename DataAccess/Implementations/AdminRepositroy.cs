﻿using Core.Entities;
using DataAccess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class AdminRepositroy : IRepository<Admin>
    {
        private static int id;

        public Admin Create(Admin entity)
        {
            id++;
            entity.Id = id;
            try
            {
                DbContext.Admins.Add(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return entity;
        }

        public void Delete(Admin entity)
        {
            try
            {
                DbContext.Admins.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong");
            }
            DbContext.Admins.Remove(entity);
        }

        public void Update(Admin entity)
        {
            try
            {
                var admin = DbContext.Admins.Find(g => g.Id == entity.Id);
                if (admin != null)
                {
                    admin.Username = entity.Username;
                    admin.Password = entity.Password;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("something went wrong");
            }

        }
        public Admin Get(Predicate<Admin> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Admins[0];
                }
                else
                {
                    return DbContext.Admins.Find(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }

        public List<Admin> GetAll(Predicate<Admin> filter = null)
        {
            try
            {
                if (filter == null)
                {
                    return DbContext.Admins;
                }
                else
                {
                    return DbContext.Admins.FindAll(filter);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong");
                return null;
            }
        }
    }
}
