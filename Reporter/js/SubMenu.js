$(function () {
    //获取下拉框的二级联动
    //获取大类数据

    var $dl = $('#dl');

    window.onload = function () {
        $.ajax({
            type: "post",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            url: "../index.aspx/GetMenuClass",
            success: function (json) {
                var jsonArr = json.d.data;
                //console.log(json.d.data);
                for (var i = 0; i < jsonArr.length; i++) {
                    //console.log(jsonArr[i]);
                    $dl.append("<option value=" + i + 1 + ">" + jsonArr[i].ClassName + "</option>");
                }
            }
        });
    }

    $('#dl').change(function () {
        //console.log($(this).find('option:selected').text());
        var $rst = $(this).find('option:selected');
        var $xl = $('#xl');
        $.ajax({
            type: "post",
            dataType: "json",
            contentType: "application/json;charset:utf-8",
            url: "../index.aspx/GetMenuSubClass",
            data: "{'dl':'" + $rst.text() + "'}",
            success: function (json) {
                var jsonArr = json.d.data;
                $xl.empty();
                $xl.append("<option value='0'>所有</option>");
                for (var i = 0; i < jsonArr.length; i++) {
                    $xl.append("<option value=" + i + 1 + ">" + jsonArr[i].SubClassName + "</option>");
                }
            }
        });

    });

 

});