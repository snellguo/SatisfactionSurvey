/// <reference path="../lib/jquery/dist/jquery-1.12.4.js" />
/// <reference path="../lib/layer/layer.js" />
/// <reference path="../lib/jquery-grid/js/jquery.jqGrid.js" />


"use strict";


function forIn(obj, handler) {
    for (var i in obj) {
        if (obj.hasOwnProperty(i)) {
            handler(i, obj[i]);
        }
    }
}
function each(arr, handler) {
    for (var i = 0, len = arr.length; i < len; i += 1) {
        handler(i, arr[i]);
    }
}
if (!JSON) {
    JSON = {};
}
if (!JSON.parse) {
    JSON.parse = function (json) {
        return eval('1,' + json)
    };
}
if (!JSON.stringify) {
    (function (JSON) {
        var arr = '[object Array]',
			obj = '[object Object]';

        JSON.stringify = function (json) {
            var t = '';
            var m = Object.prototype.toString.call(json);
            if (m === arr) {
                t = ArrPartten(json);
            } else if (m === obj) {
                t = ObjectJson(json);
            } else {
                t = json;
            }
            return t;
        }

        function ObjectParse() {
            var t = '{';
            forIn(json, function (i, ele) {
                var m = Object.prototype.toString.call(ele);
                if (m === arr) {
                    t += i + ':' + ArrPartten(ele) + ',';
                } else if (m === obj) {
                    t += i + ':' + ObjectJson(ele) + ',';
                } else {

                    t += i + ':' + ele + ',';
                }
            });
            if (t.length !== 1) {
                t = t.substring(0, t.length - 1);
            }
            return t + '}';
        }

        function ArrayParse() {
            var t = '[';
            each(json, function (i, ele) {
                var m = Object.prototype.toString.call(ele);
                if (m === arr) {
                    t += ArrPartten(ele) + ',';
                } else if (m === obj) {
                    t += ObjectJson(ele) + ',';
                } else {
                    t += ele + ',';
                }
            });
            if (json.length > 0) {
                t = t.substring(0, t.length - 1);
            }
            return t + ']';
        }
    }(JSON));
}



//Array.prototype.clone = function () {
//    var len = this.lenght,
//        arr = [];

//    for (var i = 0; i < len; i++) {
//        if (typeof this[i] !== "object") {
//            arr.push(this[i]);
//        } else {
//            arr.push(this[i].clone());
//        }
//    }
//    return arr;
//}





//获取url中的参数
var UrlParam = function getUrlParam(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象
    var r = window.location.search.substr(1).match(reg);  //匹配目标参数
    if (r != null) return unescape(r[2]); return null; //返回参数值
}


var swapItems = function (arr, index1, index2) {
    arr[index1] = arr.splice(index2, 1, arr[index1])[0];
    return arr;
};

//秒转天,时,分,秒
function formatDHMS(a) {
    var hms = parseInt(a);

    var seconds = hms % 60;
    var minutes = parseInt(hms / 60 % 60);
    var hours = parseInt(hms / 3600 % 24);
    var days = parseInt(hms / 86400);

    return {
        days: days,
        hours: hours,
        minutes: minutes,
        seconds: seconds
    }
}

var Smart = {};

Smart.UrlParam = UrlParam;

//秒转天,时,分,秒
Smart.formatDHMS = formatDHMS;

// 交换数组元素
// 上移
Smart.upRecord = function (arr, index) {
    if (index == 0) {
        return;
    }
    swapItems(arr, index, index - 1);
};

// 下移
Smart.downRecord = function (arr, index) {
    if (index == arr.length - 1) {
        return;
    }
    swapItems(arr,index, parseInt(index) + 1);
};


Date.prototype.format = function (format) {
    if (isNaN(this)) return '';
    var o = {
        'M+': this.getMonth() + 1,
        'd+': this.getDate(),
        'H+': this.getHours(),
        'm+': this.getMinutes(),
        's+': this.getSeconds(),
        'S': this.getMilliseconds(),
        'W': ["日", "一", "二", "三", "四", "五", "六"][this.getDay()],
        'q+': Math.floor((this.getMonth() + 3) / 3)
    };
    if (format.indexOf('am/pm') >= 0) {
        format = format.replace('am/pm', (o['H+'] >= 12) ? '下午' : '上午');
        if (o['H+'] >= 12) o['H+'] -= 12;
    }
    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }
    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}


