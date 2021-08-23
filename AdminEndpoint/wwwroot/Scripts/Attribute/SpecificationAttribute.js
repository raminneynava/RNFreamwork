
$(document).ready(function () {
    $("#dataTable").DataTable({
        "ordering": false,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        },

        ajax: {
            url: '/SpecificationAttribut/GetList',
            dataSrc: '',
            type: "post"
        },
        columns: [
            { title: 'عنوان', data: 'name', "width": "50px" },
            { title: 'ترتیب نمایش', data: 'order', "width": "30px" },
            {
                title: 'ابزار',
                data: 'id',
                render: function (data) {
                    return `<div style="display:flex;">
                             <a href="/SpecificationAttribut/EditGroup/${data}" title="ویرایش"  class="btn btn-grd-inverse">ویرایش</a>
                             <button onclick =DeleteModal("${data}") title="حذف" class="btn btn-grd-inverse" data-modal="DeleteModal">حذف</button>
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
        url: '/SpecificationAttribut/DeleteGroup',
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


