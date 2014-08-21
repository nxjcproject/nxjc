/////////////////Array转化为Json///////////////////
//              myArray:数组事例                 //
//              myName:json名称                  //
// myIsNesting:是否嵌套,如果是不加外层大括号     //
function SingleArray2Json(mySingleArray, myName, myIsNesting) {
    var m_JsonString = "";
    if (myIsNesting == false) {
        m_JsonString = "{";
    }
    if (myName != '' ) {
        m_JsonString += '"' + myName + '":';
    }
    m_JsonString += '[';
    if (mySingleArray != undefined) {
        for (var i = 0; i < mySingleArray.length; i++) {
            if (i > 0) {
                if (mySingleArray[i] != undefined) {
                    m_JsonString += ',"' + mySingleArray[i].toString() + '"';
                }
                else {
                    m_JsonString += ',""';
                }
            }
            else {
                if (mySingleArray[i] != undefined) {
                    m_JsonString += '"' + mySingleArray[i].toString() + '"';
                }
                else {
                    m_JsonString += '""';
                }
            }
        }
    }
    m_JsonString += "]";
    if (myIsNesting == false) {
        m_JsonString = "}";
    }
    return m_JsonString;
}

