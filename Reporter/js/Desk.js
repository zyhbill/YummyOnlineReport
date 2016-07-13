$(function () {
    var $desk = $('#desk');
    window.onload = function () {
        $.ajax({
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            url: "../index.aspx/GetDeskInfo",
            success: function (json) {
                var jsonArr = json.d.data;
                //console.log(json.d.data);
                for (var i = 0; i < jsonArr.length; i++) {
                    //console.log(jsonArr[i]);
                    $desk.append("<option value=" + i + 1 + ">" + jsonArr[i].RoomName + "</option>");
                }
            }
        })
    }


});