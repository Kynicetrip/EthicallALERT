$(function insertMember() {
    $('#create-account').click(function (event) {
        event.preventDefault();
        var id = $('#id').val()
        var name = $('#name').val();
        var email = $('#email').val();
        var password = $('#password').val();
        $.ajax({
            type: 'POST',
            url: '@Url.Action("Home", "AddMember")',
            data: { Id: id,Name: name, Email: email, Password: password },
        
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
