using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexts;
using Domain;
using Repositories.Interfaces;

namespace Repositories
{
    public class AccountRepository : RepositoryBase, IAccountRepository
    {
       public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void DeleteAccount(long accountId)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.Id == accountId);
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }

        public Account GetAccount(long accountId)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.Id == accountId);
            return account;
        }

        public IEnumerable<Account> GetAccounts(long subscriptionId)
        {
            var subscription = _context.Subscriptions.SingleOrDefault(s => s.Id == subscriptionId);
            return subscription.Accounts.ToList();
        }

        public void UpdateAccount(Account account, long accountId)
        {
            var oldAccount = _context.Accounts.SingleOrDefault(a => a.Id == accountId);
            if(oldAccount == null) throw new InvalidDataException("account");

            oldAccount.EmailAddress = account.EmailAddress;
            oldAccount.Name = account.Name;
            oldAccount.Password = account.Password;
            _context.SaveChanges();
        }

        public Account GetAccountByEmailAddress(string emailAddress)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.EmailAddress == emailAddress);
            return account;
        }
    }
}
