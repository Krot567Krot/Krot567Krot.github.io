$(document).ready(() => {

    $(window).scroll(() => {

        let scrollDistance = $(window).scrollTop()

        $('.section').each((i, el) => {

            if ($(el).offset().top - $('.header-menu').outerHeight() <= scrollDistance) {
                $('nav a').each((i, el) => {
                    if ($(el).hasClass('active')) {
                        $(el).removeClass('active')
                    }
                })

                $('nav li:eq(' + i + ')').find('a').addClass('active');
            }

        });

    });

});