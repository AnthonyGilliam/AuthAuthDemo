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

    $.validator.addMethod("requiredwhennot", function (value, element, parameters) {
        var depCtrlName = parameters["dependingonproperty"];
        var $depCtrl = $("#" + depCtrlName);
        var depVal = $depCtrl.is(":checkbox")
            ? $depCtrl.filter(":checked").val()
            : $depCtrl.val();
        var notEqualToVal = typeof parameters["notequalto"] === "undefined" || parameters["notequalto"] === null
            ? ""
            : parameters["notequalto"];
        depVal = typeof depVal === "undefined" || depVal === null
            ? ""
            : depVal;

        if (notEqualToVal.toLowerCase() !== depVal.toString().toLowerCase()) {
            return $.validator.methods["required"].call(this, value, element, parameters);
        }
        return true;
    });

    $.validator.unobtrusive.adapters.add("requiredwhennot", ["dependingonproperty", "notequalto"],
        function (options) {
            options.rules["requiredwhennot"] = {
                dependingonproperty: options.params["dependingonproperty"],
                notequalto: options.params["notequalto"]
            };
            options.messages["requiredwhennot"] = options.message;
    });
})(jQuery);
