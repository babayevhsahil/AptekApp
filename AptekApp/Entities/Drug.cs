using Core.Abstarctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Drug : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Count { get; set; }

        public Drugstore Drugstores { get; set; }
    }
}
