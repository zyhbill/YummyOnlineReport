$(function () {
    window.onload = function () {
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
})