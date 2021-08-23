var myEditor = null;
$(function () {
    //html editor
    setCkEditor();

    $("#btnGetData").click(function () {
        $("#txtData").val(myEditor.getData());
    });
    $("#btnSetData").click(function () {
        myEditor.setData($("#txtData").val());
    });
});
function setCkEditor() {
    ClassicEditor
        .create(document.querySelector("#ckeditor"), {
            Language: 'fa', //Set language
            Toolbar: { //Set the toolbar
                items: [
                    'heading',
                    '|',
                    'bold',
                    'italic',
                    'link',
                    'bulletedList',
                    'numberedList',
                    'imageUpload',
                    'blockQuote',
                    'insertTable',
                    'mediaEmbed',
                    'undo',
                    'redo'
                ]
            },
            Ckfinder: { //Set the upload path
                uploadUrl: '/Home/UploadCKEditorImage'
}
            })
            .then(editor => {
    myEditor = editor;
})
    .catch(error => {
        console.error(error);
    });
}
