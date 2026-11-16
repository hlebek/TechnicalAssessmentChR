using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalAssessmentChR
{
    public static class ExampleApp
    {
        private static string accountName = "ABC";
        private static float totalAssetsValue = 100000f;
        private static Dictionary<Asset, DataForAsset> assets = new Dictionary<Asset, DataForAsset> {
            { new Asset("IBM", 150f), new DataForAsset(20f, 10f) },
            { new Asset("MSFT", 90f), new DataForAsset(20f, 20f) },
            { new Asset("ORCL", 220f), new DataForAsset(20f, 30f) },
            { new Asset("AAPL", 450f), new DataForAsset(20f, 20f) },
            { new Asset("HD", 70f), new DataForAsset(20f, 20f) },
        };

        private static AccountData account = new AccountData(accountName, totalAssetsValue, assets);
        private static List<string> MenuOptions = new List<string> {
            "1. Print Account Data",
            "2. Update Asset Unit Price",
            "3. Update Total Assets Value",
            "4. Exit" };

        private static int selectedOption = 0;

        public static void PrintMenu()
        {
            Console.WriteLine("Menu:");

            for (int i = 0; i < MenuOptions.Count; i++)
            {
                if (i == selectedOption)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine(MenuOptions[i]);
            }
        }

        public static void UpdateMenu(int oldPosition, int newPosition)
        {
            Console.SetCursorPosition(0, oldPosition + 1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(MenuOptions[oldPosition]);

            Console.SetCursorPosition(0, newPosition + 1);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(MenuOptions[newPosition]);
        }

        public static void WaitForInput()
        {
            int oldPosition = selectedOption;
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedOption > 0)
                    {
                        selectedOption--;
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (selectedOption < (MenuOptions.Count - 1))
                    {
                        selectedOption++;
                    }
                    break;

                case ConsoleKey.Enter:
                    SelectOption();
                    return;

                default:
                    break;
            }

            UpdateMenu(oldPosition, selectedOption);
        }

        private static void SelectOption()
        {
            switch(selectedOption)
            {
                case 0:
                    PrintAccountData();
                    break;
                case 1:
                    UpdateAssetUnitPrice();
                    break;
                case 2:
                    UpdateTotalAssetsValue();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
    }
}
