<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportInformation.aspx.cs" Inherits="NXJC.UI.Web.Report.ReportInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/Scripts/easyui/themes/gray/easyui.css" rel="stylesheet" />
    <link href="/Scripts/easyui/themes/icon.css" rel="stylesheet" />
    <script src="/Scripts/easyui/jquery.min.js"></script>
    <script src="/Scripts/easyui/jquery.easyui.min.js"></script>
    <title></title>
    <script type="text/javascript">
        function myformatter(date) {
            var y = date.getFullYear();
            var m = date.getMonth() + 1;
            var d = date.getDate();
            return y + '-' + (m < 10 ? ('0' + m) : m) + '-' + (d < 10 ? ('0' + d) : d);
        }
        function myparser(s) {
            if (!s) return new Date();
            var ss = (s.split('-'));
            var y = parseInt(ss[0], 10);
            var m = parseInt(ss[1], 10);
            var d = parseInt(ss[2], 10);
            if (!isNaN(y) && !isNaN(m) && !isNaN(d)) {
                return new Date(y, m - 1, d);
            } else {
                return new Date();
            }
        }
        function DataToServer() {
            var reportType = $('#reportType').combobox('getValue');
            var reportName = $('#reportName').combobox('getValue');
            var startTime = $('#startTime').datebox('getValue');
            var endTime = $('#endTime').datebox('getValue');
            var data = { 'reportType': reportType, 'reportName': reportName, 'startTime': startTime, 'endTime': endTime }
            return JSON.stringify(data);
        }
        function LoadDataToGrid(data) {
            $('#tzGrid').datagrid('loadData', data);
        }
        function GetDataFromServer() {
            varType = "POST";
            varContentType = "application/json; charset=utf-8";
            varDataType = "json";
            varData = DataToServer();
            
            $.ajaxSetup({ cache: false });

            $.ajax({
                type: varType,                  // GET or POST or PUT or DELETE verb
                url: 'ReportInformation.aspx/GetTZInformation',           // location of the service
                data: varData,                  // data sent to server
                contentType: varContentType,    // content type sent to server
                dataType: varDataType,          // expected data format from server
                success: serviceSuccessful,     // on successfull service call 
                // the serviceSuccessful method
                error: serviceFailed            // on unsuccessfull service call 
                // the serviceFailed method
            });
        }
        function serviceSuccessful(resultObject) {
            if (pollforupdates == true) {
                LoadDataToGrid(resultObject);
            }
        }
        function serviceFailed(result) {
        }
    </script>
</head>
<body>
    <div id="tb" style="padding:5px;height:auto">
		<div>
            类型: <select id="reportType" class="easyui-combobox" name="state" style="width:100px">
                        <option value="年报">年报</option>
                        <option value="月报">月报</option>
                        <option value="日报">日报</option>
                  </select>
            报表名称: <input id="reportName" class="easyui-combobox" style="width:100px"
					url="data/combobox_data.json"
					valueField="Id" textField="Name">
			起始日期: <input id="startTime" class="easyui-datebox" data-options="formatter:myformatter,parser:myparser" style="width:80px">
			至: <input id="endTime" class="easyui-datebox" data-options="formatter:myformatter,parser:myparser" style="width:80px">
			<a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-search" onclick="GetDataFromServer()">Search</a>
		</div>
	</div>
    <table id="tzGrid" class="easyui-datagrid" style="width:600px;height:250px"
			title="DataGrid - Complex Toolbar" toolbar="#tb"
			singleSelect="true" fitColumns="true">
		<thead>
			<tr>
				<th field="itemid" width="60">Item ID</th>
				<th field="productid" width="80">Product ID</th>
				<th field="listprice" align="right" width="70">List Price</th>
				<th field="unitcost" align="right" width="70">Unit Cost</th>
				<th field="attr1" width="200">Address</th>
				<th field="status" width="50">Status</th>
			</tr>
		</thead>
	</table>
</body>
</html>
