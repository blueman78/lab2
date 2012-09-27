
//
//  Custom javascript goes in here
//

onload=(function () {
    startTime();


    var isInteger_re = /^\s*(\+|-)?\d+\s*$/;
    function isInteger(s) {
        return String(s).search(isInteger_re) != -1;
    }
    var correctAnswer = Math.floor(Math.random() * 11);
    var count = 0;
    function game() {
        if (!isInteger(document.getElementById("js-game-input").value)) {
            alert("number only");
            return;
        }
        count++;
        var inp = parseInt(document.getElementById("js-game-input").value);

        var res = document.getElementById("js-game-results");

        if (inp > correctAnswer) {

            res.innerHTML += '<p>try No:' + count + ' lower' + '</p>';
        } else if (inp < correctAnswer) {
            res.innerHTML += '<p>try No:' + count + ' higher' + '</p>';
        } else {
            res.innerHTML += '<p id="correct">done in ' + count + ' tryes' + '</p>';
            document.getElementById('js-game-submit').disabled = true;
        }

    }

    function resetpage() {
        document.location.reload(true);
    }
    document.getElementById('js-game-submit').addEventListener('click', game, false);
    document.getElementById('js-game-reset').addEventListener('click', resetpage, false);
    

});

