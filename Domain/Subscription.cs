using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Subscription
    {
        public Subscription()
        {
            Accounts = new List<Account>();
        }
        public long Id { get; set; }
        public virtual List<Account> Accounts { get; set; }
    }
}
