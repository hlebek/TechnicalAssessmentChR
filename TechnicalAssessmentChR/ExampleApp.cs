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
        public readonly static List<string> MenuOptions = new List<string> {
            "1. Print Account Data",
            "2. Update Asset Unit Price",
            "3. Update Total Assets Value",
            "4. Exit" };

        private static int selectedOption = 0;
        private static int maxSelectedOption = MenuOptions.Count - 1;

        public static void PrintMenu()
        {
            selectedOption = 0;
            maxSelectedOption = MenuOptions.Count - 1;
            Console.Clear();
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

        private static void UpdateMenuLine(int Position, string lineValue, ConsoleColor color)
        {
            Console.SetCursorPosition(0, Position + 1);
            Console.BackgroundColor = color;
            Console.Write(lineValue);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void WaitForInput(List<string> options)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            maxSelectedOption = options.Count - 1;

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (selectedOption > 0)
                    {
                        UpdateMenuLine(selectedOption, options[selectedOption], ConsoleColor.Black);
                        selectedOption--;
                        UpdateMenuLine(selectedOption, options[selectedOption], ConsoleColor.DarkGray);
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (selectedOption < maxSelectedOption)
                    {
                        UpdateMenuLine(selectedOption, options[selectedOption], ConsoleColor.Black);
                        selectedOption++;
                        UpdateMenuLine(selectedOption, options[selectedOption], ConsoleColor.DarkGray);
                    }
                    break;

                case ConsoleKey.Enter:
                    SelectOption();
                    return;

                default:
                    break;
            }
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

        private static void PrintAccountData()
        {
            throw new NotImplementedException();
        }

        private static void UpdateAssetUnitPrice()
        {
            float newUnitPrice = -1;
            bool isValidInput = false;
            selectedOption = 0;
            maxSelectedOption = account.Assets.Count - 1;
            List<string> assetNames = new List<string>();

            Console.Clear();
            Console.WriteLine("Select an asset to update its unit price:");

            foreach (var asset in account.Assets)
            {
                if (assetNames.Count == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }

                string line = $"Current Unit Price for {asset.Key.AssetSecurity,-5}: {asset.Key.UnitPrice,5}";
                Console.WriteLine(line);
                assetNames.Add(line);
                Console.BackgroundColor = ConsoleColor.Black;
            }

            Console.SetCursorPosition(0, 0);
            while(true)
            WaitForInput(assetNames);
        }

        private static void UpdateTotalAssetsValue()
        {
            float newTotalAssetsValue = -1;
            bool isValidInput = false;
            Console.Clear();
            Console.WriteLine($"Current Total Assets Value: {account.TotalAssetsValue}");

            while (!isValidInput)
            {
                Console.Write("Enter new total assets value: ");
                string input = Console.ReadLine();

                if (float.TryParse(input, out newTotalAssetsValue) && newTotalAssetsValue >= 0)
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid non-negative number.");
                }
            }

            account.SetTotalAssetsValue(newTotalAssetsValue);
            PrintMenu();
        }
    }
}
