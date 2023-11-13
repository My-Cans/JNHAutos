$(document).ready(function () {
    $(window).scroll(function () {
        var height = 0;
        var scrollTop = $(window).scrollTop();

        if (scrollTop > height) {
            $('.navbar').addClass('solid-nav');
        } else {
            $('.navbar').removeClass('solid-nav');
        }
    });
});