using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Game
    {
        public long Id { get; set; }
        public virtual GameType GameType { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public long PlayerOneScore { get; set; }
        public long PlayerTwoScore { get; set; }
    }
}
