<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SubCategory.aspx.cs" Inherits="DigitalAdmin.WebForm3" %>
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
                    <h4 class="modal-title">Add New SubCateogry</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label for="inputCategoryName">Category Name</label>
                            <select id="inputCategoryName" name="CATEGORYID">

                            </select>
                            
                        </div>

                        <div class="form-group">
                            <label for="inputSubCategoryName">SubCategory Name</label>
                            <input type="text" class="form-control" name="NAME" id="inputSubCategoryName" placeholder="SubCategory Name">
                        </div>

                        <div class="form-group">
                            <label for="inputSubCategoryFile">Select Image</label>
                            <input type="file" id="inputSubCategoryFile">
                        </div>

                         <div class="form-group">
                            <label for="inputSynonyms">Synonyms</label>
                            <input type="text" class="form-control" name="SYNONYMS" id="inputSynonyms" placeholder="Synonym">
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
        <script type="text/javascript">
            loadData = function () {
                $.ajax({
                    type: 'GET',
                    url: 'http://api.modinagarmycity.com/api/SubCategory',
                    beforeSend: function () {

                    },
                    success: function (data) {

                        $('#categorytable tr').remove();
                        var table = $('#categorytable tbody');
                        $.each(data, function (i, val) {
                            table.append('<tr><td>' + val.NAME + '</td><td><img src="' + val.IMAGEURL + '" class="img img-circle img-responsive" style="height:50px; width:50px"/></td><td><a href="#myModal" class="btn btn-success" id="fixed">Edit</a></td></tr>');
                            //table.append(' <div class="w3-card-12" style="width:33%;text-align:center"><img class="img img-circle" src="' + val.IMAGEURL + '" alt="Norway" style="width:50%"><div class="w3-container w3-center" style="margin-top:10px;background:#EEE"><p style="margin:20px">' + val.NAME + '</p></div></div>');
                            //  table.append('<div class="w3-card-4"> <img src="img_car.jpg" alt="Car" style="width:100%">  <div class="w3-container w3-large w3-white">    <p>For Sale</p>   </div>  </div>');
                        });


                    }
                });
            };
            loadCategoryNames = function () {
                $.ajax({
                    type: 'GET',
                    url: 'http://api.modinagarmycity.com/api/Category',
                    beforeSend: function () {

                    },
                    success: function (data) {

                        //$('#inputCategoryName').remove();
                        var categorylist = $('#inputCategoryName');
                        $.each(data, function (i, val) {
                            categorylist.append($("<option></option>").val
                    (val.ID).html(val.NAME));
                        });


                    }
                });
            };
            $(document).ready(function () {
                loadData();
                loadCategoryNames();
                $('#savecategory').click(function (e) {
                    e.preventDefault();
                    var fd = new FormData();
                    var file = $('input[type="file"]')[0];
                    var data = {};
                    $("form").serializeArray().map(function (x) { data[x.name] = x.value; });
                    //fd.append("code", JSON.stringify(category));
                    fd.append("code", JSON.stringify(data));
                    fd.append("file", file.files[0]);
                    $.ajax({
                        type: 'POST',
                        url: 'http://api.modinagarmycity.com/api/SubCategory',
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


    </script>
</asp:Content>
