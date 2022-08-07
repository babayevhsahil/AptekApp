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

        public List<Druggist> Duriggists { get; set; }

        public List<Drug> Drugs { get; set; }

        public Owner Onwer { get; set; }
    }
}
