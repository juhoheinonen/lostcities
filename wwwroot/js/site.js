// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function domReady(fn) {
    // If we're early to the party
    document.addEventListener("DOMContentLoaded", fn);
    // If late; I mean on time.
    if (document.readyState === "interactive" || document.readyState === "complete") {
        fn();
    }
}

domReady(() => {
    const btnNewGame = document.getElementById("btnNewGame");
    btnNewGame.addEventListener("click", () => {
        startNewGame();
    })
});

function startNewGame() {
    const url = "home/newGame";

    let r = new XMLHttpRequest();
    r.open("GET", "home/newGame", true);
    r.onreadystatechange = function () {
        if (r.readyState != 4 || r.status != 200) return;

        drawRound(r.response);
    };
    r.send();
}

function drawRound(gameSituationContainerJson) {
    var gameSituationContainer = JSON.parse(gameSituationContainerJson);

    var gameField = document.getElementById("dGameField");

    gameField.innerHTML = "";

    // display human cards

    for (var card of gameSituationContainer.human.hand.cards) {
        //console.log(card);

        var cardElement = document.createElement("div");
        cardElement.classList.add("card");

        switch (card.color) {
            case 0:
                cardElement.classList.add("blue");
                break;
            case 1:
                cardElement.classList.add("green");
                break;
            case 2:
                cardElement.classList.add("red");
                break;
            case 3:
                cardElement.classList.add("white");
                break;
            case 4:
                cardElement.classList.add("yellow");
                break;
        }

        if (card.value == -1) {
            cardElement.innerText = "investointi";
        } else {
            cardElement.innerText = card.value;
        }

        gameField.appendChild(cardElement);
    }

}
