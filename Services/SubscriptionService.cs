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
    public class SubscriptionService : ISubscriptionService
    {
         private ISubscriptionRepository _subscriptionRepository ;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public SubscriptionService()
        {
            _subscriptionRepository = new SubscriptionRepository();
        }

        public void CreateSubscription(Account account)
        {
            _subscriptionRepository.CreateSubscription(account);
        }
    }
}
