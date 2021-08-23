var catid = $("#CatId").val();
var Catlevel = $("#level").val();
if (catid == "") {
    catid = null;
}
$(document).ready(function () {
    debugger
    $("#dataTable").DataTable({
        "ordering": false,
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        },
        ajax: {
            url: '/ProductCat/GetList/' + catid,
            dataSrc: '',
            type: "post"
        },
        columns: [
            { title: 'عنوان', data: 'title', "width": "50px" },
            { title: 'دسته اصلی', data: 'parentTitle', "width": "30px" },
            { title: 'وضعیت', data: 'status', "width": "30px" },
            {
                title: 'ابزار',
                data: 'id',
                render: function (data) {
                    if (Catlevel == 0) {
                        return `<div style="display:flex;">
                             <a href="/ProductCat/Edit/${data}" title="ویرایش"  class="btn btn-grd-inverse">ویرایش</a>
                             <a href="/CategoryAttribute/List/${data}" title="ویژگی ها"  class="btn btn-grd-inverse">ویژگی ها</a>
                             <button onclick =DeleteModal("${data}") title="حذف" class="btn btn-grd-inverse" data-modal="DeleteModal">حذف</button>
                             <a href="/ProductCat/list/${data}" class="btn btn-grd-inverse ">زیر دسته بندی</a>
                             </div>`;
                    } else {
                        return `<div style="display:flex;">
                             <a href="/ProductCat/Edit/${data}" title="ویرایش"  class="btn btn-grd-inverse">ویرایش</a>
                             <a href="/CategoryAttribute/List/${data}" title="ویژگی ها"  class="btn btn-grd-inverse">ویژگی ها</a>
                             <button onclick =DeleteModal("${data}") title="حذف" class="btn btn-grd-inverse" data-modal="DeleteModal">حذف</button>
                             </div>`;
                    }

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
        url: '/ProductCat/Delete',
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
function cancelModal() {
    $("#DeleteModal").modal("hide").removeClass("md-show");
    $("#modal").modal("hide").removeClass("show");
    $("#addtolist").attr('class', 'btn btn-primary btn-round');
}


