function GetPosition(element) {
    var result = new Object();
    result.x = 0;
    result.y = 0;
    result.width = 0;
    result.height = 0;
    if (element.offsetParent) {
        result.x = element.offsetLeft;
        result.y = element.offsetTop;
        var parent = element.offsetParent;
        while (parent) {
            result.x += parent.offsetLeft;
            result.y += parent.offsetTop;
            var parentTagName = parent.tagName.toLowerCase();
            if (parentTagName != "table" &&
                parentTagName != "body" &&
                parentTagName != "html" &&
                parentTagName != "div" &&
                parent.clientTop &&
                parent.clientLeft) {
                result.x += parent.clientLeft;
                result.y += parent.clientTop;
            }
            parent = parent.offsetParent;
        }
    }
    else if (element.left && element.top) {
        result.x = element.left;
        result.y = element.top;
    }
    else {
        if (element.x) {
            result.x = element.x;
        }
        if (element.y) {
            result.y = element.y;
        }
    }
    if (element.offsetWidth && element.offsetHeight) {
        result.width = element.offsetWidth;
        result.height = element.offsetHeight;
    }
    else if (element.style && element.style.pixelWidth && element.style.pixelHeight) {
        result.width = element.style.pixelWidth;
        result.height = element.style.pixelHeight;
    }
    return result;
}

function GetElementById(elementId) {
    if (document.getElementById) {
        return document.getElementById(elementId);
    }
    else if (document.all) {
        return document.all[elementId];
    }
    else return null;
}

function $(elementId) {
    if (document.getElementById) {
        return document.getElementById(elementId);
    }
    else if (document.all) {
        return document.all[elementId];
    }
    else return null;
}

function GetParentByTagName(element, tagName) {
    var parent = element.parentNode;
    var upperTagName = tagName.toUpperCase();
    while (parent && (parent.tagName.toUpperCase() != upperTagName)) {
        parent = parent.parentNode ? parent.parentNode : parent.parentElement;
    }
    return parent;
}

function GetElementsByTagName(element, tagName) {
    if (element && tagName) {
        if (element.getElementsByTagName) {
            return element.getElementsByTagName(tagName);
        }
        if (element.all && element.all.tags) {
            return element.all.tags(tagName);
        }
    }
    return null;
}

function createXMLHttpRequest() {
    try { return new ActiveXObject("Msxml2.XMLHTTP"); } catch (e) { }
    try { return new ActiveXObject("Microsoft.XMLHTTP"); } catch (e) { }
    try { return new XMLHttpRequest(); } catch (e) { }
    alert("XMLHttpRequest not supported");
    return null;
}
function splitphone(inp, control) {
    var p = inp.toString().split(";")[inp.toString().split(';').length - 1].trim();
    if (p == null) return;
    if (p.length == 4)
        control.value = inp + ".";
    else if (p.length == 8)
        control.value = inp + ".";
}
function SoXe(inp) {
    var a = inp.value.split('-');
    var p = "";
    if (a.length > 1) {
        p = a[0].trim().toUpperCase() + " - " + a[1].trim().toUpperCase();
        inp.value = p;
    }
}
function ktsdt(inp, control) {
    if (((window.event.keyCode < 48) || (window.event.keyCode > 57)) && (window.event.keyCode != 8) && ((window.event.keyCode < 96) || (window.event.keyCode > 105))) {
        control.value = inp.toString().substring(0, inp.toString().length - 1);
        return;
    }
}
function ChangeMenuitem(inp) {
    jQuery('.w3-sidebar a').removeClass("active");
    jQuery(inp).addClass("active");
}

function ChangeTopMenuitem(inp) {
    jQuery('nav ul li a').removeClass("active");
    jQuery(inp).addClass("active");
}


