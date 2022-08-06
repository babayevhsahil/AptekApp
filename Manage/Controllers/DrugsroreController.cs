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
    public class DrugstoreController
    {
        private DrugstoreRepository _drugstoreRepository;
        private OwnerRepository _onwerRepository;
        private DruggistRepository _druggistRepository;
        private DrugRepository _drugRepository;

        public DrugstoreController() 
        {
            _drugstoreRepository = new DrugstoreRepository();
            _onwerRepository = new OwnerRepository();
            _druggistRepository = new DruggistRepository();
            _drugRepository = new DrugRepository();
        }
        #region CreateDrugStore
        public void CreateDrugStore()
        {
            var owners = _onwerRepository.GetAll();
            if (owners.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drugstore Name:");
                string name = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drugstore Adress");
                string adress = Console.ReadLine();
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drugstore ContactNumber:");
                string contactNumber = Console.ReadLine();





             ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owner:");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname} ");
                }
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Owner Id:");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {

                    var owner = _onwerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        var drugstore = new Drugstore()
                        {
                            Name = name,
                            Adress = adress,
                            ContactNumber = contactNumber,
                            Onwer = owner,

                        };
                        _drugstoreRepository.Create(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Adress:{drugstore.Adress} ContactNumber:{drugstore.ContactNumber} Owner:{drugstore.Onwer.Name} DrugStore is successfully created");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Owner id doesn't exist");
                        
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    
                }





            }

            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please firstly create owner");
            }
        }
        #endregion

        #region UpdateDrugstore
        public void UpdateDrugstore()
        {
            var drugstores = _drugstoreRepository.GetAll();

            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adress} ContactNumber:{drugstore.ContactNumber} Owner:{drugstore.Onwer}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter DrugStore Id:");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        string oldname = drugstore.Name;
                        string oldadress = drugstore.Adress;
                        string oldcontactnumber = drugstore.ContactNumber;

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drugstore name:");
                        string newName = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drugstore adress:");
                        string newAdress = Console.ReadLine();
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drugstore contactnumber:");
                        string newContactName = Console.ReadLine();
                    owid: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drugstore owner Id:");
                        string newOwnerId = Console.ReadLine();
                        int newId;
                        result = int.TryParse(newOwnerId, out newId);
                        if (result)
                        {
                            var owner = _onwerRepository.Get(o => o.Id == id);
                            if (owner != null)
                            {
                                var newDrugstore = new Drugstore
                                {
                                    Id = drugstore.Id,
                                    Name = newName,
                                    Adress = newAdress,
                                    ContactNumber = newContactName,
                                    Onwer = owner,

                                };
                                _drugstoreRepository.Update(newDrugstore);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldname} OldAdress:{oldadress} OldContactNumber:{oldcontactnumber} Drugstore is successfully update: ID:{drugstore.Id} Name:{newDrugstore.Name} Adress:{newDrugstore.Adress} ContactNumber:{newDrugstore.ContactNumber} Owner:{owner} ");


                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");

                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct owner id");
                            goto owid;
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Id drugstore doesn't exist");
                        goto id;
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    goto id;
                }



            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }




        }

        #endregion

        #region DeleteDrugStore
        public void DeleteDrugStore()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adress} Owner:{drugstore.Onwer}");
                }
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter DrugStore Id:");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        _drugstoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Name:{drugstore.Name} Is Successfully Deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore doesn't exist");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format id");
                    
                }

            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any Drugstore");
            }

        }


        #endregion

        #region GetAll
        public void GetAll()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
             ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkRed, "All DrugStores:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adress}");
                }
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter DrugStore Id:");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugstoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        _drugstoreRepository.Delete(drugstore);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adress} is successfully deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Drugstore Id doesn't exist");
                        
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Id");
                    
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstore");
            }
        }

        #endregion

        #region GetAllDrugStoreByOwner
        public void GetAllDrugStoreByOwner()
        {
            var owners = _onwerRepository.GetAll();
            if (owners.Count > 0)
            {
             ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Owners");
                foreach (var owner in owners)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{owner.Id} Name:{owner.Name} Surname:{owner.Surname} DrugStores:{owner.Drugstores}");
                }
             ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter Owner Id:");
                string ownerId = Console.ReadLine();
                int id;
                bool result = int.TryParse(ownerId, out id);
                if (result)
                {
                    var owner = _onwerRepository.Get(o => o.Id == id);
                    if (owner != null)
                    {
                        var drugstores = _drugstoreRepository.GetAll(d => d.Onwer != null ? d.Onwer.Id == owner.Id : false);
                        if (drugstores.Count > 0)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "The DrugStores of Owner:");
                            foreach (var drugstore in drugstores)
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adress}");
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Owner has not Drugstore");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This owner doesn't exist");
                       
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter corred format id");
                    
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
