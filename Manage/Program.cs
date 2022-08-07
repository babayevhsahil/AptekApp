using Core.Constans;
using Core.Helpers;
using Manage.Controllers;
using System;

namespace Manage
{
    public class Program
    {
        public static void Main()
        {
            AdminController _adminController = new AdminController();
            DrugController _drugController = new DrugController();
            DruggistController _druggistController = new DruggistController();
            DrugstoreController _drugStoreController = new DrugstoreController();
            OnwerController _ownerController = new OnwerController();






        admin: var admin = _adminController.Authenticate();
            if (admin != null)
            {

                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, $"Welcome {admin.Username}");
                Console.WriteLine("-----------------------");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkMagenta, "Drgstore Applocation, Welcome");
                Console.WriteLine("-----------------------");

                while (true)
                {
                menu: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Main Menu:");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Owner Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - DrugStore Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Druggist Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Drug Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");

                    Console.WriteLine("-----------------------");


                   select: ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Select Number:");
                    string number = Console.ReadLine();
                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);

                    if (result)
                    {


                        if (selectedNumber == 1)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Creat Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Get All Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Delete Owner");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");


                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, " - Select Variant");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 4)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)OwnerOptions.CreateOwner:
                                        _ownerController.CreateOnwer();
                                        break;
                                    case (int)OwnerOptions.UpdateOwner:
                                        _ownerController.UpdateOwner();
                                        break;
                                    case (int)OwnerOptions.GetAllOwner:
                                        _ownerController.GetAll();
                                        break;
                                    case (int)OwnerOptions.DeleteOwner:
                                        _ownerController.DeleteOwner();
                                        break;
                                    case (int)OwnerOptions.Exit:
                                        goto menu;
                                        break;



                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct variant");
                                goto select;
                            }
                        }
                        else if (selectedNumber == 2)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Creat Drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Get All Drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Delete Drugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - GetOnwerDrugstore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");

                        selecet: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, " - Selected variant");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 6)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DrugstoreOptions.CreateDrugstore:
                                        _drugStoreController.CreateDrugStore();
                                        break;
                                    case (int)DrugstoreOptions.UpdateDrugstore:
                                        _drugStoreController.UpdateDrugstore();
                                        break;
                                    case (int)DrugstoreOptions.GetAllDrugstore:
                                        _drugStoreController.GetAll();
                                        break;
                                    case (int)DrugstoreOptions.DeleteDrugstore:
                                        _drugStoreController.DeleteDrugStore();
                                        break;
                                    case (int)DrugstoreOptions.GetOnwerDrugstore:
                                        break;
                                        goto selecet;
                                }

                                
                            }

                        }
                        else if (selectedNumber == 3)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Druggist ");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Druggist ");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - GetAll Druggist");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 -  Druggist Delete ");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - GetAllDruggist DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");

                        selecet: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, " - Selected variant");
                            number = Console.ReadLine();


                            result = int.TryParse(number, out selectedNumber);
                            if (selectedNumber >= 0 && selectedNumber <= 8)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)DruggistOptions.CreateDruggist:
                                        _druggistController.CreateDruggist();
                                        break;
                                    case (int)DruggistOptions.UpdateDruggist:
                                        _druggistController.UpdateDruggist();
                                        break;
                                    case (int)DruggistOptions.GetAllDruggist:
                                        _druggistController.GetAllDruggist();
                                        break;
                                    case (int)DruggistOptions.DeleteDruggist:
                                        _druggistController.DeleteDruggist();
                                        break;
                                    case (int)DruggistOptions.GetAllDruggistDrugStore:
                                        _druggistController.GetAllDruggistByDrugStore();
                                        break;
                                    case (int)DruggistOptions.Exit:
                                        goto selecet;
                                        break;
                                }
                            }
                        }
                        else if (selectedNumber == 3)
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Drug ");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Drug ");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Drug");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 -  GetAll Drug ");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - GetAll DrugStore");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");

                        selecet: ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, " - Selected variant");
                            number = Console.ReadLine();

                            switch (selectedNumber)
                            {
                                case (int)DrugOptions.CreateDrug:
                                    _drugController.CreateDrug();
                                    break;
                                case (int)DrugOptions.UpdateDrug:
                                    _drugController.UpadateDrug();
                                    break;
                                    case (int)DrugOptions.DeleteDrug:
                                    _drugController.DeleteDrug();
                                    break;
                                case (int)DrugOptions.GetAllDrug:
                                    _drugController.GetAllDrug();
                                    break;
                                case (int)DrugOptions.GetAllDrugStore:
                                    _drugController.GetAllDrugByStore();
                                    goto selecet;
                                    break;

                                    
                            }
                        }
                    }
                }
            }
        }
    }
}