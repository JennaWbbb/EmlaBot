using EmlaBot.Models;
using EmlaBot.Services;

namespace EmlaBot.Console
{
    /// <summary>
    /// Just meant as a bit of a demo of calling the API
    /// </summary>
    public class ConsoleMenu
    {
        private readonly IEmloaLock _emlaLock;

        public ConsoleMenu(IEmloaLock emloaLock)
        {
            _emlaLock = emloaLock;
        }

        public void Process()
        {
            System.Console.WriteLine("Welcome to Jenna's EmlaBot demo.");
            System.Console.WriteLine("Who is your victim today?");
            var wearer = GetApiToken();

            MenuOption option;
            do
            {
                option = PrintMenu();
                switch (option)
                {
                    case MenuOption.Add:
                        var duration = GetTimeSpan();
                        _emlaLock.AddTime(wearer, duration, "");
                        break;
                }
            }
            while (option != MenuOption.None);

            System.Console.WriteLine("Until next time 😘");
        }

        private static IApiToken GetApiToken()
        {
            var token = new ApiToken();
            System.Console.WriteLine("Please enter the user id:");
            token.UserId = System.Console.ReadLine();
            System.Console.WriteLine("Please enter the API key:");
            token.ApiKey = System.Console.ReadLine();
            return token;
        }

        private static TimeSpan GetTimeSpan()
        {
            System.Console.WriteLine("Please enter the duration (number of seconds until I get around to parsing time strings):");
            int seconds = 0;
            return new TimeSpan(0, 0, seconds);
        }

        private static MenuOption PrintMenu()
        {
            // We'll probably want to throw up a little menu
            System.Console.WriteLine($"{MenuOption.None:D}: Exit.");
            System.Console.WriteLine($"{MenuOption.Add:D}: Add time.");
            // TODO: Rest here
            return MenuOption.None;
        }

        private enum MenuOption
        {
            None,
            Add,
            Subtract,
            AddRandom,
            SubtractRandom,
            AddMinimum,
            SubtractMinimum,
            AddMinimumRandom,
            SubtractMinimumRandom,
            AddMaximum,
            SubtractMaximum,
            AddMaximumRandom,
            SubtractMaximumRandom,
            AddRequirements,
            SubtractRequirements,
            AddRequirementsRandom,
            SubtractRequirementsRandom,
        }
    }
}