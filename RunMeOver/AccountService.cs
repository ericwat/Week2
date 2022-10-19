namespace RunMeOver;

public class AccountService 
{
    private IUserService _userService;
    public AccountService(IUserService userService)
    {
        _userService = userService;
    }
    public bool Login(Account account)
    {
        bool result = false;
        var matched = _userService.Find(account.Username);
        return result;
    }


}