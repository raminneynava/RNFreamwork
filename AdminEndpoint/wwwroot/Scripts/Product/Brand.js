$(document).ready(function () {
    $("#dataTable").DataTable({
        "ordering": false,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        },

        ajax: {
            url: '/Brand/GetList',
            dataSrc: '',
            type: "post"
        },
        columns: [
            { title: 'عنوان', data: 'title', "width": "50px" },
            { title: 'وضعیت', data: 'status', "width": "30px" },
            {
                title: 'ابزار',
                data: 'id',
                render: function (data) {
                    return `<div style="display:flex;">
                             <a href="/Brand/Edit/${data}" title="ویرایش"  class="btn btn-info btn-icon"><i class="icofont icofont-info-square"></i></a>
                             <button onclick =DeleteModal("${data}") title="حذف" class="btn btn-danger btn-icon waves-effect md-trigger" data-modal="DeleteModal"><i class="icofont icofont-eye-alt"></i></button>
                             </div>`;
                }, "width": "30px"
            }
        ]
    });
});

function refreshTable() {
    $('#dataTable').DataTable().clear();
    $('#dataTable').DataTable().ajax.reload();
}
function DeleteModal(id) {
    $("#DeleteModal").modal("show");
    $("#DeleteClick").attr("onclick", 'Delete("' + id + '");');
}
function Delete(Id) {
    $.ajax({
        type: "Post",
        data: {
            id: Id
        },
        cashe: false,
        url: '/Brand/Delete',
        success: function (result) {
            if (result) {
                refreshTable();
                $("#DeleteModal").modal("hide");
                notifySuccess("اطلاعات با موفقیت حذف شد")
            } else {
                $("#DeleteModal").modal("hide");
                notifyDanger("حطا در حذف اطلاعات")
            };

            $("#DeleteModal").modal("hide");
        }
    });
}


