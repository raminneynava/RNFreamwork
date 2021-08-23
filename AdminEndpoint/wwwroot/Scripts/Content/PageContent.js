$(document).ready(function () {
    $("#dataTable").DataTable({
        "ordering": false,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        },

        ajax: {
            url: '/PageContent/GetList',
            dataSrc: '',
            type: "post"
        },
        columns: [
            { title: 'عنوان', data: 'title', "width": "50px" },
            {
                title: 'ابزار',
                data: 'id',
                render: function (data) {
                    return `<div style="display:flex;">
                             <a href="/PageContent/Edit/${data}" title="ویرایش"  class="btn btn-info btn-icon"><i class="icofont icofont-info-square"></i></a>
                             </div>`;
                }, "width": "30px"
            }
        ]
    });
});



