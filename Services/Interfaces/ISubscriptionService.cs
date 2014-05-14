using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.Interfaces
{
    public interface ISubscriptionService
    {
        void CreateSubscription(Account account);
    }
}
