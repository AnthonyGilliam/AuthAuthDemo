AuthAuth = {
    formErrorMessage: "Sorry, we cannot register you at this time.  Please try again later."
};

(function($) {
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').removeClass('has-success').addClass('has-feedback has-error');
            $(element).next('.form-control-feedback').show().removeClass('glyphicon-ok').addClass('glyphicon glyphicon-remove');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
            $(element).next('.form-control-feedback').removeClass('glyphicon-remove').addClass('glyphicon-ok');
        }
    });
})(jQuery);
