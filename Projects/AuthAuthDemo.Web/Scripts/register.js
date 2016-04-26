var register = (function($) {
    function success(data, status) {
        if (status && status === "success") {
            window.location.assign("/Home/ShowUsers");
        } else if (data && data.indexOf("field-validation-error") > -1) {
            var $errors = $(".field-validation-error");
            $errors.closest(".form-group").addClass("has-feedback has-error");
            $errors.prev(".form-control-feedback").show().removeClass("glyphicon-ok").addClass("glyphicon glyphicon-remove");
        }
    }
    function failure() {
        if (!$(".validation-summary-errors").length) {
            $("<div />").addClass("validation-summary-errors text-danger").insertBefore($("#registerForm"));
        }
        $(".validation-summary-errors").html("<ul><li>" + AuthAuth.formErrorMessage + "</li></ul>");
    }
    return { onSuccess:success, onFailure:failure };
})(jQuery);