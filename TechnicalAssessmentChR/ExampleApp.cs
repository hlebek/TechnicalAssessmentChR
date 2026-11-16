using System;
using System.Collections.Generic;
using System.Text;

namespace TechnicalAssessmentChR
{
    public static class ExampleApp
    {

        #region Properties

        public readonly static List<string> MenuOptions = new List<string> {
            "1. Print Account Data",
            "2. Update Asset Unit Price",
            "3. Update Total Assets Value",
            "4. Exit" };

        private static string accountName = "ABC";
        private static float totalAssetsValue = 100000f;

        private static int selectedOption = 0;
        private static int maxSelectedOption = MenuOptions.Count - 1;
        private static Dictionary<Asset, DataForAsset> assets = new Dictionary<Asset, DataForAsset> {
            { new Asset("IBM", 150f), new DataForAsset(20f, 10f) },
            { new Asset("MSFT", 90f), new DataForAsset(20f, 20f) },
            { new Asset("ORCL", 220f), new DataForAsset(20f, 30f) },
            { new Asset("AAPL", 450f), new DataForAsset(20f, 20f) },
            { new Asset("HD", 70f), new DataForAsset(20f, 20f) },
        };
        private static AccountData account = new AccountData(accountName, totalAssetsValue, assets);

        private static List<Action> currActions = new List<Action>();

        #endregion

        #region Public Methods

        public static void PrintMenu()
        {
            selectedOption = 0;
            maxSelectedOption = MenuOptions.Count - 1;
            currActions = new List<Action> {
                PrintAccountData,
                UpdateAssetUnitPrice,
                UpdateTotalAssetsValue,
                () => Environment.Exit(0) };

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
                    SelectOption(currActions);
                    return;

                default:
                    break;
            }
        }

        #endregion

        #region Private Methods

        private static void UpdateMenuLine(int Position, string lineValue, ConsoleColor color)
        {
            Console.SetCursorPosition(0, Position + 1);
            Console.BackgroundColor = color;
            Console.Write(lineValue);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        private static void SelectOption(List<Action> actions)
        {
            actions[selectedOption]();
        }

        private static void PrintAccountData()
        {
            int accountAssetLength = account.TotalAssetsValue.ToString().Length;

            Console.Clear();
            Console.WriteLine($"Account Name: {account.AccountName.PadRight(accountAssetLength)}");
            Console.WriteLine($"Total Account Assets: {account.TotalAssetsValue.ToString().PadRight(accountAssetLength)}");
            Console.WriteLine($"\n| Asset Security | Unit Price | Variance |   Output   |");

            foreach (var asset in account.Assets)
            {
                float output = asset.Value.GetOutput(account.TotalAssetsValue, asset.Key);
                Console.WriteLine($"| {asset.Key.AssetSecurity, -14} | {asset.Key.UnitPrice, 10} | {asset.Value.Variance, 8} | {output, 10:F3} |");
            }

            Console.WriteLine($"\nPress any key to go back");
            Console.ReadKey();
            PrintMenu();
        }

        private static void UpdateAssetUnitPrice()
        {
            string goBack = "<= Go back";
            List<string> assetNames = new List<string>();
            currActions = new List<Action>();
            Action helper = null;

            selectedOption = 0;
            maxSelectedOption = account.Assets.Count;

            Console.Clear();
            Console.WriteLine("Select an asset to update its unit price:");

            foreach (var asset in account.Assets)
            {
                if (assetNames.Count == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                }

                string line = $"Current Unit Price for {asset.Key.AssetSecurity,-5}: {asset.Key.UnitPrice,5}";

                assetNames.Add(line);
                Console.WriteLine(line);
                Console.BackgroundColor = ConsoleColor.Black;
                helper = () => ChangeUnitPrice(asset.Key);
                currActions.Add(helper);
            }

            Console.WriteLine(goBack);
            assetNames.Add(goBack);
            currActions.Add(() => PrintMenu());
            Console.SetCursorPosition(0, 0);

            while(currActions.Contains(helper))
            {
                WaitForInput(assetNames);
            }
        }

        private static void ChangeUnitPrice(Asset asset)
        {
            float newTotalAssetsValue = -1;
            bool isValidInput = false;

            Console.Clear();
            Console.WriteLine($"Enter new unit price for {asset.AssetSecurity}: ");

            while (!isValidInput)
            {
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

            asset.UpdateUnitPrice(newTotalAssetsValue);
            PrintMenu();
        }

        private static void UpdateTotalAssetsValue()
        {
            float newTotalAssetsValue = -1;
            bool isValidInput = false;

            Console.Clear();
            Console.WriteLine($"Current Total Assets Value: {account.TotalAssetsValue}");

            while (!isValidInput)
            {
                Console.Write("Enter new total assets value (empty to cancel): ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    PrintMenu();
                    return;
                }
                else if (float.TryParse(input, out newTotalAssetsValue) && newTotalAssetsValue >= 0)
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

        #endregion

    }
}
