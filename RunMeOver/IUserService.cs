namespace RunMeOver;

public interface IUserService
{
    public bool Register(User user);
    public User? Find(string username);
    
}