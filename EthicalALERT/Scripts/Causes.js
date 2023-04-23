$(function insertCause() {
    $('#Create-cause').click(function (event) {
        event.preventDefault();
        var inputObj = {
            Id: $("#id").val(response.nextId),
            Name: $('#causeName').val(),
            Description: $('#causeDescription').val()
        }

        $.ajax({
            url: "/Home/PostCause",
            data: JSON.stringify(inputObj),
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                // handle success
                console.log("Cause added successfully");
                alert("cause added successfully")
            },
            error: function (errorMessage) {
                // handle error
                alert(errorMessage.responseText);
            }
        });
    });
});
