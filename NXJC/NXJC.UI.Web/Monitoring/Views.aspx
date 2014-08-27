<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Views.aspx.cs" Inherits="NXJC.UI.Web.Monitoring.Views" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>监控</title>
    <script type="text/javascript" src="/Scripts/jquery-ui-1.11.0.custom/external/jquery/jquery.js"></script>
    <script type="text/javascript" src="/Scripts/jquery-ui-1.11.0.custom/jquery-ui.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.utility.js"></script>
    <link rel="stylesheet" type="text/css" href="/Scripts/jquery-ui-1.11.0.custom/jquery-ui.css"/>
    <link rel="stylesheet" type="text/css" href="/Content/Monitoring.css" />
    <script>
        $(function () {
            $("#tabs").tabs();

            // 修改 class
            $(".tabs-bottom .ui-tabs-nav, .tabs-bottom .ui-tabs-nav > *")
			    .removeClass("ui-corner-all ui-corner-top")
			    .addClass("ui-corner-bottom");

            // 移动导航到底部
            $(".tabs-bottom .ui-tabs-nav").appendTo(".tabs-bottom");

            $(".tabs-spacer").height($(window).height() - 60);
            $("#tabs-content").height($(window).height() - 65);

            $(".ui-tabs-nav li").click(function () {
                var tabId = $(this).attr("id");
                var url = "Realtime.aspx?productLineId=" + $.getUrlParam("productLineId") + "&viewName=" + tabId;

                $("#tabs_iframe").attr("src", url);
            });

            $(".ui-tabs-nav li")[0].click();
        });

        $(window).resize(function () {
            $(".tabs-spacer").height($(window).height() - 60);
            $("#tabs-content").height($(window).height() - 65);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="tabs" class="tabs-bottom">
            <ul>
                <% foreach (var view in ViewNameDictionary)
                   { %>
                <li id="<%= view.Key %>"><a href="#tabs-content"><%= view.Value %></a></li>
                <% } %>
            </ul>
            <div class="tabs-spacer"></div>
            <div id="tabs-content">
    	        <iframe id="tabs_iframe" src="" frameborder="0" style="height:100%; width:100%; scrolling:auto" webkitAllowFullScreen="true" mozallowfullscreen="true" allowFullScreen="true"></iframe>
            </div>
        </div>
    </form>
</body>
</html>