function ChangeCarActive(inp) {
    jQuery('.danhsachxe div').removeClass("xeactive");
    jQuery('.danhsachxe div').addClass("xeinactive");
    jQuery(inp).removeClass('xeinactive');
    jQuery(inp).addClass("xeactive");
    var x = jQuery("#hdidcxe").val();
    jQuery("#hdidcxe").val(inp.id);
    var y =jQuery("#hdidcxe").val();
}
function resize(controls) {
    var myHeight = 0;
    if (typeof (window.innerWidth) == 'number') {
        //Non-IE
        myHeight = window.innerHeight;
    } else if (document.documentElement && (document.documentElement.clientWidth || document.documentElement.clientHeight)) {
        //IE 6+ in 'standards compliant mode'
        myHeight = document.documentElement.clientHeight;
    } else if (document.body && (document.body.clientWidth || document.body.clientHeight)) {
        //IE 4 compatible
        myHeight = document.body.clientHeight;
    }
    controls.style.height = myHeight - 70 + "px";
    controls.style.width = "100%";
}
function GetUrlQueryString(qname) {
    var QueryString = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < QueryString.length; i++) {
        var name = QueryString[i].split('=')[0];
        var value = QueryString[i].split('=')[1];
        if (name == qname)
            return value;
    }
}
function Money(obj) {
    var p = obj.value.toString().replace(/,/g, "");
    if (p == null) return;

    if (p.length < 4)
    {
        if (p.indexOf(",") >= 0) {
            while (p.indexOf(",") >= 0) {
                p = p.replace(",", "");
            }
        }
        obj.value = p;
    }
    else if (p.length >= 4 && p.length < 7) {
        obj.value = p.substring(0, p.length - 3) + "," + p.substring(p.length - 3, p.length);

    }
    else if (p.length >= 7) {
        obj.value = p.substring(0, p.length - 6) + "," + p.substring(p.length - 6, p.length - 3) + "," + p.substring(p.length - 3, p.length);
    }
}

function ColorLuminance(hex, lum) {

    // validate hex string
    hex = String(hex).replace(/[^0-9a-f]/gi, '');
    if (hex.length < 6) {
        hex = hex[0] + hex[0] + hex[1] + hex[1] + hex[2] + hex[2];
    }
    lum = lum || 0;

    // convert to decimal and change luminosity
    var rgb = "#", c, i;
    for (i = 0; i < 3; i++) {
        c = parseInt(hex.substr(i * 2, 2), 16);
        c = Math.round(Math.min(Math.max(0, c + (c * lum)), 255)).toString(16);
        rgb += ("00" + c).substr(c.length);
    }

    return rgb;
}

var diacritics = {
    a: 'áàảãạăắặằẳẵâấầẩẫậ',//'ÀÁÂÁẮÃÄÅàáâãäåĀāąĄ',//c: 'ÇçćĆčČ',
    d: 'đ',
    e: 'éèẻẽẹêếềểễệ',//'ÈÉÊËèéêëěĚĒēęĘ',
    i: 'íìỉĩị',//'ÌÍÎÏìíîïĪī',l: 'łŁ',//n: 'ÑñňŇńŃ',
    o: 'óòỏõọôốồổỗộơớờởỡợ',//r: 'řŘ',s: 'ŠšśŚ',t: 'ťŤ',
    u: 'úùủũụưứừửữự',//'ÙÚÛÜùúûüůŮŪū',
    y: 'ýỳỷỹỵ',//'ŸÿýÝ',
    //z: 'ŽžżŻźŹ'
}

function removeDiacritics(text) {
    for (var toLetter in diacritics) if (diacritics.hasOwnProperty(toLetter)) {
        for (var i = 0, ii = diacritics[toLetter].length, fromLetter, toCaseLetter; i < ii; i++) {
            fromLetter = diacritics[toLetter][i];
            if (text.indexOf(fromLetter) < 0) continue;
            toCaseLetter = fromLetter == fromLetter.toUpperCase() ? toLetter.toUpperCase() : toLetter;
            text = text.replace(new RegExp(fromLetter, 'g'), toCaseLetter);
        }
    }
    return text;
}

