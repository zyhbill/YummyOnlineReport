<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Reporter.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>报表首页</title>
    <link href="css/main.css" rel="stylesheet" />
    <script src="js/jquery-2.1.4.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
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
                    <img src="img/department.png" alt="店小二" />
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
                                    <a href="ReportForm/WePay.aspx">支付对账表</a>
                                </li>
                                <li>
                                    <a href="ReportForm/Rankings.aspx">商品销售排行榜</a>
                                </li>
                                <li>
                                    <a href="ReportForm/SalesCount.aspx">菜品销售统计表</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h2>营业汇总表
                                <span class="icon-angle-down"></span>
                            </h2>
                            <ul>
                                <li>
                                    <a href="ReportForm/TodayOrder.aspx">今日订单</a>
                                </li>
                                <li>
                                    <a href="ReportForm/TodaySales.aspx">营业日报</a>
                                </li>
                                <li>
                                    <a href="#">营业收入汇总表</a>
                                </li>
                                <li>
                                    <a href="#">交接班明细表</a>
                                </li>
                            </ul>
                        </li>
                        <li>
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
                                    <a href="ReportForm/YingyeYilan.aspx">营业情况一览表</a>
                                </li>
                                <li>
                                    <a href="ReportForm/DeskAnalysis.aspx">桌台消费分析表</a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <h2>退菜发票分析
                                <span class="icon-angle-down"></span>
                            </h2>
                            <ul>
                                <li>
                                    <a href="ReportForm/RefundInfo.aspx">退菜分析表</a>
                                </li>
                                <li>
                                    <a href="#">赠菜分析表</a>
                                </li>
                                <li>
                                    <a href="ReportForm/Receipt.aspx">发票分析表</a>
                                </li>
                                <li>
                                    <a href="#">支付方式表</a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </aside>
                <div id="main_reporter">
                </div>
            </div>
        </section><!--main_content finish-->
    </form>
</body>
</html>
