using System;
using SplashKitSDK;

namespace _7_1P
{
    public enum MenuOption
            {
               Add_Account, Deposit, Withdraw, Print, Transfer, Past_Transactions, Quit
            }
    public class Program
    {

        public static MenuOption ReadUserOption()
        {
            int option = 0;
            do{  
                try{
                    Console.WriteLine("Choose an option from 1-6");
                    Console.WriteLine("***********************************");
                    Console.WriteLine("1 = Add Account 2 = Deposit, 3 = Withdraw,  4 = Print, 5 = Transfer, 6 = Print Past Transaction, 7= Quit");
                    Console.WriteLine("***********************************");
                    option = Convert.ToInt32(Console.ReadLine()) ;
                }catch{
                    Console.WriteLine("Invalid option. Try Again.");
                }
                
            }
            while (option < 1 || option > 7);
           
            return (MenuOption)(option-1);
        }


      

         private static void DoDeposit(Bank bank)
        {
            Account account = FindAccount(bank);
            if(account == null){
                return;
            }
            try{
                int amount;
                Console.Write("Enter amount to deposit: ");
                amount = Convert.ToInt32(Console.ReadLine());
                DepositTransaction transaction = new DepositTransaction(account, amount);
                bank.ExecuteTransaction(transaction);
                if (!transaction.Success){
                    throw new Exception("Deposit was not successful.");
                }
                transaction.Print();
                
               
            }catch{Console.WriteLine("Invalid input. Please enter a number.");}
            
        }
        private static void DoWithdraw(Bank bank)
        {
            Account account = FindAccount(bank);
            if(account == null){
                return;
            }
            try{
                int amount;
                Console.Write("Enter amount to withdraw: ");
                amount = Convert.ToInt32(Console.ReadLine());
                WithdrawTransaction transaction = new WithdrawTransaction(account, amount);
                bank.ExecuteTransaction(transaction);
                if (!transaction.Success){
                    throw new Exception("Withdraw was not successful.");
                }
                transaction.Print();
                
               
            }catch{Console.WriteLine("Invalid input. Please enter a number.");}
            
        }

        private static void DoTransfer(Bank bank){
            Account fromAccount = FindAccount(bank);
            try{
                if(fromAccount == null){
                    return;
                }
                Account toAccount = FindAccount(bank);
                if(toAccount == null){
                    return;
                }
                
                if(fromAccount == toAccount){
                    throw new Exception ("Same account.");
                }
                
                decimal amount;
                Console.Write("How much would you like to transfer into " + toAccount.Name + "?");
                try{    
                    amount = Convert.ToInt32(Console.ReadLine());
                    TransferTransaction transaction = new TransferTransaction(fromAccount, toAccount, amount);
                    bank.ExecuteTransaction(transaction);
                     if (!transaction.Success)
                     {
                        throw new Exception("Transfer was not successful.");
                    }
                    transaction.Print();

                }catch{Console.WriteLine("Invalid input. Please enter a number.");}
            }catch(Exception ex)
            {
                    Console.WriteLine(ex.Message);
                    return;
            }

        }
        private static void DoPrint(Bank bank )
        {
            Account account = FindAccount(bank);
            if(account == null){
                    return;
                }

            account.Print();
        }

        private static void DoAddAccount(Bank bank){
            Console.WriteLine("Please enter the account name: ");
            string accName = Console.ReadLine();

            while (true){
                try{
                    Console.Write("Enter opening balance: ");
                    decimal openingBalance = Convert.ToDecimal(Console.ReadLine());
                    if (openingBalance<0){
                        throw new Exception("Opening Balance can not be less than 0.");
                    }

                    bank.AddAccount(new Account(accName, openingBalance));
                    break;
                }
                catch (Exception ex){
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static Account FindAccount(Bank bank) 
        {
            Console.Write("Enter account name: "); String name = Console.ReadLine();
            Account result = bank.GetAccount(name);
            if ( result == null ) 
            {
                Console.WriteLine($"No account found with name {name}"); 
            }
            return result; 
        }
                
        
        public static void Main() {
            MenuOption userSelection;
            //Account account = new Account("Jings Account", 5000);
            //Account newaccount = new Account("SIT771 Account", 2000);
            Bank bank = new Bank();
            int amount;

            do{
                userSelection = ReadUserOption();
        
                switch(userSelection)
                {
                    case MenuOption.Add_Account:
                        DoAddAccount(bank);
                        break;
                    case MenuOption.Withdraw:
                        DoWithdraw(bank);
                        break;
                    case MenuOption.Deposit:
                        DoDeposit(bank);
                        break;
                    case MenuOption.Print:
                        DoPrint(bank);
                        
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(bank);
                        break;
                    case MenuOption.Past_Transactions:
                        bank.PrintTransaction();
                        break;
                    case MenuOption.Quit:
                        Console.WriteLine("Goodbye!");
                        break;
                
                    
                }

            }while (userSelection != MenuOption.Quit);

        
         }
    }
}
