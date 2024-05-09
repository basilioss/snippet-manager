window.changeCopyIconTemporary = function (snippetId) {
    var icon = document.getElementById("copy-icon-" + snippetId);
    if (icon) {
        icon.className = "fa-solid fa-check";
        setTimeout(function () {
            icon.className = "fa-regular fa-clipboard";
        }, 1000); // Change back after 1000 milliseconds (1 second)
    }
}