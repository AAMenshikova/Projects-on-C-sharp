namespace Itmo.ObjectOrientedProgramming.Lab2.AllUsers;

public class User
{
    public User(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }

    public string Name { get; }
}