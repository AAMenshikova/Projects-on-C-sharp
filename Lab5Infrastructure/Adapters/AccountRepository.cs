using Lab5Domain.Entities;
using Lab5Domain.Ports;
using Npgsql;
using System.Data;

namespace Lab5Infrastructure.Adapters;

public class AccountRepository : IAccountRepository
{
    private readonly NpgsqlConnection _connection;

    public AccountRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public IAccount? FindAccountByNumber(int accountNumber)
    {
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }

        const string sql = "SELECT * FROM Accounts WHERE accountNumber = @accountNumber";
        var command = new NpgsqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@accountNumber", accountNumber);
        using NpgsqlDataReader reader = command.ExecuteReader();

        if (!reader.Read())
        {
            return null;
        }

        int number = reader.GetInt32(0);
        int pin = reader.GetInt32(1);
        var account = new Account(number, pin);
        account.Balance = reader.GetDecimal(2);
        return account;
    }

    public void Save(IAccount account)
    {
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }

        const string sql = "INSERT INTO Accounts (accountNumber, pin, balance) VALUES (@accountNumber, @pin, @balance) " +
                           "ON CONFLICT (accountNumber) DO UPDATE SET balance = @balance";
        using var command = new NpgsqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@accountNumber", account.Number);
        command.Parameters.AddWithValue("@pin", account.Pin);
        command.Parameters.AddWithValue("@balance", account.Balance);
        command.ExecuteNonQuery();
    }

    public void Create(IAccount account)
    {
        if (_connection.State == ConnectionState.Closed)
        {
            _connection.Open();
        }

        const string sql =
            "INSERT INTO Accounts (accountNumber, pin, balance) VALUES (@accountNumber, @pin, @balance)";
        var command = new NpgsqlCommand(sql, _connection);
        command.Parameters.AddWithValue("@accountNumber", account.Number);
        command.Parameters.AddWithValue("@pin", account.Pin);
        command.Parameters.AddWithValue("@balance", 0);
        command.ExecuteNonQuery();
    }
}