namespace RunMeOver;

public class UserService 
{
    private IAccountService _accountService;
    public UserService(IAccountService accountService)
    {
        _accountService = accountService;
    }
    public bool Login(User user)
    {
        bool result = false;
        var matched = _accountService.Find(user);
        if (matched != null)
        {
            result = true;
        }

        return result;
    }


}