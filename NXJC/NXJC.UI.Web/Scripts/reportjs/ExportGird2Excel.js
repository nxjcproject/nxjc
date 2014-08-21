
function ExportExcel(myData) {
    var form = $("<form>");   //定义一个form表单
    form.attr('style', 'display:none');   //在form表单中添加查询参数
    form.attr('target', '');
    form.attr('method', 'post');
    form.attr('action', "ReportTemplate/ExportFiles.aspx");

    var input_Method = $('<input>');
    input_Method.attr('type', 'hidden');
    input_Method.attr('name', 'myMethod');
    input_Method.attr('value', 'OutExcelStream');
    var input_Data = $('<input>');
    input_Data.attr('type', 'hidden');
    input_Data.attr('name', 'myData');
    input_Data.attr('value', myData);

    $('body').append(form);  //将表单放置在web中 
    form.append(input_Method);   //将查询参数控件提交到表单上
    form.append(input_Data);   //将查询参数控件提交到表单上
    form.submit();
}

function CreateDataJson(myExportDatagrid, myTitle, myStartTime, myEndTime) {


    var m_Columns = new Array();
    var m_ClolumnWidth = new Array();
    var m_Rows = new Array();

    var frozenColumns = myExportDatagrid.datagrid("options").frozenColumns;  // 得到frozenColumns对象
    var columns = myExportDatagrid.datagrid("options").columns;    // 得到columns对象
    var rows = myExportDatagrid.datagrid("getRows"); // 这段代码是获取当前页的所有行。

    var TemplateString = '';
    var ColumnsString = '';
    var ColumnWidthString = '';
    var RowsString = '';
    var ConditionString = '';
    var TitleString = '';

    if (frozenColumns != undefined && frozenColumns != '') {
        for (var i = 0; i < frozenColumns[0].length; i++) {

            if (frozenColumns[0][i].hidden != true) {
                m_Columns.push(frozenColumns[0][i].title);
                m_ClolumnWidth.push(frozenColumns[0][i].width);
            }

        }

    }
    if (columns != undefined && columns != '') {
        for (var i = 0; i < columns[0].length - 1; i++) {

            if (columns[0][i].hidden != true) {
                m_Columns.push(columns[0][i].title);
                m_ClolumnWidth.push(columns[0][i].width);
            }

        }

    }

    for (var j = 0; j < rows.length; j++) {
        var m_Row = new Array();
        if (frozenColumns != undefined && frozenColumns != '') {

            for (var i = 0; i < frozenColumns[0].length; i++) {

                if (frozenColumns[0][i].hidden != true) {

                    m_Row.push(rows[j][frozenColumns[0][i].field]);

                }

            }

        }

        if (columns != undefined && columns != '') {

            for (var i = 0; i < columns[0].length - 1; i++) {

                if (columns[0][i].hidden != true) {

                    m_Row.push(rows[j][columns[0][i].field]);

                }

            }

        }
        m_Rows.push(m_Row);
    }

    ColumnsString = SingleArray2Json(m_Columns, 'columns', true);
    ColumnWidthString = SingleArray2Json(m_ClolumnWidth, 'columnWidth', true);
    RowsString = '"rows":[';
    for (var i = 0; i < m_Rows.length; i++) {
        if (i > 0) {
            RowsString += ',' + SingleArray2Json(m_Rows[i], '', true);
        }
        else {
            RowsString += SingleArray2Json(m_Rows[i], '', true);
        }
    }

    RowsString += ']'
    ConditionString = '"conditions":{"startTime":"' + myStartTime + '","endTime":"' + myEndTime + '"}';
    TitleString = '"title":"' + myTitle + '"';
    TemplateString = '{' + ColumnsString + ',' + ColumnWidthString + ',' + RowsString + ',' + ConditionString + ',' + TitleString + '}';

    //m_Template.push({ColumnWidthString, RowsString});
    //m_Template.push(RowsString);
    //m_Template.push(m_Conditions);
    // m_Template.push(ColumnsString);

    ExportExcel(TemplateString);
}