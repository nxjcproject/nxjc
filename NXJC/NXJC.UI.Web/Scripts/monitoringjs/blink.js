
///////////////////////////////////////////////////////
// 开关量
///////////////////////////////////////////////////////

var basePath = "/Monitoring/Templates/Common/";
var grey = "grey.png";
var white = "white.png";
var redD = "redD.png";
var redL = "redL.png";
var greenD = "greenD.png";
var greenL = "greenL.png";
var yellowD = "yellowD.png";
var yellowL = "yellowL.png";

function getImgTag(src) {
    return '<img src="' + basePath + src + '" style="width:100%;height:100%;" />';
}

function blink() {
    if (window["blink"] == "0")
        window["blink"] = "1";
    else
        window["blink"] = "0";

    $(".blink").each(function () {
        var pattern = /[^\.^\/]+\.png/gi;
        var match = $(this).html().match(pattern);

        if (window["blink"] == "0") {
            if (match == redL)
                $(this).html(getImgTag(redD));
            if (match == greenL)
                $(this).html(getImgTag(greenD));
            if (match == yellowL)
                $(this).html(getImgTag(yellowD));
        }
        else {
            if (match == redD)
                $(this).html(getImgTag(redL));
            if (match == greenD)
                $(this).html(getImgTag(greenL));
            if (match == yellowD)
                $(this).html(getImgTag(yellowL));
        }
    });
};

function handleValueRAA_2() {
    $(".ValueRAA_2").each(function () {
        var attr_r2 = '#' + $(this).attr('R2');
        var attr_a = '#' + $(this).attr('A');
        var attr_alm = '#' + $(this).attr('ALM');
        var combination = $(attr_r2).val() + $(attr_a).val() + $(attr_alm).val();

        var content;
        switch (combination) {
            case '000':
                content = getImgTag(grey);
            case '001':
                content = getImgTag(redL);
            case '010':
                content = getImgTag(greenL);
            case '011':
                content = getImgTag(redL);
        }

        $(this).html(html);
    });
}

function handleValueRRE_circle() {
    $(".ValueRRE_circle").each(function () {
        var attr_rd = '#' + $(this).attr('RD');
        var attr_rn = '#' + $(this).attr('RN');
        var attr_err = '#' + $(this).attr('ERR');
        var combination = $(attr_rd).val() + $(attr_rn).val() + $(attr_err).val();

        var content;
        switch (combination) {
            case '000':
                content = getImgTag(yellowL);
                $(this).removeClass("blink").addClass("blink");
                break;
            case '010':
                content = getImgTag(greenL);
                $(this).removeClass("blink").addClass("blink");
                break;
            case '100':
                content = getImgTag(yellowL);
                $(this).removeClass("blink");
                break;
            case '110':
                content = getImgTag(greenL);
                $(this).removeClass("blink");
                break;
            default:
                content = getImgTag(redL);
                $(this).removeClass("blink").addClass("blink");
                break;
        }
        $(this).html(content);
    });
}

$(document).ready(function () {
    // 开关量1000ms一闪
    setInterval(blink, 500);
});

function SwitchingValueRender() {

    handleValueRRE_circle();
}