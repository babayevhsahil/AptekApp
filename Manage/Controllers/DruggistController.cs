﻿using Core.Entities;
using Core.Helpers;
using DataAccess.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manage.Controllers
{
    public class DruggistController
    {
        private DruggistRepository _druggistRepository;
        private object newDruggist;
        private string surname;
        private byte age;
        private int id;
        private string experience;

        public DruggistController()
        {
            _druggistRepository = new DruggistRepository();

        }

        #region CreateDruggist
        public void CreateDruggist()
        {
        Name: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please Enter Druggist Name:");
            string name = Console.ReadLine();

            object? druggist = _druggistRepository.Get(d => d.Name.ToLower() == name.ToLower());
            if (druggist == null)
            {
            Surname: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Please Enter Druggist Surname:");
                string size = Console.ReadLine();
                string surname;
                byte age;
                int id;
                string experience;

                if (result)
                {
                    Druggist newDruggist = new Druggist
                    {
                        Id = id,
                        Name = name,
                        Surname = surname,
                        Age = age,
                        Experience = experience,
                        Drugstore = drugstore,
                    };

                    var createdDruggist = _druggistRepository.Create(newDruggist);
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{createdDruggist.Name} is successfully created with surname - {createdDruggist.Surname}, {createdDruggist.Age}, {createdDruggist.Experience}");
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct druggist surname");
                    goto Surname;
                }
            }

        }
       0
	{


	}

    }

    #endregion
}

