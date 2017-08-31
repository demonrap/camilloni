$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest('.form-group').addClass('has-error has-danger');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error has-danger');
    }
});