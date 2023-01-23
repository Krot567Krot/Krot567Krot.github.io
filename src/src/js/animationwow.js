$(document).ready(() => {
    new WOW().init();


    $('.form').submit(function (event) {
        if ($('.contact-cubmitname').val() == '' || $('.contact-cubmitemail').val() == '' || $('.contact-cubmitmessage').val() == '') {
            event.preventDefault();
        }
    })
})


