$(function () {
    $(document).on('click', 'button[data-toggle="ajax-modal"]', function (event) {
        event.preventDefault();
        var placeholderElement = $('#modal-placeholder');
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });
});
