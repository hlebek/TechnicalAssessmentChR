using TechnicalAssessmentChR;

internal class Program
{
    static void Main(string[] args)
    {
        ExampleApp.PrintMenu();

        while (true)
        {
            ExampleApp.WaitForInput(ExampleApp.MenuOptions);
        }
    }
}
