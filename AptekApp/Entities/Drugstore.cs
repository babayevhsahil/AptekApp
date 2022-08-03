using Core.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Drugstore : IEntity 
        //Aptek
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string ContactNumber { get; set; }

        public string Duriggists { get; set; }

        public string Drugs { get; set; }

        public string Onwer { get; set; }
    }
}
