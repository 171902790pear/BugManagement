$('#btnSignup').click(function() {
    $.ajax({
        url: "/Account/Signup",
        method: 'post',
        data: $('#formSignup').serializeJson(),
        dataType:'json'
    }).done(function(result) {
        
    });
});

$('#txtUsername').blur(function() {
    $.ajax({
        url: "/Account/CheckUserName",
        method: 'post',
        data: { username: $('#txtUsername').val()},
        dataType: 'json'
    }).done(function (result) {
        if (!result.Success) {
            $('#txtUsername').next('span')
                .html(result.Errors[0].ErrorMessage);
        }
    });
});