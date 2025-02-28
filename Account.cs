using System;
public class Account
{ 
    private decimal _balance;
    private string _name;
    public Account(string name, decimal startingBalance) {
        _name = name;
        _balance = startingBalance; }

   public bool Deposit(decimal amountToAdd)
    {
        if (amountToAdd>0){
            _balance = _balance + amountToAdd; 
            return true;
        }
    
        return false;
    }
    
    public bool Withdraw(decimal amountToSub)
    {
        if (amountToSub > 0 && amountToSub <= _balance)
        {
            _balance = _balance - amountToSub;
            return true;
        }
    
        return false;
    }

    public string Name {
        get { return _name; }
        }
    public void Print (){
        Console.WriteLine("Name: " + _name);
        Console.WriteLine("Balance: " + _balance);

    }
    
    
}