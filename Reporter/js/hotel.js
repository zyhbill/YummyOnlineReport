$(function () {
    var $hotel = $('#hotelid');
    var hotelCode = $.session.get('hotelId');
    window.onload = function () {
        $.ajax({
            type: "post",
            dataType: "json",
            data: "{'hotelCode':'" + hotelCode + "'}",
            contentType: "application/json;charset=utf-8",
            url: "../index.aspx/GetHotelInfo",
            success: function (json) {
                var jsonArr = json.d.data;
                //console.log(json.d.data);
                for (var i = 0; i < jsonArr.length; i++) {
                    //console.log(jsonArr[i]);
                    $hotel.append("<option value=" + jsonArr[i].HotelCode + ">" + jsonArr[i].HotelName + "</option>");
                }
                var $pay = $('#Pkind');
                $.ajax({
                    type: "post",
                    dataType: "json",
                    contentType: "application/json;charset=utf-8",
                    url: "../index.aspx/GetPayKind",
                    success: function (json) {
                        var jsonArr = json.d.data;
                        //console.log(json.d.data);
                        for (var i = 0; i < jsonArr.length; i++) {
                            //console.log(jsonArr[i]);
                            $pay.append("<option value=" + jsonArr[i].Kind + ">" + jsonArr[i].PayName + "</option>");
                        }
                    }
                });
            }
        });
    }
})