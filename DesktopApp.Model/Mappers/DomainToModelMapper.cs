using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DesktopApp.Model.Mappers
{
    public static class DomainToModelMapper
    {
        public static List<AccountModel> Map(IEnumerable<Account> source)
        {
            return source.Select(account => new AccountModel
            {
                Id = account.Id, Name = account.Name
            }).ToList();
        }

        public static List<GameTypeModel> Map(IEnumerable<GameType> source)
        {
            return source.Select(gameType => new GameTypeModel
            {
                Id = gameType.Id,
                Name = gameType.Name,
                Type = gameType.Type
            }).ToList();
        }

        public static GameModel Map(GameType gameType, Account playerOne, Account playerTwo)
        {
            return new GameModel
            {
                GameType = new GameTypeModel
                {
                    Id = gameType.Id,
                    Name = gameType.Name,
                    Type = gameType.Type
                },
                PlayerOne = new PlayerModel
                {
                    Id = playerOne.Id,
                    EmailAddress = playerOne.EmailAddress,
                    Name = playerOne.Name
                },
                PlayerTwo = new PlayerModel
                {
                    Id = playerTwo.Id,
                    EmailAddress = playerTwo.EmailAddress,
                    Name = playerTwo.Name
                }
            };
        }
    }
}
