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

                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome {admin.Username}");
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Blue, "------------");
                
                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Main Menu:");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Owner Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - DrugStore Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Druggist Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - Drug Menu");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");

                     
                    

                    ConsoleHelper.WriteTextWithColor(ConsoleColor.DarkBlue, "Select Options:");
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
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Main Menu");
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, " - Select Options");
                            number = Console.ReadLine();

                            result = int.TryParse(number, out selectedNumber);

                            if (selectedNumber >= 0 && selectedNumber <= 4)
                            {
                                switch (selectedNumber)
                                {
                                    case (int)OwnerOptions.CreateOnwer:
                                        _ownerController.CreateOnwer();
                                        break;
                                    case (int)OwnerOptions.UpdateOnwer:
                                        _ownerController.UpdateOwner();
                                        break ;
                                    case (int)OwnerOptions.GetAllOnwer:
                                        _ownerController.GetAll();
                                        break;
                                    case (int)OwnerOptions.DeleteOnwer:
                                        _ownerController.DeleteOwner();
                                        break ;
                                    case (int)OwnerOptions.Exit:
                                        _ownerController.ExitOnwer();
                                        break;
                                        break;


                                }
                            }
                            else
                            {
                                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please enter correct variant");
                                
                            }
                        }
                    }
                }
            }
        }
    }
}