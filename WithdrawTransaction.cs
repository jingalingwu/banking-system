public class WithdrawTransaction:Transaction{
    private Account _account; 
    private bool _success = false; 
   
    
    public override bool Success {
        get {
        return _success; 
        }
    }
    
    
    public WithdrawTransaction(Account account, decimal amount):base(amount) {
        _account = account;
        
    }

    public override void Execute(){
        base.Execute();
        _success = _account.Withdraw(_amount); 
    }
    public override void Rollback() {
       base.Rollback();
      
       if(_account.Deposit(_amount))
       {
            _reversed = true;
            _executed = false;
            _success = false; 
        }
        else{
            _reversed = false;
            _executed = true;
            _success = true; 

        }


  
    }
       public override void Print()
    {
        if(_success == true){

            Console.WriteLine("Withdraw Transaction: Amount: " + _amount + " from Account Name: " + _account.Name + " is successfull");
        }
        else{
            Console.WriteLine("Withdrawal not successful");
            if (_reversed == true){
                Console.WriteLine("Reversed: " + (_reversed ? "Yes" : "No"));
            }
        }
        
    }
}
    