function LoadAutocompleteDriver(cusID) {
    var da;
    jQuery(document).ready(function () {
        jQuery.post("/UpdateData.asmx/getDriverList",
            {
                cusID: id
            },
            function (data, status) {
                da = data;
            });
    });
    jQuery('input[name="txtTenLaiXe"]').autoComplete({
        minChars: 1,
        source:
            function (term, suggest) {
                term = term.toLowerCase();
                var key = new RegExp(removeDiacritics(term));
                var choices = da;
                var suggestions = [];
                for (var j = 0; j < choices.length; j++) {
                    var stri = choices[j].HoTen.toLowerCase();
                    stri = removeDiacritics(stri);
                    if (stri.match(key) || choices[j].Id.match(key))
                        suggestions.push(choices[j]);
                }
                suggest(suggestions);
            }
        ,
        renderItem: function (item, search) {
            search = search.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&');
            var re = new RegExp("(" + search.split(' ').join('|') + ")", "gi");
            return '<div class="autocomplete-suggestion" data-langname="' + item.HoTen + '" data-lang="' + item.Id + '" data-val="' + search + '">' + item.HoTen.replace(re, "<b>$1</b>") + '</div>';
        },
        onSelect: function (e, term, item) {
            console.log('Item "' + item.data('langname') + ' (' + item.data('lang') + ')" selected by ' + (e.type == 'keydown' ? 'pressing enter or tab' : 'mouse click') + '.');
            jQuery('#txtTenLaiXe').val(item.data('langname') + ' (' + item.data('lang') + ')');
            jQuery("#lblLaiXe").val(item.data('lang'));
        }
    });
}

function LoadAutocompleteBusline(cusID) {
    var da;
    jQuery(document).ready(function () {
        jQuery.post("/UpdateData.asmx/getDanhSachTuyen",
            {
                cusID: id
            },
            function (data, status) {
                da = data;
            });
    });
    jQuery('input[name="txtTuyenXe"]').autoComplete({
        minChars: 1,
        source:
            function (term, suggest) {
                term = term.toLowerCase();
                var key = new RegExp(removeDiacritics(term));
                var choices = da;
                var suggestions = [];
                for (var j = 0; j < choices.length; j++) {
                    var stri = choices[j].TenTuyen.toLowerCase();
                    stri = removeDiacritics(stri);
                    if (stri.match(key) || choices[j].Id.match(key))
                        suggestions.push(choices[j]);
                }
                suggest(suggestions);
            }
        ,
        renderItem: function (item, search) {
            search = search.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&');
            var re = new RegExp("(" + search.split(' ').join('|') + ")", "gi");
            return '<div class="autocomplete-suggestion" data-langname="' + item.TenTuyen + '" data-lang="' + item.Id + '" data-val="' + search + '">' + item.TenTuyen.replace(re, "<b>$1</b>") + '</div>';
        },
        onSelect: function (e, term, item) {
            console.log('Item "' + item.data('langname') + ' (' + item.data('lang') + ')" selected by ' + (e.type == 'keydown' ? 'pressing enter or tab' : 'mouse click') + '.');
            jQuery('#txtTuyenXe').val(item.data('langname'));
            jQuery("#lblTuyenXe").val(item.data('lang'));
        }
    });
}
function LoadAutocompleteBusNumber(cusID) {
    var da;
    jQuery(document).ready(function () {
        jQuery.post("/UpdateData.asmx/getVihiclesList",
            {
                cusID: id
            },
            function (data, status) {
                da = data;
            });
    });
    jQuery('input[name="txtSoXe"]').autoComplete({
        minChars: 1,
        source:
            function (term, suggest) {
                term = term.toLowerCase();
                var key = new RegExp(removeDiacritics(term));
                var choices = da;
                var suggestions = [];
                for (var j = 0; j < choices.length; j++) {
                    var stri = choices[j].SoXe.toLowerCase();
                    stri = removeDiacritics(stri);
                    var tenxe = removeDiacritics(choices[j].TenXe.toLowerCase());
                    if (stri.match(key) || choices[j].Id.match(key) || tenxe.match(key))
                        suggestions.push(choices[j]);
                }
                suggest(suggestions);
            }
        ,
        renderItem: function (item, search) {
            search = search.replace(/[-\/\\^$*+?.()|[\]{}]/g, '\\$&');
            var re = new RegExp("(" + search.split(' ').join('|') + ")", "gi");
            return '<div class="autocomplete-suggestion" data-langname="' + item.SoXe + '" data-lang="' + item.TenXe + '" data-val="' + search + '">' + item.SoXe.replace(re, "<b>$1</b>") + '</div>';
        },
        onSelect: function (e, term, item) {
            //console.log('Item "' + item.data('langname') + ' (' + item.data('lang') + ')" selected by ' + (e.type == 'keydown' ? 'pressing enter or tab' : 'mouse click') + '.');
            jQuery('#txtSoXe').val(item.data('langname') + ' (' + item.data('lang') + ')');
            jQuery("#lblSoXe").val(item.data('lang'));
        }
    });
}
function LoadThongKe(obj)
{
    var href = jQuery(obj).attr('link');
    var thongke = jQuery('.thongke');
    ChangeMenuitem(thongke);
    jQuery('#divTimKiem').hide();
    var ifr = jQuery('#container');
    jQuery(ifr).attr("src", href);
    
}
function openLeftMenu() {
    //document.getElementById("leftMenu").style.display = "block";
    document.getElementById("leftMenu").style.marginLeft = "0px";
    document.getElementById("closeButton").style.display = "block";
    document.getElementById("openButton").style.display = "none";
    document.getElementById("main").style.marginLeft = "120px";
    jQuery('.w3-sidebar>a').attr('style', '1px solid #c7f4c3 !important;');

}
function closeLeftMenu() {
    document.getElementById("leftMenu").style.marginLeft = "-85px";

    document.getElementById("openButton").style.display = "block";
    document.getElementById("closeButton").style.display = "none";
    document.getElementById("main").style.marginLeft = "35px";
    jQuery('.w3-sidebar>a').attr('style', 'border-bottom: none !important; width:88%;');
    jQuery('#openButton').attr('style', 'width: 30px;height: 30px; margin: 5px 3px 1px 0px;text-align: center;display: block;padding: 5px !important;')
}
function resizeIframe(obj) {

    obj.style.height = obj.contentWindow.document.body.scrollHeight + 10 + 'px';
}

