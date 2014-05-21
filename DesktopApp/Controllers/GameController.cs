using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesktopApp.Model;
using DesktopApp.Model.Mappers;
using Domain;
using Domain.Enums;
using Services;
using Services.Interfaces;

namespace DesktopApp.Controllers
{
    [Authorize]
    public class GameController : LetsPlayDartsControllerController
    {
        private IGameService _gameService;
        private IAccountService _accountService;

        #region ctors
        public GameController(IGameService gameService, IAccountService accountService)
        {
            _gameService = gameService;
            _accountService = accountService;
        }

        public GameController()
        {
            _gameService = new GameService();
            _accountService = new AccountService();
        }
        #endregion

        [HttpGet]
        public ActionResult StartQuickGame()
        {
            var accounts = _accountService.GetAccounts(Subscription.Id);
            var gameTypes = _gameService.GetGameTypes();

            var startQuickGameModel = new StartQuickGameModel
            {
                Accounts = DomainToModelMapper.Map(accounts),
                GameTypes = DomainToModelMapper.Map(gameTypes)
            };

            ViewData.Model = startQuickGameModel;

            return View();
        }

        [HttpPost]
        public ActionResult StartQuickGame(long gameType, long playerOne, long playerTwo)
        {
            _gameService.StartMatch(gameType, playerOne, playerTwo);
            var game = _gameService.GetGameTypes().SingleOrDefault(g => g.Id == gameType);
            var playerOneModel = _accountService.GetAccount(playerOne);
            var playerTwoModel = _accountService.GetAccount(playerTwo);

            var gameModel = DomainToModelMapper.Map(game, playerOneModel, playerTwoModel);
            ViewData.Model = gameModel;
            switch (game.Type)
            {
                case GameTypeTypes.TacTics:
                    return View("TacTics");
                case GameTypeTypes.TwentyAndBelow:
                    return View();
                case GameTypeTypes.ThreeHundredAndOne:
                    return View();
                case GameTypeTypes.FiveHundredAndOne:
                    return View();
                default:
                    return View();
            }
        }
    }
}
