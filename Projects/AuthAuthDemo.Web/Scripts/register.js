(function ($) {
    $('#registerForm').validate({
        debug: true,
        submitHandler: function(form) {
            $.post('/Account/Register', $(form).serialize())
                .done(function (results) {
                    if (results.success == true)
                        window.location.href = '/Home/ShowUsers';
                    else {
                        $('.validation-summary-valid ul').html('');
                        $(results.errors).each(function (index, error) {
                            $('.validation-summary-valid ul').append('<li>' + error + '</li>');
                        });
                    }
                })
                .fail(function () {
                    $('.validation-summary-valid ul').html('<li>Sorry, we cannot register as a user at this time.  Please try again later</li>');
                });
        }
    });
})(jQuery);