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
        alert("Success: " + r.responseText);

        console.log(r);
    };
    r.send();
}
