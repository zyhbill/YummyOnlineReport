$(function () {
    // 登录信息实现
    $('#store').mousemove(function () {
        $(this).addClass('move');
        $('#store_info').show();
    }).mouseout(function () {
        $(this).removeClass('move');
        $('#store_info').hide();
    });
    $('#store_info').mousemove(function () {
        $('#store').addClass('move');
        $(this).show();
    }).mouseout(function () {
        $('#store').removeClass('move');
        $(this).hide();
    });
    //注销
    $('#logout').click(function () {
        $.ajax({
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8", //注意：WebMethod()必须加这项，否则客户端数据不会传到服务端
            url: "/index.aspx/logout",
            success: function () {
                window.location = "/Login.aspx";
            }
        })
    });
    //二级导航
    $('#location_li').mousemove(function () {
        $(this).find('ul').eq(0).show();
    }).mouseout(function () {
        $(this).find('ul').eq(0).hide();
    });
    
    
   

});