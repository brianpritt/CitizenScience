$(document).ready(function () {
    if ("geolocation" in navigator) {
        console.log("location present");
        var options = {
            enableHighAccuracy: true,
            timeout: 5000,
            maximumAge: 0
        };

        function success(pos) {
            var crd = pos.coords;
            console.log("success");
            
          
            console.log(`Lat:` + crd.latitude);
            console.log(`Long:` + crd.longitude);

            $("#longitude").val(crd.longitude);
            $("#latitude").val(crd.latitude);
 
        }

        function error(err) {
            console.warn(`ERROR(${err.code}): ${err.message}`);
            console.log("if you are using chrome it is possible it is blocking access")
        }

        navigator.geolocation.getCurrentPosition(success, error, options);
    }
    else {
        console.log("no location data, maybe change browser settings");
    }
});