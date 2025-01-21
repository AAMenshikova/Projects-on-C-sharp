namespace Lab5Domain.Entities;

public class Account : IAccount
{
    public Account(int number, int pin)
    {
        Number = number;
        Balance = 0;
        Pin = pin;
    }

    public int Number { get; set; }

    public decimal Balance { get; set; }

    public int Pin { get; set; }
}