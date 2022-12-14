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
    public class DrugController
    {
        private DrugRepository _drugRepository;
        private DrugstoreRepository _drugStoreRepository;

        public DrugController()
        {
            _drugStoreRepository = new DrugstoreRepository();
            _drugRepository = new DrugRepository();
        }
        #region CreateDrug
        public void CreateDrug()
        {
            var drugStories = _drugStoreRepository.GetAll();

            if (drugStories.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Please Enter Drug Name:");
                string drugName = Console.ReadLine();
             ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Please Enter Drug Price:");
                string priceDrug = Console.ReadLine();
                double price;
                bool result = double.TryParse(priceDrug, out price);
                if (result)
                {


                 ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Please Enter Drug Count:");
                    string countDrug = Console.ReadLine();
                    int count;
                    result = int.TryParse(countDrug, out count);

                    if (result)
                    {

                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All DrugStories:");
                        foreach (var drugstore in drugStories)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, $"ID:{drugstore.Id}, Name:{drugstore.Name}, Adress:{drugstore.Adress}, ContactNumber:{drugstore.ContactNumber} ");
                        }
                     ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "Please Enter Drugstore ID");
                        string storeId = Console.ReadLine();
                        int id;
                        result = int.TryParse(storeId, out id);
                        if (result)
                        {
                            var drugStore = _drugStoreRepository.Get(d => d.Id == id);
                            if (drugStore != null)
                            {
                                var drug = new Drug
                                {
                                    Name = drugName,
                                    Price = price,
                                    Count = count,
                                    Drugstores = drugStore,
                                };
                                _drugRepository.Create(drug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{drugName}, Price:{priceDrug}, Count:{countDrug} Drugstore:{drug.Drugstores.Name}is successfully created drug");

                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This Id DrugStore is Empty");
                                
                            }


                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Id");
                            
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format drug count");
                       
                    }

                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format price");
                    
                }
            }
          
        }
        #endregion

        #region UpdateGroup
        public void UpadateDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugs:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} DrugStore:{drug.Drugstores.Name}");
                }
             ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Id:");
                string drugId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                        string oldname = drug.Name;
                        double oldprice = drug.Price;
                        int oldcount = drug.Count;
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drug name:");
                        string newName = Console.ReadLine();
                     ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drug Price:");
                        string newPrice = Console.ReadLine();
                        double price;
                        result = double.TryParse(newPrice, out price);
                        if (result)
                        {
                         ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter new drug count");
                            string newCount = Console.ReadLine();
                            int count;
                            result = int.TryParse(newCount, out count);
                            if (result)
                            {
                                var newDrug = new Drug
                                {
                                    Id = drug.Id,
                                    Name = newName,
                                    Price = price,
                                    Count = count,
                                };
                                _drugRepository.Update(newDrug);
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"OldName:{oldname} OldPrice:{oldprice} OldCount:{oldcount} is drug successfully update: Name:{newName} Price:{newPrice} Count:{newCount}");

                            }
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format count");
                            
                        }
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Price");
                        
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
                    }
                }
                else
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct format Id");
                    
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugs");
            }
        }
        #endregion

        #region DeleteGroup
        public void DeleteDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugs:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} DrugStore:{drug.Drugstores.Name}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Enter Drug Id:");
                string drugId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugId, out id);
                if (result)
                {
                    var drug = _drugRepository.Get(d => d.Id == id);
                    if (drug != null)
                    {
                        _drugRepository.Delete(drug);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Id{drug.Id} Name:{drug.Name} This drug is successfully deleted");
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drug doesn't exist");
                        goto all;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drug");
            }
        }
        #endregion

        #region GetAllGroup
        public void GetAllDrug()
        {
            var drugs = _drugRepository.GetAll();
            if (drugs.Count > 0)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All Drugs:");
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count} Drugstore:{drug.Drugstores.Name} ");
                }
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Not any drug");
            }
        }
        #endregion

        #region GetAllDrugstore
        public void GetAllDrugByStore()
        {
            var drugstores = _drugStoreRepository.GetAll();
            if (drugstores.Count > 0)
            {
            all: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "All drugstore:");
                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drugstore.Id} Name:{drugstore.Name} Adress:{drugstore.Adress} ContactNumber:{drugstore.ContactNumber}");
                }
            id: ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, "Please Enter DrugStore Id:");
                string drugstoreId = Console.ReadLine();
                int id;
                bool result = int.TryParse(drugstoreId, out id);
                if (result)
                {
                    var drugstore = _drugStoreRepository.Get(d => d.Id == id);
                    if (drugstore != null)
                    {
                        var drugs = _drugRepository.GetAll(d => d.Drugstores != null ? d.Drugstores.Id == drugstore.Id : false);
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "The drugs of drugsore:");
                        foreach (var drug in drugs)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Cyan, $"Id:{drug.Id} Name:{drug.Name} Price:{drug.Price} Count:{drug.Count}");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This drugstore doesn't exist");
                        goto all;
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
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "There is no any drugstores");
            }
        }
        #endregion


    }
}
