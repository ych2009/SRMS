var data;
var devicecount = 0;

var lineinfoId = 0;
var linecount = 0;
var lineinfoIdArr = [];
var lineinfoNameArr = [];


function initUI() {
    $.ajax({
        url: '/deviceworkinginfoSets/GetJsonData1',
        type: 'POST',
        dataType: 'json',
        tradition: true,
        //data: { "lineinfoid": lineinfoId, "productinfoSetId": productinfoId },
        success: function (callbackdata) {
            initdata = callbackdata;
            //生产线下拉框
            linecount = initdata["linelist"].length;
            $('#selectline').empty();
            for (var i = 0; i < linecount; i++) {
                lineinfoIdArr[i] = initdata["linelist"][i]["Id"];
                lineinfoNameArr[i] = initdata["linelist"][i]["name"];
            }
            //lineinfoId.toString() == lineinfoIdold.toString()
            for (var i = 0; i < linecount; i++) {
                $('#selectline').append("<option value=" + lineinfoIdArr[i] + ">" + lineinfoNameArr[i] + "</option>");
            } 
            lineinfoId = $('#selectline').val();
            createTable();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            toastr.warning("数据请求失败:" + XMLHttpRequest.status);
        }
    })      
}

function changelines() {
    lineinfoId = $('#selectline').val();
    createTable();
}

function createTable() {
    $.ajax({
        url: '/deviceworkinginfoSets/GetJsonData',
        type: 'POST',
        dataType: 'json',
        tradition: true,
        data: { "lineinfoid": lineinfoId },
        success: function (callbackdata) {
            data = callbackdata["deviceworkinginfo"];
            devicecount = data.length;
            $('#tablehead').empty();
            $("#tablebody").empty();
            //添加thead>tr
            var theadtr = document.createElement("tr");
            theadtr.id = "coltitle";
            $("#tablehead").append(theadtr);
            for (var i = 0; i < 5; i++) {
                var tbodytr = document.createElement("tr");
                tbodytr.id = "row" + (i + 1).toString();
                $("#tablebody").append(tbodytr);
            }
            for (var i = 0; i <= devicecount; i++) {
                var th = document.createElement("th");
                if (i == 0) {
                    var devicename = "";
                    th.innerHTML = devicename;
                }
                else {
                    var index=i-1
                    var devicename = data[index]["name"];
                    th.innerHTML = devicename;
                }
                $("#coltitle").append(th);
                for (var j = 0; j < 5; j++) {
                    {
                        var td = document.createElement("td");
                        var rowid = "row" + (j + 1).toString();
                        var colid = i.toString() + j.toString();
                        td.id = colid;
                        var p = document.createElement("p");
                        p.id = "p" + colid;
                        //p.className = "p1";
                        if (i == 0) {
                            td.className = "rowtitle"
                            if (j == 0) {
                                p.innerHTML = "设备启动";
                                p.className = "rowtitlep";
                            }
                            if (j == 1) {
                                p.innerHTML = "正在加工";
                                p.className = "rowtitlep";
                            }
                            if (j == 2) {
                                p.innerHTML = "加工完成";
                                p.className = "rowtitlep";
                            }
                            if (j == 3) {
                                p.innerHTML = "设备报警";
                                p.className = "rowtitlep";
                            }
                            if (j == 4) {
                                p.innerHTML = "报警总数";
                                p.className = "rowtitlep";
                            }
                        }
                        if (i > 0) {
                            if (j == 0) {
                                //p.innerHTML = "运行中...";
                                p.className = "p1";
                            }
                            if (j == 1) {
                                //p.innerHTML = "正在加工";
                                p.className = "p2";
                            }
                            if (j == 2) {
                               // p.innerHTML = "加工完成";
                                p.className = "p3";
                            }
                            if (j == 3) {
                               // p.innerHTML = "报警中...";
                                p.className = "p4";
                            }
                            if (j == 4) {
                               // p.innerHTML = "1000";
                                p.className = "p5";
                            }
                        }
                        $("#" + rowid).append(td);
                        $("#" + colid).append(p);
                    }
                }
            }
            //updateUI();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            toastr.warning("数据请求失败:" + XMLHttpRequest.status);
        }
    })
}
function updateTable() {
    $.ajax({
        url: '/deviceworkinginfoSets/GetJsonData',
        type: 'POST',
        dataType: 'json',
        tradition: true,
        data: { "lineinfoid": lineinfoId },
        success: function (callbackdata) {
            data = callbackdata["deviceworkinginfo"];
            devicecount = data.length;
            if (devicecount > 0) {
                for (var i = 0; i < 5; i++) {
                    for (var j = 0; j < devicecount; j++) {
                        var cellId = "p" + (j + 1).toString() + i.toString();
                        if (i == 0) {
                            var isruning = data[j]["isrunning"];
                            if (isruning == true) {
                                $("#" + cellId).text("运行中...")
                                $("#" + cellId).css("background", "green");
                            }
                            else {
                                $("#" + cellId).text("未启动")
                                $("#" + cellId).css("background", "darkorange");
                            }
                        }

                        if (i == 1) {
                            var runningstatus = data[j]["runningstatus"];
                            if (runningstatus == true) {
                                $("#" + cellId).text("正在加工")
                                $("#" + cellId).css("background", "green");
                            }
                            else {
                                $("#" + cellId).text("等待加工")
                                $("#" + cellId).css("background", "darkorange");
                            }
                        }

                        if (i == 2) {
                            var runningstatus = data[j]["isfinished"];
                            if (runningstatus == true) {
                                $("#" + cellId).text("加工完成")
                                $("#" + cellId).css("background", "green");
                            }
                            else {
                                $("#" + cellId).text("等待完成")
                                $("#" + cellId).css("background", "darkorange");
                            }
                        }
                        if (i == 3) {
                            var warning = data[j]["iswarning"];
                            if (warning == true) {
                                $("#" + cellId).text("正常")
                                $("#" + cellId).css("background", "green");
                            }
                            else {
                                $("#" + cellId).text("报警中...")
                                $("#" + cellId).css("background", "red");
                            }
                        }
                        if (i == 4) {
                            var errorcount = data[j]["errorcount"];
                            $("#" + cellId).text(errorcount)
                            $("#" + cellId).css("background", "white");
                        }
                    }
                }
            }
            else {
                toastr.warning("数据请求失败:400");
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            toastr.warning("数据请求失败:" + XMLHttpRequest.status);
        }
    })
}

function updateUI() {
    //createTable();
}


$(document).ready(function () {
    //下拉框选择事件
    $('#selectline').change('change', function () {
        lineinfoId = this.value;
        changelines();
    }); 
    initUI();
    var interval = setInterval(function () {
        lineinfoId = $('#selectline').val();
        updateTable();
    }, 2000);
});
