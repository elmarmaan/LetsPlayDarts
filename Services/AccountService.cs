using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public void AddAccount(Account account)
        {
            _accountRepository.AddAccount(account);
        }

        public List<Account> GetAccounts()
        {
            var accounts = _accountRepository.GetAccounts();
            return accounts.ToList();
        }
    }
}
