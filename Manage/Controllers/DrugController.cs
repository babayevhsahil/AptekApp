using Core.Helpers;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class DrugController
    {
        public void CreateDrug()
        {
            var drugstores = DrugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter Drug Name:");
                string name = Console.ReadLine();

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter Drug Price:");
                string price = Console.ReadLine();
                double drugPrice;
                bool result = double.TryParse(name, out drugPrice);

                if (result)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkCyan, "Enter Drug Count:");
                    string count = Console.ReadLine();
                    int drugCount;
                    result = int.TryParse(count, out drugCount);
                    if (result)
                    {
                        var drugs = _drugRepositroy.GetAll();
                    }

                }
            }
        }
    }
}
