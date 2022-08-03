using Core.Constans;
using Core.Helpers;

namespace Manage
{
    public class Program
    {
        public void Main()
        {
            if (admin != null)
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Welcome, {admin.Username}");
                Console.WriteLine("---");

                while (true)
                {
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "1 - Create Druggist");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "2 - Update Druggist");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "3 - Delete Druggist");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "4 - All Druggists");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "5 - Get Druggist by name");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "0 - Exit");
                   
                    Console.WriteLine("---");
                    ConsoleHelper.WriteTextWithColor(ConsoleColor.Gray, "Select option");
                    string number = Console.ReadLine();

                    int selectedNumber;
                    bool result = int.TryParse(number, out selectedNumber);
                    if (result)
                    {
                        if (selectedNumber >= 0 && selectedNumber <= 16)
                        {

                            switch (selectedNumber)
                            {
                                case (int)Options.CreateDruggist:
                                    _groupController.CreateDruggist();
                                    break;
                                case (int)Options.UpdateDruggist:
                                    _groupController.UpdateDruggist();
                                    break;
                                case (int)Options.DeleteDruggist:
                                    _groupController.DeleteDruggist();
                                    break;
                                case (int)Options.AllDruggist:
                                    _groupController.AllDruggist();
                                    break;
                                case (int)Options.GetDruggistByName:
                                    _groupController.GetDruggistName();
                                    break;                              
                                case (int)Options.Exit:
                                    _groupController.Exit();
                                    return;
                            }
                        }
                        else
                        {
                            ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                        }
                    }
                    else
                    {
                        ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "Please, enter correct number");
                    }
                }
            }
        }
    }
}