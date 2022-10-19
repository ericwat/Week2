namespace RunMeOver;

public class Program
{
    // Menu items passed as messages
    private const int REGISTRATION = 1;
    private const int LOGIN = 2;
    private const int BOOK = 3;
    private const int EXIT = 9;
    
    // Data models
    private static User? _user;
    private static Account? _account;
    private static Booking? _booking; 

    // Services that perform most of the functionality
    private static readonly AccountService _accountService = new AccountService();
    private static readonly UserService _userService = new UserService(_accountService);
    private static readonly BookingService _rideService = new BookingService();
    
    public static void Main(string[] args)
    {
                    
        _user = new User();
        _account = new Account();
        _booking = new Booking();

        SetTitle();
        
        while (true)
        {
            ShowMainMenu();
            int mainMessage;
            bool couldParseMainMessage = int.TryParse(Console.ReadLine(), out mainMessage);
            Console.Clear();

            if (couldParseMainMessage)
            {
                switch (mainMessage)
                {
                    case REGISTRATION:
                        ShowRegistrationScreen();
                        break;
                    case LOGIN:
                        ShowLoginScreen();
                        break;
                    case BOOK:
                        ShowBookingScreen();
                        break;
                    case EXIT:
                        Environment.Exit(0);
                        break;
                    default:
                        ShowRetry();
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Sets the title of the app
    /// </summary>
    private static void SetTitle()
    {
        Console.WriteLine("Run Me Over - Book a ride");
    }
  
    /// <summary>
    /// Displays the main menu
    /// </summary>
    private static void ShowMainMenu()
    {
        Console.WriteLine("1. Create user account");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Book a ride");
        Console.WriteLine("9. Exit");
    }
    
    /// <summary>
    /// Displays the prompts for registering a new user in an account
    /// </summary>
    private static void ShowRegistrationScreen()
    {
        Console.WriteLine("Enter first name");
        _account.FirstName = Console.ReadLine();
        Console.WriteLine("Enter last name");
        _account.LastName = Console.ReadLine();
        Console.WriteLine("Enter email name");
        _account.Email = Console.ReadLine();
        Console.WriteLine("Enter birthday (MM/DD/YYYY)");
        _account.Birthday = DateTime.Parse(Console.ReadLine() ?? String.Empty);
        Console.WriteLine("Enter username");
        _account.Username = Console.ReadLine();
        Console.WriteLine("Enter password");
        _account.Password = Console.ReadLine();
        Console.WriteLine("Enter password again");
        _account.PasswordConfirm = Console.ReadLine();
        var isRegsitered = _accountService.Register(_account);
        Console.Clear();
        
        if (isRegsitered)
        {
            Console.WriteLine($@"You are registered {_account.Username}");
        }
        else
        {
            Console.WriteLine($@"You must be 21 years old or older to register\n");
        }
    }
    
    private static void ShowLoginScreen()
    {
        Console.WriteLine("Enter username");
        _user.Username = Console.ReadLine();
        Console.WriteLine("Enter password");
        _user.Password = Console.ReadLine();
        var isLoggedIn = _userService.Login(_user);
        Console.Clear();
        
        if (isLoggedIn)
        {
            Console.WriteLine($@"You are logged in {_user.Username}");
        }
        else
        {
            Console.WriteLine("Username or password is invalid. Try again");
        }

    }
    
    private static void ShowBookingScreen()
    {
        Console.WriteLine("Enter vehicle");
        _booking.Vehicle = Console.ReadLine();
        Console.WriteLine("Enter date (MM/DD/YYYY)");
        _booking.Date = DateTime.Parse(Console.ReadLine() ?? String.Empty);
        Console.Clear();
        Console.WriteLine($@"Your ride in a {_booking.Vehicle} will be available on {_booking.Date}");
    }

    private static void ShowRetry()
    {
        Console.WriteLine("Try again");
    }

}


