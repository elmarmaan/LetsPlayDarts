using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repositories.Interfaces
{
    public interface IAccountRepository
    {
        void AddAccount(Account account);
        void DeleteAccount(long accountId);
        Account GetAccount(long accountId);
        IEnumerable<Account> GetAccounts(long subscriptionId);
        void UpdateAccount(Account account, long accountId);
        Account GetAccountByEmailAddress(string emailAddress);
    }
}
