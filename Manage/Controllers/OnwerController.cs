using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class OnwerController
    {
        #region CreateOnwer
        public void CreateOnwer()
        {
           Name: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Onwer Name:");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Onwer Surname:");
                string surname = Console.ReadLine();

                var onwer = new Onwer
                {
                    Name = name,
                    Surname = surname,
                };
                _onwerRepository.Create(onwer);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Name: {name}, Surname: {surname} ");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Add a number:");
                goto Name;
            }

        }
        #endregion
    }
}
