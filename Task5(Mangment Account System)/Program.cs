namespace Task5_Mangment_Account_System_
{
    public class Account
    {
        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.Name = name;
            this.Balance = balance;
        }
        public string Name { get; set; }
        public double Balance { get; set; }

        public bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Account operator +(Account lhs , Account rhs)
        {

            return new(lhs.Name + " " + rhs.Name, lhs.Balance + rhs.Balance);


        }



    }

    class SavingAccount :Account
    {
        public SavingAccount(string name = "Unnamed Account", double balance = 0.0, double intRate=0.02) : base(name,balance)
        {
            IntRate = intRate;
        }

        public double IntRate { get; set; }


        public new bool Withdraw(double amount)
        {
           return  base.Withdraw(amount + (amount * IntRate));
        }


    }

    class CheckingAccount : Account
    {
        public CheckingAccount(string name = "Unnamed Account", double balance = 0, double fee = 1.50) : base(name, balance)
        {
            Fee = fee;
        }
        public double Fee { get; set; }
        public new bool Withdraw( double amount )
        {

           return base.Withdraw(amount + Fee);

        }



    }


    class TrustAccount : SavingAccount
    {
        public TrustAccount(string name = "Unnamed Account", double balance = 0, double intRate = 50.00) : base(name, balance, intRate)
        {

        }

        public new bool Deposit(double amount)
        {
           
            if (amount >= 5000)
                return base.Deposit(amount + IntRate);

            else
                return base.Deposit(amount);
        }

        private int withdrawalCount = 0; 

        public new bool Withdraw(double amount)
        {
            if (withdrawalCount >= 3)
            {
                Console.WriteLine("you can not withdraw more than there times at a year ");
                return false;
            }
            if (amount > Balance * 0.2)
            {
                Console.WriteLine(" You can not withdraw more than 20% of the balance.");
                return false;
            }

            withdrawalCount++;
            return base.Withdraw(amount);
        }







    }


    internal class Program
    {
        static void Main(string[] args)
        {

            List<Account> accounts = new List<Account>
        {
            new Account("John", 1000),
            new SavingAccount("Alice", 2000, 0.05),
            new CheckingAccount("Bob", 3000, 1.50),
            new TrustAccount("Charlie", 5000, 0.02)
        };

            Console.WriteLine("\n=== Start Testing ===");

            // Deposit test
            TestDeposit(accounts, 1000);

            // Withdraw test
            TestWithdraw(accounts, 2000);
            TestWithdraw(accounts, 6000); // Should fail (not enough money)

            // Trust Account special test
            Console.WriteLine("\n=== Trust Account Test ===");
            var trust = new TrustAccount("Investor", 10000, 0.02);
            trust.Deposit(4000);  // Normal deposit
            trust.Deposit(6000);  // Bonus deposit
            trust.Withdraw(2000); // Allowed
            trust.Withdraw(3000); // Allowed
            trust.Withdraw(500);  // Allowed
            trust.Withdraw(1000); // Should fail (max 3 withdrawals)

            Console.WriteLine("\n=== Merge Accounts Test ===");
            Account merged = accounts[0] + accounts[1];
            Console.WriteLine($"Merged: {merged.Name}, Balance: {merged.Balance}");

            Console.WriteLine("\n=== Testing Done ===");
        }

        static void TestDeposit(List<Account> accounts, double amount)
        {
            Console.WriteLine($"\n=== Depositing {amount} ===");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($" {acc.Name}>> New balance: {acc.Balance}");
                else
                    Console.WriteLine($" {acc.Name}>> Deposit failed");
            }
        }

        static void TestWithdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine($"\n=== Withdrawing {amount} ===");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($" {acc.Name}>> New balance: {acc.Balance}");
                else
                    Console.WriteLine($" {acc.Name}>> Not enough money");
            }



            //SavingAccount savingAccount1 = new("Ahmed", 5000, 0.02);
            //TrustAccount trustAccount1 = new("Mohamed", 10000, 0.02);

            //Console.WriteLine("Dposite on TrustAccount:");
            //Console.WriteLine(trustAccount1.Deposit(4000)); // No reward
            //Console.WriteLine(trustAccount1.Deposit(5000)); // With a $50 reward
            //Console.WriteLine("****************************************");
            //Console.WriteLine("\nWithdraw from TrustAccount:");
            //Console.WriteLine(trustAccount1.Withdraw(1000)); // allow
            //Console.WriteLine(trustAccount1.Withdraw(1000)); // allow
            //Console.WriteLine(trustAccount1.Withdraw(1000)); // allow
            //Console.WriteLine(trustAccount1.Withdraw(1000));// does not allow 
            //Console.WriteLine(" Current balance :  " + trustAccount1.Balance);

            //Console.WriteLine("\n test Overloading:");
            //Account mergedAccount = savingAccount1 + trustAccount1;
            //Console.WriteLine($" Merged Account: {mergedAccount.Name}, Balance : {mergedAccount.Balance}");











        }
    }
}
