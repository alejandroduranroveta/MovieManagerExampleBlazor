using Domain;

namespace UserInterface.Data;

public class SessionLogic
{
    public User CurrentUser { get; set; }
    
    public void Login(User anyUser)
    {
        CurrentUser = anyUser;
    }

    public void LogOut()
    {
        CurrentUser = null;
    }
}