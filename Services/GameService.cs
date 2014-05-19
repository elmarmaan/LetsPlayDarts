using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class GameService : IGameService
    {
        private IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public GameService()
        {
            _gameRepository = new GameRepository();
        }

        public IList<Domain.GameType> GetGameTypes()
        {
            return _gameRepository.GetGameTypes();
        }
    }
}
