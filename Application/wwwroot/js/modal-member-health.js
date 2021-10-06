$(function () {
    $('#modal-placeholder').on('click', '[data-save="modal-Health"]', function (event) {
        event.preventDefault();
        var placeholderElement = $('#modal-placeholder');
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = new FormData(form.get(0));
        $.ajax({
            url: actionUrl,
            method: 'post',
            data: dataToSend,
            type: 'post',
            processData: false,
            contentType: false,
            success: function (data) {
                var newBody = $('.modal-body', data);
                placeholderElement.find('.modal-body').replaceWith(newBody);

                var isValid = newBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    tableUpdateHealth()
                    placeholderElement.find('.modal').modal('hide');
                }
            },
            error: function (data) {
                alert("error");
            }
        });
    });

    $(document).on('click', 'button[data-toggle="HealthDelete"]', function (event) {
        event.preventDefault();
        var id = $(this).data('deleteid');
        var url = $(this).data('url');

        $.ajax({
            url: url,
            type: 'post',
            cache: false,
            data: {'id': id},
            success: function (data) {
                tableUpdateHealth()
            },
            error: function () {
                alert("Do not deleted");
            }
        });

    });

    $('#modal-placeholder').on('click', '[data-dismiss="modal-Health"]', function (event) {
        event.preventDefault();
        var placeholderElement = $('#modal-placeholder');
        placeholderElement.find('.modal').modal('hide');
    });

});


function tableUpdateHealth() {
    var tableElement = $('#HealthTable');
    var tableUrl = tableElement.data('url');
    $.ajax({
        url: tableUrl,
        type: 'get',
        cache: false,
        data: {table: "Health"},
        success: function (table) {
            var tableElement = $('#HealthTable');
            tableElement.replaceWith(table);
        },
        error: function () {
            alert("Problem with page refresh");
        }
    });


}
