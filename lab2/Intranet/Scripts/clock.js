function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();
    // add a zero in front of numbers<10
    m = checkTime(m);
    s = checkTime(s);

    var day = today.getDate();
   
    var mon = today.getMonth();
    var year = today.getYear();
    year = (year < 1000) ? year + 1900 : year;
    document.getElementById('clock').innerHTML = year + '/' + mon + '/' + day + '--' + h + ":" + m + ":" + s;
    p = document.getElementById('bigclock');
    if(p!==null) document.getElementById('bigclock').innerHTML = year + '/' + mon + '/' + day + '--' + h + ":" + m + ":" + s;
    t = setTimeout(function () {
        startTime()
    }, 500);
}
function checkTime(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}