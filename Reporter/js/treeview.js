$(function () {
    var uls = $('#nav_info').find('ul');
    var showUl = $('#nav_info').find('.current_info');
    var lis = $('#nav_info').children('li');
    //console.log(showUl[0]);
    $.each(showUl, function () {
        //console.log($(this).find('ul')[0]);
        $(this).find('ul').addClass('showul');
    });
    $.each(lis, function () {
        $(this).mousemove(function () {
            $(this).find('ul').addClass('showul');
        }).mouseout(function () {
            $(this).find('ul').removeClass('showul');
            $.each(showUl, function () {
                //console.log($(this).find('ul')[0]);
                $(this).find('ul').addClass('showul');
            });
        });
    });
});