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
                    display: true,
                    text: 'SỐ TÀI KHOẢN ĐĂNG KÝ TRONG NĂM 2022',
                    fontSize: 20,
                    fontFamily: 'Source Sans Pro'
                },
                xAxis: {
                    categories: ['1', '2', '3', '4', '5', '6',
                        '7', '8', '9', '10', '11', '12']
                },
                yAxis: {
                    title: {
                        text: 'Tài khoản',
                        fontFamily: 'Source Sans Pro'
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

    var yValues;
    const endpoint2 = 'https://localhost:44315/api/app/employer/get-number-top3Employer';
    fetch(endpoint2)
        .then(response => response.json())
        .then(data => yValues = data);
    const endpoint1 = 'https://localhost:44315/api/app/employer/get-top3Employer';
    fetch(endpoint1)
        .then(response => response.json())
        .then(function (data) {
            var resultTK = data;
            console.log(yValues);
            var xValues = resultTK;
            //var yValues = yValues;
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
                        text: "TOP 3 NHÀ TUYỂN DỤNG ĐĂNG BÀI NHIỀU NHẤT",
                        fontSize: 20
                    }
                }
            });
        });

    const endpoint3 = 'https://localhost:44315/api/app/c-v/get-number-cV';
    fetch(endpoint3)
        .then(response => response.json())
        .then(function (data) {
            let myChart = document.getElementById('myChart1').getContext('2d');
            // Global Options
            Chart.defaults.global.defaultFontFamily = 'Source Sans Pro';
            Chart.defaults.global.defaultFontSize = 15;
            Chart.defaults.global.defaultFontColor = '#777';

            let massPopChart = new Chart(myChart, {
                type: 'bar', // bar, horizontalBar, pie, line, doughnut, radar, polarArea
                data: {
                    labels: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
                    datasets: [{
                        label: 'Số CV',
                        data: data,
                        //backgroundColor:'green',
                        backgroundColor: [
                            '#7982C6',
                            '#7982C6',
                            '#7982C6',
                            '#7982C6',
                            '#7982C6',
                            '#7982C6',
                            '#7982C6',
                            '#7982C6',
                            '#7982C6',
                            '#7982C6',
                            '#7982C6',
                            '#7982C6'

                        ],
                        borderWidth: 1,
                        borderColor: '#777',
                        hoverBorderWidth: 2,
                        hoverBorderColor: '#000'
                    }]
                },
                options: {
                    title: {
                        display: true,
                        text: 'SỐ CV TRONG NĂM 2022',
                        fontSize: 20
                    },
                    legend: {
                        display: true,
                        position: 'right',
                        labels: {
                            fontColor: '#000'
                        }
                    },
                    layout: {
                        padding: {
                            left: 5,
                            right: 0,
                            bottom: 0,
                            top: 0
                        }
                    },
                    tooltips: {
                        enabled: true
                    }
                }
            });
        });

    

        


});

