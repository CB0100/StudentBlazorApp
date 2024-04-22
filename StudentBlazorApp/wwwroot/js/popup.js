window.showPopupWindow = function () {
    var popupWindow = document.querySelector('.popup-window');
    popupWindow.style.display = 'block';
}

window.hidePopupWindow = function () {
    var popupWindow = document.querySelector('.popup-window');
    popupWindow.style.display = 'none';
}

 window.openInNewTab = function(url) {
        var win = window.open(url, '_blank');
        win.focus();
    }