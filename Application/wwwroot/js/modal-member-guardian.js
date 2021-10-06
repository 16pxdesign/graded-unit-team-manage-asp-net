$(function () {
    $('#modal-placeholder').on('click', '[data-save="modal-Guardian"]', function (event) {
        event.preventDefault();
        var placeholderElement = $('#modal-placeholder');
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = new FormData(form.get(0));
        event.preventDefault();
        $.ajax({
            url: actionUrl,
            method: 'post',
            data: dataToSend,
            type: 'post',
            cashe: false,
            processData: false,
            contentType: false,
            success: function (data) {
                var newBody = $('.modal-body', data);
                placeholderElement.find('.modal-body').replaceWith(newBody);

                var isValid = newBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    tableUpdateGuardian();
                    placeholderElement.find('.modal').modal('hide');
                }
            },
            error: function (xhr, textStatus, errorThrown) {
                alert("error: No controller response \n" + (errorThrown ? errorThrown : xhr.status));
            }
        });
    });

    $(document).on('click', 'button[data-toggle="GuardianDelete"]', function (event) {
        event.preventDefault();
        var id = $(this).data('deleteid');
        var url = $(this).data('url');

        $.ajax({
            url: url,
            type: 'post',
            cache: false,
            data: {'id': id},
            success: function (data) {
                tableUpdateGuardian()
            },
            error: function () {
                alert("Do not deleted");
            }
        });

    });

    $('#modal-placeholder').on('click', '[data-dismiss="modal-Guardian"]', function (event) {
        event.preventDefault();
        var placeholderElement = $('#modal-placeholder');
        placeholderElement.find('.modal').modal('hide');
    });

});


function tableUpdateGuardian() {
    var tableElement = $('#GuardianTable');
    var tableUrl = tableElement.data('url');
    $.ajax({
        url: tableUrl,
        type: 'get',
        cache: false,
        data: {table: "Guardian"},
        success: function (table) {
            var tableElement = $('#GuardianTable');
            tableElement.replaceWith(table);
            console.log(table);
        },
        error: function () {
            alert("Problem with page refresh");
        }
    });


}
