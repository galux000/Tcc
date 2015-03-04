$(document).ready(function () {
    $("#isFree").change(function () {
        if ($("#isFree").prop("checked")) {
            $("#Preco").prop("disabled", "disabled");
        } else {
            $("#Preco").prop("disabled", "");
        }
    });
});

$(function () {
    $('#file_upload').uploadify({
        'swf': "@Url.Content('~/Scripts/uploadify.swf')",
        'cancelImg': "@Url.Content('~/Content/Uploadify/uploadify-cancel.png')",
        'uploader': "@Url.Action('Upload', 'Music')",
        'onUploadSuccess': function (file, data, response) {
            $("#path").val(data);
            // $("#uploaded").append("<img src='" + data + "' alt='Uploaded Image' />");
        }
});
});