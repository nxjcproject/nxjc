<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnergyTotalMonthInformation.aspx.cs" Inherits="NXJC.UI.Web.Report.EnergyTotalMonth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/Scripts/easyui/themes/gray/easyui.css" rel="stylesheet" />
    <link href="/Scripts/easyui/themes/icon.css" rel="stylesheet" />
    <script src="/Scripts/easyui/jquery.min.js"></script>
    <script src="/Scripts/easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript">

        var m_MsgData;
        $(function () {
            loadGridData('first');

        });

        function loadGridData(myLoadType) {

            //parent.$.messager.progress({ text: '数据加载中....' });
            var m_MsgData;
            $.ajax({
                type: "POST",
                url: "EnergyTotalMonthInformation.aspx/GetTreeGridDatas",                 //填写后台方法链接
                data: "",//"{id: ''}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (myLoadType == 'first') {
                        m_MsgData = jQuery.parseJSON(msg.d);
                        InitializeGrid(m_MsgData);
                    }
                    else if (myLoadType == 'last') {
                        m_MsgData = jQuery.parseJSON(msg.d);
                        $('#tg').treegrid('loadData', m_MsgData);
                    }
                }
            });
        }
        function InitializeGrid(myData) {
            $('#tg').treegrid('loadData', myData);
        }
    </script>
    <title></title>
</head>
    <body>
        <table id="tg" class="easyui-treegrid" style="width:100%;height:600px;" 
            data-options="
                rownumbers:true,
                idField: 'ID',
                collapsible:true,
                treeField: '名称'
            ">
            <thead>
                <tr>
                    <th data-options="field:'名称',width:'20%',align:'center'" rowspan="2">名称</th>
                    <th colspan="3">用电量（KWh）</th>
                    <th data-options="field:'用煤量',width:'10%',align:'center'" rowspan="2">用煤量(t)</th>
                    <th colspan="4">产量（t）</th>
                    <th colspan="3">电耗（KWh/t）</th>
                    <th data-options="field:'吨熟料综合电耗',width:'10%',align:'center'" rowspan="2">吨熟料综合电耗（KWh/t）</th>
                    <th data-options="field:'吨熟料实物煤耗',width:'10%',align:'center'" rowspan="2">吨熟料实物煤耗（kg/t）</th>
                    <th data-options="field:'吨熟料发电量',width:'15%',align:'center'" rowspan="2">吨熟料发电量(KWh/t)</th>
                </tr>
                <tr>
                    <th data-options="field:'生料制备1',width:'10%',align:'center'">生料制备</th>
                    <th data-options="field:'熟料烧成1',width:'10%',align:'center'">熟料烧成</th>
                    <th data-options="field:'水泥制备1',width:'10%',align:'center'">水泥制备</th>
                    <th data-options="field:'生料制备2',width:'10%',align:'center'">生料制备</th>
                    <th data-options="field:'熟料烧成2',width:'10%',align:'center'">熟料烧成</th>
                    <th data-options="field:'水泥制备2',width:'10%',align:'center'">水泥制备</th>
                    <th data-options="field:'发电量',width:'10%',align:'center'">发电量(KWh)</th>
                    <th data-options="field:'生料制备3',width:'10%',align:'center'">生料制备</th>
                    <th data-options="field:'熟料烧成3',width:'10%',align:'center'">熟料烧成</th>
                    <th data-options="field:'水泥制备3',width:'10%',align:'center'">水泥制备</th>
                </tr>
            </thead>
        </table>
    </body>
</html>
