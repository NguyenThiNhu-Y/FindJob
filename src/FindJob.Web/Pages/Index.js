$(function () {
    abp.log.debug('Index.js initialized!');
   
    const endpoint = 'https://localhost:44315/api/app/manage-candidate/get-all-user';
    fetch(endpoint)
        .then(response => response.json())
        .then(function (data) {
            var resultTK = data;
            console.log(resultTK);
            Highcharts.chart('chart1', {
                title: {
                    text: 'SỐ TÀI KHOẢN ĐĂNG KÝ TRONG NĂM 2022',
                },
                xAxis: {
                    categories: ['1', '2', '3', '4', '5', '6',
                        '7', '8', '9', '10', '11', '12']
                },
                yAxis: {
                    title: {
                        text: 'Tài khoản'
                    },
                    plotLines: [{
                        value: 0,
                        width: 1,
                        color: '#714BCA'
                    }]
                },
                tooltip: {
                    valueSuffix: 'tài khoản'
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle',
                    borderWidth: 0
                },
                series: [{
                    //data: [0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0]
                    data: resultTK
                }]
            })
        });
    var xValues = ["Italy", "France", "Spain"];
    var yValues = [55, 49, 44];
    var barColors = ["#5E3FBE", "#C6A9FF", "#E4D8FF"];
    new Chart("myChart", {
        type: "pie",
        data: {
            labels: xValues,
            datasets: [{
                backgroundColor: barColors,
                data: yValues
            }]
        },
        options: {
            title: {
                display: true,
                text: "TOP 3 NHÀ TUYỂN DỤNG ĐĂNG BÀI NHIỀU NHẤT"
            }
        }
    });
    //Highcharts.chart('chart1', {
    //    title: {
    //        text: 'SỐ TÀI KHOẢN ĐĂNG KÝ TRONG NĂM 2022',
    //    },
    //    xAxis: {
    //        categories: ['1', '2', '3', '4', '5', '6',
    //            '7', '8', '9', '10', '11', '12']
    //    },
    //    yAxis: {
    //        title: {
    //            text: 'Tài khoản'
    //        },
    //        plotLines: [{
    //            value: 0,
    //            width: 1,
    //            color: '#808080'
    //        }]
    //    },
    //    tooltip: {
    //        valueSuffix: 'tài khoản'
    //    },
    //    legend: {
    //        layout: 'vertical',
    //        align: 'right',
    //        verticalAlign: 'middle',
    //        borderWidth: 0
    //    },
    //    series: [{
    //        data: [0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0]
    //        //data: resultTK
    //    }]
    //});


});

