$(document).ready(function () {
    $("#selectForm").submit(function (event) {
        event.preventDefault();
        var formChoice = $("#chooseForm").val();
        console.log(formChoice);
        if (formChoice === "fauna") {
            console.log("hello");
            $.ajax({
                url: '/Collection/SelectForm',
                type: 'POST',
                success: function (result) {
                    console.log(result);
                    $("#collection-form").html("Hello:");
                }
            })
            
        }
        else {
            console.log("nope")
        }
    });

});
