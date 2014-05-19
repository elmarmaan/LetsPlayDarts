using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;

namespace Repositories
{
    public class GameRepository : RepositoryBase, IGameRepository
    {
        public IList<Domain.GameType> GetGameTypes()
        {
            return _context.GameTypes.ToList();
        }
    }
}
