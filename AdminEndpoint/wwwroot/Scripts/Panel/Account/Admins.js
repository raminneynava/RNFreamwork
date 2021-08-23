$(document).ready(function () {
    $("#usertable").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        },
        ajax: {
            url: '/User/GetAllAdmins',
            dataSrc: '',
            type: "post"
        },
        columns: [
            { title: 'نام کاربری', data: 'userName', "width": "50px" },
            { title: 'شماره تماس', data: 'phoneNumber', "width": "30px" },
            { title: 'ایمیل', data: 'email', "width": "30px" },
            {
                title: 'ابزار',
                data: 'id',
                render: function (data) {
                    return `<div style="display:flex;">
                             <button href = "/Admin/UserManage/EditUser/${data}" onclick =DeleteModal("${data}") title="ویرایش" class="btn btn-info btn-icon"><i class="icofont icofont-info-square"></i></button>
                             <button onclick =DeleteModal("${data}") title="حذف" class="btn btn-danger btn-icon waves-effect md-trigger" data-modal="DeleteModal"><i class="icofont icofont-eye-alt"></i></button>
                             </div>`;
                }, "width": "30px"
            }
        ]
    });
});
function InsertModal() {
    $("#BodyModal").modal("show");
    $("#modal-body").load("/User/Insert")
}
function DeleteModal(id) {
    $("#DeleteModal").addClass("md-show");
    $("#DeleteClick").attr("onclick", 'Delete("' + id + '");');
}
function cancelModal(){
    $("#DeleteModal").modal("hide").removeClass("md-show");
}
function Delete(Id) {
    $.ajax({
        type: "Post",
        data: {
            id: Id
        },
        cashe: false,
        url: '/User/DeleteUser/',
        success: function (result) {
            if (result) {
                refreshTable();
                $("#DeleteModal").modal("hide");
            } else {
                $("#DeleteModal").modal("hide");
            };

            $("#DeleteModal").modal("hide");
        }
    });
}
function refreshTable() {
    $('#usertable').DataTable().clear();
    $('#usertable').DataTable().ajax.reload();
}
