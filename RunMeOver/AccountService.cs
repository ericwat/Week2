using System.Diagnostics;

namespace RunMeOver;

public class AccountService : IAccountService
{
    private List<Account> _accounts;

    public AccountService()
    {
        _accounts = new List<Account>();
    }

    public bool Register(Account account)
    {
        bool isValidated;
        isValidated = this.ValidateAge(account.Birthday);
        
        if (isValidated)
        {
            _accounts.Add(account);
        }

        return isValidated;
    }

    public Account? Find(User user)
    {
        return _accounts.Find(a => a.Username == user.Username && a.Password == user.Password);
    }

    private bool ValidateAge(DateTime birthday)
    {
        return DateTime.Today.Subtract(birthday) >= TimeSpan.FromDays(21 * 365) ? true : false;
    }
}