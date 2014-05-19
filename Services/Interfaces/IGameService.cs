using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.Interfaces
{
    public interface IGameService
    {
        IList<GameType> GetGameTypes();
    }
}
