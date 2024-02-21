using System;
using System.Collections.Generic;
using System.IO;

class BankAccount
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string PersonalCode { get; set; }
    public string AccountNumber { get; set; }
    public double Balance { get; set; }
    public string Currency { get; set; }

    public BankAccount()
    {
        // Конструктор по умолчанию
    }

    public BankAccount(string surname, string name, string personalCode, string accountNumber, double balance, string currency)
    {
        Surname = surname;
        Name = name;
        PersonalCode = personalCode;
        AccountNumber = accountNumber;
        Balance = balance;
        Currency = currency;
    }

    public override string ToString()
    {
        return $"Surname: {Surname}, Name: {Name}, Personal Code: {PersonalCode}, Account Number: {AccountNumber}, Balance: {Balance}, Currency: {Currency}";
    }

    public bool Equals(BankAccount other)
    {
        return Surname == other.Surname && Name == other.Name && PersonalCode == other.PersonalCode &&
               AccountNumber == other.AccountNumber && Balance == other.Balance && Currency == other.Currency;
    }

    public void ReadFromStream(StreamReader stream)
    {
        string line = stream.ReadLine();
        string[] parts = line.Split(';');
        Surname = parts[0];
        Name = parts[1];
        PersonalCode = parts[2];
        AccountNumber = parts[3];
        Balance = double.Parse(parts[4]);
        Currency = parts[5];
    }

    public void WriteToStream(StreamWriter stream)
    {
        stream.WriteLine($"{Surname};{Name};{PersonalCode};{AccountNumber};{Balance};{Currency}");
    }
}

class Program
{
    static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>();

        // Чтение данных из файла
        using (StreamReader reader = new StreamReader("bank_accounts.txt.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                BankAccount account = new BankAccount();
                account.ReadFromStream(reader);
                accounts.Add(account);
            }
        }

        // Вывод на экран
        foreach (BankAccount account in accounts)
        {
            Console.WriteLine(account);
        }
    }
}
