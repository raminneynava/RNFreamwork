$(document).ready(function () {
    $("#usertable").DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Persian.json"
        },
        ajax: {
            url: '/User/GetAllUsers',
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
                    return `<div class="txt-center">
                                    <a href = "/Admin/UserManage/EditUser/${data}" data-toggle="tooltip"  title="ویرایش" class="btn btn-outline-primary btn-sm" style="cursor:pointer;width:35px;" >
                                        <i class="fa fa-pencil-square-o"></i>
                                    </a>
                                      &nbsp
                                    <a onclick =DeleteModal("${data}") title="حذف" class="btn btn-outline-danger btn-sm" style="cursor:pointer;width:35px;" >
                                        <i class="fa fa-trash"></i>
                                    </a>
                                </div>
                                `;
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
