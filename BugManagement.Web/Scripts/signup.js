$('#btnSignup').click(function() {
    $.ajax({
        url: "/Account/Signup",
        method: 'post',
        data: $('#formSignup').serializeJson(),
        dataType:'json'
    }).done(function(result) {
        
    }).fail(function() {});
});