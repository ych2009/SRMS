
var initdata; //初始化下拉框数据


var data;
var detailarray1 = [];
var detailarray2 = [];
var detailcount = 0;
var chartXdata = [];
var piearray = [];
var piedatacount = 0;
var pieXdata = [];
var piejsondata;
var lineworkinfo;

var linecount = 0;
var lineinfoIdArr = [];
var lineinfoNameArr = [];

var productcount = 0;
var productinfoIdArr = [];
var productinfoNameArr = [];


var lineinfoId = 0;
var productinfoId = 0;

function drawChart() {

    var myChart = echarts.init(document.getElementById('chart1'));
    myChart.showLoading();    //数据加载完之前先显示一段简单的loading动画
    //detailcount = data["data2"].length;
    for (var i = 0;i < detailcount;i++)
    {
        detailarray1[i] = data["data2"][i]["finishnum"];
        detailarray2[i] = data["data2"][i]["finishnum"]/1000;
        chartXdata[i] = i + 1;
    }

    // 指定图表的配置项和数据
    var option = {
        title: {    //图表标题
            text: '单位生产曲线/效率'
        },
        tooltip: {
            trigger: 'axis', //坐标轴触发提示框，多用于柱状、折线图中           
        },
        dataZoom: [
            {
                type: 'slider',    //支持鼠标滚轮缩放
                start: 0,            //默认数据初始缩放范围为10%到90%
                end: 100
            },
            {
                type: 'inside',    //支持单独的滑动条缩放
                start: 0,            //默认数据初始缩放范围为10%到90%
                end: 100
            }
        ],
        legend: {    //图表上方的类别显示               
            show: true,
            data: ['件数', '效率']
        },
        color: [
            '#FF3333',    //件数曲线颜色
            '#53FF53'   //效率曲线颜色
        ],
        toolbox: {    //工具栏显示             
            show: true,
            feature: {
                saveAsImage: {}        //显示“另存为图片”工具
            }
        },
        xAxis: {    //X轴           
            type: 'category',
            data: chartXdata    //先设置数据值为空，后面用Ajax获取动态数据填入
        },
        yAxis: [    //Y轴（这里我设置了两个Y轴，左右各一个）
            {
                //第一个（左边）Y轴，yAxisIndex为0
                type: 'value',
                name: '件数',
                /* max: 120,
                min: -40, */
                axisLabel: {
                    formatter: '{value} 件'    //控制输出格式
                }
            },
            {
                //第二个（右边）Y轴，yAxisIndex为1
                type: 'value',
                name: '效率',
                // scale: true,
                axisLabel: {
                    formatter: '{value} %'
                }
            }

        ],
        series: [    //系列（内容）列表                      
            {
                name: '件数',
                type: 'line',    //折线图表示（生成温度曲线）
                tooltip: {
                    trigger: 'axis'
                },
                yAxisIndex: 0,
                smooth: false,
                itemStyle: {

                },
                symbol: 'emptycircle',    //设置折线图中表示每个坐标点的符号；emptycircle：空心圆；emptyrect：空心矩形；circle：实心圆；emptydiamond：菱形                        
                //data: [1, 5, 3, 9, 11, 13, 8, 6, 9, 18, 21, 15]        //数据值通过Ajax动态获取
                //data: [num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12,num13,num14]        //数据值通过Ajax动态获取
                data:detailarray1
            },

            {
                name: '效率',
                type: 'line',
                tooltip: {
                    trigger: 'axis'
                },
                yAxisIndex: 1,
                smooth: false,
                itemStyle: {

                },
                symbol: 'emptyrect',
                //data: [0.5, 0.8, 0.9, 0.75, 0.65, 0.8, 0.5, 0.8, 0.9, 0.75, 0.65, 0.8]
                //data: [num15, num16, num17, num18, num19, num20, num21, num22, num23, num24,num25,num26,num27,num28]        //数据值通过Ajax动态获取
                data: detailarray2
            }

        ]
    };
    myChart.hideLoading();
    myChart.setOption(option);    //载入图表
    window.onresize = function () {
        //重置容器高宽
        myChart.resize();
    };
}

