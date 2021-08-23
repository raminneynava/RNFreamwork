$(document).ready(function () {
    $("#dataTable").DataTable({
        "ordering": false,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        },

        ajax: {
            url: '/NewsLetter/GetList',
            dataSrc: '',
            type: "post"
        },
        columns: [
            { title: 'عنوان', data: 'contact', "width": "50px" },
        ]
    });
});

