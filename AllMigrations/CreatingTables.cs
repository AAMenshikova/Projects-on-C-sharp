using FluentMigrator;
using Npgsql;

namespace AllMigrations;

[Migration(1, "CreatingTables")]
public class CreatingTables
{
    public void Up(string connectionString)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        const string sqlAccount =
            "CREATE TABLE IF NOT EXISTS Accounts(accountNumber INT PRIMARY KEY, pin INT NOT NULL, balance DECIMAL NOT NULL)";
        var command1 = new NpgsqlCommand(sqlAccount, connection);
        command1.ExecuteNonQuery();
        const string sqlTransaction =
            "CREATE TABLE IF NOT EXISTS Transactions(transactionTime TIME NOT NULL, operationType VARCHAR, amount decimal, accountNumber  int references accounts (accountNumber) not null, transactionNumber UUID PRIMARY KEY)";

        var command2 = new NpgsqlCommand(sqlTransaction, connection);
        command2.ExecuteNonQuery();
    }

    public void Down(string connectionString)
    {
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        const string sql = "DROP TABLE IF EXISTS Accounts";
        var command = new NpgsqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }
}