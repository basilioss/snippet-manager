window.changeCopyIconTemporary = function (snippetId) {
    var icon = document.getElementById("copy-icon-" + snippetId);
    if (icon) {
        icon.className = "oi oi-check";
        setTimeout(function () {
            icon.className = "oi oi-document";
        }, 1000); // Change back after 1000 milliseconds (1 second)
    }
}