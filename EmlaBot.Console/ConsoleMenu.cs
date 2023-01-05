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

        public async Task Process()
        {
            System.Console.WriteLine("Welcome to Jenna's EmlaBot demo.");
            System.Console.WriteLine("Who is your victim today?");
            var wearer = GetApiToken();

            var victim = await _emlaLock.GetInfo(wearer);
            System.Console.WriteLine($"Add what do you want to do to {victim.User.UserName}?");

            MenuOption option;
            do
            {
                option = PrintMenu();
                TimeSpan duration;
                switch (option)
                {
                    case MenuOption.Info:
                        var info = await _emlaLock.GetInfo(wearer);
                        PrintInfo(info);
                        break;

                    case MenuOption.Add:
                        duration = GetTimeSpan();
                        await _emlaLock.AddTime(wearer, duration, "");
                        break;

                    case MenuOption.AddMaximum:
                        duration = GetTimeSpan();
                        await _emlaLock.AddMaximumTime(wearer, duration);
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

        private static void PrintInfo(InfoResponse infoResponse)
        {
            System.Console.WriteLine(infoResponse.User.UserName);
        }

        private static TimeSpan GetTimeSpan()
        {
            System.Console.WriteLine("Please enter the duration (number of seconds until I get around to parsing time strings):");

            var option = System.Console.ReadLine();

            return int.TryParse(option, out int seconds)
                ? new TimeSpan(0, 0, seconds)
                : GetTimeSpan();
        }

        private static MenuOption PrintMenu()
        {
            // We'll probably want to throw up a little menu
            System.Console.WriteLine($"{MenuOption.None:D}: Exit.");
            System.Console.WriteLine($"{MenuOption.Info:D}: Get Info.");
            System.Console.WriteLine($"{MenuOption.Add:D}: Add time.");
            System.Console.WriteLine($"{MenuOption.AddMaximum:D}: Add max time.");
            // Add more here as desired/required

            var option = System.Console.ReadLine();
            return int.TryParse(option, out int result)
                ? (MenuOption)result
                : PrintMenu();
        }

        private enum MenuOption
        {
            None,
            Info,
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