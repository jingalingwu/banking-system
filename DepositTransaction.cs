public class DepositTransaction:Transaction{
    private Account _account; 
    //private decimal _amount; 
    //private bool _executed = false; 
    private bool _success; 
    //private bool _reversed = false;
    
    public override bool Success {
        get { return _success; }
    }
    

    
    public DepositTransaction(Account account, decimal amount):base(amount) {
        _account = account;
       
    }

    public override void Execute(){
        base.Execute();
        _success = _account.Deposit(_amount); 
    }
    public override void Rollback() {
       base.Rollback();
      
       if(_account.Withdraw(_amount))
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

            Console.WriteLine("Deposit Transaction: Amount: " + _amount + " from Account Name: " + _account.Name + " is successfull");
        }
        else{
            Console.WriteLine("Deposit not successful");
            if (_reversed == true){
                Console.WriteLine("Reversed: " + (_reversed ? "Yes" : "No"));
            }
        }
        
    }
}