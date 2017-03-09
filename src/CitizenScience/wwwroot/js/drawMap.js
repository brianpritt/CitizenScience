//draw map - get user location and draw a map there.


//get location
var map;
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
    initMap(latx, lonx)
}
function error(err) {
    console.warn(err.code + ':' + err.message);
    console.log("if you are using chrome it is possible it is blocking access");
}
navigator.geolocation.getCurrentPosition(success,error, options);
//End get location//

//draw map//
function initMap(lat, lon) {
    if (lat !== null) {
        var myLatLng = { lat: lat, lng: lon };

        map = new google.maps.Map(document.getElementById('map'), {
            zoom: 10,
            center: myLatLng
        });
    }
}
//end draw map//
//add markers//


function addMarker(pos) {
    if (pos != null) {
        console.log(pos);
        var marker = new google.maps.Marker({
            position: pos,
            map: map,
            title: "title"
        })
    }
}

//Document ready, ajax and mark map
$(document).ready(function () {
    $("#data-form").submit(function (event) {
        event.preventDefault();
        var thisResult = $('#name').attr("value");
        
        $.ajax({
            url: '/Research/Result/',
            type: 'POST',
            data: $(this).serialize(),
            datatype: 'json',
            success: function (result) {
                
                $("#newdata").html(result);
            }
        })
        $.ajax({
            url: '/Research/API/',
            type: 'POST',
            data: $(this).serialize(),
            datatype: 'json',
            success: function (result) {
                
                result.forEach(function(item){
                    var lat = parseFloat(item.faunaLatitude);
                    var lon = parseFloat(item.faunaLongitude);
                    var myLatLng = { lat: lat, lng: lon };
                    addMarker(myLatLng);
                })
            }
        })

        $("#api-call").submit(function(event){
            event.preventDefault();
            var thisResult = $('#api-call').attr("value");
            
            $.ajax({
                url: '/Research/API/',
                type: 'POST',
                data: $(this).serialize(),
                datatype: 'json',
                success: function (result) {
                    console.log(result);
                }
            })
        })
    })
})

