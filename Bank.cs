using System;
using System.Collections.Generic;


public class Bank
{
    private List<Account> _accounts;
    private List<Transaction> _transactions;

    public Bank()
    {
        _accounts = new List<Account>();
        _transactions = new List<Transaction>();
    }

    public void AddAccount(Account account)
    {
        _accounts.Add(account);
    } 
    public Account GetAccount(string name)
    {
        foreach(Account acc in _accounts){
            if (acc.Name.ToLower().Trim()== name.ToLower().Trim()){
                return acc; 
            }
        }
        return null; 
    }

    public List<Account> GetAccounts(string name){
        List<Account> res = new List<Account>();
        foreach (Account acc in _accounts){
            if (acc.Name.ToLower().Trim() == name.ToLower().Trim()){
                res.Add(acc)
;            }
        }
        return res;
    }
    
   
    public void ExecuteTransaction(Transaction transaction){
        transaction.Execute(); 
        _transactions.Add(transaction);
    }
    
    public void PrintTransaction(){
        foreach (Transaction transaction in _transactions){
            transaction.Print();
        }
    }
    

}