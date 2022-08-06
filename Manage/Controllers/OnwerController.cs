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
        private OwnerRepository _ownerRepository;

        public OnwerController()
        {
            _ownerRepository = new OwnerRepository();
        }

        #region CreateOnwer
        public void CreateOnwer()
        {
           Name: ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Onwer Name:");
            string name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Magenta, "Enter Onwer Surname:");
                string surname = Console.ReadLine();

                var onwer = new Owner
                {
                    Name = name,
                    Surname = surname,
                };
                _ownerRepository.Create(onwer);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, $"Name: {name}, Surname: {surname} ");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Add a number:");
                goto Name;
            }

        }
        #endregion

        #region UpdateOwner
        public void UpdateOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
             ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owner:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
                }

             ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Owner Id");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        string oldName = owner.Name;
                        string oldSurname = owner.Surname;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter new owner name:");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please enter new owner surname:");
                        string newSurname = Console.ReadLine();

                        var newOwner = new Owner
                        {
                            Id = owner.Id,
                            Name = newName,
                            Surname = newSurname,
                        };
                        _ownerRepository.Update(newOwner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldName} OldSurname:{oldSurname}, Owner Successfully Update:Id:{newOwner.Id}  NewName:{newOwner.Name} NewSurname:{newOwner.Surname}  ");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
                        
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Id");
                    
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }


        }
        #endregion

        #region DeleteOwner
        public void DeleteOwner()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
             ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owners:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
                }
             ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Owner Id:");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _ownerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        _ownerRepository.Delete(owner);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{id} Name:{owner.Name} Surname:{owner.Surname} - This  owner is deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Owner doesn't exist");
                        
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }
        #endregion

        #region GetAll
        public void GetAll()
        {
            var owners = _ownerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owner:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname}");
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any owner");
            }
        }
        #endregion
    }
}
