<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="DigitalAdmin.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="col-lg-6">
            <button type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal">Add New Category</button>
            <br />
            <br />
            <table class="table table-bordered" id="categorytable">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Image</th>
                        <th>Action</th>
                    </tr>

                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add New Category</h4>
                </div>
                <div class="modal-body">
                    <form id="AddNewCategory">
                        <div class="form-group">
                            <label for="inputCategoryName">Category Name</label>
                            <input type="text" class="form-control" name="NAME" id="inputCategoryName" placeholder="Category Name">
                        </div>

                        <div class="form-group">
                            <label for="inputCategoryFile">Select Image</label>
                            <input type="file" id="inputCategoryFile">
                        </div>


                    </form>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-success" id="savecategory">Submit</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>

            </div>

        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade" id="editModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Update Category</h4>
                </div>
                <div class="modal-body">
                    <form id="EditCategory">

                        <div class="form-group text-center">
                            <input type="file" accept=".png, .jpg" id="editCategoryFile" style="display: none" />
                            <img class='img img-responsive img-thumbnail' id="editImage" style="height: 150px; width: 150px; cursor: pointer;" onclick='return OpenFileBrowser(event)' src="" alt="" />
                        </div>
                        <div class="form-group">
                            <label for="editCategoryName">Category Name</label>
                            <input type="text" class="form-control" name="NAME" id="editCategoryName" placeholder="Category Name">
                        </div>
                        <input type="hidden" id="editID" name="ID" />


                        <div class="form-group">
                            <label for="editSynonyms">Synonyms</label>
                            <input type="text" class="form-control" name="SYNONYMS" id="editSynonyms" placeholder="Synonyms">
                        </div>
                        <div class="form-group">
                            <label for="editStatus">Select Status</label>
                            <select name="Status" class="form-control" id="editStatus" placeholder="Select Status">
                                <option value="Active">Active</option>
                                <option value="Disable">Disable</option>
                            </select>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-success" id="updateCategory">Update</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>

            </div>

        </div>
    </div>
    <div class="modal fade" id="deleteModal" role="dialog">
        <div class="modal-dialog">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Delete Category</h4>
                </div>
                <div class="modal-body">
                    <h5>Are you Sure you want to Delete ?? </h5>

                </div>
                <div class="modal-footer">
                    <button type="submit" class="btn btn-success" id="deleteCategory">Delete</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                </div>

            </div>

        </div>
    </div>
    <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#editImage').attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

        deleteCategory = function (ID) {
            $.ajax({
                type: 'GET',
                url: 'http://localhost:55793/api/Category',
                data: { id: ID },
                beforeSend: function () {

                },
                success: function (data) {

                    var categoryId = data.ID;


                    $('#deleteCategory').click(function (e) {

                        e.preventDefault();

                        $.ajax({
                            type: 'Delete',
                            url: 'http://localhost:55793/api/Category/' + categoryId,

                            contentType: false, // Not to set any content header
                            processData: false, // Not to process data
                            beforeSend: function () {
                                $('#deleteCategory').val("Saving...");
                            },
                            success: function (data) {
                                $('#deleteCategory').val("Save");

                                $("#deleteModal .close").click();
                                loadData();
                            },
                            complete: function (a, b, c) {
                            }
                        })
                    });




                }
            });
        };

        $("#editCategoryFile").change(function () {
            readURL(this);
        });

        loadCategory = function (ID) {
            $.ajax({
                type: 'GET',
                url: 'http://localhost:55793/api/Category',
                data: { id: ID },
                beforeSend: function () {
                },
                success: function (data) {

                    $('#editCategoryName').val(data.NAME);
                    $('#editSynonyms').val(data.SYNONYMS);
                    $('#editCategory').val(data.Status);
                    $('#editImage').attr('src', data.IMAGEURL);
                    $('#editID').val(data.ID);


                }
            });
        };
        loadData = function () {
            $.ajax({
                type: 'GET',
                url: 'http://localhost:55793/api/Category',
                beforeSend: function () {

                },
                success: function (data) {

                    $('#categorytable tr').remove();
                    var table = $('#categorytable tbody');
                    $.each(data, function (i, val) {
                        table.append('<tr><td>' + val.NAME + '</td><td><img src="' + val.IMAGEURL + '" class="img img-circle img-responsive" style="height:50px; width:50px"/></td><td><button type="button" class="btn btn-success" data-toggle="modal" data-target="#editModal"  onclick=" return loadCategory(' + val.ID + ')" >Edit</button></td><td><button type="button" class="btn btn-success" data-toggle="modal" data-target="#deleteModal"  onclick=" return deleteCategory(' + val.ID + ')" >Delete</button></td></tr>');
                        //table.append(' <div class="w3-card-12" style="width:33%;text-align:center"><img class="img img-circle" src="' + val.IMAGEURL + '" alt="Norway" style="width:50%"><div class="w3-container w3-center" style="margin-top:10px;background:#EEE"><p style="margin:20px">' + val.NAME + '</p></div></div>');
                        //  table.append('<div class="w3-card-4"> <img src="img_car.jpg" alt="Car" style="width:100%">  <div class="w3-container w3-large w3-white">    <p>For Sale</p>   </div>  </div>');
                    });


                }
            });
        };
        $(document).ready(function () {
            loadData();
            //$('[data-toggle=confirmation]').confirmation({
            //    rootSelector: '[data-toggle=confirmation]',
            //    // other options
            //});
            $('#updateCategory').click(function (e) {

                e.preventDefault();
                var id = $('#editID').val();

                var fd = new FormData();
                var file = $('#editCategoryFile')[0];
                var data = {};
                $("#EditCategory").serializeArray().map(function (x) { data[x.name] = x.value; });
                fd.append("code", JSON.stringify(data));
                fd.append("file", file.files[0]);
                $.ajax({
                    type: 'Put',
                    url: 'http://localhost:55793/api/Category/' + id,
                    data: fd,
                    contentType: false, // Not to set any content header
                    processData: false, // Not to process data
                    beforeSend: function () {
                        $('#updateCategory').val("Updating Data...");
                    },
                    success: function (data) {
                        alert('Category updated successfully !!');
                        $('#updateCategory').val("Save");
                        $("#editModal .close").click();
                        loadData();
                    },
                    complete: function (a, b, c) {
                    }
                })
            });
            $('#savecategory').click(function (e) {
                e.preventDefault();
                var fd = new FormData();
                var file = $('input[type="file"]')[0];
                var data = {};
                $("#AddNewCategory").serializeArray().map(function (x) { data[x.name] = x.value; });
                //fd.append("code", JSON.stringify(category));
                fd.append("code", JSON.stringify(data));
                fd.append("file", file.files[0]);
                $.ajax({
                    type: 'POST',
                    url: 'http://localhost:55793/api/Category',
                    data: fd,
                    contentType: false, // Not to set any content header
                    processData: false, // Not to process data
                    beforeSend: function () {
                        $('#savecategory').val("Saving...");
                    },
                    success: function (data) {
                        $('#savecategory').val("Save");

                        $("#myModal .close").click();
                        loadData();
                    },
                    complete: function (a, b, c) {
                    }
                })
            });

        });

        function OpenFileBrowser(elem) {
            $('#editCategoryFile').click()
        }

    </script>
</asp:Content>
