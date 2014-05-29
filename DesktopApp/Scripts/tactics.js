var _turn = 0;
var _maxStripes = 3;
var _scoreType = null;
var _arrowsThrown = 0;
var _selected = false;
var _playerOneScores = {
    scores: [
        { score: 20, stripes: 0 },
        { score: 19, stripes: 0 },
        { score: 18, stripes: 0 },
        { score: 17, stripes: 0 },
        { score: 16, stripes: 0 },
        { score: 15, stripes: 0 },
        { score: 14, stripes: 0 },
        { score: 13, stripes: 0 },
        { score: 12, stripes: 0 },
        { score: 11, stripes: 0 },
        { score: 10, stripes: 0 },
        { score: 'B', stripes: 0 }
    ],
    penalty: 0,
    threeDartAverage: 0,
    triples: 0,
    doubles: 0,
    singles: 0,
    best: 0
};

var _playerTwoScores = {
    scores: [
        { score: 20, stripes: 0 },
        { score: 19, stripes: 0 },
        { score: 18, stripes: 0 },
        { score: 17, stripes: 0 },
        { score: 16, stripes: 0 },
        { score: 15, stripes: 0 },
        { score: 14, stripes: 0 },
        { score: 13, stripes: 0 },
        { score: 12, stripes: 0 },
        { score: 11, stripes: 0 },
        { score: 10, stripes: 0 },
        { score: 'B', stripes: 0 }
    ],
    penalty: 0,
    threeDartAverage: 0,
    triples: 0,
    doubles: 0,
    singles: 0,
    best: 0
};

window.onload = function() {
    $('.score_input span').click(function () {
        if ($(this).text() === 'T') {
            _scoreType = 3;
            _selected = true;
        } else if ($(this).text() === 'D') {
            _scoreType = 2;
            _selected = true;
        } else if ($(this).text() === 'S') {
            _scoreType = 1;
            _selected = true;
        } else if ($(this).text() === 'B') {
            setScore(_scoreType, 25);
            _selected = false;
        } else {
            setScore(_scoreType, parseInt($(this).text()));
            _selected = false;
        }
    });
};


function setScore(scoreType, score) {
    setStatistics(scoreType);

    if (_turn === 0) {
        setScoreForPlayer(scoreType, score, _playerOneScores, _playerTwoScores);
    } else {
        setScoreForPlayer(scoreType, score, _playerTwoScores, _playerOneScores);
    }

    _scoreType = null;
}

function setScoreForPlayer(scoreType, score, playerScores, opponentPlayerScores) {
    playerScores.scores.forEach(function (entry) {
        if (entry.score === score) {
            for (var i = 0; i < scoreType; i++ ) {
                if (entry.stripes < _maxStripes) {
                    entry.stripes++;
                } else {
                    opponentPlayerScores.scores.forEach(function(opponentEntry) {
                        if (opponentEntry.score === score) {
                            if (opponentEntry.stripes < _maxStripes) {
                                opponentPlayerScores.penalty += score;
                            }
                        }
                    });
                    
                }
            }
        } else if (entry.score === 'B' && score === 25) {
            for (var i = 0; i < scoreType; i++) {
                if (entry.stripes < _maxStripes) {
                    entry.stripes++;
                } else {
                    if ((playerScores.penalty - 25) < 0) {
                        playerScores.penalty = 0;
                    } else {
                        playerScores.penalty -= 25;
                    }
                }
            }
        }
    });

    displayScores();
}

function displayScores() {
    // show penalty    
    $('.player_one_penalty').text(_playerOneScores.penalty);
    $('.player_two_penalty').text(_playerTwoScores.penalty);

    // show stripes
    _playerOneScores.scores.forEach(function (entry) {
        var correctSpan = $('tr .player_one_stripes')[20 - entry.score];
        if (entry.score === 'B') {
            correctSpan = $('tr .player_one_stripes:last');
        }
        
        switch (entry.stripes) {
            case 1:
                $(correctSpan).text('X');
                break;
            case 2:
                $(correctSpan).text('X X');
                break;
            case 3:
                $(correctSpan).text('X X');
                $(correctSpan).addClass('done');
                break;
        default:
        }
    });
    _playerTwoScores.scores.forEach(function (entry) {
        var correctSpan = $('tr .player_two_stripes')[20 - entry.score];
        if (entry.score === 'B') {
            correctSpan = $('tr .player_two_stripes:last');
        }
        switch (entry.stripes) {
            case 1:
                $(correctSpan).text('X');
                break;
            case 2:
                $(correctSpan).text('X X');
                break;
            case 3:
                $(correctSpan).text('X X');
                $(correctSpan).addClass('done');
                break;
            default:
        }
    });

    if (_selected) {
        _arrowsThrown++;
        $('.number_of_darts').text(_arrowsThrown);
        
        checkForWinner();
        if (_arrowsThrown === 3) {
            changeTurn();
        }
    }
}

function changeTurn() { 
    $('.scoreboard .player_name td').removeClass('turn');
    if (_turn === 0) {
        _turn++;
    } else {
        _turn--;
    }
    var playersTurn = $('.scoreboard .player_name td')[_turn];
    $(playersTurn).addClass('turn');
    _arrowsThrown = 0;
}

function checkForWinner() {
    var winner = true;
    if (_turn == 0) {
        _playerOneScores.scores.forEach(function(entry) {
            if (entry.stripes < 3) {
                winner = false;
            }
        });
        if (winner && (_playerOneScores.penalty - _playerTwoScores.penalty) > 0) {
            winner = false;
        }

    } else {
        _playerTwoScores.scores.forEach(function (entry) {
            if (entry.stripes < 3) {
                winner = false;
            }
        });
        if (winner && (_playerTwoScores.penalty - _playerOneScores.penalty) > 0) {
            winner = false;
        }
    }

    if (winner) {
        var name = $('.player_name .turn').text();
        alert(name + ' has won the match');
    }
}

setStatistics = function(scoreType) {
    if (_turn === 0) {
        switch (scoreType) {
            case 1:
                _playerOneScores.singles++;
                break;
            case 2:
                _playerOneScores.doubles++;
                break;
            case 3:
                _playerOneScores.triples++;
                break;
            default:
                //do nothing
        }
    } else {
        switch (scoreType) {
            case 1:
                _playerTwoScores.singles++;
                break;
            case 2:
                _playerTwoScores.doubles++;
                break;
            case 3:
                _playerTwoScores.triples++;
                break;
            default:
                //do nothing
        }
    }

    displayStatistics();
}

displayStatistics = function () {
    //player 1
    $('.player_one .triples').text(_playerOneScores.triples);
    $('.player_one .doubles').text(_playerOneScores.doubles);
    $('.player_one .singles').text(_playerOneScores.singles);

    //player 2
    $('.player_two .triples').text(_playerTwoScores.triples);
    $('.player_two .doubles').text(_playerTwoScores.doubles);
    $('.player_two .singles').text(_playerTwoScores.singles);
}