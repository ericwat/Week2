namespace RunMeOver;

public interface IAccountService
{
    public bool Register(Account account);
    public Account? Find(User user);
    
}