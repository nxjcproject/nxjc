<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormulaYearInformation.aspx.cs" Inherits="NXJC.UI.Web.Report.FormulaYearInformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/Scripts/easyui/themes/gray/easyui.css" rel="stylesheet" />
    <link href="/Scripts/easyui/themes/icon.css" rel="stylesheet" />
    <script src="/Scripts/easyui/jquery.min.js"></script>
    <script src="/Scripts/easyui/jquery.easyui.min.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            loadGridData('first');
            loadTZTxt('first');
        });

        function loadTZTxt(myLoadType) {

            var m_MsgData;
            var dataToSend = "{id: '<%= KeyID %>'}";
            $.ajax({
                type: "POST",
                url: "FormulaYearInformationService.asmx/GetTZInformations",
                data: dataToSend,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (myLoadType == 'first') {
                        m_MsgData = jQuery.parseJSON(msg.d);
                        InitializeTZTxt(m_MsgData);
                    }
                    else if (myLoadType == 'last') {
                        m_MsgData = jQuery.parseJSON(msg.d);
                        $('#formulaYearInformation').datagrid('loadData', m_MsgData);
                    }
                }
            });
        };
        function InitializeTZTxt(myData) {
            //$('#txtNumber').attr('text', 'test');
            $('#txtDate').textbox('setText', myData['Date']);
            $('#txtRemarks').textbox('setText', myData['Remarks']);
        };

        function loadGridData(myLoadType) {

            var m_MsgData;
            var dataToSend = "{id: '<%= KeyID %>'}";
            $.ajax({
                type: "POST",
                url: "FormulaYearInformationService.asmx/GetFormulaYearDatas",
                data: dataToSend,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (myLoadType == 'first') {
                        m_MsgData = jQuery.parseJSON(msg.d);
                        InitializeGrid(m_MsgData);
                    }
                    else if (myLoadType == 'last') {
                        m_MsgData = jQuery.parseJSON(msg.d);
                        $('#formulaYearInformation').datagrid('loadData', m_MsgData);
                    }
                }
            });
        }
        function InitializeGrid(myData) {

            $('#formulaYearInformation').datagrid({
                title: '',
                data: myData,
                dataType: "json",
                striped: true,
                rownumbers: true,
                singleSelect: true,

            });
        }
    </script>
    <title></title>
</head>
<body>
    <div>
        报表日期: <input id="txtDate" class="easyui-textbox" data-options="editable:false" style="width:50px;"/>
        备注: <input id="txtRemarks" class="easyui-textbox" data-options="editable:false" style="width:50px;"/>
    </div>
    <table id="formulaYearInformation" class="easyui-datagrid" title="" style="width:700px;height:250px"
			data-options="singleSelect:true,collapsible:true">
		<thead>
			<tr>
				<th data-options="field:'KeyID',width:80">Item ID</th>
				<th data-options="field:'number',width:100">Product</th>
				<th data-options="field:'Energy',width:80,align:'right'">List Price</th>
			</tr>
		</thead>
	</table>
</body>
</html>
