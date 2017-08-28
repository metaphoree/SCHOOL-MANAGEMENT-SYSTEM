
    $(document).ready(function () {

        $('.selectpicker').selectpicker({

        }); 



    var fileUpload = $('#imageUploadForm');
        var alertMess = $('#alertMessage');
        var showImage = $('#imageContainer');
        $('#imageUploadForm').change(function (event) {

            if (window.FormData !== undefined) {

                var message = singleFileSelected(event);

                if (message == "FileOk") {
        alertMess.html("");
    ///////////////////////
    var fileUploady = ($(fileUpload))[0].files[0];
                    var reader = new FileReader();
                    reader.onload = function (e) {

        $("#imageContainer").empty();
    var dataURL = reader.result;
                        var img = new Image()
                        img.src = dataURL;
                        img.className = "thumb";
                        img.height = 200;
                        img.width = 200;

                        $("#imageContainer").append(img);
                    };
                    reader.readAsDataURL(fileUploady);


                    ////////////////////
                    var formData = new FormData();


                    //var file = document.getElementById("imageUploadForm").files[0];
                    var file = fileUploady;
                    formData.append("imageUploadForm", file);
                    // var fileName = Path.GetFileName(file.FileName);

                    $.ajax({
        type: "POST",
                        url: '/Student/UploadImageUsingAjax',
                        data: formData,
                        dataType: 'json',
                        contentType: false,
                        processData: false,
                        success: function (response) {
        //alert('succes!!');



    },
                        error: function (error) {
        alert("error");
    }
                    });
                    //////////////////////////////////////////
                }



                else {
        //alert("khan");
        $('#alertMessage').html("<h5>" + message + "</h5>");
    }
            }
            else {
        $('#alertMessage').html("This browser doesn't support HTML5 file uploads!");
    }


        });

        var singleFileSelected = function (evt) {
            //var selectedFile = evt.target.files can use this  or select input file element
            //and access it's files object
            var selectedFile = ($("#imageUploadForm"))[0].files[0];//FileControl.files[0];
            if (selectedFile) {

                var FileSize = 0;
                var imageType = /image.*/;
                if (selectedFile.size > 1048576) {
                    // FileSize = Math.round(selectedFile.size * 100 / 1048576) / 100 + " MB";
                    return "Please Insert a Smaller Size File";
                }

                /*
                else if (selectedFile.size > 1024) {
        FileSize = Math.round(selectedFile.size * 100 / 1024) / 100 + " KB";
    }
                else {
        FileSize = selectedFile.size + " Bytes";
    }
                // here we will add the code of thumbnail preview of upload images

                $("#FileName").text("Name : " + selectedFile.name);
                $("#FileType").text("type : " + selectedFile.type);
                $("#FileSize").text("Size : " + FileSize);*/
                else if (!(selectedFile.type == "image/jpeg" || selectedFile.type == "image/jpg" ||
                    selectedFile.type == "image/png" || selectedFile.type == "image/gif")) {
                    return "Please Insert Appropriate Format File";
                }
                /*
                                else if ($(selectedFile).height() > 200 || $(selectedFile).width() > 200) {
                                    return "Image Resolution Must Be Within (200x200)pixel";

                                }*/


                else { return "FileOk"; }
            }
        }

    });


