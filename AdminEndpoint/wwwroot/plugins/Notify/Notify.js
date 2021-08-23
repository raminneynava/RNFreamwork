function notifyDanger(msg="خطا"){
    vNotify.info({
        text: msg,
        fadeInDuration: 1000,
        fadeOutDuration: 1000,
        fadeInterval: 50,
        visibleDuration: 3000, // auto close after 5 seconds
        postHoverVisibleDuration: 500,
        position: "bottomLeft", // topLeft, bottomLeft, bottomRight, center
        sticky: false, // is sticky
        showClose: true // show close button
    });
}
function notifySuccess(msg = "موفقیت") {
    vNotify.success({
        text: msg,
        fadeInDuration: 1000,
        fadeOutDuration: 1000,
        fadeInterval: 50,
        visibleDuration: 3000, // auto close after 5 seconds
        postHoverVisibleDuration: 500,
        position: "bottomLeft", // topLeft, bottomLeft, bottomRight, center
        sticky: false, // is sticky
        showClose: true // show close button
    });
}