public class TransferTransaction:Transaction

{
    private Account _toAccount; 
    private Account _fromAccount;
    private WithdrawTransaction _theWithdraw;
    private DepositTransaction _theDeposit;
    //private decimal _amount; 
    //private bool _executed = false; 
   // private bool _success = false; 
    //private bool _reversed = false;

    public override bool Success {
        get {
            if (_theDeposit.Success && _theWithdraw.Success){
                return true;
            }
            else{
                return false; 
            }
        }
    }
   

    public TransferTransaction(Account fromAccount, Account toAccount, decimal amount):base(amount) {
        _fromAccount = fromAccount;
        _toAccount = toAccount; 
        //_amount = amount; Take from Transaction.cs, extension of existing constructor

        _theWithdraw = new WithdrawTransaction(_fromAccount, _amount);
        _theDeposit = new DepositTransaction(_toAccount, _amount);
    }

    public override void Execute(){
        base.Execute();
        
        _theWithdraw.Execute();
        if (_theWithdraw.Success){
            _theDeposit.Execute();
            if(_theDeposit.Success){
                _executed = true;
            }
            else{
                _theWithdraw.Rollback();
            }
        }else{
            throw new Exception("Can not execute. Withdrawl Failed");
        }
    }

    public override void Rollback() {
       base.Rollback();
      
       if(_theWithdraw.Success)
       _theWithdraw.Rollback();
    
       if(_theDeposit.Success)
       _theDeposit.Rollback();
       
       if(_theDeposit.Reversed && _theWithdraw.Reversed){
        _reversed = true;
        _executed = false;  
       }
    }

     public override void Print()
    {
        if(_theDeposit.Success && _theWithdraw.Success){

            Console.WriteLine("Transfer Transaction: Amount: " + _amount + " from Account Name: " + _fromAccount.Name + "to " + _toAccount.Name + " is successfull");
            Console.Write("          ");
            _theWithdraw.Print();
            Console.Write("          ");
            _theDeposit.Print();
        }
        else{
            Console.WriteLine("Transfer not successful");
            if (_reversed == true){
                Console.WriteLine("Reversed: " + (_reversed ? "Yes" : "No"));
            }
        }
        
    }
        
    
   
}