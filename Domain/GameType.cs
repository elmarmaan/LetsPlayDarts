using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain
{
    public class GameType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public GameTypeTypes Type { get; set; }
    }
}
