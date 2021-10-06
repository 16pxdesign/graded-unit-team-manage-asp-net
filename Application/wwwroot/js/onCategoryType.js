$(document).ready(function() {

    hideAndShow();

    $('#type').on("change", function () {

        hideAndShow();

    });

    function hideAndShow() {
        var selected = $('#type').find(':selected').text();

        if (selected === "Category") {
            $('#list').hide();
        }else {
            $('#list').show();
        }
    }
    
});