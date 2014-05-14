using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Repositories.Interfaces
{
    public interface ISubscriptionRepository
    {
        void CreateSubscription(Account account);
    }
}
