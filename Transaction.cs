using System;
public abstract class Transaction
{
    protected decimal _amount;
    protected bool _executed;
    protected bool _reversed;
    private DateTime _dateStamp;

    public bool Executed{
        get {
            return _executed;
        }
    }
    public bool Reversed{
        get{
            return _reversed;
        }
    }

    public DateTime DateStamp{
        get{
            return _dateStamp;
        }
    }

    public abstract bool Success{
        get;
    }

    public Transaction (decimal amount){
        _amount = amount;
    }

    public abstract void Print();

    public virtual void Execute(){
        if ( _executed ){
            throw new Exception("Cannot execute this transaction as it has already been executed");
        }
        _executed = true;
        _dateStamp = DateTime.Now;
    }

    public virtual void Rollback(){
        if(!_executed){
            throw new Exception("No rollback, not executed");
       }
       if(_reversed){
            throw new Exception("No rollback, already reversed");
       }
    }


}