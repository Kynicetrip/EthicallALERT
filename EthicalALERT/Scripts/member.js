$(function insertMember() {
    $('#create-account').click(function (event) {
        event.preventDefault();
        var id = $('#id').val()
        var name = $('#name').val();
        var email = $('#email').val();
        var password = $('#password').val();
        $.ajax({
            url: '@Url.Action("Home", "AddMember")',,
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(member),
            success: function (data) {
                if (data.success) {
                    alert('Registration successful!');
                    window.location.href = '@Url.Action("Index", "Home")';
                } else {
                    alert('Registration failed. Please try again.');
                }
            },
            error: function (errorMessage) {
                alert('Registration failed!');
                alert(errorMessage.responseText);
            }
        });
    });
});

    getAllMembers(callback) {
        $.ajax({
            url: this.baseUrl + "Home/GetAllMembers",
            type: "GET",
            success: function (data) {
                callback(data);
            }
        });
    }

    getMemberById(id, callback) {
        $.ajax({
            url: this.baseUrl + "Home/GetMemberById/" + id,
            type: "GET",
            success: function (data) {
                callback(data);
            }
        });
    }

    addMember(member, callback) {
        $.ajax({
            url: this.baseUrl + "Home/AddMember",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(member),
            success: function () {
                callback();
            }
        });
    }

    updateMember(member, callback) {
        $.ajax({
            url: this.baseUrl + "Home/UpdateMember",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(member),
            success: function () {
                callback();
            }
        });
    }

    deleteMember(id, callback) {
        $.ajax({
            url: this.baseUrl + "Home/DeleteMember/" + id,
            type: "POST",
            success: function () {
                callback();
            }
        });
    }

