﻿using Core.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Onwer : IEntity
        // Aptekin sahibi
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public List <Drugstore> Drugstores { get; set; }

    }
}
