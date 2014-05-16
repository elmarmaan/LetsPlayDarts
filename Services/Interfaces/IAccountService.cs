using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        void AddAccount(Account account);
        List<Account> GetAccounts(long subscriptionId);
        Account GetAccount(long accountId);
        void EditAccount(Account account);
        void DeleteAccount(long accountId);
        Account GetAccountByEmailAddress(string emailAddress);
        bool LogOn(string emailAddress, string password);
    }
}
