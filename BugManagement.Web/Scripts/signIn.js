$('#ulNav').children('li').eq(2).addClass('active');

$('#btnSignIn').click(function () {
    $('.red').html('');
    $.ajax({
        url: "/Account/SignIn",
        method: 'post',
        data: $('#formSignIn').serializeJson(),
        dataType: 'json'
    }).done(function (result) {
        if (result.Success) {
            alert('SignIn Success');
            window.location.href = '/Projects';
        } else {
            for (var i = 0; i < result.Errors.length; i++) {
                var error = result.Errors[i];
                $('[name="' + error.Name + '"]').next('span').html(error.ErrorMessage);
            }
            $('#txtPassword').val('');
        }
    });
});