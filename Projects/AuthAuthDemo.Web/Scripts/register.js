AuthAuth = {}; //MemberSuit Interview Test
AuthAuth.register = (function ($) {
    //Get MD5 Hashed value for passed in string
    function getMD5Hash(string) {
        var jsontestMD5Url = "http://md5.jsontest.com/";
        var queryString = "?text=";
        var request = jsontestMD5Url + queryString + string;

        return $.get(request);
    };

    var registerUser = function (firstName, lastName, email, password) {
        var emailHash;
        var passwordHash;

        $.when(getMD5Hash(email), getMD5Hash(password))
            .done(function (emailData, passwordData) {
                emailHash = emailData[0].md5;
                passwordHash = passwordData[0].md5;
                alert('Email:  ' +  email + '\nMD5 Hash Code:  ' + emailHash + '\n\nPassword:  ' + password + '\nMD5 Hash Code:  ' + passwordHash);
            }).fail(function () {
                alert('Sorry, jsontest.com is not working right now.  ' + 
                    'Email and Password hash codes could not be generated.  Please try again later');
            }).always(function () {
                if ($('#register_form').validate())
                    antiForgeryToken = $('input[name=__RequestVerificationToken]').val();
                    $.post('/Account/Register',
                        {
                            __RequestVerificationToken: antiForgeryToken,
                            FirstName: firstName,
                            LastName: lastName,
                            Email: email,
                            Password: password,
                        }).done(function (results) {
                            if (results.success) {
                                window.location.href = '/Home/ShowUsers';
                            } else {
                                $('.validation-summary-valid ul').html('');
                                $(results.errors).each(function (index, error) {
                                    $('.validation-summary-valid ul').append('<li>' + error + '</li>')
                                });
                            }
                        }).fail(function () {
                            $('.validation-summary-valid ul').html('<li>Sorry, we cannot register as a user at this time.  Please try again later</li>');
                        });
            });
    }

    return { registerUser:registerUser };
})(jQuery);

(function ($) {
    $('#submit').on('click', function (event) {
        event.preventDefault();

        var firstName = $('#FirstName').val();
        var lastName = $('#LastName').val();
        var email = $('#Email').val();
        var password = $('#Password').val();

        AuthAuth.register.registerUser(firstName, lastName, email, password);
    });
})(jQuery);