using Core.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Druggist : IEntity
        // eczaci
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public byte Age { get; set; }

        public double Experience  { get; set; }

        public Drugstore Drugstore { get; set; } 

    }
}
