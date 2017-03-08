//draw map - get user location and draw a map there.


var options = {
    enableHighAccuracy: true,
    timeout: 5000,
    maximumAge: 0
};

function success(pos) {
    var crd = pos.coords;

    var latx = crd.latitude;
    var lonx = crd.longitude;
    console.log(latx + " " + lonx);
    $("#longitude").val(crd.longitude);
    $("#latitude").val(crd.latitude);

    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: latx, lng: lonx },
        scrollwheel: false,
        zoom: 8
    });
}
function error(err) {
    console.warn(err.code + ':' + err.message);
    console.log("if you are using chrome it is possible it is blocking access");
}
navigator.geolocation.getCurrentPosition(success,error, options);

function markMap(lat, lon) {
    var myLatLng = { lat: lat, lng: lon };

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 4,
        center: myLatLng
    });

    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map,
        title: 'Hello World!'
    });
}
    