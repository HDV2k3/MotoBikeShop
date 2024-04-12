var userRegistrationData = [/* Dữ liệu lượt đăng ký người dùng từ cơ sở dữ liệu */];
var userRegistrationChartCanvas = document.getElementById("userRegistrationChart").getContext("2d");
var userRegistrationChart = new Chart(userRegistrationChartCanvas, {
    type: 'bar',
    data: {
        labels: /* Nhãn cho các cột */,
        datasets: [{
            label: 'Lượt đăng ký người dùng',
            data: userRegistrationData,
            backgroundColor: 'rgba(75, 192, 192, 0.6)',
            borderColor: 'rgba(75, 192, 192, 1)',
            borderWidth: 1
        }]
    },
    options: {
        responsive: true,
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});