﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    static class DbContext
    {
        static DbContext()
        {
            Drugs = new List<Drug>();
            Druggists = new List<Druggist>();
            Drugstores = new List<Drugstore>();
            Onwers = new List<Onwer>();
            Admins = new List<Admin>();
        }
        public static List<Admin> Admins { get; set; }
        public static List<Onwer> Onwers { get; set; }
        public static List<Drugstore> Drusgstores { get; set; }
        public static List<Druggist> Druggists { get; set; }
        public static List<Drugstore> Drugstores { get; }
        public static List<Drug> Drugs { get; set; }

        

        
    }
}
