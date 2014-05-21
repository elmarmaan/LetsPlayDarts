using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;
using Repositories.Interfaces;

namespace Repositories
{
    public class GameRepository : RepositoryBase, IGameRepository
    {
        public IList<Domain.GameType> GetGameTypes()
        {
            return _context.GameTypes.ToList();
        }

        public void StartGame(long gameTypeId, long playerOneId, long playerTwoId)
        {
            var gameType = _context.GameTypes.SingleOrDefault(g => g.Id == gameTypeId);
            var playerOne = _context.Accounts.SingleOrDefault(a => a.Id == playerOneId);
            var playerTwo = _context.Accounts.SingleOrDefault(a => a.Id == playerTwoId);

            _context.Games.Add(new Game
            {
                GameType = gameType,
                Accounts = new Collection<Account>
                {
                    playerOne,
                    playerTwo
                }
            });

            _context.SaveChanges();
        }
    }
}
