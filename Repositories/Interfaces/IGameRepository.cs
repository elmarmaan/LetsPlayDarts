using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;

namespace Repositories.Interfaces
{
    public interface IGameRepository
    {
        IList<GameType> GetGameTypes();
        void StartGame(long gameTypeId, long playerOneId, long playerTwoId);
    }
}
