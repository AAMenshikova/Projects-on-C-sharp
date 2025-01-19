namespace Itmo.ObjectOrientedProgramming.Lab2.AllUsers;

public class UserFactory
{
    public User Create(Guid id, string name)
    {
        var user = new User(id, name);
        return user;
    }
}