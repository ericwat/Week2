using System.Diagnostics;

namespace RunMeOver;

public class UserService : IUserService
{
    private List<User> _users;

    public UserService()
    {
        _users = new List<User>();
    }

    public bool Register(User user)
    {
        bool isValidated;
        isValidated = this.ValidateAge(user.Birthday);
        
        if (isValidated)
        {
            _users.Add(user);
        }

        return isValidated;
    }

    public User? Find(string username)
    {
        return _users.Find(u => u.Username == username);
    }

    private bool ValidateAge(DateTime birthday)
    {
        return DateTime.Today.Subtract(birthday) >= TimeSpan.FromDays(21 * 365) ? true : false;
    }
}