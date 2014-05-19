using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DesktopApp.Model;
using DesktopApp.Model.Mappers;
using Services;
using Services.Interfaces;

namespace DesktopApp.Controllers
{
    [Authorize]
    public class GameController : LetsPlayDartsControllerController
    {
        private IGameService _gameService;

        #region ctors
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        public GameController()
        {
            _gameService = new GameService();
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
    }
}
