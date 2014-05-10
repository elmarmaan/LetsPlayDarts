using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexts;
using Domain;
using Repositories.Interfaces;

namespace Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private LetsPlayDartsContext _context ;
        public AccountRepository(LetsPlayDartsContext letsPlayDartsContext)
        {
            _context = letsPlayDartsContext;
        }

        public AccountRepository()
        {
            _context = new LetsPlayDartsContext();
        }

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

        public IList<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
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


        public void AddPlayerToAccount(long accountId, Player player)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.Id == accountId);
            if(account == null) throw new InvalidDataException("account");

            account.Players.Add(player);
            _context.SaveChanges();
        }
    }
}
