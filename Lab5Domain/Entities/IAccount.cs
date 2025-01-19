namespace Lab5Domain.Entities;

public interface IAccount
{
    int Number { get; set; }

    decimal Balance { get; set; }

    int Pin { get; set; }
}