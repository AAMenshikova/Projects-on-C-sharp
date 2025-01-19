using Lab5Domain.Entities;
using Lab5Domain.Ports;
using Lab5Domain.RealisationOfOperations;
using Lab5Domain.ResultTypes;
using System.Collections.ObjectModel;

namespace Lab5Application;

public class BankService : IBankService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public BankService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
    {
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public IAccount CreateAccount(int number, int pin)
    {
        var account = new Account(number, pin);
        _accountRepository.Create(account);
        return account;
    }

    public TypesOfResult Deposit(int accountNumber, decimal amount)
    {
        IAccount? account = _accountRepository.FindAccountByNumber(accountNumber);
        if (account is not null)
        {
            var deposit = new Deposit(account);
            TypesOfResult result = deposit.Doing(amount);
            if (result is TypesOfResult.Success)
            {
                var transaction = new MoneyTransactions("Пополнение", accountNumber, amount);
                _transactionRepository.Save(transaction);
                _accountRepository.Save(account);
            }

            return result;
        }

        return new TypesOfResult.Fail("Не существует аккаунта");
    }

    public TypesOfResult Withdraw(int accountNumber, decimal amount)
    {
        IAccount? account = _accountRepository.FindAccountByNumber(accountNumber);
        if (account is null)
            return new TypesOfResult.Fail("Не существует аккаунта");

        var withdraw = new Withdraw(account);
        TypesOfResult result = withdraw.Doing(amount);
        if (result is TypesOfResult.Success)
        {
            var transaction = new MoneyTransactions("Снятие", accountNumber, amount);
            _transactionRepository.Save(transaction);
            _accountRepository.Save(account);
            return result;
        }

        return result;
    }

    public Collection<MoneyTransactions>? GetTransactionsHistory(int accountNumber)
    {
        return _transactionRepository.FindTransactionByNumber(accountNumber);
    }
}