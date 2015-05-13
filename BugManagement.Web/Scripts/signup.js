$('#ulNav').children('li').eq(3).addClass('active');

$('#btnSignup').click(function () {
    $('.red').html('');
    $.ajax({
        url: "/Account/Signup",
        method: 'post',
        data: $('#formSignup').serializeJson(),
        dataType:'json'
    }).done(function(result) {
        if (result.Success) {
            alert('Signup Success');
            window.location.href = '/SignIn/' + $('#txtUsername').val();
        } else {
            for (var i = 0; i < result.Errors.length; i++) {
                var error = result.Errors[i];
                $('[name="' + error.Name + '"]').next('span').html(error.ErrorMessage);
            }
        }
    });
});

$('#txtUsername').blur(function () {
    var username = $('#txtUsername').val();
    if (username !== '') {
        $.ajax({
            url: "/Account/CheckUserName",
            method: 'post',
            data: { username: username },
            dataType: 'json',
            async: false
        }).done(function(result) {
            if (!result.Success) {
                $('#txtUsername').next('span')
                    .html(result.Errors[0].ErrorMessage);
            }
        });
    }
});