function drawPie() {
    echartsPie = echarts.init(document.getElementById('chart2'));
    var echartsPie;

    for (var i = 0; i < piedatacount; i++) {
        piearray[i] = data["data3"][i]["errorcount"] / data["data3"][i]["totalcount"];
        pieXdata[i] = data["data3"][i]["name"];
    }

    var params = [];
    for (var i = 0; i < piedatacount; i++) {
        var param = [];
        params.push({"value":piearray[i],"name":pieXdata[i]});
    }
    piejsondata = params;
    
    var option = {
        title: {
            text: '各工序故障比',
            subtext: '',
            x: 'center'
        },
        tooltip: {
            trigger: 'item',
            formatter: "{a} <br/>{b} : {c} %"
        },
        legend: {
            orient: 'vertical',
            x: 'left',
            //data: ['1C精车', '挤齿', '2C精车', '3C精车', '倒角', '铣槽', '其他']
            data: pieXdata
        },
        toolbox: {
            show: true,
            feature: {
                mark: {
                    show: true
                },
                dataView: {
                    show: true,
                    readOnly: false
                },
                magicType: {
                    show: true,
                    type: ['pie', 'funnel'],
                    option: {
                        funnel: {
                            x: '25%',
                            width: '50%',
                            funnelAlign: 'left',
                            max: 1548
                        }
                    }
                },
                restore: {
                    show: true
                },
                saveAsImage: {
                    show: true
                }
            }
        },
        calculable: true,
        series: [{
            name: '各工序故障比',
            type: 'pie',
            radius: '50%', //饼图的半径大小
            center: ['50%', '50%'], //饼图的位置
            //data: json
            data: piejsondata
        }]
    };

    echartsPie.setOption(option);
}


function initUI() {
    toastr.options.positionClass = 'toast-top-center ';
    var time = new Date();
    var day = ("0" + time.getDate()).slice(-2);
    var month = ("0" + (time.getMonth() + 1)).slice(-2);
    var today = time.getFullYear() + "-" + (month) + "-" + (day);
    $('#date_info').val(today);

    $.ajax({
        url: '/Home/GetJsonData1',
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
            productcount = initdata["productlist"].length;
                    $('#selectproduct').empty();
                    for (var i = 0; i < productcount; i++) {
                        productinfoIdArr[i] = initdata["productlist"][i]["Id"];
                        productinfoNameArr[i] = initdata["productlist"][i]["name"];
                    }
                    for (var i = 0; i < productcount; i++) {
                        $('#selectproduct').append("<option value=" + productinfoIdArr[i] + ">" + productinfoNameArr[i] + "</option>");
            }       
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            toastr.warning(XMLHttpRequest.status);
        }
    })
    //下拉框选择事件
    $('#selectproduct').change('change', function () {
        productinfoId = this.value;
    });
    $('#selectline').change('change', function () {
        lineinfoId = this.value;
    });
}

function updateUI() {
//更新机械手位置
    var bars = $(".bar");
    if (data["data1"].length == bars.length) {
        for (var i = 0; i < bars.length; i++) {
            var x = data["data1"][i].x;
            var status = data["data1"][i].status;

            var widthTemp = (x).toFixed(1) + '%';
            $(bars[i]).css('width', widthTemp);
            $(bars[i]).text(widthTemp);
            if (status == true) {
                $(bars[i]).css("background", "red");
            }
            else {
                $(bars[i]).css("background", "chartreuse");
            }
        }
    }

//生成曲线
    detailcount = data["data2"].length;
    if (detailcount > 0) {
        drawChart();
    }
//故障比饼图
    piedatacount = data["data3"].length;
    if (piedatacount > 0) {
        drawPie();
    }

//生成完成率、数量、产品型号
    lineworkinfo = data["data4"][0];
    var percent = lineworkinfo["finishnum"] * 100 / lineworkinfo["totalnum"];
    var productname = lineworkinfo["productinfoSetName"];
    var totalnum = lineworkinfo["totalnum"];
    var finishnum = lineworkinfo["finishnum"];
    var remainnumber = totalnum - finishnum;
    $("#finishedpercent").text(percent + "%");
    $("#remainnumber").text(remainnumber);
    $("#finishednum").text(finishnum);
    $("#productname").text(productname);
}

$(document).ready(function () {
    initUI();
    var interval = setInterval(function () {
        productinfoId = $('#selectproduct').val();
        lineinfoId = $('#selectline').val();
        $.ajax({
            url: '/Home/GetJsonData',
            type: 'POST',
            dataType: 'json',
            tradition: true,
            data: { "lineinfoid": lineinfoId, "productinfoSetId": productinfoId},
            success: function (callbackdata) { 
                data = callbackdata;
                updateUI();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                toastr.warning("数据请求失败:"+XMLHttpRequest.status);
            }
        })
    }, 2000);
});

