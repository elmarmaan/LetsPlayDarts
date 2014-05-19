using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexts;
using Domain;
using Repositories.Interfaces;

namespace Repositories
{
    public class SubscriptionRepository : RepositoryBase, ISubscriptionRepository
    {
        public SubscriptionRepository()
        {
            _context = new LetsPlayDartsContext();
        }

        public void CreateSubscription(Domain.Account account)
        {
            var subscription = new Subscription();
            subscription.Accounts.Add(account);
            _context.Subscriptions.Add(subscription);

            _context.SaveChanges();
        }
    }
}
