using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexts;

namespace Repositories
{
    public class RepositoryBase
    {
        protected LetsPlayDartsContext _context;

         public RepositoryBase(LetsPlayDartsContext letsPlayDartsContext)
        {
            _context = letsPlayDartsContext;
        }

        public RepositoryBase()
        {
            _context = new LetsPlayDartsContext();
        }
    }
}
