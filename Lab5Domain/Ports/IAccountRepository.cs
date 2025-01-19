using Lab5Domain.Entities;

namespace Lab5Domain.Ports;

public interface IAccountRepository
{
    IAccount? FindAccountByNumber(int accountNumber);

    void Save(IAccount account);

    void Create(IAccount account);
}