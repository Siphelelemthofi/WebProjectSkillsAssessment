$(document).ready(function () {
    $("#AccountErrorMessage").hide();
    $(function () {
        $("form").submit(function () {
            var AccountNumber = $('#AccountNumber').val();
            if (AccountNumber.length != 8) {
                $("#AccountErrorMessage").show();
                return false;
            }
            else {

                $("#AccountErrorMessage").hide();
            }

        });
    });
}); 