namespace Lab5Domain.Entities;

public class MoneyTransactions
{
    public MoneyTransactions(string operationType, int accountNumber, decimal amount)
    {
        Time = DateTime.Now.TimeOfDay;
        OperationType = operationType;
        AccountNumber = accountNumber;
        TransactionNumber = Guid.NewGuid();
        Amount = amount;
    }

    public TimeSpan Time { get; set; }

    public string OperationType { get; set; }

    public int AccountNumber { get; set; }

    public decimal Amount { get; set; }

    public Guid TransactionNumber { get; set; }
}