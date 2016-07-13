<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeskAnalysis.aspx.cs" Inherits="Reporter.ReportForm.DeskAnalysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>报表首页</title>
    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery-2.1.4.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="../js/main.js"></script>
    <script src="../js/Desk.js"></script>
    <script src="../js/treeview.js"></script>
    <script src="../js/bootstrap-table.js" charset="gb2312"></script>
    <style type="text/css">
        #nav_info>li ul{
            display:none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header id="head">
            <div class="wrap head-top">
                <a href="javascript:;" class="store" id="store">
                    <span class="icon-user" style="margin-right:5px;margin-left:10px;"></span>
                    jack
                    <span class="down icon-angle-down"></span>
                </a>
                <a href="javascript:;" class="letter">
                    <span class="icon-envelope" style="margin-right:5px;margin-left:10px;color:#E64040;"></span>
                    站内信
                    <sup>1</sup>
                </a>
                <div id="store_info" class="clearfix">
                    <div class="logo">
                        <img src="#" alt="store logo" />
                    </div>
                    <ul>
                        <li><a href="#">帐号管理</a></li>
                        <li><a href="#" id="logout">退出</a></li>
                    </ul>
                    <div class="clean"></div>
                    <div class="hr"></div>
                    <div class="store_right clearfix">
                        <a href="#" id="back"><span class="icon-angle-left"></span></a>
                        <ul>
                            <li><a href="#">特权1</a></li>
                            <li><a href="#">特权2</a></li>
                            <li><a href="#">特权3</a></li>
                            <li><a href="#">特权4</a></li>
                        </ul>
                        <a href="#" id="next"><span class="icon-angle-right"></span></a>
                    </div><!--store_right finish-->
                </div><!--store_info finish-->
                <ul class="head-left">
                    <li><a href="#">联系我们</a></li>
                    <li><a href="#">关于</a></li>
                    <li><a href="#">加入我们</a></li>
                </ul>
            </div><!--head-top finish-->
        </header><!--head finish-->
        <section id="main_content" class="wrap clearfix">
            <header class="content-top">
                <a href="#">
                    <img src="../img/department.png" alt="店小二" />
                </a>
                <h1>店小二-智能点菜报表系统</h1>
                <div class="clean"></div>
            </header>
            <div class="hr"></div>
            <div id="main_body" class="clearfix">
                <aside id="side_bar">
                    <ul id="nav_info">
                        <li>
                            <h2>销售数据分析
                                <span class="icon-angle-down"></span>
                            </h2>
                            <ul>
                                <li>
                                    <a href="WePay.aspx">支付对账表</a>
                                </li>
                                <li>
                                    <a href="Rankings.aspx">商品销售排行榜</a>
                                </li>
                                <li>
                                    <a href="SalesCount.aspx">菜品销售统计表</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h2>营业汇总表
                                <span class="icon-angle-down"></span>
                            </h2>
                            <ul>
                                <li>
                                    <a href="TodayOrder.aspx">今日订单</a>
                                </li>
                                <li>
                                    <a href="TodaySales.aspx">营业日报</a>
                                </li>
                                <li>
                                    <a href="#">营业收入汇总表</a>
                                </li>
                                <li>
                                    <a href="#">交接班明细表</a>
                                </li>
                            </ul>
                        </li>
                        <li  class="current_info">
                            <h2>营业决策分析
                                <span class="icon-angle-down"></span>
                            </h2>
                            <ul>
                                <li>
                                    <a href="#">现金日报表</a>
                                </li>
                                <li>
                                    <a href="#">营运月报表</a>
                                </li>
                                <li>
                                    <a href="YingyeYilan.aspx">营业情况一览表</a>
                                </li>
                                <li  class="current_li">
                                    <a href="#">桌台消费分析表</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h2>退菜发票分析
                                <span class="icon-angle-down"></span>
                            </h2>
                            <ul>
                                <li>
                                    <a href="RefundInfo.aspx">退菜分析表</a>
                                </li>
                                <li>
                                    <a href="#">赠菜分析表</a>
                                </li>
                                <li>
                                    <a href="Receipt.aspx">发票分析表</a>
                                </li>
                                <li>
                                    <a href="#">支付方式表</a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </aside>
                <div id="main_reporter" class="clearfix">
                    <ul id="location" class="clearfix">
                        <li><a href="#">报表系统</a><span class="icon-angle-right"></span></li>
                        <li><a href="#">营业决策分析</a><span class="icon-angle-right"></span></li>
                        <li id="location_li"><a href="#">桌台消费分析表</a>
                            <ul>
                                <li><a href="#">现金日报表</a></li>
                                <li><a href="#">营运月报表</a></li>
                                <li><a href="YingyeYilan.aspx">营业情况一览表</a></li>
                            </ul>
                        </li>
                    </ul>
                    <div class="reporter_area">
                        
                        <!--<div id="menuSelect">
                            <span class="icon-food">大类:</span>
                            <select id="dl">
                                <option value="0">所有</option>
                            </select>
                            <span class="icon-food" style="margin-left:50px;">小类:</span>
                            <select id="xl">
                                <option value="0">所有</option>
                            </select>
                        </div>-->
                        <div class="deskinfomation">
                            <span class="end icon-desktop"> 餐厅名称:</span>
                            <select id="desk">
                                <option value="0">所有</option>
                            </select>
                        </div>
                        <div id="time">
                            <span class="begin icon-calendar"> 开始时间:</span><input type="date" name="beginTime" id="beginTime" value=" "/>
                            <span class="end icon-calendar"> 至:</span><input type="date" name="endTime" id="endTime" value=" " /> 
                            <button id="search" type="button" style="margin-left:200px;"><span class="icon-search"></span>搜索</button>
                        </div>
                        
                        <table data-toggle="table" data-height="450" data-pagination="true" id="table" data-url="" data-sort-name="id" data-sort-order="asc">
                            <thead>
                                <tr>
                                    <th data-field="id" rowspan="2" data-valign="middle">桌号</th>
                                    <th data-field="num"  data-align="center"  rowspan="2" data-valign="middle">开单数</th>
                                    <th data-field="average"  data-align="right"  rowspan="2" data-valign="middle">人均消费额</th>
                                    <th data-field="preson"  data-align="right" rowspan="2" data-valign="middle">桌人数</th>

                                    <th data-align="center" colspan="3">消费统计</th>

                                    <th data-field="precent" data-align="center"  rowspan="2" data-valign="middle" >销售百分比%</th>
                                </tr>
                                <tr>
                                    <th data-field="price"  data-align="right" >应记金额</th>
                                    <th data-field="discount"  data-align="right" >优惠金额</th>
                                    <th data-field="get"  data-align="right" >实收金额</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div><!--main_reporter finish-->
            </div><!--main_body finish-->
        </section><!--main_content finish-->
    </form>

    <script>
        //搜索实现
        $('#search').click(function () {
            var $this = $(this);
            var begin = $('#beginTime');
            var end=$('#endTime')
            var $deskinfo = $('#desk').find('option:selected');
            //console.log(begin.val());
            $.ajax({
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'beginTime':'" + begin.val() + "','endTime':'" + end.val() + "','deskinfo':'" + $deskinfo.text() + "'}",
                url: "DeskAnalysis.aspx/getAnalysis",
                beforeSend: function () {
                    $this.attr('disabled', 'disabled');
                },
                success: function (json) {
                    var jsonstr = json.d.data;
                    var $table=$('#table');
                    //console.log(typeof ();
                    //alert(JSON.stringify($table.bootstrapTable('getData')));
                    //console.log(json.d.rows);
                    //console.log(1);
                    $table.bootstrapTable('load',jsonstr);
                },
                complete: function () {
                    $this.removeAttr('disabled');
                },
                error: function (data) {
                    alert(data.d);
                }
            });

        });

    </script>
</body>
</html>