//表格
Smart.jqGrid = {
    load: function (config) {
        var obj = config.id ? $("#" + config.id) : $("#table_list");
        obj.jqGrid({
            caption: config.title,   //标题
            url: config.url,
            mtype: "POST",
            styleUI: "Bootstrap",
            datatype: "local",
            colNames: config.colNames,
            colModel: config.colModel,
            viewrecords: true,
            multiselect: config.multiselect,
            multiboxonly: config.multiboxonly ? config.multiboxonly : null,
            rownumbers: true,

            autowidth: config.autowidth!=null ? config.autowidth : true,
            shrinkToFit: config.shrinkToFit != null ? config.shrinkToFit : true,

            height: config.height ? config.height : "100%",
            width: config.width ? config.width : null,
            rowList: [10, 30, 50],
            rowNum: config.rowNum ? config.rowNum : 10,
            rownumWidth: 35,
            sortname: config.sortname,
            sortorder: config.sortorder,
            emptyrecords: "没有相关数据",
            ajaxGridOptions: { url: config.url, type: "POST", contentType: "application/json; charset=utf-8" },
            serializeGridData: function (postData) {
                return JSON.stringify(postData);
            },
            jsonReader: {
                repeatitems: false,     //使用非标准的格式填充
                page: "pageIndex"         //页码
            },

            loadComplete: config.loadComplete ? config.loadComplete : function (n) {
                n && n.code === 401 && console.log(n.msg)
            },
            loadError: function (n, t, i) {
                console.log(n);
                console.log(t);
                console.log(i)
            },
            pager: config.pagerId ? "#" + config.pagerId : "#pager_list",
            subGrid: config.subGrid ? true : false,
            subGridRowExpanded: config.subGridRowExpanded ? config.subGridRowExpanded : null,
            gridComplete: config.gridComplete ? config.gridComplete : null,


            cellEdit: config.cellEdit ? config.cellEdit : false,
            cellsubmit: config.cellsubmit ? config.cellsubmit : "remote",    // 'remote',
            cellurl: config.cellurl ? config.cellurl : "",
            // treeGrid: true,
            //treeGridModel: "adjacency",
            //ExpandColumn:"name",
            //treeIcons: { leaf: 'ui-icon-document-b' },

            beforeSelectRow: config.beforeSelectRow ? config.beforeSelectRow : null,
            onSelectRow: config.onSelectRow ? config.onSelectRow : null,
            onSelectAll: config.onSelectAll ? config.onSelectAll : null,

        });
        $(window).on("resize", function () {
            var n = $(".jqGrid_wrapper").width();
            obj.setGridWidth(n)

        })
    }
};



//layer.config({
//    extend: ['skin/default/style.css'], //加载新皮肤
//    skin: 'layer-ext-default' //一旦设定，所有弹层风格都采用此主题。
//});

//数据
Smart.AjaxPost = function (url, data, callback) {
    $.ajax({
        type: "POST",
        url: url,
        data: data,
        dataType: "json",
        success: function (data) {
            callback(data);
        },
        error: function (data) {
            console.log(JSON.stringify(data));
        }
    });
}
Smart.AjaxGet = function (url, data, callback) {
    $.ajax({
        type: "GET",
        url: url,
        data: data,
        dataType: "json",
        success: function (data) {
            callback(data);
        },
        error: function (data) {
            console.log(JSON.stringify(data));
        }
    });
}
Smart.AjaxObject = function (url, data, callback) {
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),//MVC4
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            callback(data);
        },
        error: function (data) {
            console.log(JSON.stringify(data));
        }
    });
}




//弹框
Smart.dialog = {
    open: function (title, url, width, height, callback) {
        return parent.layer.open({
            type: 2,//iframe
            title: title,
            shadeClose: true,
            shade: 0.8,
            area: [width, height],
            content: encodeURI(url),
            maxmin: true,
            moveType: 1,
            end: callback
        });
    },
    msg: function (msg) {
        return parent.layer.msg(msg);
    },
    loading: function (msg) {
        return parent.layer.msg(msg, {
            icon: 16, shade: 0.1,time:6000*1000
        });
    },
    close: function (index) {
        parent.layer.close(index);
    },
    closeAll: function () {
        parent.layer.closeAll();
    },
    confirm: function (content, options, yes, cancel) {
        return parent.layer.confirm(content, options, yes, cancel)
    },
    prompt: function (options,yes) {
        return parent.layer.prompt(options, yes);
    }
}




