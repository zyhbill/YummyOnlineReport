<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Reporter.Login" %>

<!DOCTYPE html>
<html lang="en" class="no-js">

    <head>

        <meta charset="utf-8">
        <title>请登录</title>
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <meta name="description" content="">
        <meta name="author" content="">

        <!-- CSS -->
        <link rel="stylesheet" href="css/reset.css">
        <link rel="stylesheet" href="css/supersized.css">
        <link rel="stylesheet" href="css/style.css">

        <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
        <!--[if lt IE 9]>
            <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
        <![endif]-->

    </head>

    <body oncontextmenu="return false">

        <div class="page-container">
            <h1>登录</h1>
            <form id="form1" runat="server">
				<div>
					<input type="text" name="username" class="username" placeholder="Username" autocomplete="off"/>
				</div>
                <div>
					<input type="password" name="password" class="password" placeholder="Password" oncontextmenu="return false" />
                </div>
                <button id="submit" type="button">登录</button>
            </form>
            <div class="connect">
				<p style="margin-top:20px;">如果只是遇见，不能停留，不如不遇见。</p>
            </div>
        </div>
		<div class="alert" style="display:none">
			<h2>消息</h2>
			<div class="alert_con">
				<p id="ts"></p>
				<p style="line-height:70px"><a class="btn">确定</a></p>
			</div>
		</div>

        <!-- Javascript -->
        <script src="js/jquery-2.1.4.js"></script>
        <script src="js/jQuerysession.js"></script>
        <script src="js/supersized.3.2.7.min.js"></script>
        <script src="js/supersized-init.js"></script>
		<script>
		$(".btn").click(function(){
			is_hide();
		})
		var u = $("input[name=username]");
		var p = $("input[name=password]");
        
		$("#submit").click(function () {
		    var $this = $(this);
			if(u.val() == '' || p.val() =='')
			{
				$("#ts").html("用户名或密码不能为空~");
				is_show();
				return false;
			}
			else{
				var reg = /^[0-9A-Za-z]+$/;
				if(!reg.exec(u.val()))
				{
				    $("#ts").html("用户名含有特殊字符(引号，中文，空格)~");
					is_show();
					return false;
				}
				else {
				    $.ajax({
				        type: "post",
				        dataType: "json",
				        contentType: "application/json;charset=utf-8", //注意：WebMethod()必须加这项，否则客户端数据不会传到服务端
				        data: "{'username':'" + u.val() + "','password':'" + p.val() + "'}",
				        url: "Login.aspx/signin",
				        beforeSend: function () {
				            $this.attr({ disabled: "disabled" });
				        },
				        success: function (json) {
				            var rStr = new Array();
				            rStr = json.d.split("&", 2);
				            console.log(rStr);
				            console.log(rStr[0]);
				            if (json.d == "false") {
				                $("#ts").html("用户名密码不匹配");
				                is_show();
				            }
				            else if (rStr[0] == "index.aspx") {
				                $.session.set('hotelId', rStr[1]);
				                window.location = rStr[0];
				            }
				            else {
				                alert(json.d);
				            }
				        },
				        complete: function () {
				            $this.removeAttr("disabled");
				        },
				        error: function (data) {
				            $("#ts").html("error: " + data.d);
				        }
				    })
				}
			}
		});
		window.onload = function()
		{
			$(".connect p").eq(0).animate({"left":"0%"}, 400);
		}
		function is_hide(){ $(".alert").animate({"top":"-40%"}, 300) }
		function is_show(){ $(".alert").show().animate({"top":"45%"}, 300) }
		</script>
    </body>

</html>