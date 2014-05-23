var _turn = 0;

function changeTurn() { 
    $('.scoreboard .player_name td').removeClass('turn');
    if (_turn === 0) {
        _turn++;
    } else {
        _turn--;
    }
    var playersTurn = $('.scoreboard .player_name td')[_turn];
    $(playersTurn).addClass('turn');
}