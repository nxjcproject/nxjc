
var tableString = "";
function doPrint() {
    tableString += '<script type="text/javascript" charset="utf-8">\n window.print();window.close();\n</script>';
    tableString += '\n</html>';

    // tableString.insertAdjacentHTML("beforeBegin","<scriptlanguage='javascript'>window.print();window.close();</s"+"cript>")
    
    var m_PrintDialog = document.open('', '', 'height=500,width=611,scrollbars=yes,status =yes,toolbar=no,menubar=no,location=no,resizable=yes,titlebar=no');
    m_PrintDialog.document.write(tableString);
}



// strPrintName 打印任务名

// printDatagrid 要打印的datagrid
function InitializingHtml() {
    tableString = '<html xmlns=\"http://www.w3.org/1999/xhtml\">\n';
    tableString += "<head>\n";
    tableString += '<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />\n';
    tableString += '</head>\n';
    tableString += '<body>';
}
function CreateFormPage(strPrintName, printDatagrid) {
    InitializingHtml();

    var frozenColumns = printDatagrid.datagrid("options").frozenColumns;  // 得到frozenColumns对象
    var columns = printDatagrid.datagrid("options").columns;    // 得到columns对象
    //var columnsCount = 0;
    //载入标题
    tableString += '\n<div style="font-size:18pt; text-align:center; margin-bottom:5px;"> ' + strPrintName + '</div>';
    tableString += '\n<table cellpadding="3" cellspacing="0" border= "1" style="border-collapse:collapse"  bordercolor="black">';

    // 载入title   strPrintName
    tableString += "\n<tr>";

    if (frozenColumns != undefined && frozenColumns != '') {

        for (var i = 0; i < frozenColumns[0].length; i++) {

            if (frozenColumns[0][i].hidden != true) {

                tableString = tableString + "\n<th width= '" + frozenColumns[0][i].width + "'>" + frozenColumns[0][i].title + "</th>";

            }

        }

    }

    if (columns != undefined && columns != '') {

        for (var i = 0; i < columns[0].length - 1; i++) {

            if (columns[0][i].hidden != true) {

                tableString = tableString + "\n<th width= '" + columns[0][i].width + "'>" + columns[0][i].title + "</th>";

            }

        }

    }

    tableString = tableString + "\n</tr>";



    // 载入内容

    var rows = printDatagrid.datagrid("getRows"); // 这段代码是获取当前页的所有行。

    for (var j = 0; j < rows.length; j++) {

        tableString = tableString + "\n<tr>";

        if (frozenColumns != undefined && frozenColumns != '') {

            for (var i = 0; i < frozenColumns[0].length; i++) {

                if (frozenColumns[0][i].hidden != true) {

                    tableString = tableString + "\n<td >" + rows[j][frozenColumns[0][i].field] + "</td>";

                }

            }

        }

        if (columns != undefined && columns != '') {

            for (var i = 0; i < columns[0].length - 1; i++) {

                if (columns[0][i].hidden != true) {

                    tableString = tableString + "\n<td >" + rows[j][columns[0][i].field] + "</td>";

                }

            }

        }

        tableString = tableString + "\n</tr>";

    }

    tableString = tableString + "\n</table>\n</body>";

    doPrint();

}