function openNavmenu() {
    var div = document.getElementById("mySidenavmenu");
    if (div.style.width == "300px")
        closeNav();
    else {
        div.style.borderRight = "1px solid rgba(104, 204, 206, 1)";
        div.style.borderRightColor = "rgba(104, 204, 206, 1)";
        div.style.borderRightStyle = "solid";
        div.style.borderRightWidth = "1px";
        div.style.width = "300px";
        document.getElementById("imgMenu").src = "../Image/border4-2.png";
        document.getElementById("imgMenu").title = "Ẩn menu";

    }
}

function closeNav() {
    var div = document.getElementById("mySidenavmenu");
    div.style.width = "0";
    document.getElementById("imgMenu").src = "../Image/border4.png";
    document.getElementById("imgMenu").title = "Hiện menu";
    div.style.borderRight = "0px solid rgba(255, 255, 255, 0)";
    div.style.borderRightColor = "rgb(255, 255, 255)";
    div.style.borderRightStyle = "solid";
    div.style.borderRightWidth = "0px";
}
function DoiMenuTrai(trangduocchon, tenquyen)
{
    var divs = document.getElementsByClassName("divMenuCon");
    for (var i = 0; i < divs.length; i++) {
        var classlist = divs[i].classList;
        var td = document.getElementById("td" + divs[i].id);
        if(divs[i].id == trangduocchon)
        {
            divs[i].classList.add("menuselected");
            td.style.backgroundImage = "url('../Image/border3.png')";
            td.title = tenquyen;
        }
        else
        {
            divs[i].classList.remove("menuselected");
            td.style.backgroundImage = "url('../Image/border5.png')";
            td.title = "";
        }
    }
    window.open(trangduocchon, "container");
}

function openNavmenuUser() {
    var div = document.getElementById("sidenavmenuUser");
    if (div.style.width == "200px")
        closeNavUser();
    else {
        div.style.border = "1px solid rgb(104, 204, 206)";
        div.style.width = "200px";
    }
}

function closeNavUser() {
    var div = document.getElementById("sidenavmenuUser");
    div.style.width = "0";
    div.style.border = "0px solid rgba(255, 255, 255, 0)";
}

function DoiMenuThongKe(trangduocchon, tenquyen) {
    var divs = document.getElementsByClassName("divItemMenu");
    for (var i = 0; i < divs.length; i++) {
        var classlist = divs[i].classList;
        if (divs[i].id == trangduocchon) {
            divs[i].classList.add("divItemMenuSelect");
        }
        else {
            divs[i].classList.remove("divItemMenuSelect");
        }
    }
    window.open(trangduocchon, "container2");
}